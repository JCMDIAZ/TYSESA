
Imports System.Data.SqlClient
Imports System.Data

Public Class FrmEntradaCompra
    Private Sub FrmEntradaCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Traealmacen()
        Me.Cbalm.SelectedIndex = 0
    End Sub
    Public Sub TraeDatosClientes()
        Dim SqlClientes As New SqlCommand("SELECT NOMBRE FROM EMPLEADOS ORDER BY NOMBRE", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.CboProveedor.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
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
    Public Sub TraeDatosProveedor()
        Dim SqlProveedores As New SqlCommand("SELECT Abreviatura FROM Proveedores ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Proveedores As New String(Nothing)
        Try
            SqlRead = SqlProveedores.ExecuteReader
            While SqlRead.Read
                Me.CboProveedor.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()

        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub CboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProveedor.SelectedIndexChanged
        'Generalote()
        Me.CboCliente.Focus()
    End Sub

    Private Sub TxtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFOL.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtFOL.Text = Nothing Then
                MsgBox("Error, favor de capturar lote")
                Me.TxtFOL.Focus()
            Else
                'genlote()
                Me.TxtCodigo.Focus()
            End If
        End If
    End Sub

    Private Sub TxtPEDIMENTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFAC.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtFAC.Text = Nothing Then
                MsgBox("Error, favor de capturar pedido")
                Me.TxtFAC.Focus()
            Else
                Me.TxtCodigo.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TxtCosto.Text = "0.00"
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

                If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                    MsgBox("ERROR, Producto NO habilitado o no existe")
                    Me.TxtCodigo.Focus()
                    Me.TxtCodigo.SelectAll()
                Else
                    If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
                        codefolio()
                    Else
                        Me.LblDescripcion.Text = TraeDescripcion(Me.TxtCodigo.Text)
                        Me.TxtCodigo.Text = Traecodigo(Me.TxtCodigo.Text)
                        Traeprecio()
                        If Me.TxtCosto.Text = "0.00" Then
                            MsgBox("No existen lotes anteriores de este producto favor de revisar el costo")
                            Traeprecio1()
                        End If
                    End If
                    If Me.TxtCosto.Text = Nothing Or Me.TxtCosto.Text = "." Then
                        'MsgBox("No tiene existencia el producto. VUELVA A CAPTURARLO")
                        'Me.TxtCodigo.Text = Nothing
                        'Me.LblDescripcion.Text = Nothing
                        Me.TxtCosto.Text = "0.00"
                        'Me.TxtCodigo.Focus()
                    End If

                    If Me.ChkCANT.Checked = True Then
                        Me.TxtCantidad.Focus()
                    Else
                        Me.TxtCantidad.Text = "1.00"
                        FuncionesTempEntCompra("1", Me.TxtFOL.Text, Me.TxtCodigo.Text, Me.TxtCantidad.Text, Me.TxtCosto.Text)
                        If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
                            restafol()
                            codefolio()
                        End If
                        detalle()
                        traesuma()
                        With Me
                            If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
                                dfolio()
                            End If
                            .TxtCodigo.Text = Nothing
                            .TxtCosto.Text = Nothing
                            .TxtCantidad.Text = Nothing
                            .LblDescripcion.Text = "."
                            .TxtCodigo.Focus()
                        End With

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCantidad.Text = Nothing Then
                MsgBox("Error, favor de capturar la cantidad")
                Me.TxtCantidad.Focus()
            Else
                If Me.TxtCodigo.Text = Nothing Or Me.TxtCantidad.Text = Nothing Or Me.TxtCosto.Text = Nothing Or Me.LblDescripcion.Text = "." Then
                    MsgBox("Error, favor de capturar todos los datos")
                Else
                    FuncionesTempEntCompra("1", Me.TxtFOL.Text, Me.TxtCodigo.Text, Me.TxtCantidad.Text, Me.TxtCosto.Text)
                    If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
                        restafol()
                        codefolio()
                    End If

                    detalle()
                    traesuma()
                    With Me
                        If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
                            dfolio()
                        End If
                        .TxtCodigo.Text = Nothing
                        .TxtCosto.Text = Nothing
                        .TxtCantidad.Text = Nothing
                        .LblDescripcion.Text = "."
                        .TxtCodigo.Focus()
                    End With
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
                If Me.TxtCodigo.Text = Nothing Or Me.TxtCantidad.Text = Nothing Or Me.TxtCosto.Text = Nothing Or Me.LblDescripcion.Text = "." Then
                    MsgBox("Error, favor de capturar todos los datos")
                Else
                    FuncionesTempEntCompra("1", Me.TxtFOL.Text, Me.TxtCodigo.Text, Me.TxtCantidad.Text, Me.TxtCosto.Text)
                    If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
                        restafol()
                        codefolio()
                    End If
                    detalle()
                    traesuma()
                    With Me
                        If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
                            dfolio()
                        End If
                        .TxtCodigo.Text = Nothing
                        .TxtCosto.Text = Nothing
                        .TxtCantidad.Text = Nothing
                        .LblDescripcion.Text = "."
                        .TxtCodigo.Focus()
                    End With
                End If
            End If
        End If
    End Sub
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.TxtFOL.Text = Nothing Or Me.CboProveedor.Text = Nothing Or Me.CboCliente.Text = Nothing Then
            MsgBox("Error, favor de capturar los datos necesarios")
        Else
            If ValidaDetent2(Me.TxtFOL.Text) = Nothing Then
                MsgBox("Error, no hay datos para guardar")
            Else
                Dim F1 As String
                Dim fn As String

                If ChkFAC.Checked = True Then
                    fn = "FAC"
                Else
                    fn = "NOT"
                End If

                If GuardaEntCompra2(Me.TxtFOL.Text, Me.Cbalm.Text, F1, Me.TxtEmpleado.Text, fn, fn, Me.CboCliente.Text, Me.TxtFAC.Text, Me.CboProveedor.Text) = 0 Then
                    MsgBox("Registro Guardado")
                    Me.Close()
                Else
                    MsgBox("La operacion presento errores")
                End If

            End If
            End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim resp
        resp = MsgBox("Esta accion eliminara los datos no almacenados, ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            borrafolio(Me.TxtFOL.Text)
            borranocapt()
            borranocapt2()
            Me.Close()
        End If
    End Sub

    Public Sub CargaGrid2()

        Dim DS As New DataTable

        Try

            Dim F1 As String
            F1 = Me.TxtFolio.Text
            Dim SqlSel1 As New SqlDataAdapter("SELECT Codigo, Descripcion, Cantidad, Costo FROM TEntCompra WHERE Folio = '" & F1 & "'", SqlCnn)
            SqlSel1.Fill(DS)
            Me.DGped.DataSource = DS

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub genlote()
        Dim prove As String
        Dim fecha As String
        Dim contador As String
        Dim user As String

        prove = Me.CboProveedor.Text
        fecha = Date.Today
        contador = Generalote()
        'user = Me.Stb.Text
        user = Me.TxtEmpleado.Text

        Dim SqlSelDes As New SqlCommand("SELECT clave FROM proveedores WHERE Abreviatura = '" & prove & "'", SqlCnn)
        Dim SqlSelDes2 As New SqlCommand("BEGIN " & _
                                "DECLARE @prov nchar(20) " & _
                                "DECLARE @VAR nchar(20) " & _
                                "SET @prov = (SELECT clave FROM proveedores WHERE '" & prove & "' = Abreviatura) " & _
                                "SET @VAR = (SELECT usuario FROM usuarios WHERE '" & user & "' = Nombre) " & _
                                "INSERT INTO LOTES (Numlote, prove, fecha, usuario) " & _
                                "VALUES ('" & contador & "', @prov ,'" & fecha & "',@VAR) " & _
                                "END ", SqlCnn)
        Dim SqlRead As SqlDataReader
        'Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDes2.ExecuteReader
            While SqlRead.Read
                prove = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Me.TxtFAC.Text = contador
    End Sub

    Public Function Generalote() As Integer
        Dim SqlFolio As New SqlCommand("SELECT MAX(Numlote) FROM LOTES", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim lotes As Integer

        Try

            SqlRead = SqlFolio.ExecuteReader
            While SqlRead.Read
                lotes = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return lotes + 1
        Me.TxtFAC.Text = lotes
    End Function

    Public Sub Traeprecio()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim Sqlprecio As New SqlCommand("DECLARE @loteva nchar(12) " & _
        "SET @loteva = (SELECT max(Numlote2) FROM LOTEEX2 WHERE [Codigo de Producto] = '" & codigo & "' AND ALMACEN = '" & Me.Cbalm.Text & "') " & _
        "SELECT costo2 FROM LOTEEX2 WHERE [Codigo de Producto] = '" & codigo & "' AND ALMACEN = '" & Me.Cbalm.Text & "' AND Numlote2 = @loteva ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    Me.TxtCosto.Text = "0.00"
                Else
                    Me.TxtCosto.Text = SqlRead.GetDecimal(0)
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

    Private Sub borranocapt()

        Dim folio = Me.TxtFOL.Text
        Dim Sqlborra As New SqlCommand("IF EXISTS (SELECT * FROM TEntAlm WHERE Folio = '" & folio & "') " & _
        "BEGIN " & _
        "DELETE FROM TEntAlm WHERE Folio = '" & folio & "' " & _
        "End", SqlCnn)
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

    End Sub
    Private Sub borranocapt2()

        Dim folio = Me.TxtFolio.Text
        Dim Sqlborra As New SqlCommand("IF EXISTS (SELECT * FROM TTraspaso WHERE ID_TRAS = '" & folio & "') " & _
        "BEGIN " & _
        "DELETE FROM TTraspaso WHERE ID_TRAS = '" & folio & "' " & _
        "End", SqlCnn)
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

    End Sub
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
    Public Sub FuncionesTempEntCompra(ByVal opcion As String, ByVal folio As String, ByVal codigo As String, ByVal cantidad As String, ByVal costo As String)
        Dim SqlTempEntAlm As New SqlCommand

        CmdStr1 = "exec spTempEntAlm "
        CmdStr1 = CmdStr1 & "'" & opcion & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.Cbalm.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & folio & "'" & ","
        CmdStr1 = CmdStr1 & "'" & codigo & "'" & ","
        CmdStr1 = CmdStr1 & "'" & cantidad & "'" & ","
        CmdStr1 = CmdStr1 & "'" & costo & "'"

        Try
            With SqlTempEntAlm
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            SqlTempEntAlm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Function borrafolio(ByVal folio) As Integer
        Dim SqlFolio As New SqlCommand("IF EXISTS (SELECT * FROM FOLIOS2 WHERE Consecutivo = '" & folio & "' AND utilizado = 'SI') " & _
        "BEGIN " & _
        "DELETE FROM FOLIOS2 WHERE Consecutivo = '" & folio & "' " & _
        "End", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlFolio.ExecuteReader
            While SqlRead.Read
                folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        If Me.CboProveedor.Text = Nothing Or Me.TxtFOL.Text = Nothing Or Me.CboCliente.Text = Nothing Then
            MsgBox("Error, favor de capturar los campos necesarios: Proveedor, Factura y OC")
        Else
            If ValidaDetEnt(Me.TxtFolio.Text) = 0 Then
                MsgBox("Error, no hay datos para guardar")
            Else
                Dim F1 As String
                Dim Nac As String
                Dim user As String
                genlote()
                If Me.ChkFAC.Checked = True Then
                    Nac = "fac"
                Else
                    Nac = "not"
                End If
                user = "General"

                'If GuardaEntCompra(Me.TxtFolio.Text, F1, Me.Stb.Text, Nac, Me.TxtPedimento.Text, Me.CboCliente.Text, Me.TxtFactura.Text, Me.CboProveedor.Text) = 0 Then
                If GuardaEntCompra1(Me.TxtFolio.Text, F1, user, Nac, Me.TxtFAC.Text, Me.CboCliente.Text, Me.TxtFOL.Text, Me.CboProveedor.Text) = 0 Then
                    MsgBox("Registro Guardado")
                    With Me
                        .TxtFolio.Text = GeneraNuevoFolio()
                        .TxtFOL.Text = Nothing
                        .CboProveedor.Text = Nothing
                        .CboCliente.Text = Nothing
                        .TxtFAC.Text = Nothing
                        .ChkFAC.Checked = False
                        .lbltotal.Text = "."
                        CargaGrid2()

                    End With
                Else
                    MsgBox("La transaccion presento problemas")
                End If
            End If
        End If
    End Sub
    Private Function ValidaDetEnt(ByVal folio As String) As Integer
        Dim SqlSelCuantos As New SqlCommand("SELECT COUNT(*) FROM TEntCompra WHERE Folio = '" & folio & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Cuantos As New String(Nothing)

        Try
            SqlRead = SqlSelCuantos.ExecuteReader
            While SqlRead.Read
                Cuantos = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Cuantos

    End Function
    Private Function GuardaEntCompra1(ByVal Folio, ByVal fecha, ByVal empleado, ByVal FACNOT, ByVal LOTE, ByVal CLIENTE, ByVal factura, ByVal proveedor) As Integer

        Dim SqlInsEntCompra As New SqlCommand


        CmdStr1 = "exec spInsEntMov2 "
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.Cbalm.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & empleado & "'" & ","
        CmdStr1 = CmdStr1 & "'" & FACNOT & "'" & ","
        CmdStr1 = CmdStr1 & "'" & LOTE & "'" & ","
        CmdStr1 = CmdStr1 & "'" & CLIENTE & "'" & ","
        CmdStr1 = CmdStr1 & "'" & factura & "'" & ","
        CmdStr1 = CmdStr1 & "'" & proveedor & "'"

        With SqlInsEntCompra
            .Connection = SqlCnn
            .CommandText = CmdStr1
        End With

        Try
            SqlInsEntCompra.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Error1 = 0

    End Function
   
    Private Sub CBENT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBENT.SelectedIndexChanged
        If Me.CBENT.Text = "ENTRADA POR TRANSPASO" Then
            Me.CboCliente.Text = Me.Cbalm.Text
            Me.CboProveedor.Text = "ALM GRAL"
            With Me
                .TxtFolio.Enabled = True
                .TxtFAC.Enabled = False
                .TxtCosto.Enabled = False
                .TxtEmpleado.Enabled = False
                .CBENT.Enabled = False
                .TxtFolio.Focus()
            End With
        End If
        If Me.CBENT.Text = "ENTRADA POR COMPRA" Then
            TraeDatosProveedor()
            TraeDatosClientes()
            Me.CboCliente.SelectedIndex = 0
            With Me
                .TxtFolio.Enabled = False
                .TxtFAC.Enabled = True
                .CboProveedor.Enabled = True
                .CboCliente.Enabled = True
                .ChkFAC.Enabled = True
                .CBENT.Enabled = False
                .CboProveedor.Focus()
            End With
        End If
        If Me.CBENT.Text = "ENTRADA POR DEVOLUCION" Then
            With Me
                .TxtFolio.Enabled = False
                .TxtFAC.Enabled = False
                .TxtCosto.Enabled = False
                .TxtEmpleado.Enabled = False
                .ChkCANT.Enabled = True
                .TxtCodigo.Enabled = True
                .TxtCodigo.Focus()
            End With
            TraeDatosProveedor()
            TraeDatosClientes()
        End If
    End Sub
    Private Sub Txtfolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtFolio.Text = Nothing Then
                MsgBox("Error, favor de folio nuevamente")
                Me.TxtFolio.Focus()
            Else
                buscafolio()
                If Me.CboCliente.Text = "." Or Me.CboCliente.Text = Nothing Then
                    MsgBox("No existe folio favor de volver a capturarlo")
                    Me.TxtFolio.Text = Nothing
                    Me.TxtFolio.Focus()
                Else
                    copiarfolio()
                    dfolio()
                    'Me.CboCliente.Text = Me.Cbalm.Text
                    Me.TxtFAC.Text = Me.TxtFolio.Text
                    Me.ChkCANT.Enabled = True
                    Me.ChkCANT.Checked = True
                    Me.TxtCosto.Enabled = True
                    Me.TxtCodigo.Enabled = True
                    Me.TxtCantidad.Enabled = True
                    Me.TxtCodigo.Focus()
                   
                End If
            End If
        End If
    End Sub
    Private Sub TxtFAC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFAC.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtFAC.Text = Nothing Then
                MsgBox("Error, favor capturar factura o folio nuevamente")
                Me.TxtFAC.Focus()
            Else
                Me.TxtCosto.Enabled = True
                Me.TxtCodigo.Enabled = True
                Me.ChkCANT.Enabled = True
                Me.ChkCANT.Checked = True
                Me.Button1.Enabled = True
                Me.TxtCodigo.Focus()
            End If
        End If

    End Sub
    Public Sub buscafolio()

        Dim Sqlfolio As New SqlCommand("SELECT a.ALMENT_TRAS, b.abreviatura FROM TRASPASO a, almacenes b WHERE a.ALMSAL_TRAS = b.Clave AND ID_TRAS = '" & Me.TxtFolio.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlfolio.ExecuteReader
            While SqlRead.Read
                Me.CboCliente.Text = SqlRead.GetString(0)
                Me.CboProveedor.Text = SqlRead.GetString(1)
                'Me.CboCliente.Text = Me.Cbalm.Text
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub copiarfolio()

        Dim Sqlcopi As New SqlCommand("exec spTemfol '" & Me.TxtFOL.Text & "', '" & Me.TxtFolio.Text & "'", SqlCnn)
        Try
            Sqlcopi.ExecuteNonQuery()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub dfolio()

        Dim DSped As New DataTable
        Try
            Dim SqlSel1 As New SqlDataAdapter("SELECT a.[Codigo de producto], b.[Descripcion], a.CANT_TRAS, a.COSTO_TRAS FROM TTraspaso a, productos b WHERE a.[Codigo de producto] = b.[Codigo de producto] AND a.ID_TRAS = '" & Me.TxtFolio.Text & "' AND a.CANT_TRAS != 0", SqlCnn)
            SqlSel1.Fill(DSped)
            Me.DGped.DataSource = DSped

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub detalle()

        Dim DSped As New DataTable
        Try
            Dim SqlSel1 As New SqlDataAdapter("SELECT a.[Codigo de producto], b.[Descripcion], a.CANT_ALM, a.COSTO_ALM FROM TEntALM a, productos b WHERE a.[Codigo de producto] = b.[Codigo de producto] AND a.Folio = '" & Me.TxtFOL.Text & "' ", SqlCnn)
            SqlSel1.Fill(DSped)
            Me.DataGridView1.DataSource = DSped

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub codefolio()

        Dim Sqlcfolio As New SqlCommand("SELECT CANT_TRAS, COSTO_TRAS FROM TTraspaso WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND ID_TRAS = '" & Me.TxtFolio.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlcfolio.ExecuteReader
            While SqlRead.Read
                'Me.LBTOTAL.Text = SqlRead.GetDecimal(0)
                Me.TxtCosto.Text = SqlRead.GetDecimal(1)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Function restafol()

        Dim Sqltempsal As New SqlCommand("DECLARE @Folio nchar(10) " & _
        "DECLARE @Codigo nchar(20) " & _
        "DECLARE @Cantidad decimal(12,2) " & _
        "DECLARE @Costo decimal(12,2) " & _
        "DECLARE @iva decimal(20,2) " & _
        "SET @Folio = '" & Me.TxtFolio.Text & "' " & _
        "SET @Codigo = '" & Me.TxtCodigo.Text & "' " & _
        "SET @Costo = " & Me.TxtCosto.Text & " " & _
        "SET @Cantidad = " & Me.TxtCantidad.Text & " " & _
        "SET @iva = (SELECT IVA FROM productos WHERE [Codigo de producto] = @Codigo) " & _
        "IF EXISTS (SELECT * FROM TTRASPASO WHERE ID_TRAS = @Folio AND [Codigo de producto] = @Codigo) " & _
        "BEGIN " & _
        "UPDATE TTRASPASO SET CANT_TRAS = CANT_TRAS - @Cantidad WHERE ID_TRAS = @Folio AND [Codigo de producto] = @Codigo " & _
        "UPDATE TTRASPASO SET TOT_TRAS = @Costo * CANT_TRAS WHERE ID_TRAS = @Folio AND [Codigo de producto] = @Codigo " & _
        "UPDATE TTRASPASO SET COSTO_TRAS = @Costo WHERE ID_TRAS = @Folio AND [Codigo de producto] = @Codigo " & _
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

    Private Sub ChkCANT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCANT.CheckedChanged
        If Me.ChkCANT.Checked = True Then
            Me.TxtCantidad.Enabled = True
            Me.TxtCodigo.Focus()
        Else
            Me.TxtCantidad.Enabled = False
            Me.TxtCodigo.Focus()
        End If
    End Sub


    Private Sub Cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbalm.SelectedIndexChanged
        If GroupBox1.Enabled = False Then
            GroupBox1.Enabled = True
            GroupBox3.Enabled = True
            TraeDatosClientes()
        End If
    End Sub

    Private Sub ChkFAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFAC.CheckedChanged
        If Me.ChkFAC.Checked = True Then
            'Me.fac.Visible = True
            'Me.NOTA.Visible = False
            Me.TxtFAC.Focus()
        Else
            'Me.fac.Visible = False
            'Me.NOTA.Visible = True
            Me.TxtFAC.Focus()
        End If
    End Sub
    Private Sub traesuma()
        Dim folio As String
        folio = Me.TxtFOL.Text
        Dim Sqlsuma As New SqlCommand("SELECT Folio, SUM(Total) FROM TEntAlm WHERE Folio = '" & folio & "' Group by folio ORDER BY folio", SqlCnn)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        With Buscador
            .Show(Me)
            Buscador.lbform.Text = 0
        End With
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        If Me.TxtCodigo.Text = Nothing Then
            MsgBox("Favor de seleccionar el producto que desea borrar")
        Else
            Dim resp
            resp = MsgBox("Desea eliminar el codigo " & Me.TxtCodigo.Text & ", ¿Es correcto?", MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                borrar()
                detalle()
                traesuma()
                Me.TxtCodigo.Focus()

            End If
        End If
    End Sub
    Private Sub borrar()

        Dim SqlDelDetSalRes As New SqlCommand("DELETE FROM TEntAlm WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND Folio = '" & Me.TxtFOL.Text & "'", SqlCnn)
        Try
            SqlDelDetSalRes.ExecuteNonQuery()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim code As String
        Dim desc As String
        Dim prev As String
        'Dim um As String

        Dim value As Object = DataGridView1.Rows(e.RowIndex).Cells(0).Value()
        Dim value1 As Object = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        Dim value2 As Object = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        'Dim value3 As Object = Griinv.Rows(e.RowIndex).Cells(3).Value

        If value.GetType Is GetType(DBNull) Then Return

        code = CType(value, String)
        desc = CType(value1, String)
        prev = CType(value2, String)
        'um = CType(value3, String)

        Me.TxtCodigo.Text = code
        Me.LblDescripcion.Text = desc
        Me.TxtCantidad.Text = prev
        'Me.LBUM.Text = um
    End Sub


    Private Sub CboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCliente.SelectedIndexChanged
        Me.TxtFAC.Focus()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim resp
        resp = MsgBox("Esta accion eliminara los datos no almacenados, ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            borrafolio(Me.TxtFOL.Text)
            borranocapt()
            borranocapt2()
            Me.Close()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtCodigo.Text = Nothing Then
            MsgBox("Favor de seleccionar el producto que desea borrar")
        Else
            Dim resp
            resp = MsgBox("Desea eliminar el codigo " & Me.TxtCodigo.Text & ", ¿Es correcto?", MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                borrar()
                detalle()
                traesuma()
                Me.TxtCodigo.Focus()

            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtFOL.Text = Nothing Or Me.CboProveedor.Text = Nothing Or Me.CboCliente.Text = Nothing Then
            MsgBox("Error, favor de capturar los datos necesarios")
        Else
            If ValidaDetent2(Me.TxtFOL.Text) = Nothing Then
                MsgBox("Error, no hay datos para guardar")
            Else
                Dim F1 As String
                Dim fn As String

                If ChkFAC.Checked = True Then
                    fn = "FAC"
                Else
                    fn = "NOT"
                End If

                If GuardaEntCompra2(Me.TxtFOL.Text, Me.Cbalm.Text, F1, Me.TxtEmpleado.Text, fn, fn, Me.CboCliente.Text, Me.TxtFAC.Text, Me.CboProveedor.Text) = 0 Then
                    MsgBox("Registro Guardado")
                    With Me
                        '.TxtFOL.Text = GeneraNuevoFolio()
                        '.TxtCodigo.Text = Nothing
                        '.TxtCantidad.Text = Nothing
                        '.LblDescripcion.Text = "."
                        '.LblExistencia.Text = "."
                        '.ComboBox1.Text = Nothing
                        '.lbltotal.Text = "."
                        '.TxtCosto.Text = Nothing
                        'detalle()
                    End With
                    Me.Close()
                Else
                    MsgBox("La operacion presento errores")
                End If

            End If
        End If
    End Sub

    Private Sub TxtFAC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFAC.TextChanged

    End Sub
   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class