Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO


Public Class consinventarios
    Private m_ChildFormNumber As Integer = 0
    Private Sub cantExisten()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text

        'Dim Sqlprecio As New SqlCommand("Select ROUND(sum(cantidad2 * costo2)/sum(cantidad2),2) FROM LOTEEX2 WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND Almacen = '" & Me.CBALMI.Text & "' ", SqlCnn)
        Dim Sqlprecio As New SqlCommand("declare @totUbi as int, @totAlm as int, @TotMax as int set @totAlm = (select sum(b.cantidad2) from LOTEEX2 as b where b.[Codigo de producto]  = '" & Me.TxtCodigo.Text & "' and b.Almacen  = '" & Me.Cbalm.Text & "') set @totUbi = (select sum(a.Inva_Cantidad) from INVENTARIOSA as a where a.Inva_Codigo = '" & Me.TxtCodigo.Text & "' and a.Inva_Almi = '" & Me.Cbalm.Text & "') set @TotMax = @totAlm - @totUbi SELECT @totAlm, @totUbi, @TotMax ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(2) = True Then
                    Me.LblExistencia.Text = 0
                Else

                    Me.LblExistencia.Text = SqlRead.GetSqlInt32(2)
                End If

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub consinventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MDIPrincipal.StbCAT.Text = "MASTER              " Then
            Me.ToolStripButton1.Enabled = True
        End If
        Me.ComboBox1.Enabled = False
        Me.ComboBox2.Enabled = False
        'Me.TextBox1.Enabled = False
        CargaALMACEN()
        Me.Cbalm.SelectedIndex = 0
        CargaUsuario()
        Cargatipo()
        Me.Cbalm.Focus()
    End Sub

    Private Sub CargaUsuario()
        Dim SqlSelEmp As New SqlCommand("SELECT Nombre From Usuarios ORDER BY Nombre", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.ComboBox2.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Cargatipo()
        Dim SqlSelfam As New SqlCommand("SELECT Abreviatura From Familias ORDER By Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelfam.ExecuteReader
            While SqlRead.Read
                Me.ComboBox1.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex1 As Exception
            MsgBox(ex1.Message.ToString)
        End Try
    End Sub
    Private Sub Cargadatagrid()

        Dim Fec1 As Date
        Fec1 = Me.DateTimePicker1.Text
        Dim cbsqlstring As String
        If Me.Cbalm.Text = "A. CENTRAL" Then
            cbsqlstring = "SELECT a.Inv_Codigo as Codigo, b.descripcion as descripcion, a.Inv_Cantidad as Cantidad, Inv_Fecha as Fecha, a.Inv_Empleado as Empleado, c.abreviatura as Familia, a.Inv_Ubicacion as Ubicacion, a.Inv_Precio as Costo FROM Inventarios a, productos b, familias c Where a.Inv_codigo = b.[Codigo de producto] and b.familia = c.clave and a.Inv_Fecha = '" & Fec1 & "' "
        Else
            cbsqlstring = "SELECT a.Inva_Codigo as Codigo, b.descripcion as descripcion, a.Inva_Cantidad as Cantidad, Inva_Fecha as Fecha, a.Inva_Empleado as Empleado, c.abreviatura as Familia, a.Inva_Ubicacion as Ubicacion, a.Inva_Precio as Costo FROM InventariosA a, productos b, familias c Where a.Inva_Almi = '" & Me.Cbalm.Text & "' AND a.Inva_codigo = b.[Codigo de producto] and b.familia = c.clave and a.Inva_Caduce = '" & Fec1 & "' "
        End If
        'MsgBox(cbsqlstring)

        Dim SqlSel As New SqlDataAdapter(cbsqlstring, SqlCnn)

        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
            With Me.Griinv
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub Cargadatagridusu()

        Dim Fec1 As DateTime
        Dim usu As String
        usu = Me.ComboBox2.Text
        Fec1 = Me.DateTimePicker1.Text
        Dim cbsqlstring As String
        If Me.Cbalm.Text = "A. CENTRAL     " Then
            cbsqlstring = "SELECT a.Inv_Codigo as Codigo, b.descripcion as descripcion, a.Inv_Cantidad as Cantidad, Inv_Fecha as Fecha, a.Inv_Empleado as Empleado, c.abreviatura as Familia, a.Inv_Ubicacion as Ubicacion, a.Inv_Precio as Costo FROM Inventarios a, productos b, familias c Where a.Inv_codigo = b.[Codigo de producto] and b.familia = c.clave and Inv_Fecha = '" & Fec1 & "' and Inv_Empleado = '" & usu & "'"
        Else
            cbsqlstring = "SELECT a.Inva_Codigo as Codigo, b.descripcion as descripcion, a.Inva_Cantidad as Cantidad, Inva_Fecha as Fecha, a.Inva_Empleado as Empleado, c.abreviatura as Familia, a.Inva_Ubicacion as Ubicacion, a.Inva_Precio as Costo FROM InventariosA a, productos b, familias c Where a.Inva_Almi = '" & Me.Cbalm.Text & "' AND a.Inva_codigo = b.[Codigo de producto] and b.familia = c.clave and Inva_Caduce = '" & Fec1 & "' and Inva_Empleado = '" & usu & "'"
        End If
        Dim SqlSel As New SqlDataAdapter(cbsqlstring, SqlCnn)

        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
            With Me.Griinv
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub
    Private Sub Cargadatagridfam()

        Dim Fec1 As DateTime
        Dim fam As String
        fam = Me.ComboBox1.Text
        Fec1 = Me.DateTimePicker1.Text
        Dim cbsqlstring As String
        If Me.Cbalm.Text = "A. CENTRAL     " Then
            cbsqlstring = "SELECT a.Inv_Codigo as Codigo, b.descripcion as descripcion, a.Inv_Cantidad as Cantidad, Inv_Fecha as Fecha, a.Inv_Empleado as Empleado, c.abreviatura as Familia, a.Inv_Ubicacion as Ubicacion, a.Inv_Precio as Costo FROM Inventarios a, productos b, familias c Where a.Inv_codigo = b.[Codigo de producto] and b.familia = c.clave and a.Inv_Fecha = '" & Fec1 & "' and c.abreviatura = '" & fam & "'"
        Else
            cbsqlstring = "SELECT a.Inva_Codigo as Codigo, b.descripcion as descripcion, a.Inva_Cantidad as Cantidad, Inva_Fecha as Fecha, a.Inva_Empleado as Empleado, c.abreviatura as Familia, a.Inva_Ubicacion as Ubicacion, a.Inva_Precio as Costo FROM InventariosA a, productos b, familias c Where a.Inva_Almi = '" & Me.Cbalm.Text & "' AND a.Inva_codigo = b.[Codigo de producto] and b.familia = c.clave and a.Inva_Caduce = '" & Fec1 & "' and c.abreviatura = '" & fam & "'"
        End If
        Dim SqlSel As New SqlDataAdapter(cbsqlstring, SqlCnn)

        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
            With Me.Griinv
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub
    Private Sub CheckBox1_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged
        If Me.CheckBox1.Checked = True Then

            Me.ComboBox2.Enabled = True
            Me.CheckBox2.Checked = False
            'Me.CheckBox3.Checked = False

        Else

            Me.ComboBox2.Enabled = False
            Me.ComboBox2.Text = Nothing

        End If
    End Sub

    Private Sub CheckBox2_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckStateChanged
        If Me.CheckBox2.Checked = True Then
            Me.ComboBox1.Enabled = True
            Me.CheckBox1.Checked = False
            'Me.CheckBox3.Checked = False

        Else
            Me.ComboBox1.Enabled = False
            Me.ComboBox1.Text = Nothing
        End If
    End Sub
    

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        If Me.Cbalm.Text = Nothing Then
            MsgBox("Error, favor de capturar el almacen")
            Me.Cbalm.Focus()
        Else
            busqueda()
        End If

    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click

        If Me.Cbalm.Text = Nothing Then
            MsgBox("Error, favor de capturar el almacen")
            Me.Cbalm.Focus()
        Else
            busqueda()
            If Me.Cbalm.Text = "A. CENTRAL" Then
                With Reports1
                    .Show(Me)
                End With
            Else
                Diferencias2A(Me.DateTimePicker1.Text, Me.Cbalm.Text)
                Diferencias2B(Me.DateTimePicker1.Text, Me.Cbalm.Text)
                'With Reports5
                '    .Show(Me)
                'End With

                For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
                    If MDIPrincipal.MdiChildren(i).Text = "Inventarios" Then

                        MDIPrincipal.MdiChildren(i).Close()
                        Exit For
                    Else
                    End If
                Next

                Dim chReportClRut As New Reports5
                chReportClRut.MdiParent = MDIPrincipal
                m_ChildFormNumber += 1
                chReportClRut.Show()

            End If


        End If
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub
    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress

        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo")
                Me.TxtCodigo.Focus()
            Else
                Dim Cadena As String
                Dim medcod As String
                Dim pesokg As String
                Dim pesogr As String
                Dim verpeso As String
                Me.Txtprev.Text = 0
                Me.LblExistencia.Text = 0
                Cadena = Me.TxtCodigo.Text
                medcod = Mid(Cadena, 1, 2)
                If medcod = "99" Then
                    'MsgBox("es peso")
                    medcod = Mid(Cadena, 1, 6)
                    Me.TxtCodigo.Text = medcod
                    pesokg = Mid(Cadena, 7, 2)
                    pesogr = Mid(Cadena, 9, 2)
                    verpeso = (pesokg & "." & pesogr)
                    Me.TxtCantidad.Text = verpeso

                Else

                End If
                Me.LblDescripcion.Text = TraeDescripcion(Me.TxtCodigo.Text)
                Traecodigo1()
                If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                    MsgBox("ERROR, Producto NO habilitado o no existe")
                    Me.TxtCodigo.Focus()
                    Me.TxtCodigo.SelectAll()
                Else
                    'Traefam()
                    Traeum()
                    cantprev()
                    cantExisten()

                    Me.TxtCantidad.Focus()
                End If
            End If
        End If

    End Sub
    Public Sub Traecodigo1()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim Sqlprecio As New SqlCommand("SELECT [Codigo de producto] FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & " and Baja = 'NO' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                Me.TxtCodigo.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub Traeum()

        Dim Sqlprecio As New SqlCommand("SELECT a.abreviatura FROM unidaddemedida a, productos b WHERE b.[Unidad de medida] = a.clave AND b.[Codigo de producto] = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                Me.LBUM.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub cantprev()

        'Dim Sqlprevi As New SqlCommand("SELECT Inv_Cantidad FROM Inventarios WHERE Inv_Fecha = '" & Me.DateTimePicker1.Text & "' AND Inv_Codigo = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
        Dim Sqlprevi As New SqlCommand("SELECT Inva_Cantidad FROM Inventariosa WHERE Inva_Caduce = '" & Me.DateTimePicker1.Text & "' AND Inva_Codigo = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprevi.ExecuteReader
            While SqlRead.Read
                Me.Txtprev.Text = SqlRead.GetDecimal(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub CargaALMACEN()
        'Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From ALMACENES ORDER BY Abreviatura", SqlCnn)
        Dim SqlSelEmp As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY a.almacen", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.Cbalm.Items.Add(SqlRead.GetString(0))

            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbalm.SelectedIndexChanged
        'Me.Cbalm.Enabled = False
    End Sub
    Private Sub busqueda()
        If Me.CheckBox1.Checked = True Then
            If Me.ComboBox2.Text = Nothing Then
                MsgBox("Error, requiere seleccionar un usuario")
                Me.ComboBox2.Focus()
            Else
                Cargadatagridusu()
            End If
        Else
            If Me.CheckBox2.Checked = True Then
                If Me.ComboBox1.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar una familia")
                    Me.ComboBox1.Focus()
                Else
                    Cargadatagridfam()
                End If
            Else
                Cargadatagrid()
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim resp

        resp = MsgBox("Esta accion eliminara las existencias actuales de los productos inventariados, ¿Desea actualizar las existencias?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If Me.Cbalm.Text = "A. CENTRAL" Then
                If Guardaexistencias(Me.DateTimePicker1.Text) = 0 Then
                    actualexistencias(Me.DateTimePicker1.Text)
                    borraexistencias(Me.DateTimePicker1.Text)
                    borraexistenciasLotes(Me.DateTimePicker1.Text)
                    MsgBox("Existencias Actualizadas")

                Else
                    MsgBox("La operacion presento errores")
                End If
            Else
                If Guardaexistencias2(Me.DateTimePicker1.Text, Me.Cbalm.Text) = 0 Then
                    actualexistencias2(Me.DateTimePicker1.Text, Me.Cbalm.Text)
                    borraexistencias2(Me.DateTimePicker1.Text, Me.Cbalm.Text)
                    borraexistenciasLotes2(Me.DateTimePicker1.Text, Me.Cbalm.Text)
                    MsgBox("Existencias Actualizadas")

                Else
                    MsgBox("La operacion presento errores")
                End If
            End If

        End If

    End Sub

    Private Sub Griinv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Griinv.CellClick
        Dim code As String
        Dim desc As String
        Dim prev As String
        'Dim um As String
        If e.RowIndex >= -1 Then
            Exit Sub
        End If
        Dim value As Object = Griinv.Rows(e.RowIndex).Cells(0).Value()
        Dim value1 As Object = Griinv.Rows(e.RowIndex).Cells(1).Value
        Dim value2 As Object = Griinv.Rows(e.RowIndex).Cells(2).Value
        'Dim value3 As Object = Griinv.Rows(e.RowIndex).Cells(3).Value

        If value.GetType Is GetType(DBNull) Then Return

        code = CType(value, String)
        desc = CType(value1, String)
        prev = CType(value2, String)
        'um = CType(value3, String)

        Me.TxtCodigo.Text = code
        Me.LblDescripcion.Text = desc
        Me.Txtprev.Text = prev
        'Me.LBUM.Text = um


    End Sub

    Private Sub Griinv_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Griinv.CellContentClick

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.Txtprev.Text = Nothing Then
            Me.Txtprev.Text = 0
        End If

        If Me.Txtprev.Text = 0 Then
            MsgBox("el codigo no fue inventariado favor de capturarlo desde la terminal")
            busqueda()
            Me.TxtCodigo.Text = Nothing
            '.lbcosto.Text = Nothing
            Me.TxtCantidad.Text = Nothing
            Me.Txtprev.Text = Nothing
            '.Txtubi.Text = Nothing
            Me.LblDescripcion.Text = "."
            Me.TxtCodigo.Focus()
        Else
            If Me.TxtCantidad.Text = Nothing Then
                MsgBox("Error, favor de capturar la cantidad")
                Me.TxtCantidad.Focus()
            Else
                If Me.TxtCodigo.Text = Nothing Or Me.TxtCantidad.Text = Nothing Or Me.LblDescripcion.Text = "." Then
                    MsgBox("Error, favor de capturar todos los datos")
                Else
                    If (Val(Me.TxtCantidad.Text) + Val(Me.Txtprev.Text)) > Val(Me.LblExistencia.Text) Then
                        MsgBox("La cantidad mas cantidad previa no puede ser mayor a las Existencias", MsgBoxStyle.Exclamation)
                        Me.TxtCantidad.Focus()
                        Exit Sub
                    End If
                    If Val(Me.TxtCantidad.Text) > Val(Me.LblExistencia.Text) Then
                        MsgBox("La cantidad no puede ser mayor a las Existencias", MsgBoxStyle.Exclamation)
                        Me.TxtCantidad.Focus()
                        Exit Sub
                    End If
                    Dim resp

                    resp = MsgBox("¿Desea actualizar producto " & Me.LblDescripcion.Text & " ?", MsgBoxStyle.OkCancel)
                    If resp = vbOK Then
                        If Me.Cbalm.Text = "A. CENTRAL" Then
                            actualiza()
                        Else
                            actualiza2()
                        End If

                        MsgBox("Existencias Actualizadas")
                    End If

                    With Me
                        busqueda()
                        .TxtCodigo.Text = Nothing
                        '.lbcosto.Text = Nothing
                        .TxtCantidad.Text = Nothing
                        .Txtprev.Text = Nothing
                        '.Txtubi.Text = Nothing
                        .LblDescripcion.Text = "."
                        .TxtCodigo.Focus()
                    End With
                End If
            End If
        End If
    End Sub
    Private Function actualiza()

        Dim cant As Decimal
        cant = Me.TxtCantidad.Text
        Dim Sqltempsal As New SqlCommand("DECLARE @Codigo nchar(20) " & _
        "DECLARE @Cantidad decimal(12,2) " & _
        "DECLARE @fecha nchar(20) " & _
        "SET @Codigo = '" & Me.TxtCodigo.Text & "' " & _
        "SET @Cantidad = " & Me.TxtCantidad.Text & " " & _
        "SET @fecha = '" & Me.DateTimePicker1.Text & "' " & _
        "IF EXISTS(SELECT * FROM Inventarios WHERE Inv_Fecha = @fecha AND Inv_Codigo = @Codigo) " & _
        "BEGIN " & _
        "UPDATE Inventarios SET Inv_Cantidad = @Cantidad WHERE Inv_Fecha = @fecha AND Inv_Codigo = @Codigo " & _
        "END " , SqlCnn)

        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqltempsal.ExecuteReader
            While SqlRead.Read
                'folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Private Function actualiza2()

        Dim cant As Decimal
        cant = Me.TxtCantidad.Text
        Dim Sqltempsal As New SqlCommand("DECLARE @Codigo nchar(20) " & _
        "DECLARE @Cantidad decimal(12,2) " & _
        "DECLARE @fecha nchar(20) " & _
        "DECLARE @ALM nchar(20) " & _
        "SET @Codigo = '" & Me.TxtCodigo.Text & "' " & _
        "SET @Cantidad = " & Me.TxtCantidad.Text & " " & _
        "SET @fecha = '" & Me.DateTimePicker1.Text & "' " & _
        "SET @ALM = '" & Me.Cbalm.Text & "' " & _
        "IF EXISTS(SELECT * FROM InventariosA WHERE Inva_Caduce = @fecha AND Inva_Codigo = @Codigo AND Inva_almi = @ALM) " & _
        "BEGIN " & _
        "UPDATE InventariosA SET Inva_Cantidad = @Cantidad WHERE Inva_Caduce = @fecha AND Inva_Codigo = @Codigo AND Inva_almi = @ALM " & _
        "END ", SqlCnn)

        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqltempsal.ExecuteReader
            While SqlRead.Read
                'folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.TxtCodigo.Text = Nothing Or Me.LblDescripcion.Text = "." Then
            MsgBox("Error, favor de capturar todos los datos")
        Else
            Dim resp
            resp = MsgBox("¿Desea borrar producto " & Me.LblDescripcion.Text & " ?", MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                If Me.Cbalm.Text = "A. CENTRAL" Then
                    borraproducto2()
                Else
                    borraproducto()
                End If
                MsgBox("producto borrado")
            End If
            With Me
                busqueda()
                .TxtCodigo.Text = Nothing
                '.lbcosto.Text = Nothing
                .TxtCantidad.Text = Nothing
                .Txtprev.Text = Nothing
                '.Txtubi.Text = Nothing
                .LblDescripcion.Text = "."
                .TxtCodigo.Focus()
            End With
        End If
    End Sub
    Private Function borraproducto()

        Dim Sqltempsal As New SqlCommand("DELETE FROM InventariosA WHERE Inva_Caduce = '" & Me.DateTimePicker1.Text & "' AND Inva_Codigo = '" & Me.TxtCodigo.Text & "' AND Inva_Almi = '" & Me.Cbalm.Text & "' ", SqlCnn)

        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqltempsal.ExecuteReader
            While SqlRead.Read
                'folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Private Function borraproducto2()

        Dim Sqltempsal As New SqlCommand("DELETE FROM Inventarios WHERE Inv_Fecha = '" & Me.DateTimePicker1.Text & "' AND Inv_Codigo = '" & Me.TxtCodigo.Text & "' ", SqlCnn)

        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqltempsal.ExecuteReader
            While SqlRead.Read
                'folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.Cbalm.Text = Nothing Then
            MsgBox("Error, favor de capturar el almacen")
            Me.Cbalm.Focus()
        Else
            busqueda()
            If Me.Cbalm.Text = "A. CENTRAL" Then
                With Reports8
                    .Show(Me)
                End With
            Else
                'With Reports9
                '    .F1 = Me.DateTimePicker1.Value
                '    .NomAlm = Me.Cbalm.Text
                '    .Show(Me)

                'End With

                For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
                    If MDIPrincipal.MdiChildren(i).Text = "Reports9" Then

                        MDIPrincipal.MdiChildren(i).Close()
                        Exit For
                    Else
                    End If
                Next

                Dim chReportClRut As New Reports9
                chReportClRut.MdiParent = MDIPrincipal
                m_ChildFormNumber += 1
                chReportClRut.F1 = Me.DateTimePicker1.Value
                chReportClRut.NomAlm = Me.Cbalm.Text
                chReportClRut.Show()
            End If


        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        If Me.Cbalm.Text = Nothing Then
            MsgBox("Seleccionar Almacen")
        Else
            'With Reports_10
            '    .Show(Me)
            'End With
            For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
                If MDIPrincipal.MdiChildren(i).Text = "EXISTENCIAS" Then

                    MDIPrincipal.MdiChildren(i).Close()
                    Exit For
                Else
                End If
            Next

            Dim chReportClRut As New Reports_10
            chReportClRut.MdiParent = MDIPrincipal
            m_ChildFormNumber += 1
            chReportClRut.Show()
        End If

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'GUARDATOTALES("")
        If Me.Cbalm.Text = Nothing Then
            MsgBox("Seleccionar Almacen")
        Else
            'With Reports_13
            '    .Show(Me)
            'End With


            For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
                If MDIPrincipal.MdiChildren(i).Text = "REPORTE EXISTENCIAS" Then

                    MDIPrincipal.MdiChildren(i).Close()
                    Exit For
                Else
                End If
            Next

            Dim chReportClRut As New Reports_13
            chReportClRut.MdiParent = MDIPrincipal
            m_ChildFormNumber += 1
            chReportClRut.Show()
        End If

    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub
End Class