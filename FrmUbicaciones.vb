Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmUbicaciones

    Public F1, F2 As Integer
    Dim numalm As String
    Private m_ChildFormNumber As Integer = 0
    Private exis As Boolean
    Private idubi As Int32
    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmSalidaResguardo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaALM2()
        exis = False
    End Sub
    Public Sub CargaALM2()
        Dim Sqlalm As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY a.almacen", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlalm.ExecuteReader
            While SqlRead.Read
                Me.cbalm.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub cargaubicaciones1()

        Dim SqlSel As New SqlDataAdapter("SELECT nombres as NAME, ABRS as abreviatura, zonas as ZONA, areas as AREA, Alturas as ALTURA, [offsets] as LIMITES, a.claves FROM subalmacenes a, almacenes b where almacen = clave and b.abreviatura = '" & cbalm.Text & "' ORDER BY Claves", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGUBI
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Me.DGUBI.Columns("claves").Visible = False
    End Sub
    Private Sub cargaubicaciones2()

        Dim SqlSel As New SqlDataAdapter("SELECT  UUBI AS SALM, [Nombre corto] AS PRODUCTO,UCOD AS CODEBAR, UFEC as FECHAUBI, UUSU AS USERUBI, UARE AS AREA, UALT AS ALTURA, UOFF AS OFFS FROM UBICACIONES a, loteex2 b, PRODUCTOS c WHERE UCOD = CodigoLote and b.[Codigo de producto] = c.[Codigo de producto] and UALM = '" & numalm & "' ORDER BY UUBI", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGUBI
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTUBI.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TXTUBI.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo")
                Me.TXTUBI.Focus()
            Else

            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTZONA.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TXTZONA.Text = Nothing Then
                MsgBox("Error, favor de capturar los campos requeridos: Codigo y Caantidad")
            Else

            End If
        End If
    End Sub

    Private Sub CHKSTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSTATUS.CheckedChanged
        'If cbalm.Text = Nothing Then
        '    MsgBox("Favor de seleccionar almacen")
        'Else
        If CHKSTATUS.Checked = True Then
            cargaubicaciones2()
        Else
            cargaubicaciones1()
        End If
        Me.TxtAltura.Text = ""
        Me.TxtArea.Text = ""
        Me.TXTNOMBRE.Text = ""
        Me.TxtOff.Text = ""
        Me.TXTUBI.Text = ""
        Me.TXTZONA.Text = ""
        'End If
    End Sub

    Private Sub DGUBI_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGUBI.CellClick
        If Me.CHKSTATUS.Checked = False Then
            If e.RowIndex > -1 Then
                Dim value As Object = DGUBI.Rows(e.RowIndex).Cells(0).Value
                If value.GetType Is GetType(DBNull) Then Return
                Dim value1 As Object = DGUBI.Rows(e.RowIndex).Cells(1).Value
                Dim value2 As Object = DGUBI.Rows(e.RowIndex).Cells(2).Value
                Dim value3 As Object = DGUBI.Rows(e.RowIndex).Cells(3).Value
                Dim value4 As Object = DGUBI.Rows(e.RowIndex).Cells(4).Value
                Dim value5 As Object = DGUBI.Rows(e.RowIndex).Cells(5).Value
                Dim value6 As Object = DGUBI.Rows(e.RowIndex).Cells(6).Value
                TXTNOMBRE.Text = Trim(CType(value, String))
                TXTUBI.Text = Trim(CType(value1, String))
                TXTZONA.Text = Trim(CType(value2, String))
                TxtArea.Text = CType(value3, String)
                TxtAltura.Text = CType(value4, String)
                TxtOff.Text = CType(value5, String)
                idubi = value6
                exis = True
            End If
        End If
    End Sub

    Private Sub cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbalm.SelectedIndexChanged
        numalm = 0
        traeNalm()
        'CHKSTATUS.Visible = True
        'CHKSTATUS.Checked = False
        cargaubicaciones1()
        Me.TxtAltura.Text = ""
        Me.TxtArea.Text = ""
        Me.TXTNOMBRE.Text = ""
        Me.TxtOff.Text = ""
        Me.TXTUBI.Text = ""
        Me.TXTZONA.Text = ""
    End Sub
    Public Function traeNalm() As Integer
        Dim SqlFolio As New SqlCommand("SELECT clave FROM almacenes where abreviatura = '" & Me.cbalm.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim almx As Integer
        Try
            SqlRead = SqlFolio.ExecuteReader
            While SqlRead.Read
                almx = SqlRead.GetString(0)
                numalm = almx
                SelecALM = almx
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return almx

    End Function
    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        If Me.TXTUBI.Text = Nothing Or cbalm.Text = Nothing Or Me.TXTZONA.Text = Nothing Or Me.TXTNOMBRE.Text = Nothing Then
            MsgBox("Favor de seleccionar almacen o ingresar nombre de ubicacion")
        Else
            Dim resp
            Dim regalt As Int32 = 0
            Dim regcod(3) As String
            Dim abrev(3) As String
            Dim claa(3) As String
            Dim regco As String
            Dim abre As String
            If exis = False Then
                Dim SqlSel As New SqlCommand("SELECT  a.NombreS AS NAME, a.AbrS AS abreviatura, a.ZonaS AS ZONA, a.AreaS AS AREA, a.AlturaS AS ALTURA, a.[offsetS] AS LIMITES FROM  dbo.SUBALMACENES AS a LEFT OUTER JOIN dbo.ALMACENES AS b ON a.Almacen = b.Clave WHERE (a.nombres = '" & Me.TXTNOMBRE.Text.Trim & "' or a.abrs = '" & Me.TXTUBI.Text.Trim & "' or a.zonas = '" & Me.TXTZONA.Text.Trim & "') and (b.Abreviatura = '" & cbalm.Text & "') ORDER BY Claves", SqlCnn)
                Dim SqlRead As SqlDataReader
                Try
                    SqlRead = SqlSel.ExecuteReader
                    While (SqlRead.Read)

                        regcod(regalt) = SqlRead.GetString(0).ToString.Trim
                        abrev(regalt) = SqlRead.GetString(1).ToString.Trim
                        claa(regalt) = SqlRead.GetString(2).ToString.Trim
                        regalt = regalt + 1
                    End While
                    SqlRead.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                Dim enc, enc1, enc2 As Int32
                enc = Array.IndexOf(regcod, Me.TXTNOMBRE.Text.Trim)
                enc1 = Array.LastIndexOf(abrev, Me.TXTUBI.Text.Trim)
                enc2 = Array.LastIndexOf(claa, Me.TXTZONA.Text.Trim)

                If enc >= 0 Or enc1 >= 0 Then
                    'resp = MsgBox("Esta seguro de modificar el siguiente codigo:  " & Me.TxtCodigo.Text.Trim & " , ¿Desea continuar?", MsgBoxStyle.OkCancel)
                    If enc >= 0 And enc1 >= 0 Then
                        resp = MsgBox("Ya existe el siguiente nombre: " & Me.TXTNOMBRE.Text.Trim & " y la Abreviatura: " & Me.TXTUBI.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                        Exit Sub
                    Else
                        If enc >= 0 Then
                            resp = MsgBox("Ya existe el siguiente nombre: " & Me.TXTNOMBRE.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                            Exit Sub
                        Else
                            If enc1 >= 0 Then
                                resp = MsgBox("Ya existe la siguiente  Abreviatura: " & Me.TXTUBI.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                                Exit Sub
                            Else

                            End If
                        End If
                    End If
                End If
            Else
                Dim SqlSel1 As New SqlCommand("SELECT  a.NombreS AS NAME, a.AbrS AS abreviatura, a.ZonaS AS ZONA, a.AreaS AS AREA, a.AlturaS AS ALTURA, a.[offsetS] AS LIMITES FROM  dbo.SUBALMACENES AS a LEFT OUTER JOIN dbo.ALMACENES AS b ON a.Almacen = b.Clave WHERE (a.nombres = '" & Me.TXTNOMBRE.Text.Trim & "' or a.abrs = '" & Me.TXTUBI.Text.Trim & "' or a.zonas = '" & Me.TXTZONA.Text.Trim & "' and a.claves <> '" & idubi & "') and b.Abreviatura = '" & cbalm.Text & "' and a.claves <> '" & idubi & "' ORDER BY Claves", SqlCnn)
                Dim SqlRead1 As SqlDataReader
                Try
                    SqlRead1 = SqlSel1.ExecuteReader
                    While (SqlRead1.Read)
                        If regalt < 4 Then
                            regcod(regalt) = SqlRead1.GetString(0).ToString.Trim
                            abrev(regalt) = SqlRead1.GetString(1).ToString.Trim
                            claa(regalt) = SqlRead1.GetString(2).ToString.Trim
                            regalt = regalt + 1
                        End If

                    End While
                    SqlRead1.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                Dim enc0, enc01, enc02 As Int32
                enc0 = Array.IndexOf(regcod, Me.TXTNOMBRE.Text.Trim)
                enc01 = Array.LastIndexOf(abrev, Me.TXTUBI.Text.Trim)
                enc02 = Array.LastIndexOf(claa, Me.TXTZONA.Text.Trim)
                If enc0 >= 0 And enc01 >= 0 Then
                    resp = MsgBox("Ya existe el siguiente nombre: " & Me.TXTNOMBRE.Text.Trim & " y la Abreviatura: " & Me.TXTUBI.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                    Exit Sub
                Else
                    If enc0 >= 0 Then
                        resp = MsgBox("Ya existe el siguiente nombre: " & Me.TXTNOMBRE.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                        Exit Sub
                    Else
                        If enc01 >= 0 Then
                            resp = MsgBox("Ya existe la siguiente  Abreviatura: " & Me.TXTUBI.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                            Exit Sub
                        Else

                        End If
                    End If
                End If
            End If



            guardayactu()
            If Error1 <> 1 Then
                MsgBox("Se guardo Ubicacion")
            End If

            cargaubicaciones1()
        End If
    End Sub
    Private Sub guardayactu()
        Dim NOMBRE As String
        Dim abrev, zone As String
        Dim area, altura, offset As Decimal
        If TxtAltura.Text = Nothing Then
            altura = "0.00"
        Else
            altura = TxtAltura.Text
        End If
        If TxtArea.Text = Nothing Then
            area = "0.00"
        Else
            area = TxtArea.Text
        End If
        If TxtOff.Text = Nothing Then
            offset = "0.00"
        Else
            offset = TxtOff.Text
        End If
        zone = TxtZona.Text
        abrev = Me.TXTUBI.Text
        NOMBRE = Me.TXTNOMBRE.Text

        Dim SqlInsEmp As New SqlCommand
        'Dim CmdStr As New String("DECLARE @VALUEA INT IF EXISTS(SELECT * FROM subalmacenes WHERE ABRS = '" & abrev & "' and almacen = '" & numalm & "' and claves = '" & idubi & "') " & _
        '                        "BEGIN " & _
        '                        "UPDATE subalmacenes SET NOMBRES = '" & NOMBRE & "', zonas = '" & zone & "', areas = '" & area & "', alturas = '" & altura & "', [offsets] = '" & offset & "' WHERE ABRS = '" & abrev & "' and almacen = '" & numalm & "' and claves = '" & idubi & "' " & _
        '                        "END " & _
        '                        "ELSE BEGIN " & _
        '                        "SET @VALUEA = (SELECT MAX(CLAVES) FROM SUBALMACENES) + 1 INSERT INTO subalmacenes (claves, nombres, abrs, zonas, areas, alturas, [offsets], almacen) " & _
        '                        "VALUES (@VALUEA,'" & NOMBRE & "','" & abrev & "','" & zone & "','" & area & "','" & altura & "','" & offset & "','" & numalm & "') END ")
        Dim CmdStr As New String("DECLARE @VALUEA INT IF EXISTS(SELECT * FROM subalmacenes WHERE  claves = '" & idubi & "') " & _
                               "BEGIN " & _
                               "UPDATE subalmacenes SET NOMBRES = '" & NOMBRE & "', ABRS = '" & abrev & "', zonas = '" & zone & "', areas = '" & area & "', alturas = '" & altura & "', [offsets] = '" & offset & "' WHERE claves = '" & idubi & "' " & _
                               "END " & _
                               "ELSE BEGIN " & _
                               "SET @VALUEA = (SELECT MAX(CLAVES) FROM SUBALMACENES) + 1 INSERT INTO subalmacenes (claves, nombres, abrs, zonas, areas, alturas, [offsets], almacen) " & _
                               "VALUES (@VALUEA,'" & NOMBRE & "','" & abrev & "','" & zone & "','" & area & "','" & altura & "','" & offset & "','" & numalm & "') END ")


        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return

    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If SelecALM = Nothing And cbalm.Text = Nothing Then
            MsgBox("Favor de Seleccionar almacen ")
        Else
            'With Reports1
            '    .Show(Me)
            'End With

            For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
                If MDIPrincipal.MdiChildren(i).Text = "Reportes de Ubicaciones" Then

                    MDIPrincipal.MdiChildren(i).Close()
                    Exit For
                Else
                End If
            Next

            Dim chReportClRut As New Reports_14
            chReportClRut.MdiParent = MDIPrincipal
            m_ChildFormNumber += 1
            chReportClRut.Show()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        With Me
            .TxtAltura.Text = ""
            .TxtArea.Text = ""
            .TXTNOMBRE.Text = ""
            .TxtOff.Text = ""
            .TXTUBI.Text = ""
            .TXTZONA.Text = ""
        End With
        exis = False
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim SqlSel As New SqlDataAdapter("SELECT nombres as NAME, ABRS as abreviatura, zonas as ZONA, areas as AREA, Alturas as ALTURA, [offsets] as LIMITES FROM dbo.SUBALMACENES AS a LEFT OUTER JOIN dbo.ALMACENES AS b ON a.Almacen = b.Clave where a.abrs like '%" & Me.TBoxBuscaUBI.Text.Trim & "%' and b.abreviatura = '" & cbalm.Text & "' ORDER BY Claves ", SqlCnn)

        Dim DS1 As New DataTable
        Try
            SqlSel.Fill(DS1)
            With Me.DGUBI
                .DataSource = DS1
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class