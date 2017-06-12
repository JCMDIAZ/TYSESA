Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Public Class FrmExpendedoras
    Dim dato As Integer
    Dim selecciona1, selecciona2, tiposel As String
    Private m_ChildFormNumber As Integer = 0

    Sub pongamayus()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.CharacterCasing = CharacterCasing.Upper
            Else
            End If
        Next
    End Sub
    Private Sub FrmExpendedoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pongamayus()
        txtufecha.Text = DateString
        Call Me.CargaCliente()
        CargaGrid()
        Call Me.CargaComboRutas()

        Me.cbCliente.SelectAll()
        Me.cbCliente.Focus()

    End Sub
    Private Sub SelecUbicacion()
        Dim CODIGO As String
        Dim SPaso As Boolean = True
        CODIGO = Me.txtCODE.Text
        Dim lectura As SqlDataReader

        Me.txtID.Text = ""
        Me.txtCODE.Text = ""
        Me.txtubi.Text = ""

        'Dim CmdStr As New SqlCommand("SELECT calle, Clave FROM CLIENTES where Clave = '" & Me.cbCliente.SelectedValue & "' ", SqlCnn)
        'Dim CmdStr As New SqlCommand("SELECT IDMAQUINA AS ID, CODEMAQ as BARCODE, DESCRIPCION AS NOMBRE, DIRECCION AS UBICACION, INSTALACION AS ULTIMAFECHA, RUTA FROM Cat_ClienteRuta where IDMAQUINA = '" & Me.cbCliente.SelectedValue & "' ", SqlCnn)
        Dim CmdStr As New SqlCommand("SELECT dbo.CLIENTES.Clave AS ID, dbo.Cat_ClienteRuta.CODEMAQ AS BARCODE, dbo.Cat_ClienteRuta.DESCRIPCION AS NOMBRE, dbo.CLIENTES.calle AS UBICACION, dbo.Cat_ClienteRuta.INSTALACION AS ULTIMAFECHA, dbo.Cat_ClienteRuta.RUTA, dbo.Cat_ClienteRuta.IDMAQUINA, dbo.Cat_ClienteRuta.DIRECCION FROM dbo.Cat_ClienteRuta RIGHT OUTER JOIN dbo.CLIENTES ON dbo.Cat_ClienteRuta.IDMAQUINA = dbo.CLIENTES.Clave where dbo.clientes.clave = '" & Me.cbCliente.SelectedValue & "' ", SqlCnn)
        lectura = CmdStr.ExecuteReader
        Try
            While lectura.Read
             
                'Me.txtubi.Text = lectura.GetString(0)
                'Me.txtID.Text = lectura.GetInt32(1)
                Me.txtID.Text = lectura.GetInt32(0)
                If lectura.IsDBNull(1) Then

                Else
                    Me.txtCODE.Text = lectura.GetString(1)
                End If
                Me.txtubi.Text = lectura.GetString(3)
                If lectura.IsDBNull(5) Then
                    SPaso = False
                Else
                    Me.cbruta.SelectedValue = 0
                    Me.cbruta.SelectedValue = lectura.GetString(5)
                End If
            End While
            lectura.Close()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        Finally
            lectura.Close()
        End Try
        If SPaso = False Then
            Me.cbruta.Text = "--Selecciona una Ruta--"
        End If
    End Sub
    Private Sub CargaComboRutas()
        Dim SqlSel As New SqlDataAdapter("SELECT IDRUTA, NOMBRE FROM RUTAS where activo = 1 ORDER BY IDRUTA", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
           
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        With Me.cbruta
            .DataSource = DS
            .DisplayMember = "NOMBRE" '"TEZINR"
            .ValueMember = "IDRUTA"
            .SelectedIndex = 0

        End With
        Me.cbruta.Text = "--Selecciona una Ruta--"
    End Sub

    Private Sub CargaCliente()

        Dim SqlSel As New SqlDataAdapter("SELECT  Clave, Razon, calle FROM CLIENTES WHERE ACTIVO = '1' ", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
           
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        With Me.cbCliente
            .DataSource = DS
            .DisplayMember = "Razon"
            .ValueMember = "Clave"
            .SelectedIndex = 0

        End With
        Me.cbCliente.Text = "--Seleccione un Cliente--"
    End Sub
    Private Sub CargaGrid()

        'Dim SqlSel As New SqlDataAdapter("SELECT IDMAQUINA AS ID, CODEMAQ as BARCODE, DESCRIPCION AS NOMBRE, DIRECCION AS UBICACION, INSTALACION AS ULTIMAFECHA, RUTA FROM MACHINES order by IDMAQUINA", SqlCnn)
        Dim SqlSel As New SqlDataAdapter("SELECT IDMAQUINA AS ID, CODEMAQ as BARCODE, DESCRIPCION AS NOMBRE, DIRECCION AS UBICACION, INSTALACION AS ULTIMAFECHA, RUTA FROM Cat_ClienteRuta where RUTA <> 0 order by IDMAQUINA", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGEXP
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub CargaGridRuta()

        'Dim SqlSel As New SqlDataAdapter("SELECT IDMAQUINA AS ID, CODEMAQ as BARCODE, DESCRIPCION AS NOMBRE, DIRECCION AS UBICACION, INSTALACION AS ULTIMAFECHA, RUTA FROM MACHINES order by IDMAQUINA", SqlCnn)
        Dim SqlSel As New SqlDataAdapter("SELECT IDMAQUINA AS ID, CODEMAQ as BARCODE, DESCRIPCION AS NOMBRE, DIRECCION AS UBICACION, INSTALACION AS ULTIMAFECHA, RUTA FROM Cat_ClienteRuta where ruta = '" & Me.cbruta.SelectedValue & "' order by IDMAQUINA", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGEXP
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.Close()
    End Sub

    Private Sub DGEXP_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEXP.CellClick
        If e.RowIndex > -1 Then
            txtID.Text = DGEXP.Rows(e.RowIndex).Cells("ID").Value
            If Me.cbCliente.SelectedValue = DGEXP.Rows(e.RowIndex).Cells("ID").Value Then
                If Me.cbCliente.SelectedValue = 1 Then
                    Me.cbCliente.SelectedValue = 2
                End If

            End If
            Me.cbCliente.SelectedValue = DGEXP.Rows(e.RowIndex).Cells("ID").Value
            txtCODE.Text = DGEXP.Rows(e.RowIndex).Cells("BARCODE").Value
            txtname.Text = DGEXP.Rows(e.RowIndex).Cells("NOMBRE").Value
            txtubi.Text = DGEXP.Rows(e.RowIndex).Cells("UBICACION").Value
            txtufecha.Text = DGEXP.Rows(e.RowIndex).Cells("ULTIMAFECHA").Value
            'cbruta.Text = DGEXP.Rows(e.RowIndex).Cells("RUTA").Value
            Dim fres As Object = DGEXP.Rows(e.RowIndex).Cells("RUTA").Value
            If cbruta.SelectedValue = DGEXP.Rows(e.RowIndex).Cells("RUTA").Value Then
                If cbruta.SelectedValue = 1 Then
                    cbruta.SelectedValue = 2
                End If
            End If
            cbruta.SelectedValue = DGEXP.Rows(e.RowIndex).Cells("RUTA").Value
            CargaGrid2(DGEXP.Rows(e.RowIndex).Cells("ID").Value)
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'txtID.Text = Nothing
        'txtCODE.Text = Nothing
        'txtname.Text = Nothing
        'txtubi.Text = Nothing
        'cbruta.Text = Nothing
        For Each c As Control In GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.Text = ""
            Else
                If TypeOf c Is ComboBox Then
                    Dim Cboxtem As ComboBox = CType(c, ComboBox)
                    Cboxtem.Text = ""
                Else

                End If
            End If
        Next
        txtufecha.Text = Date.Now.ToString("dd/MM/yyyy")
        Me.cbCliente.Text = "--Seleccione un Cliente--"
        Me.cbCliente.SelectAll()
        Me.cbruta.Text = "--Selecciona una Ruta--"
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        ''Dim erro As Integer = 0
        ''Dim Sqlbusmov As New SqlCommand
        ''Dim CmdStr As New String(selecciona1)
        ''selecciona1 = "SELECT * FROM LOGDEL "
        ''selecciona2 = "DELETE FROM LOGDEL "
        ''tiposel = "LOG DE MOVIMIENTOS BORRADOS "

        ''If CmdStr = Nothing Or CmdStr = "" Then
        ''    erro = 1
        ''End If
        ''erro = 1
        ''If erro = 1 Then
        ''    MsgBox("FALTAN DATOS")
        ''Else
        ''    'MsgBox("Carga filtro")
        ''    printmov(CmdStr)
        ''End If

        'Dim DTMACHINES As New DataTable
        'Dim DTREPORTE As New DataTable
        'Dim SqlCOMMAND As New SqlCommand
        'Dim ADAP As New SqlDataAdapter
        'Try
        '    SqlCOMMAND.Connection = SqlCnn
        '    SqlCOMMAND.CommandText = "SELECT * FROM MACHINES ORDER BY IDMAQUINA  "
        '    ADAP.SelectCommand = SqlCOMMAND
        '    ADAP.Fill(DTMACHINES)
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try
        'Dim DTPRODUCTOS As New DataTable
        'Dim SqlCOMMAND2 As New SqlCommand
        'Dim ADAP2 As New SqlDataAdapter
        'Try
        '    SqlCOMMAND2.Connection = SqlCnn
        '    SqlCOMMAND2.CommandText = "SELECT * FROM PRODUCTOS ORDER BY [Codigo de Producto]  "
        '    ADAP2.SelectCommand = SqlCOMMAND
        '    ADAP2.Fill(DTPRODUCTOS)
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try
        ''Dim tabla As String = dttabla.TableName
        ''dttabla.Columns.Add("TIEMPO", GetType(String))
        ''dttabla.Columns.Add("PROTOCOLO", GetType(String))
        ''Dim renglon As DataRow
        ''renglon = dttabla.NewRow()
        ''Dim numerofilas As Integer = dttabla.Rows.Count
        ''For i As Integer = 0 To numerofilas - 1

        ''    dttabla.Rows(i)("TIEMPO") = "DATOS_1"
        ''    dttabla.Rows(i)("PROTOCOLO") = "DATOS2"
        ''Next
        'For Each row As DataRow In DTMACHINES.Rows
        '    DTREPORTE.Columns.Add(row(0), GetType(String))
        'Next
        'Dim renglon As DataRow
        'renglon = DTREPORTE.NewRow()
        'Dim numerofilas As Integer = DTREPORTE.Rows.Count
        'For i As Integer = 0 To numerofilas - 1

        '    DTREPORTE.Rows(i)(1) = "DATOS_1"
        '    DTREPORTE.Rows(i)(2) = "DATOS2"
        'Next
        'With Me.DataGridView1
        '    .DataSource = DTREPORTE
        'End With

        For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
            If MDIPrincipal.MdiChildren(i).Text = "Reporte de Clientes a Rutas" Then

                MDIPrincipal.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chReportClRut As New ReporteClientesRutas
        chReportClRut.MdiParent = MDIPrincipal
        m_ChildFormNumber += 1
        chReportClRut.Show()
    End Sub
    Public Sub printmov(ByVal sqldato As String)
        Dim date1 As String
        date1 = Now.ToString
        Dim ObjAdapterNum As New SqlDataAdapter(sqldato, SqlCnn)
        Dim ObjDSNum As New DataSet
        ObjAdapterNum.Fill(ObjDSNum)
        Dim n As Integer
        n = ObjDSNum.Tables(0).Rows.Count()
        'Dim strRuta As String

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Excel CSV|*.csv"
        saveFileDialog1.Title = "Exportar a excel"
        saveFileDialog1.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then
            Dim fs As System.IO.FileStream = CType(saveFileDialog1.OpenFile(), System.IO.FileStream)
            Dim objStreamWrite As New StreamWriter(fs)
            Dim primeralinea As String = ""
            primeralinea = "CODIGO,TIPO-MOV,FECHA,USER,CANTIDAD,COSTO,ALMACEN"
            objStreamWrite.WriteLine(primeralinea)
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
                        sw = ""
                        'If typeL = 1 Then
                        '    sw = ObjDS.Tables(0).Rows(i).Item(0) & "," & ObjDS.Tables(0).Rows(i).Item(1) & "," & ObjDS.Tables(0).Rows(i).Item(2)
                        'End If
                        'If typeL = 2 Then
                        '    sw = ObjDS.Tables(0).Rows(i).Item(0) & "," & ObjDS.Tables(0).Rows(i).Item(1) & "," & ObjDS.Tables(0).Rows(i).Item(2) & "," & ObjDS.Tables(0).Rows(i).Item(3) & "," & ObjDS.Tables(0).Rows(i).Item(4) & "," & ObjDS.Tables(0).Rows(i).Item(5) & "," & ObjDS.Tables(0).Rows(i).Item(6) & "," & ObjDS.Tables(0).Rows(i).Item(7) & "," & ObjDS.Tables(0).Rows(i).Item(8) & "," & ObjDS.Tables(0).Rows(i).Item(9)
                        'End If
                        'If typeL = 3 Then
                        '    sw = ObjDS.Tables(0).Rows(i).Item(0) & "," & ObjDS.Tables(0).Rows(i).Item(1) & "," & ObjDS.Tables(0).Rows(i).Item(2) & "," & ObjDS.Tables(0).Rows(i).Item(3) & "," & ObjDS.Tables(0).Rows(i).Item(4) & "," & ObjDS.Tables(0).Rows(i).Item(5) & "," & ObjDS.Tables(0).Rows(i).Item(6) & "," & ObjDS.Tables(0).Rows(i).Item(7)
                        'End If
                        'If typeL = 4 Then
                        '    sw = ObjDS.Tables(0).Rows(i).Item(0) & "," & ObjDS.Tables(0).Rows(i).Item(1) & "," & ObjDS.Tables(0).Rows(i).Item(2) & "," & ObjDS.Tables(0).Rows(i).Item(3) & "," & ObjDS.Tables(0).Rows(i).Item(4) & "," & ObjDS.Tables(0).Rows(i).Item(5) & "," & ObjDS.Tables(0).Rows(i).Item(6) & "," & ObjDS.Tables(0).Rows(i).Item(7) & "," & ObjDS.Tables(0).Rows(i).Item(8) & "," & ObjDS.Tables(0).Rows(i).Item(9) & "," & ObjDS.Tables(0).Rows(i).Item(10) & "," & ObjDS.Tables(0).Rows(i).Item(11) & "," & ObjDS.Tables(0).Rows(i).Item(12) & "," & ObjDS.Tables(0).Rows(i).Item(13)
                        'End If
                        'If typeL = 5 Then
                        '    sw = ObjDS.Tables(0).Rows(i).Item(0) & "," & ObjDS.Tables(0).Rows(i).Item(1) & "," & ObjDS.Tables(0).Rows(i).Item(2) & "," & ObjDS.Tables(0).Rows(i).Item(3) & "," & ObjDS.Tables(0).Rows(i).Item(4) & "," & ObjDS.Tables(0).Rows(i).Item(5) & "," & ObjDS.Tables(0).Rows(i).Item(6)
                        'End If
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
            fs.Close()
        End If

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        If txtID.Text = Nothing Or Me.txtCODE.Text = Nothing Or Me.txtubi.Text = Nothing Or Me.cbruta.Text = Nothing Or Me.cbCliente.Text = Nothing Or Me.txtubi.Text = Nothing Or Me.cbruta.Text = "--Selecciona una Ruta--" Then
            MsgBox("REQUIERE TODOS LOS DATOS COMPLETOS")
        Else
            guardayactu()
            If dato = 0 Then
                txtufecha.Text = DateString
                txtufecha.Text = Format(Now(), "dd/MM/yyyy") & " " & Format(Now(), "HH:mm:ss")
                'Dim Sqlasigna As New SqlCommand("IF NOT EXISTS(SELECT * FROM MACHINES WHERE IDMAQUINA = '" & txtID.Text & "' ) " & _
                '                    "Begin INSERT INTO MACHINES (IDMAQUINA,CODEMAQ,DESCRIPCION,TOTAL,DIRECCION,INSTALACION,RUTA) Values ('" & txtID.Text & "','" & txtCODE.Text & "','" & txtname.Text & "', 0,'" & txtubi.Text & "', '" & txtufecha.Text & "', '" & cbruta.Text & "') End ELSE  " & _
                '                    "BEGIN UPDATE MACHINES SET CODEMAQ = '" & txtCODE.Text & "', DESCRIPCION = '" & txtname.Text & "', DIRECCION = '" & txtubi.Text & "', INSTALACION = '" & txtufecha.Text & "', RUTA = '" & cbruta.Text & "' WHERE IDMAQUINA = '" & txtID.Text & "'  END", SqlCnn)
                Dim Sqlasigna As New SqlCommand("IF NOT EXISTS(SELECT * FROM Cat_ClienteRuta WHERE IDMAQUINA = '" & cbCliente.SelectedValue & "' ) " & _
                                    "Begin INSERT INTO Cat_ClienteRuta (IDMAQUINA,CODEMAQ,DESCRIPCION,TOTAL,DIRECCION,INSTALACION,RUTA) Values ('" & cbCliente.SelectedValue & "','" & txtCODE.Text.Trim & "','" & cbCliente.Text.Trim & "', 0,'" & txtubi.Text.Trim & "', '" & txtufecha.Text.Trim & "', '" & cbruta.SelectedValue & "') End ELSE  " & _
                                    "BEGIN UPDATE Cat_ClienteRuta SET CODEMAQ = '" & txtCODE.Text.Trim & "', DESCRIPCION = '" & cbCliente.Text.Trim & "', DIRECCION = '" & txtubi.Text.Trim & "', INSTALACION = '" & txtufecha.Text.Trim & "', RUTA = '" & cbruta.SelectedValue & "' WHERE IDMAQUINA = '" & cbCliente.SelectedValue & "'  END ", SqlCnn)

                Dim SqlRead As SqlDataReader
                Try
                    SqlRead = Sqlasigna.ExecuteReader
                    While SqlRead.Read
                        'folio = SqlRead.GetValue(0)
                    End While
                    SqlRead.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                CargaGrid()
            Else
                MsgBox("El codigo ya existe favor de capturar un codigo de barras valido")
            End If

        End If
    End Sub
    Private Sub guardayactu()
        Dim CODIGO As String

        CODIGO = Me.txtCODE.Text
        Dim lectura As SqlDataReader


        Dim CmdStr As New SqlCommand("declare @existe int set @existe=0 IF EXISTS(SELECT * FROM MACHINES WHERE CODEMAQ = '" & CODIGO & "' and IDMAQUINA <> '" & txtID.Text & "') " & _
                                "Begin set @existe=1 end select @existe", SqlCnn)

        lectura = CmdStr.ExecuteReader
        Try
            While lectura.Read
                dato = lectura.GetInt32(0)
            End While
            lectura.Close()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try
        Return
    End Sub
    Private Sub CargaGrid2(ByVal IDEXPEN1 As Integer)

        Dim SqlSel2 As New SqlDataAdapter("SELECT A.[Codigo de Producto] AS PRODUCTO, DESCRIPCION, CANTIDAD  AS CANTIDAD, C.ABREVIATURA AS UM FROM INVENTARIOMACH A, PRODUCTOS B, UNIDADDEMEDIDA C  WHERE A.[Codigo de Producto] = B.[Codigo de Producto] AND B.[Unidad de medida] = C.clave AND IDMAQUINA = '" & IDEXPEN1 & "'", SqlCnn)
        Dim DS2 As New DataTable
        Try
            SqlSel2.Fill(DS2)
            With Me.DGDETALLE
                .DataSource = DS2
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub TSOpciones_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TSOpciones.ItemClicked

    End Sub

    Private Sub cbCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.SelectionChangeCommitted
        Call Me.SelecUbicacion()
        Me.txtCODE.Focus()

    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        'Dim Sqlasigna As New SqlCommand("delete FROM Cat_ClienteRuta WHERE IDMAQUINA = '" & cbCliente.SelectedValue & "' ", SqlCnn)
        Dim Sqlasigna As New SqlCommand("UPDATE Cat_ClienteRuta set Ruta = 0 WHERE IDMAQUINA = '" & cbCliente.SelectedValue & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlasigna.ExecuteReader
            While SqlRead.Read
                'folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        MsgBox("El Cliente se a borrado")
        CargaGrid()
    End Sub

    Private Sub cbruta_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbruta.SelectionChangeCommitted

        Call Me.CargaGridRuta()
    End Sub

    Private Sub txtCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCODE.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbruta.Focus()
        End If
    End Sub

    Private Sub DGEXP_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEXP.CellContentClick

    End Sub

    Private Sub cbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCliente.SelectedIndexChanged

    End Sub

    Private Sub txtCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCODE.TextChanged

    End Sub
End Class