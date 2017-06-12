Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmAturiza

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click, MyBase.Click
        Dim categ As String = ""
        Dim SqlClientes As New SqlCommand("select categoria from usuarios where usuario = '" & Me.TxtUser.Text.Trim & "' and 1 = pwdcompare('" & Me.TxtPWD.Text.Trim & "',contraseña,0)", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                categ = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        UsuCate = categ.Trim
        Me.Close()
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TxtPWD.Focus()
        End If
    End Sub

    Private Sub TxtPWD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPWD.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim categ As String = ""
            Dim SqlClientes As New SqlCommand("select categoria from usuarios where usuario = '" & Me.TxtUser.Text.Trim & "' and 1 = pwdcompare('" & Me.TxtPWD.Text.Trim & "',contraseña,0)", SqlCnn)
            Dim SqlRead As SqlDataReader
            Dim Clientes As New String(Nothing)
            Try
                SqlRead = SqlClientes.ExecuteReader
                While SqlRead.Read
                    categ = SqlRead.GetString(0)
                End While
                SqlRead.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
            UsuCate = categ.Trim
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmAturiza_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtUser.Focus()
    End Sub


    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub
End Class
