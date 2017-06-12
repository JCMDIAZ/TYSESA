Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class ImpresionZPL
    Public Const GENERIC_WRITE = &H40000000
    Public Const OPEN_EXISTING = 3
    Public Const FILE_SHARE_WRITE = &H2

    Dim LPTPORT As String
    Dim PuertoImpresion As String = "USB002"

    Friend WithEvents btnImpresion As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Dim hPort As Integer

    Public Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" ( _
    ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, _
    ByVal dwShareMode As Integer, _
     ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, _
    ByVal dwCreationDisposition As Integer, _
    ByVal dwFlagsAndAttributes As Integer, _
    ByVal hTemplateFile As Integer) As Integer

    Public Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" _
                            (ByVal hObject As Integer) As Integer
    Dim retval As Integer

    Public Structure SECURITY_ATTRIBUTES
        Private nLength As Integer
        Private lpSecurityDescriptor As Integer
        Private bInheritHandle As Integer
    End Structure


    Public Sub Impresion(ByVal Evento As String, ByVal Nombre As String, _
                         ByVal Apellidos As String, ByVal Empresa As String, _
                         ByVal Codigo As String, ByVal Fecha As String)

        Dim SA As SECURITY_ATTRIBUTES
        'outFile es el archivo stream que contien la etiqueta y su formato
        Dim outFile As FileStream, hPortP As IntPtr
        'Imprime por LPT1 en local.
        'Para la impresión por red vía net use.
        'Se ha de crear un bat con: --> net use LPT2 /del 

        ' --> net use LPT2 \\NombrePC\NombreImpresoraCompartida y colocarlo en
        '....\All Users\Menú Inicio\Programas\Inicio 
        'para que cada usr. que inicie tenga 
        LPTPORT = PuertoImpresion
        hPort = ImpresionZPL.CreateFile(LPTPORT, ImpresionZPL.GENERIC_WRITE, ImpresionZPL.FILE_SHARE_WRITE, _
                           SA, ImpresionZPL.OPEN_EXISTING, 0, 0)



        'Convertir Integer a IntPtr 
        hPortP = New IntPtr(hPort)
        'Crear FileStream usando Handle 
        'outFile = New FileStream(hPortP, FileAccess.Write)
        Dim Safe As New Microsoft.Win32.SafeHandles.SafeFileHandle(hPortP, True)
        outFile = New FileStream(Safe, FileAccess.Write)



        Dim fileWriter As New StreamWriter(outFile)

        'Sustitución de caracteres. El alfabeto que maneja esta impresora en concreto

        'es solo inglés por eso se sustituyen las tildes, eñes, etc.

        'Esta operación se debe realizar con todos los campos susceptibles a contener 

        'carácteres no aceptados 
        Apellidos = (Apellidos.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U").Replace("ñ", "n").Replace("Ñ", "N").Replace("ç", "c").Replace("Ç", "C").Replace("ª", "."))

        'Poner a mayusculas la primera letra
        Empresa = Empresa.ToLower
        Empresa = (Application.CurrentCulture.TextInfo.ToTitleCase(Empresa))
        Nombre = Nombre.ToLower
        Nombre = (Application.CurrentCulture.TextInfo.ToTitleCase(Nombre))
        Apellidos = Apellidos.ToLower
        Apellidos = (Application.CurrentCulture.TextInfo.ToTitleCase(Apellidos))

        '--------------------------INICIO ETIQUETA---------------------------' 
        fileWriter.Write("^XA")
        'Deshabilita el panel de la impresora, para que el usr no pueda acceder
        fileWriter.Write("^MPS")
        'Posicion del eje de cordenadas, en dots
        fileWriter.Write("^LH0,0")
        'FO para el inicio de escritura, eje X,Y
        'AU el formato de la fuente
        'FB establece un espacio de 900 dots y la C para centrar el texto
        fileWriter.Write("^FO1,30^AU^FB900,1,0,C^FD" & Evento & "^FS")

        'AD el formato de la fuente y el 20 para el tamaño de la fuente
        fileWriter.Write("^FO50,90^AD,,20^FD" & Apellidos & "^FS")

        fileWriter.Write("^FO50,130^AD,,20^FD" & Nombre & "^FS")

        fileWriter.Write("^FO520,130^AD,,10^FD" & "Historia Cl. " & Empresa & "^FS")

        'GB escribe una linea horizontal 900 largo, 0 grosor y 2 ancho
        fileWriter.Write("^FO50,165^FR^GB900,0,2^FS")

        fileWriter.Write("^FO520,180^AD^FD" & Fecha & "^FS")

        'B3 escribe el texto en cod. de barras tipo B3 (alfanumerico)

        'el 60 para el tamaño
        fileWriter.Write("^FO200,200^B3,,60^FD" & Codigo & " ^FS")
        '--------------------------PIE DE ETIQUETA---------------------------'
        fileWriter.Write("^FO100,290^AD^FD" & "SUJA Corporation" & "^FS")
        'Finaliza la etiqueta
        fileWriter.Write("^XZ")
        fileWriter.Flush()
        fileWriter.Close()
        outFile.Close()
        retval = CloseHandle(hPort)
    End Sub

End Class
