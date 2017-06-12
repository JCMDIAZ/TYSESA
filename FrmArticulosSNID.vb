Imports System.Data.Sqlclient

Public Class FrmArticulosSNID
    Dim prefolio020, codigo020 As String
    Dim prefolio021, codigo021, descripcion021 As String
    Private Sub FrmArticulosSNID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbprefolio.Items.Add("Todos")
        Traeprecargas()
        Traealmacen()
        cbprefolio.SelectedIndex = 0
        CargaGridped()
        Me.TxtID.Focus()

    End Sub
    Public Sub Traealmacen()
        Dim SqlClientes As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & USUARIOCONECTA & "' ORDER BY a.almacen", SqlCnn)
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
    Private Function TraeID(ByVal id01) As String

        Dim SqlSelDes As New SqlCommand("SELECT [Codigo de Producto], [nombre corto], [Precio de compra] FROM productos WHERE [Codigo de Producto] = '" & id01 & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim codeidI As Integer = 0
        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) Then
                    codeidI = 0
                Else
                    'codeidI = SqlRead.GetString(0)
                    Me.TXTDESCRIPCION.Text = SqlRead.GetString(1)
                    Me.TxtCosto.Text = SqlRead.GetDecimal(2)
                    codeidI = 1
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return codeidI

    End Function
    Public Sub Traeprecargas()
        Dim SqlClientes As New SqlCommand("SELECT folio FROM tsalres2 ORDER BY folio", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.cbprefolio.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub CargaGridped()
        Dim DS As New DataTable
        Dim prefolio010 As String = ""
        If Me.cbprefolio.Text = "Todos" Then
            prefolio010 = ""
        Else
            prefolio010 = "folio = '" & Me.cbprefolio.Text & "' AND"
        End If
        Try
            Dim F1 As String
            F1 = Me.cbprefolio.Text
            Dim SqlSel1 As New SqlDataAdapter("SELECT *  FROM tsalres2 where " & prefolio010 & " ID_Nuevo = '0' order by codigo", SqlCnn)
            SqlSel1.Fill(DS)
            Me.DGSNASIGNAR.DataSource = DS
        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub CargaGridped2()
        Dim DS2 As New DataTable
        Try
            Dim F1 As String
            F1 = Me.cbprefolio.Text
            Dim SqlSel1 As New SqlDataAdapter("SELECT *  FROM tsalres2 where ID_Nuevo <> '0' order by codigo", SqlCnn)
            SqlSel1.Fill(DS2)
            Me.DGASIGNADO.DataSource = DS2
        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Dim resp
        resp = MsgBox("Hay datos que no ha guardado, ¿Desea salir de todas formas?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            Me.Close()
        End If
    End Sub

    Private Sub cbprefolio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbprefolio.SelectedIndexChanged
        CargaGridped()
    End Sub

    Private Sub DGSNASIGNAR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSNASIGNAR.CellContentClick
        prefolio020 = DGSNASIGNAR.Rows(e.RowIndex).Cells("Folio").Value
        codigo020 = DGSNASIGNAR.Rows(e.RowIndex).Cells("Codigo").Value
        Me.txtdescripcionSN.Text = DGSNASIGNAR.Rows(e.RowIndex).Cells("Descripcion").Value
        Me.TXTCANT.Text = DGSNASIGNAR.Rows(e.RowIndex).Cells("Cantidad").Value
        Me.TxtProveedor.Text = DGSNASIGNAR.Rows(e.RowIndex).Cells("Proveedor").Value
    End Sub

    Private Sub TxtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtID.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtID.Text = Nothing Then
                MsgBox("Error, favor de capturar el ID")
                Me.TxtID.SelectAll()
                Me.TxtID.Focus()
            Else
                If TraeID(Me.TxtID.Text) = 0 Then
                    MsgBox("ID no valido capturar uno valido")
                    Me.TxtID.SelectAll()
                    Me.TxtID.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub BTNBUSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSC.Click
        If Me.TxtID.Text = Nothing Then
            MsgBox("Error, favor de capturar el ID")
            Me.TxtID.SelectAll()
            Me.TxtID.Focus()
        Else
            If TraeID(Me.TxtID.Text) = 0 Then
                MsgBox("ID no valido capturar uno valido")
                Me.TxtID.SelectAll()
                Me.TxtID.Focus()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If codigo020 = Nothing And TxtID.Text = Nothing Or TxtID.Text = "" Then
            MsgBox("Revisar ID y seleccionar articulo en la tabla SIN ASIGNAR")
        Else
            Dim resp
            resp = MsgBox("Desea asignar el ID de PRESTASHOP " & Me.TxtID.Text & " al articulo " & Me.txtdescripcionSN.Text, MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                Dim Sqlasigna As New SqlCommand("UPDATE TSALRES2 SET ID_Nuevo = '" & Trim(TxtID.Text) & "' where codigo = '" & codigo020 & "' and folio = '" & prefolio020 & "'", SqlCnn)
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
                codigo020 = Nothing
                prefolio020 = Nothing
                TxtID.Text = Nothing
                TXTDESCRIPCION.Text = Nothing
                txtdescripcionSN.Text = Nothing
                TXTCANT.Text = Nothing
                TxtCosto.Text = Nothing
            End If
        End If
        CargaGridped()
        CargaGridped2()
    End Sub

    Private Sub DGASIGNADO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGASIGNADO.CellContentClick
        prefolio021 = DGASIGNADO.Rows(e.RowIndex).Cells("Folio").Value
        codigo021 = DGASIGNADO.Rows(e.RowIndex).Cells("Codigo").Value
        descripcion021 = DGASIGNADO.Rows(e.RowIndex).Cells("Descripcion").Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If codigo021 = Nothing And prefolio021 = Nothing Then
            MsgBox("Seleccionar el articulo en la tabla de ASIGNADOS")
        Else
            Dim resp
            resp = MsgBox("Desea des-asignar el ID de PRESTASHOP al articulo " & descripcion021, MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                Dim Sqlasigna As New SqlCommand("UPDATE TSALRES2 SET ID_Nuevo = '0' where codigo = '" & codigo021 & "' and folio = '" & prefolio021 & "'", SqlCnn)
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
                codigo021 = Nothing
                prefolio021 = Nothing
                descripcion021 = Nothing
            End If
        End If
        CargaGridped()
        CargaGridped2()
    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        Dim resp
        resp = MsgBox("Desea Guardar los articulos que se encuentran ASIGNADOS", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If Me.CBALM.Text = Nothing Or Me.TxtFact.Text = Nothing Then
                MsgBox("Favor de seleccionar el almacen o ingresar la Factura/Nota de la mercancia")
                If Me.CBALM.Text = Nothing Then
                    Me.CBALM.Focus()
                End If
                If Me.TxtFact.Text = Nothing Then
                    Me.TxtFact.Focus()
                End If
            Else
                Dim CODENUV, numerico, almacen, folio, facnot As String
                Dim li3, li2, li4 As Integer
                folio = Me.TxtFolio.Text
                If Chkfact.Checked = True Then
                    facnot = "FAC"
                Else
                    facnot = "NOT"
                End If
                numerico = SELECCIONA("ENT")
                li3 = numerico.Length
                li2 = 4
                If li3 < 4 Then
                    li2 = li2 - li3
                    For li4 = 0 To li2
                        numerico = "0" & numerico
                    Next li4
                End If
                Dim fechaI As String = FECHASURT.Text
                almacen = Trim(CBALM.Text)
                CODENUV = "ENT" & Format(DateTime.Now, "yy") & Format(DateTime.Now, "MM") & "N" & numerico
                Dim SqlInsEntCompra As New SqlCommand
                CmdStr1 = "DECLARE @Codigo	nchar(30),@Proveedor nchar(30),@fecha nchar(30),@barcode nchar(30),@Cantidad decimal(12,2),@var decimal(12,2),@var2 decimal(12,2),@var3 decimal(12,2),@Costo decimal(12,2),@Tot decimal(20,2),@exis decimal(12,2),@sum decimal(12,2),@compA decimal(12,2),@compB decimal(12,2),@a Varchar(2), "
                CmdStr1 = CmdStr1 & "@b varchar(2),@c varchar(2),@d varchar(2),@e varchar(2),@f varchar(2),@numlote varchar(12),@Caduce	NCHAR(20) "
                CmdStr1 = CmdStr1 & "set @a = (select substring(CONVERT(varchar,GETDATE(),4),1,2)) "
                CmdStr1 = CmdStr1 & "set @b = (select substring(CONVERT(varchar,GETDATE(),4),4,2)) "
                CmdStr1 = CmdStr1 & "set @c = (select substring(CONVERT(varchar,GETDATE(),4),7,2)) "
                CmdStr1 = CmdStr1 & "set @d = (select substring(CONVERT(varchar,GETDATE(),8),1,2)) "
                CmdStr1 = CmdStr1 & "set @e = (select substring(CONVERT(varchar,GETDATE(),8),4,2)) "
                CmdStr1 = CmdStr1 & "set @f = (select substring(CONVERT(varchar,GETDATE(),8),7,2)) "
                CmdStr1 = CmdStr1 & "SET @numlote = @c+@b+@a+@d+@e+@f "
                CmdStr1 = CmdStr1 & "SET NOCOUNT ON; "
                CmdStr1 = CmdStr1 & "DECLARE CDetEnt "
                CmdStr1 = CmdStr1 & "CURSOR FOR SELECT ID_Nuevo,Cantidad,Costo,Proveedor,Fecha,Barcode FROM TSALRES2 WHERE ID_Nuevo <> '0'  "
                CmdStr1 = CmdStr1 & "OPEN CDetEnt "
                CmdStr1 = CmdStr1 & "FETCH NEXT FROM CDetEnt INTO @Codigo,@Cantidad,@Costo,@Proveedor,@Fecha,@Barcode "
                CmdStr1 = CmdStr1 & "WHILE @@FETCH_STATUS = 0 "
                CmdStr1 = CmdStr1 & " BEGIN "
                CmdStr1 = CmdStr1 & "  SET @Tot = (@Cantidad * @Costo) "
                CmdStr1 = CmdStr1 & "  INSERT INTO Movimientos2 VALUES('" & folio & "',@Codigo,'ENT','SINID',@Cantidad,@Costo,@numlote,'" & facnot & "','" & Trim(TxtFact.Text) & "','" & Trim(TxtProveedor.Text) & "','" & almacen & "','" & fechaI & "','" & fechaI & "',@Tot,@Caduce) "
                CmdStr1 = CmdStr1 & "  SET @exis = 0 "
                CmdStr1 = CmdStr1 & "  IF EXISTS (SELECT * FROM ALMACEN WHERE [Codigo de producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "   BEGIN "
                CmdStr1 = CmdStr1 & "    SET @var =(SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "    set @exis = (SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de Producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "    SET @var2 = @var + @cantidad "
                CmdStr1 = CmdStr1 & "    UPDATE ALMACEN SET CANT_ALM = @var2, COSTO_ALM = @Costo WHERE [Codigo de Producto] = @Codigo AND ALMACEN = '" & almacen & "' "
                CmdStr1 = CmdStr1 & "    SET @sum = (SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de Producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "   END "
                CmdStr1 = CmdStr1 & "  ELSE "
                CmdStr1 = CmdStr1 & "   BEGIN "
                CmdStr1 = CmdStr1 & "    INSERT INTO ALMACEN VALUES('" & almacen & "',@Codigo,@Cantidad,@Costo,'SINID','" & fechaI & "') "
                CmdStr1 = CmdStr1 & "    SET @sum = @Cantidad "
                CmdStr1 = CmdStr1 & "   END "
                CmdStr1 = CmdStr1 & "  IF EXISTS (SELECT * FROM productos WHERE [Codigo de producto] = @Codigo) "
                CmdStr1 = CmdStr1 & "   BEGIN "
                CmdStr1 = CmdStr1 & "    UPDATE productos SET Existencia = @sum WHERE [Codigo de Producto] = @Codigo "
                CmdStr1 = CmdStr1 & "    INSERT INTO LOTEEX2 VALUES('" & almacen & "',@numlote,@Codigo,@Cantidad,@Costo,'" & Trim(TxtProveedor.Text) & "','" & fechaI & "','SINID','" & CODENUV & "') "
                CmdStr1 = CmdStr1 & "   END "
                CmdStr1 = CmdStr1 & "  INSERT INTO LOGS2 (Log_alm,Log_codigo,Log_tipmov,Log_Fecha,Log_usu,Log_Cant,Log_costo,Log_folio,Log_exis,Log_suma) "
                CmdStr1 = CmdStr1 & "  VALUES ('" & almacen & "',@Codigo,'ENTRADA','" & fechaI & "','SINID', @Cantidad, @Costo,'" & folio & "', @exis,@sum) "
                CmdStr1 = CmdStr1 & "  IF EXISTS (SELECT * FROM productos Where [Codigo de producto] = @Codigo AND [Se maneja por lotes] = '1') "
                CmdStr1 = CmdStr1 & "   BEGIN "
                CmdStr1 = CmdStr1 & "    SET @Tot = (@Cantidad * @Costo) "
                CmdStr1 = CmdStr1 & "    INSERT INTO Movimientos2 VALUES('" & folio & "',@Codigo,'SAL','SINID',@Cantidad,@Costo,@numlote,'" & facnot & "','" & Trim(TxtFact.Text) & "','" & almacen & "','" & almacen & "','" & fechaI & "','" & fechaI & "',@Tot,@Caduce) "
                CmdStr1 = CmdStr1 & "    IF EXISTS (SELECT * FROM ALMACEN WHERE [Codigo de producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "     BEGIN "
                CmdStr1 = CmdStr1 & "      SET @var =(SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "      SET @exis = (SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de Producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "      SET @var2 = @var - @cantidad "
                CmdStr1 = CmdStr1 & "      UPDATE ALMACEN SET CANT_ALM = @var2, COSTO_ALM = @Costo WHERE [Codigo de Producto] = @Codigo AND ALMACEN = '" & almacen & "' "
                CmdStr1 = CmdStr1 & "      SET @sum = (SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de Producto] = @Codigo AND ALMACEN = '" & almacen & "') "
                CmdStr1 = CmdStr1 & "     END "
                CmdStr1 = CmdStr1 & "    IF EXISTS (SELECT * FROM productos WHERE [Codigo de producto] = @Codigo) "
                CmdStr1 = CmdStr1 & "     BEGIN "
                CmdStr1 = CmdStr1 & "      INSERT INTO LOGLOTE2 VALUES ('" & almacen & "',@numlote,@Codigo,@Cantidad,@Costo,'" & Trim(TxtProveedor.Text) & "','" & fechaI & "','SINID') "
                CmdStr1 = CmdStr1 & "      DELETE FROM LOTEEX2 WHERE [Codigo de Producto] = @Codigo and numlote2 = @numlote and Almacen = '" & almacen & "' "
                CmdStr1 = CmdStr1 & "     END "
                CmdStr1 = CmdStr1 & "    INSERT INTO LOGS2 (Log_alm,Log_codigo,Log_tipmov,Log_Fecha,Log_usu,Log_Cant,Log_costo,Log_folio,Log_exis,Log_suma) "
                CmdStr1 = CmdStr1 & "    VALUES ('" & almacen & "',@Codigo,'SALIDA','" & fechaI & "','SINID', @Cantidad, @Costo,'" & folio & "', @exis,@sum) "
                CmdStr1 = CmdStr1 & "   END "
                CmdStr1 = CmdStr1 & "   IF NOT EXISTS(SELECT * FROM MULTIBARCODE WHERE MBarcode = @barcode) BEGIN INSERT INTO MULTIBARCODE (MBarcode, [Codigo de producto], MFecha, MUser, MEmpaque, MUnidades,MIMG) VALUES(@barcode,@Codigo,@fecha,'SIN_ID','1','1','0') end "
                CmdStr1 = CmdStr1 & " FETCH NEXT FROM CDetEnt INTO @Codigo,@Cantidad,@Costo,@Proveedor,@Fecha, @Barcode "
                CmdStr1 = CmdStr1 & " END "
                CmdStr1 = CmdStr1 & "CLOSE CDetEnt "
                CmdStr1 = CmdStr1 & "DEALLOCATE CDetEnt "
                CmdStr1 = CmdStr1 & "DELETE FROM TSALRES2 WHERE ID_Nuevo <> 0 "
                CmdStr1 = CmdStr1 & "declare @print int SET @print = '1' "
                CmdStr1 = CmdStr1 & "IF @print = '1' "
                CmdStr1 = CmdStr1 & "BEGIN "
                CmdStr1 = CmdStr1 & "INSERT INTO PRINTS (PRTIPO,PRES,PRIMP,PRCODE,PRUSU,PRARCHI) "
                CmdStr1 = CmdStr1 & "VALUES ('C','ENT','True',@numlote,'SINID','" & Trim(Me.TxtCantEti.Text) & "') "
                CmdStr1 = CmdStr1 & "END "
                CmdStr1 = CmdStr1 & "UPDATE FOLIOS2 SET utilizado = 'NO' WHERE consecutivo = '" & folio & "' "
                CmdStr1 = CmdStr1 & " "
                'FrmEntradaCompra.TxtCodigo.Text = CmdStr1
                'MsgBox(CmdStr1)
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
                Me.CBALM.Text = Nothing
                Me.TxtFact.Text = Nothing
                Me.TxtProveedor.Text = Nothing
                Me.TxtFolio.Text = GeneraNuevoFolio()
                CargaGridped()
                CargaGridped2()
            End If

        End If
    End Sub
End Class