Imports System.Text
Imports System.IO
Public Class Reports_12

    Private Sub Reports_12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If RP.CHKFOL.Checked = True Then
            Dim r As New rptfolios2
            Dim cx As New CrystalDecisions.Shared.ConnectionInfo
            Dim t As CrystalDecisions.CrystalReports.Engine.Table
            Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
            Dim td As New CrystalDecisions.Shared.TableLogOnInfo

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

            If RP.CBMOVI.Text = "SALIDA" Then
                CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
            Else
                CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
            End If

            r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & RP.CBMOVI.Text & "'"
            r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & RP.Cbalm.Text & "'"
            r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & RP.DTFECHADE.Text & "'"
            r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & RP.DTFECHAA.Text & "'"
            CrystalReportViewer1.ReportSource = r
        Else
            If RP.CHKCLI.Checked = True Then
                Dim r As New rptclientes2
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

                If RP.CBMOVI.Text = "SALIDA" Then
                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                Else
                    If RP.CBPROVE.Text = Nothing Then
                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                    Else
                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.PROV_MOV2} = ('" & RP.CBPROVE.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                    End If
                End If
                r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & Trim(RP.Cbalm.Text) & "'"
                r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & RP.CBMOVI.Text & "'"
                r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & RP.DTFECHADE.Text & "'"
                r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & RP.DTFECHAA.Text & "'"
                CrystalReportViewer1.ReportSource = r
            Else
                If RP.CHFAC.Checked = True Then
                    Dim r As New rptfacturas2
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

                    If RP.CBMOVI.Text = "SALIDA" Then
                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                    Else
                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                    End If

                    r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & RP.Cbalm.Text & "'"
                    CrystalReportViewer1.ReportSource = r
                Else
                    If RP.CHFAM.Checked = True Then
                        Dim r As New rptfamilias2
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

                        If RP.CBMOVI.Text = "SALIDA" Then
                            CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                        Else
                            CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                        End If

                        r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & RP.CBMOVI.Text & "'"
                        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & RP.Cbalm.Text & "'"
                        r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & RP.DTFECHADE.Text & "'"
                        r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & RP.DTFECHAA.Text & "'"
                        CrystalReportViewer1.ReportSource = r
                    Else
                        If RP.CHKFAMP.Checked = True Then
                            Dim r As New rptprove_fam2
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

                            If RP.CBMOVI.Text = "SALIDA" Then
                                CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                            Else
                                CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                            End If
                            r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & RP.CBMOVI.Text & "'"
                            r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & RP.Cbalm.Text & "'"
                            r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & RP.DTFECHADE.Text & "'"
                            r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & RP.DTFECHAA.Text & "'"
                            CrystalReportViewer1.ReportSource = r
                        Else
                            If RP.CHPROV.Checked = True Then
                                Dim r As New rptproveedores2
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
                                If RP.CBPROVE.Text = Nothing Then
                                    If RP.CBMOVI.Text = "SALIDA" Then
                                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                                    Else
                                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                                    End If
                                Else
                                    If RP.CBMOVI.Text = "SALIDA" Then
                                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                                    Else
                                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.CBPROVE.Text & "') AND {Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                                    End If
                                End If
                                r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & RP.CBMOVI.Text & "'"
                                r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & Trim(RP.Cbalm.Text) & "'"
                                r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & RP.DTFECHADE.Text & "'"
                                r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & RP.DTFECHAA.Text & "'"
                                CrystalReportViewer1.ReportSource = r
                            Else
                                If RP.CHGLOBAL.Checked = True Then
                                    Dim r As New rptclienteglobal2
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

                                    If RP.CBMOVI.Text = "SALIDA" Then
                                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                                    Else
                                        CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                                    End If
                                    r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & RP.Cbalm.Text & "'"
                                    r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & RP.CBMOVI.Text & "'"
                                    r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & RP.DTFECHADE.Text & "'"
                                    r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & RP.DTFECHAA.Text & "'"
                                    CrystalReportViewer1.ReportSource = r
                                Else
                                    If RP.CHPROD.Checked = True Then
                                        Dim r As New rptproductos2
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
                                        If RP.TXTCODIGO.Text = Nothing Then
                                            If RP.CbFAM.Text = Nothing Then
                                                If RP.CBMOVI.Text = "SALIDA" Then
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                                                Else
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                                                End If
                                            Else
                                                If RP.CBMOVI.Text = "SALIDA" Then
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {familias.ABREVIATURA} = ('" & RP.CbFAM.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                                                Else
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {familias.ABREVIATURA} = ('" & RP.CbFAM.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                                                End If
                                            End If
                                        Else
                                            If RP.CbFAM.Text = Nothing Then
                                                If RP.CBMOVI.Text = "SALIDA" Then
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.Codigo de producto} = ('" & RP.TXTCODIGO.Text & "') AND {Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                                                Else
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.Codigo de producto} = ('" & RP.TXTCODIGO.Text & "') AND {Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                                                End If
                                            Else
                                                If RP.CBMOVI.Text = "SALIDA" Then
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.Codigo de producto} = ('" & RP.TXTCODIGO.Text & "') AND {familias.ABREVIATURA} = ('" & RP.CbFAM.Text & "') AND {Movimientos2.PROV_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} <> ('ENT'))"
                                                Else
                                                    CrystalReportViewer1.SelectionFormula = "({Movimientos2.Codigo de producto} = ('" & RP.TXTCODIGO.Text & "') AND {familias.ABREVIATURA} = ('" & RP.CbFAM.Text & "') AND {Movimientos2.CLIEN_MOV2} = ('" & RP.Cbalm.Text & "') AND {Movimientos2.FECHA_MOV2} = DateValue ('" & RP.DTFECHADE.Text & "') to DateValue ('" & RP.DTFECHAA.Text & "') AND {Movimientos2.TIPO_MOV2} = ('ENT'))"
                                                End If
                                            End If

                                        End If
                                        r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & RP.CBMOVI.Text & "'"
                                        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & RP.Cbalm.Text & "'"
                                        r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & RP.DTFECHADE.Text & "'"
                                        r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & RP.DTFECHAA.Text & "'"
                                        CrystalReportViewer1.ReportSource = r
                                    Else
                                        MsgBox("NO HA SELECCIONADO NINGUN REPORTE")
                                        Me.Close()

                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class