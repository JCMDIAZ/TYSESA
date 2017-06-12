Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class Reports7
    Private m_ChildFormNumber As Int32
    Private Sub Reports7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmova As New frmmov2
        For i As Integer = 0 To MDIPrincipal.MdiChildren.Length - 1
            If MDIPrincipal.MdiChildren(i).Text = "MOVIMIENTOS" Then

                frmova = MDIPrincipal.MdiChildren(i)
                Exit For
            Else
            End If
        Next



        Dim data As New String("({Movimientos2.FECHA_MOV2} = DateValue ('" & frmova.DTFECHADE.Text & "') to DateValue ('" & frmova.DTFECHAA.Text & "')) ")
        TITULO = Nothing
        If frmova.CBMOVI.Text = "ENTRADA POR COMPRA" Then
            'MsgBox(" es entrada")
            TITULO = "ENTRADA POR COMPRA"
            data = data & "AND {Movimientos2.TIPO_MOV2} = 'ENT' "
            data = data & "AND {Movimientos2.CLIEN_MOV2} = '" & frmova.Cbalm.Text & "' "
        End If
        'If frmova.CBMOVI.Text = "SALIDAS POR RECARGA A RUTA" Then
        If frmova.CBMOVI.Text = "SALIDAS A RUTA" Then
            'MsgBox("es salida")
            data = data & "AND {Movimientos2.TIPO_MOV2} = 'STR' "
            data = data & "AND {Movimientos2.PROV_MOV2} = '" & frmova.Cbalm.Text & "' "
        End If
        If frmova.CBMOVI.Text = "ENTRADA POR DEVOLUCION DE RUTA" Then
            'MsgBox(" es entrada")
            TITULO = "ENTRADA POR DEVOLUCION DE RUTA"
            data = data & "AND {Movimientos2.TIPO_MOV2} = 'EDV' "
            data = data & "AND {Movimientos2.CLIEN_MOV2} = '" & frmova.Cbalm.Text & "' "
        End If
        If frmova.CBMOVI.Text = "ENTRADA POR DEVOLUCION PROVEEDOR" Then
            'MsgBox(" es entrada")
            TITULO = "ENTRADA POR DEVOLUCION PROVEEDOR"
            data = data & "AND {Movimientos2.TIPO_MOV2} = 'EDB' "
            data = data & "AND {Movimientos2.CLIEN_MOV2} = '" & frmova.Cbalm.Text & "' "
        End If
        If frmova.CBMOVI.Text = "SALIDAS POR MERMA" Then
            'MsgBox(" es salida")
            TITULO = "SALIDAS POR MERMA"
            data = data & "AND {Movimientos2.TIPO_MOV2} = 'SMR' "
            data = data & "AND {Movimientos2.PROV_MOV2} = '" & frmova.Cbalm.Text & "' "
        End If

        If frmova.CHCLIENTE.Checked = True Then
            If frmova.CBCLIENTE.Text = Nothing Then
                MsgBox("Error, requiere seleccionar Salida")
                Me.Close()
            Else
                If frmova.CBMOVI.Text = "ENTRADA POR COMPRA" Then
                    data = data & "AND {Movimientos2.CLIEN_MOV2} = '" & frmova.Cbalm.Text & "' "
                End If
                'If frmova.CBMOVI.Text = "SALIDAS POR RECARGA A RUTA" Then
                If frmova.CBMOVI.Text = "SALIDAS A RUTA" Then
                    data = data & "AND {Movimientos2.CLIEN_MOV2} = '" & frmova.CBCLIENTE.Text & "' "
                End If
                'MsgBox("agrega cliente")

            End If
        End If

        If frmova.CHPROV.Checked = True Then
            If frmova.CBPROVE.Text = Nothing Then
                MsgBox("Error, requiere seleccionar Proveedor")
                Me.Close()
            Else
                'MsgBox("agrega proveedor")
                data = data & "AND {Movimientos2.PROV_MOV2} = '" & frmova.CBPROVE.Text & "' "
            End If
        End If

        If frmova.CHUSU.Checked = True Then
            If frmova.CBUSU.Text = Nothing Then
                MsgBox("Error, requiere seleccionar usuario")
                Me.Close()
            Else
                'MsgBox("agrega usuario")
                data = data & "AND {Movimientos2.USU_MOV2} = '" & frmova.CBUSU.Text & "' "
            End If

        End If

        If frmova.CHFAM.Checked = True Then
            If frmova.CBFAM.Text = Nothing Then
                MsgBox("Error, requiere seleccionar familia")
                Me.Close()
            Else
                data = data & "AND {familias.Abreviatura} = '" & frmova.CBFAM.Text & "' "
            End If

        End If

        If frmova.CHCODE.Checked = True Then
            If frmova.TxtCodigo.Text = Nothing Then
                MsgBox("Error, requiere ingresar codigo")
                Me.Close()
            Else
                data = data & "AND {Movimientos2.Codigo de Producto} = '" & frmova.TxtCodigo.Text & "' "
            End If

        End If

        If frmova.CHFAC.Checked = True Then
            If frmova.CHNUMERO.Checked = True Then
                If frmova.TXTFAC.Text = Nothing Then
                    MsgBox("Error, Requiere capturar Numero de factura o Nota")
                    Me.Close()
                Else
                    data = data & "AND {Movimientos2.FACNOT_MOV2} = '" & frmova.TXTFAC.Text & "' "
                End If
            Else
                If frmova.CBFAC.Text = Nothing Then
                    MsgBox("Error, requiere seleccionar factura o nota")
                    Me.Close()
                Else
                    data = data & "AND {Movimientos2.FAC_MOV2} = '" & frmova.CBFAC.Text & "' "
                End If

            End If

        End If

        'If frmova.CBMOVI.Text = "SALIDAS POR RECARGA A RUTA" Then
        '    Dim r As New rptmovfam
        '    Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        '    Dim t As CrystalDecisions.CrystalReports.Engine.Table
        '    Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        '    Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        '    With cx

        '        .ServerName = Server
        '        .DatabaseName = BD
        '        .UserID = User1
        '        .Password = PWD1

        '    End With
        '    ts = r.Database.Tables
        '    For Each t In ts
        '        td = t.LogOnInfo
        '        td.ConnectionInfo = cx
        '        t.ApplyLogOnInfo(td)
        '    Next
        '    'data = data & "SORT ORDER BY {Movimientos2.FACNOT_MOV2} "
        '    r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & TITULO & "'"
        '    CrystalReportViewer1.SelectionFormula = data
        '    CrystalReportViewer1.ReportSource = r
        'Else
        Dim r As New rptmovimientos2
        Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        Dim t As CrystalDecisions.CrystalReports.Engine.Table
        Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        With cx

            .ServerName = noserv
            .DatabaseName = nobd
            .UserID = nous
            .Password = nopa

        End With
        ts = r.Database.Tables
        For Each t In ts
            td = t.LogOnInfo
            td.ConnectionInfo = cx
            t.ApplyLogOnInfo(td)
        Next
        'data = data & "SORT ORDER BY {Movimientos2.FACNOT_MOV2} "
        'r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & TITULO & "'"
        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & frmova.CBMOVI.Text & "'"
        r.DataDefinition.FormulaFields("UnboundString1").Text = "'" & Trim(frmova.Cbalm.Text) & "'"
        r.DataDefinition.FormulaFields("UnboundDate1").Text = "'" & frmova.DTFECHADE.Text & "'"
        r.DataDefinition.FormulaFields("UnboundDate2").Text = "'" & frmova.DTFECHAA.Text & "'"
        CrystalReportViewer1.SelectionFormula = data
        CrystalReportViewer1.ReportSource = r
        'End If
       
    End Sub
End Class