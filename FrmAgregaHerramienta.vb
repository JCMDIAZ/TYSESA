Imports System.Data
Imports System.Data.SqlClient


Public Class FrmAgregaHerramienta

    Private DTable As New DataTable
    Public Codigo, Desc, Ubicacion, Tipo, provee, Marca, peps, alterno, activo, AdquisicionFe, nombrecorto, Unidad, pcompra, pventa, cheiva, CHEIEPS, chebsk, presentacion, cantipresenta As New String(Nothing)
    Public CostoIni, UCosto, Existencia, minstk, maxcmp, ivavar, IEPSVAR, area, altura, offset As New Double
    Private CodPro As String
    Private Exis As Boolean
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

    Private Sub FrmAgregaHerramienta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pongamayus()
        Me.TxtFechaIngreso.Text = Now.Date
        Me.CmbTipo.DataSource = CargaTipos(Me)
        Me.CmbTipo.DisplayMember = "Abreviatura"
        Me.CmbTipo.ValueMember = "clave"
        Me.CmbTipo.SelectedIndex = 0
        Me.CmbTipo.Text = ""
        Me.CboUnidad.DataSource = CargaUM(Me)
        Me.CboUnidad.DisplayMember = "Abreviatura"
        Me.CboUnidad.ValueMember = "clave"
        Me.CboUnidad.SelectedIndex = 0
        Me.CboUnidad.Text = ""
        Cargaproveedores()
        DTable = CargaGridHerramientas()
        Me.DGPROD.DataSource = DTable
        Me.TxtCapacidad.Text = GENERALTERNO()
        Exis = False
        UsuCate = ""
    End Sub
    Public Function GENERALTERNO() As Integer
        Dim Sqlalter As New SqlCommand("SELECT MAX(alterno) FROM PRODUCTOS", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim ALTERNO As Integer
        Try
            SqlRead = Sqlalter.ExecuteReader
            While SqlRead.Read
                ALTERNO = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return ALTERNO + 1

    End Function
    Public Sub Cargaproveedores()
        Dim SqlSel As New SqlCommand("SELECT Abreviatura FROM proveedores where activo = 1 ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSel.ExecuteReader
            While (SqlRead.Read)
                Me.cbprovee.Items.Add(SqlRead.GetString(0).ToString)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Me.cbprovee.Items.Add("")
    End Sub
    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Descripcion
        '===============================================================
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Error, el codigo y la descripcion son datos obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtDescripcion.Text = Nothing Then
                Me.TxtDescripcion.Focus()
            End If
        Else
            '===============================================================
            ' Valido que datos si se tienen y que datos no
            '===============================================================
            valalterno(Me.TxtCapacidad.Text)
            If Me.lbalterno.Text = "." Or Me.lbalterno.Text = Nothing Or Me.lbalterno.Text = Me.TxtCodigo.Text Then

                ValidaDatos()
                If GuardaHerramienta(Codigo, peps, Ubicacion, Desc, nombrecorto, Tipo, provee, Unidad, AdquisicionFe, activo, CostoIni, UCosto, cheiva, ivavar, CHEIEPS, IEPSVAR, minstk, maxcmp, Existencia, alterno, chebsk, presentacion, cantipresenta, area, altura, offset, Me.ChkMantenimiento.Checked) = 0 Then
                    MsgBox("Registro Guardado o Actualizado")
                    PreparaFormParaCaptura(Me.Name.ToString)
                    With Me
                        With Me
                            .TxtCodigo.Text = Nothing
                            .TxtCapacidad.Text = Nothing
                            .TxtDescripcion.Text = Nothing
                            .TxtObservaciones.Text = Nothing
                            .TxtUbicacion.Text = Nothing
                            .CmbTipo.Text = Nothing
                            .CboUnidad.Text = Nothing
                            .preciocompra.Text = "0.00"
                            .precioventa.Text = "0.00"
                            .minstock.Text = "0.00"
                            .maxcompra.Text = "0.00"
                            .Chkiva.Checked = False
                            .CHKIEPS.Checked = False
                            .TXTIEPS.Text = "0.00"
                            .ChkSeries.Checked = False
                            .ChkMantenimiento.Checked = True
                            .lbalterno.Text = Nothing
                            .cbprovee.Text = Nothing
                        End With
                        .TxtCodigo.Focus()
                    End With
                    CargaGridHerramientas()
                End If

            Else
                MsgBox("El codigo rapido ya existe, Favor de capturar uno que no este repetido")
                Me.lbalterno.Text = Nothing
                '==============================================================='
                ' Como es la opcion Guardar y Nuevo voy a limpiar los campos y  '
                ' preparar la pantalla para una nueva captura                   '   
                '==============================================================='

            End If
        End If
    End Sub


    Public Sub ValidaDatos()
        
        With Me
            Codigo = .TxtCodigo.Text
            Desc = .TxtDescripcion.Text
            AdquisicionFe = .TxtFechaIngreso.Text
            Existencia = 0
            alterno = .TxtCapacidad.Text

            If .TxtUbicacion.Text = Nothing Then
                Ubicacion = "GRAL"
            Else
                Ubicacion = .TxtUbicacion.Text
            End If

            If .CmbTipo.Text = Nothing Then
                Tipo = "NFAM"
            Else
                Tipo = .CmbTipo.Text
            End If
            If .cbprovee.Text = Nothing Then
                provee = "NO"
            Else
                provee = .cbprovee.Text
            End If

            If .ChkSeries.Checked = True Then
                peps = "SI"
            Else
                peps = "NO"
            End If

            If .ChkMantenimiento.Checked = True Then
                activo = "NO"
            Else
                activo = "SI"
            End If

            If .TxtObservaciones.Text = Nothing Then
                nombrecorto = "sin nombre corto"
            Else
                nombrecorto = .TxtObservaciones.Text
            End If

            If .CboUnidad.Text = Nothing Then
                Unidad = "NUNI"
            Else
                Unidad = .CboUnidad.Text
            End If

            If .preciocompra.Text = Nothing Then
                CostoIni = "0.00"
            Else
                CostoIni = .preciocompra.Text
            End If

            If .precioventa.Text = Nothing Then
                UCosto = "0.00"
            Else
                UCosto = .precioventa.Text
            End If

            If .minstock.Text = Nothing Then
                minstk = "0.00"
            Else
                minstk = .minstock.Text
            End If

            If .maxcompra.Text = Nothing Then
                maxcmp = "0.00"
            Else
                maxcmp = .maxcompra.Text
            End If

            If .Chkiva.Checked = True Then
                cheiva = "SI"
            Else
                cheiva = "NO"
            End If

            If .iva.Text = Nothing Then
                ivavar = "0.00"
            Else
                ivavar = .iva.Text
            End If

            If .Chkbsc.Checked = True Then
                chebsk = "1"
            Else
                chebsk = "0"
            End If
            If .TxPres1.Text = Nothing Then
                presentacion = "1"
            Else
                presentacion = .TxPres1.Text
            End If
            If .TxPCant1.Text = Nothing Then
                cantipresenta = "1"
            Else
                cantipresenta = .TxPCant1.Text
            End If
            If .CHKIEPS.Checked = True Then
                cheIEPS = "SI"
            Else
                cheIEPS = "NO"
            End If

            If .TXTIEPS.Text = Nothing Then
                IEPSvar = "0.00"
            Else
                IEPSvar = .TXTIEPS.Text
            End If
        End With
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Then
            Me.Close()
        Else
            Dim resp
            resp = MsgBox("Hay datos que no ha guardado, ¿Desea salir de todas formas?", MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                Me.Close()
            End If
        End If
    End Sub


    Private Sub GuardarYSalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Descripcion
        '===============================================================
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Error, el codigo y la descripcion son datos obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtDescripcion.Text = Nothing Then
                Me.TxtDescripcion.Focus()
            End If
        Else
            '===============================================================
            ' Valido que datos si se tienen y que datos no
            '===============================================================
            ValidaDatos()
            If GuardaHerramienta(Codigo, peps, Ubicacion, Desc, nombrecorto, Tipo, provee, Unidad, AdquisicionFe, activo, CostoIni, UCosto, cheiva, ivavar, CHEIEPS, IEPSVAR, minstk, maxcmp, Existencia, alterno, chebsk, presentacion, cantipresenta, area, altura, offset, Me.ChkMantenimiento.Checked) = 0 Then
                MsgBox("Registro Guardado")
                PreparaFormParaCaptura(Me.Name.ToString)
                With Me
                    .TxtCodigo.Text = Nothing
                    .TxtCapacidad.Text = Nothing
                    .TxtDescripcion.Text = Nothing
                    .TxtFoto.Text = Nothing
                    .TxtObservaciones.Text = Nothing
                    .TxtUbicacion.Text = Nothing
                    .CboUnidad.Text = Nothing
                    .CmbTipo.Text = Nothing
                    .ChkMantenimiento.Checked = False
                    .ChkSeries.Checked = False
                    .TxtCodigo.Focus()
                End With
                CargaGridHerramientas()
                Me.Close()
            End If

        End If
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo")
                Me.TxtCodigo.Focus()
            Else
                Me.TxtDescripcion.Focus()
            End If
        End If
    End Sub

    Private Sub TxtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcion.KeyPress

        If InStr(1, Chr(39), e.KeyChar) = 1 Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If Me.TxtDescripcion.Text = Nothing Then
                MsgBox("Error, favor de capturar la descripcion")
                Me.TxtDescripcion.Focus()
            Else
                Me.TxtObservaciones.Text = Mid(TxtDescripcion.Text, 1, 12)
                Me.TxtUbicacion.Focus()
            End If
        End If
    End Sub

    Private Sub TxtUbicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUbicacion.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtUbicacion.Text = Nothing Then
                MsgBox("Error, favor de capturar la ubicacion")
                Me.TxtUbicacion.Focus()
            Else
                Me.CmbTipo.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCapacidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCapacidad.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCapacidad.Text = Nothing Then
                MsgBox("Error, favor de capturar codigo alterno")
                Me.TxtCapacidad.Focus()
            Else
                Me.TxtObservaciones.Focus()
            End If
        Else
            If Not (Char.IsNumber(e.KeyChar)) Then e.Handled = True
        End If

    End Sub


    Private Sub Chkiva_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkiva.CheckedChanged
        If Me.Chkiva.Checked <> True Then
            Me.iva.Enabled = False
            Me.iva.Text = "0.00"
        Else
            Me.iva.Enabled = True
        End If

    End Sub

    Private Sub DGPROD_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPROD.CellClick

        Dim PROIVA, PROIEPS, PROPEP, PROACT, PROSR As String
 
        If e.RowIndex > -1 Then
            CodPro = DGPROD.Rows(e.RowIndex).Cells("CODE").Value
            Me.TxtCodigo.Text = DGPROD.Rows(e.RowIndex).Cells("CODE").Value
            TxtCapacidad.Text = DGPROD.Rows(e.RowIndex).Cells("ALTERNO").Value
            Me.TxtDescripcion.Text = DGPROD.Rows(e.RowIndex).Cells("DESCR").Value
            TxtObservaciones.Text = DGPROD.Rows(e.RowIndex).Cells("CORTO").Value
            If DGPROD.Rows(e.RowIndex).Cells("FAMILIA").Value Is DBNull.Value Then
                Me.CmbTipo.Text = ""
            Else
                Me.CmbTipo.Text = DGPROD.Rows(e.RowIndex).Cells("FAMILIA").Value
            End If
            If DGPROD.Rows(e.RowIndex).Cells("PROVEE").Value Is DBNull.Value Then
                Me.cbprovee.Text = ""
            Else
                Me.cbprovee.Text = DGPROD.Rows(e.RowIndex).Cells("PROVEE").Value
            End If
            If DGPROD.Rows(e.RowIndex).Cells("UM").Value Is DBNull.Value Then
                Me.CboUnidad.Text = ""
            Else
                Me.CboUnidad.Text = DGPROD.Rows(e.RowIndex).Cells("UM").Value
            End If

            Me.preciocompra.Text = Decimal.Round(DGPROD.Rows(e.RowIndex).Cells("COMPRA").Value, 2)
            Me.precioventa.Text = Decimal.Round(DGPROD.Rows(e.RowIndex).Cells("VENTA").Value, 2)
            Me.minstock.Text = Decimal.Round(DGPROD.Rows(e.RowIndex).Cells("MINIMO").Value, 2)
            Me.maxcompra.Text = Decimal.Round(DGPROD.Rows(e.RowIndex).Cells("MAXIMO").Value, 2)
            PROIVA = DGPROD.Rows(e.RowIndex).Cells("IIVA").Value
            Dim value As Object = DGPROD.Rows(e.RowIndex).Cells("Act").Value
            'IdProd = DGPROD.Rows(e.RowIndex).Cells("CODE").Value
            If PROIVA = "SI" Then
                Me.Chkiva.Checked = True
            Else
                Me.Chkiva.Checked = False
            End If
            iva.Text = Decimal.Round(DGPROD.Rows(e.RowIndex).Cells("IVA").Value, 2)
            PROIEPS = DGPROD.Rows(e.RowIndex).Cells("IIEPS").Value
            If PROIEPS = "SI" Then
                Me.CHKIEPS.Checked = True
            Else
                Me.CHKIEPS.Checked = False
            End If
            TXTIEPS.Text = Decimal.Round(DGPROD.Rows(e.RowIndex).Cells("IEPS").Value, 2)
            PROPEP = DGPROD.Rows(e.RowIndex).Cells("PEPS").Value
            If PROPEP = "SI" Then
                Me.ChkSeries.Checked = True
            Else
                Me.ChkSeries.Checked = False
            End If
            PROACT = DGPROD.Rows(e.RowIndex).Cells("BAJA").Value
            If PROPEP = "NO" Then
                Me.ChkMantenimiento.Checked = True
            Else
                Me.ChkMantenimiento.Checked = False
            End If
            If value Is DBNull.Value Then
                Me.ChkMantenimiento.Checked = False
            Else
                If value = True Then
                    Me.ChkMantenimiento.Checked = True
                Else
                    Me.ChkMantenimiento.Checked = False
                End If
            End If
            PROSR = DGPROD.Rows(e.RowIndex).Cells("LOTES").Value
            If PROSR = "1" Then
                Me.Chkbsc.Checked = True
            Else
                Me.Chkbsc.Checked = False
            End If
            Me.TxtCodigo.Enabled = False
            Exis = True
        End If
        Me.ChBoxModificar.Checked = False
    End Sub
    Private Function valalterno(ByVal alterno As String) As Integer
        Dim Sqlbus As New SqlCommand("SELECT [Codigo de producto] FROM productos WHERE alterno = " & alterno & " ", SqlCnn)
        Dim SqlRead As SqlDataReader

        SqlRead = Sqlbus.ExecuteReader
        While SqlRead.Read
            Me.lbalterno.Text = SqlRead.GetValue(0)
        End While
        SqlRead.Close()

        Try
            Sqlbus.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function

    Private Function TraeDescripcion()

        Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] as CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre Corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA,d.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA AS IIVA, a.IVA AS IVA,a.IIEPS AS IIEPS,a.IEPS AS IEPS,a.PEPS AS PEPS, a.baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, a.Activo as Act From productos a, familias b, unidaddemedida c, PROVEEDORES D WHERE a.familia = b.clave AND a.proveedor = D.clave AND a.[Unidad de medida] = c.clave AND Descripcion LIKE '%" & Me.TxtDescripcion.Text & "%'ORDER BY a.alterno", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With DGPROD
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Me.DGPROD.Columns("Act").Visible = False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Favor de capturar el codigo alterno")
        Else
            TraeDescripcion()
        End If

    End Sub


    Private Sub CHKIEPS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKIEPS.CheckedChanged
        If Me.CHKIEPS.Checked <> True Then
            Me.TXTIEPS.Enabled = False
            Me.TXTIEPS.Text = "0.00"
        Else
            Me.TXTIEPS.Enabled = True
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Or Me.cbprovee.Text = "" Or Me.CmbTipo.Text = "" Then
            MsgBox("Error, el codigo, proveedor, familia o la descripcion son datos obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtDescripcion.Text = Nothing Then
                Me.TxtDescripcion.Focus()
            End If
        Else
            ValidaDatos()
            Dim resp
            Dim VENT As Int32 = Val(Me.TxtCapacidad.Text)
            Dim dv As DataView
            Dim regalt As Int32 = 0
            Dim regcod As String = ""
            'Dim SqlSel As New SqlCommand("SELECT  a.alterno AS ALTERNO FROM dbo.PRODUCTOS AS a INNER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave INNER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave INNER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave where a.alterno = '" & VENT & "' ", SqlCnn)
            'Dim SqlRead As SqlDataReader
            'Try
            '    SqlRead = SqlSel.ExecuteReader
            '    While (SqlRead.Read)
            '        regalt = SqlRead.GetInt32(0).ToString
            '    End While
            '    SqlRead.Close()
            'Catch ex As SqlException
            '    MsgBox(ex.Message.ToString)
            'End Try

            'If regalt > 0 Then
            '    resp = MsgBox("Ya existe el siguiente codigo Alterno: " & Me.TxtCapacidad.Text & " , ¿Desea continuar?", MsgBoxStyle.OkCancel)
            '    If resp = vbOK Then
            '    Else

            '        Exit Sub
            '    End If
            'End If
            'dv = New DataView(DTable, "ALTERNO = '" & Me.TxtCapacidad.Text & "'  ", "CODE asc", DataViewRowState.CurrentRows)

            Dim regCOD00 As String = ""
            Dim SqlSel00 As New SqlCommand("SELECT  a.alterno AS ALTERNO FROM dbo.PRODUCTOS AS a INNER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave INNER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave left outer JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave where a.[Nombre corto] = '" & Me.TxtObservaciones.Text.Trim & "' AND  a.alterno <> '" & VENT & "' ", SqlCnn)
            Dim SqlRead00 As SqlDataReader
            Try
                SqlRead00 = SqlSel00.ExecuteReader
                While (SqlRead00.Read)
                    regCOD00 = SqlRead00.GetInt32(0).ToString
                End While
                SqlRead00.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
            If regCOD00 <> "" Then
                resp = MsgBox("Ya existe el Nombre corto:  " & Me.TxtObservaciones.Text.Trim & " , agregue uno nuevo", MsgBoxStyle.Critical)
                If resp = vbOK Then
                    Exit Sub
                Else


                End If
            End If

            dv = New DataView(DTable, "CODE = '" & Me.TxtCodigo.Text.Trim & "' ", "CODE asc", DataViewRowState.CurrentRows)
            Dim SqlSel1 As New SqlCommand("SELECT  a.[Codigo de producto] AS CODE FROM dbo.PRODUCTOS AS a INNER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave INNER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave left outer JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave where a.[Codigo de producto] = '" & Me.TxtCodigo.Text.Trim & "' ", SqlCnn)
            Dim SqlRead1 As SqlDataReader
            Try
                SqlRead1 = SqlSel1.ExecuteReader
                While (SqlRead1.Read)
                    regcod = SqlRead1.GetString(0).ToString
                End While
                SqlRead1.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
            ' If regcod <> "" Then
            If Exis = True Then
                ''If regcod <> "" Then
                ''    resp = MsgBox("Ya existe el codigo:  " & Me.TxtCodigo.Text.Trim & " , ¿Deseas modificarlo?", MsgBoxStyle.OkCancel)
                ''    If resp = vbOK Then

                ''    Else
                ''        Exit Sub

                ''    End If
                ''Else
                ''resp = MsgBox("Ya existe el codigo:  " & CODPRO & " , Deseas cambiar el codigo por " & Me.TxtCodigo.Text.Trim & "?", MsgBoxStyle.Critical)
                'If UsuCate <> "MASTER" Then
                '    resp = MsgBox("No puede modificar codigo:  " & Me.TxtCapacidad.Text & " , con nuevo codigo: " & Me.TxtCodigo.Text.Trim & " dar click en limpiar ", MsgBoxStyle.Critical)
                '    If resp = vbOK Then
                '        Exit Sub
                '    Else


                '    End If
                '    ' End If
                'End If
                Dim regCOD1 As String = ""
                Dim SqlSel As New SqlCommand("SELECT  a.alterno AS ALTERNO FROM dbo.PRODUCTOS AS a INNER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave INNER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave left outer JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave where a.[Codigo de producto] = '" & Me.TxtCodigo.Text.Trim & "' AND  a.alterno <> '" & VENT & "' ", SqlCnn)
                Dim SqlRead As SqlDataReader
                Try
                    SqlRead = SqlSel.ExecuteReader
                    While (SqlRead.Read)
                        regCOD1 = SqlRead.GetInt32(0).ToString
                    End While
                    SqlRead.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                If regCOD1 <> "" Then
                    resp = MsgBox("Ya existe el codigo:  " & Me.TxtCodigo.Text.Trim & " , agregue uno nuevo", MsgBoxStyle.Critical)
                    If resp = vbOK Then
                        Exit Sub
                    Else


                    End If
                End If


            Else
                If regcod <> "" Then
                    resp = MsgBox("Ya existe el codigo:  " & Me.TxtCodigo.Text.Trim & " , agregue uno nuevo", MsgBoxStyle.Critical)
                    If resp = vbOK Then
                        Exit Sub
                    Else


                    End If
                End If
            End If


            Me.DGPROD.DataSource = dv

            If GuardaHerramienta(Codigo, peps, Ubicacion, Desc, nombrecorto, Tipo, provee, Unidad, AdquisicionFe, activo, CostoIni, UCosto, cheiva, ivavar, CHEIEPS, IEPSVAR, minstk, maxcmp, Existencia, alterno, chebsk, presentacion, cantipresenta, area, altura, offset, Me.ChkMantenimiento.Checked) = 0 Then
                MsgBox("Registro Guardado", MsgBoxStyle.MsgBoxRtlReading)
                PreparaFormParaCaptura(Me.Name.ToString)
                With Me
                    .TxtCodigo.Text = Nothing
                    .TxtCapacidad.Text = Nothing
                    .TxtDescripcion.Text = Nothing
                    .TxtFoto.Text = Nothing
                    .TxtObservaciones.Text = Nothing
                    .TxtUbicacion.Text = Nothing
                    .cbprovee.Text = ""
                    .CboUnidad.Text = Nothing
                    .CmbTipo.Text = Nothing
                    .ChkMantenimiento.Checked = False
                    .ChkSeries.Checked = False
                    .TxtCodigo.Focus()
                End With
                Me.ChBoxModificar.Checked = False
                CodPro = ""
                DTable = CargaGridHerramientas()
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        With Me
            .TxtCodigo.Text = Nothing
            .TxtCodigo.Enabled = True
            .TxtCapacidad.Text = Nothing
            .TxtDescripcion.Text = Nothing
            .TxtObservaciones.Text = Nothing
            .TxtUbicacion.Text = Nothing
            .CmbTipo.Text = Nothing
            .cbprovee.Text = ""
            .CboUnidad.Text = Nothing
            .preciocompra.Text = "0.00"
            .precioventa.Text = "0.00"
            .minstock.Text = "0.00"
            .maxcompra.Text = "0.00"
            .Chkiva.Checked = False
            .ChkSeries.Checked = False
            .ChkMantenimiento.Checked = True
            .ChBoxModificar.Checked = False
        End With
        Me.TxtCapacidad.Text = GENERALTERNO()
        Me.TxtCodigo.Text = Me.TxtCapacidad.Text.Trim
        Exis = False
        CodPro = ""

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        'With Reports_10
        '    .Show(Me)
        'End With

        For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
            If MDIPrincipal.MdiChildren(i).Text = "EXISTENCIAS" Then

                MDIPrincipal.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chReportClRut As New Reports_10
        chReportClRut.MdiParent = MDIPrincipal
        m_ChildFormNumber += 1
        chReportClRut.Show()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Then
            CargaGridHerramientas()
            Me.Close()
        Else
            Dim resp
            resp = MsgBox("Hay datos que no ha guardado, ¿Desea salir de todas formas?", MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                CargaGridHerramientas()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        With Buscador
            .Show(Me)
        End With
        Buscador.lbform.Text = 4
    End Sub

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcion.TextChanged

    End Sub

    Private Sub DGPROD_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPROD.CellContentClick

    End Sub

    Private Sub TSOpciones_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TSOpciones.ItemClicked

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If (Me.TBoxBuscaAlter.Text.Trim = "" And Me.TBoxBuscaCod.Text.Trim = "" And Me.TBoxBuscaDescrip.Text.Trim = "") Or (Me.TBoxBuscaAlter.Text.Trim <> "" And Me.TBoxBuscaCod.Text.Trim <> "" And Me.TBoxBuscaDescrip.Text.Trim <> "") Then
            Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] as CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre Corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA,d.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA AS IIVA, a.IVA AS IVA,a.IIEPS AS IIEPS,a.IEPS AS IEPS,a.PEPS AS PEPS, a.baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, case when (a.Activo is null) then 'false' else a.Activo end as Act From dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave ORDER BY a.alterno ", SqlCnn)
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
                Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA, D.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA, a.IVA, a.IIEPS, a.IEPS, a.PEPS, a.Baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, CASE WHEN (a.Activo IS NULL) THEN 'false' ELSE a.Activo END AS Act FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.Descripcion like '%" & Me.TBoxBuscaDescrip.Text.Trim & "%' order by a.alterno", SqlCnn)
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
                    Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA, D.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA, a.IVA, a.IIEPS, a.IEPS, a.PEPS, a.Baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, CASE WHEN (a.Activo IS NULL) THEN 'false' ELSE a.Activo END AS Act FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.[Codigo de producto] like '%" & Me.TBoxBuscaCod.Text.Trim & "%' order by a.alterno", SqlCnn)
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
                        Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA, D.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA, a.IVA, a.IIEPS, a.IEPS, a.PEPS, a.Baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, CASE WHEN (a.Activo IS NULL) THEN 'false' ELSE a.Activo END AS Act FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.alterno like '%" & Me.TBoxBuscaAlter.Text.Trim & "%' order by a.alterno", SqlCnn)
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
                            Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA, D.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA, a.IVA, a.IIEPS, a.IEPS, a.PEPS, a.Baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, CASE WHEN (a.Activo IS NULL) THEN 'false' ELSE a.Activo END AS Act FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.alterno like '%" & Me.TBoxBuscaAlter.Text.Trim & "%' or a.[Codigo de producto] like '%" & Me.TBoxBuscaCod.Text.Trim & "%' order by a.alterno", SqlCnn)
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
                                Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA, D.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA, a.IVA, a.IIEPS, a.IEPS, a.PEPS, a.Baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, CASE WHEN (a.Activo IS NULL) THEN 'false' ELSE a.Activo END AS Act FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.[Codigo de producto] like '%" & Me.TBoxBuscaCod.Text.Trim & "%' or a.Descripcion like '%" & Me.TBoxBuscaDescrip.Text.Trim & "%' order by a.alterno", SqlCnn)
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
                                    Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] AS CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA, D.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA, a.IVA, a.IIEPS, a.IEPS, a.PEPS, a.Baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, CASE WHEN (a.Activo IS NULL) THEN 'false' ELSE a.Activo END AS Act FROM dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave where a.alterno like '%" & Me.TBoxBuscaAlter.Text.Trim & "%' or a.Descripcion like '%" & Me.TBoxBuscaDescrip.Text.Trim & "%' order by a.alterno", SqlCnn)
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

    End Sub

    Private Sub TxtCapacidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCapacidad.TextChanged

    End Sub

    Private Sub ChBoxModificar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxModificar.CheckedChanged
        If CodPro = "" Then
            ChBoxModificar.Checked = False
        Else
            If ChBoxModificar.Checked = True Then
                Dim frmauto As New FrmAturiza
                ' Display frmAbout as a modal dialog
                frmauto.Text = "Autoriza"
                frmauto.ShowDialog(Me)
                If UsuCate = "MASTER" Then
                    Me.ChBoxModificar.ForeColor = Color.DarkGreen                               'SpringGreen        'Color.DarkGreen

                    Me.ChBoxModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold)
                    'Me.ChBoxModificar.Font = New System.Drawing.Font(Me.ChBoxModificar.Font, FontStyle.Underline)
                    Me.ChBoxModificar.BackColor = Color.CadetBlue
                    Me.TxtCodigo.Enabled = True
                Else
                    ChBoxModificar.Checked = False
                    Exit Sub
                End If

            Else

                Me.ChBoxModificar.ForeColor = Color.Black
                Me.ChBoxModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Regular)
                'Me.ChBoxModificar.Font = New System.Drawing.Font(ChBoxModificar.Font, FontStyle.Underline)
                Me.ChBoxModificar.BackColor = Color.Silver
                Me.TxtCodigo.Enabled = False
                UsuCate = ""
            End If
        End If
    End Sub
End Class