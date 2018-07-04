
'Namespace calculation_water
Module Tini
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Dim Sect As String
    Dim ConfigFile As String
    Public Function SaveValue(Variable As String, Value As Object) As Boolean
        Dim FS As String, L As Boolean, TConf As String
        FS = Value
        If ConfigFile = "" Then TConf = Application.StartupPath & "\Config.ini" Else TConf = ConfigFile
        Return L = WritePrivateProfileString(Sect, Variable, FS, TConf)
    End Function
    Public Function LoadValue(Variable As String, Optional Default1 As String = "0") As String
        Dim FS As String, TConf As String
        FS = Space$(255)
        If ConfigFile = "" Then TConf = Application.StartupPath & "\Config.ini" Else TConf = ConfigFile
        GetPrivateProfileString(Sect, Variable, Default1, FS, Len(FS), TConf)
        LoadValue = FS
    End Function
    Public Function SetSection(S As String) As Boolean
        Sect = S : SetSection = True
    End Function
    Public Function SetConfigurationFile(FileName As String) As Boolean
        ConfigFile = FileName : SetConfigurationFile = True
    End Function
End Module
'End Namespace