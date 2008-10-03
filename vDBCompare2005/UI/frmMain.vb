Public Class frmMain
  Implements IMessageFilter
  Private Const ONLINE_MANUAL_URL As String = "http://www.meikleprogramming.com/software/vdbcompare/manual/"

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    DevExpress.UserSkins.OfficeSkins.Register()

    DevExpress.Skins.SkinManager.EnableFormSkins()

    'setup display (as removed tab control)
    'With Me.ksplitSchema
    '    .Top = Me.scriptPanel.Top
    '    .Left = Me.scriptPanel.Left
    '    .Width = Me.scriptPanel.Width
    '    .Height = Me.scriptPanel.Height
    '    .Anchor = Me.scriptPanel.Anchor
    'End With

    'With Me.ksplitDifferences
    '    .Top = Me.scriptPanel.Top
    '    .Left = Me.scriptPanel.Left
    '    .Width = Me.scriptPanel.Width
    '    .Height = Me.scriptPanel.Height
    '    .Anchor = Me.scriptPanel.Anchor
    'End With

  End Sub

  Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Application.AddMessageFilter(Me)

    DragAcceptFiles(Me.txtMasterDB.Handle, True)
    DragAcceptFiles(Me.tvDB1.Handle, True)

    DragAcceptFiles(Me.txtCompareDB.Handle, True)
    DragAcceptFiles(Me.tvDB2.Handle, True)



    Me.SetDisplayMode()

    'display
    Me.SetSkin(My.Settings.Skin)


    G.RunSystemChecks()

  End Sub

  Private Sub SetDisplayMode()

    Me.txtScript.Visible = True

    Me.ConvertToAccessToolStripMenuItem.Enabled = True
    ToAccessmdbToolStripMenuItem.Enabled = True
    ToAccessmdbToolStripMenuItem1.Enabled = True

    'scripting
    chkGenScript.Checked = True
    chkGenScript.Enabled = True


  End Sub



#Region "  Drag/Drop File Handling  "

  Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements IMessageFilter.PreFilterMessage

    If m.Msg = WM_DROPFILES Then

      'Trace.WriteLine("File Dropped")

      'this code to handle multiple dropped files.. 
      'not really neccesary for this example
      Dim nfiles As Integer = DragQueryFile(m.WParam, -1, Nothing, 0)

      Dim i As Integer
      For i = 0 To nfiles
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder(256)

        'Trace.WriteLine(m.WParam)
        'Trace.WriteLine(m.LParam)
        'Trace.WriteLine(m.HWnd)
        'Trace.WriteLine(m.Result)

        DragQueryFile(m.WParam, i, sb, 256)
        HandleDroppedFiles(sb.ToString(), m.HWnd.ToInt64)
      Next
      DragFinish(m.WParam)
      Return True
    End If
    Return False
  End Function

  Public Sub HandleDroppedFiles(ByVal file As String, ByVal hWnd As Long)
    If Len(file) > 0 Then

      'If Not file.EndsWith(".vdb") Then
      '    If DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure this is a VistaDB Database?", "Suspect File Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub
      'End If

      'LoadPicture(file)
      Select Case hWnd
        Case txtMasterDB.Handle.ToInt64
          txtMasterDB.Text = file
        Case Me.tvDB1.Handle.ToInt64()
          txtMasterDB.Text = file
          'load schema now
          PrintSchema(file, Me.tvDB1)
        Case Me.txtCompareDB.Handle.ToInt64
          Me.txtCompareDB.Text = file
        Case Me.tvDB2.Handle.ToInt64()
          Me.txtCompareDB.Text = file
          'load schema now
          PrintSchema(file, Me.tvDB2)
      End Select

      UpdateDBShortNames()

    End If
  End Sub


#End Region

  Private Sub OnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click, CompareToolStripMenuItem.Click
    'a bit of validation first
    If Me.txtMasterDB.Text = "" Or Me.txtCompareDB.Text = "" Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Please select the databases to compare", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    If Not IO.File.Exists(Me.txtMasterDB.Text) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Master Database not found!", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    If Not IO.File.Exists(Me.txtCompareDB.Text) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Compare Database not found!", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    'can not compare vdb3 db's yet!
    'If Me.txtMasterDB.Text.EndsWith("vdb3") Or Me.txtCompareDB.Text.EndsWith("vdb3") Then
    '    DevExpress.XtraEditors.XtraMessageBox.Show("Sorry, compare for vdb3 is still under construction" & Environment.NewLine & _
    '    "(Please check for an update regular, coming soon)", "vdb3 not supported (yet)", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
    '    Return
    'End If

    'can not cross compare (yet)
    'ToDo: cross compare dbs (e.g. db2 compared to db3 schema)
    If G.IsDbOfSameVersion(Me.txtMasterDB.ToString, Me.txtCompareDB.ToString) = False Then
      'If Me.txtMasterDB.Text.Substring(Me.txtMasterDB.Text.Length - 3) <> Me.txtCompareDB.Text.Substring(Me.txtCompareDB.Text.Length - 3) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Sorry, currently can only compare VistaDB 2.x databases" & Environment.NewLine _
      & "(Cross compare under development)", "Database Version Warning", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
      Return
    End If

    'clear outputs
    tvDiff1.Nodes.Clear()
    tvDiff2.Nodes.Clear()
    Me.txtScript.Text = ""

    'auto load schema first (just in case)
    Try
      PrintSchema(Me.txtMasterDB.Text, Me.tvDB1)
      PrintSchema(Me.txtCompareDB.Text, Me.tvDB2)
    Catch ex As Exception
      DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error loading schema view", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
      Return
    End Try

    '19-Aug-07: CompareDatabases now does all the hard work for the reliant db provider BooYaa!!!

    If CompareDatabases(Me.txtMasterDB.Text, Me.txtCompareDB.Text, tvDiff1, Me.chkGenScript.Checked) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("The database structures are the same.", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Return ' they are the same, exit now
    End If

    'they are different so check out reverse
    CompareDatabases(Me.txtCompareDB.Text, Me.txtMasterDB.Text, tvDiff2, False)
    'never script changes for reverse compare (e.g. downgrade), user must swap db's to do that


    'set focus to tab
    'Me.TabControl1.SelectedIndex = 1
    'Me.View_Differences()


    'removed, now done in Compare
    'new scripting test
    'If Me.chkGenScript.Checked Then
    '    'Dim differences As DbDiff = ScriptEngine.GetDifferences(Me.txtMasterDB.Text, Me.txtCompareDB.Text, My.Settings.CodeGen_ProcessIndexes)
    '    'If differences IsNot Nothing Then
    '    '    If differences.Tables.Count > 0 Then
    '    '        'there are some differences
    '    '        'Me.txtScript.Text = differences.Script(ScriptLanguageEnum.VbNet)
    '    '        Me.txtScript.Text = differences.Script(ScriptEngine.CLangType(My.Settings.ScriptLang))
    '    '        Me.View_Script()
    '    '    End If
    '    'End If

    '    Dim differences As vdb2.DbDiff = vdb2.vdbScriptEngine.GetDifferences(Me.txtMasterDB.Text, Me.txtCompareDB.Text, My.Settings.CodeGen_ProcessIndexes)

    '    If differences IsNot Nothing Then
    '        If differences.Tables.Count > 0 Then
    '            'there are some differences
    '            'Me.txtScript.Text = differences.Script(ScriptLanguageEnum.VbNet)
    '            'Me.txtScript.Text = differences.Script(ScriptEngine.CLangType(My.Settings.ScriptLang))
    '            Me.txtScript.Text = differences.Script(vdb2.vdbScriptEngine.CLangType(My.Settings.ScriptLang), My.Settings.CodeGen_ProcessIndexes)
    '            Me.View_Script()
    '        End If
    '    End If
    'End If


  End Sub


  Private Function CompareDatabasesv2(ByVal vdbFile1 As String, ByVal vdbFile2 As String, ByVal outputTreeView As TreeView, ByVal scriptChanges As Boolean) As Boolean
    'Returns true if structures are the same
    Dim differences As vdb2.DbDiff = vdb2.vdbScriptEngine.GetDifferences(vdbFile1, vdbFile2, My.Settings.CodeGen_ProcessIndexes)

    If differences IsNot Nothing Then
      If differences.Tables.Count > 0 Then
        'there are some differences

        'view differences
        differences.WriteDifferences(outputTreeView)

        'show differences
        Me.View_Differences()

        'Script chagnes
        If scriptChanges Then
          Me.txtScript.Text = ""
          Me.txtScript.Text = differences.Script(vdb2.vdbScriptEngine.CLangType(My.Settings.ScriptLang), My.Settings.CodeGen_ProcessIndexes)
          Me.View_Script()
        End If

        Return False 'false = Has Changes
      Else
        'no differences
        Return True
      End If
    Else
      'no differences
      Return True
    End If
  End Function

  Private Function CompareDatabasesv3(ByVal vdbFile1 As String, ByVal vdbFile2 As String, ByVal outputTreeView As TreeView, ByVal scriptChanges As Boolean) As Boolean
    'Returns true if structures are the same

    Dim differences As vdb3.DbDiff = vdb3.vdbScriptEngine.GetDifferences(vdbFile1, vdbFile2, My.Settings.CodeGen_ProcessIndexes)

    If differences IsNot Nothing Then
      If differences.Tables.Count > 0 Then

        differences.WriteDifferences(outputTreeView)

        'show differences
        Me.View_Differences()

        If scriptChanges Then
          Me.txtScript.Text = ""
          Me.txtScript.Text = differences.Script(vdb3.vdbScriptEngine.CLangType(My.Settings.ScriptLang), My.Settings.CodeGen_ProcessIndexes)
        End If
        Return False 'false = Has Changes
      Else
        Return True
      End If
    Else
      Return True
    End If
    'not done yet,
    Return False
  End Function


  Private Function CompareDatabases(ByVal vdbFile1 As String, ByVal vdbFile2 As String, ByVal outputTreeView As TreeView, ByVal scriptChanges As Boolean) As Boolean
    'Returns true if structures are the same

    'validate files exist
    If vdbFile1 = "" Or vdbFile2 = "" Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Please select the databases to compare", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      Return False
    End If

    If Not IO.File.Exists(vdbFile1) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Master Database not found!", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Return False
    End If

    If Not IO.File.Exists(vdbFile2) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Compare Database not found!", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Return False
    End If

    '19-Aug-07: writing to compare both versions in their own modules
    If G.IsVdb2File(vdbFile1) And G.IsVdb2File(vdbFile2) Then
      'v2
      Return Me.CompareDatabasesv2(vdbFile1, vdbFile2, outputTreeView, scriptChanges)
    ElseIf G.IsVdb3File(vdbFile1) And G.IsVdb3File(vdbFile2) Then
      'v3
      Return Me.CompareDatabasesv3(vdbFile1, vdbFile2, outputTreeView, scriptChanges)
    Else
      'cant cross compare (yet)
      DevExpress.XtraEditors.XtraMessageBox.Show("Sorry, unable to Cross compare v2 & v3 databases (yet)" & ControlChars.NewLine & "Please use the migration wizard to upgrade the v2 database to v3", "Cross Compare warning", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
      Return False
    End If

    'END 19-Aug-07

    'compare the database whilst loading schema.

    'Dim db1, db2 As VistaDB.VistaDBDatabase
    'Dim t1 As VistaDB.VistaDBTable = Nothing
    'Dim t2 As VistaDB.VistaDBTable = Nothing
    'Dim c As VistaDB.VistaDBColumn

    'Dim tables1() As String = Nothing
    'Dim tables2() As String = Nothing
    ''Dim indexes() As String = Nothing
    'Dim tableName As String ', sIndex As String
    'Dim diffTableNode, diffFieldNode As TreeNode
    'Dim indexInfo As VistaDB.RTagInfo
    ''Dim i As Integer

    'indexInfo.cpKeyExpr = ""


    ''clear schema trees
    'outputTreeView.Nodes.Clear()

    'db1 = New VistaDB.VistaDBDatabase(vdbFile1, False, True)
    'db2 = New VistaDB.VistaDBDatabase(vdbFile2, False, True)

    'If Not db1.Connected Then db1.Connect()
    'If Not db2.Connected Then db2.Connect()


    'db1.EnumTables(tables1)
    'db2.EnumTables(tables2)

    ''create basic script output objects
    ''With scriptOutPut
    ''    .Append("'// Auto Generated script by vDBCompare (Meikle Programming)")
    ''    .Append(vbCrLf)
    ''    .Append("'// Generated At: ")
    ''    .Append(Now.ToLongDateString)
    ''    .Append(" ")
    ''    .Append(Now.ToLongTimeString)
    ''    .Append(vbCrLf)
    ''    .Append("'// " & My.Resources.BuildDate & ": Scripting Engine still under construction, this will not be the entire script!!! (only missing tables are scripted for now.")
    ''    .Append(vbCrLf)
    ''    .Append(vbCrLf)
    ''    .Append("Dim db as VistaDB.VistaDBDatabase")
    ''    .Append(vbCrLf)
    ''    .Append("Dim t As VistaDB.VistaDBTable")
    ''    .Append(vbCrLf)
    ''    .Append(vbCrLf)
    ''    .Append("db = New VistaDB.VistaDBDatabase(""")
    ''    .Append(vdbFile2)
    ''    .Append(""", True, False)")
    ''    .Append(vbCrLf)
    ''    .Append(vbCrLf)
    ''    .Append(vbCrLf)
    ''    .Append(vbCrLf)

    ''End With

    'If Not tables1 Is Nothing Then
    '    For Each tableName In tables1

    '        'reset stuff
    '        diffTableNode = Nothing
    '        diffFieldNode = Nothing

    '        t1 = New VistaDB.VistaDBTable(db1, tableName)
    '        t1.Open()


    '        'does this table exist in the 2nd db
    '        If db2.IsTableExist(tableName) Then
    '            'Checking all fields exist
    '            t2 = New VistaDB.VistaDBTable(db2, tableName)
    '            t2.Open()

    '            For Each c In t1.Columns
    '                'check the field exists
    '                'assuming a vdb2 file
    '                'If G.ColumnExists(t2, c.Name) Then
    '                If vdb2.vdbScriptEngine.ColumnExists(t2, c.Name) Then
    '                    'check data type
    '                    If t1.ColumnType(c.Name) = t2.ColumnType(c.Name) Then
    '                        'check data length
    '                        If c.ColumnWidth <> t2.ColumnWidth(c.Name) Then
    '                            'sizes are different
    '                            If diffTableNode Is Nothing Then
    '                                diffTableNode = outputTreeView.Nodes.Add(tableName)
    '                                diffTableNode.ImageIndex = G.TICON_TABLE
    '                            End If

    '                            diffFieldNode = diffTableNode.Nodes.Add(c.Name)
    '                            diffFieldNode.ImageIndex = G.TICON_FIELD_ALTER
    '                            diffFieldNode.Nodes.Add("Type: " & c.VistaDBType.ToString).ImageIndex = G.TICON_FIELD_INFO
    '                            diffFieldNode.Nodes.Add("* Size: " & c.ColumnWidth.ToString & " (was " & t2.ColumnWidth(c.Name) & ")").ImageIndex = G.TICON_FIELD_INFO

    '                        End If
    '                    Else
    '                        'different data type
    '                        If diffTableNode Is Nothing Then
    '                            diffTableNode = outputTreeView.Nodes.Add(tableName)
    '                            diffTableNode.ImageIndex = G.TICON_TABLE
    '                        End If

    '                        diffFieldNode = diffTableNode.Nodes.Add(c.Name)
    '                        diffFieldNode.ImageIndex = G.TICON_FIELD_ALTER
    '                        diffFieldNode.Nodes.Add("* Type: " & c.VistaDBType.ToString & " (" & t2.ColumnType(c.Name).ToString & ")").ImageIndex = G.TICON_FIELD_INFO
    '                        diffFieldNode.Nodes.Add("Size: " & c.ColumnWidth.ToString).ImageIndex = G.TICON_FIELD_INFO
    '                    End If
    '                Else
    '                    'column does not exist
    '                    If diffTableNode Is Nothing Then
    '                        diffTableNode = outputTreeView.Nodes.Add(tableName)
    '                        diffTableNode.ImageIndex = G.TICON_TABLE
    '                    End If

    '                    diffFieldNode = diffTableNode.Nodes.Add("* " & c.Name)
    '                    diffFieldNode.ImageIndex = G.TICON_FIELD_ADD
    '                    diffFieldNode.Nodes.Add("Type: " & c.VistaDBType.ToString).ImageIndex = 2
    '                    diffFieldNode.Nodes.Add("Size: " & c.ColumnWidth.ToString).ImageIndex = 2
    '                End If
    '            Next


    '            'check for fields that may need to be dropped
    '            For Each c In t2.Columns

    '                'assuming vdb2 database
    '                'If Not G.ColumnExists(t1, c.Name) Then
    '                If Not vdb2.vdbScriptEngine.ColumnExists(t1, c.Name) Then
    '                    'drop field
    '                    If diffTableNode Is Nothing Then
    '                        diffTableNode = outputTreeView.Nodes.Add(tableName)
    '                        diffTableNode.ImageIndex = G.TICON_TABLE
    '                    End If
    '                    diffFieldNode = diffTableNode.Nodes.Add("DROP [" & c.Name & "]")
    '                    diffFieldNode.ImageIndex = G.TICON_FIELD_DROP
    '                End If

    '            Next


    '        Else
    '            'entire table missing
    '            diffTableNode = outputTreeView.Nodes.Add("* " & tableName)
    '            diffTableNode.ImageIndex = G.TICON_TABLE_ADD

    '            'With scriptOutPut
    '            '    .Append("'======================================================")
    '            '    .Append(vbCrLf)
    '            '    .Append("'// Create Table [" & tableName & "]")
    '            '    .Append(vbCrLf)
    '            '    .Append("'// Saftey checks...")
    '            '    .Append(vbCrLf)
    '            '    .Append("If Not db.IsTableExist(""")
    '            '    .Append(tableName)
    '            '    .Append(""") Then")

    '            '    .Append(vbCrLf)
    '            '    .Append("t = New VistaDBTable(db, """ & tableName & """)")
    '            '    .Append(vbCrLf)
    '            '    .Append("t.TableName = """ & tableName & """")
    '            '    .Append(vbCrLf)
    '            '    .Append("t.CreateNew()")
    '            '    .Append(vbCrLf)


    '            For Each c In t1.Columns
    '                diffFieldNode = diffTableNode.Nodes.Add(c.Name)
    '                diffFieldNode.ImageIndex = G.TICON_FIELD_ADD
    '                diffFieldNode.Nodes.Add("Type: " & c.VistaDBType.ToString).ImageIndex = G.TICON_FIELD_INFO
    '                diffFieldNode.Nodes.Add("Size: " & c.ColumnWidth.ToString).ImageIndex = G.TICON_FIELD_INFO

    '                'If c.PrimaryKey Then
    '                '    .Append("'// Primary Key Field")
    '                '    .Append(vbCrLf)
    '                'End If
    '                'If c.Identity Then
    '                '    .Append("'// Identity Column")
    '                '    .Append(vbCrLf)
    '                'End If

    '                '.Append("t.CreateColumn(""")
    '                '.Append(c.Name)
    '                '.Append(""", VistaDBType.")
    '                '.Append(c.VistaDBType.ToString)
    '                '.Append(", ")
    '                '.Append(c.ColumnWidth)
    '                '.Append(", ")
    '                '.Append(c.ColumnDecimals)
    '                '.Append(", ")
    '                '.Append(Not c.AllowNull)
    '                '.Append(", ")
    '                '.Append("False, False, False, False, False)")

    '                '.Append(vbCrLf)
    '                'Next 'field 
    '            Next

    '            '.Append(vbCrLf)
    '            '.Append("t.CreateFinalize()")
    '            '.Append(vbCrLf)
    '            '.Append(vbCrLf)

    '            '.Append("'Create Primary Key(s) & auto Identities...")
    '            '.Append(vbCrLf)
    '            '.Append("If Not t.Opened Then t.Open()")
    '            '.Append(vbCrLf)

    '            'auto id's first
    '            'For Each c In t1.Columns
    '            '    If c.Identity Then
    '            '        't.SetIdentity("OID", "1", 1)
    '            '        .Append("'// Auto Id")
    '            '        .Append(vbCrLf)
    '            '        .Append("t.SetIdentity(""")
    '            '        .Append(c.Name)
    '            '        .Append(""", ""1"", 1)")
    '            '        .Append(vbCrLf)
    '            '    End If
    '            'Next


    '            't1.EnumIndexes(indexes)

    '            'If Not indexes Is Nothing Then
    '            '    For Each sIndex In indexes

    '            '        If t1.GetIndex(sIndex, indexInfo.bActive, indexInfo.iOrderIndex, indexInfo.bUnique, indexInfo.bPrimary, indexInfo.bDesc, indexInfo.cpKeyExpr, indexInfo.bFts) Then
    '            '            .Append("'// Index: ")
    '            '            .Append(sIndex)
    '            '            .Append(vbCrLf)

    '            '            .Append("t.CreateIndex(""")
    '            '            .Append(sIndex)
    '            '            .Append(""", """)
    '            '            .Append(indexInfo.cpKeyExpr)
    '            '            If indexInfo.bPrimary Then
    '            '                .Append(""", VistaDB.VDBIndexOption.Primary, ")
    '            '            ElseIf indexInfo.bUnique Then
    '            '                .Append(""", VistaDB.VDBIndexOption.Unique, ")
    '            '            ElseIf indexInfo.bStandardIndex Then
    '            '                .Append(""", VistaDB.VDBIndexOption.Standard, ")
    '            '            End If

    '            '            .Append(indexInfo.bDesc.ToString)
    '            '            .Append(", ")
    '            '            .Append(indexInfo.ulLocaleId)
    '            '            .Append(")")
    '            '            .Append(vbCrLf)
    '            '        End If

    '            '    Next
    '            'End If

    '            ''// Clean up
    '            '.Append(vbCrLf)
    '            '.Append("'// Clean Up")
    '            '.Append(vbCrLf)
    '            '.Append("If t.Opened Then t.Close()")
    '            '.Append(vbCrLf)
    '            '.Append("t = Nothing")


    '            '.Append(vbCrLf)
    '            '.Append(vbCrLf)

    '            '.Append("End If")
    '            '.Append(vbCrLf)
    '            '.Append(vbCrLf)
    '            'End With


    '        End If

    '        'close tables as we go (if necessary)
    '        If t1 IsNot Nothing Then
    '            If t1.Opened Then t1.Close()
    '            t1 = Nothing
    '        End If

    '        If t2 IsNot Nothing Then
    '            If t2.Opened Then t2.Close()
    '            t2 = Nothing
    '        End If

    '    Next 'table
    'End If

    ''now check for tables that may need to be dropped
    'If Not tables2 Is Nothing Then
    '    For Each tableName In tables2
    '        'reset stuff
    '        diffTableNode = Nothing
    '        diffFieldNode = Nothing

    '        If Not G.IsItemInArray(tables1, tableName) Then
    '            'drop table
    '            diffTableNode = outputTreeView.Nodes.Add("DROP TABLE [" & tableName & "]")
    '            diffTableNode.ImageIndex = G.TICON_TABLE_DROP

    '            'script it
    '            'With scriptOutPut
    '            '    .Append(vbCrLf)
    '            '    .Append("'================================================")
    '            '    .Append(vbCrLf)
    '            '    .Append("'// Drop Table '" & tableName & "'")
    '            '    .Append(vbCrLf)
    '            '    .Append("db.DropTable(""")
    '            '    .Append(tableName)
    '            '    .Append(""")")
    '            '    .Append(vbCrLf)
    '            '    .Append(vbCrLf)
    '            'End With

    '        End If
    '    Next
    'End If


    ''clean up
    'If db1.Connected Then db1.Close()
    'If db2.Connected Then db2.Close()

    'db1.Dispose()
    'db2.Dispose()

    'db1 = Nothing
    'db2 = Nothing

    'If outputTreeView.GetNodeCount(False) = 0 Then
    '    'DevExpress.XtraEditors.XtraMessageBox.Show("The database structures are the same.", "Compare Databases", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Return True
    'Else

    '    ''set focus to tab
    '    'Me.TabControl1.SelectedIndex = 1

    '    ''auto load schema
    '    'PrintSchema(Me.txtMasterDB.Text, Me.tvDB1)
    '    'PrintSchema(Me.txtCompareDB.Text, Me.tvDB2)

    '    Return False
    'End If


  End Function

  Private Sub PrintSchema(ByVal fileName As String, ByVal outputTreeView As TreeView)

    If fileName = "" Then Return
    If outputTreeView Is Nothing Then Return

    outputTreeView.Nodes.Clear()

    Try
      Select Case IO.Path.GetExtension(fileName).ToLower
        Case ".vdb", ".vdb2"
          vdb2.vdbScriptEngine.OutPutSchema(fileName, outputTreeView)
        Case ".vdb3"
          vdb3.vdbScriptEngine.OutPutSchema(fileName, outputTreeView)
        Case Else
          'Trace.WriteLine(IO.Path.GetExtension(fileName))
          DevExpress.XtraEditors.XtraMessageBox.Show("UnRecognized file extension '" & IO.Path.GetExtension(fileName) & "', please use vdb or vdb3 files.", "Load Schema View", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
      End Select
    Catch ex As Exception
      DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error Loading Schema View", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    End Try


  End Sub


  Private Sub OnLoadSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSchema.Click, LoadSchemaToolStripMenuItem.Click

    'validate

    If txtMasterDB.Text = "" Then
      Me.tvDB1.Nodes.Clear()
    Else
      If IO.File.Exists(Me.txtMasterDB.Text) Then
        PrintSchema(Me.txtMasterDB.Text, Me.tvDB1)
        'Else
        'DevExpress.XtraEditors.XtraMessageBox.Show("Master Database not found!", "DB Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Exit Sub
      End If
    End If

    If txtCompareDB.Text = "" Then
      Me.tvDB2.Nodes.Clear()
    Else
      If IO.File.Exists(Me.txtCompareDB.Text) Then
        PrintSchema(Me.txtCompareDB.Text, Me.tvDB2)
        'Else
        'DevExpress.XtraEditors.XtraMessageBox.Show("Compare Database not found!", "DB Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Exit Sub
      End If
    End If

  End Sub


  Private Sub tvDB1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvDB1.DoubleClick
    If tvDB1.GetNodeCount(False) > 0 Then
      Dim blnExpand As Boolean = Not tvDB1.Nodes(0).IsExpanded
      For Each n As TreeNode In tvDB1.Nodes
        If blnExpand Then
          'n.ExpandAll()
          n.Expand()
        Else
          n.Collapse()
        End If
      Next
    End If


  End Sub

  Private Sub UpdateDBShortNames()

    If Me.txtMasterDB.Text = "" Then
      Me.lnkDB1ShortName.Text = ""
    Else
      lnkDB1ShortName.Text = IO.Path.GetFileName(txtMasterDB.Text)
    End If

    If Me.txtCompareDB.Text = "" Then
      Me.lnkDB2ShortName.Text = ""
    Else
      Me.lnkDB2ShortName.Text = IO.Path.GetFileName(Me.txtCompareDB.Text)
    End If

  End Sub

  Private Sub btnSwapDBs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSwapDBs.Click
    Dim s As String = Me.txtCompareDB.Text
    Me.txtCompareDB.Text = Me.txtMasterDB.Text
    Me.txtMasterDB.Text = s
    UpdateDBShortNames()
  End Sub


  Private Function ScriptDBToSql(ByVal dbPath As String) As String
    If dbPath = "" Then Return "Invalid Database File : "
    If Not IO.File.Exists(dbPath) Then Return "File: " & dbPath & " not found!"

    'Dim db As VistaDB.VistaDBDatabase

    'db = New VistaDB.VistaDBDatabase(dbPath, False, True)

    Return ""
  End Function


  Private Function ExportData(ByVal dbFile As String, ByVal exportTarget As String) As Boolean
    '15-Feb-07: moved to separate export screen
    Dim f As New frmExport
    f.VistaDatabase = dbFile
    f.OutputXmlFile = exportTarget
    f.Show()

    'If dbFile = "" Then Return False
    'If exportTarget = "" Then Return False

    'If Not IO.File.Exists(dbFile) Then Return False

    'Dim db As VistaDB.VistaDBDatabase = Nothing
    'Dim tables() As String = Nothing

    'Try

    '    db = New VistaDB.VistaDBDatabase(dbFile, False, True)

    '    db.Connect()
    '    db.EnumTables(tables)

    '    For Each table As String In tables
    '        db.AddToExportList(table)
    '    Next

    '    'now export the data
    '    ExportData = db.ExportData(exportTarget, False)

    'Catch ex As Exception
    '    ExportData = False
    '    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
    'Finally

    '    If Not db Is Nothing Then
    '        If db.Connected Then db.Close()
    '        db.Dispose()
    '        db = Nothing
    '    End If
    'End Try

  End Function



  Private Sub LaunchVistaDBBuilder(ByVal dbFile As String)
    If dbFile Is Nothing Then Exit Sub
    If dbFile = "" Then Exit Sub

    If IO.File.Exists(dbFile) Then
      G.StartProcess(dbFile)
    End If

  End Sub


  Private Sub CheckForUpdates()
    DevExpress.XtraEditors.XtraMessageBox.Show("Feature not done, visit the project home page for updates.", "Feature not done", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub



  Private Sub miScriptDB1_ToSql_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.txtScript.Text = "Scripting DB '" & Me.txtMasterDB.Text & "' to Sql..."
    'Me.TabControl1.SelectedTab = Me.tpScript
    Me.View_Script()
    Me.txtScript.Text = ScriptDBToSql(Me.txtMasterDB.Text)
  End Sub

#Region "  Menu ToolStrip  "


  Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
    '3-feb-07: have to do this as if just call close = err in drawing
    Me.Hide()
    Me.Close()
  End Sub

  Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
    With Me.dlgSave
      .Title = "Save Export As"
      .Filter = "XML Data File (*.xml)|*.xml"
      .DefaultExt = "xml"
      If Not String.IsNullOrEmpty(Me.txtMasterDB.Text) Then
        .FileName = IO.Path.GetFileNameWithoutExtension(Me.txtMasterDB.Text) & "_Schema.xml"
      End If
      If .ShowDialog = Windows.Forms.DialogResult.OK Then
        Me.ExportData(Me.txtMasterDB.Text, .FileName)
      End If
    End With
  End Sub

  Private Sub ToAccessmdbToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToAccessmdbToolStripMenuItem.Click

    If Me.txtMasterDB.Text = "" Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Please select a Vista Database to convert", "To Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Return
    End If

    Dim f As frmConvertToAccess
    'Dim dbGen As AccessDBGen

    'select the access database.
    With dlgSave
      .Filter = "Access Databases (*.mdb)|*.mdb"
      .DefaultExt = "mdb"
      .Title = "Save to Access"

      If .ShowDialog = Windows.Forms.DialogResult.OK Then
        'go
        f = New frmConvertToAccess
        f.Show()

        f.txtVistaDatabase.Text = Me.txtMasterDB.Text
        f.txtAccessDatabase.Text = .FileName

      End If
    End With
  End Sub

  Private Sub ScriptVBNETToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptVBNETToolStripMenuItem.Click
    'a bit of validation first

    If Me.txtMasterDB.Text = "" Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Please select a databases to Script", "Script to VB.NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    If Not IO.File.Exists(Me.txtMasterDB.Text) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Master Database not found!", "Script to VB.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    'output script

    '19-Aug-07: quick version check
    If G.IsVdb2File(Me.txtMasterDB.Text) Then
      Me.txtScript.Text = vdb2.vdbScriptEngine.ScriptToVB(Me.txtMasterDB.Text)
    ElseIf G.IsVdb3File(Me.txtMasterDB.Text) Then
      Me.txtScript.Text = vdb3.vdbScriptEngine.ScriptToVB(Me.txtMasterDB.Text)
    Else
      DevExpress.XtraEditors.XtraMessageBox.Show("Hmm, unable to determine what version this database is, please check extension", "Please check file extention", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
      Return
    End If


    'set focus to tab
    'Me.TabControl1.SelectedIndex = 2
    Me.View_Script()

    'auto load schema
    PrintSchema(Me.txtMasterDB.Text, Me.tvDB1)
    'Me.tvDB2.Nodes.Clear()
  End Sub

  Private Sub ExportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem1.Click
    With Me.dlgSave
      .Title = "Save Export As"
      .Filter = "XML Data File (*.xml)|*.xml"
      .DefaultExt = "xml"
      If .ShowDialog = Windows.Forms.DialogResult.OK Then
        Me.ExportData(Me.txtCompareDB.Text, .FileName)
      End If
    End With
  End Sub

  Private Sub ToAccessmdbToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToAccessmdbToolStripMenuItem1.Click
    If Me.txtCompareDB.Text = "" Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Please select a Vista Database to convert", "To Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Return
    End If

    Dim f As frmConvertToAccess


    'Dim dbGen As AccessDBGen

    'select the access database.
    With dlgSave
      .Filter = "Access Databases (*.mdb)|*.mdb"
      .DefaultExt = "mdb"
      .Title = "Save to Access"

      If .ShowDialog = Windows.Forms.DialogResult.OK Then
        'go
        f = New frmConvertToAccess
        f.Show()

        f.txtVistaDatabase.Text = Me.txtCompareDB.Text
        f.txtAccessDatabase.Text = .FileName

      End If
    End With
  End Sub

  Private Sub ScriptVBNETToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptVBNETToolStripMenuItem1.Click
    'a bit of validation first

    If Me.txtCompareDB.Text = "" Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Please select a databases to Script", "Script to VB.NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    If Not IO.File.Exists(Me.txtCompareDB.Text) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Compare Database not found!", "Script to VB.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    'output script
    If G.IsVdb2File(Me.txtCompareDB.Text) Then
      Me.txtScript.Text = vdb2.vdbScriptEngine.ScriptToVB(Me.txtCompareDB.Text)
    ElseIf G.IsVdb3File(Me.txtCompareDB.Text) Then
      Me.txtScript.Text = vdb3.vdbScriptEngine.ScriptToVB(Me.txtCompareDB.Text)
    Else
      DevExpress.XtraEditors.XtraMessageBox.Show("Hmm, unable to determine what version this database is, please check extensionon", "Please check file extention", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
      Return
    End If


    'set focus to tab
    'Me.TabControl1.SelectedIndex = 2
    Me.View_Script()

    'auto load schema
    PrintSchema(Me.txtCompareDB.Text, Me.tvDB2)
    'Me.tvDB1.Nodes.Clear()
  End Sub


  Private Sub ConvertToAccessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertToAccessToolStripMenuItem.Click
    Dim f As frmConvertToAccess
    f = New frmConvertToAccess
    f.Show()
    f = Nothing
  End Sub


  Private Sub CheckForUpdatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
    Me.CheckForUpdates()
  End Sub

  Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
    Dim f As New AboutForm
    f.ShowDialog()
    f.Dispose()
    f = Nothing
  End Sub

#End Region

  Private Sub VistaDBDataBuilderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VistaDBDataBuilderToolStripMenuItem.Click
    If G.LaunchVistaDBBuilder() = False Then
      VistaDBDataBuilderToolStripMenuItem.Enabled = False
    End If
  End Sub


  Private Sub CloneDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloneDatabaseToolStripMenuItem.Click
    'Dim f As New frmCloneVdb
    'f.Show()
    DevExpress.XtraEditors.XtraMessageBox.Show("Sorry, this feature is undergoing an upgrade & should be ready in the next update", "Upgrading Feature", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
  End Sub

  Private Sub BuyNowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ShowBuyNowScreen()
  End Sub

  Private Sub ShowBuyNowScreen()
    Dim f As New frmBuyNow
    If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
      'they clicked buy now.
      'log this some how?
    End If
    f.Dispose()
    f = Nothing
  End Sub

  Private Sub OnlineManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnlineManualToolStripMenuItem.Click
    G.StartProcess(ONLINE_MANUAL_URL)
  End Sub




#Region "  Fudging manual tab control  "

  Private Sub View_Schema()
    Me.xTabMain.SelectedTabPage = Me.xtpSchema
  End Sub

  Private Sub View_Differences()
    Me.xTabMain.SelectedTabPage = Me.xtpDifferences
  End Sub

  Private Sub View_Script()

    Me.txtScript.Visible = True
    Me.xTabMain.SelectedTabPage = Me.xtpScript
  End Sub

#End Region

  Private Sub Opf3ObjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opf3ObjectsToolStripMenuItem.Click
    G.StartProcess("http://www.meikleprogramming.com/software/vdbcompare/manual/opf3.htm")
  End Sub

  Private Sub XPOObjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XPOObjectsToolStripMenuItem.Click
    G.StartProcess("http://www.meikleprogramming.com/software/vdbcompare/manual/xpo.htm")
  End Sub


  Private Sub lnkDB1ShortName_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDB1ShortName.LinkClicked
    LaunchVistaDBBuilder(Me.txtMasterDB.Text)
  End Sub

  Private Sub lnkDB2ShortName_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDB2ShortName.LinkClicked
    LaunchVistaDBBuilder(Me.txtCompareDB.Text)
  End Sub

  Private Sub PackDatabase1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackDatabase1ToolStripMenuItem.Click
    If G.PackDatabase(Me.txtMasterDB.Text) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Database Compacted Successfully", "Pack Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub

  Private Sub PackDatabase2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackDatabase2ToolStripMenuItem.Click
    If G.PackDatabase(Me.txtCompareDB.Text) Then
      DevExpress.XtraEditors.XtraMessageBox.Show("Database Compacted Successfully", "Pack Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub

  Private Sub PackDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackDatabaseToolStripMenuItem.Click
    If Me.dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
      Try
        If G.PackDatabase(Me.dlgOpen.FileName) Then
          DevExpress.XtraEditors.XtraMessageBox.Show("Database Compacted Successfully", "Pack Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
      Catch ex As Exception
        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error Packing Database", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
      End Try
    End If
  End Sub

  Private Sub txtMasterDB_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtMasterDB.ButtonClick
    If Me.dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
      Me.txtMasterDB.Text = dlgOpen.FileName
      UpdateDBShortNames()
    End If
  End Sub

  Private Sub txtCompareDB_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCompareDB.ButtonClick
    If Me.dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
      Me.txtCompareDB.Text = dlgOpen.FileName
      UpdateDBShortNames()
    End If
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    Me.ShowBuyNowScreen()
  End Sub

  Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
    Dim fo As New frmOptions
    If fo.ShowDialog = Windows.Forms.DialogResult.OK Then
      'what needs updating?

    End If
    'fo.Dispose '??
    fo = Nothing
  End Sub

#Region "  Skin Stuff  "


  Private Sub SetSkin(ByVal skinName As String)
    Me.DefaultLookAndFeel1.LookAndFeel.SkinName = skinName

    If skinName = "" Then skinName = miSkin1.Text

    My.Settings.Skin = skinName
    My.Settings.Save()

    'now set the checked menu items
    Me.miSkin1.Checked = False
    Me.miSkin2.Checked = False
    Me.miSkin3.Checked = False
    Me.miSkin4.Checked = False
    Me.miSkin5.Checked = False
    Me.miSkin6.Checked = False
    Me.miSkin7.Checked = False
    Me.miSkin8.Checked = False
    Me.miSkin9.Checked = False
    Me.miSkin10.Checked = False

    'now set it
    Select Case skinName
      Case miSkin1.Text
        miSkin1.Checked = True
      Case miSkin2.Text
        miSkin2.Checked = True
      Case miSkin3.Text
        miSkin3.Checked = True
      Case miSkin4.Text
        miSkin4.Checked = True
      Case miSkin5.Text
        miSkin5.Checked = True
      Case miSkin6.Text
        miSkin6.Checked = True
      Case miSkin7.Text
        miSkin7.Checked = True
      Case miSkin8.Text
        miSkin8.Checked = True
      Case miSkin9.Text
        miSkin9.Checked = True
      Case miSkin10.Text
        miSkin10.Checked = True
      Case Else
        'default ?
        Me.miSkin1.Checked = True
    End Select


  End Sub

  Private Sub On_miSkin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
  miSkin1.Click, miSkin2.Click, miSkin3.Click, miSkin4.Click, miSkin5.Click, miSkin6.Click, miSkin7.Click, _
  miSkin8.Click, miSkin9.Click, miSkin10.Click

    Me.SetSkin(CType(sender, System.Windows.Forms.ToolStripMenuItem).Text)
  End Sub

#End Region

  Private Sub DataBuilder3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataBuilder3ToolStripMenuItem.Click
    If G.LaunchVistaDBBuilder3 = False Then
      DataBuilder3ToolStripMenuItem.Enabled = False
    End If
  End Sub

  Private Sub ReportFaultIssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFaultIssueToolStripMenuItem.Click
    G.StartProcess(My.Resources.ProjectUrl_Issues)
  End Sub

  Private Sub VisitProjectHomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisitProjectHomeToolStripMenuItem.Click
    G.StartProcess(My.Resources.ProjectUrl)
  End Sub

End Class