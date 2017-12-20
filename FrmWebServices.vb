Imports System.Data.SqlClient
Imports System.Data
Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient


Partial Class FrmWebServices
    Dim PEDX As String
    Dim PEDXs As String
    Dim HTTPCLIENTES As String
    Dim HTTPPRODUCTS As String
    Dim HTTPSALIDAS As String
    Dim HTTPDETSAL As String
    Dim zona As String = Nothing
    Dim mesE As String = Nothing
    Dim CANTAR, COUNTLOTE As Integer
    Dim clavealm As String
    Dim DMP As New DataTable
    Dim DMT As New DataTable
    Dim DMD As New DataTable
    Dim DMe As New DataTable
    Dim xpb As Long
    Dim filepath1 As String = ""
    Private conexion As MySqlConnection
    'Private Const userMSQL As String = "miisacom_invroot"
    'Private Const serverMSQL As String = "67.225.221.124"
    'Private Const passMSQL As String = "invROOT143"

    'Private Const userMSQL As String = "root"
    'Private Const serverMSQL As String = "LOCALHOST"
    'Private Const passMSQL As String = "12345"
    Dim conexionMYSQLerror As Integer


    Private Sub FrmWebServices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexionMYSQLerror = 0
        leeMySQL()
        If conexionMYSQLerror = 0 Then
            FillProds()
            FillPeds()
            FillPedsdetalle()
            Timer1.Enabled = True
        Else : Me.Close()
        End If
    End Sub
    Private Sub leexml()
        Dim reader As XmlTextReader = New XmlTextReader(filepath1)
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Display beginning of element.
                    Console.Write("<" + reader.Name)
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()
                            'Display attribute name and value.
                            If reader.ReadElementContentAsString = "producto" Then
                                Console.Write("es rrecto,es correcto,es correcto,es correcto,es correcto")
                                On Error Resume Next
                            End If

                            Console.Write(" {0}='{1}'", reader.Name, reader.Value)
                        End While
                    End If
                    Console.WriteLine(">")
                Case XmlNodeType.Text 'Display the text in each element.
                    If reader.HasValue Then 'If attributes exist
                        Console.WriteLine(reader.Value)
                    End If
                    'Console.WriteLine(reader.Value)
                Case XmlNodeType.EndElement 'Display end of element.
                    Console.Write("</" + reader.Name)
                    Console.WriteLine(">")
            End Select
        Loop
    End Sub
    Private Sub leeMySQL()
        Dim ok As Boolean = False
        Try
            conexion = New MySqlConnection()
            conexion.ConnectionString = "server=" & serverMSQL & ";" & "user id=" & userMSQL & ";" & "password=" & passMSQL & ";database=" & BDMSQL & ";"
            conexion.Open()
            ErrorBox.Text = "conectado..." & vbCrLf & ErrorBox.Text

        Catch ex As MySqlException
            MsgBox("No se puede conectar al servidor")
            conexionMYSQLerror = 1
            'Me.Close()
        End Try
        If conexion.State <> ConnectionState.Closed Then conexion.Close()
    End Sub
    Public Sub FillProds()

        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & serverMSQL & ";" & "user id=" & userMSQL & ";" & "password=" & passMSQL & ";database=" & BDMSQL & ";"
        'conexion.Open()
        Dim SQL = "SELECT id_product,id_manufacturer,id_category_default,quantity,minimal_quantity,price,REFERENCE,supplier_reference,active FROM " & BDMSQL & ".ps_product;"
        'Try
        conexion.Open()
        Try
            myCommand.Connection = conexion
            myCommand.CommandText = SQL
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(DMP)
            'DGPEDIDO.DataSource = DMP
        Catch myerror As MySqlException
            MsgBox("Ocurrió un error leyendo la base de datos: " & myerror.Message)
        End Try
        'Catch myerror As MySqlException
        'MessageBox.Show("Ocurrió un error conectando a la base de datos: " & myerror.Message)
        'Finally
        If conexion.State <> ConnectionState.Closed Then conexion.Close()
        'End Try
    End Sub
    Public Sub FillPeds()
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter

        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & serverMSQL & ";" & "user id=" & userMSQL & ";" & "password=" & passMSQL & ";database=" & BDMSQL & ";"
        'conexion.Open()
        Dim SQL = "SELECT id_pedido,nombre_cliente,fecha_pedido,estatus FROM " & BDMSQL & ".inv_pedidos WHERE estatus = '1';"
        'Dim SQL = "SELECT id_pedido,nombre_cliente,estatus FROM miisacom_prestashop1430RE.inv_pedidos WHERE estatus = '1';"
        'Try
        conexion.Open()
        Try
            myCommand.Connection = conexion
            myCommand.CommandText = SQL
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(DMT)
            'DGPEDIDO.DataSource = DMT

        Catch myerror As MySqlException
            MsgBox("Ocurrió un error leyendo la base de datos: " & myerror.Message)
        End Try
        'Catch myerror As MySqlException
        'MessageBox.Show("Ocurrió un error conectando a la base de datos: " & myerror.Message)
        'Finally
        If conexion.State <> ConnectionState.Closed Then conexion.Close()
        'End Try
        'select a.id_order, a.product_id, a.product_quantity from ps_order_detail a, inv_pedidos b where b.id_pedido = a.id_order and b.estatus = '1'
    End Sub
    Public Sub FillPedsdetalle()
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & serverMSQL & ";" & "user id=" & userMSQL & ";" & "password=" & passMSQL & ";database=" & BDMSQL & ";"
        'conexion.Open()
        Dim SQL2 = "select a.id_order, a.product_id, a.product_quantity from ps_order_detail a, inv_pedidos b where b.id_pedido = a.id_order and b.estatus = '1';"
        'Try
        conexion.Open()
        Try
            myCommand.Connection = conexion
            myCommand.CommandText = SQL2
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(DMD)
        Catch myerror As MySqlException
            MsgBox("Ocurrió un error leyendo la base de datos: " & myerror.Message)
        End Try
        If conexion.State <> ConnectionState.Closed Then conexion.Close()
    End Sub

    'Private Sub CargaGrid()
    '    Dim SqlSel As New SqlDataAdapter("SELECT A.ID_PED as IDSALIDA, B.EMPRESA as CLIENTE, SUM(D.TOTAL_PED) as COSTO, A.FECHA_PED AS FECHA, A.UTIL_PED AS SURTIR, C.NOMBRE AS ALMACEN, A.PROTOCOLO AS PROTOCOLO, A.DESARR_ID AS DESARROLLO, A.PEDIDOORIGIN AS PEDIDO FROM PEDIDOS A, CLIENTES B, ALMACENES C, PEDIDOS_DET D WHERE A.CLIENTE_PED = B.CLAVE AND A.ALM_ID = C.CLAVE AND A.ID_PED = D.ID_PED AND A.UTIL_PED = 0 GROUP BY A.ID_PED, B.Empresa, A.FECHA_PED, A.UTIL_PED, C.NOMBRE, A.PROTOCOLO, A.DESARR_ID, A.PEDIDOORIGIN ORDER BY A.ID_PED", SqlCnn)
    '    Dim DS As New DataTable
    '    'Dim ARRAYPASO As New ObjProducto
    '    Try
    '        SqlSel.Fill(DS)
    '        With Me.DGPEDIDO
    '            .DataSource = DS
    '        End With
    '    Catch ex As SqlException
    '        MsgBox(ex.Message.ToString)
    '    End Try
    'End Sub
    Private Sub CargaGridDetalle(ByVal idped As String)
        'idped = Trim(idped)
        'Dim SqlSeldet As New SqlDataAdapter("SELECT A.[Codigo de Producto] as PRODUCTO, B.[Nombre Corto] as DESCRIPCION, A.CANT_PROD as CANTIDAD, A.COSTO_PROD AS PRECIO, A.MONTO_PROD AS SUBTOTAL, A.IVA_PROD AS IVA, A.TOTAL_PED AS TOTAL FROM PEDIDOS_DET A, PRODUCTOS B WHERE A.[Codigo de Producto] = B.[Codigo de Producto] AND A.ID_PED = '" & idped & "'", SqlCnn)
        'Dim DS As New DataTable
        'Try
        '    SqlSeldet.Fill(DS)
        '    With Me.DTDET
        '        .DataSource = DS
        '    End With
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try
    End Sub
    'Private Sub CargaGridS()
    '    Dim SqlSel2 As New SqlDataAdapter("SELECT A.ID_PED as IDSALIDA, B.EMPRESA as CLIENTE, SUM(D.TOTAL_PED) as COSTO, A.FECHA_PED AS FECHA, A.UTIL_PED AS SURTIR, C.NOMBRE AS ALMACEN, A.PROTOCOLO AS PROTOCOLO, A.DESARR_ID AS DESARROLLO, A.PEDIDOORIGIN AS PEDIDO FROM PEDIDOS A, CLIENTES B, ALMACENES C, PEDIDOS_DET D WHERE A.CLIENTE_PED = B.CLAVE AND A.ALM_ID = C.CLAVE AND A.ID_PED = D.ID_PED AND A.UTIL_PED = 1 GROUP BY A.ID_PED, B.Empresa, A.FECHA_PED, A.UTIL_PED, C.NOMBRE, A.PROTOCOLO, A.DESARR_ID, A.PEDIDOORIGIN ORDER BY A.ID_PED", SqlCnn)
    '    Dim DS2 As New DataTable
    '    Try
    '        SqlSel2.Fill(DS2)
    '        With Me.DGSINSURTIR
    '            .DataSource = DS2
    '        End With
    '    Catch ex As SqlException
    '        MsgBox(ex.Message.ToString)
    '    End Try
    'End Sub
    Private Function guardaclientes(ByVal idcliente As String, ByVal emp As String, ByVal abr As String, ByVal contac As String, ByVal t_pers As String, ByVal tpers As String, ByVal entidad As String, ByVal dir As String, ByVal codpos As String, ByVal pais As String, ByVal tel As String, ByVal mpio As String, ByVal edo As String, ByVal email As String, ByVal rfc As String, ByVal razon As String, ByVal activo As String) As Integer
        Dim datosx As Integer = 0
        idcliente = Trim(idcliente)
        emp = Trim(emp)
        abr = Trim(abr)
        contac = Trim(contac)
        t_pers = Trim(t_pers)
        tpers = Trim(tpers)
        entidad = Trim(entidad)
        dir = Trim(dir)
        codpos = Trim(codpos)
        pais = Trim(pais)
        tel = Trim(tel)
        mpio = Trim(mpio)
        edo = Trim(edo)
        email = Trim(email)
        rfc = Trim(rfc)
        razon = Trim(razon)
        activo = Trim(activo)
        If idcliente.Length > 20 Then
            ErrorBox.Text = "El id de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If emp.Length > 100 Then
            ErrorBox.Text = "El nombre de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If abr.Length > 100 Then
            ErrorBox.Text = "La abreviatura de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If contac.Length > 150 Then
            ErrorBox.Text = "El contacto de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        'If tpers.Length > 20 Then
        '    ErrorBox.Text = ErrorBox.Text + "El tipo de " & emp & " es demasiado largo" & vbCrLf
        'End If
        If dir.Length > 250 Then
            ErrorBox.Text = "La direccion de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If codpos.Length > 6 Then
            ErrorBox.Text = "El Codigo Postal de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If pais.Length > 20 Then
            ErrorBox.Text = "El pais de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If tel.Length > 30 Then
            ErrorBox.Text = "El telefono de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If mpio.Length > 30 Then
            ErrorBox.Text = "El municipio de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If edo.Length > 30 Then
            ErrorBox.Text = "El estado de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If email.Length > 100 Then
            ErrorBox.Text = "El email de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If rfc.Length > 20 Then
            ErrorBox.Text = "El RFC de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If razon.Length > 150 Then
            ErrorBox.Text = "La Razon Social de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If activo.Length > 1 Then
            ErrorBox.Text = "Activo de " & emp & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If datosx = 0 Then
            Dim Sqlclientenvo As New SqlCommand("DECLARE @Descripcion nchar(30) " & _
            "IF NOT EXISTS(SELECT * FROM clientes WHERE clave = '" & idcliente & "') " & _
            "BEGIN " & _
            "INSERT INTO clientes VALUES('" & idcliente & "','" & razon & "','" & abr & "','" & emp & "','" & rfc & "',1,'" & dir & "',0,0,'NA','" & codpos & "','" & mpio & "','" & edo & "','" & pais & "','NA','" & tel & "','" & email & "','" & contac & "','" & activo & "','0','0') " & _
            "End ", SqlCnn)

            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlclientenvo.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
            Catch ex As SqlException
                ErrorBox.Text = "Error en base de datos cliente: " & emp & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        End If
    End Function
    Private Function guardaproductos(ByVal idpro As String, ByVal alm As String, ByVal nam As String, ByVal desc As String, ByVal nombre As String, ByVal alta As String, ByVal um As String, ByVal provee As String, ByVal preven As Decimal, ByVal precom As Decimal, ByVal exis As Decimal, ByVal min As Decimal, ByVal max As Decimal) As Integer
        Dim datosx As Integer = 0
        idpro = Trim(idpro)
        alm = Trim(alm)
        nam = Trim(nam)
        desc = Trim(desc)
        nombre = Trim(nombre)
        alta = Trim(alta)
        um = Trim(um)
        If idpro.Length > 15 Or idpro.Length < 0 Then
            ErrorBox.Text = "El id de " & nombre & " no cumple con los requisitos " & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If alm.Length > 4 Then
            ErrorBox.Text = "El numero de alamcen de " & nombre & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If nam.Length > 50 Then
            ErrorBox.Text = "La nombre del almacen de " & nombre & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If desc.Length > 100 Then
            ErrorBox.Text = "La descripcion del " & nombre & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If nombre.Length > 20 Then
            ErrorBox.Text = "El nombre  de " & nombre & " es demasiado largo" & vbCrLf & ErrorBox.Text
        End If
        If alta.Length > 25 Then
            ErrorBox.Text = "La fecha de alta de " & nombre & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If um.Length > 50 Then
            ErrorBox.Text = "La unidad de medida de " & nombre & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If provee.Length > 50 Then
            ErrorBox.Text = "El proveedor de " & nombre & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If datosx = 0 Then
            Dim Sqlclientenvo As New SqlCommand("DECLARE @provnum nchar(50) " & _
            "DECLARE @um nchar(50) " & _
            "DECLARE @CAP bigint " & _
            "SET @provnum = (select clave FROM proveedores WHERE nombre = '" & provee & "') " & _
            "SET @um = (select clave FROM unidaddemedida WHERE nombre = '" & um & "') " & _
            "IF NOT EXISTS(SELECT * FROM productos WHERE alterno= '" & idpro & "') " & _
            "BEGIN " & _
            "INSERT INTO productos VALUES('" & idpro & "','SI','" & alm & "','" & desc & "','" & nombre & "','0',@provnum,'F001',@um,'" & alta & "','NO','" & precom & "','" & preven & "','SI','0.16','" & min & "','" & max & "','" & exis & "'," & idpro & ") " & _
            "INSERT INTO Existencias VALUES('" & idpro & "','0.00','False','0') " & _
            "SET @CAP = (SELECT MAX(IDCAP) FROM productcap) + 1 " & _
            "INSERT INTO productcap VALUES(@CAP,'" & idpro & "','0.1','0.1','0.1','1','1') " & _
            "End ", SqlCnn)

            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlclientenvo.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
            Catch ex As SqlException

                ErrorBox.Text = "Error en base de datos producto: " & nombre & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        End If
    End Function
    Private Function guardapedidos(ByVal idpeds As String, ByVal idcli As String, ByVal idped As String, ByVal iddes As String, ByVal idprot As String, ByVal prot As String, ByVal fechap As String, ByVal alm As String, ByVal nomalm As String, ByVal tiposal As String, ByVal cantped As Decimal) As Integer
        Dim datosx As Integer = 0
        idpeds = Trim(idpeds)
        idcli = Trim(idcli)
        idped = Trim(idped)
        iddes = Trim(iddes)
        idprot = Trim(idprot)
        prot = Trim(prot)
        fechap = Trim(fechap)
        Dim fechap1 As String = fechap
        fechap = fechap1.Substring(8, 2) & "/" & fechap1.Substring(5, 2) & "/" & fechap1.Substring(0, 4)
        nomalm = Trim(nomalm)
        alm = Trim(alm)
        tiposal = Trim(tiposal)
        If idpeds.Length > 15 Or idpeds.Length < 1 Then
            ErrorBox.Text = "El id de la salida  " & idpeds & " no cumple con los requisitos " & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If idcli.Length > 10 Then
            ErrorBox.Text = "El idcliente de " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If idped.Length > 10 Then
            ErrorBox.Text = "El id del pedido de " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If iddes.Length > 10 Then
            ErrorBox.Text = "El id del desarrollo " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If idprot.Length > 10 Then
            ErrorBox.Text = "El id del protocolo " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
        End If
        If prot.Length > 50 Then
            ErrorBox.Text = "El protocolo " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If fechap.Length > 25 Then
            ErrorBox.Text = "La fecha " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If alm.Length > 10 Then
            ErrorBox.Text = "El almacen de " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If nomalm.Length > 50 Then
            ErrorBox.Text = "El nombre del almacen de " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If datosx = 0 Then
            Dim Sqlclientenvo As New SqlCommand("IF NOT EXISTS(SELECT * FROM pedidos WHERE id_ped = '" & idpeds & "') " & _
            "BEGIN " & _
            "INSERT INTO pedidos VALUES('" & idpeds & "','NA','" & idcli & "','0.00','NA','" & fechap & "','01/01/2000','01/01/2000','1','0','" & alm & "','" & prot & "','" & idprot & "','" & iddes & "','" & idped & "') " & _
            "End ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlclientenvo.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
            Catch ex As SqlException

                ErrorBox.Text = "Error en base de datos pedidos: " & idpeds & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        End If
    End Function
    Private Function guardapedidosDet(ByVal idpedds As String, ByVal idpedi As String, ByVal idpro As String, ByVal canti As Decimal, ByVal preci As Decimal, ByVal ivas As Decimal, ByVal montos As Decimal, ByVal fechas As String, ByVal total As Decimal) As Integer
        Dim datosx As Integer = 0
        idpedds = Trim(idpedds)
        idpedi = Trim(idpedi)
        idpro = Trim(idpro)
        fechas = Trim(fechas)
        Dim fechaps As String = fechas
        fechas = fechaps.Substring(8, 2) & "/" & fechaps.Substring(5, 2) & "/" & fechaps.Substring(0, 4)
        If idpedds.Length > 15 Or idpedds.Length < 1 Then
            ErrorBox.Text = "El id de la salida  " & idpedds & " no cumple con los requisitos " & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If idpedi.Length > 10 Then
            ErrorBox.Text = "El idpedido de " & idpedds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If idpro.Length > 10 Then
            ErrorBox.Text = "El id producto de " & idpedds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If datosx = 0 Then
            Dim Sqlclientenvo As New SqlCommand("IF NOT EXISTS(SELECT * FROM pedidos_det WHERE id_ped = '" & idpedds & "') " & _
            "BEGIN " & _
            "INSERT INTO pedidos_DET VALUES('" & idpedds & "','" & idpro & "','" & canti & "','" & preci & "','" & montos & "','" & ivas & "','" & fechas & "','01/01/2000','" & total & "','0',0) " & _
            "End ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlclientenvo.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
            Catch ex As SqlException

                ErrorBox.Text = "Error en base de datos pedidos: " & idpedds & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        End If
    End Function
    Private Function leeclientes()
        Dim errorweb As Integer = 0
        Try
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.nuvagromx.com/erp/htdocs/api/webServicesClientes.php?op=3"), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            myHttpWebResponse.Close()
        Catch e As WebException
            ErrorBox.Text = e.Message & vbCrLf & ErrorBox.Text
            errorweb = 1
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        Dim m_xmlr As XmlTextReader
        m_xmlr = New XmlTextReader("http://www.nuvagromx.com/erp/htdocs/api/webServicesClientes.php?op=3")
        m_xmlr.WhitespaceHandling = WhitespaceHandling.None
        If errorweb = 1 Then
            ErrorBox.Text = "No existe conexion en clientes" & vbCrLf & ErrorBox.Text
        Else
            m_xmlr.Read()
            m_xmlr.Read()
            While Not m_xmlr.EOF
                m_xmlr.Read()
                If Not m_xmlr.IsStartElement() Then
                    Exit While
                End If
                'Get the Gender Attribute Value
                Dim cliente = m_xmlr.GetAttribute("clave")
                'Read elements firstname and lastname
                m_xmlr.Read()
                'Get the empresa Element Value
                Dim empresa1 = m_xmlr.ReadElementString("empresa")
                Dim contacto1 = m_xmlr.ReadElementString("contacto")
                Dim abreviatura = m_xmlr.ReadElementString("abreviatura")
                Dim tipo_persona = m_xmlr.ReadElementString("tipo_persona")
                Dim tipoPersona = m_xmlr.ReadElementString("tipoPersona")
                Dim entidad = m_xmlr.ReadElementString("entidad")
                Dim direccion = m_xmlr.ReadElementString("direccion")
                Dim codigoPostal = m_xmlr.ReadElementString("codigoPostal")
                Dim pais = m_xmlr.ReadElementString("pais")
                Dim telefono = m_xmlr.ReadElementString("telefono")
                Dim municipio = m_xmlr.ReadElementString("municipio")
                Dim estado = m_xmlr.ReadElementString("estado")
                Dim email = m_xmlr.ReadElementString("email")
                Dim rfc = m_xmlr.ReadElementString("rfc")
                Dim razonSocial = m_xmlr.ReadElementString("razonSocial")
                Dim activo = m_xmlr.ReadElementString("activo")
                guardaclientes(cliente, empresa1, abreviatura, contacto1, tipo_persona, tipoPersona, entidad, direccion, codigoPostal, pais, telefono, municipio, estado, email, rfc, razonSocial, activo)
            End While
            m_xmlr.Close()

        End If
    End Function
    Public Function LoadXMLDoc() As XmlDocument
        Dim xdoc As XmlDocument
        Dim lnum As Long
        Dim pos As Long
        Dim Newxml As String
        Try
            xdoc = New XmlDocument()
            xdoc.Load(filepath1)
        Catch ex As XmlException
            MessageBox.Show(ex.Message)
            lnum = ex.LineNumber
            ReplaceSpecialChars(lnum)

            xdoc = LoadXMLDoc()

        End Try
        Return (xdoc)
    End Function
    Private Function leeproductos()
        Dim errorweb As Integer = 0
        Try
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.nuvagromx.com/erp/htdocs/api/webServicesProducto.php?op=3"), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            myHttpWebResponse.Close()
        Catch e As WebException
            ErrorBox.Text = e.Message & vbCrLf & ErrorBox.Text
            errorweb = 1
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            End If

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try



        'Dim xmldoc As New XmlDocument()
        'xmldoc = LoadXMLDoc()
        'Dim nextnode As XmlNode
        'nextnode = xmldoc.FirstChild.NextSibling
        'TextBox1.Text = nextnode.OuterXml

        Dim m_xmlr2 As XmlTextReader
        m_xmlr2 = New XmlTextReader("http://www.nuvagromx.com/erp/htdocs/api/webServicesProducto.php?op=3")
        'm_xmlr2 = New XmlTextReader(nextnode.OuterXml)
        m_xmlr2.WhitespaceHandling = WhitespaceHandling.None

        If errorweb = 1 Then
            ErrorBox.Text = "No existe conexion en producto" & vbCrLf & ErrorBox.Text
        Else
            m_xmlr2.Read()
            m_xmlr2.Read()
            While Not m_xmlr2.EOF
                m_xmlr2.Read()
                If Not m_xmlr2.IsStartElement() Then
                    Exit While
                End If
                Dim producto = m_xmlr2.GetAttribute("idProducto")
                m_xmlr2.Read()
                Dim almacen1 = m_xmlr2.ReadElementString("almacen")
                Dim namea = m_xmlr2.ReadElementString("nombreAlmacen")
                Dim desc = m_xmlr2.ReadElementString("descripcion")
                Dim name = m_xmlr2.ReadElementString("nombre")
                Dim alta = m_xmlr2.ReadElementString("fechaAlta")
                Dim um = m_xmlr2.ReadElementString("unidadMedida")
                Dim provee = m_xmlr2.ReadElementString("proveedor")
                Dim preVent = m_xmlr2.ReadElementString("precioVenta")
                Dim precomp = m_xmlr2.ReadElementString("precioCompra")
                Dim exist = m_xmlr2.ReadElementString("existencia")
                Dim minimos = m_xmlr2.ReadElementString("minimoStock")
                Dim maximos = m_xmlr2.ReadElementString("maximoCompra")
                Dim preven0 As Decimal = Val(preVent)
                Dim precom0 As Decimal = Val(precomp)
                Dim exist0 As Decimal = Val(exist)
                Dim min0 As Decimal = Val(minimos)
                Dim max0 As Decimal = Val(maximos)

                guardaproductos(producto, almacen1, namea, desc, name, alta, um, provee, preven0, precom0, exist0, min0, max0)
            End While
            m_xmlr2.Close()

        End If
    End Function
    Private Function leesalidas()
        Dim errorweb As Integer = 0
        Try
            'Create a web request for an invalid site. Substitute the "invalid site" strong in the Create call with a invalid name. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.nuvagromx.com/erp/htdocs/api/webServices.php?op=3"), HttpWebRequest)

            'Get the associated response for the above request. 
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            myHttpWebResponse.Close()
        Catch e As WebException
            ErrorBox.Text = e.Message & vbCrLf & ErrorBox.Text
            errorweb = 1
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        Dim m_xmlr3 As XmlTextReader
        m_xmlr3 = New XmlTextReader("http://www.nuvagromx.com/erp/htdocs/api/webServices.php?op=3")
        m_xmlr3.WhitespaceHandling = WhitespaceHandling.None
        If errorweb = 1 Then
            ErrorBox.Text = "No existe conexion en salidas" & vbCrLf & ErrorBox.Text
        Else
            m_xmlr3.Read()
            m_xmlr3.Read()
            While Not m_xmlr3.EOF
                m_xmlr3.Read()
                If Not m_xmlr3.IsStartElement() Then
                    Exit While
                End If
                Dim pedido = m_xmlr3.GetAttribute("idSalida")
                m_xmlr3.Read()
                Dim idcliente = m_xmlr3.ReadElementString("idCliente")
                Dim nomcli = m_xmlr3.ReadElementString("nombreCliente")
                Dim idPed = m_xmlr3.ReadElementString("idPedido")
                Dim iddes = m_xmlr3.ReadElementString("idDesarrollo")
                Dim idpro = m_xmlr3.ReadElementString("idProtocolo")
                Dim proto = m_xmlr3.ReadElementString("protocolo")
                Dim fetcha = m_xmlr3.ReadElementString("fecha")
                Dim alma = m_xmlr3.ReadElementString("almacen")
                Dim nameal = m_xmlr3.ReadElementString("nombreAlmacen")
                Dim tipoSal = m_xmlr3.ReadElementString("tipoSalida")
                Dim usuario = m_xmlr3.ReadElementString("usuario")
                Dim cantPro = m_xmlr3.ReadElementString("cantProducto")
                Dim cantpr As Decimal
                If cantPro = "" Then
                    cantpr = "0.00"
                End If
                cantpr = Val(cantPro)
                guardapedidos(pedido, idcliente, idPed, iddes, idpro, proto, fetcha, alma, nameal, tipoSal, cantpr)
            End While
            m_xmlr3.Close()
        End If
    End Function
    Private Function leeDetSalidas()
        Dim errorweb As Integer = 0
        Try
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.nuvagromx.com/erp/htdocs/api/webServicesDet.php?op=3"), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            myHttpWebResponse.Close()
        Catch e As WebException
            ErrorBox.Text = e.Message & vbCrLf & ErrorBox.Text
            errorweb = 1
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            End If

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        Dim m_xmlr4 As XmlTextReader
        m_xmlr4 = New XmlTextReader("http://www.nuvagromx.com/erp/htdocs/api/webServicesDet.php?op=3")
        m_xmlr4.WhitespaceHandling = WhitespaceHandling.None
        If errorweb = 1 Then
            ErrorBox.Text = "No existe conexion en detalles salidas" & vbCrLf & ErrorBox.Text
        Else
            m_xmlr4.Read()
            m_xmlr4.Read()
            While Not m_xmlr4.EOF
                m_xmlr4.Read()
                If Not m_xmlr4.IsStartElement() Then
                    Exit While
                End If
                Dim pedido = m_xmlr4.GetAttribute("idSalidaDet")
                m_xmlr4.Read()
                Dim idpedido = m_xmlr4.ReadElementString("idPedido")
                Dim idprod = m_xmlr4.ReadElementString("idProducto")
                Dim cantPro = m_xmlr4.ReadElementString("cantidad")
                Dim precio = m_xmlr4.ReadElementString("precio")
                Dim ivaa = m_xmlr4.ReadElementString("iva")
                Dim montopr = m_xmlr4.ReadElementString("montoProducto")
                Dim fetcha = m_xmlr4.ReadElementString("fecha")
                Dim ttal = m_xmlr4.ReadElementString("total")
                Dim cantpr4 As Decimal = Val(cantPro)
                Dim precio4 As Decimal = Val(precio)
                Dim ivaa4 As Decimal = Val(ivaa)
                Dim montopr4 As Decimal = Val(montopr)
                Dim ttal4 As Decimal = Val(ttal)
                guardapedidosDet(pedido, idpedido, idprod, cantpr4, precio4, ivaa4, montopr4, fetcha, ttal4)
            End While
            m_xmlr4.Close()
        End If
    End Function
    Private Function leePEDIDOS()
        Dim errorweb As Integer = 0
        Try
            'Create a web request for an invalid site. Substitute the "invalid site" strong in the Create call with a invalid name. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.nuvagromx.com/erp/htdocs/api/webServicesPedido.php?op=3"), HttpWebRequest)

            'Get the associated response for the above request. 
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            myHttpWebResponse.Close()
        Catch e As WebException
            ErrorBox.Text = e.Message & vbCrLf & ErrorBox.Text
            errorweb = 1
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            End If

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        Dim m_xmlr3 As XmlTextReader
        m_xmlr3 = New XmlTextReader("http://www.nuvagromx.com/erp/htdocs/api/webServicesPedido.php?op=3")
        m_xmlr3.WhitespaceHandling = WhitespaceHandling.None
        If errorweb = 1 Then
            ErrorBox.Text = "No existe conexion en pedidos" & vbCrLf & ErrorBox.Text
        Else
            m_xmlr3.Read()
            m_xmlr3.Read()
            While Not m_xmlr3.EOF
                m_xmlr3.Read()
                If Not m_xmlr3.IsStartElement() Then
                    Exit While
                End If
                Dim IDPED = m_xmlr3.GetAttribute("idPedido")
                m_xmlr3.Read()
                Dim pedido = m_xmlr3.ReadElementString("referencia")
                Dim nomcli = m_xmlr3.ReadElementString("cliente")
                Dim costoped = m_xmlr3.ReadElementString("costoPedido")
                Dim us1 = m_xmlr3.ReadElementString("usuario")
                Dim fetcha = m_xmlr3.ReadElementString("fechaPedido")
                Dim fpe2 = m_xmlr3.ReadElementString("modificacionPedido")
                Dim costopedS As Decimal
                If costoped = "" Then
                    costopedS = "0.00"
                End If
                costopedS = Val(costoped)
                guardapedidosWS(pedido, IDPED, nomcli, costopedS, fetcha)
            End While
            m_xmlr3.Close()
        End If
    End Function
    Private Function guardapedidosWS(ByVal pedido As String, ByVal idpeds As String, ByVal clienteN As String, ByVal costoped As Decimal, ByVal fechap As String) As Integer
        Dim datosx As Integer = 0
        idpeds = Trim(idpeds)
        pedido = Trim(pedido)
        clienteN = Trim(clienteN)
        fechap = Trim(fechap)
        Dim fechap1 As String = fechap
        fechap = fechap1.Substring(8, 2) & "/" & fechap1.Substring(5, 2) & "/" & fechap1.Substring(0, 4)
        If idpeds.Length > 20 Or idpeds.Length < 1 Then
            ErrorBox.Text = "El id del pedido " & idpeds & " no cumple con los requisitos " & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If pedido.Length > 20 Then
            ErrorBox.Text = "El pedido de " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If clienteN.Length > 100 Then
            ErrorBox.Text = "El nombre del cliente de " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If fechap.Length > 25 Then
            ErrorBox.Text = "La fecha " & idpeds & " es demasiado largo" & vbCrLf & ErrorBox.Text
            datosx = 1
        End If
        If datosx = 0 Then
            Dim Sqlclientenvo As New SqlCommand("IF NOT EXISTS(SELECT * FROM wspedidos WHERE id_ped = '" & idpeds & "') " & _
            "BEGIN " & _
            "INSERT INTO wspedidos VALUES('" & idpeds & "','" & pedido & "','" & clienteN & "','" & costoped & "','" & fechap & "','WEBSERVICE INVENTARIO') " & _
            "End ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlclientenvo.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
            Catch ex As SqlException

                ErrorBox.Text = "Error en base de datos pedidos: " & idpeds & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        End If
    End Function

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub BTNSURTIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PEDX = Nothing Then
            MsgBox("Favor de seleccionar un pedido pendiente")
        Else
            Dim resp
            resp = MsgBox("Desea surtir IDSalida: " & PEDX & "? ", MsgBoxStyle.YesNo)
            If resp = MsgBoxResult.Yes Then
                surtir()
                PEDX = Nothing
            End If
            'CargaGrid()
            'CargaGridS()
        End If
    End Sub
    Private Sub surtir()
        Dim Sqlsurt As New SqlCommand
        Dim CmdStr As New String("UPDATE pedidos SET UTIL_PED = '1' WHERE ID_PED = '" & PEDX & "' ")
        With Sqlsurt
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With
        Try
            Sqlsurt.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try
        Return

    End Sub
    Private Sub dessurtir()
        Dim Sqldsurt As New SqlCommand
        Dim CmdStr As New String("UPDATE pedidos SET UTIL_PED = '0' WHERE ID_PED = '" & PEDXs & "' ")
        With Sqldsurt
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With
        Try
            Sqldsurt.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try
        Return
    End Sub
    Private Sub borrar(ByVal pedidoS As String)
        Dim Sqlborra As New SqlCommand
        Dim CmdStr As New String("DELETE FROM pedidos WHERE ID_PED = '" & pedidoS & "' ")
        With Sqlborra
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With
        Try
            Sqlborra.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try
        Return
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


    Private Sub ReplaceSpecialChars(ByVal linenumber As Long)
        Dim strm As StreamReader
        Dim strline As String
        Dim strreplace As String

        Dim tempfile As String = "C:\temp.xml"
        Try
            FileCopy(filepath1, tempfile)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(filepath1)
        Dim strmwriter As New StreamWriter(result)
        strmwriter.AutoFlush = True

        strm = New StreamReader(tempfile)


        Dim i As Long = 0
        While i < linenumber - 1
            strline = strm.ReadLine
            strmwriter.WriteLine(strline)
            i = i + 1
        End While

        strline = strm.ReadLine
        Dim lineposition As Int32
        lineposition = InStr(strline, "")
        If lineposition > 0 Then
            strreplace = "&amp;"
        Else
            lineposition = InStr(2, strline, "<")
            If lineposition > 0 Then
                strreplace = "<"
            End If
        End If
        strline = Mid(strline, 1, lineposition - 1) + strreplace + Mid(strline, lineposition + 1)
        strmwriter.WriteLine(strline)

        strline = strm.ReadToEnd
        strmwriter.WriteLine(strline)

        strm.Close()
        strm = Nothing

        strmwriter.Flush()
        strmwriter.Close()
        strmwriter = Nothing

    End Sub

    Private Sub cbalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TraeNalm(cbalm.Text)
        COUNTLOTE = 0
        'leeExistencias()
    End Sub


    Private Sub DGPEDIDO_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim row As DataRow
        Dim i010 As Integer = 0
        Dim descripcion01 As String = ""
        Dim descripcion02 As String = ""
        xpb = DMP.Rows.Count
        ProgressBar1.Maximum = 0
        ProgressBar1.Maximum = xpb
        For Each row In DMP.Rows
            If Not (row("supplier_reference") Is DBNull.Value) Then
                descripcion01 = row("supplier_reference")
                For i As Integer = 0 To descripcion01.Length - 1
                    descripcion01 = Replace(descripcion01, "'", "")
                Next
            End If
            If Not (row("reference") Is DBNull.Value) Then
                descripcion02 = row("reference")
                For i As Integer = 0 To descripcion02.Length - 1
                    descripcion02 = Replace(descripcion02, "'", "")
                Next
            End If

            Dim Sqlclientenvo As New SqlCommand("DECLARE @provnum nchar(50) " & _
                       "DECLARE @um nchar(50) " & _
                       "DECLARE @CAP bigint " & _
                       "SET @provnum = (select clave FROM proveedores WHERE nombre = 'WEB MYSQL') " & _
                       "SET @um = (select clave FROM unidaddemedida WHERE nombre = 'PIEZA') " & _
                       "IF NOT EXISTS(SELECT * FROM productos WHERE alterno = '" & row("id_product") & "') " & _
                       "BEGIN " & _
                       "INSERT INTO productos VALUES('" & row("id_product") & "','SI','0','" & descripcion01 & "','" & descripcion02 & "','0',@provnum,'F001',@um,'" & row("active") & "','NO','" & row("price") & "','" & row("price") & "','SI','0.16','0','0','0','" & row("id_product") & "') " & _
                       "INSERT INTO Existencias VALUES('" & row("id_product") & "','0.00','False','0') " & _
                       "INSERT INTO MULTIBARCODE([MBarcode],[Codigo de producto],[MFecha],[MUser],[MEmpaque],[MUnidades],[MIMG]) VALUES('" & row("id_product") & "','" & row("id_product") & "',GETDATE(),'MYSQL','1','1','0') " & _
                       "SET @CAP = (SELECT MAX(IDCAP) FROM productcap) + 1 " & _
                       "INSERT INTO productcap VALUES(@CAP,'" & row("id_product") & "','0.1','0.1','0.1','1','1') " & _
                       "End ", SqlCnn)

            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlclientenvo.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
            Catch ex As SqlException

                ErrorBox.Text = "Error en base de datos producto: " & row("id_product") & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
            i010 = i010 + 1
            System.Windows.Forms.Application.DoEvents()
            ProgressBar1.Value = i010
            ProgressBar1.Refresh() '
            If i010 Mod 2 = 0 Then
                lbprogressbar.Text = "ESPERE..."
            Else
                lbprogressbar.Text = "ESPERE...."
            End If
        Next row
        ProgressBar1.Visible = False
        lbprogressbar.Visible = False
        ErrorBox.Text = "FINALIZADO SINCRONIZACION DE ITEMS PRESTASHOP " & Date.Now & vbCrLf & ErrorBox.Text
        Timer2.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Dim row2 As DataRow
        Dim fechaProv As String
        For Each row2 In DMT.Rows
            fechaProv = row2("fecha_pedido").ToString
            Dim Sqlpedido As New SqlCommand("IF NOT EXISTS(SELECT * FROM pedidos WHERE id_ped= '" & row2("id_pedido") & "') " & _
                       "BEGIN " & _
                       "INSERT INTO pedidos VALUES('" & row2("id_pedido") & "','PRESTASHOP','" & row2("nombre_cliente") & "','1','MYSQL','" & fechaProv.Substring(0, 10) & "',getdate(),getdate(),'1','1','1','" & row2("id_pedido") & "') end ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlpedido.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
            Catch ex As SqlException
                ErrorBox.Text = "Error en base de datos en pedido: " & row2("id_pedido") & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        Next row2
        Dim row3 As DataRow
        For Each row3 In DMD.Rows
            Dim Sqlpedidos As New SqlCommand("IF NOT EXISTS(SELECT * FROM pedidos_det WHERE id_ped= '" & row3("id_order") & "' and [Codigo de producto] = '" & row3("product_id") & "') " & _
                       "BEGIN INSERT INTO pedidos_det VALUES('" & row3("id_order") & "','" & row3("product_id") & "','" & row3("product_quantity") & "','1','1','0',getdate(),getdate(),'1','" & row3("id_order") & "',0) " & _
                       "End ", SqlCnn)
            Dim SqlRead As SqlDataReader
            Try
                SqlRead = Sqlpedidos.ExecuteReader
                'While SqlRead.Read
                '    folio = SqlRead.GetValue(0)
                'End While
                SqlRead.Close()
                ErrorBox.Text = "Pedidos Syncronizados " & Date.Now & vbCrLf & ErrorBox.Text
            Catch ex As SqlException

                ErrorBox.Text = "Error en base de datos producto: " & row3("product_id") & " |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        Next row3
        Timer3.Enabled = True
    End Sub

    Private Sub TSBSYNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSYNC.Click
        Timer2.Enabled = False
        Timer3.Enabled = False
        lbprogressbar.Visible = True
        lbprogressbar.Text = "ESPERE"
        ProgressBar1.Visible = True
        leeMySQL()
        FillProds()
        FillPeds()
        FillPedsdetalle()
        Timer1.Enabled = True
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Timer3.Enabled = False
        Dim ARRANCA As Integer = 0
        Dim SqlSTATUS As New SqlCommand("SELECT * FROM SYNCROMYSQL WHERE SYNCALM = 'MTR' AND SYNCSTAT = '1'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSTATUS.ExecuteReader
            While SqlRead.Read
                If SqlRead.IsDBNull(0) Then
                    ARRANCA = 0
                Else
                    ARRANCA = SqlRead.GetValue(1)
                    ErrorBox.Text = SqlRead.GetString(2) & vbCrLf & ErrorBox.Text
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            ErrorBox.Text = "Error en Consulta Syncronizacion:  |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
            'MsgBox(ex.Message.ToString)
        End Try
        If ARRANCA = 1 Then
            Dim SqlUpdateMySQL As New SqlCommand("UPDATE SYNCROMYSQL SET SYNCSTAT = '0' WHERE SYNCALM = 'MTR' select a.[Codigo de producto],a.Almacen,b.Abreviatura,sum(a.cantidad2)from LOTEEX2 a, FAMILIAS b, PRODUCTOS c where a.[Codigo de producto] = c.[Codigo de producto] and b.Clave = c.Familia group by a.[Codigo de producto],a.Almacen,b.Abreviatura ", SqlCnn)
            Dim SqlRead2 As SqlDataReader
            Try
                SqlRead2 = SqlUpdateMySQL.ExecuteReader
                While SqlRead2.Read
                    If SqlRead2.IsDBNull(0) Then
                        ErrorBox.Text = "No existe informacion:  |" & vbCrLf & ErrorBox.Text
                    Else
                        UpdateProductsSQL(SqlRead2.GetString(0), SqlRead2.GetString(1), SqlRead2.GetString(2), SqlRead2.GetDecimal(3))
                    End If
                End While
                SqlRead2.Close()
                ErrorBox.Text = "Articulos Syncronizados en PRESTASHOP " & Date.Now & vbCrLf & ErrorBox.Text
            Catch ex As SqlException
                ErrorBox.Text = "Error en Consulta Syncronizacion:  |" & ex.Message.ToString & vbCrLf & ErrorBox.Text
                'MsgBox(ex.Message.ToString)
            End Try
        End If
        Timer3.Enabled = True
    End Sub
    Public Sub UpdateProductsSQL(ByVal codeMS As String, ByVal almacenMS As String, ByVal familiaMS As String, ByVal existenciaMS As Decimal)
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim fechamysql As String
        fechamysql = Format(Now.Date, "yyyy-MM-dd HH:mm:ss")
        'fechamysql = Now.Date.ToUniversalTime
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & serverMSQL & ";" & "user id=" & userMSQL & ";" & "password=" & passMSQL & ";database=" & BDMSQL & ";"
        conexion.Open()
        Dim comandos As New MySqlCommand
        Try
            comandos.Connection = conexion
            comandos.CommandText = "insert INTO " & BDMSQL & ".inv_intercambio_producto(id_producto,nombre_almacen,tipo_producto,existencia,fecha,estatus) values ('" & Trim(codeMS) & "','" & Trim(almacenMS) & "','0','" & existenciaMS & "','" & fechamysql & "','1') ON DUPLICATE KEY UPDATE existencia=VALUES(existencia);"
            comandos.ExecuteNonQuery()
            'MessageBox.Show(msok)
        Catch ex As MySqlException
            MessageBox.Show(ex.ToString)
        End Try

        'Dim SQL = "insert INTO miisacom_prestashop1430re.inv_intercambio_producto values ('" & Trim(codeMS) & "','" & Trim(almacenMS) & "','" & familiaMS & "','" & existenciaMS & "','" & fechamysql & "','1');"
        ''Try
        'conexion.Open()
        'Try
        '    myCommand.Connection = conexion
        '    myCommand.CommandText = SQL
        '    myAdapter.InsertCommand = myCommand
        '    'myAdapter.Fill(DMT)
        '    'DGPEDIDO.DataSource = DMT
        '    'MsgBox(myCommand.Transaction.ToString)
        'Catch myerror As MySqlException
        '    MsgBox("Ocurrió un error leyendo la base de datos: " & myerror.Message)
        'End Try
        'Catch myerror As MySqlException
        'MessageBox.Show("Ocurrió un error conectando a la base de datos: " & myerror.Message)
        'Finally
        If conexion.State <> ConnectionState.Closed Then conexion.Close()
        'End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Timer3.Enabled = True Then
            Timer3.Enabled = False
        Else
            Timer3.Enabled = True
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim resp
        resp = MsgBox("Esta accion actualizara las existencias de PRESTASHOP eliminando existencias del sistema de CONTROL DE ALMACEN, ¿Desea realizar esta acción de todas formas?", MsgBoxStyle.OkCancel)
        If resp = vbOK Then
            Fillexistencias()
            If Guardaexistencias2(Date.Now.ToString, Me.CBALM.Text) = 0 Then
                actualexistencias2(Date.Now.ToString, Me.CBALM.Text)
                'borraexistencias2(Date.Now.ToString, Me.CBALM.Text)
                'borraexistenciasLotes2(Date.Now.ToString, Me.CBALM.Text)
                MsgBox("Existencias Actualizadas")

            Else
                MsgBox("La operacion presento errores")
            End If
        End If
    End Sub
    Public Sub Fillexistencias()
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & serverMSQL & ";" & "user id=" & userMSQL & ";" & "password=" & passMSQL & ";database=" & BDMSQL & ";"
        Dim SQL = "SELECT select p.id_product, sa.quantity FROM " & BDMSQL & ".ps_product p, " & BDMSQL & ".ps_stock_available sa where p.id_product = sa.id_product and sa.id_product_attribute = 0;"
        conexion.Open()
        Try
            myCommand.Connection = conexion
            myCommand.CommandText = SQL
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(DMe)
        Catch myerror As MySqlException
            MsgBox("Ocurrió un error leyendo la base de datos: " & myerror.Message)
        End Try
        If conexion.State <> ConnectionState.Closed Then conexion.Close()
    End Sub
End Class