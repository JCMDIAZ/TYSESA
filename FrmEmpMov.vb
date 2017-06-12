Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class FrmEmpMov

    Dim dato As Integer
    Public CodEmpMov As String

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click

        Dim ID As Integer
        Dim Nombre, Pass As String

        ID = CInt(Me.TxtCodigo.Text)
        Nombre = Me.TxtNombre.Text
        Pass = Me.Txtpass.Text

        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As String

        'Busqueda()

        If dato = 1 Then
            MsgBox("Id de Empleado ya existe")
            Me.TxtCodigo.Text = ""
            Me.TxtNombre.Text = ""
            Me.Txtpass.Text = ""
            Me.Txtcpass.Text = ""
            Me.TxtCodigo.Focus()
        Else
            If Me.Txtpass.Text = Me.Txtcpass.Text Then
                Dim resp
                Dim regCOD1 As String = ""

                If CodEmpMov = "" Then
    

                    Dim regalt As Int32 = 0
                    Dim regcod(3) As String
                    Dim abrev(3) As String
                    Dim claa(3) As String

                    Dim SqlSel As New SqlCommand("SELECT ID_EMPLEADO, NOMBRE FROM Empleadosmoviles WHERE nombre = '" & Me.TxtNombre.Text.Trim & "' OR ID_EMPLEADO = '" & Me.TxtCodigo.Text & "'", SqlCnn)
                    Dim SqlRead As SqlDataReader
                    Try
                        SqlRead = SqlSel.ExecuteReader
                        While (SqlRead.Read)

                            regcod(regalt) = SqlRead.GetSqlInt32(0).ToString.Trim
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

                    If enc >= 0 Or enc1 >= 0 Then
                        'resp = MsgBox("Esta seguro de modificar el siguiente codigo:  " & Me.TxtCodigo.Text.Trim & " , ¿Desea continuar?", MsgBoxStyle.OkCancel)
                        If enc >= 0 And enc1 >= 0 Then
                            resp = MsgBox("Ya existe la siguiente clave: " & Me.TxtCodigo.Text.Trim & " y el nombre: " & Me.TxtNombre.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                            Exit Sub
                        Else
                            If enc >= 0 Then
                                resp = MsgBox("Ya existe la siguiente clave: " & Me.TxtCodigo.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                                Exit Sub
                            Else
                                If enc1 >= 0 Then
                                    resp = MsgBox("Ya existe el siguiente nombre: " & Me.TxtNombre.Text.Trim & ", favor de poner otra diferente", MsgBoxStyle.Information)
                                    Exit Sub
                                Else

                                End If
                            End If
                        End If
                    End If
   
                Else
                    Dim SqlSel1 As New SqlCommand("SELECT ID_EMPLEADO FROM Empleadosmoviles WHERE NOMBRE = '" & Me.TxtNombre.Text.Trim & "'  AND ID_EMPLEADO <> '" & Me.TxtCodigo.Text & "'  ", SqlCnn)
                    Dim SqlRead1 As SqlDataReader
                    Try
                        SqlRead1 = SqlSel1.ExecuteReader
                        While (SqlRead1.Read)
                            regCOD1 = SqlRead1.GetInt32(0).ToString
                        End While
                        SqlRead1.Close()
                    Catch ex As SqlException
                        MsgBox(ex.Message.ToString)
                    End Try
                    If regCOD1 <> "" Then
                        resp = MsgBox("Ya existe el nombre:  " & Me.TxtNombre.Text.Trim & " , agregue uno nuevo", MsgBoxStyle.Critical)
                        If resp = vbOK Then
                            Exit Sub
                        Else

                        End If
                    End If
                End If


                CmdStr = "IF NOT EXISTS(SELECT * FROM Empleadosmoviles WHERE ID_EMPLEADO = '" & Me.TxtCodigo.Text & "' ) BEGIN INSERT INTO Empleadosmoviles (ID_EMPLEADO, NOMBRE, PASS, Activo) Values ('" & ID & "', '" & Nombre & "', '" & Pass & "', '" & Me.ChActivo.Checked & "') END ELSE BEGIN UPDATE Empleadosmoviles SET NOMBRE = '" & Nombre & "', PASS = '" & Pass & "', Activo = '" & Me.ChActivo.Checked & "' WHERE ID_EMPLEADO = '" & ID & "' END "
                'convert(varbinary(255),pwdencrypt('" & Pass & "')))")
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
                MsgBox("Empleado Agregado")
                CargaGrid()
                Me.TxtCodigo.Text = ""
                Me.TxtNombre.Text = ""
                Me.Txtpass.Text = ""
                Me.Txtcpass.Text = ""
                CodEmpMov = ""
                Me.TxtCodigo.Focus()
            Else
                MsgBox("No coincide la contraseña")
                Me.Txtpass.Text = ""
                Me.Txtcpass.Text = ""
                Me.Txtpass.Focus()
            End If
        End If

        'Me.TxtRuta.Text = Nothing
        'Me.TxtRuta.Focus()
    End Sub

    Private Sub Busqueda()
        Dim Id As String

        Id = Me.TxtCodigo.Text
        Dim lectura As SqlDataReader


        Dim CmdStr As New SqlCommand("declare @existe int set @existe=0 IF EXISTS(SELECT * FROM EmpleadosMoviles WHERE ID_EMPLEADO = '" & Id & "') " & _
                                "Begin set @existe=1 end select @existe", SqlCnn)

        lectura = CmdStr.ExecuteReader
        Try
            While lectura.Read
                dato = lectura.GetInt32(0)
            End While

            lectura.Close()

        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try
        Return

    End Sub

    Private Sub FrmEmpMov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        'Dim SFD As New AutoCompleteStringCollection
        'Me.TBoxBuscaDescrip.AutoCompleteCustomSource = DataHelper.LoadAutoComplete()
        'Me.TBoxBuscaDescrip.AutoCompleteMode = AutoCompleteMode.Suggest
        'Me.TBoxBuscaDescrip.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub CargaGrid()

        Dim SqlSel As New SqlDataAdapter("SELECT Id_Empleado as CLAVE, nombre as NOMBRE, CAST (PWDENCRYPT(pass) AS VARCHAR) as PASS, Activo FROM EMPLEADOSMOVILES ORDER BY Id_Empleado", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGEmpAsig
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub DGEmpAsig_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpAsig.CellClick
        If e.RowIndex > -1 Then
            CodEmpMov = DGEmpAsig.Rows(e.RowIndex).Cells("CLAVE").Value
            TxtCodigo.Text = DGEmpAsig.Rows(e.RowIndex).Cells("CLAVE").Value
            TxtNombre.Text = DGEmpAsig.Rows(e.RowIndex).Cells("NOMBRE").Value
            If DGEmpAsig.Rows(e.RowIndex).Cells("Activo").Value Is DBNull.Value Then
                Me.ChActivo.Checked = False
            Else
                If DGEmpAsig.Rows(e.RowIndex).Cells("Activo").Value = True Then
                    Me.ChActivo.Checked = True
                Else
                    Me.ChActivo.Checked = False
                End If
            End If
            Me.TxtCodigo.Enabled = False
            Txtcpass.Text = "11111111"
            Txtpass.Text = "11111111"
        End If
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        'Dim SqlInsEmp As New SqlCommand
        'Dim CmdStr As String
        'Dim ID As Int32
        'ID = CInt(Me.TxtCodigo.Text)
        'CmdStr = "DELETE FROM Empleadosmoviles WHERE ID_EMPLEADO = '" & ID & "' "
        ''convert(varbinary(255),pwdencrypt('" & Pass & "')))")
        'With SqlInsEmp
        '    .CommandText = CmdStr
        '    .Connection = SqlCnn
        'End With

        'Try
        '    SqlInsEmp.ExecuteNonQuery()
        '    MsgBox("Empleado Borrado")
        'Catch ex As Exception
        '    Error1 = 1
        '    MsgBox(ex.Message.ToString)
        'End Try
        'CargaGrid()
        Me.TxtCodigo.Text = ""
        Me.TxtNombre.Text = ""
        Me.Txtpass.Text = ""
        Me.Txtcpass.Text = ""
        Me.TxtCodigo.Enabled = True
        Me.TxtCodigo.Focus()
        CodEmpMov = ""
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim SqlSel As New SqlDataAdapter("SELECT Id_Empleado as CLAVE, nombre as NOMBRE, CAST (PWDENCRYPT(pass) AS VARCHAR) as PASS, Activo FROM EMPLEADOSMOVILES where NOMBRE like '%" & Me.TBoxBuscaDescrip.Text & "%'  ORDER BY Id_Empleado ", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGEmpAsig
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
       
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not (Char.IsNumber(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub DGEmpAsig_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpAsig.CellContentClick

    End Sub
End Class