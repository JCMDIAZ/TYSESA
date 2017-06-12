Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class frmmov2
    Dim tipomovx As String
    Private m_ChildFormNumber As Integer = 0
    Private Sub frmmov2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CBCLIENTE.Enabled = False
        Me.CBUSU.Enabled = False
        Me.CBFAM.Enabled = False
        Me.CBPROVE.Enabled = False
        Me.TxtCodigo.Enabled = False
        Me.TXTFAC.Enabled = False
        Me.CBFAC.Enabled = False
        Me.CHNUMERO.Enabled = False

        With CBFAC
            .Items.Add("NOT")
            .Items.Add("FAC")
        End With
        With CBMOVI
            .Items.Add("ENTRADA POR COMPRA")
            '.Items.Add("SALIDAS POR RECARGA A RUTA")
            .Items.Add("SALIDAS A RUTA")
            .Items.Add("ENTRADA POR DEVOLUCION DE RUTA")
            '.Items.Add("ENTRADA POR DEVOLUCION PROVEEDOR")
            .Items.Add("SALIDAS POR MERMA")
            '.Items.Add("
            .SelectedIndex = 0
        End With
        TraeCLIENTE()
        Traealmacen()
        Me.Cbalm.SelectedIndex = 0
        CargaUsuario()
        Cargafam()
        CargaPROVE()
        Cargacliente()

    End Sub

    Sub DesabilitaChe()
        For Each c As Control In Me.GroupBox1.Controls

            If TypeOf c Is CheckBox Then

                Dim Chboxtem As CheckBox = CType(c, CheckBox)
                'If Chboxtem.Name = chbox.Name Then

                'Else
                Chboxtem.Checked = False
                'End If

            Else

            End If

        Next
    End Sub
    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        Dim FECDE As Date
        Dim FECA As Date
        Dim FEC1 As String
        Dim FEC2 As String
        FEC1 = Me.DTFECHADE.Text
        FEC2 = Me.DTFECHAA.Text

        Dim erro As Integer
        Dim fam1 As String
        Dim fam2 As String
        Dim Sqlbusmov As New SqlCommand

        If Me.ChBoxUbi.Checked = True Then
            If Me.CBUBI.Text <> "" Then
                Dim CmdStr1 As New String("SELECT a.Inva_Codigo, b.Descripcion, a.Inva_Cantidad, a.Inva_Empleado, a.Inva_Familia, a.Inva_Ubicacion, a.Inva_precio, a.Inva_Fecha  " & _
                                               "FROM  dbo.INVENTARIOSA AS a LEFT OUTER JOIN dbo.PRODUCTOS AS b ON a.Inva_Codigo = b.[Codigo de producto]  " & _
                                               "WHERE  (convert(varchar(10),a.Inva_Fecha,103) between '" & Format(Me.DTFECHADE.Value, "dd/MM/yyyy") & "'  and '" & Format(Me.DTFECHAA.Value, "dd/MM/yyyy") & "') and Inva_Almi = '" & Me.Cbalm.Text & "'  " & _
                                               "and a.Inva_Ubicacion = '" & Me.CBUBI.Text & "' ORDER BY a.Inva_Codigo ")

                FECDE = Me.DTFECHADE.Text
                FECA = Me.DTFECHAA.Text
                erro = 0
                If FECDE > FECA Then
                    MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
                    Me.DTFECHADE.Focus()
                    Exit Sub
                Else
                    Cargadatagridusu(CmdStr1)
                    Dim dt As DataTable = Me.gridmovi.DataSource

                    If dt.Rows.Count > 0 Then
                        Me.Lbtotal.Text = dt.Rows.Count
                    End If
                    Exit Sub
                End If
            Else
                MsgBox("Selecciona una ubicacion")
                Me.CBUBI.Focus()
                Exit Sub
            End If
        End If
        tipomovx = Me.CBMOVI.Text


  
        Dim CmdStr As New String("SELECT a.[Codigo de producto] as CODIGO, b.descripcion as DESCRIPCION, " & _
                                "a.TIPO_MOV2 as SAL_ENT, a.CANT_MOV2 as CANT, a.COSTO_MOV2 AS COSTO, c.abreviatura as UM, d.abreviatura as FAM, a.FACNOT_MOV2 as FAC_NOTA, " & _
                                "a.PROV_MOV2 as PROVEEDOR, a.CLIEN_MOV2 as CLIENTE, a.FECHA_MOV2 as FECHA, a.USU_MOV2, a.TOT_MOV2 " & _
                                "FROM movimientos2 a, productos b, unidaddemedida c, familias d " & _
                                "WHERE a.[Codigo de producto] = b.[Codigo de producto] AND b.[Unidad de medida] = c.clave AND b.familia = d.clave AND FECHA_MOV2 BETWEEN '" & Trim(FEC1) & " 00:00:00.000' AND '" & Trim(FEC2) & " 23:59:59.999' ")

        FECDE = Me.DTFECHADE.Text
        FECA = Me.DTFECHAA.Text
        erro = 0
        If FECDE > FECA Then
            MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
        Else
            If Me.Cbalm.Text = Nothing Then
                MsgBox("Error, requiere seleccionar almacen")
                erro = 1
                Me.Cbalm.Focus()
            End If
            If tipomovx = "ENTRADA POR COMPRA" Then
                tipomovx = "ENT"
            Else
                If tipomovx = "SALIDA" Then
                    tipomovx = "SAL"
                Else
                    If tipomovx = "ENTRADA POR DEVOLUCION DE RUTA" Then
                        tipomovx = "EDV"
                    Else
                        If tipomovx = "ENTRADA POR DEVOLUCION PROVEEDOR" Then
                            tipomovx = "EDB"
                        Else
                            If tipomovx = "ENTRADA DEVOLUCION HERRAMIENTA" Then
                                tipomovx = "EDH"
                            Else
                                If tipomovx = "PRESTAMO" Then
                                    tipomovx = "SPR"
                                Else
                                    If tipomovx = "SALIDA DEVOLUCION" Then
                                        tipomovx = "SDV"
                                    Else
                                        If tipomovx = "SALIDAS A RUTA" Then
                                            tipomovx = "STR"
                                        Else
                                            If tipomovx = "REPARACION" Then
                                                tipomovx = "SRP"
                                            Else
                                                If tipomovx = "SALIDAS POR MERMA" Then
                                                    tipomovx = "SMR"
                                                    FEC1 = Mid(Me.DTFECHADE.Text, 7, 4) & "." & Mid(Me.DTFECHADE.Text, 4, 2) & "." & Mid(Me.DTFECHADE.Text, 1, 2)
                                                    FEC2 = Mid(Me.DTFECHAA.Text, 7, 4) & "." & Mid(Me.DTFECHAA.Text, 4, 2) & "." & Mid(Me.DTFECHAA.Text, 1, 2)
                                                    'CmdStr = "SELECT Movimientos2.TIPO_MOV2 ,Movimientos2.ID_MOV2, Movimientos2.USU_MOV2, Movimientos2.CANT_MOV2, Movimientos2.COSTO_MOV2, Movimientos2.FACNOT_MOV2, Movimientos2.PROV_MOV2, " & _
                                                    ' " CONVERT(VARCHAR(10),Movimientos2.FECHA_MOV2,105) AS Fecha, Movimientos2.TOT_MOV2, productos.[Nombre corto], productos.alterno, unidaddemedida.abreviatura , productos.IVA, productos.IEPS, productos.IIVA, " & _
                                                    ' " productos.IIEPS FROM   (SNROQUE.dbo.MOVIMIENTOS2 Movimientos2 INNER JOIN SNROQUE.dbo.PRODUCTOS productos ON Movimientos2.[Codigo de producto] = productos.[Codigo de producto]) " & _
                                                    ' " INNER JOIN SNROQUE.dbo.UNIDADDEMEDIDA unidaddemedida ON productos.[Unidad de medida] = unidaddemedida.clave  " & _
                                                    ' " WHERE  (CONVERT(VARCHAR(10),Movimientos2.FECHA_MOV2,102) BETWEEN '" & FEC1 & "' AND '" & FEC2 & "')  "
                                                    CmdStr = "SELECT a.TIPO_MOV2, a.ID_MOV2, a.USU_MOV2, a.CANT_MOV2, a.COSTO_MOV2, a.FACNOT_MOV2, a.PROV_MOV2, CONVERT(VARCHAR(10), a.FECHA_MOV2, 105) AS Fecha  " & _
                                                             "  , a.TOT_MOV2, b.[Nombre corto], b.alterno, c.abreviatura, b.IVA, b.IEPS, b.IIVA, b.IIEPS  " & _
                                                             " FROM dbo.MOVIMIENTOS2 AS a INNER JOIN dbo.PRODUCTOS AS b ON a.[Codigo de producto] = b.[Codigo de producto] INNER JOIN dbo.UNIDADDEMEDIDA AS c  " & _
                                                             " ON b.[Unidad de medida] = c.clave " & _
                                                             " WHERE  (CONVERT(VARCHAR(10),a.FECHA_MOV2,102) BETWEEN '" & FEC1 & "' AND '" & FEC2 & "')  "
                                                Else
                                                    MsgBox("Favor de seleccionar un tipo valido de movimiento")
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            'If Me.CBMOVI.Text = "ENTRADA" Then
            '    'MsgBox(" es entrada")
            '    CmdStr = CmdStr & "AND a.TIPO_MOV2 = 'ENT' "
            '    CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.Cbalm.Text & "' "
            'End If
            'If Me.CBMOVI.Text = "SALIDA" Then
            '    'MsgBox("es salida")
            '    CmdStr = CmdStr & "AND a.TIPO_MOV2 = 'SAL' "
            '    CmdStr = CmdStr & "AND a.PROV_MOV2 = '" & Me.Cbalm.Text & "' "
            'End If
            'If tipoMovX.Substring(0, 1) = "E" Then
            '    CmdStr = CmdStr & "AND SUBSTRING(a.TIPO_MOV2, 1, 1) = '" & tipomovx.Substring(0, 1) & "' "
            '    CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Cbalm.Text & "' "
            'End If
            'If tipoMovX.Substring(0, 1) = "S" Then
            '    CmdStr = CmdStr & "AND SUBSTRING(a.TIPO_MOV2, 1, 1)  = '" & tipomovx.Substring(0, 1) & "' "
            '    CmdStr = CmdStr & "AND a.PROV_MOV2 = '" & Cbalm.Text & "' "
            'End If

            If tipomovx = "SMR" Then
                'ORDER BY Movimientos2.FECHA_MOV2 DESC  
                CmdStr = CmdStr & "AND a.TIPO_MOV2 = '" & tipomovx & "' "
                CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Cbalm.Text & "' "
                'CmdStr = CmdStr & "AND Movimientos2.TIPO_MOV2 = '" & tipomovx & "' "
                'CmdStr = CmdStr & "AND Movimientos2.CLIEN_MOV2 = '" & Cbalm.Text & "' "
                'CmdStr = CmdStr & "ORDER BY Movimientos2.FECHA_MOV2 DESC "
            Else
                If tipomovx.Substring(0, 1) = "E" Then
                    CmdStr = CmdStr & "AND a.TIPO_MOV2 = '" & tipomovx & "' "
                    CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Cbalm.Text & "' "
                End If
                If tipomovx.Substring(0, 1) = "S" Then
                    CmdStr = CmdStr & "AND a.TIPO_MOV2  = '" & tipomovx & "' "
                    CmdStr = CmdStr & "AND a.PROV_MOV2 = '" & Cbalm.Text & "' "
                End If
            End If

            If Me.CHCLIENTE.Checked = True Then
                'If Me.CBRUTAS.Text = Nothing Then
                If Me.ComboBox2.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Salida")
                    erro = 1
                    'Me.CBRUTAS.Focus()
                    Me.ComboBox2.Focus()
                Else

                    If Me.CBMOVI.Text = "ENTRADA POR COMPRA" Then
                        CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.Cbalm.Text & "' "
                    End If
                    If Me.CBMOVI.Text = "SALIDAS POR RECARGA A RUTA" Then
                        CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.CBCLIENTE.Text & "' "
                    End If
                End If
            End If

            If Me.CHPROV.Checked = True Then
                If Me.CBPROVE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Proveedor")
                    erro = 1
                    Me.CBPROVE.Focus()
                Else
                    'MsgBox("agrega proveedor")
                    CmdStr = CmdStr & "AND a.PROV_MOV2 = '" & Me.CBPROVE.Text & "' "
                End If
            End If

            If Me.CHUSU.Checked = True Then
                If Me.CBUSU.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar usuario")
                    erro = 1
                    Me.CBUSU.Focus()
                Else
                    'MsgBox("agrega usuario")
                    CmdStr = CmdStr & "AND a.USU_MOV2 = '" & Me.CBUSU.Text & "' "
                End If

            End If

            If Me.CHFAM.Checked = True Then
                If Me.CBFAM.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar familia")
                    erro = 1
                    Me.CBFAM.Focus()
                Else
                    fam1 = Me.CBFAM.Text
                    fam2 = Traefam(fam1)

                    'MsgBox("agrega familia")
                    CmdStr = CmdStr & "AND  b.familia = '" & fam2 & "' "
                    'MsgBox("falta filtro familia")
                End If

            End If

            If Me.CHCODE.Checked = True Then
                If Me.TxtCodigo.Text = Nothing Then
                    MsgBox("Error, requiere ingresar codigo")
                    erro = 1
                    Me.TxtCodigo.Focus()
                Else
                    'MsgBox("agrega codigo")
                    CmdStr = CmdStr & "AND a.[Codigo de Producto] = '" & Me.TxtCodigo.Text & "' "
                End If

            End If

            If Me.CHFAC.Checked = True Then
                If Me.CHNUMERO.Checked = True Then
                    If Me.TXTFAC.Text = Nothing Then
                        MsgBox("Error, Requiere capturar Numero de factura o Nota")
                        erro = 1
                        Me.TXTFAC.Focus()
                    Else
                        'MsgBox("agrega numero factura")
                        CmdStr = CmdStr & "AND a.FACNOT_MOV2 = '" & Me.TXTFAC.Text & "' "
                    End If
                Else
                    If Me.CBFAC.Text = Nothing Then
                        MsgBox("Error, requiere seleccionar factura o nota")
                        erro = 1
                        Me.CBFAC.Focus()
                    Else
                        'MsgBox("agrega opcion de factura")
                        CmdStr = CmdStr & "AND FAC_MOV2 = '" & Me.CBFAC.Text & "' "
                    End If

                End If

            End If

            If Me.CheckBox1.Checked = True Then
                If Me.CBCLIENTE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar una ruta")
                    erro = 1
                    Me.CBCLIENTE.Focus()
                Else
                    If Me.CBMOVI.Text = "ENTRADA POR COMPRA" Then
                        CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.Cbalm.Text & "' "
                    End If
                    If Me.CBMOVI.Text = "SALIDAS POR RECARGA A RUTA" Then
                        CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.CBCLIENTE.Text & "' "
                    End If
                End If

            End If

            CmdStr = CmdStr & "ORDER BY a.FECHA_MOV2 DESC "
            If erro = 1 Then
                MsgBox("FALTAN DATOS")
            Else

                'MsgBox("Carga filtro")
                Cargadatagridusu(CmdStr)
                traesuma()
                Dim dt As DataTable = Me.gridmovi.DataSource

                If dt.Rows.Count > 0 Then
                    Me.Lbtotal.Text = dt.Rows.Count
                End If
            End If
        End If
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        If Me.Cbalm.Text = Nothing Then
            MsgBox("Error, requiere seleccionar almacen")
            Me.Cbalm.Focus()
        Else
            'With Reports7
            '    .Show(Me)
            'End With
            For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
                If MDIPrincipal.MdiChildren(i).Text = "Reporte Movimientos" Then

                    MDIPrincipal.MdiChildren(i).Close()
                    Exit For
                Else
                End If
            Next

            Dim chReportClRut As New Reports7
            chReportClRut.MdiParent = MDIPrincipal
            m_ChildFormNumber += 1
            chReportClRut.Show()
        End If
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub CargaUBI()
        Me.CBUBI.Items.Clear()
        Dim SqlSelEmp As New SqlCommand("SELECT a.ClaveS, a.NombreS, a.AbrS, a.ZonaS, a.AreaS, a.AlturaS, a.[offsetS], a.Almacen, b.Clave, b.Nombre, b.Abreviatura FROM dbo.SUBALMACENES AS a INNER JOIN dbo.ALMACENES AS b ON a.Almacen = b.Clave WHERE b.Abreviatura = '" & Me.Cbalm.Text.Trim & "' ORDER BY a.almacen", SqlCnn)
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

    Private Sub CargaPROVE()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From Proveedores ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBPROVE.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Cargafam()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From Familias ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBFAM.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Cargacliente()
        'Dim SqlSelEmp As New SqlCommand("SELECT a.Abreviatura FROM Clientes a, usuarios_almacen b, almacenes c, usuarios d WHERE c.abreviatura = b.almacen AND b.usuario = d.Usuario AND a.Almacen = c.clave AND d.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY Abreviatura", SqlCnn)
        Dim SqlSelEmp As New SqlCommand("SELECT  Razon FROM dbo.CLIENTES ORDER BY Razon", SqlCnn)
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
    Private Sub CHCLIENTE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHCLIENTE.CheckedChanged
        'Call Me.DesabilitaChe(CHCLIENTE)
        If Me.CHCLIENTE.Checked = True Then
            'Me.CBRUTAS.Enabled = True
            Me.ComboBox2.Enabled = True

            Me.CheckBox1.Checked = False
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHUSU.Checked = False
        Else


            'Me.CBRUTAS.Enabled = False
            'Me.CBRUTAS.Text = Nothing
            Me.ComboBox2.Enabled = False
            Me.ComboBox2.Text = ""
        End If

    End Sub

    Private Sub CHPROV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHPROV.CheckedChanged
        'Call Me.DesabilitaChe(CHPROV)
        If Me.CHPROV.Checked = True Then
            Me.CBPROVE.Enabled = True

            Me.CheckBox1.Checked = False
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHCLIENTE.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHUSU.Checked = False

        Else

            Me.CBPROVE.Enabled = False
            Me.CBPROVE.Text = Nothing
        End If
    End Sub

    Private Sub CHFAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHFAC.CheckedChanged
        'Call Me.DesabilitaChe(CHFAC)
        If Me.CHFAC.Checked = True Then
            Me.CBFAC.Enabled = True
            Me.CHNUMERO.Enabled = True

            Me.CheckBox1.Checked = False
            Me.CHCLIENTE.Checked = False
            Me.CHFAM.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHUSU.Checked = False
            Me.CHNUMERO.Enabled = False
        Else


            Me.TXTFAC.Enabled = False
            Me.TXTFAC.Text = Nothing
            Me.CBFAC.Enabled = False
            Me.CBFAC.Text = Nothing
        End If
    End Sub

    Private Sub CHUSU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHUSU.CheckedChanged
        'Call Me.DesabilitaChe(CHUSU)
        If Me.CHUSU.Checked = True Then
            Me.CBUSU.Enabled = True

            Me.CheckBox1.Checked = False
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHCLIENTE.Checked = False


        Else



            Me.CBUSU.Enabled = False
            Me.CBUSU.Text = Nothing
        End If
    End Sub

    Private Sub CHFAM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHFAM.CheckedChanged
        ' Call Me.DesabilitaChe(CHFAM)
        If Me.CHFAM.Checked = True Then
            Me.CBFAM.Enabled = True

            Me.CheckBox1.Checked = False
            Me.CHFAC.Checked = False
            Me.CHCLIENTE.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHUSU.Checked = False
        Else


            Me.CBFAM.Enabled = False
            Me.CBFAM.Text = Nothing
        End If
    End Sub

    Private Sub CHCODE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHCODE.CheckedChanged
        'Call Me.DesabilitaChe(CHCODE)
        If Me.CHCODE.Checked = True Then
            Me.TxtCodigo.Enabled = True
            Me.CheckBox1.Checked = False
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHCLIENTE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHUSU.Checked = False
        Else

            Me.TxtCodigo.Enabled = False
            Me.TxtCodigo.Text = Nothing
        End If
    End Sub

    Private Sub CHNUMERO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHNUMERO.CheckedChanged
        'Call Me.DesabilitaChe(CHNUMERO)
        If Me.CHNUMERO.Checked = True Then
            Me.TXTFAC.Enabled = True
            'Me.CBFAC.Enabled = False
            'Me.CBFAC.Text = Nothing

            'Me.CheckBox1.Checked = False
            'Me.CHFAC.Checked = False
            'Me.CHFAM.Checked = False
            'Me.CHCODE.Checked = False
            'Me.CHCLIENTE.Checked = False
            'Me.CHPROV.Checked = False
            'Me.ChBoxUbi.Checked = False
            'Me.CHUSU.Checked = False
        Else


            Me.TXTFAC.Enabled = False
            Me.TXTFAC.Text = Nothing
            'Me.CBFAC.Enabled = True
        End If
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo")
                Me.TxtCodigo.Focus()
            Else
                Me.LblDescripcion.Text = Nothing
                Traecodigo()
                Traedes()
                'Traeprecio()
                If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                    MsgBox("Error, codigo no valido")
                    Me.TxtCodigo.Focus()
                    Me.TxtCodigo.SelectAll()
                Else

                End If
            End If
        End If
    End Sub

    Public Sub Traecodigo()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim Sqlprecio As New SqlCommand("SELECT [Codigo de producto] FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & "", SqlCnn)
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
    Public Sub Traedes()
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
    Private Sub CargaUsuario()
        Dim SqlSelEmp As New SqlCommand("SELECT Nombre From Usuarios ORDER BY Nombre", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBUSU.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Traealmacen()
        Dim SqlClientes As New SqlCommand("SELECT Abreviatura From ALMACENES ORDER BY Abreviatura", SqlCnn)
        'Dim SqlClientes As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY a.almacen", SqlCnn)
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
    Public Sub TraeCLIENTE()
        Dim SqlClientes As New SqlCommand("SELECT NOMBRE FROM RUTAS ORDER BY NOMBRE", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.CBCLIENTE.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub traesuma()
        tipomovx = Me.CBMOVI.Text
        Dim FECDE As Date
        Dim FECA As Date
        Dim FEC1 As String
        Dim FEC2 As String
        FEC1 = Me.DTFECHADE.Text
        FEC2 = Me.DTFECHAA.Text

        Dim erro As Integer
        Dim fam1 As String
        Dim fam2 As String
        Dim Sqlbusmov As New SqlCommand
        Dim CmdStr As New String("SELECT SUM(a.TOT_MOV2) " & _
                                 "FROM movimientos2 a, productos b, unidaddemedida c, familias d " & _
                                "WHERE a.[Codigo de producto] = b.[Codigo de producto] AND b.[Unidad de medida] = c.clave AND b.familia = d.clave AND FECHA_MOV2 BETWEEN '" & FEC1 & " 00:00:00.000' AND '" & FEC2 & " 23:59:59.999' ")
        FECDE = Me.DTFECHADE.Text
        FECA = Me.DTFECHAA.Text
        erro = 0
        If FECDE > FECA Then
            MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
        Else
            If Me.Cbalm.Text = Nothing Then
                MsgBox("Error, requiere seleccionar almacen")
                erro = 1
                Me.Cbalm.Focus()
            End If
            If tipomovx = "ENTRADA POR COMPRA" Then
                tipomovx = "ENT"
            Else
                If tipomovx = "SALIDA" Then
                    tipomovx = "SAL"
                Else
                    If tipomovx = "ENTRADA POR DEVOLUCION DE RUTA" Then
                        tipomovx = "EDV"
                    Else
                        If tipomovx = "ENTRADA POR DEVOLUCION PROVEEDOR" Then
                            tipomovx = "EDB"
                        Else
                            If tipomovx = "ENTRADA DEVOLUCION HERRAMIENTA" Then
                                tipomovx = "EDH"
                            Else
                                If tipomovx = "PRESTAMO" Then
                                    tipomovx = "SPR"
                                Else
                                    If tipomovx = "SALIDA DEVOLUCION" Then
                                        tipomovx = "SDV"
                                    Else
                                        If tipomovx = "SALIDAS A RUTA" Then
                                            tipomovx = "STR"
                                        Else
                                            If tipomovx = "REPARACION" Then
                                                tipomovx = "SRP"
                                            Else
                                                If tipomovx = "SALIDAS POR MERMA" Then
                                                    tipomovx = "SMR"

                                                    FEC1 = Mid(Me.DTFECHADE.Text, 7, 4) & "." & Mid(Me.DTFECHADE.Text, 4, 2) & "." & Mid(Me.DTFECHADE.Text, 1, 2)
                                                    FEC2 = Mid(Me.DTFECHAA.Text, 7, 4) & "." & Mid(Me.DTFECHAA.Text, 4, 2) & "." & Mid(Me.DTFECHAA.Text, 1, 2)
                                                    'CmdStr = "SELECT SUM(MOVIMIENTOS2.CANT_MOV2) " & _
                                                    ' " FROM   (SNROQUE.dbo.MOVIMIENTOS2 Movimientos2 INNER JOIN SNROQUE.dbo.PRODUCTOS productos ON Movimientos2.[Codigo de producto] = productos.[Codigo de producto]) " & _
                                                    ' " INNER JOIN SNROQUE.dbo.UNIDADDEMEDIDA unidaddemedida ON productos.[Unidad de medida] = unidaddemedida.clave  " & _
                                                    ' " WHERE  (CONVERT(VARCHAR(10),Movimientos2.FECHA_MOV2,102) BETWEEN '" & FEC1 & "' AND '" & FEC2 & "')  "
                                                    CmdStr = "SELECT SUM(a.CANT_MOV2) " & _
                                                              " FROM dbo.MOVIMIENTOS2 AS a INNER JOIN dbo.PRODUCTOS AS b ON a.[Codigo de producto] = b.[Codigo de producto] INNER JOIN  " & _
                                                              " dbo.UNIDADDEMEDIDA AS c ON b.[Unidad de medida] = c.clave  " & _
                                                              " WHERE  (CONVERT(VARCHAR(10),a.FECHA_MOV2,102) BETWEEN '" & FEC1 & "' AND '" & FEC2 & "')  "
                                                Else
                                                    MsgBox("Favor de seleccionar un tipo valido de movimiento")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If tipomovx = "SMR" Then
                CmdStr = CmdStr & "AND a.TIPO_MOV2 = '" & tipomovx & "' "
                CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Cbalm.Text & "' "
            Else
                If tipomovx.Substring(0, 1) = "E" Then
                    CmdStr = CmdStr & "AND a.TIPO_MOV2 = '" & tipomovx & "' "
                    CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Cbalm.Text & "' "
                End If
                If tipomovx.Substring(0, 1) = "S" Then
                    CmdStr = CmdStr & "AND a.TIPO_MOV2  = '" & tipomovx & "' "
                    CmdStr = CmdStr & "AND a.PROV_MOV2 = '" & Cbalm.Text & "' "
                End If
            End If


            'If Me.CBMOVI.Text = "ENTRADA" Then
            '    'MsgBox(" es entrada")
            '    CmdStr = CmdStr & "AND a.TIPO_MOV2 = 'ENT' "
            '    CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.Cbalm.Text & "' "
            'End If
            'If Me.CBMOVI.Text = "SALIDA" Then
            '    'MsgBox("es salida")
            '    CmdStr = CmdStr & "AND a.TIPO_MOV2 = 'SAL' "
            '    CmdStr = CmdStr & "AND a.PROV_MOV2 = '" & Me.Cbalm.Text & "' "
            'End If


            If Me.CHCLIENTE.Checked = True Then
                'If Me.CBRUTAS.Text = Nothing Then
                If Me.ComboBox2.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Cliente")
                    erro = 1
                    'Me.CBRUTAS.Focus()
                    Me.ComboBox2.Focus()
                Else
                    'MsgBox("agrega cliente")
                    CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.ComboBox2.Text & "' "
                    'CmdStr = CmdStr & "AND a.CLIEN_MOV2 = '" & Me.CBRUTAS.Text & "' "
                End If
            End If

            If Me.CHPROV.Checked = True Then
                If Me.CBPROVE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Proveedor")
                    erro = 1
                    Me.CBPROVE.Focus()
                Else
                    'MsgBox("agrega proveedor")
                    CmdStr = CmdStr & "AND a.PROV_MOV2 = '" & Me.CBPROVE.Text & "' "
                End If
            End If

            If Me.CHUSU.Checked = True Then
                If Me.CBUSU.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar usuario")
                    erro = 1
                    Me.CBUSU.Focus()
                Else
                    'MsgBox("agrega usuario")
                    CmdStr = CmdStr & "AND a.USU_MOV2 = '" & Me.CBUSU.Text & "' "
                End If

            End If

            If Me.CHFAM.Checked = True Then
                If Me.CBFAM.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar familia")
                    erro = 1
                    Me.CBFAM.Focus()
                Else
                    fam1 = Me.CBFAM.Text
                    fam2 = Traefam(fam1)

                    'MsgBox("agrega familia")
                    CmdStr = CmdStr & "AND  b.familia = '" & fam2 & "' "
                    'MsgBox("falta filtro familia")
                End If

            End If

            If Me.CHCODE.Checked = True Then
                If Me.TxtCodigo.Text = Nothing Then
                    MsgBox("Error, requiere ingresar codigo")
                    erro = 1
                    Me.TxtCodigo.Focus()
                Else
                    'MsgBox("agrega codigo")
                    CmdStr = CmdStr & "AND a.[Codigo de Producto] = '" & Me.TxtCodigo.Text & "' "
                End If

            End If

            If Me.CHFAC.Checked = True Then
                If Me.CHNUMERO.Checked = True Then
                    If Me.TXTFAC.Text = Nothing Then
                        MsgBox("Error, Requiere capturar Numero de factura o Nota")
                        erro = 1
                        Me.TXTFAC.Focus()
                    Else
                        'MsgBox("agrega numero factura")
                        CmdStr = CmdStr & "AND a.FACNOT_MOV2 = '" & Me.TXTFAC.Text & "' "
                    End If
                Else
                    If Me.CBFAC.Text = Nothing Then
                        MsgBox("Error, requiere seleccionar factura o nota")
                        erro = 1
                        Me.CBFAC.Focus()
                    Else
                        'MsgBox("agrega opcion de factura")
                        'CmdStr = CmdStr & "AND a.FAC_MOV2 = '" & Me.CBFAC.Text & "' "
                        CmdStr = CmdStr & "AND FAC_MOV2 = '" & Me.CBFAC.Text & "' "
                    End If

                End If

            End If
            If erro = 1 Then
                MsgBox("FALTAN DATOS")
            Else
                'MsgBox("Carga filtro")
                'printmov(CmdStr)
                Dim SqlTOT As New SqlCommand(CmdStr, SqlCnn)
                Dim SqlRead As SqlDataReader
                Try
                    SqlRead = SqlTOT.ExecuteReader
                    While SqlRead.Read
                        If SqlRead.IsDBNull(0) = True Then
                            Me.Lbtotal.Text = "0"
                        Else
                            Me.Lbtotal.Text = SqlRead.GetDecimal(0)
                        End If
                    End While
                    SqlRead.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

            End If
        End If


    End Sub
    Private Sub Cargadatagridusu(ByVal Cmdstr As String)


        Dim SqlSel As New SqlDataAdapter(Cmdstr, SqlCnn)
        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
            With Me.gridmovi
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub


    Private Sub Cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbalm.SelectedIndexChanged
        ''Me.Cbalm.Enabled = False
        'Me.CBRUTAS.Items.Clear()
        'With CBRUTAS
        '    .Items.Add("COCINA")
        '    .Items.Add("SALIDA MERMA")
        '    .Items.Add("DEVOLUCION")
        '    .Items.Add(Me.Cbalm.Text)
        '    '.SelectedIndex = 0
        'End With
        If Me.ChBoxUbi.Checked = True Then
            Call Me.CargaUBI()
        End If
    End Sub

    Private Sub CBMOVI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBMOVI.SelectedIndexChanged

    End Sub

    Private Sub CHRUTA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Call Me.DesabilitaChe(CHRUTA)
        If Me.CheckBox1.Checked = True Then
            Me.CBCLIENTE.Enabled = True

            Me.CHCLIENTE.Checked = False
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHUSU.Checked = False
        Else


            Me.CBCLIENTE.Enabled = False
            Me.CBCLIENTE.Text = Nothing
        End If
    End Sub

    Private Sub CHUBICA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Call Me.DesabilitaChe(CHUBICA)
        If Me.ChBoxUbi.Checked = True Then
            Me.CBUBI.Enabled = True

            Me.CHCLIENTE.Checked = False
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False
            Me.CheckBox1.Checked = False
            Me.CHUSU.Checked = False

        Else

            Me.CBUBI.Enabled = False
            Me.CBUBI.Text = ""
        End If
    End Sub

    Private Sub ChBoxUbi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxUbi.CheckedChanged
        If Me.ChBoxUbi.Checked = True Then
            Me.CBUBI.Enabled = True

            Me.CheckBox1.Checked = False
            Me.CHFAC.Checked = False
            Me.CHCLIENTE.Checked = False
            Me.CHCODE.Checked = False
            Me.CHNUMERO.Checked = False
            Me.CHPROV.Checked = False

            Me.CHUSU.Checked = False
            Me.CBMOVI.Enabled = False
            Me.CBMOVI.Text = ""
            CargaUBI()
        Else

            Me.CBMOVI.Enabled = True
            Me.CBUBI.Enabled = False
            Me.CBUBI.Text = Nothing
        End If
    End Sub

    Private Sub CBFAC_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBFAC.SelectedValueChanged
        If Me.CBFAC.Text <> "" Then
            Me.CHNUMERO.Enabled = True
            Me.TXTFAC.Enabled = True
        Else
            Me.CHNUMERO.Enabled = False
            Me.TXTFAC.Enabled = False
            Me.TXTFAC.Text = ""
        End If
    End Sub

    Private Sub CBMOVI_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBMOVI.SelectedValueChanged
        If Me.CBMOVI.Text = "SALIDAS POR MERMA" Then
            Me.CheckBox1.Checked = False
            Me.CHFAC.Checked = False
            Me.CHCLIENTE.Checked = False
            Me.CHPROV.Checked = False
            Me.ChBoxUbi.Checked = False
            Me.CHFAM.Checked = False

            Me.CheckBox1.Enabled = False
            Me.CHFAC.Enabled = False
            Me.CHCLIENTE.Enabled = False
            Me.CHPROV.Enabled = False
            Me.ChBoxUbi.Enabled = False
            Me.CHFAM.Enabled = False
        Else
            Me.CheckBox1.Enabled = True
            Me.CHFAC.Enabled = True
            Me.CHCLIENTE.Enabled = True
            Me.CHPROV.Enabled = True
            Me.ChBoxUbi.Enabled = True
            Me.CHFAM.Enabled = True
        End If
    End Sub
End Class