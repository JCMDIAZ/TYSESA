Imports System.Data
Imports System.Data.SqlClient
Public Class PRODUCTOS

    Private Sub PRODUCTOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargacliente()
    End Sub
    Private Sub Cargacliente()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From clientes ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBCLIENTE.Items.Add(SqlRead.GetString(0))

            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, favor de capturar el codigo")
                Me.TxtCodigo.Focus()
            Else
                Me.LblDescripcion.Text = Nothing
                Traecodigo()
                Traedes()
                'Traeprecio()
                If Me.LblDescripcion.Text = "." Or Me.LblDescripcion.Text = Nothing Then
                    MsgBox("Error, codigo no valido")
                    Me.TxtCodigo.Focus()
                    Me.TxtCodigo.SelectAll()
                Else

                End If
            End If
        End If
    End Sub



    Public Sub Traecodigo()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim Sqlprecio As New SqlCommand("SELECT [Codigo de producto] FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & "", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                Me.TxtCodigo.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Traedes()
        Dim codigo As String
        codigo = Me.TxtCodigo.Text
        Dim Sqlprecio As New SqlCommand("SELECT [Nombre Corto] FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' or alterno = " & codigo & "", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlprecio.ExecuteReader
            While SqlRead.Read
                Me.LblDescripcion.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim FECDE As Date
        Dim FECA As Date
        Dim FEC1 As String
        Dim FEC2 As String
        FEC1 = Me.DTFECHADE.Text
        FEC2 = Me.DTFECHAA.Text

        Dim erro As Integer
        Dim fam1 As String
        Dim fam2 As String
        Dim Sqlbusmov As New SqlCommand
        Dim CmdStr As New String("SELECT [Codigo de producto] AS CODIGO, SUM(CANT_MOV) as CANT FROM movimientos " & _
                                "WHERE FECHA_MOV BETWEEN '" & FEC1 & "' AND '" & FEC2 & "' ")

        FECDE = Me.DTFECHADE.Text
        FECA = Me.DTFECHAA.Text
        erro = 0
        If FECDE > FECA Then
            MsgBox("FECHA INICIAL ES MAYOR QUE LA FECHA FINAL")
        Else


            If Me.CBCLIENTE.Text = Nothing Then
                MsgBox("Error, requiere seleccionar Cliente")
                erro = 1
                Me.CBCLIENTE.Focus()
            Else
                'MsgBox("agrega cliente")
                CmdStr = CmdStr & "AND CLIEN_MOV = '" & Me.CBCLIENTE.Text & "' "
            End If


            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Error, requiere ingresar codigo")
                erro = 1
                Me.TxtCodigo.Focus()
            Else
                'MsgBox("agrega codigo")
                CmdStr = CmdStr & "AND [Codigo de Producto] = '" & Me.TxtCodigo.Text & "' "
            End If

            CmdStr = CmdStr & "GROUP BY [Codigo de Producto] "
            If erro = 1 Then
                MsgBox("FALTAN DATOS")
            Else

                Cargadatagridusu(CmdStr)

            End If
        End If
    End Sub
    Private Sub Cargadatagridusu(ByVal Cmdstr As String)


        Dim SqlSel As New SqlDataAdapter(Cmdstr, SqlCnn)
        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
            With Me.gridmovi
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        With Reports3
            .Show(Me)
        End With
    End Sub

    Private Sub LblDescripcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblDescripcion.Click

    End Sub
End Class