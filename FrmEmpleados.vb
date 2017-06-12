
Imports System.Data.SqlClient
Imports System.Data
Public Class FrmEmpleados
    Private Exis As Boolean
    Public Codigo, Nombre, Depto, Mail, Telefono, Foto As String

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmEmpleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DGUsuarios.DataSource = CargaGridEmpleados()
        Me.DGAlmacen.DataSource = CargaALM()
        cargacategoria()
        Me.TxtCodigo.Enabled = True
        Exis = False
    End Sub


    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Nombre
        '===============================================================
        If Me.TxtCodigo.Text = Nothing And Me.TxtNombre.Text = Nothing Then
            MsgBox("El codigo y el nombre son campos obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtNombre.Text = Nothing Then
                Me.TxtNombre.Focus()
            End If
        Else
            '===============================================================
            ' Valido que datos si se tienen y que datos no
            '===============================================================
            ValidaDatos()
            'If Me.TSBSaveNew.Text = "Guardar y Nuevo" Then
            'If CatalogoEmpleados(1, Me.TxtCodigo.Text, Me.TxtNombre.Text, Depto, Mail, Telefono) = 0 Then
            'MsgBox("Empleado Agregado")
            'PreparaFormParaCaptura(Me.Name.ToString)
            'CargaGridEmpleados()
            'Else
            'MsgBox("La operacion presento errores")
            'End If
            'Else
            If CatalogoEmpleados(3, Me.TxtCodigo.Text, Me.TxtNombre.Text, Depto, Mail, Telefono) = 0 Then
                MsgBox("Empleado Actualizado")
                PreparaFormParaCaptura(Me.Name.ToString)
                CargaGridEmpleados()
                Me.Close()
            Else
                MsgBox("La operacion presento errores")
            End If
        End If


        'End If
    End Sub


    Public Sub ValidaDatos()

        'If Me.TxtMail.Text = Nothing Then
        '    Mail = "null"
        'Else
        '    Mail = Me.TxtMail.Text
        'End If

        'If Me.TxtTelefono.Text = Nothing Then
        '    Telefono = "null"
        'Else
        '    Telefono = Me.TxtTelefono.Text
        'End If

        'If Me.TxtExtension.Text = Nothing Then
        'Extension = "null"
        'Else
        'Extension = Me.TxtExtension.Text
        'End If

        'If Me.TxtFoto.Text = Nothing Then
        'Foto = "null"
        'Else
        'Foto = Me.TxtFoto.Text
        'End If

    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtCodigo.Text = Nothing And Me.TxtNombre.Text = Nothing Then
            MsgBox("El codigo y el nombre son campos obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtNombre.Text = Nothing Then
                Me.TxtNombre.Focus()
            End If
        Else
            '===============================================================
            ' Valido que datos si se tienen y que datos no
            '===============================================================
            ValidaDatos()
            CatalogoEmpleados(1, Me.TxtCodigo.Text, Me.TxtNombre.Text, Depto, Mail, Telefono)
            PreparaFormParaCaptura(Me.Name.ToString)
            CargaGridEmpleados()
            Me.Close()
        End If

    End Sub

    Private Sub BtnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.OPFImagen.ShowDialog()
    End Sub

    Private Sub GuardarYNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Nombre
        '===============================================================
        If Me.TxtCodigo.Text = Nothing And Me.TxtNombre.Text = Nothing Then
            MsgBox("El codigo y el nombre son campos obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtNombre.Text = Nothing Then
                Me.TxtNombre.Focus()
            End If
        Else
            '===============================================================
            ' Valido que datos si se tienen y que datos no
            '===============================================================
            ValidaDatos()

            If CatalogoEmpleados(3, Me.TxtCodigo.Text, Me.TxtNombre.Text, Depto, Mail, Telefono) = 0 Then
                MsgBox("Empleado Actualizado")
                PreparaFormParaCaptura(Me.Name.ToString)
                CargaGridEmpleados()
                Me.Close()
            Else
                MsgBox("La operacion presento errores")
            End If
        End If


    End Sub

    Private Sub GuardarYSalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtCodigo.Text = Nothing And Me.TxtNombre.Text = Nothing Then
            MsgBox("El codigo y el nombre son campos obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtNombre.Text = Nothing Then
                Me.TxtNombre.Focus()
            End If
        Else
            '===============================================================
            ' Valido que datos si se tienen y que datos no
            '===============================================================
            ValidaDatos()
            CatalogoEmpleados(1, Me.TxtCodigo.Text, Me.TxtNombre.Text, Depto, Mail, Telefono)
            PreparaFormParaCaptura(Me.Name.ToString)
            CargaGridEmpleados()
            Me.Close()
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo del empleado")
                Me.TxtCodigo.Focus()
            Else
                Me.TxtNombre.Focus()
            End If
        End If
    End Sub


    Private Sub TxtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtNombre.Text = Nothing Then
                MsgBox("Error, favor de capturar el nombre")
                Me.TxtNombre.Focus()
            Else
            End If
        End If
    End Sub


    Private Sub TSBSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub
    Private Function cargacategoria()

        Dim SqlSelDes As New SqlCommand("SELECT Categoria FROM Categorias ORDER BY Categoria", SqlCnn)
        Dim SqlRead As SqlDataReader
        'Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.cbCategoria.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'Return code

    End Function
    Private Sub DGUsuarios_CellClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGUsuarios.CellClick
        If e.RowIndex > -1 Then
            Dim usuId As String
            Dim usunom As String
            Dim usucat As String
            Dim usuact As String
            Dim value As Object = DGUsuarios.Rows(e.RowIndex).Cells(0).Value
            Dim value1 As Object = DGUsuarios.Rows(e.RowIndex).Cells(1).Value
            Dim value2 As Object = DGUsuarios.Rows(e.RowIndex).Cells(2).Value
            Dim value3 As Object = DGUsuarios.Rows(e.RowIndex).Cells(3).Value
            If value.GetType Is GetType(DBNull) Then Return
            usuId = CType(value, String)
            usunom = CType(value1, String)
            usucat = CType(value2, String)
            usuact = CType(value3, Boolean)

            Me.TxtCodigo.Text = usuId
            Me.TxtNombre.Text = usunom
            Me.Txtpass.Text = "12345678"
            Me.Txtcpass.Text = "12345678"
            Me.cbCategoria.Text = usucat

            If usuact = True Then
                Me.Chkact.Checked = True
            Else
                Me.Chkact.Checked = False
            End If
            Me.DGalmusu.DataSource = CargaALMUSU(Me.TxtCodigo.Text)
            Me.TxtCodigo.Enabled = False
            Exis = True
        End If
    End Sub

    Private Sub TSBSaveNew_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Nombre
        '===============================================================
        If Me.TxtCodigo.Text = Nothing Or Me.TxtNombre.Text = Nothing Or Me.Txtpass.Text = Nothing Or Me.Txtcpass.Text = Nothing Or Me.cbCategoria.Text = Nothing Then
            MsgBox("Error, los campos son obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error favor de capturar el ID del usuario")
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtNombre.Text = Nothing Then
                Me.TxtNombre.Focus()
            End If
        Else
            If Txtpass.Text <> Txtcpass.Text Then
                MsgBox("Error el campo de contraseña no coincide")
                Txtpass.Text = Nothing
                Txtcpass.Text = Nothing
                Me.TxtCodigo.Focus()
            Else
                Dim resp
                'Dim regcod As String = ""
                Dim regnom As String = ""

                Dim regalt As Int32 = 0
                Dim regcod(3) As String
                Dim abrev(3) As String
                Dim claa(3) As String

                Dim SqlSel As New SqlCommand("SELECT USUARIO, NOMBRE FROM usuarios WHERE usuario = '" & Me.TxtCodigo.Text.Trim & "' or nombre = '" & Me.TxtNombre.Text.Trim & "' ", SqlCnn)
                Dim SqlRead As SqlDataReader
                Try
                    SqlRead = SqlSel.ExecuteReader
                    While (SqlRead.Read)

                        regcod(regalt) = SqlRead.GetSqlString(0).ToString.Trim
                        abrev(regalt) = SqlRead.GetString(1).ToString.Trim

                        regalt = regalt + 1
                    End While
                    SqlRead.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                Dim enc, enc1 As Int32
                enc = Array.IndexOf(regcod, Me.TxtCodigo.Text.Trim)
                enc1 = Array.LastIndexOf(abrev, Me.TxtNombre.Text)

                'Dim SqlSel1 As New SqlCommand("SELECT * FROM usuarios WHERE usuario = '" & Me.TxtCodigo.Text.Trim & "' ", SqlCnn)
                'Dim SqlRead1 As SqlDataReader
                'Try
                '    SqlRead1 = SqlSel1.ExecuteReader
                '    While (SqlRead1.Read)
                '        regcod = SqlRead1.GetString(0).ToString
                '    End While
                '    SqlRead1.Close()
                'Catch ex As SqlException
                '    MsgBox(ex.Message.ToString)
                'End Try
                'Dim SqlSel3 As New SqlCommand("SELECT * FROM usuarios WHERE nombre = '" & Me.TxtNombre.Text.Trim & "' ", SqlCnn)
                'Dim SqlRead3 As SqlDataReader
                'Try
                '    SqlRead3 = SqlSel3.ExecuteReader
                '    While (SqlRead3.Read)
                '        regnom = SqlRead3.GetString(0).ToString
                '    End While
                '    SqlRead3.Close()
                'Catch ex As SqlException
                '    MsgBox(ex.Message.ToString)
                'End Try
                If Exis = True Then
                    Dim SqlSel3 As New SqlCommand("SELECT nombre FROM usuarios WHERE nombre = '" & Me.TxtNombre.Text.Trim & "' and usuario <> '" & Me.TxtCodigo.Text.Trim & "' ", SqlCnn)
                    Dim SqlRead3 As SqlDataReader
                    Try
                        SqlRead3 = SqlSel3.ExecuteReader
                        While (SqlRead3.Read)
                            regnom = SqlRead3.GetString(0).ToString
                        End While
                        SqlRead3.Close()
                    Catch ex As SqlException
                        MsgBox(ex.Message.ToString)
                    End Try
                    If regnom <> "" Then
                        MsgBox("Ya existe el Nombre: " & Me.TxtNombre.Text.Trim & "")
                        Exit Sub
                    End If
                Else
                    If enc >= 0 Or enc1 >= 0 Then
                        'resp = MsgBox("Esta seguro de modificar el siguiente codigo:  " & Me.TxtCodigo.Text.Trim & " , ¿Desea continuar?", MsgBoxStyle.OkCancel)
                        If enc >= 0 And enc1 >= 0 Then
                            resp = MsgBox("Ya existe el siguiente Usuario: " & Me.TxtCodigo.Text.Trim & " y el Nomnbre: " & Me.TxtNombre.Text.Trim & ", favor de poner otro diferente", MsgBoxStyle.Information)
                            Exit Sub
                        Else
                            If enc >= 0 Then
                                resp = MsgBox("Ya existe el siguiente Usuario: " & Me.TxtCodigo.Text.Trim & ", favor de poner otro diferente", MsgBoxStyle.Information)
                                Exit Sub
                            Else
                                If enc1 >= 0 Then
                                    resp = MsgBox("Ya existe el siguiente  Nombre: " & Me.TxtNombre.Text.Trim & ", favor de poner otro diferente", MsgBoxStyle.Information)
                                    Exit Sub
                                Else

                                End If
                            End If
                        End If
                    End If
                End If

                    guardayactu()
                MsgBox("Usuario Agregado y/o Actualizado")
                    Me.DGUsuarios.DataSource = CargaGridEmpleados()

                    Me.TxtCodigo.Enabled = False
            End If
           
        End If

    End Sub
    Private Sub guardayactu()
        Dim codigo As String
        Dim nombre As String
        Dim catego As String
        Dim pass As String
        Dim valpass As String
        Dim activo As String

        codigo = Me.TxtCodigo.Text
        nombre = Me.TxtNombre.Text
        catego = Me.cbCategoria.Text
        pass = Me.Txtpass.Text
        valpass = Me.Txtcpass.Text
        If Chkact.Checked = True Then
            activo = "2"
        Else
            activo = "1"
        End If

        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("IF EXISTS(SELECT * FROM usuarios WHERE usuario = '" & codigo & "') " & _
                                "BEGIN " & _
                                "UPDATE usuarios SET nombre = '" & nombre & "', categoria = '" & catego & "', contraseña = convert(varbinary(255),pwdencrypt('" & pass & "')), activo = '" & Me.Chkact.Checked & "' WHERE usuario = '" & codigo & "' " & _
                                "END " & _
                                "ELSE " & _
                                "INSERT INTO usuarios VALUES ('" & codigo & "','" & nombre & "','" & catego & "',convert(varbinary(255),pwdencrypt('" & pass & "')),'" & Me.Chkact.Checked & "', null) ")

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

    Private Sub DGalmusu_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        
    End Sub

 
    Private Sub DGalmusu_CellClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGalmusu.CellClick
        Dim almacen As String
        Dim value As Object = DGalmusu.Rows(e.RowIndex).Cells(0).Value
        If value.GetType Is GetType(DBNull) Then Return
        almacen = CType(value, String)
        Me.lbalmacen2.Text = almacen
    End Sub

    Private Sub AddBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBtn.Click
        Dim codigo As String
        Dim alma As String
        codigo = Me.TxtCodigo.Text
        alma = Me.lbalmacen.Text
        If Me.lbalmacen.Text = Nothing Or Me.lbalmacen.Text = "." Then
            MsgBox("favor de selecionar el almacen")
        Else

            Dim SqlInsalm As New SqlCommand
            Dim CmdStr As New String("IF EXISTS(SELECT * FROM usuarios_almacen WHERE usuario = '" & codigo & "' AND almacen = '" & alma & "') " & _
                                    "BEGIN " & _
                                    "UPDATE usuarios_almacen SET usuario = '" & codigo & "', almacen = '" & alma & "' WHERE usuario = '" & codigo & "' AND almacen = '" & alma & "' " & _
                                    "END " & _
                                    "ELSE " & _
                                    "INSERT INTO usuarios_almacen VALUES ('" & codigo & "','" & alma & "') ")

            With SqlInsalm
                .CommandText = CmdStr
                .Connection = SqlCnn
            End With

            Try
                SqlInsalm.ExecuteNonQuery()
            Catch ex As Exception
                Error1 = 1
                MsgBox(ex.Message.ToString)
            End Try
            Me.DGalmusu.DataSource = CargaALMUSU(codigo)

            Return
        End If
    End Sub

    Private Sub DelBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelBtn.Click
        Dim codigo As String
        Dim alma As String
        codigo = Me.TxtCodigo.Text
        alma = Me.lbalmacen2.Text
        If Me.lbalmacen2.Text = Nothing Or Me.lbalmacen2.Text = "." Then
            MsgBox("favor de selecionar el almacen")
        Else

            Dim SqlInsalm As New SqlCommand
            Dim CmdStr As New String("DELETE FROM usuarios_almacen WHERE usuario = '" & codigo & "' AND almacen = '" & alma & "' ")

            With SqlInsalm
                .CommandText = CmdStr
                .Connection = SqlCnn
            End With

            Try
                SqlInsalm.ExecuteNonQuery()
            Catch ex As Exception
                Error1 = 1
                MsgBox(ex.Message.ToString)
            End Try
            Me.DGalmusu.DataSource = CargaALMUSU(codigo)

            Return
        End If
    End Sub

    Private Sub DGAlmacen_CellBorderStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGAlmacen.CellBorderStyleChanged

    End Sub

    Private Sub DGAlmacen_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGAlmacen.CellClick
        Dim almacen As String
        Dim value As Object = DGAlmacen.Rows(e.RowIndex).Cells(0).Value
        If value.GetType Is GetType(DBNull) Then Return
        almacen = CType(value, String)
        Me.lbalmacen.Text = almacen
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        For Each c As Control In Me.GpoEmpleados.Controls
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
        Me.TxtCodigo.Enabled = True
        Exis = False
    End Sub

    Private Sub DGUsuarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGUsuarios.CellContentClick

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked


        'Dim SqlSel As New SqlDataAdapter("SELECT FROM Clientes WHERE  Razon like '%" & TextBox2.Text & "%'", SqlCnn)
        Dim SqlSel As New SqlDataAdapter("SELECT Usuario, Nombre, Categoria, Activo FROM Usuarios where Nombre like '%" & Me.TBoxBuscaUsua.Text & "%' ORDER BY nombre", SqlCnn)

        Dim DS1 As New DataTable
        Try
            SqlSel.Fill(DS1)
            With Me.DGUsuarios
                .DataSource = DS1
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'MsgBox("No hay datos para buscar")
        'Me.TBoxBuscaUsua.Focus()

    End Sub

    Private Sub DGalmusu_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGalmusu.CellContentClick

    End Sub
End Class