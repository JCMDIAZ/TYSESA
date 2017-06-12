Imports System.Data
Imports System.Data.SqlClient
Public Class FrmProveedor

    Public Codigo, Desc, Ubicacion, Tipo, Marca, RegSerie, Capacidad, AplicaMan, AdquisicionFe, Observaciones, Unidad, Foto As New String(Nothing)
    Public CostoIni, UCosto, Existencia As New Double
    Private idProv As String
    Private nompro As String
    Private Exis As Boolean

    Sub pongamayus()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.CharacterCasing = CharacterCasing.Upper
            Else
            End If
        Next
    End Sub
    Private Sub FrmMaquinaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pongamayus()
        Me.TxtFechaIngreso.Text = Now.Date
        CargaGrid()
        'idProv = GENERAIDPROVEEDOR()
        idProv = 0
        UsuCate = ""
        Exis = False
    End Sub
    Private Sub limpia()
        For Each c As Control In GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.Text = ""
            Else
                If TypeOf c Is ComboBox Then
                    Dim Cboxtem As ComboBox = CType(c, ComboBox)
                    Cboxtem.Text = ""
                Else
                    If TypeOf c Is CheckBox Then
                        Dim Chboxtem As CheckBox = CType(c, CheckBox)
                        Chboxtem.Checked = False
                    Else

                    End If
                End If
            End If
        Next
    End Sub
    Public Function GENERAIDPROVEEDOR() As String
        Dim Sqlpedi As New SqlCommand("SELECT MAX(Id_Proveedor) FROM proveedores", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim CLAVE As String
        Try
            SqlRead = Sqlpedi.ExecuteReader
            While SqlRead.Read
                CLAVE = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        If CLAVE Is DBNull.Value Then

        Else
            'CLAVE = Mid(CLAVE, 2, Len(CLAVE))
            Return CLAVE + 1
        End If
     
    End Function
    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Descripcion
        '===============================================================
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Error, la clave y el nombre son datos obligatorios")
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
            Call Me.ValidaDatos()
            Dim resp
            Dim regalt As Int32 = 0
            Dim regcod(3) As String
            Dim abrev(3) As String
            Dim claa(3) As String
            Dim regco As String
            Dim abre As String
            Dim SqlSel As New SqlCommand("SELECT  Clave, Abreviatura,nombre, Id_Proveedor  FROM proveedores where Clave = '" & Me.TxtCodigo.Text.Trim & "' or Abreviatura = '" & Me.TxtCapacidad.Text.Trim & "' ORDER BY Clave", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = SqlSel.ExecuteReader
                While (SqlRead.Read)

                    regcod(regalt) = SqlRead.GetString(0).ToString.Trim
                    abrev(regalt) = SqlRead.GetString(1).ToString.Trim
                    claa(regalt) = SqlRead.GetInt32(3).ToString.Trim
                    regalt = regalt + 1
                End While
                SqlRead.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
            Dim enc, enc1, enc2 As Int32
            enc = Array.IndexOf(regcod, Me.TxtCodigo.Text.Trim)
            enc1 = Array.LastIndexOf(abrev, Me.TxtCapacidad.Text)
            enc2 = Array.LastIndexOf(claa, idProv)
            If idProv = "0" Then


                If enc >= 0 Or enc1 >= 0 Then
                    'resp = MsgBox("Esta seguro de modificar el siguiente codigo:  " & Me.TxtCodigo.Text.Trim & " , ¿Desea continuar?", MsgBoxStyle.OkCancel)
                    If enc >= 0 And enc1 >= 0 Then
                        resp = MsgBox("Ya existe la siguiente clave: " & Me.TxtCodigo.Text.Trim & " y la Abreviatura: " & Me.TxtCapacidad.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                        Exit Sub
                    Else
                        If enc >= 0 Then
                            resp = MsgBox("Ya existe la siguiente clave: " & Me.TxtCodigo.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                            Exit Sub
                        Else
                            If enc1 >= 0 Then
                                resp = MsgBox("Ya existe la siguiente  Abreviatura: " & Me.TxtCapacidad.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                                Exit Sub
                            Else

                            End If
                        End If
                    End If



                Else

                End If

            Else
                Dim TCLA As String = ""
                Dim SqlSel1 As New SqlCommand("SELECT  Clave, Abreviatura,nombre, Id_Proveedor  FROM proveedores where Clave = '" & Me.TxtCodigo.Text.Trim & "' AND id_proveedor <> '" & idProv & "' ORDER BY Clave", SqlCnn)
                Dim SqlRead1 As SqlDataReader
                Try
                    SqlRead1 = SqlSel1.ExecuteReader
                    While (SqlRead1.Read)

                        TCLA = SqlRead1.GetString(0).ToString.Trim
                        
                    End While
                    SqlRead1.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If TCLA <> "" Then
                    resp = MsgBox("Ya existe la siguiente clave: " & Me.TxtCodigo.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim TAbre As String = ""
                Dim SqlSel2 As New SqlCommand("SELECT  Clave, Abreviatura,nombre, Id_Proveedor  FROM proveedores where Abreviatura = '" & Me.TxtCapacidad.Text.Trim & "' AND id_proveedor <> '" & idProv & "' ORDER BY Clave", SqlCnn)
                Dim SqlRead2 As SqlDataReader
                Try
                    SqlRead2 = SqlSel2.ExecuteReader
                    While (SqlRead2.Read)

                        TAbre = SqlRead2.GetString(1).ToString.Trim

                    End While
                    SqlRead2.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If TAbre <> "" Then
                    resp = MsgBox("Ya existe la siguiente Abreviatura: " & Me.TxtCapacidad.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
                'dv = New DataView(DTable, "ALTERNO = '" & Me.TxtCapacidad.Text & "'  ", "CODE asc", DataViewRowState.CurrentRows)
                guardayactu()
                MsgBox("Proveedor Agregado y/o Actualizado")
                CargaGrid()
                Me.CheckBox1.Checked = False
                With Me
                    .TxtCodigo.Text = Nothing
                    .TxtCapacidad.Text = Nothing
                    .TxtDescripcion.Text = Nothing
                    .TXTTEL.Text = Nothing
                    .TXTCONT.Text = Nothing
                    .TxtUbicacion.Text = Nothing
                    .TxtCodigo.Focus()
                End With
                idProv = "0"
        End If
    End Sub

    Public Sub ValidaDatos()

        With Me
            Codigo = .TxtCodigo.Text
            Desc = .TxtDescripcion.Text
            AdquisicionFe = .TxtFechaIngreso.Text
            CostoIni = 0
            UCosto = 0
            Existencia = 0

            If .TxtUbicacion.Text = Nothing Then
                Ubicacion = "null"
            Else
                Ubicacion = .TxtUbicacion.Text
            End If

            If .TxtCapacidad.Text = Nothing Then
                Capacidad = "null"
            Else
                Capacidad = .TxtCapacidad.Text
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
        e.KeyChar = Char.ToUpper(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Me.TxtCapacidad.Text = Mid(TxtDescripcion.Text, 1, 12)
            If Me.TxtDescripcion.Text = Nothing Then
                MsgBox("Error, favor de capturar la descripcion")
                Me.TxtDescripcion.Focus()
            Else
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
                'Me.CmbTipo.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCapacidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCapacidad.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCapacidad.Text = Nothing Then
                MsgBox("Error, favor de capturar la capacidad")
                Me.TxtCapacidad.Focus()
            Else
                'Me.CboMarca.Focus()
            End If
        End If
    End Sub

    Private Sub GuardarYNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub GuardarYSalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub CargaGrid()

        Dim SqlSel As New SqlDataAdapter("SELECT Id_Proveedor as IDPROV, Clave as CLAVE, nombre as NOMBRE, Abreviatura AS ABREVIATURA , Direccion as DIRECCION, Contacto as CONTACTO , Telefono AS TEL, FIngreso_Proveedor as FechaIngreso, case when (Activo is null) then 'false' else Activo end as Activo FROM proveedores ORDER BY Clave", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGPROV
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Me.DGPROV.Columns("IDPROV").Visible = False
        Me.DGPROV.Columns("FECHAINGRESO").Visible = False
    End Sub
    Private Sub guardayactu()
        Dim codigo As String
        Dim descripcion As String
        Dim abrev As String
        Dim tel As String
        Dim dir As String
        Dim contac As String


        codigo = Me.TxtCodigo.Text
        descripcion = Me.TxtDescripcion.Text
        tel = Me.TXTTEL.Text
        dir = Me.TxtUbicacion.Text
        contac = Me.TXTCONT.Text
        abrev = Me.TxtCapacidad.Text


        Dim SqlInsEmp As New SqlCommand
        'Dim CmdStr As New String("IF EXISTS(SELECT * FROM proveedores WHERE clave = '" & codigo & "') " & _
        '                        "BEGIN " & _
        '                        "UPDATE proveedores SET nombre = '" & descripcion & "', Direccion = '" & dir & "', Telefono = '" & tel & "', Contacto = '" & contac & "', abreviatura = '" & abrev & "' WHERE clave = '" & codigo & "' " & _
        '                        "END " & _
        '                        "ELSE " & _
        '                        "INSERT INTO proveedores (Clave, Nombre, Direccion, Telefono, Contacto, Abreviatura) " & _
        '                        "VALUES ('" & codigo & "','" & descripcion & "','" & dir & "','" & tel & "','" & contac & "','" & abrev & "') ")

        If UsuCate = "MASTER" Then
            Me.ChBoxModificar.Checked = False
            Dim CmdStr As New String("IF EXISTS(SELECT * FROM proveedores WHERE Id_Proveedor = '" & idProv & "') " & _
                                    "BEGIN " & _
                                    "UPDATE proveedores SET CLAVE = '" & Me.TxtCodigo.Text.Trim & "', Abreviatura = '" & Me.TxtCapacidad.Text.Trim & "', nombre = '" & descripcion & "', Direccion = '" & dir & "', Telefono = '" & tel & "', Contacto = '" & contac & "', Activo = '" & Me.CheckBox1.Checked & "' WHERE Id_Proveedor = '" & idProv & "' " & _
                                    "END ")

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
        Else
            Dim CmdStr As New String("IF EXISTS(SELECT * FROM proveedores WHERE Id_Proveedor = '" & idProv & "') " & _
                                    "BEGIN " & _
                                    "UPDATE proveedores SET nombre = '" & descripcion & "', Direccion = '" & dir & "', Telefono = '" & tel & "', Contacto = '" & contac & "', Activo = '" & Me.CheckBox1.Checked & "' WHERE Id_Proveedor = '" & idProv & "' " & _
                                    "END " & _
                                    "ELSE " & _
                                    "INSERT INTO proveedores (Clave, Nombre, Direccion, Telefono, Contacto, Abreviatura, FIngreso_Proveedor, Activo) " & _
                                    "VALUES ('" & codigo & "','" & descripcion & "','" & dir & "','" & tel & "','" & contac & "','" & abrev & "', getdate(), '" & Me.CheckBox1.Checked & "') ")

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
        End If



        Return

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub DGPROV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
       

    End Sub

    Private Sub DGPROV_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPROV.CellClick
        If e.RowIndex > -1 Then
            Dim PROId As String
            Dim PRODESC As String
            Dim PROABR As String
            Dim PRODIR As String
            Dim PROCON As String
            Dim PROTEL As String
            Me.TxtFechaIngreso.Text = Now.Date
            Me.CheckBox1.Checked = False
            idProv = DGPROV.Rows(e.RowIndex).Cells(0).Value
            Dim value As Object = DGPROV.Rows(e.RowIndex).Cells(2).Value
            Dim value1 As Object = DGPROV.Rows(e.RowIndex).Cells(1).Value
            Dim value2 As Object = DGPROV.Rows(e.RowIndex).Cells(3).Value
            Dim value3 As Object = DGPROV.Rows(e.RowIndex).Cells(4).Value
            Dim value4 As Object = DGPROV.Rows(e.RowIndex).Cells(5).Value
            Dim value5 As Object = DGPROV.Rows(e.RowIndex).Cells(6).Value
            Dim value6 As Object = DGPROV.Rows(e.RowIndex).Cells(7).Value
            Dim value7 As Object = DGPROV.Rows(e.RowIndex).Cells(8).Value
            nompro = DGPROV.Rows(e.RowIndex).Cells(1).Value
            If value7.GetType Is GetType(DBNull) Then
            Else
                Me.CheckBox1.Checked = CType(value7, Boolean)
            End If

            If value6.GetType Is GetType(DBNull) Then
            Else
                Me.TxtFechaIngreso.Text = CType(value6, DateTime)
            End If
            If value.GetType Is GetType(DBNull) Then Return

            PROId = CType(value, String)
            PRODESC = CType(value1, String)
            PROABR = CType(value2, String)
            PRODIR = CType(value3, String)
            PROCON = CType(value4, String)
            PROTEL = CType(value5, String)

            Me.TxtCodigo.Text = PRODESC
            Me.TxtDescripcion.Text = PROId
            Me.TxtCapacidad.Text = PROABR
            Me.TxtUbicacion.Text = PRODIR
            Me.TXTCONT.Text = PROCON
            Me.TXTTEL.Text = PROTEL
            Me.TxtCapacidad.Enabled = False
            Me.TxtCodigo.Enabled = False
            Exis = True
        End If
        Me.ChBoxModificar.Checked = False
    End Sub

    Private Sub DGPROV_CellContentClick_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPROV.CellContentClick

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TextBox1.Text <> Nothing Then

            Dim SqlSel As New SqlDataAdapter("SELECT * FROM proveedores WHERE  Nombre like '%" & TextBox1.Text & "%'", SqlCnn)
            Dim DS1 As New DataTable
            Try
                SqlSel.Fill(DS1)
                With Me.DGPROV
                    .DataSource = DS1
                End With
            Catch ex As SqlException

            End Try

        Else
            MsgBox("No hay datos para buscar")
        End If
    End Sub

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcion.TextChanged

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Call Me.limpia()
        'idProv = GENERAIDPROVEEDOR()
        Me.TxtFechaIngreso.Text = Now.Date
        Me.TxtCapacidad.Enabled = True
        Me.TxtCodigo.Enabled = True
        Me.ChBoxModificar.Checked = False
        idProv = "0"
        Exis = False
    End Sub

    Private Sub TXTTEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTEL.KeyPress
        If Not (Char.IsNumber(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub ChBoxModificar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxModificar.CheckedChanged
        If idProv = "0" Then
            ChBoxModificar.Checked = False
        Else
            If ChBoxModificar.Checked = True Then
                Dim frmauto As New FrmAturiza
                ' Display frmAbout as a modal dialog
                frmauto.Text = "Autoriza"
                frmauto.ShowDialog(Me)
                If UsuCate = "MASTER" Then
                    Me.ChBoxModificar.ForeColor = Color.DarkGreen

                    Me.ChBoxModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold)
                    'Me.ChBoxModificar.Font = New System.Drawing.Font(Me.ChBoxModificar.Font, FontStyle.Underline)
                    Me.ChBoxModificar.BackColor = Color.CadetBlue
                    Me.TxtCapacidad.Enabled = True
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
                Me.TxtCapacidad.Enabled = False
                Me.TxtCodigo.Enabled = False
                UsuCate = ""
            End If
        End If

    End Sub
End Class