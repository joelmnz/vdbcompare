﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3634
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("vDBCompare.vdb3.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &apos;// update helper class for vdb3
        '''&apos;------------------------------------------------------------------
        '''Imports VistaDB
        '''Imports VistaDB.DDA
        '''Imports VistaDB.Provider
        '''
        '''Public Class vDb3UpdateHelper
        '''  &apos;vistadb 3 code functions
        '''  Public Shared Function CreateDatabase(ByVal fileName As String) As IVistaDBDatabase
        '''    Dim DDAObj As IVistaDBDDA = VistaDBEngine.Connections.OpenDDA
        '''    Dim db As IVistaDBDatabase = DDAObj.CreateDatabase(fileName, True, Nothing, 2, 0, False)
        '''    Return db
        '''  End Function
        '''
        '''   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Code_vbd3UpdateHelper_VB() As String
            Get
                Return ResourceManager.GetString("Code_vbd3UpdateHelper_VB", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to //// update helper class for vdb3
        '''//------------------------------------------------------------------
        '''using VistaDB;
        '''using VistaDB.DDA;
        '''using VistaDB.Provider;
        '''
        '''public class vDb3UpdateHelper
        '''{
        '''    //vistadb 3 code functions
        '''    public static IVistaDBDatabase CreateDatabase(string fileName)
        '''    {
        '''        IVistaDBDDA DDAObj = VistaDBEngine.Connections.OpenDDA;
        '''        IVistaDBDatabase db = DDAObj.CreateDatabase(fileName, true, null, 2, 0, false);
        '''        return db;
        '''    }
        '''    
        '''    public stati [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Code_vdb3UpdateHelper_CS() As String
            Get
                Return ResourceManager.GetString("Code_vdb3UpdateHelper_CS", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
