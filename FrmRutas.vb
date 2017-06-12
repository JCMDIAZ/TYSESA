Imports System.Data.SqlClient
Imports System.Data

Public Class FrmRutas
    Dim dato As Integer
    Private IDRUT As Int32
    Private Exis As Boolean
    Private nomr As String

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        Dim Ruta As String
        Ruta = Me.TxtRuta.Text
        If Me.TxtRuta.Text = Nothing Then
            MsgBox("Error, los campos son obligatorios")
        Else
            Dim resp
            guardayactu()
            If Exis = True Then


                resp = MsgBox("Ya existe ruta:  " & nomr.Trim & " , Deseas modificarlo por " & Ruta.Trim & "?", MsgBoxStyle.OkCancel)
                If resp = vbOK Then
                    Dim SqlInsEmp As New SqlCommand
                    Dim CmdStr As New String("Update Rutas set Nombre = '" & Ruta & "', Activo = '" & Me.ChActivo.Checked & "' where IDRUTA = '" & IDRUT & "'")

                    With SqlInsEmp
                        .CommandText = CmdStr
                        .Connection = SqlCnn
                    End With

                    Try
                        SqlInsEmp.ExecuteNonQuery()
                        MsgBox("Ruta Modificada")
                    Catch ex As Exception
                        Error1 = 1
                        MsgBox(ex.Message.ToString)
                    End Try
                Else
                    Exit Sub

                End If


            Else
                If dato = 1 Then
                    MsgBox("Ruta Ya Registrada")
                Else
                    Dim SqlInsEmp As New SqlCommand
                    Dim CmdStr As New String("INSERT INTO Rutas (Nombre, Activo) VALUES ('" & Ruta & "', '" & Me.ChActivo.Checked & "')")

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
                    MsgBox("Ruta Agregada")
                End If


            End If
            CargaGrid()
            Me.TxtRuta.Text = Nothing
            Me.TxtRuta.Focus()
        End If

    End Sub

    Private Sub guardayactu()
        Dim ruta As String

        ruta = Me.TxtRuta.Text
        Dim lectura As SqlDataReader


        Dim CmdStr As New SqlCommand("declare @existe int set @existe=0 IF EXISTS(SELECT * FROM rutas WHERE nombre = '" & ruta & "') " & _
                                "Begin set @existe=1 end select @existe", SqlCnn)

                                
       
        Try
            lectura = CmdStr.ExecuteReader
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

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
    End Sub
    Private Sub CargaGrid()

        Dim SqlSel As New SqlDataAdapter("SELECT IDRUTA AS IDRUT, NOMBRE as RUTA, Activo as Activo FROM RUTAS order by idruta", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DataGridView1
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Me.DataGridView1.Columns("IDRUT").Visible = False
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex > -1 Then
            TxtRuta.Text = DataGridView1.Rows(e.RowIndex).Cells("RUTA").Value
            nomr = DataGridView1.Rows(e.RowIndex).Cells("RUTA").Value
            IDRUT = DataGridView1.Rows(e.RowIndex).Cells("IDRUT").Value
            If DataGridView1.Rows(e.RowIndex).Cells("Activo").Value Is DBNull.Value Then
                Me.ChActivo.Checked = False
            Else
                If DataGridView1.Rows(e.RowIndex).Cells("Activo").Value = True Then
                    Me.ChActivo.Checked = True
                Else
                    Me.ChActivo.Checked = False
                End If
            End If
            Exis = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim SqlSel As New SqlDataAdapter("SELECT IDRUTA AS IDRUT, NOMBRE as RUTA FROM RUTAS where NOMBRE like '%" & Me.TBoxBuscaDescrip.Text & "%' order by idruta", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DataGridView1
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Me.DataGridView1.Columns("IDRUT").Visible = False


    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.TxtRuta.Text = ""
        IDRUT = 0
        Exis = False
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class