Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Xml
Imports Microsoft.Win32

Public Class MDIPrincipal
    Private time As Int32
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Cree una nueva instancia del formulario secundario.

        Dim ChildForm As New System.Windows.Forms.Form
        ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()

    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Agregar código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregar código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuSalir.Click
        SqlCnn.Close()
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub MDIPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim TCLOS As String = e.CloseReason
        'Application.Restart()
        'If e.CloseReason = Microsoft.Win32.SessionEndReasons.Logoff Then

        '    If System.Windows.Forms.DialogResult.Yes = Windows.Forms.DialogResult.OK Then

        '    End If
        '    MessageBox.Show("User is logging off")
        'ElseIf e.CloseReason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
        '    MessageBox.Show("System is shutting down")
        'End If
        'MsgBox(e.CloseReason)

        If ID > 0 Then
            'Dim Sqldetalle2 As New SqlCommand("UPDATE FECHAREG SET IDCOMPU = NULL, STATUS = 1, FECHAREG2 = GETDATE() where FECHAREG2 is null ", SqlCnn)
            'Dim SqlRead As SqlDataReader
            'Try
            '    SqlRead = Sqldetalle2.ExecuteReader
            '    While SqlRead.Read
            '        'folio = SqlRead.GetValue(0)
            '    End While
            '    SqlRead.Close()
            'Catch ex As SqlException
            '    MsgBox(ex.Message.ToString)
            'End Try
        End If

        'If systemShutdown Then
        '    systemShutdown = False
        '    If (System.Windows.Forms.DialogResult.Yes = MessageBox.Show("", "", MessageBoxButtons.YesNo)) Then
        '        MsgBox("Shutdown")
        '        Dim Sqldetalle2 As New SqlCommand("IF NOT EXISTS(SELECT * FROM FECHAREG) BEGIN INSERT INTO FECHAREG VALUES(NULL,GETDATE(),NULL,0) END ELSE BEGIN UPDATE FECHAREG SET FECHAREG2 = GETDATE() END ", SqlCnn)
        '        Dim SqlRead As SqlDataReader
        '        Try
        '            SqlRead = Sqldetalle2.ExecuteReader
        '            While SqlRead.Read
        '                'folio = SqlRead.GetValue(0)
        '            End While
        '            SqlRead.Close()
        '        Catch ex As SqlException
        '            MsgBox(ex.Message.ToString)
        '        End Try
        '        e.Cancel = False
        '    Else

        '    End If

        'End If

        'Select Case e.CloseReason
        '    Case 3 'CloseReason.UserClosing
        '        'e.Cancel = True
        '        MsgBox("OTRO")
        '        Dim Sqldetalle2 As New SqlCommand("IF NOT EXISTS(SELECT * FROM FECHAREG) BEGIN INSERT INTO FECHAREG VALUES(NULL,GETDATE(),NULL,0) END ELSE BEGIN UPDATE FECHAREG SET FECHAREG2 = GETDATE() END ", SqlCnn)
        '        Dim SqlRead As SqlDataReader
        '        Try
        '            SqlRead = Sqldetalle2.ExecuteReader
        '            While SqlRead.Read
        '                'folio = SqlRead.GetValue(0)
        '            End While
        '            SqlRead.Close()
        '        Catch ex As SqlException
        '            MsgBox(ex.Message.ToString)
        '        End Try
        '        e.Cancel = True
        '    Case 0 'CloseReason.None
        '        'aqui guarda el tiempo que se estuvo usando el sistema
        '        MsgBox("OTRO")
        '        Dim Sqldetalle2 As New SqlCommand("IF NOT EXISTS(SELECT * FROM FECHAREG) BEGIN INSERT INTO FECHAREG VALUES(NULL,GETDATE(),NULL,0) END ELSE BEGIN UPDATE FECHAREG SET FECHAREG2 = GETDATE() END ", SqlCnn)
        '        Dim SqlRead As SqlDataReader
        '        Try
        '            SqlRead = Sqldetalle2.ExecuteReader
        '            While SqlRead.Read
        '                'folio = SqlRead.GetValue(0)
        '            End While
        '            SqlRead.Close()
        '        Catch ex As SqlException
        '            MsgBox(ex.Message.ToString)
        '        End Try
        '    Case 4 'CloseReason.TaskManagerClosing
        '        MsgBox("TASK MANAGER")
        '        Dim Sqldetalle2 As New SqlCommand("IF NOT EXISTS(SELECT * FROM FECHAREG) BEGIN INSERT INTO FECHAREG VALUES(NULL,GETDATE(),NULL,0) END ELSE BEGIN UPDATE FECHAREG SET FECHAREG2 = GETDATE() END ", SqlCnn)
        '        Dim SqlRead As SqlDataReader
        '        Try
        '            SqlRead = Sqldetalle2.ExecuteReader
        '            While SqlRead.Read
        '                'folio = SqlRead.GetValue(0)
        '            End While
        '            SqlRead.Close()
        '        Catch ex As SqlException
        '            MsgBox(ex.Message.ToString)
        '        End Try
        '        e.Cancel = False
        '    Case 6 'CloseReason.ApplicationExitCall
        '        MsgBox("OTRO")

        '        e.Cancel = False
        '    Case 2 'CloseReason.MdiFormClosing
        '        MsgBox("CLOSE FORM")


        '    Case 5 'CloseReason.FormOwnerClosing
        '        MsgBox("OTRO")

        '    Case 1 'CloseReason.WindowsShutDown
        '        MsgBox("OTRO")

        'End Select
    End Sub

    Private Sub MDIPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Conecta()
        'empresa()
        'SqlCnn.Open()

        time = 1
        
        Dim ctl As Control
        Dim ctlMDI As MdiClient
        ' Recorre todos los formularios en busca del formulario buscado por el control de tipo MDIPrincipal
        For Each ctl In Me.Controls
            Try
                'Aqui intentamos  emitir el control para introducir la orden en el MDIPrincipal
                ctlMDI = CType(ctl, MdiClient)
                ' Esto es para establecer el color
                ctlMDI.BackColor = Me.BackColor
            Catch exc As InvalidCastException
            End Try
        Next


        Dim FLog As New FrmLogin
        With FLog
            .TxtUser.Focus()
            .ShowDialog()
        End With

    End Sub

    Private Sub TiposToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposToolStripMenuItem.Click
        'With FrmTipos
        '    .Show(Me)
        'End With
        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Familias" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormFamilias As New FrmTipos
        chFormFamilias.MdiParent = Me
        m_ChildFormNumber += 1
        chFormFamilias.Show()
    End Sub

    Private Sub UnidadesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnidadesToolStripMenuItem.Click
        'With FrmUnidad
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "UNIDAD DE MEDIDA" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormUM As New FrmUnidad
        chFormUM.MdiParent = Me
        m_ChildFormNumber += 1
        chFormUM.Show()
    End Sub



    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        'With FrmAgregaHerramienta
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Productos" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmAgregaHerramienta
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub AlmacenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlmacenesToolStripMenuItem.Click
        'With FrmDeptos
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "ALMACENES" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmDeptos
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        'With FrmMarcas
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Clientes" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmMarcas
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub MnuReconexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReconexion.Click
        If SqlCnn.State = ConnectionState.Closed Then
            Try
                SqlCnn.Open()
                MsgBox("Conectado!!!")
                ConeccionFallida = False
            Catch ex As Exception
                ConeccionFallida = True
                'MsgBox("Revisar coneccion de red")
            End Try
            If ConeccionFallida = True Then
                Dim chFormClieRut As New FrmLogin
                chFormClieRut.MdiParent = Me
                m_ChildFormNumber += 1
                chFormClieRut.Show()
            End If

        End If
    End Sub

    Private Sub InventariosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventariosToolStripMenuItem1.Click
        With FrmEntIni
            .Show(Me)
        End With
    End Sub

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub


    Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click
        'With FrmProveedor
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Proveedores" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmProveedor
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub EntradasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntradasToolStripMenuItem.Click
        With FrmEntradaCompra
            .Show(Me)
        End With
    End Sub

    Private Sub ContadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContadorToolStripMenuItem.Click
        'With printport
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "PUERTO DE IMPRESION" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New printport
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()

    End Sub

    Private Sub PedidosNuevosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With FrmPedidos
            .Show(Me)
        End With
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem.Click
        With BuscaPedido
            .Show(Me)
        End With
    End Sub

    Private Sub ProductosMovsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosMovsToolStripMenuItem.Click
        With PRODUCTOS
            .Show(Me)
        End With
    End Sub

    Private Sub InventariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventariosToolStripMenuItem.Click
        'With FrmInventarios
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Inventarios de Ubicaciones" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormInventarios As New FrmInventarios
        chFormInventarios.MdiParent = Me
        m_ChildFormNumber += 1
        chFormInventarios.Show()
    End Sub

    Private Sub MnuCatalogos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCatalogos.Click

    End Sub

    Private Sub SalidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidasToolStripMenuItem.Click
        With SALIDA
            .Show(Me)
        End With
    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriasToolStripMenuItem.Click
        'With FrmCategorias
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "CATEGORIAS" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormCategorias As New FrmCategorias
        chFormCategorias.MdiParent = Me
        m_ChildFormNumber += 1
        chFormCategorias.Show()
    End Sub

    Private Sub Movimientos2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Movimientos2ToolStripMenuItem.Click
        'With frmmov2
        '    .Show(Me)
        'End With
        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "MOVIMIENTOS" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormCategorias As New frmmov2
        chFormCategorias.MdiParent = Me
        m_ChildFormNumber += 1
        chFormCategorias.Show()
    End Sub

    Private Sub BorrarFoliosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarFoliosToolStripMenuItem.Click
        'With FrmBorraFolios
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "BORRAR FOLIOS" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormCategorias As New FrmBorraFolios
        chFormCategorias.MdiParent = Me
        m_ChildFormNumber += 1
        chFormCategorias.Show()
    End Sub


    Private Sub Movimientos3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Movimientos3ToolStripMenuItem.Click
        With RP
            .Show(Me)
        End With
    End Sub
    Private Sub WebServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebServiceToolStripMenuItem.Click
        With FrmWebServices
            .Show(Me)
        End With
    End Sub

    Private Sub EtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtiquetasToolStripMenuItem.Click
        With FrmNoAlm
            .Show(Me)
        End With
    End Sub

    Private Sub UbicacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbicacionesToolStripMenuItem.Click
        'With FrmUbicaciones
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "UBICACIONES" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmUbicaciones
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub ReorderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GuardaFotosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardaFotosToolStripMenuItem.Click
        With FrmAgrImg
            .Show(Me)
        End With
    End Sub

    Private Sub AsigarArticulosSINIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsigarArticulosSINIDToolStripMenuItem.Click
        With FrmArticulosSNID
            .Show(Me)
        End With
    End Sub

    Private Sub ImprimirBarcodesSINIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirBarcodesSINIDToolStripMenuItem.Click
        With FrmPrinter
            .Show(Me)
        End With
    End Sub

    Private Sub RutasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutasToolStripMenuItem.Click
        'With FrmRutas
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "RUTAS" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmRutas
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub UsuariosMovilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosMovilesToolStripMenuItem.Click
        'With FrmEmpMov
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Usuarios Moviles" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormEmpMob As New FrmEmpMov
        chFormEmpMob.MdiParent = Me
        m_ChildFormNumber += 1
        chFormEmpMob.Show()
    End Sub

    Private Sub AsignacionDeRutaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignacionDeRutaToolStripMenuItem.Click
        'With FrmAsignacionRuta
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Asignacion de Ruta a Empleado" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmAsignacionRuta
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub ExpendedorasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpendedorasToolStripMenuItem.Click
        'With FrmExpendedoras
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Asignacion de Clientes a Rutas" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmExpendedoras
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click
        'With FrmEmpleados
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Usuarios" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormUsua As New FrmEmpleados
        chFormUsua.MdiParent = Me
        m_ChildFormNumber += 1
        chFormUsua.Show()
    End Sub

    Private Sub InventariosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventariosToolStripMenuItem2.Click
        'SE CAMBIA DE UBICACION AL FORMULARIO Reports-13
        'GUARDATOTALES()


        'SE DESHABILITA POR EL DE ABAJO YA QUE ESTA PANTALLA CONTIENE VARIOS SUBMENUS
        'With consinventarios
        '    .Show(Me)
        'End With


        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "REPORTE EXISTENCIAS" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next


        Dim chFormUsua As New Reports_13
        chFormUsua.MdiParent = Me
        m_ChildFormNumber += 1
        chFormUsua.Show()
        'With Reports_13
        '    .Show(Me)
        'End With







        'For i As Integer = 0 To Me.MdiChildren.Length - 1
        '    If Me.MdiChildren(i).Text = "Consulta Inventarios" Then

        '        Me.MdiChildren(i).Close()
        '        Exit For
        '    Else
        '    End If
        'Next

        'Dim chFormUsua As New consinventarios
        'chFormUsua.MdiParent = Me
        'm_ChildFormNumber += 1
        'chFormUsua.Show()
    End Sub

    Private Sub DiferenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiferenciasToolStripMenuItem.Click

    End Sub

    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem.Click
        'With FrmFolios
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "REPARAR INVENTARIO RUTA" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormUsua As New FrmFolios
        chFormUsua.MdiParent = Me
        m_ChildFormNumber += 1
        chFormUsua.Show()
    End Sub

    Private Sub SurtidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SurtidoToolStripMenuItem.Click
        'With FrmRutaSurtido
        '    .Show(Me)
        'End With

        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "Ruta Surtido" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormUsua As New FrmRutaSurtido
        chFormUsua.MdiParent = Me
        m_ChildFormNumber += 1
        chFormUsua.Show()
    End Sub

    Private Sub RevisarPedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisarPedidosToolStripMenuItem.Click

    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AyudaToolStripMenuItem.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Static Sec As Integer, Min As Integer

        'Sec = Sec + 1
        'If ID > 0 And Sec = 60 Then

        '    Dim hr As String = Timer1.ToString.Trim
        '    Dim maq As String
        '    Dim totd As Int32
        '    'Dim Sqldetalle2 As New SqlCommand("declare @stimes int declare @stime int set @stimes = '" & time & "' set @stime = (select time from fechareg where id = '" & ID & "') if @stime is null begin set @stime = 0 end set @stime = @stime + @stimes UPDATE FECHAREG SET IDCOMPU = NULL, FECHAREG2 = GETDATE(), time = @stime where Id = '" & ID & "' ", SqlCnn)
        '    Dim Sqldetalle2 As New SqlCommand("exec Proc_SelIML '" & ID & "', '" & time & "','" & mmaid & "' ", SqlCnn)
        '    Dim SqlRead As SqlDataReader
        '    Timer1.Stop()
        '    Try

        '        If SqlCnn.State = ConnectionState.Closed Then
        '            SqlCnn.Open()
        '        End If

        '        SqlRead = Sqldetalle2.ExecuteReader
        '        While SqlRead.Read
        '            totd = SqlRead.GetValue(2)
        '        End While
        '        SqlRead.Close()
        '        time = 1
        '    Catch ex As SqlException
        '        'MsgBox(ex.Message.ToString)
        '        time = time + 1
        '    End Try
        '    If totd > 0 Then
        '        MsgBox("Usuario caducado")
        '        Close()
        '    End If
        '    Timer1.Start()
        '    Sec = 0
        'End If
    End Sub

    Private Sub PedidosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem1.Click
        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Text = "LEVANTA PEDIDOS" Then

                Me.MdiChildren(i).Close()
                Exit For
            Else
            End If
        Next

        Dim chFormClieRut As New FrmLevanPed
        chFormClieRut.MdiParent = Me
        m_ChildFormNumber += 1
        chFormClieRut.Show()
    End Sub
End Class
