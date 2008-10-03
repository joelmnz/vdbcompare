Module G
  Private Const STR_Zip As String = ".zip"
  Private Const STR_VistaDB20dll As String = "VistaDB20.dll"

  Public Declare Function DragAcceptFiles Lib "shell32.dll" (ByVal hwnd As IntPtr, ByVal accept As Boolean) As Long
  Public Declare Function DragQueryFile Lib "shell32.dll" (ByVal hdrop As IntPtr, ByVal ifile As Integer, ByVal fname As System.Text.StringBuilder, ByVal fnsize As Integer) As Integer
  Public Declare Sub DragFinish Lib "Shell32.dll" (ByVal hdrop As IntPtr)
  Public Const WM_DROPFILES As Integer = 563

  Public Const TICON_TABLE As Integer = 0
  Public Const TICON_TABLE_ADD As Integer = 1
  Public Const TICON_TABLE_DROP As Integer = 2

  Public Const TICON_FIELD As Integer = 4
  Public Const TICON_FIELD_ADD As Integer = 5
  Public Const TICON_FIELD_DROP As Integer = 6
  Public Const TICON_FIELD_ALTER As Integer = 7

  Public Const TICON_FIELD_INFO As Integer = 8



  Public Function IsItemInArray(ByVal stringArray() As String, ByVal searchValue As String) As Boolean
    If stringArray Is Nothing Then Return False
    For Each s As String In stringArray
      If s = searchValue Then Return True
    Next
    Return False
  End Function

  Public Function StartProcess(ByVal sProcess As String) As Boolean
    Try
      System.Diagnostics.Process.Start(sProcess)
      Return True
    Catch ex As Exception
      DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Start Process", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End Try
  End Function

  Public Function StartProcess(ByVal sProcess As String, ByVal args As String) As Boolean
    Try
      System.Diagnostics.Process.Start(sProcess, args)
      Return True
    Catch ex As Exception
      DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Start Process", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End Try
  End Function


  Public Function GetFileSize_MB(ByVal theFile As String) As Double
    If IO.File.Exists(theFile) Then
      'IO.File.GetAttributes(datafile).
      Return CType((FileLen(theFile) / 1048576).ToString("0.00"), Double)
    End If
  End Function

  Public Function LaunchVistaDBBuilder() As Boolean
    Dim sPath As String = ""

    sPath = My.Resources.DataBuilderDefaultPath

    If Not IO.File.Exists(sPath) Then
      'try to find it
      'try to find path in registry
      'If My.Computer.Registry.CurrentUser.GetValue("Software\Vista Software\VistaDB\RootDir", Nothing) Is Nothing Then
      If My.Computer.Registry.GetValue(My.Resources.DataBuilderRegPath, My.Resources.DataBuilderRegKey, Nothing) Is Nothing Then
        'may not be installed.
        DevExpress.XtraEditors.XtraMessageBox.Show("VistaDB Data Builder may not be installed.", "VistaDB Data Builder", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
      Else
        'get path
        sPath = My.Computer.Registry.GetValue(My.Resources.DataBuilderRegPath, My.Resources.DataBuilderRegKey, My.Resources.DataBuilderDefaultDir)
        If Not sPath.EndsWith("\") Then sPath &= "\Tools\Data Builder\DataBuilder.exe"

        'make sure the folder exists
        '? Nah

      End If
    End If



    Return G.StartProcess(sPath)

  End Function

  Public Function LaunchVistaDBBuilder3() As Boolean
    Dim sPath As String = ""

    sPath = My.Resources.DataBuilderDefaultPath_3

    If Not IO.File.Exists(sPath) Then
      'try to find it
      'try to find path in registry
      'If My.Computer.Registry.CurrentUser.GetValue("Software\Vista Software\VistaDB\RootDir", Nothing) Is Nothing Then
      If My.Computer.Registry.GetValue(My.Resources.DataBuilderRegPath_3, My.Resources.DataBuilderRegKey, Nothing) Is Nothing Then
        'may not be installed.
        DevExpress.XtraEditors.XtraMessageBox.Show("VistaDB Data Builder may not be installed.", "VistaDB Data Builder", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
      Else
        'get path
        sPath = My.Computer.Registry.GetValue(My.Resources.DataBuilderRegPath_3, My.Resources.DataBuilderRegKey, My.Resources.DataBuilderDefaultDir_3)
        If Not sPath.EndsWith("\") Then sPath &= "\Tools\Data Builder\Bin\DataBuilder.exe"

        'make sure the folder exists
        '? Nah

      End If
    End If

    Return G.StartProcess(sPath)

  End Function

  Public Function PackDatabase(ByVal dataFile As String) As Boolean
    'no error handling, calling code wants to display error message
    If dataFile = "" Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Please enter a Database First", "Pack Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Return False
    End If

    If IO.File.Exists(dataFile) = False Then
      DevExpress.XtraEditors.XtraMessageBox.Show("File not found!", "Pack Database", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
      Return False
    End If

    Try
      Select Case IO.Path.GetExtension(dataFile).ToLower
        Case ".vdb"
          Return vdb2.vdbScriptEngine.PackDatabase(dataFile)

        Case ".vdb3"
          Return vdb3.vdbScriptEngine.PackDatabase(dataFile)
        Case Else

          DevExpress.XtraEditors.XtraMessageBox.Show("UnRecognized file extension '" & IO.Path.GetExtension(dataFile) & "', please use vdb or vdb3 files.", "Pack Database", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
          Return False
      End Select
    Catch ex As Exception
      DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error packing database", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    End Try


  End Function

  Public Function FormatFileSize(ByVal byteLenght As Long) As String
    'smart function 
    Select Case byteLenght
      Case Is < 1024
        'bytes, very small
        Return byteLenght.ToString("0 bytes")
      Case Is < 1048576
        'Kb
        Return (byteLenght / 1024).ToString("0 KB")
      Case Is < 1073741824
        'MB
        Return (byteLenght / 1048576).ToString("0 MB")
      Case Else
        'GB
        Return (byteLenght / 1073741824).ToString("0 GB")
    End Select

  End Function

  Public Function IsVdb2File(ByVal fileName As String) As Boolean
    If fileName = "" Then Return False
    Select Case IO.Path.GetExtension(fileName).ToLower
      Case ".vdb", ".vdb2"
        Return True
      Case Else
        Return False
    End Select
  End Function

  Public Function IsVdb3File(ByVal fileName As String) As Boolean
    If fileName = "" Then Return False
    Return IO.Path.GetExtension(fileName).ToLower = ".vdb3"
  End Function

  Public Function IsDbOfSameVersion(ByVal file1 As String, ByVal file2 As String) As Boolean
    If file1 = "" Then Return False
    If file2 = "" Then Return False

    file1 = IO.Path.GetExtension(file1)
    file2 = IO.Path.GetExtension(file2)

    Return file1 = file2
  End Function

  Public Sub RunSystemChecks()

    'look for VistaDb20.dll

    'removed auto fix to comply with open source license
  End Sub

#Region "  Zip File Handling  "


  Public Sub FileCompress(ByVal fileName As String, ByVal sZipFileName As String, Optional ByVal CompressionLevel As Integer = 6, Optional ByVal Password As String = "")
    Dim ar As ArrayList = New ArrayList(1)

    ar.Add(fileName)

    FileCompress(ar.GetEnumerator, sZipFileName, CompressionLevel, Password)

    ar = Nothing
  End Sub

  Public Sub FileCompress(ByVal e As Collections.IEnumerator, ByVal sZipFileName As String, ByVal CompressionLevel As Integer, Optional ByVal Password As String = "")
    'Note: File names only, no folders
    Dim strmZipOutputStream As ICSharpCode.SharpZipLib.Zip.ZipOutputStream
    Dim objCrc32 As ICSharpCode.SharpZipLib.Checksums.Crc32 = New ICSharpCode.SharpZipLib.Checksums.Crc32

    strmZipOutputStream = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(IO.File.Create(sZipFileName))

    ' Compression Level: 0-9
    ' 0: no(Compression) - fastest
    ' 9: maximum compression - slowest
    If CompressionLevel <= 0 Then
      'use default
      CompressionLevel = 6
    End If
    If CompressionLevel > 9 Then
      CompressionLevel = 6
    End If

    strmZipOutputStream.SetLevel(CompressionLevel)

    If Password <> String.Empty Then
      strmZipOutputStream.Password = Password
    End If

    While e.MoveNext
      Dim strmFile As IO.FileStream = IO.File.OpenRead(e.Current)
      Dim abyBuffer(strmFile.Length - 1) As Byte

      strmFile.Read(abyBuffer, 0, abyBuffer.Length)
      Dim objZipEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry = New ICSharpCode.SharpZipLib.Zip.ZipEntry(IO.Path.GetFileName(e.Current))

      objZipEntry.DateTime = DateTime.Now
      objZipEntry.Size = strmFile.Length
      strmFile.Close()
      objCrc32.Reset()
      objCrc32.Update(abyBuffer)
      objZipEntry.Crc = objCrc32.Value
      strmZipOutputStream.PutNextEntry(objZipEntry)
      strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)
    End While

    strmZipOutputStream.Finish()
    strmZipOutputStream.Close()

    strmZipOutputStream = Nothing

    objCrc32 = Nothing

  End Sub

  Public Function FileCompressInMemory(ByVal fileName As String, ByVal CompressionLevel As Integer, Optional ByVal Password As String = "") As Byte()
    'Note: File names only, no folders
    Dim strmZipOutputStream As ICSharpCode.SharpZipLib.Zip.ZipOutputStream
    Dim objCrc32 As ICSharpCode.SharpZipLib.Checksums.Crc32 = New ICSharpCode.SharpZipLib.Checksums.Crc32

    'strmZipOutputStream = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(File.Create(sZipFileName))
    Dim ms As IO.MemoryStream = New IO.MemoryStream

    strmZipOutputStream = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(ms)

    ' Compression Level: 0-9
    ' 0: no(Compression) - fastest
    ' 9: maximum compression - slowest
    If CompressionLevel <= 0 Then
      'use default
      CompressionLevel = 6
    End If
    If CompressionLevel > 9 Then
      CompressionLevel = 6
    End If

    strmZipOutputStream.SetLevel(CompressionLevel)

    If Password <> "" Then
      strmZipOutputStream.Password = Password
    End If


    Dim strmFile As IO.FileStream = IO.File.OpenRead(fileName)
    Dim abyBuffer(strmFile.Length - 1) As Byte

    strmFile.Read(abyBuffer, 0, abyBuffer.Length)
    Dim objZipEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry = New ICSharpCode.SharpZipLib.Zip.ZipEntry(IO.Path.GetFileName(fileName))

    objZipEntry.DateTime = DateTime.Now
    objZipEntry.Size = strmFile.Length
    strmFile.Close()
    objCrc32.Reset()
    objCrc32.Update(abyBuffer)
    objZipEntry.Crc = objCrc32.Value
    strmZipOutputStream.PutNextEntry(objZipEntry)
    strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)


    strmZipOutputStream.Finish()
    Dim arRetults() As Byte = ms.ToArray()
    strmZipOutputStream.Close()

    strmZipOutputStream = Nothing

    objCrc32 = Nothing

    'tidy up
    If Not ms Is Nothing Then
      ms = Nothing
    End If

    Return arRetults


  End Function


  Public Function zipDecompressSingleFile(ByVal sZipFileName As String, ByVal sTargetFileName As String) As String
    'Note this has only been tested with file in zip base dir (e.g. no sub folders in the zip file)
    Dim objEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry
    Dim s As ICSharpCode.SharpZipLib.Zip.ZipInputStream

    'Dim directoryName As String
    Dim fileName As String = ""

    Dim streamWriter As IO.FileStream

    s = New ICSharpCode.SharpZipLib.Zip.ZipInputStream(IO.File.OpenRead(sZipFileName))

    'Do
    objEntry = s.GetNextEntry
    If Not objEntry Is Nothing Then

      'changing this to use the supplied dir, dont know what it was doing before, not used in this app anyway
      'directoryName = Path.Combine(sExtractToFolder, Path.GetDirectoryName(objEntry.Name))

      'fileName = Path.GetFileName(objEntry.Name)
      fileName = sTargetFileName

      '// create directory
      'Directory.CreateDirectory(directoryName)

      If fileName <> String.Empty Then
        'streamWriter = File.Create(Path.Combine(directoryName, fileName))
        streamWriter = IO.File.Create(fileName)

        Dim iSize As Integer = 2048
        Dim data(iSize) As Byte

        Do
          iSize = s.Read(data, 0, data.Length)
          If iSize > 0 Then
            streamWriter.Write(data, 0, iSize)
          Else
            Exit Do
          End If
        Loop
        streamWriter.Close()
      End If
    End If
    'Loop Until (objEntry Is Nothing)

    objEntry = Nothing

    s.Close()
    s = Nothing

    streamWriter = Nothing

    Return fileName

  End Function


  Public Sub FileDecompress(ByVal sZipFileName As String, ByVal sExtractTo As String)
    'Note this has only been tested with file in zip base dir (e.g. no sub folders in the zip file)
    Dim objEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry
    Dim s As ICSharpCode.SharpZipLib.Zip.ZipInputStream

    Dim directoryName As String
    Dim fileName As String

    Dim streamWriter As IO.FileStream

    s = New ICSharpCode.SharpZipLib.Zip.ZipInputStream(IO.File.OpenRead(sZipFileName))

    Do
      objEntry = s.GetNextEntry
      If Not objEntry Is Nothing Then

        'changing this to use the supplied dir, dont know what it was doing before, not used in this app anyway
        directoryName = IO.Path.Combine(sExtractTo, IO.Path.GetDirectoryName(objEntry.Name))

        fileName = IO.Path.GetFileName(objEntry.Name)

        '// create directory
        'Directory.CreateDirectory(directoryName)

        If fileName <> "" Then
          streamWriter = IO.File.Create(IO.Path.Combine(directoryName, fileName))

          Dim iSize As Integer = 2048
          Dim data(iSize) As Byte

          Do
            iSize = s.Read(data, 0, data.Length)
            If iSize > 0 Then
              streamWriter.Write(data, 0, iSize)
            Else
              Exit Do
            End If
          Loop
          streamWriter.Close()
        End If
      End If
    Loop Until (objEntry Is Nothing)

    objEntry = Nothing

    s.Close()
    s = Nothing

    streamWriter = Nothing

  End Sub



#End Region

End Module
