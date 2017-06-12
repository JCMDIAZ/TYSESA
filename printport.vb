Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
'Imports System.Drawing
Imports System.Management

Public Class printport
    Dim BARCODEPRINT As String
    Dim REPORTESPRINT As String
    Dim CODEBAR, FECHAENT, FECHACADENT, LOTEENT, FACE, TIPOE, PRESENTACION, MODOE, DESCRENT, TIPOCAJAE As String
    Dim LOTESAL, TIPOSAL, FECHASAL, FOLIOSAL, IDPEDSAL, CLIENTESAL, DIRCLIENSAL, OCSAL, OBSSAL, CADSAL, PROTOSAL, CAJASAL, LTSSAL, ZONASAL, HASAL, CULTSAL, tipocaja, descrsal, CODESA As String
    Dim CANTETIQUETAS, CANTXTARE As Integer
    Dim totale, LTSXTIPO As Decimal
    Dim unidades, nomcode, elcode As String

    Dim codeimp As String
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean


    Public Function PrinterIsOnline(ByVal sPrinterName As String) As Boolean
        '// Set management scope
        Dim scope As ManagementScope = New ManagementScope("\root\cimv2")
        scope.Connect()

        '// Select Printers from WMI Object Collections
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Printer")

        Dim printerName As String = String.Empty
        For Each printer As ManagementObject In searcher.Get()
            printerName = printer("Name").ToString()
            Debug.Print(printerName)
            If (printerName.Equals(sPrinterName)) Then
                If (printer("WorkOffline").ToString().ToLower().Equals("true")) Then
                    ' Printer is offline by user
                    Return False
                Else
                    ''Dim ntprint As String = printer.
                    'If (printer("Online").ToString().ToLower().Equals("true")) Then
                    '    ' Printer is offline by user
                    '    Return False
                    'Else
                    '    ' Printer is not offline
                    '    Return True
                    'End If
                    '' Printer is not offline
                    Return True
                End If
            End If
        Next
    End Function ' PrinterIsOnline

    Sub listadeimp()

        Try
            CBoxImpresoras.Items.Clear()
            For Each Impresora As String In PrinterSettings.InstalledPrinters
                CBoxImpresoras.Items.Add(Impresora)
            Next
            'ObtenerImpresoraPredeterminada()
        Catch ex As Exception


        End Try

    End Sub

    Private Sub guardaimp()
        Dim SqlSelDes As New SqlCommand("UPDATE printers SET codigobarras = '" & Me.CBoxImpresoras.SelectedItem & "'  ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            'While SqlRead.Read
            '    Me.Lblfolio.Text = SqlRead.GetString(0)
            'End While
            SqlRead.Close()
            Me.ChBoxTimpr.Checked = False
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'Return code
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Me.CheckBox1.Checked = True Then
            traefoliopr()
        End If
        If Me.CheckBox2.Checked = True Then
            printsolocode()
            printcode()
            printcode2()
        End If

    End Sub

    Private Sub BTNFOLIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNFOLIO.Click
        If Me.CBFOLIOS.Text = "" Then
            MsgBox("Selecciona un Folio")
            Me.CBFOLIOS.Focus()
            Exit Sub
        End If
        Dim r As New rptsalidas
        Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        Dim t As CrystalDecisions.CrystalReports.Engine.Table
        Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        Dim td As New CrystalDecisions.Shared.TableLogOnInfo

        Dim Archivo As New StreamReader("Config.txt")
        Dim Server, BD, User1, PWD1 As String
        Server = Archivo.ReadLine
        BD = Archivo.ReadLine
        User1 = Archivo.ReadLine
        PWD1 = Archivo.ReadLine

        With cx

            .ServerName = Server
            .DatabaseName = BD
            .UserID = User1
            .Password = PWD1

        End With
        ts = r.Database.Tables
        For Each t In ts
            td = t.LogOnInfo
            td.ConnectionInfo = cx
            t.ApplyLogOnInfo(td)
        Next

        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & MDIPrincipal.stbempresa.Text & "'"
        r.RecordSelectionFormula = "({Movimientos.ID_MOVIMIENTO} = '" & Me.CBFOLIOS.Text & "')"
        r.PrintToPrinter(1, True, 0, 0)

    End Sub

    Private Sub printport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SELECTPRINTER()
    End Sub

    Private Sub CARGAFOL()
        Dim SqlSel As New SqlCommand("SELECT ID_MOVIMIENTO FROM MOVIMIENTOS ORDER BY ID_MOVIMIENTO", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSel.ExecuteReader
            While (SqlRead.Read)
                Me.CBFOLIOS.Items.Add(SqlRead.GetString(0).ToString)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub printers(ByVal folios As String)
        Dim r As New rptsalidas
        Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        Dim t As CrystalDecisions.CrystalReports.Engine.Table
        Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        Dim td As New CrystalDecisions.Shared.TableLogOnInfo

        Dim Archivo As New StreamReader("Config.txt")
        Dim Server, BD, User1, PWD1 As String
        Server = Archivo.ReadLine
        BD = Archivo.ReadLine
        User1 = Archivo.ReadLine
        PWD1 = Archivo.ReadLine

        With cx

            .ServerName = Server
            .DatabaseName = BD
            .UserID = User1
            .Password = PWD1

        End With
        ts = r.Database.Tables
        For Each t In ts
            td = t.LogOnInfo
            td.ConnectionInfo = cx
            t.ApplyLogOnInfo(td)
        Next
        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & MDIPrincipal.stbempresa.Text & "'"
        r.RecordSelectionFormula = "({Movimientos.ID_MOVIMIENTO} = '" & folios & "')"
        r.PrintToPrinter(1, True, 0, 0)
    End Sub
    Private Sub traefoliopr()
        Timer1.Enabled = False
        Dim SqlSelDes As New SqlCommand("SELECT PRCODE FROM PRINTS WHERE PRIMP = 'True' AND PRTIPO = 'F' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.Lblfolio.Text = SqlRead.GetString(0)
                code = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        If code = Nothing Then
            Me.Lblfolio.Text = "."
        Else
            printers(code)
            If Me.CheckBox3.Checked = True Then
                printers(code)
            End If
            closefolio(code)
        End If
        Timer1.Enabled = True

        'Return code
    End Sub
    Private Sub printsolocode()
        Timer1.Enabled = False
        CANTETIQUETAS = 1
        'Dim SqlSelDes As New SqlCommand("SELECT PRCODE, PRARCHI FROM PRINTS WHERE PRIMP = 'True' AND PRTIPO = 'C' AND PRES = 'CODE' ", SqlCnn)
        'Dim SqlSelDes As New SqlCommand("SELECT top 1 PRCODE, PRARCHI, dbo.MULTIBARCODE.MUNIDADES, dbo.PRODUCTOS.[Codigo de producto], dbo.PRODUCTOS.[Nombre corto] FROM dbo.MULTIBARCODE INNER JOIN dbo.PRODUCTOS ON dbo.MULTIBARCODE.[Codigo de producto] = dbo.PRODUCTOS.[Codigo de producto] INNER JOIN dbo.PRINTS ON dbo.MULTIBARCODE.[Codigo de producto] = dbo.PRINTS.PRCODE WHERE PRIMP = 'True' AND PRTIPO = 'C' AND PRES = 'CODE' ", SqlCnn)
        Dim SqlSelDes As New SqlCommand("SELECT top 1 PRCODE, PRARCHI, dbo.MULTIBARCODE.MUNIDADES, dbo.PRODUCTOS.[Codigo de producto], dbo.PRODUCTOS.[Nombre corto] FROM dbo.MULTIBARCODE INNER JOIN dbo.PRINTS ON dbo.MULTIBARCODE.MBARCODE = dbo.PRINTS.PRCODE INNER JOIN dbo.PRODUCTOS ON dbo.MULTIBARCODE.[Codigo de producto] = dbo.PRODUCTOS.alterno WHERE PRIMP = 'True' AND PRTIPO = 'C' AND PRES = 'CODE' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)
        Dim cant As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.Lblfolio.Text = SqlRead.GetString(0)
                Me.lbcant.Text = SqlRead.GetString(1)
                code = SqlRead.GetString(0)
                CANTETIQUETAS = SqlRead.GetString(1)
                unidades = SqlRead.GetSqlInt32(2)
                elcode = SqlRead.GetString(3)
                nomcode = SqlRead.GetString(4)
                codeimp = code
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        LOTEENT = code
        If code = Nothing Then
            Me.Lblfolio.Text = "."
        Else
            printers2(code, CANTETIQUETAS)
            'deletecode(code)
        End If
        Timer1.Enabled = True

        'Return code
    End Sub
    Private Sub printcode()
        Timer1.Enabled = False
        CANTETIQUETAS = 1
        'Dim SqlSelDes As New SqlCommand("SELECT PRCODE, PRARCHI FROM PRINTS WHERE PRIMP = 'True' AND PRTIPO = 'C' AND PRES = 'CODE' ", SqlCnn)
        Dim SqlSelDes As New SqlCommand("SELECT top 1 PRCODE, PRARCHI, dbo.MULTIBARCODE.MUNIDADES, dbo.PRODUCTOS.[Codigo de producto], dbo.PRODUCTOS.[Nombre corto] FROM dbo.MULTIBARCODE INNER JOIN dbo.PRODUCTOS ON dbo.MULTIBARCODE.[Codigo de producto] = dbo.PRODUCTOS.[Codigo de producto] INNER JOIN dbo.PRINTS ON dbo.MULTIBARCODE.MBARCODE = dbo.PRINTS.PRCODE WHERE PRIMP = 'True' AND PRTIPO = 'C' AND PRES = 'CODE' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)
        Dim cant As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.Lblfolio.Text = SqlRead.GetString(0)
                Me.lbcant.Text = SqlRead.GetString(1)
                code = SqlRead.GetString(0)
                CANTETIQUETAS = SqlRead.GetString(1)
                unidades = SqlRead.GetSqlInt32(2)
                elcode = SqlRead.GetString(3)
                nomcode = SqlRead.GetString(4)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        LOTEENT = code
        If code = Nothing Then
            Me.Lblfolio.Text = "."
        Else
            printers2(code, CANTETIQUETAS)
            deletecode(code)
        End If
        Timer1.Enabled = True

        'Return code
    End Sub
    Private Sub printcode2()
        Timer1.Enabled = False
        CANTETIQUETAS = 1
        Dim SqlSelDes As New SqlCommand("SELECT PRCODE, PRARCHI FROM PRINTS WHERE PRIMP = 'True' AND PRTIPO = 'C' AND PRES = 'SAL' ", SqlCnn)
        'Dim SqlSelDes As New SqlCommand("SELECT PRCODE, PRARCHI, dbo.MULTIBARCODE.MUNIDADES, dbo.PRODUCTOS.[Codigo de producto] FROM dbo.PRINTS INNER JOIN dbo.PRODUCTOS ON dbo.PRINTS.PRCODE = dbo.PRODUCTOS.[Codigo de producto] INNER JOIN dbo.MULTIBARCODE ON dbo.PRODUCTOS.[Codigo de producto] = dbo.MULTIBARCODE.[Codigo de producto] WHERE PRIMP = 'True' AND PRTIPO = 'C' AND PRES = 'SAL' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)
        Dim cant As New String(Nothing)
        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.Lblfolio.Text = SqlRead.GetString(0)
                Me.lbcant.Text = SqlRead.GetString(1)
                code = SqlRead.GetString(0)
                CANTETIQUETAS = SqlRead.GetString(1)

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        LOTESAL = code
        If code = Nothing Then
            Me.Lblfolio.Text = "."
        Else
            printers3(code, CANTETIQUETAS)
            'deletecode(code)

        End If
        Timer1.Enabled = True

        'Return code
    End Sub

    Private Sub SELECTPRINTER()
        Dim SqlSel01 As New SqlCommand("SELECT TOP 1 * FROM PRINTERS ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSel01.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) Then
                    MsgBox("FAVOR DE CONFIGURAR LAS IMPRESORAS EN TABLA PRINTERS")
                Else
                    BARCODEPRINT = SqlRead.GetString(0)
                    REPORTESPRINT = SqlRead.GetString(1)
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub SELECTBARCODE()
        Dim SqlSel01 As New SqlCommand("SELECT TOP 1 * FROM PRINTERS ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSel01.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) Then
                    MsgBox("FAVOR DE CONFIGURAR LAS IMPRESORAS EN TABLA PRINTERS")
                Else
                    BARCODEPRINT = SqlRead.GetString(0)
                    REPORTESPRINT = SqlRead.GetString(1)
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub closefolio(ByVal folio As String)
        Dim SqlSelDes As New SqlCommand("Delete from prints where prcode = '" & folio & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.Lblfolio.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'Return code
    End Sub
    Private Sub borrarfolios()

        Dim SqlDelDetSalRes As New SqlCommand("DELETE FROM PRINTS ", SqlCnn)
        Try
            SqlDelDetSalRes.ExecuteNonQuery()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim resp
        resp = MsgBox("Esta accion eliminara todas las impresiones pendientes ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            borrarfolios()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Enabled = True Then
            MsgBox("HABILITADA LA IMPRESION DE SALIDA", MsgBoxStyle.OkCancel)
        Else
            MsgBox("DESHABILITADA LA IMPRESION DE SALIDA", MsgBoxStyle.OkCancel)
        End If

    End Sub

    Private Sub printers2(ByVal folios As String, ByVal cant As String)
        'PrintDocument1.PrinterSettings.PrinterName = Trim(BARCODEPRINT)
        'PrintDocument1.Print()


        ETIQUETAENT(LOTEENT)
        DESCRENT = Trim(DESCRENT)
        CODEBAR = Trim(CODEBAR)
        CANTXTARE = Trim(CANTXTARE)
        Dim report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New rptCodeBarras
        'Dim drep As String = Application.StartupPath & "\rptCodeBarras.rpt"
        'Dim report As New ReportDocument
        'report.Load(drep, OpenReportMethod.OpenReportByDefault)

        report.SetParameterValue("Code", LOTEENT)
        report.SetParameterValue("Nombre", nomcode.Trim)
        report.SetParameterValue("Unidades", unidades)
        report.SetParameterValue("Codesinb", elcode.Trim)
        If Me.ChBoxTimpr.Checked = True Then
            Dim p As Int32
            Dim vnomi As String
            For p = 0 To Me.CBoxImpresoras.Items.Count - 1
                vnomi = Me.CBoxImpresoras.Items(p)
                report.PrintOptions.PrinterName = vnomi
                Dim pd As New ReportDocument
                pd.PrintOptions.PrinterName = vnomi
                Dim index As Integer
                Dim hu As Integer = vnomi.ToLower.IndexOf("pdf")
                If hu = -1 Then
                    hu = vnomi.ToLower.IndexOf("fax")

                    If hu = -1 Then
    
                        hu = vnomi.ToLower.IndexOf("fax")
                        If hu = -1 Then
                            hu = vnomi.ToLower.IndexOf("xps")
                            If hu = -1 Then

                            End If
                        End If
                    End If
                End If
                If hu = -1 Then
                    If PrinterIsOnline(vnomi) Then
                        'MsgBox("en linea " & vnomi)
                        Try

                            'MsgBox(report.PrintOptions.PrinterName)
                            report.PrintToPrinter(CANTXTARE, True, 1, 1)
                            deletecode(codeimp)
                        Catch ex As Exception
                            'MsgBox("Impresora no valida o no esta conectada: " & vnomi)
                        End Try
                    Else
                        'MsgBox("fuera de linea")
                    End If
                End If
            Next

        Else

            Try
                'report.PrintOptions.PrinterName = BARCODEPRINT.Trim
                report.PrintOptions.PrinterName = Me.CBoxImpresoras.Text.Trim

                'MsgBox(report.PrintOptions.PrinterName)
                report.PrintToPrinter(CANTETIQUETAS, True, 1, 1)
                'report.PrintToPrinter(CANTXTARE, True, 1, 1)
                deletecode(codeimp)
            Catch ex As Exception
                MsgBox("Impresora no valida o no esta conectada")
            End Try

        End If
    End Sub
    Private Sub printers3(ByVal folios As String, ByVal cant As String)
        'PrintDocument2.PrinterSettings.PrinterName = Trim(BARCODEPRINT)
        'PrintDocument2.Print()
    End Sub

    Private Sub document_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
       Handles PrintDocument1.PrintPage

        ETIQUETAENT(LOTEENT)
        'LOTEENT = Trim(LOTEENT)
        'FECHACADENT = Trim(FECHACADENT)
        'TIPOE = Trim(TIPOE)
        'If TIPOE = "ENT" Then
        'TIPOE = "MATERIA PRIMA"
        'End If
        'FACE = Trim(FACE)
        'PRESENTACION = Trim(PRESENTACION)
        DESCRENT = Trim(DESCRENT)
        CODEBAR = Trim(CODEBAR)
        'TIPOCAJAE = Trim(TIPOCAJAE)
        CANTXTARE = Trim(CANTXTARE)



        'Dim xPos As Single = e.MarginBounds.Left
        'Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        'Dim yPos As Single = prFont.GetHeight(e.Graphics)
        'Dim printFont As New System.Drawing.Font("Device Font 10cpi", 10, System.Drawing.FontStyle.Regular)
        'e.Graphics.DrawString("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4^MD0^JUS^LRN^CI0^XZ", prFont, Brushes.Black, 0, 0)
        'e.Graphics.DrawString("~DG000.GRF,00512,008,", prFont, Brushes.Black, 0, 10)
        'e.Graphics.DrawString(",::::::::::::::::::::::I07070780,I0F8F9FE0,I07CF1CE0,I068B3840,I075330,I06FBB8", prFont, Brushes.Black, 0, 20)
        'e.Graphics.DrawString(",I06731840,I067338E0,I06731FC0,I0E238F80,,::::::::::::::::::::::::::::::^XA", prFont, Brushes.Black, 0, 30)
        'e.Graphics.DrawString("^MMT", prFont, Brushes.Black, 0, 40)
        'e.Graphics.DrawString("^LL0203", prFont, Brushes.Black, 0, 50)
        'e.Graphics.DrawString("^PW406", prFont, Brushes.Black, 0, 60)
        'e.Graphics.DrawString("^LS0", prFont, Brushes.Black, 0, 70)
        'e.Graphics.DrawString("^FT352,64^XG000.GRF,1,1^FS", prFont, Brushes.Black, 0, 80)
        'e.Graphics.DrawString("^FT34,36^A0N,17,16^FH\^FD" & CODEBAR & "^FS", prFont, Brushes.Black, 0, 90)
        'e.Graphics.DrawString("^FT13,36^A0N,17,16^FH\^FDID^FS", prFont, Brushes.Black, 0, 100)
        'e.Graphics.DrawString("^FT137,35^A0N,17,16^FH\^FD" & MDIPrincipal.stbempresa.Text & "^FS", prFont, Brushes.Black, 0, 110)
        'e.Graphics.DrawString("^FT13,167^A0N,13,14^FH\^FD" & DESCRENT & "^FS", prFont, Brushes.Black, 0, 120)
        'e.Graphics.DrawString("^BY3,3,100^FT13,147^B3N,N,,N,N", prFont, Brushes.Black, 0, 130)
        'e.Graphics.DrawString("^FD" & CODEBAR & "F^FS", prFont, Brushes.Black, 0, 140)
        'e.Graphics.DrawString("^FO360,13^GE31,29,2^FS", prFont, Brushes.Black, 0, 150)
        'e.Graphics.DrawString("^PQ" & CANTXTARE & ",0,1,Y^XZ", prFont, Brushes.Black, 0, 160)
        'e.Graphics.DrawString("^XA^ID000.GRF^FS^XZ", prFont, Brushes.Black, 0, 170)
        'e.HasMorePages = False

        'movimeinto de las imrpesoras 
        Dim NuevaImpresionZPL As New ImpresionZPL
        NuevaImpresionZPL.Impresion(DESCRENT, CANTXTARE, _
                                    "SI FUNCIONA", "IMPRIME", _
                                    CODEBAR, "16/11/2016")

    End Sub

    Private Sub deletecode(ByVal folio As String)
        Dim SqlSelDes As New SqlCommand("UPDATE prints SET PRIMP = 'FALSE' where prcode = '" & folio & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.Lblfolio.Text = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'Return code
    End Sub
    Public Function ReimprimeCodigo(ByVal codigo As String) As Integer
        'Dim SqlSelEntIni As New SqlCommand("declare @existe int set @existe = 0 if exists (select * from prints where prcode = '" & codigo & "') BEGIN SET @existe = 1 UPDATE prints SET PRIMP = 'true' where prcode = '" & codigo & "' END SELECT @existe", SqlCnn)
        'Dim SqlRead As SqlDataReader
        'Dim Existe As Integer
        'Existe = 0
        'Try
        '    SqlRead = SqlSelEntIni.ExecuteReader
        '    While SqlRead.Read
        '        Existe = SqlRead.GetValue(0)
        '    End While
        '    SqlRead.Close()
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try
        'Return Existe
        printers2(codigo, CANTETIQUETAS)

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Txtlote.Text = Nothing Then
            MsgBox("Error, Favor de capturar el numero de ID de la etiqueta que se desea reimprimir")
            Txtlote.Focus()
        Else
            ReimprimeCodigo(Txtlote.Text)
            Txtlote.SelectAll()
            Txtlote.Focus()
        End If
        'printcode()

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim resp
        If Me.CheckBox2.Enabled = True Then
            If Me.CheckBox2.Checked = True Then
                resp = MsgBox("HABILITADA LA IMPRESION DE ETIQUETAS", MsgBoxStyle.OkCancel)
                If resp = vbOK Then

                Else
                    Me.CheckBox2.Checked = False
                End If
            Else
                MsgBox("DESHABILITADA LA IMPRESION DE ETIQUETAS", MsgBoxStyle.OkOnly)
                'If resp = vbOK Then

                'Else
                ' Me.CheckBox2.Checked = True
                'End If
            End If

        Else
            MsgBox("DESHABILITADA LA IMPRESION DE ETIQUETAS", MsgBoxStyle.OkCancel)
        End If
    End Sub
    Private Sub ETIQUETAENT(ByVal LOTE As String)
        Dim SqlSelDes As New SqlCommand("SELECT a.[Nombre corto], a.[Codigo de producto], b.PRARCHI FROM productos A, PRINTS B where a.[Codigo de producto] = b.PRCODE AND b.PRTIPO = 'C' AND b.PRCODE = '" & LOTE & "' and b.PRIMP = 'true' ", SqlCnn)
        'Dim SqlSelDes As New SqlCommand("SELECT a.[Nombre corto], a.[Codigo de producto], b.PRARCHI, dbo.MULTIBARCODE.MUNIDADES FROM dbo.PRODUCTOS AS A INNER JOIN dbo.PRINTS AS B ON A.[Codigo de producto] = B.PRCODE INNER JOIN dbo.MULTIBARCODE ON A.[Codigo de producto] = dbo.MULTIBARCODE.[Codigo de producto] where a.[Codigo de producto] = b.PRCODE AND b.PRTIPO = 'C' AND b.PRCODE = '" & LOTE & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)
        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                'LOTEENT = SqlRead.GetString(0)
                'FECHAENT = SqlRead.GetDateTime(1)
                'FECHACADENT = SqlRead.GetString(2)
                'TIPOE = SqlRead.GetString(3)
                'FACE = SqlRead.GetString(4)
                'PRESENTACION = SqlRead.GetString(5)
                DESCRENT = SqlRead.GetString(0)
                'LTSXTIPO = SqlRead.GetInt32(7)
                'totale = SqlRead.GetDecimal(8)
                CODEBAR = SqlRead.GetString(1)
                'TIPOCAJAE = SqlRead.GetString(10)
                CANTXTARE = SqlRead.GetString(2)

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        'Return code
    End Sub
    Private Sub ETIQUETASAL(ByVal FOLIO As String)
        Dim SqlSelDes As New SqlCommand("select B.FECHA_MOV2, B.ID_MOV2, E.PEDIDOSA ,F.Empresa, F.calle, F.noext, F.noint, F.colonia, F.codigop, F.municipio, F.estado, F.pais ,G.PROTOCOLO,D.TIPO,ROUND(B.CANT_MOV2/D.LTSPORTIPO,0)AS CANTCAJAS,SUM(B.CANT_MOV2),B.FACNOT_MOV2, C.[Nombre corto], C.DESCRIPCION, E.ZONASA, E.HASA, E.CULTIVOSA, E.CODESA, B.TIPO_MOV2 " & _
        "FROM LOTEEX2 A, MOVIMIENTOS2 B, PRODUCTOS C, CODESTAR D, SALIDAES E, CLIENTES F, PEDIDOS G " & _
        "WHERE A.[Codigo de producto] = C.[Codigo de producto] AND B.LOTE_MOV2 = A.Numlote2 " & _
        "AND B.ID_MOV2 = E.IDFOLIO AND F.Clave = E.CLIENTESA AND G.ID_PED = E.PEDIDOSA AND B.ID_MOV2 = '" & FOLIO & "' " & _
        "GROUP BY B.FECHA_MOV2, B.ID_MOV2, E.PEDIDOSA ,F.Empresa, F.calle, F.noext, F.noint, F.colonia, F.codigop, F.municipio, F.estado, F.pais ,G.PROTOCOLO,D.TIPO,D.LTSPORTIPO,B.CANT_MOV2,B.FACNOT_MOV2, C.[Nombre corto], C.DESCRIPCION, E.ZONASA, E.HASA, E.CULTIVOSA, E.CODESA, B.TIPO_MOV2 ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)
        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                FECHASAL = SqlRead.GetDateTime(0)
                FOLIOSAL = SqlRead.GetString(1)
                IDPEDSAL = SqlRead.GetString(2)
                CLIENTESAL = SqlRead.GetString(3)
                DIRCLIENSAL = SqlRead.GetString(4)
                DIRCLIENSAL = DIRCLIENSAL & " No " & SqlRead.GetString(5)
                DIRCLIENSAL = DIRCLIENSAL & " Int " & SqlRead.GetString(6)
                DIRCLIENSAL = DIRCLIENSAL & " Col " & SqlRead.GetString(7)
                DIRCLIENSAL = DIRCLIENSAL & " CP " & SqlRead.GetString(8)
                DIRCLIENSAL = DIRCLIENSAL & "," & SqlRead.GetString(9)
                DIRCLIENSAL = DIRCLIENSAL & "," & SqlRead.GetString(10)
                DIRCLIENSAL = DIRCLIENSAL & "," & SqlRead.GetString(11)
                PROTOSAL = SqlRead.GetString(12)
                tipocaja = SqlRead.GetString(13)
                CAJASAL = SqlRead.GetDecimal(14)
                LTSSAL = SqlRead.GetDecimal(15)
                descrsal = SqlRead.GetString(18)
                ZONASAL = SqlRead.GetString(19)
                HASAL = SqlRead.GetString(20)
                CULTSAL = SqlRead.GetString(21)
                CODESA = SqlRead.GetString(22)
                TIPOSAL = SqlRead.GetString(23)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        'Return code
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        ETIQUETASAL(LOTESAL)
        TIPOSAL = Trim(TIPOSAL)
        If TIPOSAL = "SAL" Then
            TIPOSAL = "VENTA"
        End If
        FOLIOSAL = Trim(FOLIOSAL)
        IDPEDSAL = Trim(IDPEDSAL)
        CLIENTESAL = Trim(CLIENTESAL)
        DIRCLIENSAL = Trim(DIRCLIENSAL)
        Dim dir00, dir01, dir02, dir03 As String
        dir00 = DIRCLIENSAL
        If DIRCLIENSAL.Length > 39 Then
            dir01 = dir00.Substring(0, 39)
            dir00 = dir00.Remove(0, 39)
            If dir00.Length > 50 Then
                dir02 = dir00.Substring(0, 50)
                dir00 = dir00.Remove(0, 50)
                If dir00.Length > 50 Then
                    dir03 = dir00.Substring(0, 50)
                Else
                    dir03 = dir00
                End If
            Else
                dir02 = dir00
            End If
        Else
            dir01 = dir00
            dir02 = ""
            dir03 = ""
        End If
        PROTOSAL = Trim(PROTOSAL)
        tipocaja = Trim(tipocaja)
        descrsal = Trim(descrsal)
        ZONASAL = Trim(ZONASAL)
        HASAL = Trim(HASAL)
        CULTSAL = Trim(CULTSAL)
        CODESA = Trim(CODESA)

        Dim xPos As Single = e.MarginBounds.Left
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim yPos As Single = prFont.GetHeight(e.Graphics)
        Dim printFont As New System.Drawing.Font("Device Font 10cpi", 10, System.Drawing.FontStyle.Regular)
        e.Graphics.DrawString("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4^MD0^JUS^LRN^CI0^XZ", prFont, Brushes.Black, 0, 0)
        e.Graphics.DrawString("^XA", prFont, Brushes.Black, 0, 10)
        e.Graphics.DrawString("^MMT", prFont, Brushes.Black, 0, 20)
        e.Graphics.DrawString("^LL0203", prFont, Brushes.Black, 0, 30)
        e.Graphics.DrawString("^PW812", prFont, Brushes.Black, 0, 40)
        e.Graphics.DrawString("^LS0", prFont, Brushes.Black, 0, 50)
        e.Graphics.DrawString("^FT422,750^A0N,25,52^FH\^FD" & FECHASAL & "^FS", prFont, Brushes.Black, 0, 60)
        e.Graphics.DrawString("^FT454,343^A0N,34,76^FH\^FD01.07.13^FS", prFont, Brushes.Black, 0, 70)
        e.Graphics.DrawString("^FT0,1024^XG000.GRF,1,1^FS", prFont, Brushes.Black, 0, 80)
        e.Graphics.DrawString("^FT32,384^XG001.GRF,1,1^FS", prFont, Brushes.Black, 0, 90)
        e.Graphics.DrawString("^FO397,545^GB0,213,4^FS", prFont, Brushes.Black, 0, 100)
        e.Graphics.DrawString("^FO397,256^GB0,136,4^FS", prFont, Brushes.Black, 0, 110)
        e.Graphics.DrawString("^FO25,760^GB761,0,4^FS", prFont, Brushes.Black, 0, 120)
        e.Graphics.DrawString("^BY4,3,150^FT47,928^BCN,,Y,N", prFont, Brushes.Black, 0, 130)
        e.Graphics.DrawString("^FD>:" & CODESA & "^FS", prFont, Brushes.Black, 0, 140)
        e.Graphics.DrawString("^FO25,394^GB762,0,4^FS", prFont, Brushes.Black, 0, 150)
        e.Graphics.DrawString("^FO24,544^GB762,0,5^FS", prFont, Brushes.Black, 0, 160)
        e.Graphics.DrawString("^FT419,686^A0N,25,45^FH\^FD" & CULTSAL & "^FS", prFont, Brushes.Black, 0, 170)
        e.Graphics.DrawString("^FT542,615^A0N,25,45^FH\^FD" & HASAL & "^FS", prFont, Brushes.Black, 0, 180)
        e.Graphics.DrawString("^FT544,581^A0N,25,45^FH\^FD" & ZONASAL & "^FS", prFont, Brushes.Black, 0, 190)
        e.Graphics.DrawString("^FT705,613^A0N,25,45^FH\^FDHA^FS", prFont, Brushes.Black, 0, 200)
        e.Graphics.DrawString("^FT419,720^A0N,25,45^FH\^FDCADUCIDAD:^FS", prFont, Brushes.Black, 0, 210)
        e.Graphics.DrawString("^FT419,615^A0N,25,45^FH\^FDCANT:^FS", prFont, Brushes.Black, 0, 220)
        e.Graphics.DrawString("^FT419,581^A0N,25,45^FH\^FDZONA:^FS", prFont, Brushes.Black, 0, 230)
        e.Graphics.DrawString("^FT41,569^A0N,17,26^FH\^FDPresentacion:^FS", prFont, Brushes.Black, 0, 240)
        e.Graphics.DrawString("^FT41,672^A0N,20,33^FH\^FD" & tipocaja & "^FS", prFont, Brushes.Black, 0, 250)
        e.Graphics.DrawString("^FT41,739^A0N,20,33^FH\^FDPESO BRUTO^FS", prFont, Brushes.Black, 0, 260)
        e.Graphics.DrawString("^FT41,706^A0N,20,33^FH\^FDCONTENIDO NETO^FS", prFont, Brushes.Black, 0, 270)
        e.Graphics.DrawString("^FT144,674^A0N,24,28^FH\^FD" & CAJASAL & "^FS", prFont, Brushes.Black, 0, 280)
        e.Graphics.DrawString("^FT295,708^A0N,24,28^FH\^FD" & LTSSAL & " LTS^FS", prFont, Brushes.Black, 0, 290)
        e.Graphics.DrawString("^FT41,640^A0N,24,33^FH\^FD" & descrsal & "^FS", prFont, Brushes.Black, 0, 300)
        e.Graphics.DrawString("^FT41,607^A0N,31,45^FH\^FD" & PROTOSAL & "^FS", prFont, Brushes.Black, 0, 310)
        e.Graphics.DrawString("^FT35,525^A0N,18,26^FH\^FD" & dir03 & "^FS", prFont, Brushes.Black, 0, 320)
        e.Graphics.DrawString("^FT35,500^A0N,18,26^FH\^FD" & dir02 & "^FS", prFont, Brushes.Black, 0, 330)
        e.Graphics.DrawString("^FT516,463^A0N,23,26^FH\^FDx1^FS", prFont, Brushes.Black, 0, 340)
        e.Graphics.DrawString("^FT453,496^A0N,23,26^FH\^FDx2^FS", prFont, Brushes.Black, 0, 350)
        e.Graphics.DrawString("^FT147,439^A0N,23,26^FH\^FD" & CLIENTESAL & "^FS", prFont, Brushes.Black, 0, 360)
        e.Graphics.DrawString("^FT35,439^A0N,23,26^FH\^FDCLIENTE:^FS", prFont, Brushes.Black, 0, 370)
        e.Graphics.DrawString("^FT496,432^A0N,23,26^FH\^FDP-^FS", prFont, Brushes.Black, 0, 380)
        e.Graphics.DrawString("^FT453,432^A0N,23,26^FH\^FDOC:^FS", prFont, Brushes.Black, 0, 390)
        e.Graphics.DrawString("^FT453,525^A0N,23,26^FH\^FDCAD:^FS", prFont, Brushes.Black, 0, 400)
        e.Graphics.DrawString("^FT453,463^A0N,23,26^FH\^FDOBS:^FS", prFont, Brushes.Black, 0, 410)
        e.Graphics.DrawString("^FT35,474^A0N,20,24^FH\^FDDIRECCION: " & dir01 & "^FS", prFont, Brushes.Black, 0, 420)
        e.Graphics.DrawString("^FT52,362^A0N,16,14^FH\^FDBelisario Dominguez #300 Col. Nuevo Progreso^FS", prFont, Brushes.Black, 0, 430)
        e.Graphics.DrawString("^FT52,382^A0N,16,14^FH\^FDTampico, Tam., M\82xico CP. 89318 Tel 01 800-NUVAGRO^FS", prFont, Brushes.Black, 0, 440)
        e.Graphics.DrawString("^FT525,381^A0N,25,43^FH\^FD" & IDPEDSAL & "^FS", prFont, Brushes.Black, 0, 450)
        e.Graphics.DrawString("^FT456,381^A0N,25,43^FH\^FDNP.^FS", prFont, Brushes.Black, 0, 460)
        e.Graphics.DrawString("^FT416,300^A0N,34,60^FH\^FD" & TIPOSAL & "^FS", prFont, Brushes.Black, 0, 470)
        e.Graphics.DrawString("^FT84,314^A0N,62,62^FH\^FDNUVAGRO^FS", prFont, Brushes.Black, 0, 380)
        e.Graphics.DrawString("^PQ1,0,1,Y^XZ", prFont, Brushes.Black, 0, 490)
        e.Graphics.DrawString("^XA^ID000.GRF^FS^XZ", prFont, Brushes.Black, 0, 500)
        e.Graphics.DrawString("^XA^ID001.GRF^FS^XZ", prFont, Brushes.Black, 0, 510)
        e.HasMorePages = False
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged

    End Sub

    Private Sub CBoxImpresoras_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBoxImpresoras.GotFocus
        Me.Timer1.Enabled = False
        Me.CheckBox2.Checked = False
        listadeimp()
    End Sub

    Private Sub CBoxImpresoras_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBoxImpresoras.LostFocus
        Me.Timer1.Enabled = True
        SELECTPRINTER()
    End Sub

    Private Sub CBoxImpresoras_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBoxImpresoras.SelectedIndexChanged
        'Me.Timer1.Enabled = False
        'Me.CheckBox2.Checked = False
        guardaimp()
        ' Me.CheckBox2.Checked = True
        'Me.Timer1.Enabled = True
    End Sub


    Private Sub ChBoxTimpr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxTimpr.CheckedChanged
        If Me.ChBoxTimpr.Checked Then
            Me.ChBoxTimpr.ForeColor = Color.DarkGreen

            Me.ChBoxTimpr.Font = New System.Drawing.Font("Verdana", 9, FontStyle.Bold)
            'Me.ChBoxModificar.Font = New System.Drawing.Font(Me.ChBoxModificar.Font, FontStyle.Underline)
            Me.ChBoxTimpr.BackColor = Color.Gold
            Me.CBoxImpresoras.Text = ""
            listadeimp()
        Else
            'Microsoft Sans Serif, 8.25pt
            Me.ChBoxTimpr.ForeColor = Color.Black

            Me.ChBoxTimpr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            'Me.ChBoxModificar.Font = New System.Drawing.Font(Me.ChBoxModificar.Font, FontStyle.Underline)
            Me.ChBoxTimpr.BackColor = Color.Beige

        End If
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class