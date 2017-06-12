Imports System.Data.SqlClient
Imports System.Data
Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Net
Public Class FrmNoAlm
    Dim mesE As String = Nothing
    Dim CANTAR, COUNTLOTE, LTSXTAR As Integer
    Dim clavealm, zonaalm As String
    Dim idexp1 As Integer
    Dim inv1, inv2 As Date
    Dim DS4 As New DataTable
    Dim fecha1, fecha2 As Date

    Private Sub FrmNoAlm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        CargaALM2()
    End Sub
    Private Sub CargaGrid()
        Dim SqlSel As New SqlDataAdapter("SELECT COUNT(A.cantidad2) AS [CANT ETIQUETAS],SUM(A.cantidad2) AS [CANT PRODUCTO],B.[Nombre corto] AS DESCRIPCION, A.[Codigo de producto] AS [CODIGO DE PRODUCTO] FROM LOTEEX2 A, PRODUCTOS B WHERE A.[Codigo de producto] = B.[Codigo de producto] AND ALMACEN = 'WSALM' GROUP BY A.[Codigo de producto], B.[Nombre corto] ", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGETIQUETAS
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub CargaGridANT()
        Dim SqlSel As New SqlDataAdapter("SELECT A.PRIMP AS IMPRIMIR,PRCODE AS [LOTE ENTRADA],B.CodigoLote AS [CODIGO BARRAS], C.[Nombre corto] AS DESCRIPCION, PRARCHI AS [CANT ETIQUETAS], fecha2 AS FECHA FROM PRINTS A, LOTEEX2 B, PRODUCTOS C WHERE  A.PRCODE = B.Numlote2 AND B.[Codigo de producto] = C.[Codigo de producto] AND A.PRUSU = 'WSALM' and A.PRES = 'ENT' ", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGETIQUETAS
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub TraecantXtar(ByVal codetar As String)
        Dim Sqlcant1 As New SqlCommand("SELECT LTSTARIMA FROM CODESTAR WHERE [Codigo de Producto] = '" & codetar & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlcant1.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    CANTAR = 0
                Else
                    CANTAR = SqlRead.GetInt32(0)
                End If
                'Me.TxtCosto.Text = SqlRead.GetDecimal(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        'Return CANTAR
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim resp
        resp = MsgBox("Desea imprimir su seleccion, ¿OK?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If cbalm.Text = Nothing Then
                MsgBox("Favor de seleccionar el Expendedora ")
            Else
                'leeExistencias()
                Cargamaquinas()
                Dim row000 As DataRow
                For Each row000 In DS4.Rows
                    GUARDATOTALES(Trim(row000("IDMAQUINA")))
                    GUARDATOTALES2(Trim(row000("IDMAQUINA")))
                Next

            End If
        End If
    End Sub
    Private Sub Cargamaquinas()
        DS4.Clear()
        Dim SqlSel As New SqlDataAdapter("SELECT IDMAQUINA FROM RECARGAHIST GROUP BY IDMAQUINA ", SqlCnn)
        Try
            SqlSel.Fill(DS4)
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Function GUARDATOTALES(ByVal machine As Integer) As Integer
        Dim SqlInstrSCompra As New SqlCommand
        CmdStr1 = "DECLARE @Codigo nchar(30),@Cantidad INT,@Costo decimal(12,2),@CostoV decimal(12,2),@SUBTOTAL decimal(12,2),@TOTAL decimal(12,2),@FECHA DATE "
        CmdStr1 = CmdStr1 & "SET @FECHA = (SELECT MAX(FECHA) FROM RECARGAHIST where IDMAQUINA = '" & machine & "') DELETE FROM VENTASREP where IDMACHINE = '" & machine & "' SET NOCOUNT ON; "
        CmdStr1 = CmdStr1 & "DECLARE CDetSal "
        CmdStr1 = CmdStr1 & "CURSOR FOR SELECT IDPROD,CANTIDAD,COSTO,COSTOV FROM RECARGAHIST WHERE FECHA = @FECHA AND IDMAQUINA = '" & machine & "'  order by IDPROD "
        CmdStr1 = CmdStr1 & "OPEN CDetSal "
        CmdStr1 = CmdStr1 & "FETCH NEXT FROM CDetSal INTO @Codigo,@Cantidad,@Costo,@CostoV  "
        CmdStr1 = CmdStr1 & "WHILE @@FETCH_STATUS = 0 "
        CmdStr1 = CmdStr1 & "BEGIN "
        CmdStr1 = CmdStr1 & " INSERT INTO VENTASREP VALUES('" & machine & "',@Codigo,@Cantidad,0,@Costo,@CostoV,@FECHA,0) "
        CmdStr1 = CmdStr1 & "  FETCH NEXT FROM CDetSal INTO @Codigo,@Cantidad,@Costo,@CostoV END "
        CmdStr1 = CmdStr1 & "  CLOSE CDetSal"
        CmdStr1 = CmdStr1 & "  DEALLOCATE CDetSal"
        CmdStr1 = CmdStr1 & "  "
        'generaArchivo(CmdStr1)
        With SqlInstrSCompra
            .Connection = SqlCnn
            .CommandText = CmdStr1
        End With

        Try
            SqlInstrSCompra.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Error1 = 0

    End Function
    Public Function GUARDATOTALES2(ByVal machine2 As Integer) As Integer
        Dim SqlInstrSCompra2 As New SqlCommand
        CmdStr1 = "DECLARE @Codigo nchar(30),@Cantidad INT, @fecha1 date, @fecha2 date, @monto decimal(12,2) "
        CmdStr1 = CmdStr1 & "set @fecha1 = (select top 1 fecha from VENTASREP WHERE IDMACHINE = '" & machine2 & "') set @fecha2 = (select top 1 FECHA from auditoria WHERE IDMAQUINA = '" & machine2 & "') SET NOCOUNT ON; "
        CmdStr1 = CmdStr1 & "DECLARE CDetSal "
        CmdStr1 = CmdStr1 & "CURSOR FOR SELECT CODE,CANTIDAD FROM AUDITORIA WHERE IDMAQUINA = '" & machine2 & "' "
        CmdStr1 = CmdStr1 & "OPEN CDetSal "
        CmdStr1 = CmdStr1 & "FETCH NEXT FROM CDetSal INTO @Codigo,@Cantidad  "
        CmdStr1 = CmdStr1 & "WHILE @@FETCH_STATUS = 0 "
        CmdStr1 = CmdStr1 & "BEGIN "
        CmdStr1 = CmdStr1 & " UPDATE VENTASREP SET AUDITORIA = @Cantidad WHERE [Codigo de producto] = @Codigo AND IDMACHINE = '" & machine2 & "' "
        CmdStr1 = CmdStr1 & "  FETCH NEXT FROM CDetSal INTO @Codigo,@Cantidad END "
        CmdStr1 = CmdStr1 & "  CLOSE CDetSal"
        CmdStr1 = CmdStr1 & "  DEALLOCATE CDetSal"
        CmdStr1 = CmdStr1 & " SET @monto = (select sum(MONTO) from efectivo where IDMAQUINA = '" & machine2 & "' AND convert(varchar(8), FECHA, 112) Between @Fecha1 and @Fecha2) IF @monto IS NULL BEGIN set @monto = 0 end UPDATE VENTASREP SET efectivo = @monto where IDMACHINE = '" & machine2 & "'  "
        'generaArchivo(CmdStr1)
        With SqlInstrSCompra2
            .Connection = SqlCnn
            .CommandText = CmdStr1
        End With

        Try
            SqlInstrSCompra2.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Error1 = 0

    End Function
    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub
    Public Sub CargaALM2()
        Dim Sqlalm As New SqlCommand("SELECT Abreviatura FROM almacenes ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlalm.ExecuteReader
            While SqlRead.Read
                Me.cbalm.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
  
    Public Sub BUSCALTSXTAR(ByVal PRODUCTO02 As String)
        Dim Sqlcant1 As New SqlCommand("SELECT LTSTARIMA FROM CODESTAR WHERE [Codigo de producto] = '" & PRODUCTO02 & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlcant1.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    LTSXTAR = 1
                Else
                    LTSXTAR = SqlRead.GetInt32(0)
                End If
                'Me.TxtCosto.Text = SqlRead.GetDecimal(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        'Return CANTAR
    End Sub
    Public Function traeMES() As Integer
        Dim FECHA1 As String
        FECHA1 = Format(DateTime.Now, "MM")
        'MsgBox(FECHA1)
        If FECHA1 = "01" Then
            mesE = "A"
        Else
            If FECHA1 = "02" Then
                mesE = "B"
            Else
                If FECHA1 = "03" Then
                    mesE = "C"
                Else
                    If FECHA1 = "04" Then
                        mesE = "D"
                    Else
                        If FECHA1 = "05" Then
                            mesE = "E"
                        Else
                            If FECHA1 = "06" Then
                                mesE = "F"
                            Else
                                If FECHA1 = "07" Then
                                    mesE = "G"
                                Else
                                    If FECHA1 = "08" Then
                                        mesE = "H"
                                    Else
                                        If FECHA1 = "09" Then
                                            mesE = "I"
                                        Else
                                            If FECHA1 = "10" Then
                                                mesE = "J"
                                            Else
                                                If FECHA1 = "11" Then
                                                    mesE = "K"
                                                Else
                                                    If FECHA1 = "12" Then
                                                        mesE = "L"
                                                    Else
                                                        mesE = Nothing
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function

   

    Private Sub cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbalm.SelectedIndexChanged
        TraeNalm(cbalm.Text)
    End Sub
    Public Sub TraeNalm(ByVal abrevia As String)
        Dim Sqlcant1 As New SqlCommand("SELECT clave, zona FROM almacenes WHERE abreviatura = '" & abrevia & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlcant1.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) = True Then
                    clavealm = 0
                    zonaalm = "NA"
                Else
                    clavealm = SqlRead.GetString(0)
                    zonaalm = SqlRead.GetString(1)

                End If
                'Me.TxtCosto.Text = SqlRead.GetDecimal(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        'Return CANTAR
    End Sub

    Private Sub DGETIQUETAS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGETIQUETAS.CellClick
        If e.RowIndex > -1 Then
            Dim value As Object = DGETIQUETAS.Rows(e.RowIndex).Cells(0).Value
            If value.GetType Is GetType(DBNull) Then Return
            Dim value2 As Object = DGETIQUETAS.Rows(e.RowIndex).Cells(2).Value
            Dim value3 As Object = DGETIQUETAS.Rows(e.RowIndex).Cells(3).Value
        End If
    End Sub

 
    Private Sub guardaPRINT(ByVal CODIGOP As String, ByVal ETIQUETASNUM As Integer)

        Dim SqlInsPR As New SqlCommand
        'Dim CmdStr As New String("UPDATE PRINTS SET PRIMP = 'TRUE', PRARCHI = '" & Me.txetiquetas.Text & "' WHERE PRTIPO = 'C' AND PRES = 'ENT' AND PRUSU = 'WSALM' AND PRCODE = '" & Me.TXCODE.Text & "'  ")
        Dim CmdStr As New String("UPDATE TOP (" & ETIQUETASNUM & ")PRINTS SET PRIMP = 'TRUE' FROM  PRINTS A, LOTEEX2 B WHERE PRCODE = NUMLOTE2 AND PRUSU = ALMACEN AND [Codigo de producto] = '" & CODIGOP & "' AND PRUSU = 'WSALM' AND PRES = 'ENT'  ")
        With SqlInsPR
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            SqlInsPR.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try
        Return

    End Sub

    Private Function borraws()
        Dim SqlFolio As New SqlCommand("DELETE FROM ALMACEN WHERE ALMACEN = 'WSALM' DELETE FROM LOTEEX2 WHERE ALMACEN = 'WSALM' DELETE FROM PRINTS WHERE PRUSU = 'WSALM' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlFolio.ExecuteReader
            While SqlRead.Read
                'folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function
End Class