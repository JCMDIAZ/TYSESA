Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO


Public Class FrmAsignacionRuta
    Dim agregaSEL, quitaSEL As String
    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmAsignacionRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CargaUsuario()
        CargaEmpleado()
        'CargaGrid()
    End Sub

    'Private Sub CargaUsuario()
    '    Dim SqlSelRuta As New SqlCommand("SELECT Nombre From Rutas ORDER BY Nombre", SqlCnn)
    '    Dim SqlRead As SqlDataReader
    '    Try
    '        SqlRead = SqlSelRuta.ExecuteReader
    '        While SqlRead.Read
    '            Me.CmbRuta.Items.Add(SqlRead.GetString(0))
    '        End While
    '        SqlRead.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '    End Try
    'End Sub

    Private Sub CargaEmpleado()
        Dim SqlSelEmp As New SqlCommand("SELECT Nombre From EMPLEADOSMOVILES ORDER BY Nombre", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.ComboBox1.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    'Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click

    '    Dim dato As Integer

    '    '----------------------------------------------------------------
    '    Dim IdRuta, IdEmp As String

    '    IdRuta = Me.CmbRuta.Text
    '    IdEmp = Me.ComboBox1.Text
    '    Dim lectura As SqlDataReader


    '    Dim CmdStr1 As New SqlCommand("declare @IDRUTA1 int, @IDEMP1 int set @IDRUTA1 = (SELECT IDRUTA FROM RUTAS WHERE NOMBRE = '" & IdRuta & "') " & _
    '                            "set @IDEMP1 = (SELECT ID_EMPLEADO FROM EMPLEADOSMOVILES WHERE NOMBRE = '" & IdEmp & "') " & _
    '                            "IF NOT EXISTS(SELECT * FROM ASIGNACIONRUTA WHERE Id_Empleado = @IDEMP1 AND Id_Ruta = @IDRUTA1) " & _
    '                            "Begin INSERT INTO ASIGNACIONRUTA (Id_Empleado, Id_ruta) Values (@IDEMP1,@IDRUTA1) End", SqlCnn)

    '    lectura = CmdStr1.ExecuteReader
    '    Try
    '        While lectura.Read
    '            dato = lectura.GetInt32(0)
    '        End While

    '        lectura.Close()

    '    Catch ex As Exception
    '        Error1 = 1
    '        MsgBox(ex.Message.ToString)
    '    End Try

    '    '---------------------------------------------------------------------------------------

    '    If dato = 0 Then
    '        MsgBox("Se ha guardado la asignación")
    '    End If
    '    CargaGrid()
    'End Sub

    Private Sub CargaGrid()

        Dim SqlSel As New SqlDataAdapter("SELECT b.NOMBRE from ASIGNACIONRUTA a, RUTAS b, EMPLEADOSMOVILES c where a.Id_Ruta = b.IDRUTA and a.Id_Empleado = c.ID_EMPLEADO and c.NOMBRE = '" & Me.ComboBox1.Text & "' ", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGEmpAsig
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Dim SqlSel2 As New SqlDataAdapter("Select NOMBRE from RUTAS where IDRUTA not in (SELECT Id_Ruta from ASIGNACIONRUTA a, RUTAS b, EMPLEADOSMOVILES c where a.Id_Ruta = b.IDRUTA and a.Id_Empleado = c.ID_EMPLEADO)", SqlCnn)
        Dim DS2 As New DataTable
        Try
            SqlSel2.Fill(DS2)
            With Me.DataGridView1
                .DataSource = DS2
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DGEmpAsig_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpAsig.CellClick
        quitaSEL = DGEmpAsig.Rows(e.RowIndex).Cells("NOMBRE").Value
        Me.lbquitarut.Text = quitaSEL.Trim
        Me.lbagregarut.Text = "."
        agregaSEL = Nothing
        'MsgBox(quitaSEL)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        CargaGrid()
    End Sub

    Private Sub AddBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBtn.Click
        If agregaSEL = Nothing Then
            MsgBox("No ha seleccionado ninguna ruta para asignar")
        Else
            'If Me.DGEmpAsig.RowCount > 0 Then
            '    MsgBox("Cuenta con Ruta Asignada")
            '    Exit Sub
            'End If
            Dim Sqlasigna As New SqlCommand("declare @IDRUTA1 int, @IDEMP1 int set @IDRUTA1 = (SELECT IDRUTA FROM RUTAS WHERE NOMBRE = '" & agregaSEL & "') " & _
                                "set @IDEMP1 = (SELECT ID_EMPLEADO FROM EMPLEADOSMOVILES WHERE NOMBRE = '" & Me.ComboBox1.Text & "') " & _
                                "IF NOT EXISTS(SELECT * FROM ASIGNACIONRUTA WHERE Id_Empleado = @IDEMP1 AND Id_Ruta = @IDRUTA1) " & _
                                "Begin INSERT INTO ASIGNACIONRUTA (Id_Empleado, Id_ruta) Values (@IDEMP1,@IDRUTA1) End", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlasigna.ExecuteReader
                While SqlRead.Read
                    'folio = SqlRead.GetValue(0)
                End While
                SqlRead.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
            CargaGrid()
            agregaSEL = Nothing
            Me.lbagregarut.Text = "."
        End If
    End Sub

    Private Sub DelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelBtn.Click
        If quitaSEL = Nothing Then
            MsgBox("No ha seleccionado ninguna ruta para desasignar")
        Else
            Dim Sqlasigna As New SqlCommand("declare @IDRUTA1 int set @IDRUTA1 = (SELECT IDRUTA FROM RUTAS WHERE NOMBRE = '" & quitaSEL & "') " & _
                                            "DELETE ASIGNACIONRUTA WHERE id_ruta = @IDRUTA1 ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlasigna.ExecuteReader
                While SqlRead.Read
                    'folio = SqlRead.GetValue(0)
                End While
                SqlRead.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
            CargaGrid()
            quitaSEL = Nothing
            Me.lbquitarut.Text = "."
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        agregaSEL = Me.DataGridView1.Rows(e.RowIndex).Cells("NOMBRE").Value
        Me.lbagregarut.Text = agregaSEL.Trim
        Me.lbquitarut.Text = "."
        quitaSEL = Nothing
        'MsgBox(agregaSEL)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class