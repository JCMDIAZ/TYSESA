Imports System.Data.SqlClient
Imports System.Data
Public Class FrmPedidos
    Public Codigo, Desc, Ubicacion, Tipo, Marca, RegSerie, Capacidad, AplicaMan, AdquisicionFe, Observaciones, Unidad, Foto As New String(Nothing)
    Public CostoIni, UCosto, Existencia As New Double

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        
        Dim resp
        resp = MsgBox("Hay datos que no ha guardado, ¿Desea salir de todas formas?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmConsumibles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TraeALMACEN()
    End Sub
    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        
        Dim Sqlexis As New SqlCommand("SELECT ID_Ped FROM pedidos_det WHERE ID_Ped = '0'", SqlCnn)
        Dim SqlRead As SqlDataReader
            Dim exi As New String(Nothing)
            Try
                SqlRead = Sqlexis.ExecuteReader
                While SqlRead.Read
                    exi = SqlRead.GetInt32(0)
                End While
                SqlRead.Close()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try
            If exi = Nothing Then
                MsgBox("No existen datos que guardar favor de capturar el pedido completo")
                Me.cbruta.Focus()
            Else
                guardapedido()
                MsgBox("Registro Guardado")
            With Me
                .cbruta.Text = Nothing

                .Txtobs.Text = Nothing
               
                .cbruta.Focus()

            End With
                CargaGridped()
            End If
        
    End Sub



    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtobs.KeyPress

        If e.KeyChar = Chr(13) Then
          

            Me.Txtobs.Text = Traecodigo(Me.Txtobs.Text)

            MsgBox("ERROR, Producto NO habilitado o no existe")
            Me.Txtobs.Focus()
            Me.Txtobs.SelectAll()


        End If

    End Sub
    Public Sub TraeDatosClientes()
        Dim SqlClientes As New SqlCommand("SELECT Abreviatura FROM Clientes ORDER BY Abreviatura", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.cbruta.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub TraeALMACEN()
        Dim SqlALM As New SqlCommand("SELECT Nombre FROM RUTAS ORDER BY Nombre", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim ALMI As New String(Nothing)
        Try
            SqlRead = SqlALM.ExecuteReader
            While SqlRead.Read
                cbruta.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Function Generapedido() As Integer
        Dim Sqlpedi As New SqlCommand("SELECT MAX(ID_PED) FROM Pedidos ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim pedido As Integer
        Try
            SqlRead = Sqlpedi.ExecuteReader
            While SqlRead.Read
                pedido = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return pedido + 1
    End Function
    Private Function Traecodigo(ByVal codigo) As String

        Dim SqlSelDes As New SqlCommand("SELECT [Codigo de Producto] FROM productos WHERE [Codigo de Producto] = '" & codigo & "' OR alterno = " & codigo & " and Baja = 'NO' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                code = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return code

    End Function
    
    Private Function Traefamilia(ByVal codigo) As String

        Dim Sqlfam As New SqlCommand("SELECT a.abreviatura FROM familias a, productos b WHERE a.clave = b.Familia AND b.[Codigo de Producto] = '" & codigo & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim fam As New String(Nothing)

        Try
            SqlRead = Sqlfam.ExecuteReader
            While SqlRead.Read
                fam = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return fam

    End Function
    Private Function Traeum(ByVal codigo) As String

        Dim Sqlum As New SqlCommand("SELECT a.abreviatura FROM unidaddemedida a, productos b WHERE a.clave = b.[unidad de medida] AND b.[Codigo de Producto] = '" & codigo & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim um As New String(Nothing)

        Try
            SqlRead = Sqlum.ExecuteReader
            While SqlRead.Read
                um = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return um

    End Function
    Private Sub guardadetalle()
        Dim almi As String
        Dim fecha As String
        Dim iva As Decimal
        Dim user As String
        Dim cliente As String
        Dim codigo As String
        Dim ped As String
        Dim cant As Decimal
        Dim cost As Decimal
        Dim surt As Date
        Dim monto As Decimal


        codigo = Me.Txtobs.Text
        'user = Me.Stb.Text
        user = "General"
        cliente = Me.cbruta.Text
        monto = cant * cost
        iva = monto * (iva / 100)


        Dim SqlSelDes2 As New SqlCommand("DECLARE @Cantidad nchar(20) " & _
                                "DECLARE @iva nchar(20) " & _
                                "SET @Cantidad = '" & cant & "' " & _
                                "SET @iva = '" & iva & "' " & _
                                "IF EXISTS(SELECT * FROM pedidos_det WHERE [Codigo de Producto] = '" & codigo & "' AND ID_Ped = '" & ped & "') " & _
                                "BEGIN " & _
                                "UPDATE pedidos_det SET Cant_Prod = (Cant_Prod + @Cantidad) WHERE Id_Ped = '" & ped & "' AND [Codigo de Producto] = '" & codigo & "' " & _
                                "UPDATE pedidos_det SET Monto_Prod = Cant_Prod * Costo_prod WHERE Id_Ped = '" & ped & "' AND [Codigo de Producto] = '" & codigo & "' " & _
                                "UPDATE pedidos_det SET IVA_Prod = IVA_Prod + @iva WHERE Id_Ped = '" & ped & "' AND [Codigo de Producto] = '" & codigo & "' " & _
                                "UPDATE pedidos_det SET Total_Ped = IVA_Prod + Monto_Prod WHERE Id_Ped = '" & ped & "' AND [Codigo de Producto] = '" & codigo & "' " & _
                                "END " & _
                                "ELSE " & _
                                "BEGIN " & _
                                "INSERT INTO pedidos_det VALUES('" & ped & "','" & codigo & "','" & cant & "','" & cost & "','" & monto & "','" & iva & "','" & fecha & "','" & surt & "','0') " & _
                                "UPDATE pedidos_det SET Total_Ped = Monto_Prod + IVA_prod WHERE Id_Ped = '" & ped & "' AND [Codigo de Producto] = '" & codigo & "' " & _
                                "END ", SqlCnn)
        Dim SqlRead As SqlDataReader
        'Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDes2.ExecuteReader
            'While SqlRead.Read
            '    prove = SqlRead.GetString(0)
            'End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        CargaGridped()

    End Sub
    Private Sub CargaGridped()

        Dim DS As New DataTable
        Try
            Dim F1 As String
            'F1 = Me.Txtpedido.Text
            Dim SqlSel1 As New SqlDataAdapter("SELECT a.[Codigo de producto], b.Descripcion, a.Cant_prod, a. Costo_Prod, a.Monto_Prod, a.IVA_Prod, a.Total_Ped  FROM pedidos_det a, productos b WHERE a.[Codigo de producto] = b.[Codigo de producto] AND ID_Ped = '0'", SqlCnn)
            SqlSel1.Fill(DS)
            Me.DGfalta.DataSource = DS

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    

    Private Sub DGPEDIDO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGfalta.CellClick
        Dim pedcod As String
        Dim value As Object = DGfalta.Rows(e.RowIndex).Cells(0).Value

        If value.GetType Is GetType(DBNull) Then Return
        pedcod = CType(value, String)

        Me.Txtobs.Text = pedcod

        Me.Txtobs.Text = Traecodigo(Me.Txtobs.Text)
        
    End Sub
    Private Sub traesuma()
        Dim ped As String
        Dim Sqlsuma As New SqlCommand("SELECT ID_Ped, SUM(Total_Ped) FROM pedidos_det WHERE ID_Ped = '" & ped & "' Group by ID_Ped ORDER BY ID_Ped", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlsuma.ExecuteReader
            While SqlRead.Read
                '        Me.LBSUMA.Text = SqlRead.GetDecimal(1)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Txtobs.Text = Nothing Then
            MsgBox("Capturar codigo que desea borrar")
            Me.Txtobs.Focus()
        Else
            Dim resp
            resp = MsgBox("Desea borrar el producto ?", MsgBoxStyle.OkCancel)
            If resp = vbOK Then
                borrarprod()
            End If
            With Me
                .Txtobs.Text = Nothing
                .Txtobs.Focus()
            End With
            CargaGridped()
            traesuma()
        End If
    End Sub
    Private Sub borrarprod()
        Dim ped
        Dim Sqlborra As New SqlCommand("DELETE FROM pedidos_det WHERE ID_Ped = '" & ped & "' AND [Codigo de producto] = '" & Me.Txtobs.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlborra.ExecuteReader
            While SqlRead.Read
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub guardapedido()

        Dim almi As String
        Dim fecha As String
        Dim user As String
        Dim cliente As String
        Dim ped As Integer
        Dim total As Decimal
        Dim surt As Date
        Dim util As String
        Dim fmod As Date

        user = MDIPrincipal.StbUSER.Text
        cliente = Me.cbruta.Text
        
        traesuma()

        Dim SqlSelped As New SqlCommand("DECLARE @almi nchar(20) " & _
                                "DECLARE @total nchar(20) " & _
                                "DECLARE @user nchar(20) " & _
                                "DECLARE @fsur nchar(20) " & _
                                "DECLARE @util nchar(1) " & _
                                "SET @almi = '" & almi & "' " & _
                                "SET @total = '" & total & "' " & _
                                "SET @user = '" & user & "' " & _
                                "SET @fsur = '" & surt & "' " & _
                                "SET @util = '" & util & "' " & _
                                "IF EXISTS(SELECT * FROM pedidos WHERE ID_PED = " & ped & ") " & _
                                "BEGIN " & _
                                "UPDATE pedidos SET PROV_PED = @almi, COSTO_PED = @total, USU_PED = @user, FSURT_PED = @fsur, FMOD_PED = @fsur, UTIL_PED = @util WHERE Id_Ped = " & ped & " " & _
                                "END " & _
                                "ELSE " & _
                                "BEGIN " & _
                                "INSERT INTO pedidos VALUES(" & ped & ",'" & almi & "','" & cliente & "','" & total & "','" & user & "','" & fecha & "','" & surt & "','" & fmod & "','False','" & util & "' ) " & _
                                "END ", SqlCnn)
        Dim SqlRead As SqlDataReader
        'Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelped.ExecuteReader
            'While SqlRead.Read
            '    prove = SqlRead.GetString(0)
            'End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub BTNBUSCA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Show(BuscaPedido)
    End Sub

    Private Sub cbruta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbruta.SelectedIndexChanged

    End Sub

    Private Sub Txtobs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtobs.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub
End Class