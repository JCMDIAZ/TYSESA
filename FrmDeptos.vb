Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmDeptos
    Private Exis As Boolean
    Private CodAlm As String
    Sub pongamayus()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.CharacterCasing = CharacterCasing.Upper
            Else
            End If
        Next
    End Sub
    Private Sub FrmDeptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pongamayus()
        CargaGrid()
        Exis = False
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
            Dim resp
            Dim regcod As String = ""
            Dim regnom As String = ""
            Dim SqlSel1 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Zona ,Activo  FROM almacenes where Clave = '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave ", SqlCnn)
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
            Dim SqlSel3 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Zona ,Activo  FROM almacenes where Abreviatura = '" & Me.TextBox1.Text.Trim & "' AND Clave <> '" & Me.TxtCodigo.Text.Trim & "' ", SqlCnn)
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

            If Exis = True Then

                Dim regCOD1 As String = ""
                Dim SqlSel As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Zona ,Activo  FROM almacenes where Abreviatura = '" & Me.TextBox1.Text.Trim & "' AND Clave <> '" & Me.TxtCodigo.Text.Trim & "' ", SqlCnn)
                Dim SqlRead As SqlDataReader
                Try
                    SqlRead = SqlSel.ExecuteReader
                    While (SqlRead.Read)
                        regCOD1 = SqlRead.GetString(0).ToString
                    End While
                    SqlRead.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                If regCOD1 <> "" Then
                    resp = MsgBox("Ya existe la Abreviatura:  " & Me.TextBox1.Text.Trim & "  , agregue uno nuevo", MsgBoxStyle.Critical)
                    If resp = vbOK Then
                        Exit Sub
                    Else


                    End If
                End If


            Else
                If regcod <> "" Then
                    resp = MsgBox("Ya existe la Clave:  " & Me.TxtCodigo.Text.Trim & " , agregue uno nuevo", MsgBoxStyle.Critical)
                    If resp = vbOK Then
                        Exit Sub
                    Else


                    End If
                End If

                If regnom <> "" Then
                    resp = MsgBox("Ya existe la Abreviatura:  " & Me.TextBox1.Text.Trim & " , agregue uno nuevo", MsgBoxStyle.Critical)
                    If resp = vbOK Then
                        Exit Sub
                    Else


                    End If
                End If
            End If
            guardayactu()
            MsgBox("Almacen Agregado y/o Actualizado")
            Me.ChBoxModificar.Checked = False
            CargaGrid()

        End If
    End Sub
    

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
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

    Private Sub GuardarYNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Error, todos los campos son obligatorios")
        Else
            If Me.TSBSaveNew.Text = "Guardar y Nuevo" Then
                If CatalogoDeptos(1, Me.TxtCodigo.Text, Me.TxtDescripcion.Text) = 0 Then
                    MsgBox("Departamento Agregado")
                    PreparaFormParaCaptura(Me.Name.ToString)
                    'CargaDeptos()
                Else
                    MsgBox("La operacion presento errores")
                End If
            Else
                If CatalogoDeptos(3, Me.TxtCodigo.Text, Me.TxtDescripcion.Text) = 0 Then
                    MsgBox("Departamento Actualizado")
                    PreparaFormParaCaptura(Me.Name.ToString)
                    'CargaDeptos()
                    Me.Close()
                Else
                    MsgBox("La operacion presento errores")
                End If

            End If
        End If
    End Sub

    Private Sub GuardarYSalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtCodigo.Text = Nothing Or Me.TxtDescripcion.Text = Nothing Or TxtZona.Text = Nothing Then
            MsgBox("Error, todos los campos son obligatorios")
        Else
            If CatalogoDeptos(1, Me.TxtCodigo.Text, Me.TxtDescripcion.Text) = 0 Then
                MsgBox("Almacen Agregado")
                PreparaFormParaCaptura(Me.Name.ToString)
                'CargaDeptos()
                Me.Close()
            Else
                MsgBox("La operacion presento errores")
            End If
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub CargaGrid()

        'Dim SqlSel As New SqlDataAdapter("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Zona , Area, Altura, offset, Activo  FROM almacenes ORDER BY Clave", SqlCnn)
        Dim SqlSel As New SqlDataAdapter("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Zona ,Activo  FROM almacenes ORDER BY Clave", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGALM
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub guardayactu()
        Dim codigo As String
        Dim descripcion As String
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
        codigo = Me.TxtCodigo.Text
        descripcion = Me.TxtDescripcion.Text
        abrev = Me.TextBox1.Text

        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("IF EXISTS(SELECT * FROM almacenes WHERE clave = '" & codigo & "') " & _
                                "BEGIN " & _
                                "UPDATE almacenes SET nombre = '" & descripcion & "', abreviatura = '" & abrev & "', zona = '" & zone & "', area = '" & area & "', altura = '" & altura & "', offset = '" & offset & "', Activo = '" & Me.Chkact.Checked & "' WHERE clave = '" & codigo & "' " & _
                                "END " & _
                                "ELSE " & _
                                "INSERT INTO almacenes (clave, nombre, abreviatura, zona, area, altura, offset, Activo) " & _
                                "VALUES ('" & codigo & "','" & descripcion & "','" & abrev & "','" & zone & "','" & area & "','" & altura & "','" & offset & "','" & Me.Chkact.Checked & "') ")

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

    Private Sub DGALM_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGALM.CellClick
        Me.ChBoxModificar.Checked = False
        If e.RowIndex > -1 Then
            Dim DEPTOId As String
            Dim DEPTODESC As String
            Dim DEPTOABR As String
            Dim value As Object = DGALM.Rows(e.RowIndex).Cells(1).Value
            If value.GetType Is GetType(DBNull) Then Return


            DEPTOId = CType(value, String)

            Dim value1 As Object = DGALM.Rows(e.RowIndex).Cells(0).Value
            Dim value2 As Object = DGALM.Rows(e.RowIndex).Cells(2).Value
            Dim value3 As Object = DGALM.Rows(e.RowIndex).Cells(3).Value
            'Dim value4 As Object = DGALM.Rows(e.RowIndex).Cells(4).Value
            'Dim value5 As Object = DGALM.Rows(e.RowIndex).Cells(5).Value
            'Dim value6 As Object = DGALM.Rows(e.RowIndex).Cells(6).Value

            Dim value7 As Object = DGALM.Rows(e.RowIndex).Cells(4).Value

            DEPTODESC = CType(value1, String)
            DEPTOABR = CType(value2, String)
            TxtZona.Text = CType(value3, String)
            'TxtArea.Text = CType(value4, String)
            'TxtAltura.Text = CType(value5, String)
            'TxtOff.Text = CType(value6, String)
            If value7 Is DBNull.Value Then
                Me.Chkact.Checked = False
            Else
                Dim vacti As Boolean = CType(value7, Boolean)
                If vacti = True Then
                    Me.Chkact.Checked = True
                Else
                    Me.Chkact.Checked = False
                End If
            End If
            CodAlm = CType(value1, String)
            Me.TxtCodigo.Text = DEPTODESC
            Me.TxtDescripcion.Text = DEPTOId
            Me.TextBox1.Text = DEPTOABR
            Exis = True
            Me.TxtCodigo.Enabled = False
            Me.TextBox1.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DGALM_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGALM.CellContentClick

    End Sub

 
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
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
                        Dim Cboxtem As CheckBox = CType(c, CheckBox)
                        Cboxtem.Checked = False
                    Else

                    End If
                End If
            End If
        Next
        Me.TxtCodigo.Enabled = True
        Me.TextBox1.Enabled = True
        Me.TxtCodigo.Focus()
        Exis = False
        CodAlm = ""
    End Sub

    Private Sub ChBoxModificar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChBoxModificar.CheckedChanged
        If CodAlm = "" Then
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

                    Me.TextBox1.Enabled = True
                Else
                    ChBoxModificar.Checked = False
                    Me.TextBox1.Enabled = False
                    Exit Sub
                End If

            Else

                Me.ChBoxModificar.ForeColor = Color.Black
                Me.ChBoxModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Regular)
                'Me.ChBoxModificar.Font = New System.Drawing.Font(ChBoxModificar.Font, FontStyle.Underline)
                Me.ChBoxModificar.BackColor = Color.Silver
                Me.TxtCodigo.Enabled = False
                Me.TextBox1.Enabled = False
                UsuCate = ""
            End If
        End If
    End Sub

End Class