Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions


Public Class FrmMarcas
    Dim clave, razon, abr, rfc, calle, noext, noint, postal, munic, estado, pais, colonia, refer, tel, email, contacto As String
    Dim act As Boolean
    Dim idCreCli As Int32
    Dim traemonto As Double
    Dim Sep As Char
    Private Exis As Boolean

    Private conv As Boolean = False

    Private Const CopyKeys As Keys = Keys.Control Or Keys.C
    Private Const PasteKeys As Keys = Keys.Control Or Keys.V

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If (keyData = CopyKeys) OrElse (keyData = PasteKeys) Then
            Return True

        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        'If (keyData = CopyKeys) OrElse (keyData = PasteKeys) Then
        '    conv = True
        'Else
        '    conv = False
        'End If
        'Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Sub pongamayus()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.CharacterCasing = CharacterCasing.Upper
            Else
            End If
        Next
    End Sub
    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Exis = False
        Traepaises()
        TraeEstados()
        CargaGrid()
        pongamayus()
        Me.TxtCodigo.Text = GENERAIDCLIENTE()
    End Sub
    Public Function GENERAIDCLIENTE() As Integer
        Dim Sqlpedi As New SqlCommand("SELECT MAX(Clave) FROM Clientes", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim CLAVE As Integer
        Try
            SqlRead = Sqlpedi.ExecuteReader
            While SqlRead.Read
                CLAVE = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return CLAVE + 1
    End Function
    Public Sub TraeEstados()
        Dim SqlClientes As New SqlCommand("SELECT estado FROM Estados ORDER BY estado", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.CBESTADO.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Traepaises()
        Dim SqlClientes As New SqlCommand("SELECT pais FROM paises ORDER BY pais", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Clientes As New String(Nothing)
        Try
            SqlRead = SqlClientes.ExecuteReader
            While SqlRead.Read
                Me.CBPAIS.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub TraeCredito(ByVal idcli As Int32)
        Dim Sqlpedi As New SqlCommand("SELECT d.ID_CreditoCliente ,d.Monto_CreditoCliente, dbo.StatusCredCte.Descripcion_StatusCredCte FROM dbo.StatusCredCte FULL OUTER JOIN dbo.CreditoCliente AS d ON dbo.StatusCredCte.ID_StatusCredCte = d.Id_StatusCredCte WHERE  (d.FechaAsignada_CreditoCliente = (SELECT MAX(FechaAsignada_CreditoCliente) AS Expr1 FROM dbo.CreditoCliente WHERE   (Clave = '" & idcli & "')))", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim CLAVE As Integer
        Me.LblStatusCredito.Text = ""
        Me.txtCredito.Text = "0.00"
        Me.ChkBCredito.Checked = False
        Try
            SqlRead = Sqlpedi.ExecuteReader
            While SqlRead.Read
                idCreCli = SqlRead.GetValue(0)
                Me.txtCredito.Text = SqlRead.GetValue(1)
                traemonto = Me.txtCredito.Text
                If SqlRead.GetValue(2) Is DBNull.Value Then
                    Me.LblStatusCredito.Text = 0
                Else
                    Me.LblStatusCredito.Text = SqlRead.GetValue(2)
                End If

                Me.ChkBCredito.Checked = True
                If Me.LblStatusCredito.Text = "Agotado" Then
                    Me.LblStatusCredito.ForeColor = Color.Red
                Else
                    Me.LblStatusCredito.ForeColor = Color.Green
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub CargaGrid()
        Dim SqlSel As New SqlDataAdapter("SELECT a.Clave, a.razon, a.abreviatura, a.rfc, a.calle, a.calle1,a.calle2, a.noext, a.noint, a.codigop, a.municipio, b.estado, c.pais, a.colonia, a.refer, a.telefono, a.email, a.contacto, a.activo, a.NoExtTel FROM clientes a, estados b, paises c where a.estado = b.id_edo and b.pais = c.id_pais order by a.clave ", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGCLIENTES
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub GuardaCredito(ByVal MontoCredito As Double)
        'Dim Sqltempsal As New SqlCommand(" declare @ID_CreditoCliente int  if exists(select clave from Clientes where Clave = '" & Me.TxtCodigo.Text & "') begin if '" & Me.LblStatusCredito.Text & "' = 'Disponible' begin UPDATE CreditoCliente SET Id_StatusCredCte = 3 WHERE ID_CreditoCliente = '" & idCreCli & "' set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente )  " & _
        '" set @ID_CreditoCliente = @ID_CreditoCliente + 1  insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & Me.txtCredito.Text & "',1) " & _
        '" END else begin " & _
        '" if '" & Me.ChkBCredito.Checked & "' = 'true' begin " & _
        '" set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente)  " & _
        '" declare @stat int set @stat = (select Id_StatusCredCte from CreditoCliente where ID_CreditoCliente = @ID_CreditoCliente) " & _
        '" if @ID_CreditoCliente IS null begin set @ID_CreditoCliente = 1   " & _
        '" end else begin set @ID_CreditoCliente = @ID_CreditoCliente +1 end  " & _
        '" if @stat is null begin set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente ) if @ID_CreditoCliente IS null begin set @ID_CreditoCliente = 1  " & _
        '" end else begin set @ID_CreditoCliente = @ID_CreditoCliente +1 end  end insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & Me.txtCredito.Text & "',1) end " & _
        '" else if @stat = 1 begin delete from CreditoCliente where Clave = '" & Me.TxtCodigo.Text & "' and Id_StatusCredCte = @stat set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente ) set @ID_CreditoCliente = @ID_CreditoCliente + 1 insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & Me.txtCredito.Text & "',1) end " & _
        '" else if @stat = 2 begin set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente ) set @ID_CreditoCliente = @ID_CreditoCliente + 1 insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & Me.txtCredito.Text & "',1) end " & _
        '" end end  ", SqlCnn)
        Dim Sqltempsal As New SqlCommand(" declare @ID_CreditoCliente int  if exists(select clave from Clientes where Clave = '" & Me.TxtCodigo.Text & "') begin if '" & Me.LblStatusCredito.Text & "' = 'Disponible' begin UPDATE CreditoCliente SET Id_StatusCredCte = 3 WHERE ID_CreditoCliente = '" & idCreCli & "' set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente )  " & _
        " set @ID_CreditoCliente = @ID_CreditoCliente + 1  insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & MontoCredito & "',1) " & _
        " END else begin " & _
        " if '" & Me.ChkBCredito.Checked & "' = 'true' begin " & _
        " set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente)  " & _
        " declare @stat int set @stat = (select Id_StatusCredCte from CreditoCliente where ID_CreditoCliente = @ID_CreditoCliente) " & _
        " if @ID_CreditoCliente IS null begin set @ID_CreditoCliente = 1   " & _
        " end else begin set @ID_CreditoCliente = @ID_CreditoCliente +1 end  " & _
        " if @stat is null begin set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente ) if @ID_CreditoCliente IS null begin set @ID_CreditoCliente = 1  " & _
        " end else begin set @ID_CreditoCliente = @ID_CreditoCliente +1 end  end insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & MontoCredito & "',1) end " & _
        " else if @stat = 1 begin delete from CreditoCliente where Clave = '" & Me.TxtCodigo.Text & "' and Id_StatusCredCte = @stat set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente ) set @ID_CreditoCliente = @ID_CreditoCliente + 1 insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & MontoCredito & "',1) end " & _
        " else if @stat = 2 begin set @ID_CreditoCliente = (select max(ID_CreditoCliente) from CreditoCliente ) set @ID_CreditoCliente = @ID_CreditoCliente + 1 insert into CreditoCliente values (@ID_CreditoCliente, getdate(), '" & Me.TxtCodigo.Text & "', '" & MontoCredito & "',1) end " & _
        " end end  ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqltempsal.ExecuteReader
            'While SqlRead.Read
            '    folio = SqlRead.GetValue(0)
            'End While
            SqlRead.Close()
            MsgBox("Credito Actualizado")
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Function guardacliente()
        contacto = Me.TXTCONTACTO.Text.Trim
        Dim Sqltempsal As New SqlCommand(" declare @ID_CreditoCliente int DECLARE @EDO int DECLARE @PAI int SET @EDO = (SELECT id_edo FROM Estados WHERE estado = '" & estado & "') SET @PAI = (SELECT id_pais FROM Paises WHERE pais = '" & pais & "') IF EXISTS(SELECT * FROM clientes WHERE clave = '" & Me.TxtCodigo.Text & "') " & _
        "BEGIN " & _
        "UPDATE clientes SET razon = '" & razon & "' , abreviatura = '" & abr & "', rfc = '" & rfc & "', calle = '" & calle & "', calle1 = '" & Me.TXTCALLE2.Text.Trim & "', calle2 = '" & Me.TXTCALLE3.Text.Trim & "',noext = '" & noext & "',noint = '" & noint & "',codigop = '" & postal & "'," & _
        " municipio = '" & munic & "' ,estado = @EDO ,pais = @PAI ,colonia = '" & colonia & "' ,refer = '" & refer & "' ,telefono = '" & tel & "' ,email = '" & email & "' ,contacto = '" & contacto & "' , activo = '" & act & "', NoExtTel = '" & Me.TEXTNoExtTel.Text.Trim & "' " & _
        "WHERE clave = '" & Me.TxtCodigo.Text & "' " & _
        "END " & _
        "ELSE " & _
        "BEGIN " & _
        "INSERT INTO clientes(clave,razon,abreviatura,empresa,rfc,sucursal,calle,calle1,calle2,noext,noint,colonia,codigop,municipio,estado,pais,refer,telefono,email,contacto,activo, NoExtTel,FIngreso) VALUES('" & clave & "','" & razon & "','" & abr & "','" & razon & "','" & rfc & "','MTR','" & calle & "','" & Me.TXTCALLE2.Text.Trim & "','" & Me.TXTCALLE3.Text.Trim & "','" & noext & "','" & noint & "','" & colonia & "','" & postal & "','" & munic & "',@EDO,@PAI,'" & refer & "','" & tel & "','" & email & "','" & contacto & "','" & act & "','" & Me.TEXTNoExtTel.Text.Trim & "', getdate()) " & _
        " END " & _
        "IF NOT EXISTS(SELECT * FROM Cat_ClienteRuta WHERE IDMAQUINA = '" & Me.TxtCodigo.Text.Trim & "' ) " & _
        "Begin INSERT INTO Cat_ClienteRuta (IDMAQUINA,CODEMAQ,DESCRIPCION,TOTAL,DIRECCION,INSTALACION,RUTA) Values ('" & Me.TxtCodigo.Text.Trim & "','" & Me.TxtCodigo.Text.Trim & "','" & razon & "', 0,'" & calle & "', getdate(), 0) End ELSE  " & _
        "BEGIN UPDATE Cat_ClienteRuta SET CODEMAQ = '" & Me.TxtCodigo.Text.Trim & "', DESCRIPCION = '" & razon & "', DIRECCION = '" & Me.TXTCALLE1.Text.Trim & "' WHERE IDMAQUINA = '" & Me.TxtCodigo.Text.Trim & "'  END ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqltempsal.ExecuteReader
            'While SqlRead.Read
            '    folio = SqlRead.GetValue(0)
            'End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub ValidaDatos()

        With Me
            clave = .TxtCodigo.Text
            clave = Trim(clave)
            razon = .TxtRazon.Text
            razon = Trim(razon)
            abr = .txtAbr.Text
            abr = Trim(abr)
            If .txtRFC.Text = Nothing Then
                rfc = "X"
            Else
                rfc = .txtRFC.Text
                rfc = Trim(rfc)
            End If

            If .CheckBox1.Checked = True Then
                act = True
            Else
                act = False
            End If

            If .TXTCALLE1.Text = Nothing Then
                calle = "NA"
            Else
                calle = .TXTCALLE1.Text
                calle = Trim(calle)
            End If

            If .TXTNOEXT.Text = Nothing Then
                noext = "0"
            Else
                noext = .TXTNOEXT.Text
                noext = Trim(noext)
            End If
            If .TXTNOINT.Text = Nothing Then
                noint = "0"
            Else
                noint = .TXTNOINT.Text
                noint = Trim(noint)
            End If

            If .CBESTADO.Text = Nothing Then
                estado = "Nuevo León"
            Else
                estado = .CBESTADO.Text
                estado = Trim(estado)
            End If

            If .CBPAIS.Text = Nothing Then
                pais = "México"
            Else
                pais = .CBPAIS.Text
                pais = Trim(pais)
            End If

            If .TXTMUNIC.Text = Nothing Then
                munic = "Monterrey"
            Else
                munic = .TXTMUNIC.Text
                munic = Trim(munic)
            End If

            If .TXTCOL.Text = Nothing Then
                colonia = "NA"
            Else
                colonia = .TXTCOL.Text
                colonia = Trim(colonia)
            End If

            If .TXTREFER.Text = Nothing Then
                refer = "NA"
            Else
                refer = .TXTREFER.Text
                refer = Trim(refer)
            End If
            If .TXTTEL.Text = Nothing Then
                tel = "NA"
            Else
                tel = .TXTTEL.Text
                tel = Trim(tel)
            End If
            If .TXTMAIL.Text = Nothing Then
                email = "@"
            Else
                email = .TXTMAIL.Text
                email = Trim(email)
            End If
            If .TEXTNoExtTel.Text = Nothing Then
                .TEXTNoExtTel.Text = 0
            End If
        End With

    End Sub
    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click

        ValidaDatos()
        If clave = Nothing Or razon = Nothing Or abr = Nothing Then
            MsgBox("Requiere llenar los campos de clave, razon y abreviatura para poder seguir")
        Else
            Dim regnom As String
            If Exis = True Then
                Dim SqlSel3 As New SqlCommand("SELECT Abreviatura FROM CLIENTES WHERE Abreviatura = '" & Me.txtAbr.Text.Trim & "' and clave <> '" & Me.TxtCodigo.Text.Trim & "' ", SqlCnn)
                Dim SqlRead3 As SqlDataReader
                Try
                    SqlRead3 = SqlSel3.ExecuteReader
                    While (SqlRead3.Read)
                        regnom = SqlRead3.GetString(0).ToString
                    End While
                    SqlRead3.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                If regnom <> "" Then
                    MsgBox("Ya existe la Abreviatura: " & Me.txtAbr.Text.Trim & "")
                    Exit Sub
                End If
            Else
                Dim regnom1 As String

                Dim SqlSel3 As New SqlCommand("SELECT Abreviatura FROM CLIENTES where Abreviatura = '" & Me.txtAbr.Text.Trim & "' ", SqlCnn)
                Dim SqlRead3 As SqlDataReader
                Try
                    SqlRead3 = SqlSel3.ExecuteReader
                    While (SqlRead3.Read)
                        regnom1 = SqlRead3.GetString(0).ToString
                    End While
                    SqlRead3.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
                If regnom1 <> "" Then
                    MsgBox("Ya existe la Abreviatura: " & Me.txtAbr.Text.Trim & "")
                    Exit Sub
                End If

            End If
            guardacliente()
            MsgBox("Se agrego y/o actualizo registro")
            traemonto = 0
            Me.TxtCodigo.Text = Nothing
            Me.TxtRazon.Text = Nothing
            Me.txtAbr.Text = Nothing
            Me.txtRFC.Text = Nothing
            Me.TXTCALLE1.Text = Nothing
            Me.TXTNOEXT.Text = Nothing
            Me.TXTCP.Text = Nothing
            Me.TXTMUNIC.Text = Nothing
            Me.CBESTADO.Text = Nothing
            Me.CBPAIS.Text = Nothing
            Me.TXTCOL.Text = Nothing
            Me.TXTREFER.Text = Nothing
            Me.TXTTEL.Text = Nothing
            Me.TXTMAIL.Text = Nothing
            Me.TXTCONTACTO.Text = Nothing
            Me.CheckBox1.Checked = False
            Me.txtCredito.Text = "0.00"
            Me.ChkBCredito.Checked = False
            Me.LblStatusCredito.Text = ""
            For Each c As Control In GroupBox1.Controls
                If TypeOf c Is TextBox Then
                    Dim Tboxtem As TextBox = CType(c, TextBox)
                    Tboxtem.Text = ""
                Else
                    If TypeOf c Is ComboBox Then
                        Dim Cboxtem As ComboBox = CType(c, ComboBox)
                        Cboxtem.Text = ""
                    Else
                        If TypeOf c Is CheckBox Then
                            Dim Chboxtem As CheckBox = CType(c, CheckBox)
                            Chboxtem.Checked = False
                        Else

                        End If
                    End If
                End If
            Next
            CargaGrid()
        End If
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub DGCLIENTES_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCLIENTES.CellClick
        If e.RowIndex > -1 Then

            If DGCLIENTES.Rows(e.RowIndex).Cells("Clave").Value IsNot DBNull.Value Then
                Exis = True
                TxtCodigo.Text = DGCLIENTES.Rows(e.RowIndex).Cells("Clave").Value
                Me.TXTBOXCodBarr.Text = TxtCodigo.Text
                TxtRazon.Text = DGCLIENTES.Rows(e.RowIndex).Cells("Razon").Value
                txtAbr.Text = DGCLIENTES.Rows(e.RowIndex).Cells("Abreviatura").Value
                txtRFC.Text = DGCLIENTES.Rows(e.RowIndex).Cells("RFC").Value
                TXTCALLE1.Text = DGCLIENTES.Rows(e.RowIndex).Cells("calle").Value
                If DGCLIENTES.Rows(e.RowIndex).Cells("calle1").Value Is DBNull.Value Then
                    TXTCALLE2.Text = ""
                Else
                    TXTCALLE2.Text = DGCLIENTES.Rows(e.RowIndex).Cells("calle1").Value
                End If
                If DGCLIENTES.Rows(e.RowIndex).Cells("calle2").Value Is DBNull.Value Then
                    TXTCALLE3.Text = ""
                Else
                    TXTCALLE3.Text = DGCLIENTES.Rows(e.RowIndex).Cells("calle2").Value
                End If
                TXTNOEXT.Text = DGCLIENTES.Rows(e.RowIndex).Cells("noext").Value
                TXTNOINT.Text = DGCLIENTES.Rows(e.RowIndex).Cells("noint").Value
                TXTCOL.Text = DGCLIENTES.Rows(e.RowIndex).Cells("colonia").Value
                TXTCP.Text = DGCLIENTES.Rows(e.RowIndex).Cells("codigop").Value
                TXTMUNIC.Text = DGCLIENTES.Rows(e.RowIndex).Cells("municipio").Value
                CBESTADO.Text = DGCLIENTES.Rows(e.RowIndex).Cells("estado").Value
                CBPAIS.Text = DGCLIENTES.Rows(e.RowIndex).Cells("pais").Value
                TXTREFER.Text = DGCLIENTES.Rows(e.RowIndex).Cells("refer").Value
                TXTTEL.Text = DGCLIENTES.Rows(e.RowIndex).Cells("telefono").Value
                TXTMAIL.Text = DGCLIENTES.Rows(e.RowIndex).Cells("email").Value
                TXTCONTACTO.Text = DGCLIENTES.Rows(e.RowIndex).Cells("contacto").Value
                If DGCLIENTES.Rows(e.RowIndex).Cells("NoExtTel").Value Is DBNull.Value Then
                    Me.TEXTNoExtTel.Text = ""
                Else
                    Me.TEXTNoExtTel.Text = DGCLIENTES.Rows(e.RowIndex).Cells("NoExtTel").Value
                End If

                Dim act As Boolean
                act = DGCLIENTES.Rows(e.RowIndex).Cells("activo").Value
                If act = True Then
                    Me.CheckBox1.Checked = True
                Else
                    Me.CheckBox1.Checked = False
                End If
                idCreCli = 0
                Me.ChkBCredito.Checked = False
                Me.LblStatusCredito.Text = ""
                Me.txtCredito.Text = "0.0000"
                Call Me.TraeCredito(Me.TxtCodigo.Text)
                'Dim value As Object = DGCLIENTES.Rows(e.RowIndex).Cells(0).Value
                'Dim value1 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(1).Value
                'Dim value2 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(2).Value
                'Dim value3 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(3).Value
                'Dim value4 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(4).Value
                'Dim value5 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(5).Value
                'Dim value6 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(6).Value
                'Dim value7 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(7).Value
                'Dim value8 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(8).Value
                'Dim value9 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(9).Value
                'Dim value10 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(10).Value
                'Dim value11 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(11).Value
                'Dim value12 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(12).Value
                'Dim value13 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(13).Value
                'Dim value14 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(14).Value
                'Dim value15 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(15).Value
                'Dim value16 As Object = DGCLIENTES.Rows(e.RowIndex).Cells(16).Value

                'If value.GetType Is GetType(DBNull) Then Return

                'clave = CType(value, String)
                'razon = CType(value1, String)
                'abr = CType(value2, String)
                'rfc = CType(value3, String)
                'calle = CType(value4, String)
                'noext = CType(value5, String)
                'noint = CType(value6, String)
                'postal = CType(value7, String)
                'munic = CType(value8, String)
                'estado = CType(value9, String)
                'pais = CType(value10, String)
                'colonia = CType(value11, String)
                'refer = CType(value12, String)
                'tel = CType(value13, String)
                'email = CType(value14, String)
                'contacto = CType(value15, String)
                'act = CType(value16, Boolean)

                'Me.TxtCodigo.Text = Trim(clave)
                'Me.TxtRazon.Text = Trim(razon)
                'Me.txtAbr.Text = Trim(abr)
                'Me.txtRFC.Text = Trim(rfc)
                'Me.TXTCALLE.Text = Trim(calle)
                'Me.TXTNOEXT.Text = Trim(noext)
                'Me.TXTNOINT.Text = Trim(noint)
                'Me.TXTCP.Text = Trim(postal)
                'Me.TXTMUNIC.Text = Trim(munic)
                'Me.CBESTADO.Text = Trim(estado)
                'Me.CBPAIS.Text = Trim(pais)
                'Me.TXTCOL.Text = Trim(colonia)
                'Me.TXTREFER.Text = Trim(refer)
                'Me.TXTTEL.Text = Trim(tel)
                'Me.TXTMAIL.Text = Trim(email)
                'Me.TXTCONTACTO.Text = Trim(contacto)

                'If act = True Then
                '    Me.CheckBox1.Checked = True
                'Else
                '    Me.CheckBox1.Checked = False
                'End If
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TextBox2.Text <> Nothing Then

            'Dim SqlSel As New SqlDataAdapter("SELECT FROM Clientes WHERE  Razon like '%" & TextBox2.Text & "%'", SqlCnn)
            Dim SqlSel As New SqlDataAdapter("SELECT a.Clave, a.Razon, a.Abreviatura, a.RFC, a.calle,a.calle1, a.calle2, a.noext, a.noint, a.codigop, a.municipio, b.estado, c.pais, a.colonia, a.refer, a.telefono,a.email, a.contacto, a.activo, a.NoExtTel FROM clientes a, estados b, paises c where a.estado = b.id_edo and b.pais = c.Id_pais and   Razon like '%" & TextBox2.Text & "%'", SqlCnn)

            Dim DS1 As New DataTable
            Try
                SqlSel.Fill(DS1)
                With Me.DGCLIENTES
                    .DataSource = DS1
                End With
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            End Try

        Else
            MsgBox("No hay datos para buscar")
        End If
    End Sub

    Private Sub TxtRazon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRazon.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            'Me.txtAbr.Text = Mid(TxtRazon.Text, 1, 12)
            Me.txtAbr.Focus()
        End If

    End Sub

   
   
    Private Sub DGCLIENTES_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCLIENTES.CellContentClick

    End Sub

    Private Sub TxtRazon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRazon.TextChanged

    End Sub

    Private Sub txtAbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbr.KeyPress

    End Sub

    Private Sub txtAbr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAbr.TextChanged

    End Sub
    Sub limpiar()
        
        For Each c As Control In GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim txttemp As TextBox = CType(c, TextBox)
                txttemp.Text = "" ' eliminar el texto
                c.Text = ""

            Else
                If TypeOf c Is ComboBox Then
                    Dim txttemp As ComboBox = CType(c, ComboBox)
                    txttemp.Text = "" ' eliminar el texto
                Else
                    If TypeOf c Is CheckBox Then
                        Dim txttemp As CheckBox = CType(c, CheckBox)
                        txttemp.Checked = False ' poner en false
                    Else

                    End If
                End If
            End If
        Next

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        idCreCli = 0
        traemonto = 0
        limpiar()
        Me.TxtCodigo.Text = GENERAIDCLIENTE()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Exis = False Then
            MsgBox("Selecciona un cliente")
            Exit Sub
        End If
        If Me.ChkBCredito.Checked = True Then
            If Me.txtCredito.Text = "" Or Me.txtCredito.Text = "0.00" Or Me.txtCredito.Text = "0.0000" Then
                MsgBox("Error, favor de ingresar el monto de credito")
                Me.txtCredito.Focus()
                Exit Sub
            Else
                If Me.LblStatusCredito.Text = "Disponible" And Val(Me.txtCredito.Text) >= traemonto Then
                    'If Me.LblStatusCredito.Text = "Disponible" Then
                    Dim resp
                    Dim masaumento As Double = Val(Me.txtCredito.Text) + traemonto
                    resp = MsgBox("El monto que desea capturar es " & masaumento & ", desea aumentar el credito?", MsgBoxStyle.OkCancel)
                    If resp = vbOK Then
                        Call Me.GuardaCredito(masaumento)
                    End If
                Else
                    If Me.LblStatusCredito.Text <> "Disponible" Then
                        Call Me.GuardaCredito(Me.txtCredito.Text)
                    End If
                End If

            End If
        Else
            MsgBox("favor de ingresar el monto de credito")
        End If
    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        For Each c As Control In GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.Text = ""
            Else
                If TypeOf c Is ComboBox Then
                    Dim Cboxtem As ComboBox = CType(c, ComboBox)
                    Cboxtem.Text = ""
                Else
                    If TypeOf c Is CheckBox Then
                        Dim Chboxtem As CheckBox = CType(c, CheckBox)
                        Chboxtem.Checked = False
                    Else

                    End If
                End If
            End If
        Next
        Exis = False
        Me.txtCredito.Text = "0.00"
        Me.LblStatusCredito.Text = ""
        Me.TxtCodigo.Text = GENERAIDCLIENTE()
        Me.TXTBOXCodBarr.Text = Me.TxtCodigo.Text
    End Sub

    Private Sub TXTTEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTEL.KeyPress
        'If IsNumeric(TXTTEL) = False Then
        '    MsgBox("Lo siento. Debe Ingresar SOLAMENTE Números.", vbInformation)
        '    TXTTEL.Focus()

        'End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
        If Not (Char.IsNumber(e.KeyChar)) Then e.Handled = True
       
    End Sub

    Private Sub TXTTEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTEL.Validated
        'If Not Me.TXTTEL.Text.Length = 13 Then
        '    MessageBox.Show("Son 10 digitos ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    TXTTEL.Text = vbNullChar
        '    TXTTEL.Focus()
        'Else
        '    TXTTEL.Focus()
        'End If
    End Sub

    Private Sub TXTTEL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTEL.TextChanged

    End Sub

    Private Sub txtRFC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRFC.KeyDown
        If e.Modifiers = Keys.Control Then

            e.Handled = True

            Me.txtRFC.SelectionLength = 0

        End If

    End Sub

    Private Sub txtRFC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If e.KeyChar = Chr(13) Then


        End If
    End Sub

    Private Sub txtRFC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRFC.TextChanged

        Static tam As Integer
        Static noChange As Boolean

        Dim strLetra As String = ""
        Dim blFlag As Boolean = False
        If Me.txtRFC.SelectionStart = 0 Then
            Exit Sub
        End If
        'If Me.txtRFC.SelectionStart = 0 Then
        '    If Me.txtRFC.TextLength >= 3 Then
        '        Dim oo As Int32
        '        For oo = 1 To Me.txtRFC.TextLength
        '            Dim vp As String = Mid(Me.txtRFC.Text, oo, 1)
        '            If oo <= 3 Then
        '                Select Case Asc(vp)
        '                    Case 97 To 122 : blFlag = False    'Es letra de la a -> z
        '                    Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
        '                    Case 8 : blFlag = False         'Tecla de retroceso
        '                    Case 32 : blFlag = False       'Tecla de espacio e blanco
        '                    Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
        '                    Case Else
        '                        blFlag = True
        '                        'Exit Select
        '                End Select
        '                If blFlag = True Then
        '                    MsgBox("RFC invalido")
        '                End If
        '            Else
        '                If oo = 4 And vp = " " Then

        '                Else
        '                    If oo = 4 Then
        '                        Select Case Asc(vp)
        '                            Case 97 To 122 : blFlag = False    'Es letra de la a -> z
        '                            Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
        '                            Case 8 : blFlag = False         'Tecla de retroceso
        '                            Case 32 : blFlag = False       'Tecla de espacio e blanco
        '                            Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
        '                            Case Else
        '                                blFlag = True
        '                                'Exit Select
        '                        End Select
        '                        If blFlag = True Then
        '                            MsgBox("RFC invalido")
        '                        End If
        '                    Else
        '                        If oo = 5 And vp = " " Then

        '                        Else
        '                            If oo >= 5 And oo <= 11 Then
        '                                Select Case Asc(vp)
        '                                    Case 97 To 122 : blFlag = True    'Es letra de la a -> z
        '                                    Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
        '                                    Case 8 : blFlag = False         'Tecla de retroceso
        '                                    Case 32 : blFlag = False       'Tecla de espacio e blanco
        '                                    Case 48 To 57 : blFlag = False    'Es un número 0 -> 9  
        '                                    Case Else
        '                                        blFlag = True
        '                                        'Exit Select
        '                                End Select
        '                                If blFlag = True Then
        '                                    MsgBox("RFC invalido")
        '                                End If

        '                            Else

        '                            End If
        '                        End If
        '                    End If
        '                End If

        '            End If
        '        Next
        '    End If
        '    Exit Sub
        'Else
        '    'If Me.txtRFC.TextLength >= 3 Then
        '    '    Dim oo As Int32
        '    '    For oo = 1 To Me.txtRFC.TextLength
        '    '        Dim vp As String = Mid(Me.txtRFC.Text, oo, 1)
        '    '        If oo <= 3 Then
        '    '            Select Case Asc(vp)
        '    '                Case 97 To 122 : blFlag = False    'Es letra de la a -> z
        '    '                Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
        '    '                Case 8 : blFlag = False         'Tecla de retroceso
        '    '                Case 32 : blFlag = False       'Tecla de espacio e blanco
        '    '                Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
        '    '                Case Else
        '    '                    blFlag = True
        '    '                    'Exit Select
        '    '            End Select
        '    '            If blFlag = True Then
        '    '                MsgBox("RFC invalido: " & vp)
        '    '            End If
        '    '        Else
        '    '            If oo = 4 And vp = " " Then

        '    '            Else
        '    '                If oo = 4 Then
        '    '                    Select Case Asc(vp)
        '    '                        Case 97 To 122 : blFlag = False    'Es letra de la a -> z
        '    '                        Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
        '    '                        Case 8 : blFlag = False         'Tecla de retroceso
        '    '                        Case 32 : blFlag = False       'Tecla de espacio e blanco
        '    '                        Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
        '    '                        Case Else
        '    '                            blFlag = True
        '    '                            'Exit Select
        '    '                    End Select
        '    '                    If blFlag = True Then
        '    '                        MsgBox("RFC invalido: " & vp)
        '    '                    End If
        '    '                Else
        '    '                    If oo = 5 And vp = " " Then

        '    '                    Else
        '    '                        If oo >= 5 And oo <= 10 Then
        '    '                            Select Case Asc(vp)
        '    '                                Case 97 To 122 : blFlag = True    'Es letra de la a -> z
        '    '                                Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
        '    '                                Case 8 : blFlag = False         'Tecla de retroceso
        '    '                                Case 32 : blFlag = False       'Tecla de espacio e blanco
        '    '                                Case 48 To 57 : blFlag = False    'Es un número 0 -> 9  
        '    '                                Case Else
        '    '                                    blFlag = True
        '    '                                    'Exit Select
        '    '                            End Select
        '    '                            If blFlag = True Then
        '    '                                MsgBox("RFC invalido: " & vp)
        '    '                            End If

        '    '                        Else
        '    '                            If Mid(Me.txtRFC.Text, 4, 1) = " " And oo = 11 Then
        '    '                                Select Case Asc(vp)
        '    '                                    Case 97 To 122 : blFlag = True    'Es letra de la a -> z
        '    '                                    Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
        '    '                                    Case 8 : blFlag = False         'Tecla de retroceso
        '    '                                    Case 32 : blFlag = False       'Tecla de espacio e blanco
        '    '                                    Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
        '    '                                    Case Else
        '    '                                        blFlag = True
        '    '                                        'Exit Select
        '    '                                End Select
        '    '                                If blFlag = True Then
        '    '                                    MsgBox("RFC invalido: " & vp)
        '    '                                End If
        '    '                            Else
        '    '                                If oo = 11 Then
        '    '                                    Select Case Asc(vp)
        '    '                                        Case 97 To 122 : blFlag = True    'Es letra de la a -> z
        '    '                                        Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
        '    '                                        Case 8 : blFlag = False         'Tecla de retroceso
        '    '                                        Case 32 : blFlag = False       'Tecla de espacio e blanco
        '    '                                        Case 48 To 57 : blFlag = False    'Es un número 0 -> 9  
        '    '                                        Case Else
        '    '                                            blFlag = True
        '    '                                            'Exit Select
        '    '                                    End Select
        '    '                                    If blFlag = True Then
        '    '                                        MsgBox("RFC invalido: " & vp)
        '    '                                    End If
        '    '                                Else

        '    '                                End If
        '    '                            End If
        '    '                        End If
        '    '                    End If
        '    '                End If
        '    '            End If

        '    '        End If
        '    '    Next
        '    'End If
        '    'Exit Sub
        'End If
        Dim pos As Int32 = Me.txtRFC.SelectionStart
        Dim enco As String = Me.txtRFC.Text.IndexOf(" ")
        Dim encor As String = Me.txtRFC.Text.LastIndexOf(" ")
        Dim texch As String = Mid(Me.txtRFC.Text, Me.txtRFC.SelectionStart, 1)
        Dim nas As Int32 = Asc(texch)

        If enco < 0 Then
            If pos <= 3 Then
                Select Case Asc(texch)
                    Case 97 To 122 : blFlag = False    'Es letra de la a -> z
                    Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
                    Case 8 : blFlag = False         'Tecla de retroceso
                    Case 32 : blFlag = False       'Tecla de espacio e blanco
                    Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
                    Case Else
                        blFlag = True
                        'Exit Select
                End Select
            Else
                If pos And texch = " " Then
                    'Select Case Asc(texch)
                    '    Case 97 To 122 : blFlag = False   'Es letra de la a -> z
                    '    Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
                    '    Case 8 : blFlag = False         'Tecla de retroceso
                    '    Case 32 : blFlag = False       'Tecla de espacio e blanco
                    '    Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
                    '    Case Else
                    '        blFlag = True
                    '        'Exit Select
                    'End Select
                    Me.txtRFC.SelectionStart = pos
                Else
                    If pos = 4 Then
                        Select Case Asc(texch)
                            Case 97 To 122 : blFlag = False    'Es letra de la a -> z
                                Me.txtRFC.Text = Me.txtRFC.Text & " "
                                Me.txtRFC.SelectionStart = pos
                            Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
                                Me.txtRFC.Text = Me.txtRFC.Text & " "
                                Me.txtRFC.SelectionStart = pos + 1
                            Case 8 : blFlag = False         'Tecla de retroceso
                            Case 32 : blFlag = False       'Tecla de espacio e blanco
                            Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
                            Case Else
                                blFlag = True
                                'Exit Select
                        End Select
                    Else
                        If pos = 5 Then
                            Select Case Asc(texch)
                                Case 97 To 122 : blFlag = True    'Es letra de la a -> z
                                    Me.txtRFC.Text = Me.txtRFC.Text & " "
                                    Me.txtRFC.SelectionStart = pos + 1
                                Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
                                    Me.txtRFC.Text = Me.txtRFC.Text & " "
                                    Me.txtRFC.SelectionStart = pos + 1
                                Case 8 : blFlag = False         'Tecla de retroceso
                                Case 32 : blFlag = True       'Tecla de espacio e blanco
                                Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
                                    Me.txtRFC.Text = Me.txtRFC.Text & " "
                                    Me.txtRFC.SelectionStart = pos + 1
                                Case Else
                                    blFlag = True
                                    Me.txtRFC.Text = Me.txtRFC.Text & " "
                                    Me.txtRFC.SelectionStart = pos + 1
                                    'Exit Select
                            End Select
                        Else
                            If Me.txtRFC.TextLength > 5 Then
                                MsgBox("RFC invalido")
                                Me.txtRFC.SelectAll()
                                Me.txtRFC.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        Else
            If enco = 3 And pos > 4 And pos <= 10 Then
                Select Case Asc(texch)
                    Case 97 To 122 : blFlag = True    'Es letra de la a -> z
                    Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
                    Case 8 : blFlag = False         'Tecla de retroceso
                    Case 32 : blFlag = True       'Tecla de espacio e blanco
                    Case 48 To 57 : blFlag = False    'Es un número 0 -> 9  
                    Case Else
                        blFlag = True
                        'Exit Select
                End Select

            Else

                If enco = 4 And pos >= 5 And pos <= 11 Then
                    Select Case Asc(texch)
                        Case 97 To 122 : blFlag = True    'Es letra de la a -> z
                        Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
                        Case 8 : blFlag = False         'Tecla de retroceso
                        Case 32 : blFlag = False       'Tecla de espacio e blanco
                        Case 48 To 57 : blFlag = False    'Es un número 0 -> 9  
                        Case Else
                            blFlag = True
                            'Exit Select
                    End Select
                Else
                    If enco = 3 And pos = 11 Then
                        Select Case Asc(texch)
                            Case 97 To 122 : blFlag = True    'Es letra de la a -> z
                            Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
                            Case 8 : blFlag = False         'Tecla de retroceso
                            Case 32 : blFlag = False       'Tecla de espacio e blanco
                            Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
                            Case Else
                                blFlag = True
                                'Exit Select
                        End Select
                    Else
                        If enco = 4 And pos = 12 Then
                            Select Case Asc(texch)
                                Case 97 To 122 : blFlag = True    'Es letra de la a -> z
                                Case 65 To 90 : blFlag = True     'Es letra de la A -> Z
                                Case 8 : blFlag = False         'Tecla de retroceso
                                Case 32 : blFlag = False       'Tecla de espacio e blanco
                                Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
                                Case Else
                                    blFlag = True
                                    'Exit Select
                            End Select
                        Else
                            If enco >= 5 Then
                                MsgBox("RFC invalido")
                                Me.txtRFC.SelectAll()
                                Me.txtRFC.Focus()
                            Else
                                If (enco = 3 Or enco = 4) And (encor = 10 Or encor = 11) Then
                                    Select Case Asc(texch)
                                        Case 97 To 122 : blFlag = False    'Es letra de la a -> z
                                        Case 65 To 90 : blFlag = False     'Es letra de la A -> Z
                                        Case 8 : blFlag = False         'Tecla de retroceso
                                        Case 32 : blFlag = False       'Tecla de espacio e blanco
                                        Case 48 To 57 : blFlag = False    'Es un número 0 -> 9  
                                        Case Else
                                            blFlag = True
                                            'Exit Select
                                    End Select
                                Else
                                    If enco = 0 Then
                                        blFlag = True
                                    Else
                                        If enco <> 3 And enco <> 4 And encor <> 10 And encor <> 11 Then
                                            blFlag = True
                                        Else

                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If


        If blFlag Then
            MsgBox("caracter invalido: " & texch)
            Dim ctext As String = txtRFC.Text
            Me.txtRFC.Text = Mid(Me.txtRFC.Text, 1, pos - 1) & "" & Mid(Me.txtRFC.Text, pos + 1, Me.txtRFC.TextLength)
            Me.txtRFC.SelectionStart = pos
            Exit Sub
        Else

        End If

        Exit Sub
        ''''''If (pos = 3 Or pos = 4 Or pos = 11 Or pos = 12) And enco > -1 And texch = " " Then
        '' '' ''    noChange = True
        '' '' ''    Select Case Asc(texch)
        '' '' ''        Case 97 To 122 : blFlag = True   'Es letra de la a -> z
        '' '' ''        Case 65 To 90 : blFlag = True    'Es letra de la A -> Z
        '' '' ''        Case 8 : blFlag = False         'Tecla de retroceso
        '' '' ''        Case 32 : blFlag = False       'Tecla de espacio e blanco
        '' '' ''        Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
        '' '' ''        Case Else
        '' '' ''            blFlag = True
        '' '' ''            'Exit Select
        '' '' ''    End Select
        '' '' ''    If blFlag Then
        '' '' ''        Me.txtRFC.Text = Mid(Me.txtRFC.Text, 1, pos - 1) & " " & Mid(Me.txtRFC.Text, pos + 1, Me.txtRFC.TextLength)
        '' '' ''    End If
        '' '' ''Else
        '' '' ''    If (pos < enco) And enco = 4 Then
        '' '' ''        Select Case Asc(texch)
        '' '' ''            Case 8 : blFlag = False         'Tecla de retroceso
        '' '' ''            Case 32 : blFlag = False       'Tecla de espacio e blanco
        '' '' ''            Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  
        '' '' ''            Case Else
        '' '' ''                blFlag = True
        '' '' ''                'Exit Select
        '' '' ''        End Select
        '' '' ''        If blFlag Then
        '' '' ''            Me.txtRFC.Text = Mid(Me.txtRFC.Text, 1, pos - 1) & "" & Mid(Me.txtRFC.Text, pos + 1, Me.txtRFC.TextLength)
        '' '' ''        End If
        '' '' ''    Else
        '' '' ''        If (pos = enco) And enco = 4 Then
        '' '' ''            Select Case Asc(texch)
        '' '' ''                Case 8 : blFlag = False         'Tecla de retroceso
        '' '' ''                Case 32 : blFlag = False       'Tecla de espacio e blanco
        '' '' ''                Case 48 To 57 : blFlag = True    'Es un número 0 -> 9  }
        '' '' ''                Case 97 To 122 : blFlag = False   'Es letra de la a -> z
        '' '' ''                Case 65 To 90 : blFlag = False    'Es letra de la A -> Z
        '' '' ''                Case Else
        '' '' ''                    blFlag = True
        '' '' ''                    'Exit Select
        '' '' ''            End Select

        '' '' ''        Else
        '' '' ''            If enco = 4 And pos >= 5 And pos <= 10 Then
        '' '' ''                Select Case Asc(texch)
        '' '' ''                    Case 97 To 122 : blFlag = True   'Es letra de la a -> z
        '' '' ''                    Case 65 To 90 : blFlag = True    'Es letra de la A -> Z
        '' '' ''                    Case 8 : blFlag = False         'Tecla de retroceso
        '' '' ''                    Case 32 : blFlag = True       'Tecla de espacio e blanco
        '' '' ''                    Case 48 To 57 : blFlag = False     'Es un número 0 -> 9  }
        '' '' ''                    Case Else
        '' '' ''                        blFlag = True
        '' '' ''                        'Exit Select
        '' '' ''                End Select
        '' '' ''            End If
        '' '' ''        End If
        '' '' ''    End If
        '' '' ''    noChange = True

        '' '' ''End If




        '' '' ''If blFlag Then
        '' '' ''    MsgBox("caracter invalido: " & texch)
        '' '' ''    Dim ctext As String = txtRFC.Text
        '' '' ''    txtRFC.Text = ctext.Replace(texch, "")
        '' '' ''    Me.txtRFC.SelectionStart = pos
        '' '' ''    Exit Sub
        '' '' ''Else

        '' '' ''End If
        '' '' ''If pos > enco And pos < encor Then

        '' '' ''    Select Case Asc(texch)
        '' '' ''        Case 97 To 122 : blFlag = True   'Es letra de la a -> z
        '' '' ''        Case 65 To 90 : blFlag = True    'Es letra de la A -> Z
        '' '' ''        Case 8 : blFlag = False         'Tecla de retroceso
        '' '' ''        Case 32 : blFlag = True       'Tecla de espacio e blanco
        '' '' ''        Case Else
        '' '' ''            blFlag = True
        '' '' ''            'Exit Select
        '' '' ''    End Select
        '' '' ''Else

        '' '' ''End If


        '' '' ''If blFlag Then
        '' '' ''    MsgBox("caracter invalido: " & texch)
        '' '' ''    Dim ctext As String = txtRFC.Text
        '' '' ''    'txtRFC.Text = ctext.Replace(texch, "")
        '' '' ''    Me.txtRFC.Text = Mid(Me.txtRFC.Text, 1, pos - 1) & "" & Mid(Me.txtRFC.Text, pos + 1, Me.txtRFC.TextLength)
        '' '' ''    Me.txtRFC.SelectionStart = pos
        '' '' ''    Exit Sub
        '' '' ''Else

        '' '' ''End If
        '' '' ''Exit Sub
        'Dim o As Int32
        'For o = 1 To Me.txtRFC.TextLength
        '    strLetra = Mid(Me.txtRFC.Text, o, Me.txtRFC.TextLength)
        '    Dim nas As Int32 = Asc(strLetra)
        '    Select Case Asc(strLetra)
        '        Case 97 To 122 : blFlag = True   'Es letra de la a -> z
        '        Case 65 To 90 : blFlag = True    'Es letra de la A -> Z
        '            'Case 48 To 57 : blFlag = True    'Es un número 0 -> 9   
        '        Case 8 : blFlag = True         'Tecla de retroceso
        '        Case 32                         'Tecla de espacio e blanco
        '            'If Me.txtRFC.TextLength <> 4 Or Me.txtRFC.TextLength <> 5 Or Me.txtRFC.TextLength <> 11 Then

        '            'Else
        '            If Me.txtRFC.TextLength = 4 Then
        '                txtRFC.SelectionStart = txtRFC.TextLength + 1
        '                o = o + 1
        '            Else
        '                If Me.txtRFC.TextLength = 5 Then
        '                    txtRFC.SelectionStart = txtRFC.TextLength + 1
        '                    o = o + 1
        '                Else
        '                    If Me.txtRFC.TextLength = 11 Then
        '                        txtRFC.SelectionStart = txtRFC.TextLength + 1
        '                        o = o + 1
        '                    Else
        '                        txtRFC.Text.Replace(" ", "")
        '                        txtRFC.SelectionStart = txtRFC.TextLength - 1
        '                        o = o - 1
        '                        blFlag = False
        '                        Exit For
        '                    End If
        '                End If
        '            End If
        '            'blFlag = False
        '            'End If
        '        Case Else : blFlag = False
        '            Exit For
        '    End Select
        'Next

        'If blFlag = False Then
        '    MsgBox("caracter no valido")
        '    txtRFC.SelectAll()
        '    txtRFC.Focus()
        'End If
        'If txtRFC.TextLength = 1 Then
        '    noChange = False
        'End If
        'If noChange = False Then

        '    If txtRFC.TextLength > tam Then

        '        If txtRFC.TextLength - tam = 1 Then ' el texto se introdujo por teclado o sólo se pegó un carácter...

        '            If txtRFC.TextLength = 4 Or txtRFC.TextLength = 11 Then

        '                tam = txtRFC.TextLength + 1

        '                ' aquí podrías poner también el nochange=true  y después de la siguiente línea el =false

        '                txtRFC.Text += " "

        '                txtRFC.SelectionStart = txtRFC.TextLength  ' si eliminas esta línea el cursor se irá al inicio...

        '            End If


        '        Else ' se ha pegado texto.. ya que el teclado dispara el evento carácter a carácter...y se han añadido más de 1 de golpe.

        '            If txtRFC.TextLength > 3 Then

        '                Dim txt As String  ' para valores temporales


        '                txt = txtRFC.Text.Replace(" ", "") ' elimina guiones (por si no existieran en el lugar adecuado)

        '                Select Case txt.Length

        '                    Case (3)

        '                        txt &= "-"

        '                    Case 4 To 9

        '                        txt = txt.Substring(0, 4) & " " & txt.Substring(4, txt.Length - 4)

        '                    Case (10)

        '                        txt = txt.Substring(0, 4) & " " & txt.Substring(4, 6) & " "

        '                    Case Is > 10

        '                        txt = txt.Substring(0, 4) & " " & txt.Substring(4, 6) & " " & txt.Substring(10, txt.Length - 10)

        '                End Select

        '                noChange = True

        '                txtRFC.Text = txt

        '                txtRFC.SelectionStart = txtRFC.TextLength  ' olvidé meter esta línea.... para que el cursor se vaya al final de la edición.

        '                noChange = False

        '            End If

        '        End If

        '    End If
        '    If txtRFC.TextLength <> 4 Or txtRFC.TextLength <> 5 Or txtRFC.TextLength <> 11 Or txtRFC.TextLength <> 12 Then
        '        strLetra = Mid(Me.txtRFC.Text, Me.txtRFC.TextLength, 1)
        '        Dim nas As Int32 = Asc(strLetra)
        '        Select Case Asc(strLetra)
        '            Case 97 To 122 : blFlag = True   'Es letra de la a -> z
        '            Case 65 To 90 : blFlag = True    'Es letra de la A -> Z
        '                'Case 48 To 57 : blFlag = True    'Es un número 0 -> 9   
        '            Case 8 : blFlag = True         'Tecla de retroceso
        '            Case 32                         'Tecla de espacio e blanco
        '                'If Me.txtRFC.TextLength <> 4 Or Me.txtRFC.TextLength <> 5 Or Me.txtRFC.TextLength <> 11 Then

        '                'Else
        '                Dim ttxt As String = txtRFC.Text.Replace(" ", "")
        '                txtRFC.Text = ttxt
        '                txtRFC.SelectionStart = txtRFC.TextLength - 1

        '                blFlag = False
        '                Exit Select

        '                'blFlag = False
        '                'End If
        '            Case Else : blFlag = False
        '                Exit Select
        '        End Select
        '    End If
        '    tam = txtRFC.TextLength

        'End If
        If Me.txtRFC.TextLength = 1 Then
            tam = 0
        End If
        Dim tipoc As String = ""



        If Me.txtRFC.TextLength > 0 Then
            strLetra = Mid(Me.txtRFC.Text, Me.txtRFC.TextLength, 1)
        Else
            Exit Sub
        End If

        If txtRFC.TextLength <= 5 And tam = 1 Then
            Dim o As Int32
            Dim revl As String
            Dim Senc As Boolean = False
            For o = 1 To Me.txtRFC.TextLength
                revl = Mid(Me.txtRFC.Text, o, 1)
                Select Case Asc(revl)
                    Case 48 To 57 : Senc = True
                        Exit For  'Es un número 0 -> 9   
                    Case Else
                        Exit Select
                End Select
            Next
            If Senc = True Then
                Dim ctext1 As String = txtRFC.Text.Replace(revl, "")
                txtRFC.Text = ctext1
                txtRFC.SelectionStart = txtRFC.TextLength
                Exit Sub
            End If
        Else
            If enco > -1 Then
                Dim o As Int32
                Dim revl As String
                Dim Senc As Boolean = False
                For o = 1 To enco
                    revl = Mid(Me.txtRFC.Text, o, 1)
                    Select Case Asc(revl)
                        Case 48 To 57 : Senc = True
                            Exit For  'Es un número 0 -> 9   
                        Case Else
                            Exit Select
                    End Select
                Next
                If Senc = True Then
                    Dim ctext1 As String = txtRFC.Text.Replace(revl, "")
                    txtRFC.Text = ctext1
                    txtRFC.SelectionStart = txtRFC.TextLength
                    Exit Sub
                End If
            End If
        End If

        Dim pall As Int32 = Asc(strLetra)
        If (txtRFC.TextLength <= 5) And pall <> 32 And tam = 0 Then
            tipoc = "l"
            'Me.txtRFC.Text = Me.txtRFC.Text & " "
            If txtRFC.TextLength = 4 And pall <> 32 And tam = 0 Then
                Me.txtRFC.Text = Me.txtRFC.Text & " "
                tam = 0
            End If
        End If
        'If tam = 1 Then
        '    tipoc = "n"
        'End If
        If enco > -1 Then
            tipoc = "n"
        End If
        If enco = 3 And Me.txtRFC.TextLength = 10 Then
            Me.txtRFC.Text = Me.txtRFC.Text & " "
        Else
            If enco = 3 And Me.txtRFC.TextLength > 10 Then
                If strLetra = " " Then
                    tipoc = ""
                Else
                    tipoc = "t"
                End If

            Else
                If enco = 4 And Me.txtRFC.TextLength = 11 Then
                    Me.txtRFC.Text = Me.txtRFC.Text & " "
                Else
                    If enco = 4 And Me.txtRFC.TextLength > 11 Then
                        tipoc = ""
                    Else

                    End If
                End If
            End If
        End If
        If encor > -1 Then
            Select Case Asc(strLetra)
                Case 97 To 122 And tipoc = "t" : blFlag = True   'Es letra de la a -> z
                Case 65 To 90 And tipoc = "t" : blFlag = True    'Es letra de la A -> Z
                Case 48 To 57 And tipoc = "t" : blFlag = True    'Es un número 0 -> 9  

                Case 97 To 122 And tipoc = "n" : blFlag = True   'Es letra de la a -> z
                Case 65 To 90 And tipoc = "n" : blFlag = True    'Es letra de la A -> Z
                Case 48 To 57 And tipoc = "l" : blFlag = True    'Es un número 0 -> 9   
                Case 8 : blFlag = True         'Tecla de retroceso
                Case 32                         'Tecla de espacio e blanco
                Case Else
                    Exit Select
            End Select
        End If


        If blFlag Then
            MsgBox("caracter invalido:" & strLetra)
            Dim ctext As String = txtRFC.Text.Replace(strLetra, "")
            txtRFC.Text = ctext
        Else
            If pall = 32 Then
                tam = 1
            End If
        End If
        txtRFC.SelectionStart = txtRFC.TextLength






        'If txtRFC.TextLength = 3 Or txtRFC.TextLength = 4 Then
        '    If Mid(Me.txtRFC.Text, Me.txtRFC.TextLength, 1) = " " Then

        '    End If
        'End If

        'If Me.txtRFC.TextLength <= 4 Then
        '    Dim vf As String = Mid(Me.txtRFC.Text, Me.txtRFC.TextLength, 1)
        '    If Regex.IsMatch(txtRFC.Text.Trim, "^([A-Z\s]{4})\d{6}([A-Z\w]{3})$") = False Then
        '        MsgBox("El Registro no es válido. El formato correcto es: LLL ###### LL ó LLLL ###### LLL. L=Letra, #=Número.")
        '        Me.txtRFC.Focus()
        '    End If
        'End If

        'If txtRFC.TextLength = 4 Or txtRFC.TextLength = 11 Then

        '    'txtRFC.Text += "-"

        '    txtRFC.SelectionStart = txtRFC.TextLength

        'End If


    End Sub

    Private Sub txtRFC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRFC.Validated
        'If txtRFC.Text <> String.Empty Then
        '    If Regex.IsMatch(txtRFC.Text.Trim, "^([A-Z\s]{4})\d{6}([A-Z\w]{3})$") = False Then
        '        MsgBox("El Registro no es válido. El formato correcto es: LLL ###### LL ó LLLL ###### LLL. L=Letra, #=Número.")
        '        Me.txtRFC.Focus()
        '    End If
        'End If
    End Sub

    Private Sub txtRFC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRFC.Validating
        'If txtRFC.Text <> String.Empty Then
        '    If Regex.IsMatch(txtRFC.Text.Trim, "^([A-Z\s]{4})\d{6}([A-Z\w]{3})$") = False Then
        '        MsgBox("El Registro no es válido. El formato correcto es: LLL ###### LL ó LLLL ###### LLL. L=Letra, #=Número.")
        '        Me.txtRFC.Focus()
        '    End If
        'End If
    End Sub

    Private Sub TXTMAIL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMAIL.TextChanged

    End Sub

    Private Sub TXTMAIL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMAIL.Validating
        Try
            Dim mail As New System.Net.Mail.MailAddress(TXTMAIL.Text)
            MessageBox.Show("Correo valido")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.TXTMAIL.SelectAll()
            Me.TXTMAIL.Focus()
        End Try

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TEXTNoExtTel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTNoExtTel.KeyPress
        If Not (Char.IsNumber(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub TEXTNoExtTel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTNoExtTel.TextChanged

    End Sub
End Class