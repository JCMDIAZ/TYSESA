Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class Buscador

    Private Sub Buscador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        Me.TxtDescripcion.Focus()
    End Sub
    Private Sub CargaGrid()
        Dim SqlSel As New SqlDataAdapter("SELECT [Codigo de Producto], Descripcion, Alterno FROM productos ORDER BY Descripcion", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGbusca
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        If Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Favor de capturar la descripcion")
        Else
            Dim SqlSel As New SqlDataAdapter("select [Codigo de producto], Descripcion, alterno from productos where Descripcion like '%" & Me.TxtDescripcion.Text & "%' order by descripcion", SqlCnn)
            Dim DS As New DataTable
            Try
                SqlSel.Fill(DS)
                With Me.DGbusca
                    .DataSource = DS
                End With
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
        End If

    End Sub

    Private Sub DGbusca_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGbusca.CellClick
        Dim DEPTOId As String
        Dim DEPTODESC As String
        Dim DEPTOABR As String
        Dim value As Object = DGbusca.Rows(e.RowIndex).Cells(1).Value
        If value.GetType Is GetType(DBNull) Then Return


        DEPTOId = CType(value, String)

        Dim value1 As Object = DGbusca.Rows(e.RowIndex).Cells(0).Value
        Dim value2 As Object = DGbusca.Rows(e.RowIndex).Cells(2).Value

        DEPTODESC = CType(value1, String)
        DEPTOABR = CType(value2, String)

        Me.TxtCodigo.Text = DEPTODESC
        Me.TxtDescripcion.Text = DEPTOId
        Me.Txtalterno.Text = DEPTOABR
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        Me.TxtCodigo.Text = Nothing
        Me.TxtDescripcion.Text = Nothing
        Me.Txtalterno.Text = Nothing
        Me.TxtDescripcion.Focus()
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub
    Private Sub TxtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcion.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtDescripcion.Text = Nothing Then
                MsgBox("Error, favor de capturar la Descripcion")
                Me.TxtDescripcion.Focus()
            Else
                Dim SqlSel As New SqlDataAdapter("select [Codigo de producto], Descripcion, alterno from productos where Descripcion like '%" & Me.TxtDescripcion.Text & "%' order by descripcion", SqlCnn)
                Dim DS As New DataTable
                Try
                    SqlSel.Fill(DS)
                    With Me.DGbusca
                        .DataSource = DS
                    End With
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

            End If

        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.lbform.Text = 0 Then
            FrmEntradaCompra.TxtCodigo.Text = Me.TxtCodigo.Text
            FrmEntradaCompra.TxtCodigo.Focus()
            Me.Close()
        End If
        If Me.lbform.Text = "1" Then
            SALIDA.TxtCodigo.Text = Me.TxtCodigo.Text
            SALIDA.TxtCodigo.Focus()
            Me.Close()
        End If
        If Me.lbform.Text = "3" Then
            FrmInventarios.TxtCodigo.Text = Me.TxtCodigo.Text
            FrmInventarios.TxtCodigo.Focus()
            Me.Close()
        End If
        If Me.lbform.Text = "4" Then
            FrmAgregaHerramienta.TxtCapacidad.Text = Me.TxtCodigo.Text
            FrmAgregaHerramienta.TxtCapacidad.Focus()
            Me.Close()
        End If
    End Sub
End Class