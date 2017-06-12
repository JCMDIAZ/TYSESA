Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Xml
Imports System.IO

Public Class FrmLogin

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        If Me.TxtPWD.Text = Nothing Or Me.TxtUser.Text = Nothing Then
            MsgBox("Error, favor de capturar los valores")
            Me.TxtUser.Focus()
        Else
            If ConeccionFallida = True Then

                Conecta(Me.TBoxServidor.Text)
            End If
            If ConeccionFallida = True Then
                MsgBox("No se pudo conectar al Servidor")
                Exit Sub
            End If
            If ValidaUsuario(Me.TxtUser.Text, Me.TxtPWD.Text) = 0 Then
                MsgBox("Error, usuario no valido")
                With Me
                    .TxtPWD.Text = Nothing
                    .TxtUser.Text = Nothing
                    .TxtUser.Focus()
                End With
            Else
                USUARIOCONECTA = Login1(Me.TxtUser.Text, Me.TxtPWD.Text).ToString()
                If USUARIOCONECTA = "La pc no esta dado de alta" Then
                    MsgBox(USUARIOCONECTA)
                    Exit Sub
                End If
                If USUARIOCONECTA = "" Then
                    'MsgBox("USUARIO CADUCADO")
                    'Exit Sub
                End If
                MDIPrincipal.StbUSER.Text = Login1(Me.TxtUser.Text, Me.TxtPWD.Text).ToString()
                If MDIPrincipal.StbUSER.Text = "" Then
                    'MsgBox("USUARIO CADUCADO")
                    'Exit Sub
                End If
                MDIPrincipal.StbCAT.Text = categoria(Me.TxtUser.Text, Me.TxtPWD.Text)
                selcategoria()
                cargacat()
                MDIPrincipal.Show()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click

        End
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TxtPWD.Enabled = False             'ConeccionFallida
        'TxtUser.Enabled = False        
        empresa()
        If ConeccionFallida = True Then
            Me.TBoxServidor.Visible = True
            Me.TBoxServidor.SelectAll()
            Me.TBoxServidor.Focus()
        Else
            Me.TBoxServidor.Visible = False
            'empresa()
            Me.TxtUser.Focus()
        End If

    End Sub
    Private Sub empresa()
        '' empresasx()
        'Dim Archivo As New StreamReader("Config.txt")
        Dim a1, a2, a3, a4, empresa As String
        'a1 = Archivo.ReadLine
        'a2 = Archivo.ReadLine
        'a3 = Archivo.ReadLine
        'a4 = Archivo.ReadLine
        'empresa = Archivo.ReadLine
        MDIPrincipal.stbempresa.Text = empresa
        CBEMPRESA.Enabled = False
        Conecta(Me.TBoxServidor.Text)
       
    End Sub
    'Private Sub empresasx()
    '    Dim t02 As Integer = 0
    '    Dim nombrearch As String
    '    Dim d As New DirectoryInfo("bdcfg\")
    '    If d.Exists Then
    '        For Each f As FileInfo In d.GetFiles
    '            If f.Name.ToString.Substring(0, 6) = "Config" Then
    '                nombrearch = f.Name
    '                t02 = nombrearch.IndexOf(".")
    '                nombrearch = nombrearch.Substring(0, t02)
    '                nombrearch = nombrearch.Remove(0, 6)
    '                CBEMPRESA.Items.Add(nombrearch)
    '            End If
    '        Next
    '    Else
    '        MsgBox("No existe carpeta de config en System favor de crearla")
    '    End If
    'End Sub
    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtUser.Text = Nothing Then
                MsgBox("Error, favor de capturar el usuario")
                Me.TxtUser.Focus()
            Else
                Me.TxtPWD.Focus()
            End If
        End If
    End Sub

    Private Sub TxtPWD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPWD.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtPWD.Text = Nothing Then
                MsgBox("Error, favor de capturar el password")
                Me.TxtPWD.Focus()
            Else
                If ConeccionFallida = True Then

                    Conecta(Me.TBoxServidor.Text)
                    If ConeccionFallida = True Then
                        Exit Sub
                    End If
                Else

                End If
                If ValidaUsuario(Me.TxtUser.Text, Me.TxtPWD.Text) = 0 Then
                    MsgBox("Error, usuario no valido")
                    With Me
                        .TxtPWD.Text = Nothing
                        .TxtUser.Text = Nothing
                        .TxtUser.Focus()
                    End With
                Else
                    USUARIOCONECTA = Login1(Me.TxtUser.Text, Me.TxtPWD.Text).ToString()
                    If USUARIOCONECTA = "La pc no esta dado de alta" Then
                        MsgBox(USUARIOCONECTA)
                        Exit Sub
                    End If
                    If USUARIOCONECTA = "" Then
                        'MsgBox("USUARIO CADUCADO")
                        'Exit Sub
                    End If
                    MDIPrincipal.StbUSER.Text = USUARIOCONECTA
                    MDIPrincipal.StbCAT.Text = categoria(Me.TxtUser.Text, Me.TxtPWD.Text)
                    selcategoria()
                    cargacat()
                    selfecha()
                    ipss()
                    logIN()
                    MDIPrincipal.Show()
                    Me.Close()
                    If ConeccionFallida = False Then
                        Dim Sqldetalle2 As New SqlCommand("INSERT INTO FECHAREG (IDCOMPU,FECHAREG1,FECHAREG2,STATUS,TIME) VALUES('" & mmaid & "',GETDATE(),NULL,NULL,NULL) SELECT MAX(Id) from fechareg ", SqlCnn)
                        Dim SqlRead As SqlDataReader
                        Try
                            SqlRead = Sqldetalle2.ExecuteReader
                            While SqlRead.Read
                                ID = SqlRead.GetValue(0)
                            End While
                            SqlRead.Close()
                        Catch ex As SqlException
                            MsgBox(ex.Message.ToString)
                        End Try
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub selcategoria()
        Dim SqlClientes As New SqlCommand("SELECT Categoria FROM usuarios WHERE Nombre = '" & MDIPrincipal.StbUSER.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.lbcat.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub selfecha()
        Dim Sqlfecha As New SqlCommand("declare @date datetime set @date = GETDATE() select @date ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = Sqlfecha.ExecuteReader
            While SqlRead.Read
                MDIPrincipal.StbDate.Text = SqlRead.GetDateTime(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Function cargacat()

        'Dim SqlSelDes As New SqlCommand("SELECT usu,cat,clie,alm,pro,cod,fam,um,ent,sal,inv,ped,rpe,mov,MovL,cpe,cin,cre,cpm,con,imp,BorrFol FROM Categorias Where Categoria = '" & Me.lbcat.Text & "'", SqlCnn)
        Dim SqlSelDes As New SqlCommand("SELECT usu,cat,alm,AsigRut,AsigClieRuta,clie,pro,cod,fam,um,ent,sal,inv,ped,rpe,mov,MovL,cpe,cin,cre,cpm,con,imp,BorrFol,RepCar,Ubi,SurtiRut FROM Categorias Where Categoria = '" & Me.lbcat.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        'Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                'If SqlRead.GetBoolean(0) = True Then
                '    MDIPrincipal.EmpleadosToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.EmpleadosToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(1) = True Then
                '    MDIPrincipal.CategoriasToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.CategoriasToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(2) = True Then
                '    MDIPrincipal.ClientesToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.ClientesToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(3) = True Then
                '    MDIPrincipal.AlmacenesToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.AlmacenesToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(4) = True Then
                '    MDIPrincipal.ProveedoresToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.ProveedoresToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(5) = True Then
                '    MDIPrincipal.ProductosToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.ProductosToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(6) = True Then
                '    MDIPrincipal.TiposToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.TiposToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(7) = True Then
                '    MDIPrincipal.UnidadesToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.UnidadesToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(8) = True Then
                '    MDIPrincipal.EntradasToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.EntradasToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(9) = True Then
                '    MDIPrincipal.SalidasToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.SalidasToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(10) = True Then
                '    MDIPrincipal.InventariosToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.InventariosToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(11) = True Then
                '    MDIPrincipal.PedidosToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.PedidosToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(13) = True Then
                '    MDIPrincipal.InventariosToolStripMenuItem1.Enabled = True
                'Else
                '    MDIPrincipal.InventariosToolStripMenuItem1.Enabled = False
                'End If
                'If SqlRead.GetBoolean(14) = True Then
                '    MDIPrincipal.Movimientos2ToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.Movimientos2ToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(15) = True Then
                '    MDIPrincipal.BuscarToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.BuscarToolStripMenuItem.Enabled = False
                'End If
                ''If SqlRead.GetBoolean(16) = True Then
                ''    MDIPrincipal.InventariosToolStripMenuItem3.Enabled = True
                ''Else
                ''    MDIPrincipal.InventariosToolStripMenuItem3.Enabled = False
                ''End If

                'If SqlRead.GetBoolean(18) = True Then
                '    MDIPrincipal.ProductosMovsToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.ProductosMovsToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(19) = True Then
                '    MDIPrincipal.ContadorToolStripMenuItem.Enabled = True
                '    MDIPrincipal.HelpMenu.Enabled = True
                '    MDIPrincipal.Movimientos3ToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.ContadorToolStripMenuItem.Enabled = False
                '    MDIPrincipal.HelpMenu.Enabled = False
                '    MDIPrincipal.Movimientos3ToolStripMenuItem.Enabled = False
                'End If
                'If SqlRead.GetBoolean(21) = True Then
                '    MDIPrincipal.BorrarFoliosToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.BorrarFoliosToolStripMenuItem.Enabled = False
                'End If
                ''If SqlRead.GetBoolean(21) = True Then
                ''    MDIPrincipal.ContadorToolStripMenuItem.Enabled = True
                ''Else
                ''    MDIPrincipal.ContadorToolStripMenuItem.Enabled = False
                ''End If

                'AsignacionDeRuta
                'Expendedoras
                If SqlRead.GetBoolean(0) = True Then
                    MDIPrincipal.EmpleadosToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.EmpleadosToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(1) = True Then
                    MDIPrincipal.CategoriasToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.CategoriasToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(2) = True Then
                    MDIPrincipal.AlmacenesToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.AlmacenesToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetValue(3) Is DBNull.Value Then
                    MDIPrincipal.AsignacionDeRutaToolStripMenuItem.Visible = False
                Else
                    If SqlRead.GetBoolean(3) = True Then
                        MDIPrincipal.AsignacionDeRutaToolStripMenuItem.Enabled = True
                    Else
                        MDIPrincipal.AsignacionDeRutaToolStripMenuItem.Enabled = False
                    End If
                End If

                If SqlRead.GetValue(4) Is DBNull.Value Then
                    MDIPrincipal.ExpendedorasToolStripMenuItem.Visible = False
                Else
                    If SqlRead.GetBoolean(4) = True Then
                        MDIPrincipal.ExpendedorasToolStripMenuItem.Enabled = True
                    Else
                        MDIPrincipal.ExpendedorasToolStripMenuItem.Enabled = False
                    End If
                End If

                If SqlRead.GetBoolean(5) = True Then
                    MDIPrincipal.ClientesToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.ClientesToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(6) = True Then
                    MDIPrincipal.ProveedoresToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.ProveedoresToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(7) = True Then
                    MDIPrincipal.ProductosToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.ProductosToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(8) = True Then
                    MDIPrincipal.TiposToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.TiposToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(9) = True Then
                    MDIPrincipal.UnidadesToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.UnidadesToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(10) = True Then
                    MDIPrincipal.EntradasToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.EntradasToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(11) = True Then
                    MDIPrincipal.SalidasToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.SalidasToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(12) = True Then
                    MDIPrincipal.InventariosToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.InventariosToolStripMenuItem.Enabled = False
                End If
                'If SqlRead.GetBoolean(13) = True Then
                '    MDIPrincipal.RevisarPedidosToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.RevisarPedidosToolStripMenuItem.Enabled = False
                'End If
                If SqlRead.GetBoolean(14) = True Then
                    MDIPrincipal.InventariosToolStripMenuItem1.Enabled = True
                Else
                    MDIPrincipal.InventariosToolStripMenuItem1.Enabled = False
                End If
                If SqlRead.GetBoolean(14) = True Then
                    MDIPrincipal.Movimientos2ToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.Movimientos2ToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(15) = True Then
                    MDIPrincipal.BuscarToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.BuscarToolStripMenuItem.Enabled = False
                End If
                'If SqlRead.GetBoolean(16) = True Then
                '    MDIPrincipal.InventariosToolStripMenuItem3.Enabled = True
                'Else
                '    MDIPrincipal.InventariosToolStripMenuItem3.Enabled = False
                'End If

                If SqlRead.GetBoolean(18) = True Then
                    MDIPrincipal.ProductosMovsToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.ProductosMovsToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(19) = True Then
                    MDIPrincipal.ContadorToolStripMenuItem.Enabled = True
                    MDIPrincipal.HelpMenu.Enabled = True
                    MDIPrincipal.Movimientos3ToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.ContadorToolStripMenuItem.Enabled = False
                    MDIPrincipal.HelpMenu.Enabled = False
                    MDIPrincipal.Movimientos3ToolStripMenuItem.Enabled = False
                End If
                If SqlRead.GetBoolean(21) = True Then
                    MDIPrincipal.BorrarFoliosToolStripMenuItem.Enabled = True
                Else
                    MDIPrincipal.BorrarFoliosToolStripMenuItem.Enabled = False
                End If
                'If SqlRead.GetBoolean(21) = True Then
                '    MDIPrincipal.ContadorToolStripMenuItem.Enabled = True
                'Else
                '    MDIPrincipal.ContadorToolStripMenuItem.Enabled = False
                'End If

                If SqlRead.GetValue(24) Is DBNull.Value Then
                    MDIPrincipal.PedidosToolStripMenuItem.Visible = False
                Else
                    If SqlRead.GetBoolean(24) = True Then
                        MDIPrincipal.PedidosToolStripMenuItem.Enabled = True
                    Else
                        MDIPrincipal.PedidosToolStripMenuItem.Enabled = False
                    End If
                End If

                If SqlRead.GetValue(25) Is DBNull.Value Then
                    MDIPrincipal.UbicacionesToolStripMenuItem.Visible = False
                Else
                    If SqlRead.GetBoolean(25) = True Then
                        MDIPrincipal.UbicacionesToolStripMenuItem.Enabled = True
                    Else
                        MDIPrincipal.UbicacionesToolStripMenuItem.Enabled = False
                    End If
                End If

                If SqlRead.GetValue(26) Is DBNull.Value Then
                    MDIPrincipal.SurtidoToolStripMenuItem.Visible = False
                Else
                    If SqlRead.GetBoolean(26) = True Then
                        MDIPrincipal.SurtidoToolStripMenuItem.Enabled = True
                    Else
                        MDIPrincipal.SurtidoToolStripMenuItem.Enabled = False
                    End If
                End If

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'Return code

    End Function

    Private Function ipss()
        Dim Hostname As String

        Dim nombreHost As String = System.Net.Dns.GetHostName

        If Environment.GetCommandLineArgs().Length > 1 Then
            Hostname = Environment.GetCommandLineArgs(1)
        Else
            Hostname = Dns.GetHostName
            'Me.TextBox1.Text = Hostname
        End If
        Dim hostInfo As IPHostEntry = Dns.GetHostByName(Hostname)

        For Each ip As System.Net.IPAddress In hostInfo.AddressList
            MDIPrincipal.StbIP.Text = "  IP: " & ip.ToString & "   "
            ip1 = ip.ToString
        Next
    End Function
    Public Sub logIN()
        Dim Sqlin As New SqlCommand("INSERT INTO LogIN VALUES ('" & MDIPrincipal.StbUSER.Text & "', '" & ip1 & "', getdate()) ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = Sqlin.ExecuteReader
            While SqlRead.Read
                'MDIPrincipal.StbDate.Text = SqlRead.GetDateTime(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub CBEMPRESA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBEMPRESA.SelectedIndexChanged
        empresax = CBEMPRESA.Text
        Dim Archivo As New StreamReader("bdcfg\Config" & CBEMPRESA.Text & ".txt")
        Dim a1, a2, a3, a4, empresa As String
        a1 = Archivo.ReadLine
        a2 = Archivo.ReadLine
        a3 = Archivo.ReadLine
        a4 = Archivo.ReadLine
        empresa = Archivo.ReadLine
        MDIPrincipal.stbempresa.Text = empresa
        CBEMPRESA.Enabled = False
        Conecta(Me.TBoxServidor.Text)
        TxtUser.Enabled = True
        Me.TxtPWD.Enabled = True
        TxtUser.Focus()
    End Sub

    Private Sub TxtPWD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPWD.TextChanged

    End Sub

    Private Sub TBoxServidor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBoxServidor.Click
        Me.TBoxServidor.SelectAll()
    End Sub

    Private Sub TBoxServidor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxServidor.TextChanged

    End Sub
End Class
