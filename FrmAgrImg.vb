Imports System.IO
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Threading

Public Class FrmAgrImg
    Dim existe010 As Integer
    Dim existe020 As Integer
    Dim existe030 As Integer
    Private Declare Function ShellEx Lib "shell32.dll" Alias "ShellExecuteA" ( _
        ByVal hWnd As Integer, ByVal lpOperation As String, _
        ByVal lpFile As String, ByVal lpParameters As String, _
        ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
    
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()

            If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
                txtFileToUpload.Text = OpenFileDialog.FileName

            Else 'Cancel
                Exit Sub
            End If
        End Using
    End Sub
    Private Sub GetImagesFromDatabase()
        Try

            'Initialize SQL Server Connection 
            If SqlCnn.State = ConnectionState.Closed Then
                SqlCnn.Open()
            End If
            Dim strSql As String = "SELECT MBarcode AS CODIGO_BARRAS, [Codigo de producto] AS ID_PRESTASHOP, MFecha AS FECHA_ACT, MUser AS USUARIO, MEmpaque AS EMPAQUE, MUnidades AS UNIDADES, MImagen AS IMAGEN, MTipo AS TIPO, MName AS NAME, MIMG AS EXIS_IMG FROM MULTIBARCODE"
            Dim ADAP As New SqlDataAdapter(strSql, SqlCnn)
            Dim DS As New DataSet()
            ADAP.Fill(DS, "FileStore")
            dbGridView.DataSource = DS.Tables("FileStore")

            Dim dgButtonColumn As New DataGridViewButtonColumn
            dgButtonColumn.HeaderText = ""
            dgButtonColumn.UseColumnTextForButtonValue = True
            dgButtonColumn.Text = "View File"
            dgButtonColumn.Name = "ViewFile"
            dgButtonColumn.ToolTipText = "View File"
            dgButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            dgButtonColumn.FlatStyle = FlatStyle.System
            dgButtonColumn.DefaultCellStyle.BackColor = Color.Gray
            dgButtonColumn.DefaultCellStyle.ForeColor = Color.White
            dbGridView.Columns.Add(dgButtonColumn)


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            MessageBox.Show("Could not load the Image")
        End Try
    End Sub

    Private Sub dbGridView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dbGridView.CellContentClick
        Dim strSql As String = ""
        Me.lblUploadStatus.Text = ""
        Try
            Select Case e.ColumnIndex
                Case Is > -1
                    If sender.Columns(e.ColumnIndex).Name = "ViewFile" Then
                        'Dim value As String = dbGridView.Rows(e.RowIndex).Cells("MTipo").Value
                        If (dbGridView.Rows(e.RowIndex).Cells("TIPO").Value Is DBNull.Value) Then
                            MessageBox.Show("El codigo seleccionado no tienen imagen favor de seleccionar otra...")
                        Else
                            Select Case Trim(dbGridView.Rows(e.RowIndex).Cells("TIPO").Value)
                                Case "Image"
                                    'For Image
                                    strSql = "Select MIMAGEN from MULTIBARCODE WHERE MBARCODE='" & dbGridView.Rows(e.RowIndex).Cells("CODIGO_BARRAS").Value & "' "
                                    Dim sqlCmd As New SqlCommand(strSql, SqlCnn)
                                    'Get image data from DB
                                    Dim imageData As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
                                    'Initialize image variable 
                                    Dim newImage As Image = Nothing

                                    If Not imageData Is Nothing Then
                                        'Read image data into a memory stream 
                                        Using ms As New MemoryStream(imageData, 0, imageData.Length)
                                            ms.Write(imageData, 0, imageData.Length)
                                            'Set image variable value using memory stream. 
                                            newImage = Image.FromStream(ms, True)
                                        End Using

                                        'set picture 
                                        PictureBox1.Image = newImage

                                        'Dim myPicForm As New docViewerSubForm(newImage)
                                        'newImage.Save("E:\TESTSave.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                                        'myPicForm.ShowDialog()
                                        'pictureBox1.Image = newImage
                                    End If

                                    'Case ".txt", ".pdf", ".doc"
                                    '    downLoadFile(dbGridView.Rows(e.RowIndex).Cells("FileId").Value, dbGridView.Rows(e.RowIndex).Cells("FileName").Value, dbGridView.Rows(e.RowIndex).Cells("FileType").Value)

                            End Select

                        End If

                    End If

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub
    Private Sub downLoadFile(ByVal iFileId As Long, ByVal sFileName As String, ByVal sFileExtension As String)
        Dim strSql As String
        'For Document
        Try
            'Get image data from gridview column. 
            strSql = "Select Mimagen from MULTIBARCODE WHERE MBarcode=" & iFileId

            Dim sqlCmd As New SqlCommand(strSql, SqlCnn)

            'Get image data from DB
            Dim fileData As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())

            Dim sTempFileName As String = Application.StartupPath & "\" & sFileName

            If Not fileData Is Nothing Then
                'Read image data into a file stream 
                Using fs As New FileStream(sFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    fs.Write(fileData, 0, fileData.Length)
                    'Set image variable value using memory stream. 
                    fs.Flush()
                    fs.Close()
                End Using

                'Open File
                ' 10 = SW_SHOWDEFAULT
                ShellEx(Me.Handle, "Open", sFileName, "", "", 10)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub upLoadImageOrFile(ByVal sFilePath As String, ByVal sFileType As String)
        Dim SqlCom As SqlCommand
        Dim imageData As Byte()
        Dim sFileName As String
        Dim qry As String

        Try
            'Read Image Bytes into a byte array 

            'Initialize SQL Server Connection 
            If SqlCnn.State = ConnectionState.Closed Then
                SqlCnn.Open()
            End If

            imageData = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)

            'Set insert query 
            qry = "if not exists(select * from multibarcode where MBarcode = @barcode) begin insert into multibarcode values(@barcode,@idpresta,@AddedOn,'SQLROBOT',@pressentacion,@unidades, @ImageData,@FileType,@FileName,'1') end else " & _
            "update multibarcode set [codigo de producto] = @idpresta, Mempaque = @pressentacion, Munidades = @unidades, MImagen = @ImageData, Mtipo = @FileType, MName = @FileName, MIMG = '1' where Mbarcode = @barcode"

            'Initialize SqlCommand object for insert. 
            SqlCom = New SqlCommand(qry, SqlCnn)

            'We are passing File Name and Image byte data as sql parameters.
            SqlCom.Parameters.Add(New SqlParameter("@barcode", txtbarcode.Text))
            SqlCom.Parameters.Add(New SqlParameter("@idpresta", TxtCodigo.Text))
            SqlCom.Parameters.Add(New SqlParameter("@FileName", sFileName))
            SqlCom.Parameters.Add(New SqlParameter("@unidades", txtunidades.Text))
            SqlCom.Parameters.Add(New SqlParameter("@ImageData", DirectCast(imageData, Object)))
            SqlCom.Parameters.Add(New SqlParameter("@pressentacion", CmbTipo.Text))
            SqlCom.Parameters.Add(New SqlParameter("@FileType", sFileType))
            SqlCom.Parameters.Add(New SqlParameter("@AddedOn", Now()))

            SqlCom.ExecuteNonQuery()
            lblUploadStatus.Text = "File uploaded successfully"

            Me.txtFileToUpload.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            lblUploadStatus.Text = "File could not uploaded"
        End Try

    End Sub
    'Open file in to a filestream and read data in a byte array. 
    Private Function ReadFile(ByVal sPath As String) As Byte()
        'Initialize byte array with a null value initially. 
        Dim data As Byte() = Nothing

        'Use FileInfo object to get file size. 
        Dim fInfo As New FileInfo(sPath)
        Dim numBytes As Long = fInfo.Length

        'Open FileStream to read file 
        Dim fStream As New FileStream(sPath, FileMode.Open, FileAccess.Read)

        'Use BinaryReader to read file stream into byte array. 
        Dim br As New BinaryReader(fStream)

        'When you use BinaryReader, you need to supply number of bytes to read from file. 
        'In this case we want to read entire file. So supplying total number of bytes. 
        data = br.ReadBytes(CInt(numBytes))

        Return data
    End Function
    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog

        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True

        openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.GIF)|*.bmp;*.jpg;*.jpeg;*.GIF|" + _
            "PNG files (*.png)|*.png|text files (*.text)|*.txt|doc files (*.doc)|*.doc|pdf files (*.pdf)|*.pdf"


        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        Return openFileDialog
    End Function
    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        If Me.TxtCodigo.Text = Nothing Or Me.txtbarcode.Text = Nothing Or Me.txtFileToUpload.Text = Nothing Or Me.CmbTipo.Text = Nothing Or Me.txtunidades.Text = Nothing Then
            MsgBox("Favor de ingresar todos los datos¡¡")
        Else
            If existe030 = 1 Then
                Me.lblUploadStatus.Text = ""
                If LTrim(RTrim(txtFileToUpload.Text)) = "" Then
                    lblUploadStatus.Text = "Enter File Name"
                    txtFileToUpload.Focus()
                    Exit Sub
                End If
                'Call Upload Images Or File
                Dim sFileToUpload As String = ""
                sFileToUpload = LTrim(RTrim(txtFileToUpload.Text))
                Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                'If StrComp(Extension, ".bmp", CompareMethod.Text) = 0 Or Extension = ".jpg" Or Extension = ".img" Or Extension = ".png" Or Extension = ".gif" Then
                If StrComp(Extension, ".bmp", CompareMethod.Text) = 0 Or _
                StrComp(Extension, ".jpg", CompareMethod.Text) = 0 Or _
                StrComp(Extension, ".jpeg", CompareMethod.Text) = 0 Or _
                StrComp(Extension, ".png", CompareMethod.Text) = 0 Or _
                StrComp(Extension, ".gif", CompareMethod.Text) = 0 Then
                    upLoadImageOrFile(sFileToUpload, "Image")
                Else 'Pass the extension
                    upLoadImageOrFile(sFileToUpload, Extension)
                End If
                dbGridView.DataSource = Nothing
                dbGridView.Columns.Clear()
                GetImagesFromDatabase()
            Else
                MsgBox("No existe ID de Prestashop favor de ingresar uno valido; si ya existe favor de sincronizar nuevamente la base de datos")
            End If
            
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Application.EnableVisualStyles()

        ' Add any initialization after the InitializeComponent() call

        Me.lblUploadStatus.Text = ""

        'SqlCnn = New SqlConnection(SConnectionString)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FrmAgrImg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With CmbTipo
            .Items.Add("PZA")
            .Items.Add("BOX")
            .Items.Add("BOLSA")
            .Items.Add("LITRO")
            .Items.Add("GALON")
            .Items.Add("JUEGO")
            .SelectedIndex = Nothing
        End With
        dbGridView.DataSource = Nothing
        dbGridView.Columns.Clear()
        GetImagesFromDatabase()
        txtbarcode.Focus()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        dbGridView.DataSource = Nothing
        dbGridView.Columns.Clear()
        GetImagesFromDatabase()
    End Sub

    Private Sub CmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipo.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TxtCodigo.Text = Nothing Then
            MsgBox("Favor de capturar el id de prestashop")
        Else
            TraeDescripcion()
        End If
    End Sub
    Private Function TraeDescripcion()
        Dim SqlSelDes As New SqlCommand("SELECT [Nombre corto] From productos WHERE [Codigo de producto] = '" & Me.TxtCodigo.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read

                If SqlRead.IsDBNull(0) = True Then
                    MsgBox("El id no existe")
                    existe030 = 0
                    TxtCodigo.SelectAll()
                    TxtCodigo.Focus()
                Else
                    existe030 = 1
                    Me.TxtDescripcion.Text = SqlRead.GetString(0)
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Function

    Private Function TraeCodigoBarras()
        existe010 = 0
        Dim SqlSelDes As New SqlCommand("SELECT a.[Codigo de producto] AS IDPRESTASHOP, [Nombre Corto] AS DESCRIPCION, Mempaque AS EMPAQUE, Munidades AS UNIDADES, MName AS NOMBRE_IMAGEN, MIMG AS EXISTE_IMG From productos a, multibarcode b  WHERE a.[Codigo de producto] = b.[Codigo de producto] and b.MBarcode = '" & Me.txtbarcode.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read

                If SqlRead.IsDBNull(0) = True Then
                    existe010 = 0
                    CmbTipo.Focus()
                    existe020 = 0
                Else
                    existe010 = 1
                    existe030 = 1
                    Me.TxtCodigo.Text = SqlRead.GetString(0)
                    Me.TxtDescripcion.Text = SqlRead.GetString(1)
                    Me.CmbTipo.Text = SqlRead.GetString(2)
                    Me.txtunidades.Text = SqlRead.GetInt32(3)
                    If Not SqlRead.IsDBNull(4) Then
                        Me.txtFileToUpload.Text = SqlRead.GetString(4)
                    End If
                    existe020 = SqlRead.GetInt32(5)
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return existe010
    End Function

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Favor de capturar el id de prestashop")
            Else
                TraeDescripcion()
            End If
        End If
    End Sub

    Private Sub txtbarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarcode.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.TxtCodigo.Text = Nothing Then
                MsgBox("Favor de capturar el id de prestashop")
            Else
                If TraeCodigoBarras() = 1 Then
                    Dim sqlCmd As New SqlCommand("Select MIMAGEN from MULTIBARCODE WHERE MBARCODE='" & txtbarcode.Text & "' ", SqlCnn)
                    Dim imageData As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
                    Dim newImage As Image = Nothing
                    If Not imageData Is Nothing Then
                        Using ms As New MemoryStream(imageData, 0, imageData.Length)
                            ms.Write(imageData, 0, imageData.Length)
                            newImage = Image.FromStream(ms, True)
                        End Using
                        PictureBox1.Image = newImage
                    End If
                    'Catch ex As Exception
                    '    MessageBox.Show(ex.ToString())
                    'End Try
                End If
            End If
        End If
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click
        Me.TxtCodigo.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.CmbTipo.Text = ""
        Me.txtunidades.Text = ""
        Me.txtFileToUpload.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.txtbarcode.Text = Nothing Then
            MsgBox("Favor de capturar el codigo de barras")
        Else
            Me.TxtCodigo.Enabled = True
            Me.TxtDescripcion.Text = ""
            Me.CmbTipo.Enabled = True
            Me.txtunidades.Enabled = True
            Me.txtFileToUpload.Enabled = True
            TraeCodigoBarras()
            If existe020 = 1 Then
                Dim sqlCmd As New SqlCommand("Select MIMAGEN from MULTIBARCODE WHERE MBARCODE='" & txtbarcode.Text & "' ", SqlCnn)
                Dim imageData As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
                Dim newImage As Image = Nothing
                If Not imageData Is Nothing Then
                    Using ms As New MemoryStream(imageData, 0, imageData.Length)
                        ms.Write(imageData, 0, imageData.Length)
                        newImage = Image.FromStream(ms, True)
                    End Using
                    PictureBox1.Image = newImage
                End If
            End If
        End If
    End Sub

End Class