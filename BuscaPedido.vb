Imports System.Data
Imports System.Data.SqlClient

Public Class BuscaPedido

    Private Sub CHPROV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHALM.CheckedChanged
        If Me.CHALM.Checked = True Then
            Me.CBALM.Enabled = True
        Else
            Me.CBALM.Enabled = False
            Me.CBALM.Text = Nothing
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

    Private Sub CHPED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHPED.CheckedChanged
        If Me.CHPED.Checked = True Then
            Me.Txtpedido.Enabled = True
        Else
            Me.Txtpedido.Enabled = False
            Me.Txtpedido.Text = Nothing
        End If
    End Sub

    Private Sub CHSUR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHSUR.CheckedChanged
        If Me.CHSUR.Checked = True Then
            Me.GroupBox2.Text = "FECHA SURTIDO"
        Else
            Me.GroupBox2.Text = "FECHA CREACION"
        End If
    End Sub

    Private Sub BuscaPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CBALM.Enabled = False
        Me.CBUSU.Enabled = False
        Me.Txtpedido.Enabled = False
        Me.TxtCodigo.Enabled = False
        CargaUsuario()
        CargaPROVE()
        Cargacliente()
    End Sub

    Private Sub CHCODE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHCODE.CheckedChanged
        If Me.CHCODE.Checked = True Then
            Me.TxtCodigo.Enabled = True
        Else
            Me.TxtCodigo.Enabled = False
            Me.TxtCodigo.Text = Nothing
        End If
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
    Private Sub CargaPROVE()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From ALMACENES ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBALM.Items.Add(SqlRead.GetString(0))
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
    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo")
                Me.TxtCodigo.Focus()
            Else
                Me.LblDescripcion.Text = Nothing
                Traecodigo()
                Traedes()
                Me.TxtCodigo.Select()
                'Traeprecio()
                If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                    MsgBox("ERROR, Producto NO habilitado o no existe")
                    Me.TxtCodigo.Focus()
                    Me.TxtCodigo.SelectAll()
                Else

                End If
            End If
        End If
    End Sub
    Private Sub Traecodigo()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim SqlCODE As New SqlCommand("SELECT [Codigo de producto] FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & " and Baja = 'NO' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlCODE.ExecuteReader
            While SqlRead.Read
                Me.TxtCodigo.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub Traedes()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim Sqlprecio As New SqlCommand("SELECT [Nombre Corto] FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & " ", SqlCnn)
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

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
       
        Dim FECDE As Date
        Dim FECA As Date
        Dim FEC1 As String
        Dim FEC2 As String
        FEC1 = Me.DTFECHADE.Text
        FEC2 = Me.DTFECHAA.Text

        Dim erro As Integer
        'Dim fam1 As String
        'Dim fam2 As String
        Dim Sqlbusmov As New SqlCommand
        Dim CmdStr As New String("SELECT a.ID_PED, a.CLIENTE_PED, a.PROV_PED, a.USU_PED, a.FECHA_PED, a.FSURT_PED, a.AUTO_PED, a.UTIL_PED " & _
                                "FROM PEDIDOS a, pedidos_det b WHERE a.ID_PED = b.ID_PED AND a.CLIENTE_PED = '" & Me.CBCLIENTE.Text & "' AND a.FECHA_PED BETWEEN '" & FEC1 & "' AND '" & FEC2 & "' ")

        FECDE = Me.DTFECHADE.Text
        FECA = Me.DTFECHAA.Text
        erro = 0
        If FECDE > FECA Then
            MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
        Else
            If Me.CBCLIENTE.Text = Nothing Then
                MsgBox("Error, requiere seleccionar Cliente")
                erro = 1
                Me.CBCLIENTE.Focus()
            Else
                'MsgBox("agrega cliente")
                CmdStr = CmdStr & "AND a.CLIENTE_PED = '" & Me.CBCLIENTE.Text & "' "
            End If

            If Me.CHALM.Checked = True Then
                If Me.CBALM.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar Almacen")
                    erro = 1
                    Me.CBALM.Focus()
                Else
                    'MsgBox("agrega proveedor")
                    CmdStr = CmdStr & "AND a.PROV_PED = '" & Me.CBALM.Text & "' "
                End If
            End If

            If Me.CHUSU.Checked = True Then
                If Me.CBUSU.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar usuario")
                    erro = 1
                    Me.CBUSU.Focus()
                Else
                    'MsgBox("agrega usuario")
                    CmdStr = CmdStr & "AND a.USU_PED = '" & Me.CBUSU.Text & "' "
                End If

            End If

            If Me.CHCODE.Checked = True Then
                If Me.TxtCodigo.Text = Nothing Then
                    MsgBox("Error, requiere ingresar codigo")
                    erro = 1
                    Me.TxtCodigo.Focus()
                Else
                    'MsgBox("agrega codigo")
                    CmdStr = CmdStr & "AND b.[Codigo de Producto] = '" & Me.TxtCodigo.Text & "' "
                End If
            End If
        End If
            If erro = 1 Then
                MsgBox("FALTAN DATOS")
            Else
            CmdStr = CmdStr & " GROUP BY a.ID_PED, a.CLIENTE_PED, a.PROV_PED, a.USU_PED, a.FECHA_PED, a.FSURT_PED, a.AUTO_PED, a.UTIL_PED ORDER BY a.ID_PED "
            'MsgBox(CmdStr)
            Cargadatagridusu(CmdStr)
        End If

    End Sub
    Private Sub Cargadatagridusu(ByVal Cmdstr As String)


        Dim SqlSel As New SqlDataAdapter(Cmdstr, SqlCnn)
        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
            With Me.DGBP
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub DGBP_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGBP.CellClick
        Dim IDPED As String
        
        Dim value As Object = DGBP.Rows(e.RowIndex).Cells(0).Value
        If value.GetType Is GetType(DBNull) Then Return

        IDPED = CType(value, Integer)
        gridetalle(IDPED)
        
    End Sub
 
    Private Sub gridetalle(ByVal id As Integer)

        Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de Producto], b.descripcion, a.Cant_PROD, a.Costo_Prod, a.Monto_Prod, a.IVA_PROD,a.TOTAL_PED FROM Pedidos_det a, Productos b WHERE a.[Codigo de Producto] = b.[Codigo de Producto] and a.ID_PED = " & id & " ", SqlCnn)
        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
            With Me.DGDP
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        If Me.LBCLIENTE.Text = Nothing Or Me.LBCLIENTE.Text = "." Then
        Else
            If Me.LBPED.Text = Nothing Or Me.LBPED.Text = "." Then
                MsgBox("NO SE A SELECCIONADO EL PEDIDO")
            Else
                With Reports6
                    .Show(Me)
                End With
            End If
        End If
    End Sub

    Private Sub DGBP_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGBP.CellClick

        Dim CLIEN As String
        Dim PED As String
        
        Dim value As Object = DGBP.Rows(e.RowIndex).Cells(0).Value()
        Dim value1 As Object = DGBP.Rows(e.RowIndex).Cells(1).Value
       
        If value.GetType Is GetType(DBNull) Then Return

        CLIEN = CType(value, String)
        PED = CType(value1, String)

        Me.LBPED.Text = CLIEN
        Me.LBCLIENTE.Text = PED
        
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        'FrmPedidos.Txtpedido.Text = Me.LBPED.Text
        FrmPedidos.Show()

    End Sub

    Private Sub DGBP_CellContentClick_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGBP.CellContentClick

    End Sub
End Class