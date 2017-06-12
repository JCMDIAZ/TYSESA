Imports System.Data
Imports System.Data.SqlClient

Public Class FrmLevanPed
    Dim CLPROD As Int32
    Dim vventa As Double
    Dim iiva, iieps As Double
    Dim CLTraePed As String
    ' 

    Private Function traePed() As String
        Me.BtnBorrarPro.Text = "Borrar Producto"
        CLTraePed = 0
        Me.DGDETALLE.Columns.Clear()
        Dim lectura As SqlDataReader
        '" AND (dbo.PEDIDOS.EnRuta_Ped = 0 or dbo.PEDIDOS.EnRuta_Ped is null)", SqlCnn)
        Dim CmdStrP As New SqlCommand("SELECT dbo.PEDIDOS.IDCLIENTE_PED, dbo.PEDIDOS.ID_PED, dbo.PEDIDOS_DET.[ALTER], dbo.PEDIDOS_DET.[Codigo de producto], dbo.PEDIDOS_DET.CANT_PROD, " & _
                                    "dbo.PEDIDOS_DET.COSTO_PROD, dbo.PEDIDOS_DET.IVA_PROD, dbo.PEDIDOS_DET.ieps_Ped FROM dbo.PEDIDOS INNER JOIN dbo.PEDIDOS_DET ON dbo.PEDIDOS.ID_PED = dbo.PEDIDOS_DET.ID_PED where dbo.PEDIDOS.IDCLIENTE_PED = '" & Me.cbCliente.SelectedValue & "' " & _
                                    "AND (dbo.PEDIDOS.Surtio_Ped = 0 or dbo.PEDIDOS.Surtio_Ped is null ) and (dbo.PEDIDOS.Cancelado_Ped = 0 or dbo.PEDIDOS.Cancelado_Ped is null) " & _
                                    "  ", SqlCnn)
        Try
            lectura = CmdStrP.ExecuteReader
            While lectura.Read
                CLTraePed = lectura.GetValue(0)
                Me.txtFolioPed.Text = lectura.GetValue(1)
            End While
            lectura.Close()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
            Return CLTraePed = 0
            Exit Function
        End Try
        '" AND (dbo.PEDIDOS.EnRuta_Ped = 0 or dbo.PEDIDOS.EnRuta_Ped is null)", SqlCnn)
        If CLTraePed <> 0 Then
            Dim SqlSel As New SqlDataAdapter("SELECT dbo.PEDIDOS.IDCLIENTE_PED AS CLPED, dbo.PEDIDOS.ID_PED, dbo.PEDIDOS_DET.[ALTER] AS CODE, dbo.PEDIDOS_DET.[Codigo de producto] as DESCR, dbo.PEDIDOS_DET.CANT_PROD AS Cantidad, " & _
                                    "dbo.PEDIDOS_DET.COSTO_PROD as VENTA, dbo.PEDIDOS_DET.IVA_PROD AS IVA, dbo.PEDIDOS_DET.ieps_Ped AS IEPS, dbo.PEDIDOS_DET.TOTAL_PED AS TOTAL, PEDIDOS.EnRuta_Ped FROM dbo.PEDIDOS INNER JOIN dbo.PEDIDOS_DET ON dbo.PEDIDOS.ID_PED = dbo.PEDIDOS_DET.ID_PED where dbo.PEDIDOS.IDCLIENTE_PED = '" & Me.cbCliente.SelectedValue & "' " & _
                                    "AND (dbo.PEDIDOS.Surtio_Ped = 0 or dbo.PEDIDOS.Surtio_Ped is null ) and (dbo.PEDIDOS.Cancelado_Ped = 0 or dbo.PEDIDOS.Cancelado_Ped is null) " & _
                                    "  ", SqlCnn)
            Dim DS As New DataTable
            SqlSel.Fill(DS)

            Try
                Me.DGDETALLE.DataSource = DS

            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try

            If Me.DGDETALLE.Rows.Count <> 0 Then
                Me.DGDETALLE.Columns("CLPED").Visible = False
                Me.DGDETALLE.Columns("ID_PED").Visible = False

                If DGDETALLE.Columns("EnRuta_Ped").ToString IsNot DBNull.Value Then


                    For Each row As DataGridViewRow In DGDETALLE.Rows
                        Dim fr As String = row.Cells("EnRuta_Ped").Value.ToString()
                        If row.Cells("EnRuta_Ped").Value.ToString() = "True" Then
                            Me.BtnBorrarPro.Text = "EN RUTA"
                            'Me.BtnBorrarPro.Enabled = False
                        Else
                            Me.BtnBorrarPro.Text = "Borrar Producto"
                            'Me.BtnBorrarPro.Enabled = True

                        End If

                    Next
                    If DGDETALLE.Columns("EnRuta_Ped").ToString = "1" Then

                    Else

                    End If
                Else
                    Me.BtnBorrarPro.Text = "Borrar Producto"
                    Me.BtnBorrarPro.Enabled = True
                End If
            Else

            End If
        Else
            Me.DGDETALLE.DataSource = Nothing
            Me.txtFolioPed.Text = ""
            Me.DGDETALLE.Columns.Add("CLPED", "CLPED")
            Me.DGDETALLE.Columns.Add("ID_PED", "ID_PED")
            Me.DGDETALLE.Columns.Add("CODE", "CODE")
            Me.DGDETALLE.Columns.Add("DESCR", "DESCR")
            Me.DGDETALLE.Columns.Add("Cantidad", "Cantidad")
            Me.DGDETALLE.Columns.Add("VENTA", "VENTA")
            Me.DGDETALLE.Columns.Add("IVA", "IVA")
            Me.DGDETALLE.Columns.Add("IEPS", "IEPS")
            Me.DGDETALLE.Columns.Add("TOTAL", "TOTAL")
            Me.DGDETALLE.Columns.Add("EnRuta_Ped", "EnRuta_Ped")
            Me.DGDETALLE.Columns("EnRuta_Ped").ReadOnly = True
            Me.DGDETALLE.Columns("CLPED").Visible = False
            Me.DGDETALLE.Columns("ID_PED").Visible = False
        End If

        Return CLTraePed
    End Function
    Private Sub guardaPed()
        Dim CODIGO As String
        Dim lectura As SqlDataReader
        Dim StatPed As String = "PLA"
        Dim IDPED As Int32
        If Me.DGDETALLE.Rows.Count > 0 Then
            Dim CmdStr As New SqlCommand("declare @idped int INSERT INTO PEDIDOS VALUES ('', '" & Me.cbCliente.SelectedValue & "', 0, '" & MDIPrincipal.StbUSER.Text & "', getdate(), '" & Format(Me.DTPFaSurtir.Value, "dd/MM/yyyy") & "', null, '" & Me.LblTRuta.Text & "', null, null, null, '" & StatPed & "', null, 0) " & _
                                                "select scope_identity() ", SqlCnn)
            Try
                lectura = CmdStr.ExecuteReader
                While lectura.Read
                    IDPED = lectura.GetValue(0)
                    Me.txtFolioPed.Text = IDPED
                End While
                lectura.Close()
            Catch ex As Exception
                Error1 = 1
                MsgBox(ex.Message.ToString)
                Exit Sub
            End Try
            For Each row As DataGridViewRow In DGDETALLE.Rows
                Dim CmdStr1 As New SqlCommand(" INSERT INTO PEDIDOS_DET VALUES (" & IDPED & ", '" & row.Cells("CODE").Value.ToString() & "', '" & row.Cells("DESCR").Value.ToString() & "', '" & row.Cells("Cantidad").Value.ToString() & "', '" & row.Cells("VENTA").Value.ToString() & "', '" & row.Cells("IVA").Value.ToString() & "', '" & row.Cells("TOTAL").Value.ToString() & "','" & row.Cells("TOTAL").Value.ToString() & "', '" & row.Cells("IEPS").Value.ToString() & "') ", SqlCnn)
                Try
                    lectura = CmdStr1.ExecuteReader
                    While lectura.Read
                        IDPED = lectura.GetInt32(0)
                    End While
                    lectura.Close()
                Catch ex As Exception
                    Error1 = 1
                    MsgBox(ex.Message.ToString)
                    Exit Sub
                End Try

            Next
        End If
        MsgBox("El Pedido " & Me.txtFolioPed.Text & " ha sido Guardado")
        CLTraePed = IDPED
        Return
    End Sub

    Private Sub tieneruta()
        Dim lectura As SqlDataReader
        Dim idclie As Int32
        If Me.cbCliente.SelectedIndex = -1 Then
            idclie = 0
        Else
            idclie = Me.cbCliente.SelectedValue
        End If
        Dim Cmdd As New SqlCommand("SELECT dbo.CLIENTES.Clave AS ID, dbo.Cat_ClienteRuta.CODEMAQ AS BARCODE, dbo.Cat_ClienteRuta.RUTA FROM dbo.Cat_ClienteRuta RIGHT OUTER JOIN dbo.CLIENTES ON dbo.Cat_ClienteRuta.IDMAQUINA = dbo.CLIENTES.Clave where  dbo.CLIENTES.Clave = " & idclie & "  ", SqlCnn)
        Try
            lectura = Cmdd.ExecuteReader
            While lectura.Read
                'Me.LblRuta.Text = lectura.GetString(2)
                If lectura.IsDBNull(2) Then
                    Me.LblTRuta.Text = "NO TIENE"
                Else
                    Me.LblTRuta.Text = lectura.GetString(2)
                End If
            End While
            lectura.Close()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        Finally
            lectura.Close()
        End Try
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
            .SelectedValue = 0

        End With
        Me.cbCliente.Text = "--Selecciona un Cliente--"
        Me.LblTRuta.Text = "NO TIENE"
    End Sub

    Private Function cancelaPed() As Int32
        Dim can As Int32 = 0
        Dim lectura As SqlDataReader
        Dim CmdStr1 As New SqlCommand("UPDATE PEDIDOS SET dbo.PEDIDOS.Cancelado_Ped = 1 WHERE dbo.PEDIDOS.ID_PED = " & Me.txtFolioPed.Text & " AND dbo.PEDIDOS.IDCLIENTE_PED = " & CLTraePed & " ", SqlCnn)

        Try
            lectura = CmdStr1.ExecuteReader
            While lectura.Read
                'IDPED = lectura.GetInt32(0)
            End While
            lectura.Close()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
            can = 1
        End Try
        Return can
    End Function

    Private Sub FrmLevanPed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Me.CargaCliente()
        'Me.DGDETALLE.Columns.Add("CLPED", "CLPED")
        'Me.DGDETALLE.Columns.Add("ID_PED", "ID_PED")
        'Me.DGDETALLE.Columns.Add("CODE", "CODE")
        'Me.DGDETALLE.Columns.Add("DESCR", "DESCR")
        'Me.DGDETALLE.Columns.Add("Cantidad", "Cantidad")
        'Me.DGDETALLE.Columns.Add("VENTA", "VENTA")
        'Me.DGDETALLE.Columns.Add("IVA", "IVA")
        'Me.DGDETALLE.Columns.Add("IEPS", "IEPS")
        'Me.DGDETALLE.Columns.Add("TOTAL", "TOTAL")

        'Me.DGDETALLE.Columns("CLPED").Visible = False
        'Me.DGDETALLE.Columns("ID_PED").Visible = False

        'Me.DTPFaSurtir.MinDate = Today()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If (Me.TBoxBuscaAlter.Text.Trim = "" And Me.TBoxBuscaCod.Text.Trim = "" And Me.TBoxBuscaDescrip.Text.Trim = "") Or (Me.TBoxBuscaAlter.Text.Trim <> "" And Me.TBoxBuscaCod.Text.Trim <> "" And Me.TBoxBuscaDescrip.Text.Trim <> "") Then
            Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] as CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre Corto] AS CORTO, a.[Precio de venta] AS VENTA, a.IVA AS IVA,a.IEPS AS IEPS,a.existencia AS EXISTENCIA From dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave WHERE A.ACTIVO <> 0 ORDER BY a.alterno ", SqlCnn)
            Dim DS As New DataTable
            Try
                SqlSel.Fill(DS)
                With Me.DGPROD
                    .DataSource = DS
                End With
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
        Else
            If Me.TBoxBuscaAlter.Text.Trim = "" And Me.TBoxBuscaCod.Text.Trim = "" And Me.TBoxBuscaDescrip.Text.Trim <> "" Then
                Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.[Precio de venta] AS VENTA, a.IVA, a.IEPS, a.existencia AS EXISTENCIA FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.Descripcion like '%" & Me.TBoxBuscaDescrip.Text.Trim & "%' AND A.ACTIVO <> 0 order by a.alterno", SqlCnn)
                Dim DS As New DataTable
                Try
                    SqlSel.Fill(DS)
                    With Me.DGPROD
                        .DataSource = DS
                    End With
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
            Else
                If Me.TBoxBuscaAlter.Text.Trim = "" And Me.TBoxBuscaCod.Text.Trim <> "" And Me.TBoxBuscaDescrip.Text.Trim = "" Then
                    Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.[Precio de venta] AS VENTA, a.IVA, a.IEPS, a.existencia AS EXISTENCIA FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.[Codigo de producto] like '%" & Me.TBoxBuscaCod.Text.Trim & "%' AND A.ACTIVO <> 0 order by a.alterno", SqlCnn)
                    Dim DS As New DataTable
                    Try
                        SqlSel.Fill(DS)
                        With Me.DGPROD
                            .DataSource = DS
                        End With
                    Catch ex As SqlException
                        MsgBox(ex.Message.ToString)
                    End Try
                Else
                    If Me.TBoxBuscaAlter.Text.Trim <> "" And Me.TBoxBuscaCod.Text.Trim = "" And Me.TBoxBuscaDescrip.Text.Trim = "" Then
                        Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.[Precio de venta] AS VENTA, a.IVA, a.IEPS, a.existencia AS EXISTENCIA FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.alterno like '%" & Me.TBoxBuscaAlter.Text.Trim & "%' AND A.ACTIVO <> 0 order by a.alterno", SqlCnn)
                        Dim DS As New DataTable
                        Try
                            SqlSel.Fill(DS)
                            With Me.DGPROD
                                .DataSource = DS
                            End With
                        Catch ex As SqlException
                            MsgBox(ex.Message.ToString)
                        End Try
                    Else
                        If Me.TBoxBuscaAlter.Text.Trim <> "" And Me.TBoxBuscaCod.Text.Trim <> "" And Me.TBoxBuscaDescrip.Text.Trim = "" Then
                            Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.[Precio de venta] AS VENTA, a.IVA, a.IEPS, a.existencia AS EXISTENCIA FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.alterno like '%" & Me.TBoxBuscaAlter.Text.Trim & "%' or a.[Codigo de producto] like '%" & Me.TBoxBuscaCod.Text.Trim & "%' AND A.ACTIVO <> 0 order by a.alterno", SqlCnn)
                            Dim DS As New DataTable
                            Try
                                SqlSel.Fill(DS)
                                With Me.DGPROD
                                    .DataSource = DS
                                End With
                            Catch ex As SqlException
                                MsgBox(ex.Message.ToString)
                            End Try
                        Else
                            If Me.TBoxBuscaAlter.Text.Trim = "" And Me.TBoxBuscaCod.Text.Trim <> "" And Me.TBoxBuscaDescrip.Text.Trim <> "" Then
                                Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.[Precio de venta] AS VENTA, a.IVA, a.IEPS, a.existencia AS EXISTENCIA FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.[Codigo de producto] like '%" & Me.TBoxBuscaCod.Text.Trim & "%' or a.Descripcion like '%" & Me.TBoxBuscaDescrip.Text.Trim & "%' AND A.ACTIVO <> 0 order by a.alterno", SqlCnn)
                                Dim DS As New DataTable
                                Try
                                    SqlSel.Fill(DS)
                                    With Me.DGPROD
                                        .DataSource = DS
                                    End With
                                Catch ex As SqlException
                                    MsgBox(ex.Message.ToString)
                                End Try
                            Else
                                If Me.TBoxBuscaAlter.Text.Trim <> "" And Me.TBoxBuscaCod.Text.Trim = "" And Me.TBoxBuscaDescrip.Text.Trim <> "" Then
                                    Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.[Precio de venta] AS VENTA, a.IVA, a.IEPS, a.existencia AS EXISTENCIA, a.EnRuta_Ped  FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.alterno like '%" & Me.TBoxBuscaAlter.Text.Trim & "%' or a.Descripcion like '%" & Me.TBoxBuscaDescrip.Text.Trim & "%' AND A.ACTIVO <> 0 order by a.alterno", SqlCnn)
                                    Dim DS As New DataTable
                                    Try
                                        SqlSel.Fill(DS)
                                        With Me.DGPROD
                                            .DataSource = DS
                                        End With
                                    Catch ex As SqlException
                                        MsgBox(ex.Message.ToString)
                                    End Try
                                Else

                                End If
                            End If
                        End If
                    End If
                End If
            End If

        End If
        Me.DGPROD.Columns("ALTERNO").Visible = False
    End Sub

    Private Sub BtnAgregaPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregaPedido.Click
        If CLTraePed <> 0 Then
            MsgBox("El Pedido ya existe, para modificar cancelar pedido y agregar nuevo")
            Exit Sub
        Else

            If Me.cbCliente.Text = "--Selecciona un Cliente--" Then
                MsgBox("Favor de Seleccionar un Cliente")
            Else
                If Me.txtCantidad.Text = "" Then
                    MsgBox("Favor de Insertar la Cantidad")
                    Exit Sub
                End If
                Dim sitiene As Boolean = False
                'Me.DGDETALLE.Columns("CODE").Visible = False
                Dim SumP As Int32 = 0
                Dim SumT As Double = 0
                If Me.DGDETALLE.Rows.Count > 0 Then


                    Dim ty As Int32 = Me.DGDETALLE.CurrentRow.Index
                    For Each row As DataGridViewRow In DGDETALLE.Rows
                        'If row.IsNewRow Then Return False
                        If row.Cells("DESCR").Value.ToString() = Me.TxtProd.Text.Trim Then
                            row.Cells("Cantidad").Value = Me.txtCantidad.Text
                            sitiene = True
                        End If

                    Next
                End If
                If sitiene = False Then
                    Me.DGDETALLE.Rows.Add(0, 0, CLPROD, Me.TxtProd.Text.Trim, Me.txtCantidad.Text, vventa, iiva, iieps, (Me.txtCantidad.Text * vventa) + ((Me.txtCantidad.Text * vventa) * iieps))
                End If
                Dim tv As Double = (Me.txtCantidad.Text * vventa) + ((Me.txtCantidad.Text * vventa) * iieps)
                If Me.DGDETALLE.Rows.Count > -1 Then


                    Dim cantn, cantn1 As Double
                    Dim art, art1 As Int32
                    For Each row As DataGridViewRow In DGDETALLE.Rows
                        cantn = row.Cells(8).Value
                        cantn1 = cantn1 + cantn
                        art = row.Cells(4).Value
                        art1 = art1 + art
                    Next row
                    Me.lbltotal.Text = cantn1
                    Me.LblArticulos.Text = DGDETALLE.Rows.Count
                    Me.LBLTTOTALART.Text = art1
                End If
            End If
        End If
    End Sub

    Private Sub DGPROD_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPROD.CellClick
        If e.RowIndex > -1 Then

            
            If DGPROD.Rows(e.RowIndex).Cells("ALTERNO").Value IsNot DBNull.Value Then

                CLPROD = DGPROD.Rows(e.RowIndex).Cells("ALTERNO").Value
                'Me.TXTBOXCodBarr.Text = TxtCodigo.Text                     DESCR
                Me.TxtProd.Text = DGPROD.Rows(e.RowIndex).Cells("DESCR").Value
                'txtAbr.Text = DGPROD.Rows(e.RowIndex).Cells("Abreviatura").Value
                'txtRFC.Text = DGPROD.Rows(e.RowIndex).Cells("RFC").Value
                vventa = DGPROD.Rows(e.RowIndex).Cells("VENTA").Value
                iiva = DGPROD.Rows(e.RowIndex).Cells("IVA").Value
                iieps = DGPROD.Rows(e.RowIndex).Cells("IEPS").Value
                'TXTCALLE1.Text = DGPROD.Rows(e.RowIndex).Cells("calle").Value

            End If
        End If

    End Sub


    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = Chr(13) Then
        Else

            If InStr(1, "0123456789" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If Me.TxtProd.Text = "" Then

            MsgBox("Selecciona un Producto")
        Else
            Me.BtnAgregaPedido.Enabled = True
        End If
    End Sub

    Private Sub BtnBorrarPro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBorrarPro.LostFocus
        If CLTraePed <> 0 Then
            MsgBox("El Pedido ya existe, para modificar cancelar pedido y agregar nuevo")
            Exit Sub
        Else
            Me.BtnBorrarPro.Enabled = False

            Me.DGDETALLE.Rows.Remove(Me.DGDETALLE.CurrentRow)
        End If


    End Sub

    Private Sub DGDETALLE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDETALLE.CellClick
        If e.RowIndex > -1 Then
            If DGDETALLE.Rows(e.RowIndex).Cells("EnRuta_Ped").Value = "True" Then

            Else

                If DGDETALLE.Rows(e.RowIndex).Cells("CODE").Value IsNot DBNull.Value Then

                    CLPROD = DGDETALLE.Rows(e.RowIndex).Cells("CODE").Value
                    'Me.TXTBOXCodBarr.Text = TxtCodigo.Text                     DESCR
                    Me.TxtProd.Text = DGDETALLE.Rows(e.RowIndex).Cells("DESCR").Value
                    'txtAbr.Text = DGPROD.Rows(e.RowIndex).Cells("Abreviatura").Value
                    'txtRFC.Text = DGPROD.Rows(e.RowIndex).Cells("RFC").Value
                    vventa = DGDETALLE.Rows(e.RowIndex).Cells("VENTA").Value
                    iiva = DGDETALLE.Rows(e.RowIndex).Cells("IVA").Value
                    iieps = DGDETALLE.Rows(e.RowIndex).Cells("IEPS").Value
                    'TXTCALLE1.Text = DGPROD.Rows(e.RowIndex).Cells("calle").Value

                    Me.BtnBorrarPro.Enabled = True
                End If
            End If
        end if
    End Sub

    Private Sub DGDETALLE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGDETALLE.LostFocus
        Me.BtnBorrarPro.Enabled = False
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.txtFolioPed.Text = ""
        CLPROD = 0
        Me.cbCliente.Text = "--Selecciona un Cliente--"
        Me.TxtProd.Text = ""
        If Me.DGDETALLE.DataSource IsNot Nothing Then
            Me.DGDETALLE.DataSource = Nothing
        Else
            Me.DGDETALLE.Rows.Clear()
        End If

        vventa = 0
        iiva = 0
        iieps = 0
        Me.LblTRuta.Text = "NO TIENE"
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        If Me.txtFolioPed.Text.Trim = "" Then
            MsgBox("No ha guardado Pedido para Cancelar")
            Exit Sub
        Else
            Dim sican As Int32 = 0
            If cancelaPed() = 0 Then
                MsgBox("Pedido " & Me.txtFolioPed.Text & " Cancelado")
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.DGDETALLE.Rows.Count = 0 Then
            MsgBox("No hay Pedido a Guardar")
            Exit Sub
        Else
            If Me.LblTRuta.Text = "NO TIENE" Then
                MsgBox("Cliente no cuenta con Ruta")
                Exit Sub
            End If
        End If
        Call Me.guardaPed()
    End Sub

    Private Sub cbCliente_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.SelectedValueChanged

        If Me.cbCliente.ValueMember <> "" Then
            tieneruta()
            Me.traePed()
        End If

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DGDETALLE_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDETALLE.CellContentClick

    End Sub

    Private Sub DGPROD_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPROD.CellContentClick

    End Sub
End Class