Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Module General
    Public nous, noserv As String
    Public nopa, nobd As String
    Public SqlRead As SqlDataReader
    Public Fecha As Integer
    Public MsgResp
    Public SqlCnn As New SqlConnection() '"Data Source = Sistemas\SQLEXPRESS; initial catalog = TYSESA; user id = msource; password = msmaster")
    Public CmdStr1 As New String(Nothing)
    Public Error1 As Integer
    Public almacene, empresax, TITULO As String
    Public SelecALM As Integer
    Public USUARIOCONECTA As String
    Public listempresas As String
    Public ID As Int32
    Public Server, BD, User1, PWD1 As String
    Public userMSQL As String = "miisacom_root143"
    Public serverMSQL As String = "67.225.221.124"
    Public passMSQL As String = "gonzalez1430"
    'Private Const BDMSQL As String = "miisacom_prestashop1562"
    Public BDMSQL As String = "miisacom_prestashop_industrial"
    Public UsuCate As String
    Public ConeccionFallida As Boolean
    'Private NomServer As String = "SISTEMAS\DESARROLLOVT"
    Private NomServer As String = "LOCALHOST"
    'SISTEMAS\DESARROLLOVT
    Private NomBD As String = "SNROQUE"
    Private NomUser As String = "Client01Ap"
    Private NomPass As String = "Cl01SeA"
    'Private NomUser As String = "sa"
    'Private NomPass As String = "Positivo01"
    Public mmaid As Int32

    Public Sub Conecta(ByVal NoSer As String)
        Dim nv As Integer = 0
        Dim nv1 As Integer = 0
        For nv = 0 To 30
            Try
                'Dim Archivo As New StreamReader("Config.txt")
                'If ConeccionFallida = True Then
                '    Server = Archivo.ReadLine
                '    Server = NoSer
                '    BD = Archivo.ReadLine
                'Else
                '    Server = Archivo.ReadLine
                '    BD = Archivo.ReadLine
                'End If

                If NoSer = "--Ingresa Servidor--" Then

                Else
                    NomServer = NoSer
                End If
                'User1 = Archivo.ReadLine
                'PWD1 = Archivo.ReadLine
                'listempresas = Archivo.ReadLine
                ''userMSQL = Archivo.ReadLine
                ''serverMSQL = Archivo.ReadLine
                ''passMSQL = Archivo.ReadLine
                ''BDMSQL = Archivo.ReadLine
                'CmdStr1 = "Data Source = " & Server & "; initial catalog = " & BD & "; user id = " & User1 & "; password = " & PWD1
                CmdStr1 = "Data Source = " & NomServer & "; initial catalog = " & NomBD & "; user id = " & NomUser & "; password = " & NomPass
                SqlCnn.ConnectionString = CmdStr1

                SqlCnn.Open()
                ConeccionFallida = False
                nous = NomUser
                nopa = NomPass
                NoServ = NomServer
                nobd = NomBD
                Exit For
            Catch ex As SqlException
                If nv = 30 And nv1 = 3 Then
                    'MsgBox(ex.Message.ToString)
                    MsgBox("Falló Conexion, revisa el servidor", MsgBoxStyle.Exclamation)
                    ConeccionFallida = True
                    Exit Sub
                End If
                If nv = 30 Then
                    nv1 = nv1 + 1
                    nv = 0
                    MsgBox("Conectando a la BDs...")
                End If
            End Try
        Next




    End Sub



    Public Function ValidaUsuario(ByVal user As String, ByVal pwd As String) As Integer
        'Validar el try
        Dim Valido As Integer
        Valido = 0
        Try
            Dim Sqlsel As New SqlCommand("declare @hay INT set @hay = 0 if exists (select nombre from usuarios where usuario = '" & user & "' and 1 = pwdcompare('" & pwd & "',contraseña,0))begin set @hay = 1 End select @hay", SqlCnn)
            SqlRead = Sqlsel.ExecuteReader
            While SqlRead.Read
                Valido = SqlRead.GetSqlInt32(0)
            End While
            SqlRead.Close()

        Catch ex As SqlException
            SqlCnn.Close()
            MsgBox(ex.Message)
        End Try

        Return Valido
    End Function
    Private Function namma() As Int32
        Dim obma As String = ""
        Dim vali As Int32 = 0
        'Dim arrmaq As String = "SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled = true"
        Dim arrmaq As String = "SELECT * FROM Win32_NetworkAdapterConfiguration "
        For Each mo As System.Management.ManagementObject In New System.Management.ManagementObjectSearcher(arrmaq).Get()
            Dim sema As String = mo("MacAddress")
            If Not sema Is Nothing Then
                'obma = sema

                obma = SelMaq(sema)
                'MsgBox(sema & "/" & obma)
                If obma <> "" Then
                    vali = obma
                    'MsgBox(sema)
                    Exit For
                End If
            End If
        Next
        'Return obma
        Return vali
    End Function

    Public Function SelMaq(ByVal codigo As String) As String
        Dim nombr As String
        'MsgBox("maquina " & codigo)
        Dim SqlSelDesHerr As New SqlCommand("exec Proc_RevMaq " & "'" & nombr & "', " & "'" & codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDesHerr.ExecuteReader
            While SqlRead.Read
                Descripcion = SqlRead.GetInt32(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Descripcion

    End Function

    Public Function Login1(ByVal user As String, ByVal pwd As String) As String
        Dim Valido As String
        'Dim nama As String = ""
        'nama = namma()
        'Dim vallic As String = ""
        'vallic = SelMaq(nama)
        Dim vallic As Int32 = 0
        vallic = namma()
        'If vallic = "" Then
        If vallic = 0 Then
            Valido = "La pc no esta dado de alta"
            Return Valido
            Exit Function
        End If
        mmaid = vallic
        Dim Sqlsel As New SqlCommand("DECLARE @cad varchar(500) declare @stat bit set @cad = '' set @stat = (select top(1) [status] from FECHAREG where [status] <> 'false' and idcompu = '" & mmaid & "') if @stat is null begin set @stat = 'false' end if @stat = 'false' begin select nombre from usuarios where usuario = '" & user & "' and 1 = pwdcompare('" & pwd & "',contraseña,0) end else begin  select @cad end", SqlCnn)
        Dim SqlRead As SqlDataReader
        Valido = 0
        Try
            SqlRead = Sqlsel.ExecuteReader
            While SqlRead.Read
                Valido = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


        Return Valido
    End Function
    Public Function categoria(ByVal user As String, ByVal pwd As String) As String
        Dim cat As String
        Dim Sqlsel As New SqlCommand("SELECT Categoria FROM Usuarios WHERE Usuario = '" & user & "'" & "AND Contraseña ='" & pwd & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        cat = Nothing
        Try
            SqlRead = Sqlsel.ExecuteReader
            While SqlRead.Read
                cat = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)

        End Try
        Return cat

    End Function

    Public Function CargaTipos(ByVal Pantalla As Form) As DataTable  'ByVal Pantalla As Form
        Dim SqlSel As New SqlDataAdapter("SELECT clave, Abreviatura FROM familias where activo = 1 ORDER BY Abreviatura", SqlCnn)
        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return DS
        'Dim SqlSel As New SqlCommand("SELECT Abreviatura FROM familias ORDER BY Abreviatura", SqlCnn)
        'Dim SqlRead As SqlDataReader
        'Try
        '    SqlRead = SqlSel.ExecuteReader
        '    While (SqlRead.Read)
        '        'FrmAgregaHerramienta.CmbTipo.Items.Add(SqlRead.GetString(0).ToString)
        '        Pantalla.Con.CmbTipo.Items.Add(SqlRead.GetString(0).ToString)
        '    End While
        '    SqlRead.Close()
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try
        'FrmAgregaHerramienta.CmbTipo.Items.Add("")

    End Function

    Public Sub CargaDeptos(ByVal Pantalla As String)
        Dim SqlSel As New SqlCommand("exec spSelDeptos ", SqlCnn)
        Dim SqlRead As SqlDataReader

        Try
            SqlRead = SqlSel.ExecuteReader
            Select Case Pantalla
                Case "FrmEmpleados"
                    While (SqlRead.Read)
                    End While
            End Select
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub CargaMarcas(ByVal familia As String, ByVal Pantalla As String)

    End Sub

    Public Function CargaUM(ByVal Pantalla As Form) As DataTable
        Dim SqlSel As New SqlDataAdapter("SELECT Clave, Abreviatura FROM unidaddemedida where activo = 1 ORDER BY Abreviatura", SqlCnn)
        Dim DS As New DataTable

        Try
            SqlSel.Fill(DS)
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return DS

        'Dim SqlSel As New SqlCommand("SELECT Abreviatura FROM unidaddemedida ORDER BY Abreviatura", SqlCnn)
        'Dim SqlRead As SqlDataReader


        'Try
        '    SqlRead = SqlSel.ExecuteReader
        '    While (SqlRead.Read)
        '        FrmAgregaHerramienta.CboUnidad.Items.Add(SqlRead.GetString(0).ToString)
        '    End While
        '    SqlRead.Close()
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try
        'FrmAgregaHerramienta.CboUnidad.Items.Add("")
    End Function

    Public Function EliminaHerramienta(ByVal codigo) As Integer
        Dim SqlDelHerr As New SqlCommand()
        Dim CmdStr As New String("exec spOpcionesCatalogoHerramientas 2, " & "'")

        Error1 = 0

        CmdStr = CmdStr & codigo & "'" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null" & ","
        CmdStr = CmdStr & "null"

        With SqlDelHerr
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With
        Try
            SqlDelHerr.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function

    Public Function CatalogoEmpleados(ByVal Opcion As Integer, ByVal Codigo As String, ByVal Nombre As String, ByVal Depto As String, ByVal Mail As String, ByVal Telefono As String) As Integer
        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoEmpleados ")

        Error1 = 0
        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & Codigo & "'" & ","
        CmdStr = CmdStr & "'" & Nombre & "'" & ","
        If Depto = "null" Then
            CmdStr = CmdStr & Depto & ","
        Else
            CmdStr = CmdStr & "'" & Depto & "'" & ","
        End If
        If Telefono = "null" Then
            CmdStr = CmdStr & Telefono & ","
        Else
            CmdStr = CmdStr & "'" & Telefono & "'" & ","
        End If

        If Mail = "null" Then
            CmdStr = CmdStr & Mail & ","
        Else
            CmdStr = CmdStr & "'" & Mail & "'" & ","
        End If

        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With
        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return Error1

    End Function

    Public Function CatalogoTipos(ByVal Opcion As Integer, ByVal Codigo As String, ByVal Nombre As String) As Integer
        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoTipos ")

        Error1 = 0
        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & Codigo & "'" & ","
        CmdStr = CmdStr & "'" & Nombre & "'"

        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return Error1

    End Function

    Public Function CatalogoMaquinaria(ByVal Opcion As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal ubicacion As String, ByVal tipo As String, ByVal marca As String, ByVal serie As String, ByVal capacidad As String, ByVal aplica As String, ByVal adquisicion As String, ByVal costo As Double, ByVal observaciones As String, ByVal ucosto As Double, ByVal existencia As Double, ByVal unidad As String, ByVal foto As String) As Integer
        Dim SqlCatMaq As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoMaquinaria  ")

        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & codigo & "'" & ","
        CmdStr = CmdStr & "'" & descripcion & "'" & ","
        If ubicacion = "null" Then
            CmdStr = CmdStr & ubicacion & ","
        Else
            CmdStr = CmdStr & "'" & ubicacion & "'" & ","
        End If
        If tipo = "null" Then
            CmdStr = CmdStr & tipo & ","
        Else
            CmdStr = CmdStr & "'" & tipo & "'" & ","
        End If
        If marca = "null" Then
            CmdStr = CmdStr & marca & ","
        Else
            CmdStr = CmdStr & "'" & marca & "'" & ","
        End If
        CmdStr = CmdStr & "'" & serie & "'" & ","
        If capacidad = "null" Then
            CmdStr = CmdStr & capacidad & ","
        Else
            CmdStr = CmdStr & "'" & capacidad & "'" & ","
        End If
        CmdStr = CmdStr & "'" & aplica & "'" & ","
        CmdStr = CmdStr & "'" & adquisicion & "'" & ","
        CmdStr = CmdStr & costo & ","
        If observaciones = "null" Then
            CmdStr = CmdStr & observaciones & ","
        Else
            CmdStr = CmdStr & "'" & observaciones & "'" & ","
        End If
        CmdStr = CmdStr & ucosto & ","
        CmdStr = CmdStr & existencia & ","
        If unidad = "null" Then
            CmdStr = CmdStr & unidad & ","
        Else
            CmdStr = CmdStr & "'" & unidad & "'" & ","
        End If
        If foto = "null" Then
            CmdStr = CmdStr & foto
        Else
            CmdStr = CmdStr & "'" & foto & "'"
        End If

        With SqlCatMaq
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            SqlCatMaq.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function

    Public Function CatalogoConsumible(ByVal Opcion As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal ubicacion As String, ByVal tipo As String, ByVal marca As String, ByVal serie As String, ByVal capacidad As String, ByVal aplica As String, ByVal adquisicion As String, ByVal costo As Double, ByVal observaciones As String, ByVal ucosto As Double, ByVal existencia As Double, ByVal unidad As String, ByVal foto As String) As Integer
        Dim SqlCatMaq As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoConsumible  ")

        Error1 = 0

        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & codigo & "'" & ","
        CmdStr = CmdStr & "'" & descripcion & "'" & ","
        If ubicacion = "null" Then
            CmdStr = CmdStr & ubicacion & ","
        Else
            CmdStr = CmdStr & "'" & ubicacion & "'" & ","
        End If
        If tipo = "null" Then
            CmdStr = CmdStr & tipo & ","
        Else
            CmdStr = CmdStr & "'" & tipo & "'" & ","
        End If
        If marca = "null" Then
            CmdStr = CmdStr & marca & ","
        Else
            CmdStr = CmdStr & "'" & marca & "'" & ","
        End If
        CmdStr = CmdStr & "'" & serie & "'" & ","
        If capacidad = "null" Then
            CmdStr = CmdStr & capacidad & ","
        Else
            CmdStr = CmdStr & "'" & capacidad & "'" & ","
        End If
        CmdStr = CmdStr & "'" & aplica & "'" & ","
        CmdStr = CmdStr & "'" & adquisicion & "'" & ","
        CmdStr = CmdStr & costo & ","
        If observaciones = "null" Then
            CmdStr = CmdStr & observaciones & ","
        Else
            CmdStr = CmdStr & "'" & observaciones & "'" & ","
        End If
        CmdStr = CmdStr & ucosto & ","
        CmdStr = CmdStr & existencia & ","
        If unidad = "null" Then
            CmdStr = CmdStr & unidad & ","
        Else
            CmdStr = CmdStr & "'" & unidad & "'" & ","
        End If
        If foto = "null" Then
            CmdStr = CmdStr & foto
        Else
            CmdStr = CmdStr & "'" & foto & "'"
        End If

        With SqlCatMaq
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            SqlCatMaq.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function

    Public Function CatalogoRefaccion(ByVal Opcion As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal ubicacion As String, ByVal tipo As String, ByVal marca As String, ByVal serie As String, ByVal status As String, ByVal Subtipo As String, ByVal AplicaMan As String, ByVal CostoIni As Double, ByVal Observaciones As String, ByVal ucosto As Double, ByVal existencia As Double, ByVal unidad As String, ByVal foto As String) As Integer
        Dim SqlCatMaq As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoRefacciones  ")

        Error1 = 0

        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & codigo & "'" & ","
        CmdStr = CmdStr & "'" & descripcion & "'" & ","
        If ubicacion = "null" Then
            CmdStr = CmdStr & ubicacion & ","
        Else
            CmdStr = CmdStr & "'" & ubicacion & "'" & ","
        End If
        If tipo = "null" Then
            CmdStr = CmdStr & tipo & ","
        Else
            CmdStr = CmdStr & "'" & tipo & "'" & ","
        End If
        If marca = "null" Then
            CmdStr = CmdStr & marca & ","
        Else
            CmdStr = CmdStr & "'" & marca & "'" & ","
        End If
        CmdStr = CmdStr & "'" & serie & "'" & ","
        If status = "null" Then
            CmdStr = CmdStr & status & ","
        Else
            CmdStr = CmdStr & "'" & status & "'" & ","
        End If
        CmdStr = CmdStr & "'" & Subtipo & "'" & ","
        CmdStr = CmdStr & "'" & AplicaMan & "'" & ","
        CmdStr = CmdStr & Fecha & ","
        CmdStr = CmdStr & CostoIni & ","
        If Observaciones = "null" Then
            CmdStr = CmdStr & Observaciones & ","
        Else
            CmdStr = CmdStr & "'" & Observaciones & "'" & ","
        End If
        CmdStr = CmdStr & ucosto & ","
        CmdStr = CmdStr & existencia & ","
        If unidad = "null" Then
            CmdStr = CmdStr & unidad & ","
        Else
            CmdStr = CmdStr & "'" & unidad & "'" & ","
        End If
        If foto = "null" Then
            CmdStr = CmdStr & foto
        Else
            CmdStr = CmdStr & "'" & foto & "'"
        End If

        With SqlCatMaq
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            SqlCatMaq.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function


    Public Function GuardaHerramienta(ByVal codigo As String, ByVal peps As String, ByVal ubicacion As String, ByVal descripcion As String, ByVal nombrecorto As String, ByVal tipo As String, ByVal provee As String, ByVal unidad As String, ByVal adquisicion As String, ByVal activo As String, ByVal costoini As Double, ByVal ucosto As Decimal, ByVal cheiva As String, ByVal ivavar As Decimal, ByVal cheIEPS As String, ByVal IEPSvar As Decimal, ByVal minstk As String, ByVal maxcmp As Decimal, ByVal existencia As Double, ByVal alterno As String, ByVal chbsk As String, ByVal presentacion As String, ByVal cantipres As String, ByVal area As Decimal, ByVal altu As Decimal, ByVal offset As Decimal, ByVal Vact As Boolean) As Integer
        Dim SqlInsHerr As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoHerramientas ")

        Error1 = 0
        CmdStr = CmdStr & "'" & UsuCate & "'" & ","
        CmdStr = CmdStr & "'" & codigo & "'" & ","
        CmdStr = CmdStr & "'" & peps & "'" & ","
        CmdStr = CmdStr & "'" & ubicacion & "'" & ","
        CmdStr = CmdStr & "'" & descripcion & "'" & ","
        CmdStr = CmdStr & "'" & nombrecorto & "'" & ","
        CmdStr = CmdStr & "'" & tipo & "'" & ","
        CmdStr = CmdStr & "'" & provee & "'" & ","
        CmdStr = CmdStr & "'" & unidad & "'" & ","
        CmdStr = CmdStr & "'" & adquisicion & "'" & ","
        CmdStr = CmdStr & "'" & activo & "'" & ","
        CmdStr = CmdStr & "'" & costoini & "'" & ","
        CmdStr = CmdStr & "'" & ucosto & "'" & ","
        CmdStr = CmdStr & "'" & cheiva & "'" & ","
        CmdStr = CmdStr & "'" & ivavar & "'" & ","
        CmdStr = CmdStr & "'" & cheIEPS & "'" & ","
        CmdStr = CmdStr & "'" & IEPSvar & "'" & ","
        CmdStr = CmdStr & "'" & minstk & "'" & ","
        CmdStr = CmdStr & "'" & maxcmp & "'" & ","
        CmdStr = CmdStr & "'" & existencia & "'" & ","
        CmdStr = CmdStr & "'" & alterno & "'" & ","
        CmdStr = CmdStr & "'" & chbsk & "'" & ","
        CmdStr = CmdStr & "'" & Vact & "'"
        With SqlInsHerr
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            'MsgBox(SqlInsHerr.CommandText)
            SqlInsHerr.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function

    Public Function ActualizaHerramienta(ByVal codigo As String, ByVal descripcion As String, ByVal ubicacion As String, ByVal tipo As String, ByVal marca As String, ByVal serie As String, ByVal capacidad As String, ByVal aplica As String, ByVal adquisicion As String, ByVal costo As Double, ByVal observaciones As String, ByVal ucosto As Double, ByVal existencia As Double, ByVal unidad As String, ByVal foto As String) As Integer
        Dim SqlInsHerr As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoHerramientas 3, ")

        Error1 = 0
        CmdStr = CmdStr & "'" & codigo & "'" & ","
        CmdStr = CmdStr & "'" & descripcion & "'" & ","
        If ubicacion = "null" Then
            CmdStr = CmdStr & ubicacion & ","
        Else
            CmdStr = CmdStr & "'" & ubicacion & "'" & ","
        End If
        If tipo = "null" Then
            CmdStr = CmdStr & tipo & ","
        Else
            CmdStr = CmdStr & "'" & tipo & "'" & ","
        End If
        If marca = "null" Then
            CmdStr = CmdStr & marca & ","
        Else
            CmdStr = CmdStr & "'" & marca & "'" & ","
        End If
        CmdStr = CmdStr & "'" & serie & "'" & ","
        If capacidad = "null" Then
            CmdStr = CmdStr & capacidad & ","
        Else
            CmdStr = CmdStr & "'" & capacidad & "'" & ","
        End If
        CmdStr = CmdStr & "'" & aplica & "'" & ","
        CmdStr = CmdStr & "'" & adquisicion & "'" & ","
        CmdStr = CmdStr & costo & ","
        If observaciones = "null" Then
            CmdStr = CmdStr & observaciones & ","
        Else
            CmdStr = CmdStr & "'" & observaciones & "'" & ","
        End If
        CmdStr = CmdStr & ucosto & ","
        CmdStr = CmdStr & existencia & ","
        If unidad = "null" Then
            CmdStr = CmdStr & unidad & ","
        Else
            CmdStr = CmdStr & "'" & unidad & "'" & ","
        End If
        If foto = "null" Then
            CmdStr = CmdStr & foto
        Else
            CmdStr = CmdStr & "'" & foto & "'"
        End If


        With SqlInsHerr
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            'MsgBox(SqlInsHerr.CommandText)
            SqlInsHerr.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function


    Public Sub PreparaFormParaCaptura(ByVal Pantalla As String)

        Select Case Pantalla
            Case "FrmAgregaHerramienta"
                With FrmAgregaHerramienta
                    .TxtCodigo.Text = Nothing
                    .TxtCapacidad.Text = Nothing
                    .TxtDescripcion.Text = Nothing
                    .TxtObservaciones.Text = Nothing
                    .TxtUbicacion.Text = Nothing
                    .CmbTipo.Text = Nothing
                    .CboUnidad.Text = Nothing
                    .preciocompra.Text = "0.00"
                    .precioventa.Text = "0.00"
                    .minstock.Text = "0.00"
                    .maxcompra.Text = "0.00"
                    .Chkiva.Checked = False
                    .ChkSeries.Checked = False
                    .ChkMantenimiento.Checked = True
                End With
            Case "FrmEmpleados"
                With FrmEmpleados
                    .TxtCodigo.Text = Nothing
                    '.TxtExtension.Text = Nothing
                    .TxtNombre.Text = Nothing
                    '.TxtFoto.Text = Nothing
                    '.PicImagen.Image = Nothing
                    '.TxtMail.Text = Nothing
                    '.TxtTelefono.Text = Nothing
                    .TxtCodigo.Focus()
                End With
            Case "FrmTipos"
                With FrmTipos
                    .TxtDescripcion.Text = Nothing
                    .TxtCodigo.Text = Nothing
                    '.CboFamilia.Text = Nothing
                    .TxtCodigo.Focus()
                End With
            Case "FrmMarcas"
                With FrmMarcas
                    .TxtDescripcion.Text = Nothing
                    .TxtCodigo.Text = Nothing
                    .CboFamilia.Text = Nothing
                    .TxtCodigo.Focus()
                End With
            Case "FrmDeptos"
                With FrmDeptos
                    .TxtCodigo.Text = Nothing
                    .TxtDescripcion.Text = Nothing
                    .TxtCodigo.Focus()
                End With
            Case "FrmUnidad"
                With FrmUnidad
                    .TxtCodigo.Text = Nothing
                    .TxtDescripcion.Text = Nothing
                    '.CboFamilia.Text = Nothing
                    .TxtCodigo.Focus()
                End With
            Case "FrmEntIni"
                With FrmEntIni
                    .TxtCodigo.Text = Nothing
                    '.TxtCosto.Text = Nothing
                    .TXTFAC.Text = Nothing
                    .LblDescripcion.Text = Nothing
                    .TxtCodigo.Focus()
                End With
            Case "FrmEntradaCompra"
                With FrmEntradaCompra
                    .TxtFolio.Text = GeneraNuevoFolio()
                    .TxtCantidad.Text = Nothing
                    .TxtCosto.Text = Nothing
                    .TxtFOL.Text = Nothing
                    .TxtPED.Text = Nothing
                    '.TxtPedFecha.Text = Nothing
                    .TxtFAC.Text = Nothing
                    .CboProveedor.Text = Nothing
                    .CboCliente.Text = Nothing
                    .ChkFAC.Checked = False
                    .ChkCANT.Checked = False
                    .ChkCalidad.Checked = False
                    .LblDescripcion.Text = Nothing
                    '.datagrid1.SelectAll()
                    '.datagrid1.ClearSelection()
                    'FuncionesTempEntCompra(2, "Herramienta", .TxtFolio.Text, .TxtCodigo.Text, .TxtCantidad.Text, .TxtCosto.Text, "Si", "Si")
                End With

            Case "FrmSalidaResguardo1"
                With FrmUbicaciones
                    .TXTUBI.Text = Nothing
                    .TXTZONA.Text = Nothing
                    .TXTUBI.Focus()
                End With

            Case "FrmInventarios"
                With FrmInventarios
                    .TxtCodigo.Text = Nothing
                    .TxtCantidad.Text = Nothing
                    .LblDescripcion.Text = Nothing
                    .TxtCodigo.Focus()
                End With

            Case "FrmMaquinaria"
                With FrmProveedor
                    .TxtCodigo.Text = Nothing
                    .TxtCapacidad.Text = Nothing
                    .TxtDescripcion.Text = Nothing
                    .TxtUbicacion.Text = Nothing
                    .TxtCodigo.Focus()
                End With

        End Select
    End Sub


    Public Sub CargaMarcas()
        'Dim SqlSel As New SqlDataAdapter("exec spSelmarcas 'Todos'", SqlCnn)
        'Dim DS As New DataTable

        'Try

        '    SqlSel.Fill(DS)
        '    With FrmCatMarcas.GridMarcas
        '        .DataSource = DS
        '    End With
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try

    End Sub


    Public Function CatalogoMarcas(ByVal Opcion As Integer, ByVal Codigo As String, ByVal Nombre As String, ByVal Familia As String) As Integer
        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoMarcas ")

        Error1 = 0
        '========================================================
        'Voy a armar la cadena de comando para el spOpcionesCatalogoHerramientas
        'Mike
        '21 Mayo 2007
        '========================================================
        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & Codigo & "'" & ","
        CmdStr = CmdStr & "'" & Nombre & "'" & ","
        CmdStr = CmdStr & "'" & Familia & "'"

        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        '        MsgBox(CmdStr)

        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return Error1

    End Function


    Public Function CatalogoDeptos(ByVal Opcion As Integer, ByVal Codigo As String, ByVal Nombre As String) As Integer
        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoDeptos ")

        Error1 = 0
        '========================================================
        'Voy a armar la cadena de comando para el spOpcionesCatalogoHerramientas
        'Mike
        '21 Mayo 2007
        '========================================================
        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & Codigo & "'" & ","
        CmdStr = CmdStr & "'" & Nombre & "'"


        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        '        MsgBox(CmdStr)

        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return Error1

    End Function


    Public Sub CargaUnidad()
        'Dim SqlSel As New SqlDataAdapter("exec spSelUM 'Todos'", SqlCnn)
        'Dim DS As New DataTable

        'Try

        '    SqlSel.Fill(DS)
        '    With FrmCatUnidad.GridUM
        '        .DataSource = DS
        '    End With
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try

    End Sub


    Public Function GeneraNuevoFolio() As Integer
        Dim SqlFolio As New SqlCommand("DECLARE @FOL bigint " & _
                                        "SET @FOL = (SELECT MAX(Consecutivo) FROM FOLIOS2) + 1 " & _
                                        "INSERT INTO FOLIOS2 VALUES (@FOL, 'SI') " & _
                                        "SELECT MAX(Consecutivo) From FOLIOS2", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Folio As Integer

        Try

            SqlRead = SqlFolio.ExecuteReader
            While SqlRead.Read
                Folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Folio


    End Function

    Public Function TraeDescripcion(ByVal codigo) As String
        'Dim SqlSelDes As New SqlCommand("SELECT Descripcion FROM Productos WHERE [Codigo de Producto] = '" & codigo & "' OR Alterno = " & codigo & " and Baja = 'NO' ", SqlCnn)
        Dim SqlSelDes As New SqlCommand("SELECT a.descripcion, a.[Codigo de producto], a.[Nombre corto], a.[Precio de venta], b.MBARCODE, a.alterno FROM dbo.PRODUCTOS AS a INNER JOIN dbo.MULTIBARCODE AS b ON a.alterno = b.[Codigo de producto] WHERE (b.MBARCODE = '" & codigo & "') OR (a.[Codigo de producto] = '" & codigo & "') and a.Baja = 'NO' ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Descripcion = SqlRead.GetString(0)

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Descripcion

    End Function

    Public Function TraeDescripcionHerr(ByVal codigo As String) As String
        Dim SqlSelDesHerr As New SqlCommand("exec spSelDesHerr " & "'" & codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDesHerr.ExecuteReader
            While SqlRead.Read
                Descripcion = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Descripcion

    End Function

    Public Function TraeDescripcionRef(ByVal codigo As String) As String
        Dim SqlSelDesHerr As New SqlCommand("exec spSelDesRef " & "'" & codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDesHerr.ExecuteReader
            While SqlRead.Read
                Descripcion = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Descripcion

    End Function

    Public Function TraeDescripcionCon(ByVal codigo As String) As String
        Dim SqlSelDesHerr As New SqlCommand("exec spSelDesCon " & "'" & codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDesHerr.ExecuteReader
            While SqlRead.Read
                Descripcion = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Descripcion

    End Function

    Public Function TraeDescripcionX(ByVal codigo As String, ByVal Familia As String) As String
        Dim SqlSelDesX As New SqlCommand("exec spSelDescX " & "'" & Familia & "'" & "," & "'" & codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDesX.ExecuteReader
            While SqlRead.Read
                Descripcion = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Descripcion

    End Function

    Public Function TraeDescripcionMaq(ByVal codigo As String) As String
        Dim SqlSelDesHerr As New SqlCommand("exec spSelDesMaq " & "'" & codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Descripcion As New String(Nothing)

        Try
            SqlRead = SqlSelDesHerr.ExecuteReader
            While SqlRead.Read
                Descripcion = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Descripcion

    End Function

    Public Function CatalogoUM(ByVal Opcion As Integer, ByVal Codigo As String, ByVal Nombre As String) As Integer
        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("exec spOpcionesCatalogoUnidad ")

        Error1 = 0
        '========================================================
        'Voy a armar la cadena de comando para el spOpcionesCatalogoUnidad
        'Mers
        '22 Mayo 2007
        '========================================================
        CmdStr = CmdStr & Opcion & ","
        CmdStr = CmdStr & "'" & Codigo & "'" & ","
        CmdStr = CmdStr & "'" & Nombre & "'"


        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        '        MsgBox(CmdStr)

        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return Error1

    End Function

    Public Function ExisteEntradaInicial(ByVal codigo As String) As Integer
        Dim SqlSelEntIni As New SqlCommand("exec spSelTieneEI " & "'" & codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Existe As Integer

        Existe = 0

        Try
            SqlRead = SqlSelEntIni.ExecuteReader
            While SqlRead.Read
                Existe = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Existe

    End Function


    Public Function GuardaEntradaInicial(ByVal Familia As String, ByVal Folio As String, ByVal Fecha As Integer, ByVal User As String, ByVal Codigo As String, ByVal Costo As Double, ByVal Existencia As Integer) As Integer
        Dim SqlInsEntIni As New SqlCommand

        CmdStr1 = Nothing
        Error1 = 0

        'Select Case Familia
        '   Case "Herramienta"

        CmdStr1 = "exec spInsEntIni "
        CmdStr1 = CmdStr1 & "'" & Familia & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & Fecha & ","
        CmdStr1 = CmdStr1 & "'" & User & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Codigo & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Costo & "'" & ","
        CmdStr1 = CmdStr1 & Existencia
        '  Case "Maquinaria"
        ' Case "Refaccion"
        'Case "Consumible"
        'End Select

        With SqlInsEntIni
            .CommandText = CmdStr1
            .Connection = SqlCnn
        End With

        Try
            SqlInsEntIni.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function

    Public Function CambiaFechaStrInt(ByVal fecha As String) As Integer
        Dim Dia, Mes, Year, F1 As String

        Dia = fecha.Substring(0, 2)
        Mes = fecha.Substring(3, 2)
        Year = fecha.Substring(6)

        ' If Mes < 10 Then
        'Mes = "0" & Mes
        'End If

        F1 = Year & Mes & Dia

        Return CInt(F1)

    End Function

    Public Function ValidaDatosNull(ByVal Pantalla As String) As String
        Dim Faltantes As New String(Nothing)

        Select Case Pantalla
            Case "FrmEntradaCompra"

        End Select

        Return Faltantes
    End Function

    Public Sub CargaDetalleEntrada(ByVal folio As String, ByVal familia As String)
        Dim SqlSelDetEnt As New SqlDataAdapter("exec spSelDetEntCompra " & "'" & folio & "'" & "," & "'" & familia & "'", SqlCnn)
        Dim DS As New DataTable


        'Select Case familia
        '   Case "Herramienta"
        Try
            SqlSelDetEnt.Fill(DS)
            FrmEntradaCompra.DGped.DataSource = DS
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        '  Case "Refaccion"
        ' Case "Consumible"
        'Case "Maquinaria"
        'Try
        'SqlSelDetEnt.Fill(DS)
        'FrmEntradaCompra.GridDetalleEntrada.DataSource = DS
        'Catch ex As SqlException
        ' MsgBox(ex.Message.ToString)
        ' End Try
        'End Select


    End Sub

    Public Sub FuncionesTempEntCompra(ByVal opcion As Integer, ByVal familia As String, ByVal folio As String, ByVal codigo As String, ByVal cantidad As Integer, ByVal costo As Double, ByVal calidad As String, ByVal usado As String)
        Dim SqlInsTEntCompra As New SqlCommand

        Select Case opcion
            Case 1
                'Select Case familia
                'Case "Herramienta"
                CmdStr1 = "exec spTempDetEntCompra "
                CmdStr1 = CmdStr1 & opcion & ","
                CmdStr1 = CmdStr1 & "'" & familia & "'" & ","
                CmdStr1 = CmdStr1 & "'" & folio & "'" & ","
                CmdStr1 = CmdStr1 & "'" & codigo & "'" & ","
                CmdStr1 = CmdStr1 & cantidad & ","
                CmdStr1 = CmdStr1 & "'" & costo & "'" & ","
                CmdStr1 = CmdStr1 & "'" & calidad & "'" & ","
                CmdStr1 = CmdStr1 & "'" & usado & "'"
                ' End Select

                Try
                    With SqlInsTEntCompra
                        .CommandText = CmdStr1
                        .Connection = SqlCnn
                    End With

                    SqlInsTEntCompra.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try
            Case 2


                'Select Case familia
                'Case "Herramienta"
                CmdStr1 = "exec spTempDetEntCompra "
                CmdStr1 = CmdStr1 & opcion & ","
                CmdStr1 = CmdStr1 & "'" & familia & "'" & ","
                CmdStr1 = CmdStr1 & "'" & folio & "'" & ","
                CmdStr1 = CmdStr1 & "'" & codigo & "'" & ","
                CmdStr1 = CmdStr1 & cantidad & ","
                CmdStr1 = CmdStr1 & "'" & costo & "'" & ","
                CmdStr1 = CmdStr1 & "'" & calidad & "'" & ","
                CmdStr1 = CmdStr1 & "'" & usado & "'"

                Try

                    Dim SqlSelTEntCompra As New SqlDataAdapter(CmdStr1, SqlCnn)
                    Dim DS As New DataTable

                    SqlSelTEntCompra.Fill(DS)
                    FrmEntradaCompra.DGped.DataSource = DS
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try


                'End Select
            Case 3

                'Select Case familia
                'Case "Herramienta"
                CmdStr1 = "exec spTempDetEntCompra "
                CmdStr1 = CmdStr1 & opcion & ","
                CmdStr1 = CmdStr1 & "'" & familia & "'" & ","
                CmdStr1 = CmdStr1 & "'" & folio & "'" & ","
                CmdStr1 = CmdStr1 & "'" & codigo & "'" & ","
                CmdStr1 = CmdStr1 & cantidad & ","
                CmdStr1 = CmdStr1 & "'" & costo & "'" & ","
                CmdStr1 = CmdStr1 & "'" & calidad & "'" & ","
                CmdStr1 = CmdStr1 & "'" & usado & "'"

                Try

                    Dim SqlSelTEntCompra As New SqlCommand

                    With SqlSelTEntCompra
                        .CommandText = CmdStr1
                        .Connection = SqlCnn
                    End With
                    SqlSelTEntCompra.ExecuteNonQuery()

                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try


                '        End Select
        End Select
    End Sub

    Public Function GuardaEntCompra(ByVal Folio As String, ByVal fecha As Integer, ByVal empleado As String, ByVal nacional As String, ByVal pedimentono As String, ByVal pedimentofe As Integer, ByVal claseimportacion As String, ByVal factura As String, ByVal ordencompra As String, ByVal proveedor As String) As Integer
        Dim SqlInsEntCompra As New SqlCommand


        CmdStr1 = "exec spInsEntCompra "
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & fecha & ","
        CmdStr1 = CmdStr1 & "'" & empleado & "'" & ","
        CmdStr1 = CmdStr1 & "'" & nacional & "'" & ","
        CmdStr1 = CmdStr1 & "'" & pedimentono & "'" & ","
        CmdStr1 = CmdStr1 & pedimentofe & ","
        CmdStr1 = CmdStr1 & "'" & claseimportacion & "'" & ","
        CmdStr1 = CmdStr1 & "'" & factura & "'" & ","
        CmdStr1 = CmdStr1 & "'" & ordencompra & "'" & ","
        CmdStr1 = CmdStr1 & "'" & proveedor & "'"

        With SqlInsEntCompra
            .Connection = SqlCnn
            .CommandText = CmdStr1
        End With

        Try
            SqlInsEntCompra.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Error1 = 0

    End Function
    Public Function GuardaEntCompra2(ByVal Folio As String, ByVal almacen As String, ByVal fecha As String, ByVal empleado As String, ByVal facnot As String, ByVal lote As String, ByVal cliente As String, ByVal factura As String, ByVal proveedor As String) As Integer
        Dim SqlInsEntCompra As New SqlCommand

        CmdStr1 = "exec spInsEntMov20 "
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & "'" & almacen & "'" & ","
        CmdStr1 = CmdStr1 & "'" & fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & empleado & "'" & ","
        CmdStr1 = CmdStr1 & "'" & facnot & "'" & ","
        CmdStr1 = CmdStr1 & "'" & lote & "'" & ","
        CmdStr1 = CmdStr1 & "'" & cliente & "'" & ","
        CmdStr1 = CmdStr1 & "'" & factura & "'" & ","
        CmdStr1 = CmdStr1 & "'" & proveedor & "'"

        With SqlInsEntCompra
            .Connection = SqlCnn
            .CommandText = CmdStr1
        End With

        Try
            SqlInsEntCompra.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Error1 = 0

    End Function

    Public Function GuardaSalidaDesecho(ByVal Folio As String, ByVal Fecha As Integer, ByVal Empleado As String, ByVal Reporta As String, ByVal Codigo As String, ByVal Cantidad As Integer, ByVal Observa As String) As Integer
        Dim SqlInsSalDes As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spInsSalDes "
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & Fecha & ","
        CmdStr1 = CmdStr1 & "'" & Empleado & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Reporta & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Codigo & "'" & ","
        CmdStr1 = CmdStr1 & Cantidad & ","
        CmdStr1 = CmdStr1 & "'" & Observa & "'"

        Try

            With SqlInsSalDes
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            SqlInsSalDes.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function



    Public Function TraeNombreEmpleado(ByVal Codigo As String) As String
        Dim SqlSelEmp As New SqlCommand("exec SpSelEmp " & "'" & Codigo & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Nombre As New String(Nothing)

        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Nombre = SqlRead.GetString(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Nombre

    End Function

    Public Sub TempDetSalRes(ByVal Opcion As Integer, ByVal Familia As String, ByVal Folio As String, ByVal Codigo As String, ByVal Cantidad As Integer)


        CmdStr1 = Nothing
        CmdStr1 = "exec spInsTSalRes "
        CmdStr1 = CmdStr1 & Opcion & ","
        CmdStr1 = CmdStr1 & "'" & Familia & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Codigo & "'" & ","
        CmdStr1 = CmdStr1 & Cantidad


        Select Case Opcion
            Case 1
                Dim SqlInsDetSalRes As New SqlCommand(CmdStr1, SqlCnn)
                Try
                    SqlInsDetSalRes.ExecuteNonQuery()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
            Case 2
                Dim SqlSelDetSalRes As New SqlDataAdapter(CmdStr1, SqlCnn)
                Dim DS As New DataTable

                Try
                    SqlSelDetSalRes.Fill(DS)
                    FrmUbicaciones.DGUBI.DataSource = DS
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try
            Case 3
                Dim SqlDelDetSalRes As New SqlCommand(CmdStr1, SqlCnn)
                Try
                    SqlDelDetSalRes.ExecuteNonQuery()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try
        End Select

    End Sub

    Public Sub ObtieneDescExi(ByVal Codigo As String, ByVal familia As String, ByVal Pantalla As String)
        Dim SqlSelEmp As New SqlCommand("exec spSelDescExi " & "'" & Codigo & "'" & "," & "'" & familia & "'", SqlCnn)
        Dim SqlRead As SqlDataReader


        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Select Case Pantalla
                    Case "FrmSalidaDesecho"
                        With SALIDA
                            .LblDescripcion.Text = SqlRead.GetString(0)
                            .LblExistencia.Text = SqlRead.GetValue(1)
                        End With
                    Case "FrmSalidaResguardo"

                End Select

            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Public Function GuardaSalidaResguardo(ByVal Familia As String, ByVal Folio As String, ByVal Empleado As String, ByVal Fecha As Integer, ByVal Responsable As String, ByVal OT As String, ByVal FechaP As Integer) As Integer
        Dim SqlInsSalRes As New SqlCommand

        CmdStr1 = Nothing
        CmdStr1 = "exec spInsSalRes "
        CmdStr1 = CmdStr1 & "'" & Familia & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Empleado & "'" & ","
        CmdStr1 = CmdStr1 & Fecha & ","
        CmdStr1 = CmdStr1 & "'" & Responsable & "'" & ","
        CmdStr1 = CmdStr1 & "'" & OT & "'" & ","
        CmdStr1 = CmdStr1 & FechaP

        Error1 = 0

        Try
            With SqlInsSalRes
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            SqlInsSalRes.ExecuteNonQuery()

        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

        Return Error1

    End Function


    'Public Sub CargaInventarioAlDia(ByVal pantalla As String, ByVal familia As String, ByVal fecha As Integer)
    '    Dim SqlSelInv As New SqlDataAdapter("exec spSelInventarios " & fecha & "," & "'" & familia & "'", SqlCnn)
    '    Dim DS As New DataTable

    '    Try
    '        SqlSelInv.Fill(DS)
    '    Catch ex As SqlException
    '        MsgBox(ex.Message.ToString)
    '    End Try

    '    Select Case pantalla
    '        Case "FrmInventarios"
    '            FrmInventarios.GridInventarios.DataSource = DS
    '    End Select
    'End Sub

    Public Sub GuardaInventarios(ByVal Codigo As String, ByVal Cantidad As Integer, ByVal Fecha As Integer, ByVal Empleado As String, ByVal Familia As String)
        Dim SqlInsInventarios As New SqlCommand()

        CmdStr1 = Nothing
        CmdStr1 = "exec spInsInventarios "
        CmdStr1 = CmdStr1 & "'" & Codigo & "'" & ","
        CmdStr1 = CmdStr1 & Cantidad & ","
        CmdStr1 = CmdStr1 & Fecha & ","
        CmdStr1 = CmdStr1 & "'" & Empleado & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Familia & "'"

        With SqlInsInventarios
            .CommandText = CmdStr1
            .Connection = SqlCnn
        End With

        Try
            SqlInsInventarios.ExecuteNonQuery()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub CargaTodosEmp(ByVal pantalla As String)
        'Dim SqlSelEmp As New SqlCommand("exec spSelEmpTodos", SqlCnn)
        'Dim SqlRead As SqlDataReader

        'Try
        '    SqlRead = SqlSelEmp.ExecuteReader
        '    While SqlRead.Read
        '        FrmConEntradaCompra.CboEmpleados.Items.Add(SqlRead.GetString(0))
        '    End While
        '    SqlRead.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString)
        'End Try

    End Sub

    Public Sub CargaGridCatalogo(ByVal Catalogo As String)
        'Dim SqlSelCatalogo As New SqlDataAdapter("exec spSelCatalogo " & "'" & Catalogo & "'", SqlCnn)
        'Dim DS As New DataTable

        'Try
        '    SqlSelCatalogo.Fill(DS)
        '    FrmCatalogo.GridCatalogo.DataSource = DS
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try

    End Sub

    Public Function CargaGridHerramientas() As DataTable
        'Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] as CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre Corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA,d.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA AS IIVA, a.IVA AS IVA,a.IIEPS AS IIEPS,a.IEPS AS IEPS,a.PEPS AS PEPS, a.baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, case when (a.Activo is null) then 'false' else a.Activo end as Act From productos a, familias b, unidaddemedida c, PROVEEDORES D WHERE a.familia = b.clave AND a.proveedor = D.clave AND a.[Unidad de medida] = c.clave ORDER BY a.alterno", SqlCnn)
        Dim SqlSel As New SqlDataAdapter("SELECT a.[Codigo de producto] as CODE, a.alterno AS ALTERNO, a.Descripcion AS DESCR, a.[Nombre Corto] AS CORTO, a.Ubicacion AS UBI, b.Abreviatura AS FAMILIA,d.Abreviatura AS PROVEE, c.abreviatura AS UM, a.[Precio de compra] AS COMPRA, a.[Precio de venta] AS VENTA, a.[Minimo stock] AS MINIMO, a.[Maximo compra] AS MAXIMO, a.IIVA AS IIVA, a.IVA AS IVA,a.IIEPS AS IIEPS,a.IEPS AS IEPS,a.PEPS AS PEPS, a.baja AS BAJA, a.existencia AS EXISTENCIA, a.[Se maneja por lotes] AS LOTES, case when (a.Activo is null) then 'false' else a.Activo end as Act From dbo.PRODUCTOS AS a LEFT OUTER JOIN dbo.PROVEEDORES AS D ON a.Proveedor = D.Clave LEFT OUTER JOIN dbo.FAMILIAS AS b ON a.Familia = b.Clave LEFT OUTER JOIN dbo.UNIDADDEMEDIDA AS c ON a.[Unidad de medida] = c.clave ORDER BY a.alterno", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With FrmAgregaHerramienta.DGPROD
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return DS
    End Function

    Public Function CargaGridEmpleados() As DataTable
        'Dim SqlSel As New SqlDataAdapter("SELECT Usuario, Nombre, Categoria, Activo FROM Usuarios ORDER BY Usuario", SqlCnn)
        'Dim DS As New DataTable

        'Try
        '    SqlSel.Fill(DS)
        '    With FrmEmpleados.DGUsuarios
        '        .DataSource = DS
        '    End With
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try

        Dim SqlSel As New SqlDataAdapter("SELECT Usuario, Nombre, Categoria, Activo FROM Usuarios ORDER BY Usuario", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            'With FrmAgregaHerramienta.DGPROD
            '    .DataSource = DS
            'End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return DS
    End Function

    Public Sub CargaDatosResguardo(ByVal Familia As String, ByVal Empleado As String)
        'Dim SqlSelDatosResguardo As New SqlDataAdapter("exec spSelDatosResguardo " & "'" & Empleado & "'" & "," & "'" & Familia & "'", SqlCnn)
        'Dim DS As New DataTable

        'Try
        '    SqlSelDatosResguardo.Fill(DS)
        '    With FrmEntradaOT
        '        .GridArticulos.DataSource = DS
        '    End With

        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try
    End Sub

    Public Sub RegresaResguardo(ByVal Folio As String, ByVal OT As String, ByVal Familia As String, ByVal Codigo As String, ByVal Cantidad As Integer, ByVal Costo As Double, ByVal Opcion As Integer, ByVal Fecha As Integer, ByVal Empleado As String)
        'Dim SqlRegresaResguardo As New SqlCommand
        'Dim SqlSelDatosResguardo As New SqlDataAdapter("exec spSelDatosResguardo " & "'" & Empleado & "'" & "," & "'" & Familia & "'", SqlCnn)
        'Dim DS As New DataTable


        'CmdStr1 = Nothing
        'CmdStr1 = "exec spRegresaResguardo "
        'CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        'CmdStr1 = CmdStr1 & "'" & OT & "'" & ","
        'CmdStr1 = CmdStr1 & "'" & Familia & "'" & ","
        'CmdStr1 = CmdStr1 & "'" & Codigo & "'" & ","
        'CmdStr1 = CmdStr1 & Cantidad & ","
        'CmdStr1 = CmdStr1 & Costo & ","
        'CmdStr1 = CmdStr1 & Opcion & ","
        'CmdStr1 = CmdStr1 & Fecha & ","
        'CmdStr1 = CmdStr1 & "'" & Empleado & "'"

        'Try
        '    With SqlRegresaResguardo
        '        .CommandText = CmdStr1
        '        .Connection = SqlCnn

        '    End With

        '    SqlRegresaResguardo.ExecuteNonQuery()

        '    SqlSelDatosResguardo.Fill(DS)
        '    With FrmEntradaOT
        '        .GridArticulos.DataSource = DS
        '    End With

        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try

    End Sub
    Public Function CargaALM() As DataTable
        'Dim SqlSel1 As New SqlDataAdapter("SELECT Abreviatura FROM almacenes ORDER BY Abreviatura", SqlCnn)
        ''Dim SqlSel As New SqlDataAdapter("SELECT Usuario, Nombre, Categoria, Contraseña, [Validar contraseña],Activo FROM Usuarios ORDER BY Usuario", SqlCnn)
        'Dim DS As New DataTable

        'Try
        '    SqlSel1.Fill(DS)
        '    With FrmEmpleados.DGAlmacen
        '        .DataSource = DS
        '    End With
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try

        Dim SqlSel As New SqlDataAdapter("SELECT Abreviatura FROM almacenes ORDER BY Abreviatura", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            'With FrmAgregaHerramienta.DGPROD
            '    .DataSource = DS
            'End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return DS

    End Function


    Public Function CargaALMUSU(ByVal codigo As String) As DataTable
        'Dim SqlSel1 As New SqlDataAdapter("SELECT almacen FROM usuarios_almacen WHERE usuario = '" & codigo & "' ORDER BY almacen", SqlCnn)
        ''Dim SqlSel As New SqlDataAdapter("SELECT Usuario, Nombre, Categoria, Contraseña, [Validar contraseña],Activo FROM Usuarios ORDER BY Usuario", SqlCnn)
        'Dim DS As New DataTable

        'Try
        '    SqlSel1.Fill(DS)
        '    With FrmEmpleados.DGalmusu
        '        .DataSource = DS
        '    End With
        'Catch ex As SqlException
        '    MsgBox(ex.Message.ToString)
        'End Try

        Dim SqlSel As New SqlDataAdapter("SELECT almacen FROM usuarios_almacen WHERE usuario = '" & codigo & "' ORDER BY almacen", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            'With FrmAgregaHerramienta.DGPROD
            '    .DataSource = DS
            'End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return DS

    End Function
    Public Function ValidaDetSal(ByVal folio As String) As Integer
        Dim SqlSelCuantos As New SqlCommand("SELECT COUNT(*) FROM TSalALM WHERE Folio = '" & folio & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Cuantos As New String(Nothing)

        Try
            SqlRead = SqlSelCuantos.ExecuteReader
            While SqlRead.Read
                Cuantos = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Cuantos

    End Function
    Public Function ValidaDetent2(ByVal folio As String) As Integer
        Dim SqlSelCuantos As New SqlCommand("SELECT COUNT(*) FROM TEntALM WHERE Folio = '" & folio & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim Cuantos As New String(Nothing)

        Try
            SqlRead = SqlSelCuantos.ExecuteReader
            While SqlRead.Read
                Cuantos = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        Return Cuantos

    End Function
    Public Function GuardaSalidaDesecho(ByVal Folio As String, ByVal Fecha As String, ByVal Empleado As String, ByVal Cliente As String) As Integer
        Dim SqlInsSalDes As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spInsSalidas "
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Empleado & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Cliente & "'"

        Try

            With SqlInsSalDes
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            SqlInsSalDes.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function GuardaSalida(ByVal almsal As String, ByVal printe As String, ByVal alment As String, ByVal Folio As String, ByVal Fecha As String, ByVal Empleado As String, ByVal Cliente As String) As Integer
        Dim SqlInsSalDes As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spSalidas20 "
        CmdStr1 = CmdStr1 & "'" & almsal & "'" & ","
        CmdStr1 = CmdStr1 & "'" & printe & "'" & ","
        CmdStr1 = CmdStr1 & "'" & alment & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Folio & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Empleado & "'" & ","
        CmdStr1 = CmdStr1 & "'" & Cliente & "'"

        Try

            With SqlInsSalDes
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            SqlInsSalDes.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function borrafolio(ByVal folio) As Integer
        Dim SqlFolio As New SqlCommand("IF EXISTS (SELECT * FROM FOLIOS2 WHERE Consecutivo = '" & folio & "' AND utilizado = 'SI') " & _
        "BEGIN " & _
        "DELETE FROM FOLIOS2 WHERE Consecutivo = '" & folio & "' " & _
        "End", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlFolio.ExecuteReader
            While SqlRead.Read
                folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Function Guardaexistencias(ByVal Fecha As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisA "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function actualexistencias(ByVal Fecha As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisB "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function borraexistencias(ByVal Fecha As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisC "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function borraexistenciasLotes(ByVal Fecha As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisD "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function Guardaexistencias2(ByVal Fecha As String, ByVal alm As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisA2 "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & alm & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function actualexistencias2(ByVal Fecha As String, ByVal alm As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisB2 "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & alm & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function borraexistencias2(ByVal Fecha As String, ByVal alm As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisC2 "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & alm & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function borraexistenciasLotes2(ByVal Fecha As String, ByVal alm As String) As Integer
        Dim Sqlactualiza As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spActualizaexisD2 "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & alm & "'"

        Try

            With Sqlactualiza
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqlactualiza.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    'Public Function GUARDATOTALES(ByVal FechaDe As String) As Integer
    Public Function GUARDATOTALES(ByVal FechaDe As DateTime, ByVal FechaA As DateTime, ByVal almacen As String) As Integer
        Dim fde, fa As String
        fde = Format(FechaDe, "yyyy.MM.dd")
        fa = Format(FechaA, "yyyy.MM.dd")
        Dim SqlInstrSCompra As New SqlCommand
        CmdStr1 = "DECLARE @SICANTDEV INT DECLARE @SURTERUT INT DECLARE @DEV INT DECLARE @TotCanAlm INT DECLARE @ALTER INTEGER, @CargaRuta int, @entrada integer, @ProdSur int, @Cantidad INT,@Cantidad2 INT,@Cantidad3 INT,@IVA decimal(12,2),@IEPS decimal(12,2),@Costo decimal(12,2),@SUBTOTAL decimal(12,2),@TOTAL decimal(12,2) "
        CmdStr1 = CmdStr1 & "DELETE FROM REPTOT SET NOCOUNT ON; "
        CmdStr1 = CmdStr1 & "DECLARE CDetSal "
        CmdStr1 = CmdStr1 & "CURSOR FOR SELECT alterno FROM productos where activo = 1 order by alterno "
        'CmdStr1 = CmdStr1 & "CURSOR FOR SELECT [Codigo de Producto] FROM productos where existencia > 0 order by alterno "
        CmdStr1 = CmdStr1 & "OPEN CDetSal "
        CmdStr1 = CmdStr1 & "FETCH NEXT FROM CDetSal INTO @ALTER "
        CmdStr1 = CmdStr1 & "WHILE @@FETCH_STATUS = 0 "
        CmdStr1 = CmdStr1 & "BEGIN "
        CmdStr1 = CmdStr1 & "  SET @DEV = (SELECT sum(CANT_MOV2) from movimientos2 WHERE [ALTER] = @ALTER AND BajaMerma = 0 and (convert(varchar(10),FECHA_MOV2,102) BETWEEN '" & fde & "' and '" & fa & "' ))"
        'SE LE DESHABILITA POR EL DE ABAJO Y QUE SE LE CABIA TIPO DE "TIPO_MOV2 = 'STR'" POR "TIPO_MOV2 = 'ENT'" Y "PROV_MOV2 = '" & almacen & "'" POR "CLIEN_MOV2 = '" & almacen & "'"
        'CmdStr1 = CmdStr1 & " SET @entrada = (SELECT SUM(CANT_MOV2) FROM MOVIMIENTOS2 WHERE (TIPO_MOV2 = 'STR') AND (PROV_MOV2 = '" & almacen & "') AND ([ALTER] = @alter) AND (CONVERT(varchar(10), FECHA_MOV2, 102) BETWEEN '" & fde & "' AND '" & fa & "')) "
        CmdStr1 = CmdStr1 & " SET @entrada = (SELECT SUM(CANT_MOV2) FROM MOVIMIENTOS2 WHERE (TIPO_MOV2 = 'ENT') AND (CLIEN_MOV2 = '" & almacen & "') AND ([ALTER] = @alter) AND (CONVERT(varchar(10), FECHA_MOV2, 102) BETWEEN '" & fde & "' AND '" & fa & "')) "
        ' SE DESHABILITA POR EL DE ABAJO PARA TOME EN CUENTA TODOS LOS ALMACENES
        'CmdStr1 = CmdStr1 & "   SET @Cantidad = (SELECT sum(cantidad2) FROM LOTEEX2 WHERE [Codigo de Producto] = @Codigo and Almacen = 'MTR') IF @Cantidad IS NULL BEGIN set @Cantidad = 0 end "
        CmdStr1 = CmdStr1 & "   SET @Cantidad = (SELECT sum(cantidad2) FROM LOTEEX2 WHERE [ALTER] = @ALTER and Almacen = '" & almacen & "') IF @Cantidad IS NULL BEGIN set @Cantidad = 0 end "
        CmdStr1 = CmdStr1 & "   SET @SURTERUT = (SELECT sum(CAST(cantidad AS INT)) FROM SURTIDORUTAS WHERE (convert(varchar(10),SECARGOARUTA,102) BETWEEN '" & fde & "' and '" & fa & "' ) AND estatus = 0 AND [ALTER] = @alter ) IF @CargaRuta IS NULL BEGIN set @CargaRuta = 0 end "
        ' se deshabilita por los 2 de abajo
        'CmdStr1 = CmdStr1 & "   SET @Cantidad2 = (SELECT sum(CAST(cantidad AS INT)) FROM INVENTARIORUTA WHERE FECHA = (SELECT top 1 fecha FROM INVENTARIORUTA order by fecha desc) AND [codigo de producto] = @codigo) IF @Cantidad2 IS NULL BEGIN set @Cantidad2 = 0 end "
        ' SE CAMBIA LA CONDICION TIPO_MOV2 <> 'SMR' POR TIPO_MOV2 = 'STR'
        'CmdStr1 = CmdStr1 & " SET @SURTERUT = (SELECT sum(CAST(CANT_MOV2 AS INT)) FROM movimientos2 WHERE [codigo de producto] = @codigo AND TIPO_MOV2 <> 'SMR') IF @SURTERUT IS NULL BEGIN set @SURTERUT = 0 end "
        CmdStr1 = CmdStr1 & " SET @CargaRuta = (SELECT sum(CAST(CANT_MOV2 AS INT)) FROM movimientos2 WHERE [ALTER] = @ALTER AND TIPO_MOV2 = 'STR' and PROV_MOV2 = '" & almacen & "' AND (convert(varchar(10),FECHA_MOV2,102) BETWEEN '" & fde & "' and '" & fa & "' )) IF @SURTERUT IS NULL BEGIN set @SURTERUT = 0 end "
        'SE DESHABLITA EL DE ABAJO POR QUE SUMA DOS VECES EL CONTENIDO DE "DEVOLUCION"
        'CmdStr1 = CmdStr1 & " SET @SICANTDEV = (SELECT sum(CAST(DEVCPTE AS INT)) FROM DEVOLUCION WHERE DEVFECHA = (SELECT top 1 DEVFECHA FROM DEVOLUCION order by DEVFECHA desc) and [ALTER] = @ALTER AND DEVACT = 1) IF @SICANTDEV IS NULL BEGIN set @SICANTDEV = 0 end "
        'SE AGREGA PARA TOMAR EN CUENTA EL CAMPO DEVCANT EN TABLA DE DEVOLUCIONES
        CmdStr1 = CmdStr1 & " SET @Cantidad2 = (SELECT sum(CAST(DEVCPTE AS INT)) FROM DEVOLUCION WHERE DEVFECHA = (SELECT top 1 DEVFECHA FROM DEVOLUCION  where (convert(varchar(10),DEVFECHA,102) BETWEEN '" & fde & "' and '" & fa & "' ) order by DEVFECHA desc) and [ALTER] = @ALTER) IF @Cantidad2 IS NULL BEGIN set @Cantidad2 = @SICANTDEV end "
        'CmdStr1 = CmdStr1 & "  SET @Cantidad3 = (SELECT sum(cantidad) FROM INVENTARIOMACH WHERE [codigo de producto] = @codigo ) IF @Cantidad3 IS NULL BEGIN set @Cantidad3 = 0 end "
        ' se deshabilita por el de abajo ya que para INVENTARIOMACH es el total de surtido historico
        'CmdStr1 = CmdStr1 & "   SET @Cantidad3 = (SELECT sum(cantidad) FROM INVENTARIOMACH WHERE [ALTER] = @ALTER and (convert(varchar(10),FECHA,102) BETWEEN '" & fde & "' and '" & fa & "' )) IF @Cantidad3 IS NULL BEGIN set @Cantidad3 = 0 end "
        CmdStr1 = CmdStr1 & "   SET @Cantidad3 = (SELECT sum(cant) FROM movimientosm WHERE [ALTER] = @ALTER and (convert(varchar(10),FECHA,102) BETWEEN '" & fde & "' and '" & fa & "' )) IF @Cantidad3 IS NULL BEGIN set @Cantidad3 = 0 end "
        CmdStr1 = CmdStr1 & "   SET @Costo = (select [Precio de compra] from productos where alterno = @ALTER )   "
        CmdStr1 = CmdStr1 & "   SET @SUBTOTAL = ((@Cantidad + @Cantidad2 + @Cantidad3) * @Costo) "
        CmdStr1 = CmdStr1 & "   IF EXISTS(SELECT * FROM PRODUCTOS WHERE IIVA = 'SI' AND alterno = @ALTER) BEGIN SET @IVA = ((SELECT IVA FROM PRODUCTOS WHERE alterno = @ALTER) * @SUBTOTAL) END else SET @IVA = 0 "
        CmdStr1 = CmdStr1 & "   IF EXISTS(SELECT * FROM PRODUCTOS WHERE IIEPS = 'SI' AND alterno = @ALTER) BEGIN SET @IEPS = ((SELECT IEPS FROM PRODUCTOS WHERE alterno = @ALTER) * @SUBTOTAL) END else SET @IEPS = 0 "
        CmdStr1 = CmdStr1 & "   SET @TOTAL = (@SUBTOTAL + @IVA + @IEPS) "
        ' se deshabilita por el de abajo
        'CmdStr1 = CmdStr1 & "   if @SUBTOTAL <> 0 begin INSERT INTO REPTOT VALUES(@Codigo,@Cantidad,@Cantidad2,@Cantidad3,@Costo,@IEPS,@IVA,@SUBTOTAL,@TOTAL) end "
        ' se omite por el de abajo se quita el if @SUBTOTAL <> 0 begin
        'CmdStr1 = CmdStr1 & "  if @SUBTOTAL <> 0 begin INSERT INTO REPTOT VALUES(@ALTER,@Cantidad,@Cantidad2, @DEV, NULL, @Cantidad3,@SURTERUT,@Costo,@IEPS,@IVA,@SUBTOTAL,@TOTAL, @entrada, '" & almacen & "', '" & FechaDe & "', '" & FechaA & "', null) end"
        CmdStr1 = CmdStr1 & "   INSERT INTO REPTOT VALUES(@ALTER,@Cantidad,@Cantidad2, @DEV, NULL, @Cantidad3,@SURTERUT,@Costo,@IEPS,@IVA,@SUBTOTAL,@TOTAL, @entrada, '" & almacen & "', '" & FechaDe & "', '" & FechaA & "', @CargaRuta) "
        CmdStr1 = CmdStr1 & "  FETCH NEXT FROM CDetSal INTO @ALTER END "
        CmdStr1 = CmdStr1 & "  CLOSE CDetSal"
        CmdStr1 = CmdStr1 & "  DEALLOCATE CDetSal"
        CmdStr1 = CmdStr1 & "  "
        'generaArchivo(CmdStr1)

        'CmdStr1 = "DECLARE @SICANTDEV INT DECLARE @SURTERUT INT DECLARE @DEV INT DECLARE @TotCanAlm INT DECLARE @Codigo nchar(30),@Cantidad INT,@Cantidad2 INT,@Cantidad3 INT,@IVA decimal(12,2),@IEPS decimal(12,2),@Costo decimal(12,2),@SUBTOTAL decimal(12,2),@TOTAL decimal(12,2) "
        'CmdStr1 = CmdStr1 & "DELETE FROM REPTOT SET NOCOUNT ON; "
        'CmdStr1 = CmdStr1 & "DECLARE CDetSal "
        'CmdStr1 = CmdStr1 & "CURSOR FOR SELECT [Codigo de Producto] FROM productos order by alterno "
        ''CmdStr1 = CmdStr1 & "CURSOR FOR SELECT [Codigo de Producto] FROM productos where existencia > 0 order by alterno "
        'CmdStr1 = CmdStr1 & "OPEN CDetSal "
        'CmdStr1 = CmdStr1 & "FETCH NEXT FROM CDetSal INTO @Codigo "
        'CmdStr1 = CmdStr1 & "WHILE @@FETCH_STATUS = 0 "
        'CmdStr1 = CmdStr1 & "BEGIN "
        'CmdStr1 = CmdStr1 & "  SET @DEV = (SELECT sum(CANT_MOV2) from movimientos2 WHERE [Codigo de Producto] = @Codigo AND BajaMerma = 0 and convert(varchar(10),FECHA_MOV2,102) = '" & FechaDe & "')"
        'CmdStr1 = CmdStr1 & "   SET @Cantidad = (SELECT sum(cantidad2) FROM LOTEEX2 WHERE [Codigo de Producto] = @Codigo and Almacen = 'MTR' ) IF @Cantidad IS NULL BEGIN set @Cantidad = 0 end "
        '' se deshabilita por los 2 de abajo
        ''CmdStr1 = CmdStr1 & "   SET @Cantidad2 = (SELECT sum(CAST(cantidad AS INT)) FROM INVENTARIORUTA WHERE FECHA = (SELECT top 1 fecha FROM INVENTARIORUTA order by fecha desc) AND [codigo de producto] = @codigo) IF @Cantidad2 IS NULL BEGIN set @Cantidad2 = 0 end "
        '' SE CAMBIA LA CONDICION TIPO_MOV2 <> 'SMR' POR TIPO_MOV2 = 'STR'
        ''CmdStr1 = CmdStr1 & " SET @SURTERUT = (SELECT sum(CAST(CANT_MOV2 AS INT)) FROM movimientos2 WHERE [codigo de producto] = @codigo AND TIPO_MOV2 <> 'SMR') IF @SURTERUT IS NULL BEGIN set @SURTERUT = 0 end "
        'CmdStr1 = CmdStr1 & " SET @SURTERUT = (SELECT sum(CAST(CANT_MOV2 AS INT)) FROM movimientos2 WHERE [codigo de producto] = @codigo AND TIPO_MOV2 = 'STR' and convert(varchar(10),FECHA_MOV2,102) = '" & FechaDe & "') IF @SURTERUT IS NULL BEGIN set @SURTERUT = 0 end "
        'CmdStr1 = CmdStr1 & " SET @SICANTDEV = (SELECT sum(CAST(DEVCPTE AS INT)) FROM DEVOLUCION WHERE convert(varchar(10),devFECHA,102) = '" & FechaDe & "' and IDPROD = @codigo AND DEVACT = 1) IF @SICANTDEV IS NULL BEGIN set @SICANTDEV = 0 end "
        ''SE AGREGA PARA TOMAR EN CUENTA EL CAMPO DEVCANT EN TABLA DE DEVOLUCIONES
        'CmdStr1 = CmdStr1 & " SET @Cantidad2 = (SELECT sum(CAST(DEVCANT AS INT)) FROM DEVOLUCION WHERE convert(varchar(10),devFECHA,102) = '" & FechaDe & "' and IDPROD = @codigo ) IF @Cantidad2 IS NULL BEGIN set @Cantidad2 = @SICANTDEV end "
        ''CmdStr1 = CmdStr1 & "  SET @Cantidad3 = (SELECT sum(cantidad) FROM INVENTARIOMACH WHERE [codigo de producto] = @codigo ) IF @Cantidad3 IS NULL BEGIN set @Cantidad3 = 0 end "
        'CmdStr1 = CmdStr1 & "   SET @Cantidad3 = (SELECT sum(cantidad) FROM INVENTARIOMACH WHERE [codigo de producto] = @codigo AND convert(varchar(10),FECHA,102) = '" & FechaDe & "') IF @Cantidad3 IS NULL BEGIN set @Cantidad3 = 0 end "
        'CmdStr1 = CmdStr1 & "   SET @Costo = (select [Precio de compra] from productos where [Codigo de producto] = @Codigo )   "
        'CmdStr1 = CmdStr1 & "   SET @SUBTOTAL = ((@Cantidad + @Cantidad2 + @Cantidad3) * @Costo) "
        'CmdStr1 = CmdStr1 & "   IF EXISTS(SELECT * FROM PRODUCTOS WHERE IIVA = 'SI' AND [Codigo de producto] = @Codigo) BEGIN SET @IVA = ((SELECT IVA FROM PRODUCTOS WHERE [Codigo de producto] = @Codigo) * @SUBTOTAL) END else SET @IVA = 0 "
        'CmdStr1 = CmdStr1 & "   IF EXISTS(SELECT * FROM PRODUCTOS WHERE IIEPS = 'SI' AND [Codigo de producto] = @Codigo) BEGIN SET @IEPS = ((SELECT IEPS FROM PRODUCTOS WHERE [Codigo de producto] = @Codigo) * @SUBTOTAL) END else SET @IEPS = 0 "
        'CmdStr1 = CmdStr1 & "   SET @TOTAL = (@SUBTOTAL + @IVA + @IEPS) "
        '' se deshabilita por el de abajo
        ''CmdStr1 = CmdStr1 & "   if @SUBTOTAL <> 0 begin INSERT INTO REPTOT VALUES(@Codigo,@Cantidad,@Cantidad2,@Cantidad3,@Costo,@IEPS,@IVA,@SUBTOTAL,@TOTAL) end "
        'CmdStr1 = CmdStr1 & "  if @SUBTOTAL <> 0 begin if @DEV IS NULL BEGIN set @DEV = 0 END INSERT INTO REPTOT VALUES(@Codigo,@Cantidad,@Cantidad2, @DEV, NULL, @Cantidad3,@SURTERUT,@Costo,@IEPS,@IVA,@SUBTOTAL,@TOTAL) end"
        'CmdStr1 = CmdStr1 & "  FETCH NEXT FROM CDetSal INTO @Codigo END "
        'CmdStr1 = CmdStr1 & "  CLOSE CDetSal"
        'CmdStr1 = CmdStr1 & "  DEALLOCATE CDetSal"
        'CmdStr1 = CmdStr1 & "  "
        ''generaArchivo(CmdStr1)

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
    Public Function Diferencias2A(ByVal Fecha As String, ByVal alm As String) As Integer
        Dim Sqldifer As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spDiferExis "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & alm & "'"

        Try

            With Sqldifer
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqldifer.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function Diferencias2B(ByVal Fecha As String, ByVal alm As String) As Integer
        Dim Sqldifer2 As New SqlCommand

        Error1 = 0
        CmdStr1 = Nothing
        CmdStr1 = "exec spDiferInve "
        CmdStr1 = CmdStr1 & "'" & Fecha & "'" & ","
        CmdStr1 = CmdStr1 & "'" & alm & "'"

        Try

            With Sqldifer2
                .CommandText = CmdStr1
                .Connection = SqlCnn
            End With

            Sqldifer2.ExecuteNonQuery()
        Catch ex As SqlException
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try

    End Function
    Public Function SELECCIONA(ByVal TIPOMOVS) As String
        Dim SqlSelDes As New SqlCommand("declare @numero int delete from COUNTMOV where MONTH <> '" & Format(DateTime.Now, "MM") & "' " & _
        "if exists (SELECT COUNT + 1 FROM COUNTMOV WHERE  TIPOMOV = '" & TIPOMOVS & "' AND MONTH = '" & Format(DateTime.Now, "MM") & "') " & _
        "BEGIN SET @numero = (SELECT COUNT + 1 FROM COUNTMOV WHERE  TIPOMOV = '" & TIPOMOVS & "' AND MONTH = '" & Format(DateTime.Now, "MM") & "') UPDATE COUNTMOV set count = @numero WHERE TIPOMOV = '" & TIPOMOVS & "' AND MONTH = '" & Format(DateTime.Now, "MM") & "' END ELSE BEGIN SET @numero = 1 INSERT INTO COUNTMOV VALUES('" & TIPOMOVS & "','" & Format(DateTime.Now, "MM") & "',1) END " & _
        "SELECT @numero ", SqlCnn)
        Dim SqlRead As SqlDataReader
        Dim fami As New String(Nothing)
        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                fami = SqlRead.GetSqlInt32(0)
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try
        Return fami
    End Function
End Module
