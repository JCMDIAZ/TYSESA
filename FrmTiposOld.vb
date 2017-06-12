Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTipos
    Private CodFam As String

    Sub pongamayus()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.CharacterCasing = CharacterCasing.Upper
            Else
            End If
        Next
    End Sub

    Private Sub FrmTipos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'GeneralesDataSet.Inventarios' Puede moverla o quitarla según sea necesario.
        'Me.InventariosTableAdapter.Fill(Me.GeneralesDataSet.Inventarios)
        pongamayus()
        CargaGrid()
        UsuCate = ""
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Nombre
        '===============================================================
        If Me.TxtCodigo.Text = Nothing And Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Error, los campos son obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtDescripcion.Text = Nothing Then
                Me.TxtDescripcion.Focus()
            End If
        Else
            Dim regcod As String = ""
            If CodFam = "" Then
                Dim SqlSel1 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM familias where Clave = '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
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

                If regcod <> "" Then
                    MsgBox("La Clave:  " & Me.TxtCodigo.Text.Trim & " Ya existe")
                    Exit Sub
                End If

                regcod = ""
                Dim SqlSel2 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM familias where nombre = '" & Me.TxtDescripcion.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead2 As SqlDataReader
                Try
                    SqlRead2 = SqlSel2.ExecuteReader
                    While (SqlRead2.Read)
                        regcod = SqlRead2.GetString(1).ToString
                    End While
                    SqlRead2.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Descripcion:  " & Me.TxtDescripcion.Text.Trim & " Ya existe")
                    Exit Sub
                End If

                regcod = ""
                Dim SqlSel3 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM familias where Abreviatura = '" & Me.TextBox1.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead3 As SqlDataReader
                Try
                    SqlRead3 = SqlSel3.ExecuteReader
                    While (SqlRead3.Read)
                        regcod = SqlRead3.GetString(2).ToString
                    End While
                    SqlRead3.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Abreviatura:  " & Me.TextBox1.Text.Trim & " Ya existe")
                    Exit Sub
                End If

            Else
                regcod = ""
                Dim SqlSel2 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM familias where nombre = '" & Me.TxtDescripcion.Text.Trim & "' and Clave <> '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead2 As SqlDataReader
                Try
                    SqlRead2 = SqlSel2.ExecuteReader
                    While (SqlRead2.Read)
                        regcod = SqlRead2.GetString(1).ToString
                    End While
                    SqlRead2.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Descripcion:  " & Me.TxtDescripcion.Text.Trim & " Ya existe")
                    Exit Sub
                End If

                regcod = ""
                Dim SqlSel3 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM familias where Abreviatura = '" & Me.TextBox1.Text.Trim & "' and Clave <> '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead3 As SqlDataReader
                Try
                    SqlRead3 = SqlSel3.ExecuteReader
                    While (SqlRead3.Read)
                        regcod = SqlRead3.GetString(2).ToString
                    End While
                    SqlRead3.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Abreviatura:  " & Me.TextBox1.Text.Trim & " Ya existe")
                    Exit Sub
                End If
            End If

            guardayactu()
            MsgBox("Familia Agregada y/o Actualizada")
            CargaGrid()
            CodFam = ""
        End If
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


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
        If e.KeyChar = Chr(13) Then
            If Me.TxtDescripcion.Text = Nothing Then
                MsgBox("Error, favor de capturar la descripcion")
                Me.TxtDescripcion.Focus()
            Else

            End If
        End If
    End Sub

    'Private Sub GuardarYNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarYNuevoToolStripMenuItem.Click
    '    '===============================================================
    '    ' Los campos que no permiten nulos en la BD son Codigo y Nombre
    '    '===============================================================
    '    If Me.TxtCodigo.Text = Nothing And Me.TxtDescripcion.Text = Nothing Then
    '        MsgBox("Error, los campos son obligatorios")
    '        If Me.TxtCodigo.Text = Nothing Then
    '            Me.TxtCodigo.Focus()
    '        End If
    '        If Me.TxtDescripcion.Text = Nothing Then
    '            Me.TxtDescripcion.Focus()
    '        End If
    '    Else
    '        '===============================================================
    '        ' Valido que datos si se tienen y que datos no
    '        '===============================================================
    '        'ValidaDatos()
    '        If Me.TSBSaveNew.Text = "Guardar y Nuevo" Then
    '            If CatalogoTipos(1, Me.TxtCodigo.Text, Me.TxtDescripcion.Text) = 0 Then
    '                MsgBox("Tipo Agregado")
    '                PreparaFormParaCaptura(Me.Name.ToString)

    '                Dim SqlSel As New SqlDataAdapter("exec spSelTipos 'Todos'", SqlCnn)
    '                Dim DS As New DataTable

    '                Try

    '                    SqlSel.Fill(DS)
    '                    With FrmCatTipos.GridTipos
    '                        .DataSource = DS
    '                    End With
    '                Catch ex As SqlException
    '                    MsgBox(ex.Message.ToString)
    '                End Try

    '            Else
    '                MsgBox("La operacion presento errores")
    '            End If
    '        Else
    '            If CatalogoTipos(3, Me.TxtCodigo.Text, Me.TxtDescripcion.Text) = 0 Then
    '                MsgBox("Tipo Actualizado")
    '                PreparaFormParaCaptura(Me.Name.ToString)
    '                Dim SqlSel As New SqlDataAdapter("exec spSelTipos 'Todos'", SqlCnn)
    '                Dim DS As New DataTable

    '                Try

    '                    SqlSel.Fill(DS)
    '                    With FrmCatTipos.GridTipos
    '                        .DataSource = DS
    '                    End With
    '                Catch ex As SqlException
    '                    MsgBox(ex.Message.ToString)
    '                End Try
    '                Me.Close()
    '            Else
    '                MsgBox("La operacion presento errores")
    '            End If
    '        End If


    '    End If
    'End Sub

    Private Sub GuardarYSalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.TxtCodigo.Text = Nothing And Me.TxtDescripcion.Text = Nothing Then
        '    MsgBox("Error, los campos son obligatorios")
        '    If Me.TxtCodigo.Text = Nothing Then
        '        Me.TxtCodigo.Focus()
        '    End If
        '    If Me.TxtDescripcion.Text = Nothing Then
        '        Me.TxtDescripcion.Focus()
        '    End If
        'Else
        '    '===============================================================
        '    ' Valido que datos si se tienen y que datos no
        '    '===============================================================
        '    'ValidaDatos()
        '    CatalogoTipos(1, Me.TxtCodigo.Text, Me.TxtDescripcion.Text)
        '    PreparaFormParaCaptura(Me.Name.ToString)
        '    Dim SqlSel As New SqlDataAdapter("exec spSelTipos 'Todos'", SqlCnn)
        '    Dim DS As New DataTable

        '    Try

        '        SqlSel.Fill(DS)
        '        With FrmCatTipos.GridTipos
        '            .DataSource = DS
        '        End With
        '    Catch ex As SqlException
        '        MsgBox(ex.Message.ToString)
        '    End Try
        '    Me.Close()
        'End If

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub CargaGrid()

        Dim SqlSel As New SqlDataAdapter("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM familias ORDER BY Clave", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGFAM 'DGFAM1
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub guardayactu()
        Dim codigo As String
        Dim descripcion As String
        Dim abrev As String

        codigo = Me.TxtCodigo.Text
        descripcion = Me.TxtDescripcion.Text
        abrev = Me.TextBox1.Text

        Dim SqlInsEmp As New SqlCommand
        'If UsuCate = "MASTER" Then
        '    Dim CmdStr As New String("IF EXISTS(SELECT * FROM familias WHERE clave = '" & codigo & "') " & _
        '                            "BEGIN " & _
        '                            "UPDATE familias SET nombre = '" & descripcion & "', abreviatura = '" & abrev & "', Activo = '" & Me.ChActivo.Checked & "' WHERE clave = '" & codigo & "' " & _
        '                            "END  ")

        '    With SqlInsEmp
        '        .CommandText = CmdStr
        '        .Connection = SqlCnn
        '    End With
        '    'Else
        Dim CmdStr As New String("IF EXISTS(SELECT * FROM familias WHERE clave = '" & codigo & "') " & _
                                "BEGIN " & _
                                "UPDATE familias SET nombre = '" & descripcion & "', abreviatura = '" & abrev & "', Activo = '" & Me.ChActivo.Checked & "' WHERE clave = '" & codigo & "' " & _
                                "END " & _
                                "ELSE " & _
                                "INSERT INTO familias (clave, nombre, abreviatura, Activo) " & _
                                "VALUES ('" & codigo & "','" & descripcion & "','" & abrev & "','" & Me.ChActivo.Checked & "') ")

        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With
        'End If


        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return

    End Sub

    Private Sub DGTIPO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

   

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.TxtCodigo.Enabled = True
        Me.TxtCodigo.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.TextBox1.Text = ""
        Me.ChActivo.Checked = False
        CodFam = ""
        
    End Sub

    Private Sub TSOpciones_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TSOpciones.ItemClicked

    End Sub

    Private Sub DGFAM_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGFAM.CellClick
        If e.RowIndex > -1 Then
            Dim FAMId As String
            Dim FAMDESC As String
            Dim FAMABR As String
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            Dim value As Object = DGFAM.Rows(e.RowIndex).Cells(1).Value
            If value.GetType Is GetType(DBNull) Then Return


            FAMId = CType(value, String)

            Dim value1 As Object = DGFAM.Rows(e.RowIndex).Cells(0).Value
            Dim value2 As Object = DGFAM.Rows(e.RowIndex).Cells(2).Value

            FAMDESC = CType(value1, String)
            FAMABR = CType(value2, String)
            CodFam = FAMDESC
            If DGFAM.Rows(e.RowIndex).Cells(3).Value Is DBNull.Value Then
                Me.ChActivo.Checked = False
            Else
                If DGFAM.Rows(e.RowIndex).Cells(3).Value = True Then
                    Me.ChActivo.Checked = True
                Else
                    Me.ChActivo.Checked = False
                End If
            End If

            Me.TxtCodigo.Text = FAMDESC
            Me.TxtDescripcion.Text = FAMId
            Me.TextBox1.Text = FAMABR
            Me.TxtCodigo.Enabled = False

        End If

    End Sub

    Private Sub ChBoxModificar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxModificar.CheckedChanged
        If CodFam = "" Then
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

    Private Sub DGFAM_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGFAM.CellContentClick

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim SqlSel As New SqlDataAdapter("SELECT * FROM familias WHERE NOMBRE like '%" & Me.TBoxBuscaFamilia.Text & "%' ORDER BY nombre", SqlCnn)

        Dim DS1 As New DataTable
        Try
            SqlSel.Fill(DS1)
            With Me.DGFAM
                .DataSource = DS1
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class