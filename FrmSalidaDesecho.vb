
Imports System.Data.SqlClient
Imports System.Data

Public Class SALIDA

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Dim resp
        resp = MsgBox("Esta accion eliminara los datos no almacenados, ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            borrafolio(Me.TxtFolio.Text)
            borranocapt()
            Me.Close()
        End If
    End Sub

    Private Sub FrmSalidaDesecho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ft As Date
        traefecha()
        With Me
            .ChkCANT.Enabled = False
            .Txtvale.Enabled = False
            .TxtFolio.Enabled = False
            .TxtCodigo.Enabled = False
            .TxtCantidad.Enabled = False
            .Button1.Enabled = False
        End With
        'Traealmacenes()
        With ComboBox1
            .Items.Add("VENTA")
            .Items.Add("DEMOSTRACIONES")
            .Items.Add("TRANSFERENCIA")
            .Items.Add("DEVOLUCION")
            .SelectedIndex = 0
        End With
        Traealmacen()
        Me.Cbalm.SelectedIndex = 0
        ft = DateTime.Today
        Me.TxtFolio.Text = GeneraNuevoFolio()
        'TraeDatosClientes()
        Me.Cbalm.Focus()
        Me.DateTimePicker1.Text = ft
    End Sub

    Public Sub TraeDatosClientes()
        Dim SqlClientes As New SqlCommand("SELECT Abreviatura FROM Clientes ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.ComboBox1.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub ObtieneDescExi(ByVal Codigo As String, ByVal familia As String)

        Dim Sqlexis As New SqlCommand("SELECT sum(cantidad2) FROM LOTEEX2 WHERE [Codigo de Producto] = '" & Codigo & "' AND ALMACEN = '" & Me.Cbalm.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlexis.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    Me.LblExistencia.Text = "0.00"
                Else
                    Me.LblExistencia.Text = SqlRead.GetDecimal(0)
                End If

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub
    Public Sub sumaexis(ByVal Codigo As String)

        Dim Sqlexis As New SqlCommand("SELECT Cantidad FROM TSalALM WHERE Codigo = '" & Codigo & "' AND Folio = '" & Me.TxtFolio.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlexis.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) Then
                    Me.asuma.Text = "0.00"
                Else
                    Me.asuma.Text = SqlRead.GetDecimal(0)
                End If

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub
    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        If Me.TxtFolio.Text = Nothing Or Me.ComboBox1.Text = Nothing Then
            MsgBox("Error, favor de capturar los datos necesarios")
        Else

            If ValidaDetSal(Me.TxtFolio.Text) = Nothing Then
                MsgBox("Error, no hay datos para guardar")
            Else
                Dim F1 As String
                F1 = Me.DateTimePicker1.Text

                
                If GuardaSalida(Me.Txtvale.Text, "1", Me.Cbalm.Text, Me.TxtFolio.Text, F1, MDIPrincipal.StbUSER.Text, Me.ComboBox1.Text) = 0 Then
                    MsgBox("Registro Guardado")
                    With Me
                        .TxtFolio.Text = GeneraNuevoFolio()
                        .TxtCodigo.Text = Nothing
                        .TxtCantidad.Text = Nothing
                        .Txtvale.Text = Nothing
                        .LblDescripcion.Text = "."
                        .LblExistencia.Text = "."
                        '.ComboBox1.Text = Nothing
                        .lbltotal.Text = "."
                        .TxtCosto.Text = Nothing
                        CargaGrid3()
                        .Txtvale.Focus()
                    End With
                    'Me.Close()
                Else
                    MsgBox("La operacion presento errores")
                End If
            End If


        End If
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        Dim resp
        Dim F2 As String
        F2 = (Date.Today)
        resp = MsgBox("Esta accion eliminara este registro ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            On Error Resume Next
            borrar(Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 0))
            CargaGrid3()
            traesuma()
            Me.TxtCodigo.Focus()
        End If
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
                Me.TxtCodigo.Text = Traecodigo(Me.TxtCodigo.Text)
                ObtieneDescExi(Me.TxtCodigo.Text, "Herramienta")

                If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                    MsgBox("ERROR, Producto NO habilitado o no existe")
                    Me.TxtCodigo.Focus()
                    Me.TxtCodigo.SelectAll()
                Else
                    Traeprecio1()
                    sumaexis(Me.TxtCodigo.Text)
                    If Me.asuma.Text = Nothing Or Me.asuma.Text = "." Then
                        Me.asuma.Text = "0.00"
                    End If
                    If Me.ChkCANT.Checked = True Then
                        Me.TxtCantidad.Focus()
                    Else
                        Me.TxtCantidad.Text = "1.00"
                        validadatos()
                        Dim acant As Decimal
                        Dim aexistencia As Decimal
                        Dim asuma As Decimal
                        asuma = Me.asuma.Text
                        acant = Me.TxtCantidad.Text + asuma
                        If Me.LblExistencia.Text = Nothing Or Me.LblExistencia.Text = "." Then
                            aexistencia = "0.00"
                        Else
                            aexistencia = Me.LblExistencia.Text
                        End If

                        If acant > aexistencia Then
                            MsgBox("No hay existencia de este producto")
                            Me.TxtCantidad.Text = Nothing
                            Me.TxtCantidad.Focus()
                        Else

                            'FuncionesTempSal(Me.TxtFolio.Text, Me.TxtCodigo.Text, Me.TxtCantidad.Text, Me.LblExistencia.Text, Me.TxtCosto.Text)
                            If guardatempsal(Me.TxtFolio.Text) = 0 Then
                                traesuma()
                                With Me
                                    CargaGrid3()
                                    .asuma.Text = "0.00"
                                    .TxtCodigo.Text = Nothing
                                    .LblDescripcion.Text = "."
                                    .TxtCantidad.Text = Nothing
                                    .TxtCosto.Text = Nothing
                                    .LblExistencia.Text = "."
                                    .TxtCodigo.Focus()
                                End With
                            Else
                                MsgBox("no guardo datos")
                            End If
                        End If

                    End If

                End If
            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCantidad.Text = Nothing Or Me.TxtCantidad.Text = "0" Or Me.TxtCantidad.Text = "0.00" Then
                MsgBox("Error, favor de capturar la cantidad")
                Me.TxtCantidad.Focus()
            Else
                If Me.TxtCodigo.Text = Nothing Or Me.TxtCantidad.Text = Nothing Or Me.LblDescripcion.Text = "." Then
                    MsgBox("Error, favor de capturar todos los datos")
                Else
                    validadatos()
                    Dim acant As Decimal
                    Dim aexistencia As Decimal
                    Dim asuma As Decimal
                    asuma = Me.asuma.Text
                    acant = Me.TxtCantidad.Text + asuma
                    If Me.LblExistencia.Text = Nothing Or Me.LblExistencia.Text = "." Then
                        aexistencia = "0.00"
                    Else
                        aexistencia = Me.LblExistencia.Text
                    End If

                    If acant > aexistencia Then
                        MsgBox("No hay existencia de este producto")
                        Me.TxtCantidad.Text = Nothing
                        Me.TxtCantidad.Focus()
                    Else

                        'FuncionesTempSal(Me.TxtFolio.Text, Me.TxtCodigo.Text, Me.TxtCantidad.Text, Me.LblExistencia.Text, Me.TxtCosto.Text)
                        If guardatempsal(Me.TxtFolio.Text) = 0 Then
                            traesuma()
                            With Me
                                CargaGrid3()
                                .asuma.Text = "0.00"
                                .TxtCodigo.Text = Nothing
                                .LblDescripcion.Text = "."
                                .TxtCantidad.Text = Nothing
                                .TxtCosto.Text = Nothing
                                .LblExistencia.Text = "."
                                .TxtCodigo.Focus()
                            End With
                        Else
                            MsgBox("no guardo datos")
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub TxtCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCosto.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCosto.Text = Nothing Then
                MsgBox("Error, favor de capturar costo")
                Me.TxtCosto.Focus()
            Else
                Me.TxtCantidad.Focus()
            End If
        End If
    End Sub
    Private Sub Txtvale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtvale.KeyPress

        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If Me.Txtvale.Text = Nothing Then
                MsgBox("Error, favor de capturar numero")
                Me.Txtvale.Focus()
            Else
                Me.TxtCodigo.Enabled = True
                Me.ChkCANT.Enabled = True
                Me.Button1.Enabled = True
                Me.TxtCodigo.Focus()
            End If
        End If
    End Sub
    Public Sub CargaGrid3()

        Dim DS As New DataTable

        Try
            Dim F1 As String
            F1 = Me.TxtFolio.Text
            Dim SqlSel1 As New SqlDataAdapter("SELECT a.Codigo, b.alterno, b.Descripcion, a.Cantidad, a.Costo FROM TSalALM a, productos b WHERE a.Codigo = b.[Codigo de producto] AND a.Folio = '" & F1 & "'", SqlCnn)
            SqlSel1.Fill(DS)
            Me.DataGrid1.DataSource = DS

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.TxtCodigo.Focus()
    End Sub
    Private Sub traesuma()
        Dim folio As String
        folio = Me.TxtFolio.Text
        Dim Sqlsuma As New SqlCommand("SELECT Folio, SUM(Total) FROM TSalALM WHERE Folio = '" & folio & "' Group by folio ORDER BY folio", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlsuma.ExecuteReader
            While SqlRead.Read
                Me.lbltotal.Text = SqlRead.GetDecimal(1)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub borrar(ByVal Codigo As String)
        Dim folio As Integer
        folio = Me.TxtFolio.Text
        Dim SqlDelDetSalRes As New SqlCommand("DELETE FROM TSalALM WHERE Codigo = '" & Codigo & "' AND Folio = '" & folio & "'", SqlCnn)
        Try
            SqlDelDetSalRes.ExecuteNonQuery()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Traeprecio1()


        Dim Sqlprecio1 As New SqlCommand("SELECT ROUND(sum(cantidad2 * costo2)/sum(cantidad2),2) FROM LOTEEX2 WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' AND ALMACEN = '" & Me.Cbalm.Text & "'  ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio1.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    Me.TxtCosto.Text = "0.00"
                Else
                    Me.TxtCosto.Text = SqlRead.GetDecimal(0)
                End If
                'Me.TxtCosto.Text = SqlRead.GetDecimal(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Function borranocapt()

        Dim folio = Me.TxtFolio.Text
        Dim Sqlborra As New SqlCommand("IF EXISTS (SELECT * FROM TSalAlm WHERE Folio = '" & folio & "') " & _
        "BEGIN " & _
        "DELETE FROM TSalAlm WHERE Folio = '" & folio & "' " & _
        "End ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlborra.ExecuteReader
            While SqlRead.Read
                'folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Private Sub validadatos()
        If Me.TxtFolio.Text = Nothing Or Me.TxtFolio.Text = "0" Then
            MsgBox("Folio no Existe, reiniciar la aplicacion")
            Me.Close()
        Else
            If Me.TxtCodigo.Text = Nothing Or Me.TxtCodigo.Text = "0" Then
                MsgBox("El codigo no existe favor de capturarlo nuevamente")
                Me.TxtCodigo.Focus()
            Else
                If Me.TxtCantidad.Text = Nothing Or Me.TxtCantidad.Text = "0" Then
                    MsgBox("No ha capturado cantidad")
                    Me.TxtCodigo.Focus()
                Else
                    If Me.TxtCosto.Text = Nothing Or Me.TxtCosto.Text = "0" Then
                        MsgBox("No ha capturado costo")
                        Me.TxtCodigo.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Function guardatempsal(ByVal folio As String) As Integer

        Dim total As Decimal
        Dim cost As Decimal
        Dim cant As Decimal
        cost = Me.TxtCosto.Text
        cant = Me.TxtCantidad.Text
        total = cost * cant

        Dim Sqltempsal As New SqlCommand("DECLARE @Descripcion nchar(30) " & _
        "DECLARE @Folio nchar(10) " & _
        "DECLARE @Codigo nchar(20) " & _
        "DECLARE @Cantidad decimal(12,2) " & _
        "DECLARE @Costo decimal(12,2) " & _
        "DECLARE @total decimal(20,2) " & _
        "SET @Folio = '" & Me.TxtFolio.Text & "' " & _
        "SET @Codigo = '" & Me.TxtCodigo.Text & "' " & _
        "SET @Costo = " & Me.TxtCosto.Text & " " & _
        "SET @Cantidad = " & Me.TxtCantidad.Text & " " & _
        "SET @total = " & total & " " & _
        "IF EXISTS(SELECT * FROM TSalALM WHERE Folio = '" & Me.TxtFolio.Text & "' AND Codigo = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE TSalALM SET Cantidad = Cantidad + @Cantidad WHERE Folio = @Folio AND Codigo = @Codigo " & _
        "UPDATE TSalALM SET Total = Costo * Cantidad   WHERE Folio = @Folio AND Codigo = @Codigo " & _
        "UPDATE TSalALM SET Costo = @Costo WHERE Folio = @Folio AND Codigo = @Codigo " & _
        "END " & _
        "ELSE " & _
        "BEGIN " & _
        "SELECT @Descripcion = [Nombre corto] FROM productos WHERE [Codigo de producto] = @Codigo " & _
        "INSERT INTO TSalALM VALUES(@Folio,@Codigo,@Cantidad,@Costo,@Descripcion,@total) " & _
        "End ", SqlCnn)

        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqltempsal.ExecuteReader
            While SqlRead.Read
                folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Private Function Traecodigo(ByVal codigo) As String

        Dim SqlSelDes As New SqlCommand("SELECT [Codigo de Producto] FROM productos WHERE [Codigo de Producto] = '" & codigo & "' OR alterno = " & codigo & " and Baja = 'NO' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                code = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return code

    End Function

   
    Public Sub Traealmacen()
        Dim SqlClientes As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY a.almacen", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.Cbalm.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Traealmacenes()
        Dim SqlClientes As New SqlCommand("SELECT abreviatura FROM almacenes ORDER BY abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.ComboBox1.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbalm.SelectedIndexChanged
        Me.Cbalm.Enabled = False
        Me.Txtvale.Enabled = True
        Me.Txtvale.Focus()
    End Sub

    Private Sub ChkCANT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCANT.CheckedChanged
        If Me.ChkCANT.Checked = True Then
            Me.TxtCantidad.Enabled = True
            Me.TxtCodigo.Focus()
        Else
            Me.TxtCantidad.Enabled = False
            Me.TxtCodigo.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With Buscador
            .Show(Me)
            Buscador.lbform.Text = 1
        End With
    End Sub

    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub
    Private Sub Traefecha()
        Dim Sqlfecha As New SqlCommand("declare @date datetime set @date = GETDATE() select @date ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = Sqlfecha.ExecuteReader
            While SqlRead.Read
                Me.DateTimePicker1.Value = SqlRead.GetDateTime(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
End Class