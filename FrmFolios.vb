Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Public Class FrmFolios
    Public RUTSID As Integer
    Public DS2 As New DataTable
   

    Private Sub FrmFolios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim SqlClientes As New SqlCommand("SELECT NOMBRE FROM RUTAS ORDER BY NOMBRE", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.ComboBox1.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Call Me.CargaComboRutas()
    End Sub

    Private Sub CargaComboRutas()
        Dim SqlSel As New SqlDataAdapter("SELECT IDRUTA, NOMBRE FROM RUTAS ORDER BY IDRUTA", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.ComboBox1
                .DataSource = DS
                .DisplayMember = "NOMBRE" '"TEZINR"
                .ValueMember = "IDRUTA"
                .SelectedIndex = 0
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.ComboBox1.Text = Nothing Then
            MsgBox("Seleccione la ruta que desea buscar")
        Else
            filtrado()
        End If

    End Sub
    Private Sub filtrado()
        DS2.Clear()
      
        Try
            Dim F1 As String
            F1 = FrmBorraFolios.TxtFolio.Text
            'Dim SqlSel1 As New SqlDataAdapter("declare @activar as bit set @activar = 0 SELECT b.NOMBRE as RUTA,a.[CODIGO] AS PRODUCTO,c.descripcion as DESCRIPCION,a.[CANTIDAD],a.[COSTO],a.[FECHA],a.[IDFOLIO] as FOLIO_MOV,[ESTATUS], @activar as RESURTIR FROM [SURTIDORUTAS] a, RUTAS b, PRODUCTOS c WHERE c.[Codigo de producto] = a.CODIGO AND a.IDRUTA = b.IDRUTA AND a.IDRUTA = '" & RUTSID & "' ", SqlCnn)
            'Dim SqlSel1 As New SqlDataAdapter("declare @activar as bit set @activar = 0 SELECT [IDPROD] AS CODIGO,[Descripcion] as DESCRIPCION,[DEVCPTE] AS CANT_RUTA,[DEVCOSTO] AS COSTO,[DEVFECHA] AS FECHA,[IDUSER] AS USUARIO,@activar as RESURTIR FROM [DEVOLUCION] a, productos b where IDPROD = [Codigo de producto] AND a.IDRUTA = '" & RUTSID & "' ", SqlCnn)
            'SE MODIFICA POR EL DE ABAJO PARA MOSTRAR SI HAY CANTIDAD RESTANTE UNA VES QUE SE HAGA UNA DEVOLUCION A ALMACEN----------------------------                                                                                                                                                                                                                                                                                                                                                                     CASE WHEN (DEVCANT > 0) THEN DEVCPTE - DEVCANT ELSE DEVCPTE END AS COSTO
            'Dim SqlSel1 As New SqlDataAdapter("declare @activar as bit set @activar = 0 SELECT [IDPROD] AS CODIGO,[Descripcion] as DESCRIPCION,[DEVCPTE] AS CANT_RUTA,[DEVCOSTO] AS COSTO,[DEVFECHA] AS FECHA,[IDUSER] AS USUARIO,@activar as RESURTIR FROM [DEVOLUCION] a, productos b where IDPROD = [Codigo de producto] AND a.IDRUTA = '" & RUTSID & "' and DEVACT = 1 ", SqlCnn)
            Dim SqlSel1 As New SqlDataAdapter("DECLARE @TRAEDIF AS INT  declare @activar as bit set @activar = 0 SELECT @TRAEDIF = DEVCANT  FROM DEVOLUCION where IDRUTA = '1' IF @TRAEDIF > 0 BEGIN SELECT [IDPROD] AS CODIGO,[Descripcion] as DESCRIPCION,[DEVCANT] AS CANT_RUTA,[DEVCOSTO] AS COSTO,[DEVFECHA] AS FECHA,[IDUSER] AS USUARIO,@activar as RESURTIR, b.alterno FROM [DEVOLUCION] a, productos b where IDPROD = [Codigo de producto] AND a.IDRUTA = '1'  END ELSE BEGIN        SELECT [IDPROD] AS CODIGO,[Descripcion] as DESCRIPCION,CASE WHEN (DEVCANT > 0) THEN DEVCPTE - DEVCANT ELSE DEVCPTE END AS CANT_RUTA,[DEVCOSTO] AS COSTO,[DEVFECHA] AS FECHA,[IDUSER] AS USUARIO,@activar as RESURTIR, b.alterno FROM [DEVOLUCION] a, productos b where IDPROD = [Codigo de producto] AND a.IDRUTA = '" & RUTSID & "' and DEVACT = 1 END  ", SqlCnn)
            'Dim SqlSel1 As New SqlDataAdapter("declare @dev as int select @dev = COUNT(*) FROM SURTIDORUTAS WHERE IDRUTA = '" & RUTSID & "' AND ESTATUS = 0 AND RESURTIR is NULL if @dev > 0 begin declare @activar as bit set @activar = 0 SELECT [IDPROD] AS CODIGO,[Descripcion] as DESCRIPCION,[DEVCPTE] AS CANT_RUTA,[DEVCOSTO] AS COSTO,[DEVFECHA] AS FECHA,[IDUSER] AS USUARIO,@activar as RESURTIR FROM [DEVOLUCION] a, productos b where IDPROD = [Codigo de producto] AND a.IDRUTA = '" & RUTSID & "' END ", SqlCnn)
            SqlSel1.Fill(DS2)
            Me.DGINVRUTA.DataSource = DS2

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message.ToString)
        End Try
        Me.DGINVRUTA.Columns("alterno").Visible = False
        If DS2.Rows.Count = 0 Then

        Else
            Dim l As Int32
            For l = 0 To DS2.Rows.Count - 1
                Me.DGINVRUTA.Rows(l).Cells(0).ReadOnly = True
                Me.DGINVRUTA.Rows(l).Cells(1).ReadOnly = True
                Me.DGINVRUTA.Rows(l).Cells(2).ReadOnly = True
                Me.DGINVRUTA.Rows(l).Cells(3).ReadOnly = True
                Me.DGINVRUTA.Rows(l).Cells(4).ReadOnly = True
                Me.DGINVRUTA.Rows(l).Cells(5).ReadOnly = True

            Next

        End If

    End Sub
    

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim Sqlsuma As New SqlCommand("SELECT IDRUTA FROM RUTAS WHERE NOMBRE = '" & Me.ComboBox1.Text & "' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlsuma.ExecuteReader
            While SqlRead.Read
                RUTSID = SqlRead.GetInt32(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.DGINVRUTA.Rows.Count > 0 Then

        Else
            Exit Sub
        End If
        Dim i As Integer = 0
        Dim resp
        resp = MsgBox("Desea autorizar recarga de producto a la la ruta: " & Trim(Me.ComboBox1.Text) & ", ¿Es correcto?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            If Me.ComboBox1.Text = Nothing Then
                MsgBox("Favor de seleccionar la ruta que se va autorizar")
            Else
                If DS2.Rows.Count > -1 Then
                    'Dim Sqldetalle As New SqlCommand("DELETE FROM SURTIDORUTAS WHERE IDRUTA = '" & RUTSID & "' AND ESTATUS = 0 ", SqlCnn)
                    'Dim SqlRead As SqlDataReader
                    'Try
                    '    SqlRead = Sqldetalle.ExecuteReader
                    '    While SqlRead.Read
                    '    End While
                    '    SqlRead.Close()
                    'Catch ex As SqlException
                    '    MsgBox(ex.Message.ToString)
                    'End Try
                    Dim FechayHora As String
                    For Each row As DataRow In DS2.Rows
                        If row("RESURTIR") = True Then
                            Dim fechayh As Date = row("FECHA")
                            FechayHora = fechayh.ToString("yyyyMMdd")
                            Dim Sqldetalle2 As New SqlCommand("INSERT INTO SURTIDORUTAS VALUES('" & RUTSID & "','" & row("CODIGO") & "','" & row("CANT_RUTA") & "','" & row("COSTO") & "',GETDATE(),'0','1','true','" & row("ALTERNO") & "','" & FechayHora & "',NULL)  ", SqlCnn)
                            'UPDATE DEVOLUCION SET DEVACT = '0' WHERE IDRUTA = '" & Me.ComboBox1.SelectedValue & "'
                            Dim Sqldetalle3 As New SqlCommand("UPDATE DEVOLUCION SET DEVCANT = 0, DEVACT = '0' WHERE IDRUTA = '" & Me.ComboBox1.SelectedValue & "' and IDPROD = '" & row("CODIGO") & "' ", SqlCnn)
                            Dim SqlRead2 As SqlDataReader
                            Dim SqlRead3 As SqlDataReader
                            Try
                                SqlRead2 = Sqldetalle2.ExecuteReader
                                While SqlRead2.Read
                                End While
                                SqlRead2.Close()
                                SqlRead3 = Sqldetalle3.ExecuteReader
                                SqlRead3.Close()
                            Catch ex As SqlException
                                MsgBox(ex.Message.ToString)
                            End Try
                        End If
                    Next
                    MsgBox("Recarga actualizada para la ruta : " & Trim(ComboBox1.Text))
                    Me.Close()
                Else
                    MsgBox("No existe nada que guardar")
                End If
            End If
        End If

    End Sub

End Class