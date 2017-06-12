Imports System.Data.SqlClient
Imports System.Data


Public Class FrmEmpMov

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click

        Dim ID As String
        Dim Nombre, Pass As String

        ID = Me.TxtCodigo.Text
        Nombre = Me.TxtNombre.Text
        Pass = Me.Txtpass.Text

        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("INSERT INTO Empleadosmoviles (ID_EMPLEADO, NOMBRE, PASS) Values ('" & ID & "', '" & Nombre & "',convert(varbinary(255),pwdencrypt('" & Pass & "'))")

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
        'Me.TxtRuta.Text = Nothing
        'Me.TxtRuta.Focus()
    End Sub
End Class