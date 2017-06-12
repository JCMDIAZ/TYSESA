Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmEntIni

    Public Fam As String

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmEntIni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CBCLIENTE.Enabled = False
        Me.CBUSU.Enabled = False
        Me.CBFAM.Enabled = False
        Me.CBPROVE.Enabled = False
        Me.TxtCodigo.Enabled = False
        Me.TXTFAC.Enabled = False
        'Me.CBCOMPCLIEN.Enabled = False
        'Me.DTCOMPA.Enabled = False
        'Me.DTCOMPDE.Enabled = False
        Me.CBFAC.Enabled = False
        Me.CHNUMERO.Enabled = False

        With CBFAC
            .Items.Add("NOT")
            .Items.Add("FAC")
        End With
        With CBMOVI
            .Items.Add("TODOS")
            .Items.Add("ENTRADAS")
            .Items.Add("SALIDAS")
            .Items.Add("DEVOLUCIONES")
            .SelectedIndex = 0
        End With

        CargaUsuario()
        Cargafam()
        CargaPROVE()
        Cargacliente()
    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        'If Me.CHCOMPA.Checked = True Then

        'End If

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
        Dim CmdStr As New String("SELECT a.[Codigo de producto] as CODIGO, b.descripcion as DESCRIPCION, a.LOTE_MOV as LOTE, " & _
                                "a.TIPO_MOV as SAL_ENT, a.CANT_MOV as CANT, a.COSTO_MOV AS COSTO, c.abreviatura as UM, d.abreviatura as FAM, a.FACNOT_MOV as FAC_NOTA, " & _
                                "a.PROV_MOV as PROVEEDOR, a.CLIEN_MOV as CLIENTE, a.FECHA_MOV as FECHA, a.USU_MOV, a.TOT_MOV " & _
                                "FROM movimientos a, productos b, unidaddemedida c, familias d " & _
                                "WHERE a.[Codigo de producto] = b.[Codigo de producto] AND b.[Unidad de medida] = c.clave AND b.familia = d.clave AND FECHA_MOV BETWEEN '" & FEC1 & "' AND '" & FEC2 & "' ")
        
        FECDE = Me.DTFECHADE.Text
        FECA = Me.DTFECHAA.Text
        erro = 0
        If FECDE > FECA Then
            MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
        Else
            If Me.CBMOVI.Text = "ENTRADAS" Then
                'MsgBox(" es entrada")
                CmdStr = CmdStr & "AND a.TIPO_MOV = 'ENT' "
            End If
            If Me.CBMOVI.Text = "SALIDAS" Then
                'MsgBox("es salida")
                CmdStr = CmdStr & "AND a.TIPO_MOV != 'ENT'  "
            End If

            If Me.CHCLIENTE.Checked = True Then
                If Me.CBCLIENTE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Cliente")
                    erro = 1
                    Me.CBCLIENTE.Focus()
                Else
                    'MsgBox("agrega cliente")
                    CmdStr = CmdStr & "AND a.CLIEN_MOV = '" & Me.CBCLIENTE.Text & "' "
                End If
            End If

            If Me.CHPROV.Checked = True Then
                If Me.CBPROVE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Proveedor")
                    erro = 1
                    Me.CBPROVE.Focus()
                Else
                    'MsgBox("agrega proveedor")
                    CmdStr = CmdStr & "AND a.PROV_MOV = '" & Me.CBPROVE.Text & "' "
                End If
            End If

            If Me.CHUSU.Checked = True Then
                If Me.CBUSU.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar usuario")
                    erro = 1
                    Me.CBUSU.Focus()
                Else
                    'MsgBox("agrega usuario")
                    CmdStr = CmdStr & "AND a.USU_MOV = '" & Me.CBUSU.Text & "' "
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
                        CmdStr = CmdStr & "AND a.FACNOT_MOV = '" & Me.TXTFAC.Text & "' "
                    End If
                Else
                    If Me.CBFAC.Text = Nothing Then
                        MsgBox("Error, requiere seleccionar factura o nota")
                        erro = 1
                        Me.CBFAC.Focus()
                    Else
                        'MsgBox("agrega opcion de factura")
                        CmdStr = CmdStr & "AND a.FAC_MOV = '" & Me.CBFAC.Text & "' "
                    End If

                End If

            End If
            If erro = 1 Then
                MsgBox("FALTAN DATOS")
            Else

                'MsgBox("Carga filtro")
                Cargadatagridusu(CmdStr)
                traesuma()

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
    Private Sub Cargatipo()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From Familias ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBMOVI.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Cargacliente()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From clientes ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBCLIENTE.Items.Add(SqlRead.GetString(0))
                'Me.CBCOMPCLIEN.Items.Add(SqlRead.GetString(0))
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

        If Me.CHCLIENTE.Checked = True Then
            Me.CBCLIENTE.Enabled = True
        Else
            Me.CBCLIENTE.Enabled = False
            Me.CBCLIENTE.Text = Nothing
        End If

    End Sub

    Private Sub CHPROV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHPROV.CheckedChanged
        If Me.CHPROV.Checked = True Then
            Me.CBPROVE.Enabled = True
        Else
            Me.CBPROVE.Enabled = False
            Me.CBPROVE.Text = Nothing
        End If
    End Sub

    Private Sub CHFAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHFAC.CheckedChanged
        If Me.CHFAC.Checked = True Then
            Me.CBFAC.Enabled = True
            Me.CHNUMERO.Enabled = True
        Else
            Me.CHNUMERO.Enabled = False
            Me.TXTFAC.Enabled = False
            Me.TXTFAC.Text = Nothing
            Me.CBFAC.Enabled = False
            Me.CBFAC.Text = Nothing
        End If
    End Sub

    Private Sub CHUSU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHUSU.CheckedChanged
        If Me.CHUSU.Checked = True Then
            Me.CBUSU.Enabled = True
        Else
            Me.CBUSU.Enabled = False
            Me.CBUSU.Text = Nothing
        End If
    End Sub

    Private Sub CHFAM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHFAM.CheckedChanged
        If Me.CHFAM.Checked = True Then
            Me.CBFAM.Enabled = True
        Else
            Me.CBFAM.Enabled = False
            Me.CBFAM.Text = Nothing
        End If
    End Sub

    Private Sub CHCODE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHCODE.CheckedChanged
        If Me.CHCODE.Checked = True Then
            Me.TxtCodigo.Enabled = True
        Else
            Me.TxtCodigo.Enabled = False
            Me.TxtCodigo.Text = Nothing
        End If
    End Sub

    Private Sub CHNUMERO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHNUMERO.CheckedChanged
        If Me.CHNUMERO.Checked = True Then
            Me.TXTFAC.Enabled = True
            Me.CBFAC.Enabled = False
            Me.CBFAC.Text = Nothing
        Else
            Me.TXTFAC.Enabled = False
            Me.TXTFAC.Text = Nothing
            Me.CBFAC.Enabled = True
        End If
    End Sub

    Private Sub CHCOMPA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.CHCOMPA.Checked = True Then
        '    Me.DTCOMPA.Enabled = True
        '    Me.DTCOMPDE.Enabled = True
        '    Me.CBCOMPCLIEN.Enabled = True

        'Else
        '    Me.DTCOMPA.Enabled = False
        '    Me.DTCOMPDE.Enabled = False
        '    Me.CBCOMPCLIEN.Enabled = False
        '    Me.CBCOMPCLIEN.Text = Nothing
        'End If
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
    Public Sub printmov(ByVal sqldato As String)
        Dim ObjAdapterNum As New SqlDataAdapter(sqldato, SqlCnn)
        Dim ObjDSNum As New DataSet
        ObjAdapterNum.Fill(ObjDSNum)
        Dim n As Integer
        n = ObjDSNum.Tables(0).Rows.Count()
        'CODIGO, DESCRIPCION, SAL_ENT, CANT, COSTO, UM, Fam, FAC_NOTA, PROVEEDOR, CLIENTE, FECHA, USUARIO"
        Dim strRuta As String
        strRuta = "c:\MOVIMIENTOS-" & Format(Today, "ddMMyyyy") & Format(TimeOfDay, "HHmm") & ".csv"
        Dim objStreamWrite As New StreamWriter(strRuta)
        objStreamWrite.WriteLine("CODIGO, DESCRIPCION, SAL_ENT, CANT, COSTO, UM, FAM, FAC_NOTA, PROVEEDOR, CLIENTE, FECHA, USUARIO")
        Dim sw As String
        If n > 0 Then
            Dim i As Integer
            Dim Number As String
            For i = 0 To n - 1

                Number = ObjDSNum.Tables(0).Rows(i).Item(0)

                Dim ObjAdapter As New SqlDataAdapter(sqldato, SqlCnn)
                Dim ObjDS As New DataSet
                ObjAdapter.Fill(ObjDS)
                Dim nw As Integer
                nw = ObjDS.Tables(0).Rows.Count()
                If nw > 0 Then
                    sw = ObjDS.Tables(0).Rows(i).Item(0) & "," & ObjDS.Tables(0).Rows(i).Item(1) & "," & ObjDS.Tables(0).Rows(i).Item(2) & "," & ObjDS.Tables(0).Rows(i).Item(3) & "," & ObjDS.Tables(0).Rows(i).Item(4) & "," & ObjDS.Tables(0).Rows(i).Item(5) & "," & ObjDS.Tables(0).Rows(i).Item(6) & "," & ObjDS.Tables(0).Rows(i).Item(7) & "," & ObjDS.Tables(0).Rows(i).Item(8) & "," & ObjDS.Tables(0).Rows(i).Item(9) & "," & ObjDS.Tables(0).Rows(i).Item(10) & "," & ObjDS.Tables(0).Rows(i).Item(11) & ""
                    objStreamWrite.WriteLine(sw)
                    sw = ""
                    ObjDS = Nothing
                    ObjAdapter = Nothing
                    Number = Nothing
                Else
                    ObjDS = Nothing
                    ObjAdapter = Nothing
                    Number = Nothing
                End If
            Next
        End If
        objStreamWrite.Close()
        MsgBox("Archivo de Movimientos se a Generado Exitosamente.", MsgBoxStyle.Exclamation, "Aviso.")
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
    Private Sub traesuma()
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
        Dim CmdStr As New String("SELECT SUM(a.TOT_MOV) " & _
                                 "FROM movimientos a, productos b, unidaddemedida c, familias d " & _
                                "WHERE a.[Codigo de producto] = b.[Codigo de producto] AND b.[Unidad de medida] = c.clave AND b.familia = d.clave AND FECHA_MOV BETWEEN '" & FEC1 & "' AND '" & FEC2 & "' ")
        FECDE = Me.DTFECHADE.Text
        FECA = Me.DTFECHAA.Text
        erro = 0
        If FECDE > FECA Then
            MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
        Else
            If Me.CBMOVI.Text = "ENTRADA" Then
                'MsgBox(" es entrada")
                CmdStr = CmdStr & "AND a.TIPO_MOV = 'ENT' "
            End If
            If Me.CBMOVI.Text = "SALIDA" Then
                'MsgBox("es salida")
                CmdStr = CmdStr & "AND a.TIPO_MOV = 'SAL' "
            End If

            If Me.CHCLIENTE.Checked = True Then
                If Me.CBCLIENTE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Cliente")
                    erro = 1
                    Me.CBCLIENTE.Focus()
                Else
                    'MsgBox("agrega cliente")
                    CmdStr = CmdStr & "AND a.CLIEN_MOV = '" & Me.CBCLIENTE.Text & "' "
                End If
            End If

            If Me.CHPROV.Checked = True Then
                If Me.CBPROVE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Proveedor")
                    erro = 1
                    Me.CBPROVE.Focus()
                Else
                    'MsgBox("agrega proveedor")
                    CmdStr = CmdStr & "AND a.PROV_MOV = '" & Me.CBPROVE.Text & "' "
                End If
            End If

            If Me.CHUSU.Checked = True Then
                If Me.CBUSU.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar usuario")
                    erro = 1
                    Me.CBUSU.Focus()
                Else
                    'MsgBox("agrega usuario")
                    CmdStr = CmdStr & "AND a.USU_MOV = '" & Me.CBUSU.Text & "' "
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
                        CmdStr = CmdStr & "AND a.FACNOT_MOV = '" & Me.TXTFAC.Text & "' "
                    End If
                Else
                    If Me.CBFAC.Text = Nothing Then
                        MsgBox("Error, requiere seleccionar factura o nota")
                        erro = 1
                        Me.CBFAC.Focus()
                    Else
                        'MsgBox("agrega opcion de factura")
                        CmdStr = CmdStr & "AND a.FAC_MOV = '" & Me.CBFAC.Text & "' "
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

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

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
        Dim CmdStr As New String("SELECT a.[Codigo de producto] as CODIGO, b.descripcion as DESCRIPCION, " & _
                                "a.TIPO_MOV as SAL_ENT, a.CANT_MOV as CANT, a.COSTO_MOV AS COSTO, c.abreviatura as UM, d.abreviatura as FAM, a.FACNOT_MOV as FAC_NOTA, " & _
                                "a.PROV_MOV as PROVEEDOR, a.CLIEN_MOV as CLIENTE, a.FECHA_MOV as FECHA, a.USU_MOV " & _
                                "FROM movimientos a, productos b, unidaddemedida c, familias d " & _
                                "WHERE a.[Codigo de producto] = b.[Codigo de producto] AND b.[Unidad de medida] = c.clave AND b.familia = d.clave AND FECHA_MOV BETWEEN '" & FEC1 & "' AND '" & FEC2 & "' ")

        FECDE = Me.DTFECHADE.Text
        FECA = Me.DTFECHAA.Text
        erro = 0
        If FECDE > FECA Then
            MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
        Else
            If Me.CBMOVI.Text = "ENTRADA" Then
                'MsgBox(" es entrada")
                CmdStr = CmdStr & "AND a.TIPO_MOV = 'ENT' "
            End If
            If Me.CBMOVI.Text = "SALIDA" Then
                'MsgBox("es salida")
                CmdStr = CmdStr & "AND a.TIPO_MOV = 'SAL' AND a.TIPO_MOV = 'SAL-TRAS' "
            End If

            If Me.CHCLIENTE.Checked = True Then
                If Me.CBCLIENTE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Cliente")
                    erro = 1
                    Me.CBCLIENTE.Focus()
                Else
                    'MsgBox("agrega cliente")
                    CmdStr = CmdStr & "AND a.CLIEN_MOV = '" & Me.CBCLIENTE.Text & "' "
                End If
            End If

            If Me.CHPROV.Checked = True Then
                If Me.CBPROVE.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Proveedor")
                    erro = 1
                    Me.CBPROVE.Focus()
                Else
                    'MsgBox("agrega proveedor")
                    CmdStr = CmdStr & "AND a.PROV_MOV = '" & Me.CBPROVE.Text & "' "
                End If
            End If

            If Me.CHUSU.Checked = True Then
                If Me.CBUSU.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar usuario")
                    erro = 1
                    Me.CBUSU.Focus()
                Else
                    'MsgBox("agrega usuario")
                    CmdStr = CmdStr & "AND a.USU_MOV = '" & Me.CBUSU.Text & "' "
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
                        CmdStr = CmdStr & "AND a.FACNOT_MOV = '" & Me.TXTFAC.Text & "' "
                    End If
                Else
                    If Me.CBFAC.Text = Nothing Then
                        MsgBox("Error, requiere seleccionar factura o nota")
                        erro = 1
                        Me.CBFAC.Focus()
                    Else
                        'MsgBox("agrega opcion de factura")
                        CmdStr = CmdStr & "AND a.FAC_MOV = '" & Me.CBFAC.Text & "' "
                    End If

                End If

            End If
            If erro = 1 Then
                MsgBox("FALTAN DATOS")
            Else
                'MsgBox("Carga filtro")
                printmov(CmdStr)

            End If
        End If


    End Sub

    
End Class