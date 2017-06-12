Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class RP

    Private Sub Movimientos3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CBCLIENTE.Enabled = False
        Me.CBPROVE.Enabled = False
        Me.CBMOVI.Enabled = False
        Me.TXTCODIGO.Enabled = False
        With CBMOVI
            .Items.Add("ENTRADA")
            .Items.Add("SALIDA")
            '.Items.Add("
            .SelectedIndex = 1
        End With
        Traealmacen()
        Me.Cbalm.SelectedIndex = 0
        CargaPROVE()
        Cargacliente()
        Cargafamilia()

    End Sub
    Public Sub Traealmacen()
        Dim SqlClientes As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY a.almacen", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.Cbalm.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub CargaPROVE()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From Proveedores ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.CBPROVE.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Cargacliente()
        Dim SqlSelcli As New SqlCommand("SELECT NOMBRE FROM RUTAS ORDER BY NOMBRE", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelcli.ExecuteReader
            While SqlRead.Read
                Me.CBCLIENTE.Items.Add(SqlRead.GetString(0))

            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Cargafamilia()
        Dim SqlSelfam As New SqlCommand("SELECT Abreviatura FROM familias ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelfam.ExecuteReader
            While SqlRead.Read
                Me.CbFAM.Items.Add(SqlRead.GetString(0))

            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub CHKFOL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKFOL.CheckedChanged
        If Me.CHKFOL.Checked = True Then
            Me.CBCLIENTE.Enabled = True
            Me.CBMOVI.Enabled = True
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHPROV.Checked = False
            Me.CHKCLI.Checked = False
            Me.CHKFAMP.Checked = False
            Me.CHGLOBAL.Checked = False
            Me.CbFAM.Enabled = False
        Else
            Me.CBCLIENTE.Text = Nothing
        End If
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        If Me.Cbalm.Text = Nothing Then
            MsgBox("Error, favor de capturar el almacen")
            Me.Cbalm.Focus()
        Else
            With Reports_12
                .Show(Me)
            End With
        End If
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub CHKCLI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKCLI.CheckedChanged
        If Me.CHKCLI.Checked = True Then
            Me.CBCLIENTE.Enabled = True
            Me.CBMOVI.Enabled = True
            Me.CHFAC.Checked = False
            Me.CHFAM.Checked = False
            Me.CHPROV.Checked = False
            Me.CHKFOL.Checked = False
            Me.CHKFAMP.Checked = False
            Me.CHGLOBAL.Checked = False
            Me.CHPROD.Checked = False
            Me.CbFAM.Enabled = False
            CBMOVI.SelectedIndex = 1
            Me.CBMOVI.Enabled = False
        Else
            'Me.CBCLIENTE.Enabled = False
            'Me.CBMOVI.Enabled = False
            Me.CBCLIENTE.Text = Nothing
        End If

    End Sub

    Private Sub CHFAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHFAC.CheckedChanged
        If Me.CHFAC.Checked = True Then
            Me.CBPROVE.Enabled = True
            Me.CBMOVI.Enabled = True
            Me.CHKCLI.Checked = False
            Me.CHFAM.Checked = False
            Me.CHPROV.Checked = False
            Me.CHKFOL.Checked = False
            Me.CHKFAMP.Checked = False
            Me.CHGLOBAL.Checked = False
            Me.CHPROD.Checked = False
            Me.CbFAM.Enabled = False

        Else

            Me.CBPROVE.Text = Nothing
        End If
    End Sub

    Private Sub CHFAM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHFAM.CheckedChanged
        If Me.CHFAM.Checked = True Then

            Me.CBMOVI.Enabled = True
            Me.CHKCLI.Checked = False
            Me.CHFAC.Checked = False
            Me.CHPROV.Checked = False
            Me.CHKFOL.Checked = False
            Me.CHKFAMP.Checked = False
            Me.CHGLOBAL.Checked = False
            Me.CHPROD.Checked = False
            Me.CbFAM.Enabled = False

        End If
    End Sub

    Private Sub CHKFAMP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKFAMP.CheckedChanged
        If Me.CHKFAMP.Checked = True Then
            Me.CBPROVE.Enabled = True
            Me.CBMOVI.Enabled = True
            Me.CHKCLI.Checked = False
            Me.CHFAM.Checked = False
            Me.CHPROV.Checked = False
            Me.CHKFOL.Checked = False
            Me.CHFAC.Checked = False
            Me.CHGLOBAL.Checked = False
            Me.CHPROD.Checked = False
            Me.CbFAM.Enabled = False

        Else

            Me.CBPROVE.Text = Nothing
        End If
    End Sub

    Private Sub CHPROV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHPROV.CheckedChanged
        If Me.CHPROV.Checked = True Then
            Me.CBPROVE.Enabled = True
            Me.CBMOVI.Enabled = True
            Me.CHKCLI.Checked = False
            Me.CHFAM.Checked = False
            Me.CHKFAMP.Checked = False
            Me.CHKFOL.Checked = False
            Me.CHFAC.Checked = False
            Me.CHGLOBAL.Checked = False
            Me.CHPROD.Checked = False
            Me.CbFAM.Enabled = False
            CBMOVI.SelectedIndex = 0
            Me.CBMOVI.Enabled = False
        Else

            Me.CBPROVE.Text = Nothing
        End If
    End Sub

    Private Sub CHGLOBAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHGLOBAL.CheckedChanged
        If Me.CHGLOBAL.Checked = True Then
            Me.CBCLIENTE.Enabled = True
            Me.CBMOVI.Enabled = True
            Me.CHKCLI.Checked = False
            Me.CHFAM.Checked = False
            Me.CHKFAMP.Checked = False
            Me.CHKFOL.Checked = False
            Me.CHFAC.Checked = False
            Me.CHPROV.Checked = False
            Me.CHPROD.Checked = False
            Me.CbFAM.Enabled = False

        Else

            Me.CBCLIENTE.Text = Nothing
        End If
    End Sub

    Private Sub CHPROD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHPROD.CheckedChanged
        If Me.CHPROD.Checked = True Then
            Me.TXTCODIGO.Enabled = True
            Me.CBCLIENTE.Enabled = False
            Me.CBMOVI.Enabled = True
            Me.CbFAM.Enabled = True
            Me.CHKCLI.Checked = False
            Me.CHFAM.Checked = False
            Me.CHKFAMP.Checked = False
            Me.CHKFOL.Checked = False
            Me.CHFAC.Checked = False
            Me.CHPROV.Checked = False

        Else

            Me.CBCLIENTE.Text = Nothing
            Me.TXTCODIGO.Text = Nothing

        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCODIGO.KeyPress
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

    Private Sub CBMOVI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBMOVI.SelectedIndexChanged
        If Me.CHKCLI.Enabled = True Then
            If Me.CBMOVI.Text = "ENTRADA" Then
                Me.CBCLIENTE.Enabled = False
                Me.CBCLIENTE.Text = Nothing
                Me.CBPROVE.Enabled = True
            Else
                Me.CBCLIENTE.Enabled = True
                Me.CBPROVE.Enabled = False
                Me.CBPROVE.Text = Nothing
            End If
        End If
    End Sub
End Class