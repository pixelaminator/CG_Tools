Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq

Public Class Globals
    'Those properties will stay in lifetime of the CorelDRAW app
    Public Shared Property JsonObj As JObject
    Public Shared Property DestFolder As New List(Of String) From {"Digital A3", "Digital Banner"}
    Public Shared Property TypeFolder As New List(Of String) From {"Non Permanent", "Permanent"}
End Class
