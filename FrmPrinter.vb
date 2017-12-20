Imports System.IO
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data.SqlClient
Public Class FrmPrinter
    Dim PREFIJO, BARCODEPRINT, REPORTESPRINT, CANTCODESTR As String
    Dim CANTCODES As Integer
    Private Sub FrmPrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SELECTPRINTER()
        Button1.Enabled = False
        CBEMP.Items.Add("COMERCIO")
        CBEMP.Items.Add("INDUSTRIAL")
        CBEMP.Focus()
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
    Private Sub CBEMP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBEMP.SelectedIndexChanged
        TxtCantidad.SelectAll()
        TxtCantidad.Focus()
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer = 0
        Dim LI3, LI2, LI4 As Integer
        CANTCODES = 0
        PrintDocument1.PrinterSettings.PrinterName = Trim(BARCODEPRINT)
        Dim counter01 As Integer = Val(TxtCantidad.Text)
        For i = 0 To counter01 - 1
            CANTCODES = CANTCODES + 1
            CANTCODESTR = CANTCODES
            LI3 = CANTCODESTR.Length
            LI2 = 3
            If LI3 < 3 Then
                LI2 = LI2 - LI3
                For li4 = 0 To LI2
                    CANTCODESTR = "0" & CANTCODESTR
                Next li4
            End If
            PrintDocument1.Print()
        Next

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If CBEMP.Text = "COMERCIO" Then
            PREFIJO = "CM"
        Else
            PREFIJO = "CI"
        End If
        Dim fechai As String = Format(Date.Now, "yyMMddHHmm")
        Dim xPos As Single = e.MarginBounds.Left
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim yPos As Single = prFont.GetHeight(e.Graphics)
        Dim printFont As New System.Drawing.Font("Device Font 10cpi", 10, System.Drawing.FontStyle.Regular)
        e.Graphics.DrawString("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4^MD0^JUS^LRN^CI0^XZ", prFont, Brushes.Black, 0, 0)
        e.Graphics.DrawString("^XA", prFont, Brushes.Black, 0, 10)
        e.Graphics.DrawString("^MMT", prFont, Brushes.Black, 0, 20)
        e.Graphics.DrawString("^LL0203", prFont, Brushes.Black, 0, 30)
        e.Graphics.DrawString("^PW406", prFont, Brushes.Black, 0, 40)
        e.Graphics.DrawString("^LS0", prFont, Brushes.Black, 0, 50)
        e.Graphics.DrawString("^BY2,3,103^FT25,155^BCN,,Y,N", prFont, Brushes.Black, 0, 60)
        e.Graphics.DrawString("^FD>:" & PREFIJO & ">5" & fechai & ">6-" & CANTCODESTR & "^FS", prFont, Brushes.Black, 0, 70)
        e.Graphics.DrawString("^FT164,42^A0N,17,16^FH\^FDMIISA " & CBEMP.Text & "^FS", prFont, Brushes.Black, 0, 80)
        e.Graphics.DrawString("^PQ1,0,1,Y^XZ", prFont, Brushes.Black, 0, 90)
        e.HasMorePages = False
    End Sub
End Class