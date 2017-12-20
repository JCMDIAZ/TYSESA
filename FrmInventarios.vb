Imports System.Data
Imports System.Data.SqlClient

Public Class FrmInventarios

    Public F1 As String
    Private exis As Boolean
    Dim ALTER As Int32
    Private Sub FrmInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LBUSER.Text = MDIPrincipal.StbUSER.Text
        F1 = Me.DTIME1.Text
        CargaALMACEN()
        Me.CBALMI.SelectedIndex = 0
        Me.Txtubi.Text = "1A"
        Me.CBUBI.Text = "-- Seleeciona una Ubicacion --"
        CargaGridin()
        exis = False
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBALMI.SelectedIndexChanged
        'Me.Txtubi.Focus()
        Me.CBUBI.Items.Clear()
        TraeUbicaciones()
        Me.CBUBI.Focus()
        Me.CBUBI.Text = "-- Seleeciona una Ubicacion --"
        CargaGridin()
    End Sub
    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Sub TraeUbicaciones()
        Dim SqlSelEmp As New SqlCommand("SELECT a.ClaveS, a.NombreS, a.AbrS, a.ZonaS, a.AreaS, a.AlturaS, a.[offsetS], a.Almacen, b.Clave, b.Nombre, b.Abreviatura FROM dbo.SUBALMACENES AS a INNER JOIN dbo.ALMACENES AS b ON a.Almacen = b.Clave WHERE b.Abreviatura = '" & Me.CBALMI.Text.Trim & "' ORDER BY a.almacen", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBUBI.Items.Add(SqlRead.GetString(2))

            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Function Traefam(ByVal family) As String
        Dim SqlSelDes As New SqlCommand("SELECT clave From familias where abreviatura = '" & family & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim fam As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                fam = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return fam

    End Function
    Private Sub CargaALMACEN()
        'Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From ALMACENES ORDER BY Abreviatura", SqlCnn)
        Dim SqlSelEmp As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY a.almacen", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBALMI.Items.Add(SqlRead.GetString(0))

            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
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
                Traecodigo1()
                If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                    MsgBox("ERROR, Producto NO habilitado o no existe")
                    Me.TxtCodigo.Focus()
                    Me.TxtCodigo.SelectAll()
                Else
                    Traeprecio()
                    TotActUbic()
                    If Me.Txtcosto.Text = 0 Then
                        Traeprecio1()
                    End If
                    Traefam()
                    Traeum()
                    cantprev()
                    Me.TxtCantidad.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub Txtubi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtubi.KeyPress

        If e.KeyChar = Chr(13) Then
            If Me.Txtubi.Text = Nothing Then
                MsgBox("Error, favor de capturar el ubicacion")
                Me.Txtubi.Focus()
            Else
                'Me.Txtubi.Enabled = False
                'Me.CBALMI.Enabled = False
                Me.TxtCodigo.Focus()
            End If
        End If


    End Sub
    Public Sub Traecodigo1()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        'Dim Sqlprecio As New SqlCommand("SELECT [Codigo de producto], ALTERNO FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & " and Baja = 'NO' ", SqlCnn)
        Dim Sqlprecio As New SqlCommand("SELECT a.[Codigo de producto], a.[Nombre corto], a.[Precio de venta], b.MBARCODE, a.alterno FROM dbo.PRODUCTOS AS a INNER JOIN dbo.MULTIBARCODE AS b ON a.alterno = b.[Codigo de producto] WHERE (b.MBARCODE = '" & codigo & "') OR (a.[Codigo de producto] = '" & codigo & "') and a.Baja = 'NO' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        ALTER = 0
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                Me.TxtCodigo.Text = SqlRead.GetString(0)
                ALTER = SqlRead.GetInt32(4)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Traedes1()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim Sqlprecio As New SqlCommand("SELECT [Nombre Corto] FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & "", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                Me.LblDescripcion.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub TotActUbic()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text

        'Dim Sqlprecio As New SqlCommand("Select ROUND(sum(cantidad2 * costo2)/sum(cantidad2),2) FROM LOTEEX2 WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND Almacen = '" & Me.CBALMI.Text & "' ", SqlCnn)
        Dim Sqlprecio As New SqlCommand("declare @ubica as varchar(150), @totUbi as int, @totAlm as int, @TotMax as int set @totAlm = (select sum(b.cantidad2) from LOTEEX2 as b where b.[ALTER]  = '" & ALTER & "' and b.Almacen  = '" & Me.CBALMI.Text & "') set @totUbi = (select sum(a.Inva_Cantidad) from INVENTARIOSA as a where a.Inva_Codigo = '" & Me.TxtCodigo.Text & "' and a.Inva_Almi = '" & Me.CBALMI.Text & "') set @TotMax = @totAlm - @totUbi" & _
                                         " set @ubica = (select UUBI from UBICACIONES where UFEC = (select max(UFEC) from UBICACIONES where UCOD = '" & Me.TxtCodigo.Text & "' and UALM = '" & Me.CBALMI.Text & "')) if @ubica is null begin set @ubica = '' end if @TotMax < 0 begin set @TotMax = 0 end  SELECT @totAlm, @totUbi, @TotMax, @ubica ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(2) = True Then
                    Me.LblCanAlm.Text = 0
                Else

                    Me.LblCanAlm.Text = SqlRead.GetSqlInt32(2)
                End If
                'If SqlRead.IsDBNull(0) = True Then
                '    Me.LblCanAlm.Text = 0
                'Else

                '    Me.LblCanAlm.Text = SqlRead.GetSqlInt32(0)
                'End If
                If SqlRead.GetSqlString(3) = "" Then
                    Me.CBUBI.Text = ""
                    Me.CBUBI.Enabled = True
                    Me.LblUbiAct.Text = "."
                Else
                    'Me.CBUBI.Text = SqlRead.GetSqlString(3)
                    Me.LblUbiAct.Text = SqlRead.GetSqlString(3)
                    'Me.CBUBI.Enabled = False
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
            End Try

    End Sub

    Public Sub Traeprecio()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text

        'Dim Sqlprecio As New SqlCommand("Select ROUND(sum(cantidad2 * costo2)/sum(cantidad2),2) FROM LOTEEX2 WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND Almacen = '" & Me.CBALMI.Text & "' ", SqlCnn)
        Dim Sqlprecio As New SqlCommand("Select ROUND(sum(cantidad2 * costo2)/sum(cantidad2),2), sum(cantidad2) as can FROM LOTEEX2 WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND Almacen = '" & Me.CBALMI.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    Me.Txtcosto.Text = 0
                    Me.LblCanAlm.Text = 0
                Else
                    Me.Txtcosto.Text = SqlRead.GetDecimal(0)
                    Me.lbcosto.Text = SqlRead.GetDecimal(0)
                    Me.LblCanAlm.Text = SqlRead.GetSqlDecimal(1)
                End If

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub Traeprecio1()

        Dim Sqlprecio1 As New SqlCommand("Select [Precio de venta] FROM productos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio1.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    Me.txtcosto.Text = 0
                Else
                    Me.txtcosto.Text = SqlRead.GetDecimal(0)
                End If

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If e.KeyChar = Chr(13) Then
            'If Val(Me.TxtCantidad.Text) > Val(Me.LblCanAlm.Text) Then
            '    MsgBox("Error, la cantidad debe ser menor a la cantidad maxima...")
            '    Me.TxtCantidad.Focus()
            '    Me.TxtCantidad.SelectAll()
            '    Exit Sub
            'End If
            'If Me.TxtCantidad.Text = Nothing Then
            '    MsgBox("Error, favor de capturar la cantidad")
            '    Me.TxtCantidad.Focus()
            'Else
            '    If Me.TxtCodigo.Text = Nothing Or Me.TxtCantidad.Text = Nothing Or Me.LblDescripcion.Text = "." Then
            '        MsgBox("Error, favor de capturar todos los datos")
            '    Else
            '        If Me.Txtcosto.Text = Nothing Then
            '            MsgBox("Error, favor de capturar costo")
            '        Else
            '            guardainv()

            '            With Me
            '                CargaGridin()
            '                .TxtCodigo.Text = Nothing
            '                .lbcosto.Text = Nothing
            '                .TxtCantidad.Text = Nothing
            '                .Txtprev.Text = Nothing
            '                .LblDescripcion.Text = "."
            '                .TxtCodigo.Focus()
            '                .LblCanAlm.Text = "0"
            '            End With
            '        End If
            '    End If
            'End If
        End If
    End Sub
    Private Function guardainv()

        'Dim total As Decimal
        Dim user As String
        Dim cant As Decimal
        user = Me.LBUSER.Text
        cant = Me.TxtCantidad.Text
        'total = cost * cant

        'Dim Sqltempsal As New SqlCommand("DECLARE @fam nchar(20) " & _
        '"DECLARE @alm nchar(20) " & _
        '"DECLARE @Codigo nchar(20) " & _
        '"DECLARE @Cantidad decimal(12,2) " & _
        '"DECLARE @ubi nchar(10) " & _
        '"DECLARE @precio decimal(20,2) " & _
        '"DECLARE @fecha nchar(20) " & _
        '"DECLARE @usu nchar(20) " & _
        '"SET @alm = '" & Me.CBALMI.Text & "' " & _
        '"SET @Codigo = '" & Me.TxtCodigo.Text & "' " & _
        '"SET @ubi = '" & Me.CBUBI.Text & "' " & _
        '"SET @Cantidad = " & Me.TxtCantidad.Text & " " & _
        '"SET @precio = " & Me.Txtcosto.Text & " " & _
        '"SET @fecha = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' " & _
        '"SET @usu = '" & user & "' " & _
        '"IF EXISTS(SELECT * FROM InventariosA WHERE Inva_Almi = '" & Me.CBALMI.Text & "' AND convert(varchar(10),Inva_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' AND Inva_Codigo = @Codigo and Inva_Ubicacion = @ubi) " & _
        '"BEGIN " & _
        '"UPDATE InventariosA SET Inva_Cantidad = Inva_Cantidad + @Cantidad,Inva_Ubicacion = @ubi WHERE Inva_Almi = @alm AND convert(varchar(10),Inva_Fecha,103) = @fecha AND Inva_Codigo = @Codigo and Inva_Ubicacion = @ubi " & _
        '"END " & _
        '"ELSE " & _
        '"BEGIN " & _
        '"SELECT @fam = a.abreviatura FROM familias a, productos b WHERE b.familia = a.clave AND b.[Codigo de producto] = @Codigo " & _
        '"INSERT INTO InventariosA VALUES(@alm,@Codigo,@Cantidad,GETDATE(),@usu,@fam,@ubi,@precio,@Codigo,0,@fecha, '" & ALTER & "') " & _
        '"End ", SqlCnn)

        Dim Sqltempsal As New SqlCommand("DECLARE @fam nchar(20) " & _
        "DECLARE @alm nchar(20) " & _
        "DECLARE @Codigo nchar(20) " & _
        "DECLARE @Cantidad decimal(12,2) " & _
        "DECLARE @ubi nchar(10) " & _
        "DECLARE @precio decimal(20,2) " & _
        "DECLARE @fecha nchar(20) " & _
        "DECLARE @usu nchar(20) " & _
        "SET @alm = '" & Me.CBALMI.Text & "' " & _
        "SET @Codigo = '" & Me.TxtCodigo.Text & "' " & _
        "SET @ubi = '" & Me.CBUBI.Text & "' " & _
        "SET @Cantidad = " & Me.TxtCantidad.Text & " " & _
        "SET @precio = " & Me.Txtcosto.Text & " " & _
        "SET @fecha = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' " & _
        "SET @usu = '" & user & "' " & _
        "IF EXISTS(SELECT * FROM InventariosA WHERE Inva_Almi = '" & Me.CBALMI.Text & "' AND convert(varchar(10),Inva_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' AND Inva_ALTER = '" & ALTER & "' and Inva_Ubicacion = @ubi) " & _
        "BEGIN " & _
        "UPDATE InventariosA SET Inva_Cantidad = Inva_Cantidad + @Cantidad,Inva_Ubicacion = @ubi WHERE Inva_Almi = @alm AND convert(varchar(10),Inva_Fecha,103) = @fecha AND Inva_ALTER = '" & ALTER & "' and Inva_Ubicacion = @ubi " & _
        "END " & _
        "ELSE " & _
        "BEGIN " & _
        "SELECT @fam = a.abreviatura FROM familias a, productos b WHERE b.familia = a.clave AND b.[Codigo de producto] = @Codigo " & _
        "INSERT INTO InventariosA VALUES(@alm,@Codigo,@Cantidad,GETDATE(),@usu,@fam,@ubi,@precio,@Codigo,0,@fecha, '" & ALTER & "') " & _
        "End ", SqlCnn)
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
    Private Sub CargaGridin()

        Dim DS As New DataTable

        Try

            'Dim SqlSel1 As New SqlDataAdapter("SELECT a.Inva_Codigo, b.Descripcion, a.Inva_Cantidad, a.Inva_Empleado, a.Inva_Familia, a.Inva_Ubicacion, a.Inva_precio FROM InventariosA a, productos b WHERE a.Inva_Codigo = b.[Codigo de producto] AND Inva_Almi = '" & Me.CBALMI.Text & "' AND Inva_Fecha = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "'", SqlCnn)
            Dim SqlSel1 As New SqlDataAdapter("SELECT a.Inva_Codigo, b.Descripcion, a.Inva_Cantidad, a.Inva_Empleado, a.Inva_Familia, a.Inva_Ubicacion, a.Inva_precio, a.Inva_Fecha FROM InventariosA a, productos b WHERE a.Inva_Codigo = b.[Codigo de producto] AND Inva_Almi = '" & Me.CBALMI.Text & "' AND convert(varchar(10),Inva_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "'", SqlCnn)
            SqlSel1.Fill(DS)
            Me.DGINV.DataSource = DS

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub Traefam()
        
        Dim Sqlprecio As New SqlCommand("SELECT a.abreviatura FROM familias a, productos b WHERE b.familia = a.clave AND b.[Codigo de producto] = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                Me.LBFAM.Text = SqlRead.GetString(0)
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

        Dim Sqlprevi As New SqlCommand("SELECT Inva_Cantidad FROM InventariosA WHERE Inva_Almi = '" & Me.CBALMI.Text & "' AND Inva_Fecha = '" & Me.DTIME1.Text & "' AND Inva_Codigo = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
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

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        If exis = True Then
            MsgBox("Da click en Limpiar para agregar nuevo")
            Exit Sub
        End If
        If Val(Me.TxtCantidad.Text) > Val(Me.LblCanAlm.Text) Then
            MsgBox("Error, la cantidad debe ser menor o igual a la cantidad maxima...")
            Me.TxtCantidad.Focus()
            Me.TxtCantidad.SelectAll()
            Exit Sub
        End If
        If Me.TxtCantidad.Text = Nothing Then
            MsgBox("Error, favor de capturar la cantidad")
            Me.TxtCantidad.Focus()
        Else
            'If Me.TxtCodigo.Text = Nothing Or Me.TxtCantidad.Text = Nothing Or Me.LblDescripcion.Text = "." Then
            'If Me.Txtubi.Text = Nothing Then
            If Me.CBUBI.Text = Nothing Then
                'MsgBox("Error, favor de capturar todos los datos")
                MsgBox("Error, favor de capturar la ubicacion")
                Me.Txtubi.Focus()
            Else
                If Me.Txtcosto.Text = Nothing Then
                    MsgBox("Error, favor de capturar costo")
                Else
                    guardainv()

                    With Me
                        CargaGridin()
                        .TxtCodigo.Text = Nothing
                        .lbcosto.Text = Nothing
                        .TxtCantidad.Text = Nothing
                        .Txtprev.Text = Nothing
                        .LblDescripcion.Text = "."
                        .TxtCodigo.Focus()
                        .LblCanAlm.Text = "0"
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click

        If exis = False Then
            MsgBox("Favor de seleccionar un inventario de la lista")
            Exit Sub
        End If
        If Val(Me.TxtCantidad.Text) > Val(Me.LblCanAlm.Text) Then
            MsgBox("Error, la cantidad debe ser menor o igual a la cantidad que desea borrar...")
            Me.TxtCantidad.Focus()
            Me.TxtCantidad.SelectAll()
            Exit Sub
        End If

        If Me.TxtCodigo.Text = Nothing Or Me.LblDescripcion.Text = "." Then
            MsgBox("Error, favor de capturar todos los datos")
        Else
            Dim resp
            resp = MsgBox("¿Desea borrar producto " & Me.LblDescripcion.Text.Trim & " ?", MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                If Me.CBALMI.Text = "A. CENTRAL" Then
                    borraproducto2()
                Else
                    borraproducto()
                End If

                MsgBox("producto borrado")
            End If
            With Me
                CargaGridin()
                .TxtCodigo.Text = Nothing
                '.lbcosto.Text = Nothing
                .TxtCantidad.Text = Nothing
                .Txtprev.Text = Nothing
                .LblDescripcion.Text = "."
                .TxtCodigo.Focus()
                exis = False
            End With
        End If
    End Sub
    Private Function borraproducto()

        'Dim Sqltempsal As New SqlCommand("DELETE FROM InventariosA WHERE convert(varchar(10),Inva_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' AND Inva_Codigo = '" & Me.TxtCodigo.Text & "' AND Inva_Almi = '" & Me.CBALMI.Text & "' AND Inva_Cantidad = '" & Me.TxtCantidad.Text & "' ", SqlCnn)
        Dim Sqltempsal As New SqlCommand("declare @resaborr decimal declare @canabo decimal set @canabo = '" & Me.TxtCantidad.Text & "'  declare @canexis decimal set @canexis = (SELECT Inva_Cantidad FROM InventariosA where convert(varchar(10),Inva_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' AND Inva_Codigo = '" & Me.TxtCodigo.Text & "'  " & _
                                         " AND Inva_Almi = '" & Me.CBALMI.Text & "' AND Inva_Ubicacion = '" & Me.CBUBI.Text.Trim & "') if @canabo < @canexis begin set @resaborr = @canexis - @canabo update InventariosA SET Inva_Cantidad = @resaborr " & _
                                         " WHERE convert(varchar(10),Inva_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' AND Inva_Codigo = '" & Me.TxtCodigo.Text & "' AND Inva_Almi = '" & Me.CBALMI.Text & "' and Inva_Ubicacion = '" & Me.CBUBI.Text.Trim & "' end else  if @canabo = @canexis begin " & _
                                         " DELETE FROM InventariosA WHERE convert(varchar(10),Inva_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' AND Inva_Codigo = '" & Me.TxtCodigo.Text & "' AND Inva_Almi = '" & Me.CBALMI.Text & "' AND Inva_Cantidad = @canabo and Inva_Ubicacion = '" & Me.CBUBI.Text.Trim & "' end ", SqlCnn)
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

        Dim Sqltempsal As New SqlCommand("DELETE FROM Inventarios WHERE convert(varchar(10),Inv_Fecha,103) = '" & Format(Me.DTIME1.Value, "dd/MM/yyyy") & "' AND Inv_Codigo = '" & Me.TxtCodigo.Text & "' AND Inv_Cantidad = '" & Me.TxtCantidad.Text & "' ", SqlCnn)

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



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With Buscador
            .Show(Me)
            Buscador.lbform.Text = 3
        End With
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub

    Private Sub DGINV_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGINV.CellClick
        If e.RowIndex > -1 Then
            Dim code As String
            Dim desc As String
            Dim prev As String
            'Dim um As String

            Dim value As Object = DGINV.Rows(e.RowIndex).Cells(0).Value()
            Dim value1 As Object = DGINV.Rows(e.RowIndex).Cells(1).Value
            Dim value2 As Object = DGINV.Rows(e.RowIndex).Cells(2).Value
            Dim value3 As Object = DGINV.Rows(e.RowIndex).Cells(5).Value
            Dim value4 As Object = DGINV.Rows(e.RowIndex).Cells(7).Value

            If value.GetType Is GetType(DBNull) Then Return

            code = CType(value, String)
            desc = CType(value1, String)
            prev = CType(value2, String)
            'um = CType(value3, String)
            Me.Txtubi.Text = CType(value3, String)
            Me.TxtCodigo.Text = code
            Me.LblDescripcion.Text = desc
            'Me.Txtprev.Text = prev
            Me.TxtCantidad.Text = 0
            Me.CBUBI.Text = value3
            Me.DTIME1.Text = value4
            'Me.LBUM.Text = um
            Me.LblCanAlm.Text = prev
            exis = True
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        With Me
            .TxtCantidad.Text = ""
            .TxtCodigo.Text = ""
            .Txtcosto.Text = ""
            .Txtprev.Text = ""
            .Txtubi.Text = ""
            .LblDescripcion.Text = ""
            .LblCanAlm.Text = "0"
            .LBUM.Text = ""
            .LblUbiAct.Text = ""
            .TxtCodigo.Focus()
            .CBUBI.Items.Clear()
        End With
        exis = False
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim SqlSel As New SqlDataAdapter("SELECT a.Inva_Codigo, b.Descripcion, a.Inva_Cantidad, a.Inva_Empleado, a.Inva_Familia, a.Inva_Ubicacion, a.Inva_precio, a.Inva_Fecha  FROM  dbo.INVENTARIOSA AS a LEFT OUTER JOIN dbo.PRODUCTOS AS b ON a.Inva_Codigo = b.[Codigo de producto] WHERE a.Inva_Codigo like '%" & Me.TBoxBuscaUBI.Text.Trim & "%' and Inva_Almi = '" & Me.CBALMI.Text & "' ", SqlCnn)

        Dim DS1 As New DataTable
        Try
            SqlSel.Fill(DS1)
            With Me.DGINV
                .DataSource = DS1
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class