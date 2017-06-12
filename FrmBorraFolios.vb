Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Public Class FrmBorraFolios

    Private Sub FrmBorraFolios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Traealmacen()
        Traecliente()
        Traeprov()
        With cbdesc
            .Items.Add("SELECCIONAR MOTIVO DE BORRADO")
            .Items.Add("MOVIMIENTO REPETIDO")
            .Items.Add("PRODUCTOS EQUIVOCADOS")
            .Items.Add("ERROR EN CANTIDADES")
            .Items.Add("OTROS")
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
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
    Public Sub Traecliente()
        Dim SqlClientes As New SqlCommand("SELECT abreviatura FROM clientes ORDER BY abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.Cbcliente.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Traeprov()
        Dim SqlClientes As New SqlCommand("SELECT abreviatura FROM proveedores ORDER BY abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.Cbprovee.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Traelote()
        Dim SqlClientes As New SqlCommand("SELECT SUM(CANT_MOV) FROM Movimientos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND LOTE_MOV = '" & Me.Lblote.Text & "' AND TIPO_MOV <> 'ENT' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) Then
                    Me.Lbpermiso.Text = "0.00"
                Else
                    Me.Lbpermiso.Text = SqlRead.GetDecimal(0)
                End If

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbalm.SelectedIndexChanged
        Traedescalmacen()
        'Me.Cbalm.Enabled = False
        Me.TxtFolio.Focus()
    End Sub

    Public Sub Traedescalmacen()
        Dim SqlClientes As New SqlCommand("SELECT nombre FROM almacenes WHERE abreviatura = '" & Me.Cbalm.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.lbalm.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        If Me.Cbalm.Text = "A. CENTRAL" Then
            buscafolio1()
        Else
            buscafolio2()
        End If
    End Sub
    Public Sub buscafolio1()

        Dim DS As New DataTable
        Try
            Dim F1 As String
            F1 = Me.TxtFolio.Text
            Dim SqlSel1 As New SqlDataAdapter("SELECT a.TIPO_MOV, b.alterno, b.Descripcion, a.CANT_MOV, a.COSTO_MOV, a.TOT_MOV, a.USU_MOV, a.FACNOT_MOV, a.PROV_MOV, a.CLIEN_MOV, a.FECHA_MOV, a.LOTE_MOV, a.FAC_MOV FROM movimientos a, productos b WHERE a.[Codigo de producto] = b.[Codigo de producto] AND a.ID_MOVIMIENTO = '" & F1 & "'", SqlCnn)
            SqlSel1.Fill(DS)
            Me.DataGridView1.DataSource = DS

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub buscafolio2()

        Dim DS As New DataTable
        Try
            Dim F1 As String
            F1 = Me.TxtFolio.Text
            Dim SqlSel1 As New SqlDataAdapter("SELECT a.TIPO_MOV2, b.alterno, b.Descripcion, a.CANT_MOV2, a.COSTO_MOV2, a.TOT_MOV2, a.USU_MOV2, a.FACNOT_MOV2, a.PROV_MOV2, a.CLIEN_MOV2, a.FECHA_MOV2 FROM movimientos2 a, productos b WHERE a.[Codigo de producto] = b.[Codigo de producto] AND a.ID_MOV2 = '" & F1 & "'", SqlCnn)
            SqlSel1.Fill(DS)
            Me.DataGridView1.DataSource = DS

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub Txtfolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtFolio.Text = Nothing Then
                MsgBox("Error, favor de capturar el folio")
                Me.TxtFolio.Focus()
            Else
                If Me.Cbalm.Text = "A. CENTRAL" Then
                    buscafolio1()
                Else
                    buscafolio2()
                End If

            End If
        End If
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        Dim resp
        resp = MsgBox("Esta accion eliminara los Movimientos efectuados previamente, ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If Me.Cbalm.Text = "A. CENTRAL" Then
                If Me.TxtFolio.Text = Nothing Then
                    MsgBox("Favor de capturar numero de folio")
                Else
                    If Me.Txtdesc.Text = "SELECCIONAR MOTIVO DE BORRADO" Or Me.Txtdesc.Text = Nothing Then
                        MsgBox("Favor de capturar el motivo por el cual se eliminara este folio")
                    Else
                        borrafol(Me.TxtFolio.Text)
                        borrarmov()
                        MsgBox("Folio " & Me.TxtFolio.Text & " Borrado")
                        buscafolio1()
                        Me.Txtdesc.Text = Nothing
                        Me.TxtFolio.Focus()

                    End If
                    
                End If
            Else
                If Me.TxtFolio.Text = Nothing Then
                    MsgBox("Favor de capturar numero de folio")
                Else
                    If Me.Txtdesc.Text = "SELECCIONAR MOTIVO DE BORRADO" Or Me.Txtdesc.Text = Nothing Then
                        MsgBox("Favor de capturar el motivo por el cual se eliminara este folio")
                    Else
                        borrafol2(Me.TxtFolio.Text)
                        borrarmov2()
                        MsgBox("Folio " & Me.TxtFolio.Text & " Borrado")
                        buscafolio2()
                        Me.Txtdesc.Text = Nothing
                        Me.TxtFolio.Focus()

                    End If

                End If
                'borrafol2(Me.TxtFolio.Text)
            End If

            End If
    End Sub
    Private Function borrafol(ByVal folio) As Integer
        Dim SqlFolio As New SqlCommand("DELETE FROM Consecutivo WHERE Consecutivo = '" & folio & "' ", SqlCnn)
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
    Private Function borrafol2(ByVal folio) As Integer
        Dim SqlFolio As New SqlCommand("DELETE FROM FOLIOS2 WHERE Consecutivo = '" & folio & "' ", SqlCnn)
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
    Private Function borrarmov()
        Dim SqlTempborr As New SqlCommand

        CmdStr1 = "exec spInsBorrado "
        CmdStr1 = CmdStr1 & "'" & Me.Cbalm.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.TxtFolio.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.DT1.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & MDIPrincipal.StbUSER.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.Txtdesc.Text & "'"

        Try
            With SqlTempborr
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            SqlTempborr.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Private Function borrarmov2()
        Dim SqlTempborr As New SqlCommand

        CmdStr1 = "exec spInsBorrado2 "
        CmdStr1 = CmdStr1 & "'" & Me.Cbalm.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.TxtFolio.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.DT1.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & MDIPrincipal.StbUSER.Text & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Me.Txtdesc.Text & "'"

        Try
            With SqlTempborr
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            SqlTempborr.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo")
                Me.TxtCodigo.Focus()
            Else
                'Me.LblDescripcion.Text = TraeDescripcion(Me.TxtCodigo.Text)
                'Me.TxtCodigo.Text = Traecodigo(Me.TxtCodigo.Text)
                'If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                '    MsgBox("Error, codigo no valido")
                '    Me.TxtCodigo.Focus()
                '    Me.TxtCodigo.SelectAll()
                'Else
                '    Traeprecio1()
                'End If
            End If
        End If
    End Sub
    Private Sub cbdesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdesc.SelectedIndexChanged
        If Me.cbdesc.Text = "OTROS" Then
            Me.Txtdesc.Enabled = True
            Me.Txtdesc.Text = Nothing
            Me.Txtdesc.Focus()
        Else
            Me.Txtdesc.Text = Me.cbdesc.Text
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex > -1 Then
            Dim tipo As String
            Dim code As String
            Dim desc As String
            Dim prev As String
            Dim costo As String
            Dim usu As String
            Dim fac As String
            Dim prov As String
            Dim clien As String
            Dim fecha As String
            Dim lote As String
            Dim facnot As String

            Dim value0 As Object = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            Dim value1 As Object = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Dim value2 As Object = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            Dim value3 As Object = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            Dim value4 As Object = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            'Dim value5 As Object = DataGridView1.Rows(e.RowIndex).Cells(6).Value
            'Dim value6 As Object = DataGridView1.Rows(e.RowIndex).Cells(7).Value
            'Dim value7 As Object = DataGridView1.Rows(e.RowIndex).Cells(8).Value
            'Dim value8 As Object = DataGridView1.Rows(e.RowIndex).Cells(9).Value
            'Dim value9 As Object = DataGridView1.Rows(e.RowIndex).Cells(10).Value
            'Dim value10 As Object = DataGridView1.Rows(e.RowIndex).Cells(11).Value
            'Dim value11 As Object = DataGridView1.Rows(e.RowIndex).Cells(12).Value
            Dim value5 As Object = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            Dim value6 As Object = DataGridView1.Rows(e.RowIndex).Cells(6).Value
            Dim value7 As Object = DataGridView1.Rows(e.RowIndex).Cells(7).Value
            Dim value8 As Object = DataGridView1.Rows(e.RowIndex).Cells(8).Value
            Dim value9 As Object = DataGridView1.Rows(e.RowIndex).Cells(9).Value
            Dim value10 As Object = DataGridView1.Rows(e.RowIndex).Cells(10).Value
            'Dim value11 As Object = DataGridView1.Rows(e.RowIndex).Cells(11).Value


            If value0.GetType Is GetType(DBNull) Then Return

            tipo = CType(value0, String)
            code = CType(value1, String)
            desc = CType(value2, String)
            prev = CType(value3, String)
            costo = CType(value4, String)
            usu = CType(value5, String)
            fac = CType(value6, String)
            prov = CType(value7, String)
            clien = CType(value8, String)
            fecha = CType(value9, String)
            lote = CType(value10, String)
            'facnot = CType(value11, String)

            Me.Lbtipo.Text = tipo
            Me.TxtCodigo.Text = Traecodigo(code)
            ObtieneDescExi()
            'Me.TxtCodigo.Text = code
            Me.LblDescripcion.Text = desc
            Me.TxtCantidad.Text = prev
            Me.TxtCosto.Text = costo
            Me.Txtncosto.Text = costo
            Me.Lbusu.Text = usu
            Me.lbfac.Text = fac
            Me.Txtfac.Text = fac
            Me.Lbprov.Text = prov
            Me.Cbprovee.SelectedItem = prov
            Me.Lbcliente.Text = clien
            Me.Cbcliente.SelectedItem = RTrim(clien)
            Me.Lbfecha.Text = fecha
            Me.DT1.Value = lote
            Me.Lblote.Text = lote
            Traelote()
            If RTrim(facnot) = RTrim("fac") Then
                Me.RadioButton1.Checked = True
            Else
                Me.RadioButton2.Checked = True
            End If
        End If
    End Sub
    Private Function Traecodigo(ByVal codigo) As String

        Dim SqlSelDes As New SqlCommand("SELECT [Codigo de Producto] FROM productos WHERE [Codigo de Producto] = '" & codigo & "' OR alterno = " & codigo & " ", SqlCnn)
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
    Public Sub Traeprecio1()


        Dim Sqlprecio1 As New SqlCommand("SELECT [Precio de venta] FROM productos WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio1.ExecuteReader
            While SqlRead.Read
                Me.TxtCosto.Text = SqlRead.GetDecimal(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Traeprecio2()


        Dim Sqlprecio1 As New SqlCommand("SELECT COSTO_ALM FROM ALMACEN WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' AND ALMACEN = '" & Me.Cbalm.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio1.ExecuteReader
            While SqlRead.Read
                Me.TxtCosto.Text = SqlRead.GetDecimal(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Dim cantnew As Decimal
        Dim cantidad As Decimal
        Dim exist As Decimal
        Dim valor As Decimal


        Dim resp
        resp = MsgBox("Esta accion actualizara el movimiento del producto " & Me.TxtCodigo.Text & ", ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If Me.Cbalm.Text = "A. CENTRAL" Then
                If Me.TxtFolio.Text = Nothing Then
                    MsgBox("Favor de capturar numero de folio")
                Else
                    If Me.Txtdesc.Text = "SELECCIONAR MOTIVO DE BORRADO" Or Me.Txtdesc.Text = Nothing Then
                        MsgBox("Favor de capturar el motivo por el cual se actualizara este producto del folio " & Me.TxtFolio.Text)

                    Else
                        If Me.Lbtipo.Text = Nothing Or Me.Lbtipo.Text = "." Then
                            MsgBox("favor de seleccionar el producto que se va a modificar")
                        Else
                            cantnew = Me.Txtncant.Text
                            cantidad = Me.TxtCantidad.Text
                            exist = Me.lbexistencia.Text
                            valor = cantnew - cantidad

                            'If Me.Lbtipo.Text = "ENT" Then
                            '    If valor < exist Then
                            '        MsgBox("El producto no tiene suficiente existencia para poder modificarlo favor de revisar sus existencias")
                            '    Else
                            '        borraproducto()
                            '        MsgBox("El producto " & Me.TxtCodigo.Text & " a sido actualizado")
                            '        buscafolio1()
                            '        Me.TxtCodigo.Text = Nothing
                            '        Me.Lbtipo.Text = Nothing
                            '        Me.LblDescripcion.Text = Nothing
                            '        Me.TxtCosto.Text = Nothing
                            '        Me.TxtCantidad.Text = Nothing
                            '        Me.Txtdesc.Text = Nothing
                            '        Me.Lbusu.Text = Nothing
                            '        Me.lbfac.Text = Nothing
                            '        Me.Lbprov.Text = Nothing
                            '        Me.Lbcliente.Text = Nothing
                            '        Me.Lbfecha.Text = Nothing
                            '        Me.Txtncant.Text = "0.00"
                            '        Me.Txtncosto.Text = "0.00"
                            '        Me.TxtFolio.Focus()
                            '    End If
                            'Else
                            'borraproducto()
                            'insertaproducto()
                            actualiza()
                            MsgBox("El producto " & Me.TxtCodigo.Text & " a sido actualizado")
                            buscafolio1()
                            Me.TxtCodigo.Text = Nothing
                            Me.Lbtipo.Text = Nothing
                            Me.LblDescripcion.Text = Nothing
                            Me.TxtCosto.Text = Nothing
                            Me.TxtCantidad.Text = Nothing
                            Me.Txtdesc.Text = Nothing
                            Me.Lbusu.Text = Nothing
                            Me.lbfac.Text = Nothing
                            Me.Lbprov.Text = Nothing
                            Me.Lbcliente.Text = Nothing
                            Me.Lbfecha.Text = Nothing
                            Me.Cbcliente.Text = Nothing
                            Me.Cbprovee.Text = Nothing
                            Me.Txtfac.Text = Nothing
                            Me.Txtncant.Text = "0.00"
                            Me.Txtncosto.Text = "0.00"
                            Me.TxtFolio.Focus()

                            'End If

                        End If

                    End If
                End If
            Else

                MsgBox("LA FUNCION DE ACTUALIZAR NO ESTA DISPONIBLE PARA ESTE ALMACEN, FAVOR DE ELIMINAR EL MOVIMIENTO Y VOLVERLO A CAPTURAR")

                'borrafol2(Me.TxtFolio.Text)
            End If

        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim cantnew As Decimal
        Dim cantidad As Decimal
        Dim exist As Decimal
        Dim valor As Decimal
        Dim exislote As Decimal

        Dim resp
        resp = MsgBox("Esta accion eliminara el movimiento del producto " & Me.TxtCodigo.Text & ", ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If Me.Cbalm.Text = "A. CENTRAL" Then
                If Me.TxtFolio.Text = Nothing Then
                    MsgBox("Favor de capturar numero de folio")
                Else
                    If Me.Txtdesc.Text = "SELECCIONAR MOTIVO DE BORRADO" Or Me.Txtdesc.Text = Nothing Then
                        MsgBox("Favor de capturar el motivo por el cual se eliminara este producto del folio " & Me.TxtFolio.Text)

                    Else
                        If Me.Lbtipo.Text = Nothing Or Me.Lbtipo.Text = "." Then
                            MsgBox("favor de seleccionar el producto que se va a eliminar")
                        Else
                            cantnew = Me.Txtncant.Text
                            cantidad = Me.TxtCantidad.Text
                            exist = Me.lbexistencia.Text
                            valor = cantnew - cantidad
                            exislote = Me.Lbpermiso.Text
                            If Me.Lbtipo.Text = "ENT" Then
                                If valor < exist Then
                                    MsgBox("El producto no tiene suficiente existencia para poder borrarlo favor de revisar sus existencias")
                                Else
                                    If exislote > 0 Then
                                        MsgBox("El producto tiene salidas de este lote borre primero los lotes antes de borrar el producto")

                                    Else
                                        borraproducto()
                                        MsgBox("El producto " & Me.TxtCodigo.Text & " a sido borrado")
                                        buscafolio1()
                                        Me.TxtCodigo.Text = Nothing
                                        Me.Lbtipo.Text = Nothing
                                        Me.LblDescripcion.Text = Nothing
                                        Me.TxtCosto.Text = Nothing
                                        Me.TxtCantidad.Text = Nothing
                                        Me.Txtdesc.Text = Nothing
                                        Me.Lbusu.Text = Nothing
                                        Me.lbfac.Text = Nothing
                                        Me.Lbprov.Text = Nothing
                                        Me.Lbcliente.Text = Nothing
                                        Me.Lbfecha.Text = Nothing
                                        Me.TxtFolio.Focus()
                                    End If
                                End If
                            Else
                                borraproducto()
                                MsgBox("El producto " & Me.TxtCodigo.Text & " a sido borrado")
                                buscafolio1()
                                Me.TxtCodigo.Text = Nothing
                                Me.Lbtipo.Text = Nothing
                                Me.LblDescripcion.Text = Nothing
                                Me.TxtCosto.Text = Nothing
                                Me.TxtCantidad.Text = Nothing
                                Me.Txtdesc.Text = Nothing
                                Me.Lbusu.Text = Nothing
                                Me.lbfac.Text = Nothing
                                Me.Lbprov.Text = Nothing
                                Me.Lbcliente.Text = Nothing
                                Me.Lbfecha.Text = Nothing
                                Me.TxtFolio.Focus()

                            End If
                            
                        End If
                        
                    End If
                End If
            Else
                If Me.TxtFolio.Text = Nothing Then
                    MsgBox("Favor de capturar numero de folio")
                Else
                    If Me.Txtdesc.Text = "SELECCIONAR MOTIVO DE BORRADO" Or Me.Txtdesc.Text = Nothing Then
                        MsgBox("Favor de capturar el motivo por el cual se eliminara este producto del folio " & Me.TxtFolio.Text)

                    Else
                        If Me.Lbtipo.Text = Nothing Or Me.Lbtipo.Text = "." Then
                            MsgBox("favor de seleccionar el producto que se va a eliminar")
                        Else
                            cantnew = Me.Txtncant.Text
                            cantidad = Me.TxtCantidad.Text
                            exist = Me.lbexistencia.Text
                            valor = cantnew - cantidad
                            If Me.Lbtipo.Text = "ENT" Then
                                If valor < exist Then
                                    MsgBox("El producto no tiene suficiente existencia para poder borrarlo favor de revisar sus existencias")
                                Else
                                    borraproducto2()
                                    MsgBox("El producto " & Me.TxtCodigo.Text & " a sido borrado")
                                    buscafolio2()
                                    Me.TxtCodigo.Text = Nothing
                                    Me.Lbtipo.Text = Nothing
                                    Me.LblDescripcion.Text = Nothing
                                    Me.TxtCosto.Text = Nothing
                                    Me.TxtCantidad.Text = Nothing
                                    Me.Txtdesc.Text = Nothing
                                    Me.Lbusu.Text = Nothing
                                    Me.lbfac.Text = Nothing
                                    Me.Lbprov.Text = Nothing
                                    Me.Lbcliente.Text = Nothing
                                    Me.Lbfecha.Text = Nothing
                                    Me.TxtFolio.Focus()
                                End If
                            Else
                                borraproducto2()
                                MsgBox("El producto " & Me.TxtCodigo.Text & " a sido borrado")
                                buscafolio2()
                                Me.TxtCodigo.Text = Nothing
                                Me.Lbtipo.Text = Nothing
                                Me.LblDescripcion.Text = Nothing
                                Me.TxtCosto.Text = Nothing
                                Me.TxtCantidad.Text = Nothing
                                Me.Txtdesc.Text = Nothing
                                Me.Lbusu.Text = Nothing
                                Me.lbfac.Text = Nothing
                                Me.Lbprov.Text = Nothing
                                Me.Lbcliente.Text = Nothing
                                Me.Lbfecha.Text = Nothing
                                Me.TxtFolio.Focus()

                            End If

                        End If

                    End If
                End If

            End If

        End If
    End Sub
    Private Function borraproducto()


        Dim Sqltempsal As New SqlCommand("DECLARE @var1 decimal(20,2) " & _
        "DECLARE @var2 decimal(20,2) " & _
        "DECLARE @var3 decimal(20,2) " & _
        "DECLARE @var4 decimal(20,2) " & _
        "DECLARE @LOTEVA nchar(20) " & _
        "DECLARE @mov nchar(20) " & _
        "SET @mov = '" & Me.Lbtipo.Text & "' " & _
        "DECLARE @cant decimal(20,2) " & _
        "SET @cant = '" & Me.TxtCantidad.Text & "' " & _
        "SET @var4 = @cant " & _
        "SET @LOTEVA = '" & Me.Lblote.Text & "' " & _
        "IF EXISTS (SELECT * FROM LOTEEX1 WHERE NUMLOTE = @LOTEVA AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "SET @var3 = (SELECT Cantidad FROM LOTEEX1 WHERE NUMLOTE = @LOTEVA AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "END " & _
        "INSERT INTO LOGDEL VALUES('" & Me.Cbalm.Text & "','" & Me.TxtFolio.Text & "','" & Me.TxtCodigo.Text & "','" & Me.Lbtipo.Text & "','" & Me.Lbusu.Text & "','" & Me.TxtCantidad.Text & "','" & Me.TxtCosto.Text & "','" & Me.lbfac.Text & "','" & Me.Lbprov.Text & "','" & Me.Lbcliente.Text & "','" & Me.Lbfecha.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.DT1.Text & "','" & Me.Txtdesc.Text & "') " & _
        "IF EXISTS (SELECT * FROM Existencias WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "SET @var1 =(SELECT Existencia FROM Existencias WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "IF @mov = 'ENT' " & _
        "BEGIN " & _
        "DELETE FROM LOTEEX1 WHERE NUMLOTE = @LOTEVA AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "' " & _
        "SET @var2 = @var1 - @cant " & _
        "END " & _
        "IF @mov = 'SAL' " & _
        "BEGIN " & _
        "IF EXISTS (SELECT * FROM LOTEEX1 WHERE NUMLOTE = @LOTEVA AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE LOTEEX1 SET Cantidad = @var3 + @var4 WHERE NUMLOTE = @LOTEVA AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "' " & _
        "END " & _
        "ELSE " & _
        "BEGIN " & _
        "INSERT INTO LOTEEX1 VALUES (@LOTEVA,'" & Me.TxtCodigo.Text & "',@cant,'" & Me.TxtCosto.Text & "','ALMACEN','" & Me.DT1.Text & "','" & MDIPrincipal.StbUSER.Text & "') " & _
        "END " & _
        "SET @var2 = @var1 + @cant " & _
        "END " & _
        "IF @mov = 'SAL-TRAS' " & _
        "BEGIN " & _
        "IF EXISTS (SELECT * FROM LOTEEX1 WHERE NUMLOTE = @LOTEVA AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE LOTEEX1 SET Cantidad = @var3 + @var4 WHERE NUMLOTE = @LOTEVA AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "' " & _
        "END " & _
        "ELSE " & _
        "BEGIN " & _
        "INSERT INTO LOTEEX1 VALUES (@LOTEVA,'" & Me.TxtCodigo.Text & "',@cant,'" & Me.TxtCosto.Text & "','ALMACEN','" & Me.DT1.Text & "','" & MDIPrincipal.StbUSER.Text & "') " & _
        "END " & _
        "SET @var2 = @var1 + @cant " & _
        "END " & _
        "UPDATE Existencias SET Existencia = @var2 WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' " & _
        "END " & _
        "IF EXISTS (SELECT * FROM productos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE productos SET Existencia = @var2 WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' " & _
        "END " & _
        "INSERT INTO LOGS VALUES ('" & Me.TxtCodigo.Text & "','Borrado','" & Me.DT1.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.TxtCantidad.Text & "','" & Me.TxtCosto.Text & "','" & Me.TxtFolio.Text & "',@var1,@var2) " & _
        "DELETE FROM Movimientos WHERE ID_MOVIMIENTO = '" & Me.TxtFolio.Text & "' AND [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' and LOTE_MOV = @LOTEVA ", SqlCnn)

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
    Private Function actualiza()


        Dim Sqltempsal As New SqlCommand("DECLARE @ncosto decimal(20,2) " & _
        "DECLARE @total decimal(20,2) " & _
        "DECLARE @cant decimal(20,2) " & _
        "DECLARE @LOTEVA nchar(20) " & _
        "SET @cant = '" & Me.TxtCantidad.Text & "' " & _
        "SET @ncosto = '" & Me.Txtncosto.Text & "' " & _
        "SET @LOTEVA = '" & Me.Lblote.Text & "' " & _
        "SET @total = @cant * @ncosto " & _
        "INSERT INTO LOGDEL VALUES('" & Me.Cbalm.Text & "','" & Me.TxtFolio.Text & "','" & Me.TxtCodigo.Text & "','" & Me.Lbtipo.Text & "','" & Me.Lbusu.Text & "','" & Me.TxtCantidad.Text & "','" & Me.TxtCosto.Text & "','" & Me.lbfac.Text & "','" & Me.Lbprov.Text & "','" & Me.Lbcliente.Text & "','" & Me.Lbfecha.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.DT1.Text & "','" & Me.Txtdesc.Text & "') " & _
        "IF EXISTS (SELECT * FROM productos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE Movimientos SET COSTO_MOV = @ncosto, TOT_MOV = @total WHERE ID_MOVIMIENTO = '" & Me.TxtFolio.Text & "' AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND LOTE_MOV = @LOTEVA " & _
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
    Private Function actualizafolio()


        Dim Sqltempsal As New SqlCommand("DECLARE @ncosto decimal(20,2) " & _
        "DECLARE @total decimal(20,2) " & _
        "DECLARE @cant decimal(20,2) " & _
        "DECLARE @LOTEVA nchar(20) " & _
        "SET @cant = '" & Me.TxtCantidad.Text & "' " & _
        "SET @ncosto = '" & Me.Txtncosto.Text & "' " & _
        "SET @LOTEVA = '" & Me.Lblote.Text & "' " & _
        "SET @total = @cant * @ncosto " & _
        "INSERT INTO LOGDEL VALUES('" & Me.Cbalm.Text & "','" & Me.TxtFolio.Text & "','" & Me.TxtCodigo.Text & "','" & Me.Lbtipo.Text & "','" & Me.Lbusu.Text & "','" & Me.TxtCantidad.Text & "','" & Me.TxtCosto.Text & "','" & Me.lbfac.Text & "','" & Me.Lbprov.Text & "','" & Me.Lbcliente.Text & "','" & Me.Lbfecha.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.DT1.Text & "','" & Me.Txtdesc.Text & "') " & _
        "IF EXISTS (SELECT * FROM productos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE Movimientos SET COSTO_MOV = @ncosto, TOT_MOV = @total WHERE ID_MOVIMIENTO = '" & Me.TxtFolio.Text & "' AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND LOTE_MOV = @LOTEVA " & _
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
    Private Function actualiza2()


        Dim Sqltempsal As New SqlCommand("DECLARE @ncosto decimal(20,2) " & _
        "DECLARE @total decimal(20,2) " & _
        "DECLARE @cant decimal(20,2) " & _
        "DECLARE @LOTEVA nchar(20) " & _
        "SET @cant = '" & Me.TxtCantidad.Text & "' " & _
        "SET @ncosto = '" & Me.Txtncosto.Text & "' " & _
        "SET @LOTEVA = '" & Me.Lblote.Text & "' " & _
        "SET @total = @cant * @ncosto " & _
        "INSERT INTO LOGDEL VALUES('" & Me.Cbalm.Text & "','" & Me.TxtFolio.Text & "','" & Me.TxtCodigo.Text & "','" & Me.Lbtipo.Text & "','" & Me.Lbusu.Text & "','" & Me.TxtCantidad.Text & "','" & Me.TxtCosto.Text & "','" & Me.lbfac.Text & "','" & Me.Lbprov.Text & "','" & Me.Lbcliente.Text & "','" & Me.Lbfecha.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.DT1.Text & "','" & Me.Txtdesc.Text & "') " & _
        "IF EXISTS (SELECT * FROM productos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE Movimientos SET COSTO_MOV = @ncosto, TOT_MOV = @total WHERE ID_MOVIMIENTO = '" & Me.TxtFolio.Text & "' AND [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND LOTE_MOV = @LOTEVA " & _
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
    Private Function borraproducto2()


        Dim Sqltempsal As New SqlCommand("DECLARE @var1 decimal(20,2) " & _
        "DECLARE @var2 decimal(20,2) " & _
        "DECLARE @mov nchar(20) " & _
        "SET @mov = '" & Me.Lbtipo.Text & "' " & _
        "DECLARE @cant decimal(20,2) " & _
        "SET @cant = '" & Me.TxtCantidad.Text & "' " & _
        "INSERT INTO LOGDEL VALUES('" & Me.Cbalm.Text & "','" & Me.TxtFolio.Text & "','" & Me.TxtCodigo.Text & "','" & Me.Lbtipo.Text & "','" & Me.Lbusu.Text & "','" & Me.TxtCantidad.Text & "','" & Me.TxtCosto.Text & "','" & Me.lbfac.Text & "','" & Me.Lbprov.Text & "','" & Me.Lbcliente.Text & "','" & Me.Lbfecha.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.DT1.Text & "','" & Me.Txtdesc.Text & "') " & _
        "IF EXISTS (SELECT * FROM ALMACEN WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND ALMACEN = '" & Me.Cbalm.Text & "') " & _
        "BEGIN " & _
        "SET @var1 =(SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' AND ALMACEN = '" & Me.Cbalm.Text & "') " & _
        "IF @mov = 'ENT' " & _
        "BEGIN " & _
        "SET @var2 = @var1 - @cant " & _
        "END " & _
        "IF @mov = 'SAL' " & _
        "BEGIN " & _
        "SET @var2 = @var1 + @cant " & _
        "END " & _
        "IF @mov = 'SAL-TRAS' " & _
        "BEGIN " & _
        "SET @var2 = @var1 + @cant " & _
        "END " & _
        "UPDATE ALMACEN SET CANT_ALM = @var2 WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' AND ALMACEN = '" & Me.Cbalm.Text & "' " & _
        "END " & _
        "INSERT INTO LOGS2 VALUES ('" & Me.Cbalm.Text & "','" & Me.TxtCodigo.Text & "','Borrado','" & Me.DT1.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.TxtCantidad.Text & "','" & Me.TxtCosto.Text & "','" & Me.TxtFolio.Text & "',@var1,@var2) " & _
        "DELETE FROM Movimientos2 WHERE ID_MOV2 = '" & Me.TxtFolio.Text & "' AND [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' ", SqlCnn)

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
    Private Function insertaproducto()

        Dim total As Decimal
        Dim cost As Decimal
        Dim cant As Decimal
        cost = Me.Txtncosto.Text
        cant = Me.Txtncant.Text
        total = cost * cant

        Dim Sqltempsal As New SqlCommand("DECLARE @var1 decimal(20,2) " & _
        "DECLARE @var2 decimal(20,2) " & _
        "DECLARE @mov nchar(20) " & _
        "SET @mov = '" & Me.Lbtipo.Text & "' " & _
        "DECLARE @cant decimal(20,2) " & _
        "SET @cant = '" & Me.Txtncant.Text & "' " & _
        "IF EXISTS (SELECT * FROM Existencias WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "SET @var1 =(SELECT Existencia FROM Existencias WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "IF @mov = 'ENT' " & _
        "BEGIN " & _
        "SET @var2 = @var1 + @cant " & _
        "END " & _
        "IF @mov = 'SAL' " & _
        "BEGIN " & _
        "SET @var2 = @var1 - @cant " & _
        "END " & _
        "IF @mov = 'SAL-TRAS' " & _
        "BEGIN " & _
        "SET @var2 = @var1 - @cant " & _
        "END " & _
        "UPDATE Existencias SET Existencia = @var2 WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' " & _
        "END " & _
        "IF EXISTS (SELECT * FROM productos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE productos SET Existencia = @var2 WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' " & _
        "END " & _
        "INSERT INTO Movimientos VALUES('" & Me.TxtFolio.Text & "','" & Me.TxtCodigo.Text & "','" & Me.Lbtipo.Text & "','" & Me.Lbusu.Text & "','" & Me.Txtncant.Text & "','" & Me.Txtncosto.Text & "','0','NA','" & Me.lbfac.Text & "','" & Me.Lbprov.Text & "','" & Me.Lbcliente.Text & "','" & Me.Lbfecha.Text & "','" & Me.DT1.Text & "','" & total & "') " & _
        "INSERT INTO LOGS VALUES ('" & Me.TxtCodigo.Text & "','Modific','" & Me.DT1.Text & "','" & MDIPrincipal.StbUSER.Text & "','" & Me.Txtncant.Text & "','" & Me.Txtncosto.Text & "','" & Me.TxtFolio.Text & "',@var1,@var2) ", SqlCnn)

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
    Public Sub ObtieneDescExi()
        Me.lbexistencia.Text = 0
        If Me.Cbalm.Text = "A. CENTRAL" Then
            Dim Sqlexis As New SqlCommand("SELECT Existencia FROM Existencias WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlexis.ExecuteReader
                While SqlRead.Read
                    Me.lbexistencia.Text = SqlRead.GetDecimal(0)
                End While
                SqlRead.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
        Else
            Dim Sqlexis As New SqlCommand("SELECT CANT_ALM FROM ALMACEN WHERE [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' AND ALMACEN = '" & Me.Cbalm.Text & "' ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlexis.ExecuteReader
                While SqlRead.Read
                    Me.lbexistencia.Text = SqlRead.GetDecimal(0)
                End While
                SqlRead.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click


        If Me.TxtFolio.Text = Nothing Then
            MsgBox("Favor de capturar el folio")
            Me.TxtFolio.Focus()
        Else
            Dim r As New rptsalidaNvo
            Dim cx As New CrystalDecisions.Shared.ConnectionInfo
            Dim t As CrystalDecisions.CrystalReports.Engine.Table
            Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
            Dim td As New CrystalDecisions.Shared.TableLogOnInfo

            Dim Archivo As New StreamReader("Config.txt")
            Dim Server, BD, User1, PWD1 As String
            Server = Archivo.ReadLine
            BD = Archivo.ReadLine
            User1 = Archivo.ReadLine
            PWD1 = Archivo.ReadLine

            With cx

                .ServerName = Server
                .DatabaseName = BD
                .UserID = User1
                .Password = PWD1

            End With
            ts = r.Database.Tables
            For Each t In ts
                td = t.LogOnInfo
                td.ConnectionInfo = cx
                t.ApplyLogOnInfo(td)
            Next
            r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & MDIPrincipal.stbempresa.Text & "'"
            'r.RecordSelectionFormula = "({Movimientos.ID_MOVIMIENTO} = '" & Me.TxtFolio.Text & "')"
            r.RecordSelectionFormula = "({Movimientos2.ID_MOV2} = '" & Me.TxtFolio.Text & "')"
            'r.RecordSelectionFormula = "({Movimientos.FECHA_MOV2} ='" & Me.DT1.Text & "')"
            CrystalReportViewer1.ReportSource = r
            'r.PrintToPrinter(1, True, 0, 0)
        End If
    End Sub

    Private Sub Lblote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lblote.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim resp
        resp = MsgBox("Esta accion actualizara datos generales del FOLIO " & Me.TxtCodigo.Text & ", ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If Me.Cbalm.Text = "A. CENTRAL" Then
                If Me.TxtFolio.Text = Nothing Then
                    MsgBox("Favor de capturar numero de folio")
                Else
                    If Me.Txtdesc.Text = "SELECCIONAR MOTIVO DE BORRADO" Or Me.Txtdesc.Text = Nothing Then
                        MsgBox("Favor de capturar el motivo por el cual se actualizara este folio " & Me.TxtFolio.Text)

                    Else
                        


                        actualiza()
                        MsgBox("El producto " & Me.TxtCodigo.Text & " a sido actualizado")
                        buscafolio1()
                        Me.TxtCodigo.Text = Nothing
                        Me.Lbtipo.Text = Nothing
                        Me.LblDescripcion.Text = Nothing
                        Me.TxtCosto.Text = Nothing
                        Me.TxtCantidad.Text = Nothing
                        Me.Txtdesc.Text = Nothing
                        Me.Lbusu.Text = Nothing
                        Me.lbfac.Text = Nothing
                        Me.Lbprov.Text = Nothing
                        Me.Lbcliente.Text = Nothing
                        Me.Lbfecha.Text = Nothing
                        Me.Cbcliente.Text = Nothing
                        Me.Cbprovee.Text = Nothing
                        Me.Txtfac.Text = Nothing
                        Me.Txtncant.Text = "0.00"
                        Me.Txtncosto.Text = "0.00"
                        Me.TxtFolio.Focus()


                    End If
                End If
        Else

            MsgBox("LA FUNCION DE ACTUALIZAR NO ESTA DISPONIBLE PARA ESTE ALMACEN, FAVOR DE ELIMINAR EL MOVIMIENTO Y VOLVERLO A CAPTURAR")

            'borrafol2(Me.TxtFolio.Text)
        End If

        End If

    End Sub
End Class