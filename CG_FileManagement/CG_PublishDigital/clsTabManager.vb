Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class ClsTabManager

    Private Structure TabPageData
        Friend Index As Integer
        Friend Parent As TabControl
        Friend Page As TabPage

        Friend Sub New(index__1 As Integer, parent__2 As TabControl, page__3 As TabPage)
            Index = index__1
            Parent = parent__2
            Page = page__3
        End Sub

        Friend Shared Function GetKey(tabCtrl As TabControl, tabPage As TabPage) As String
            Dim key As String = ""
            If tabCtrl IsNot Nothing AndAlso tabPage IsNot Nothing Then
                key = [String].Format("{0}:{1}", tabCtrl.Name, tabPage.Name)
            End If
            Return key
        End Function

        Friend Shared Function GetKey(tabCtrl As TabControl, tabName As String) As String
            Dim key As String = ""

            If tabCtrl IsNot Nothing Then
                key = [String].Format("{0}:{1}", tabCtrl.Name, tabName)
            End If
            Return key
        End Function
    End Structure

    Private hiddenPages As New Dictionary(Of String, TabPageData)()


    Public Sub SetVisible(page As TabPage, parent As TabControl)
        If parent IsNot Nothing AndAlso Not parent.IsDisposed Then
            Dim tpinfo As TabPageData
            Dim key As String = TabPageData.GetKey(parent, page)

            If hiddenPages.ContainsKey(key) Then
                tpinfo = hiddenPages(key)

                If tpinfo.Index < parent.TabPages.Count Then
                    parent.TabPages.Insert(tpinfo.Index, tpinfo.Page)
                Else
                    ' add the page in the same position it had
                    parent.TabPages.Add(tpinfo.Page)
                End If

                hiddenPages.Remove(key)
            End If
        End If
    End Sub

    Public Sub SetVisible(PageName As String, parent As TabControl)
        If parent IsNot Nothing AndAlso Not parent.IsDisposed Then
            Dim tpinfo As TabPageData
            Dim key As String = TabPageData.GetKey(parent, PageName)

            If hiddenPages.ContainsKey(key) Then
                tpinfo = hiddenPages(key)

                If tpinfo.Index < parent.TabPages.Count Then
                    parent.TabPages.Insert(tpinfo.Index, tpinfo.Page)
                Else
                    ' add the page in the same position it had
                    parent.TabPages.Add(tpinfo.Page)
                End If

                hiddenPages.Remove(key)
            End If
        End If
    End Sub

    Public Sub SetInvisible(page As TabPage)
        If IsVisible(page) Then
            Dim tabCtrl As TabControl = DirectCast(page.Parent, TabControl)
            Dim tpinfo As TabPageData
            tpinfo = New TabPageData(tabCtrl.TabPages.IndexOf(page), tabCtrl, page)
            tabCtrl.TabPages.Remove(page)
            hiddenPages.Add(TabPageData.GetKey(tabCtrl, page), tpinfo)
        End If
    End Sub

    Public Function IsVisible(page As TabPage) As Boolean
        Return page IsNot Nothing AndAlso page.Parent IsNot Nothing
        ' when Parent is null the tab page does not belong to any container
    End Function

    Public Sub CleanUpHiddenPage(page As TabPage)
        For Each info As TabPageData In hiddenPages.Values
            If info.Parent IsNot Nothing AndAlso info.Parent.Equals(DirectCast(page.Parent, TabControl)) Then
                info.Page.Dispose()
            End If
        Next
    End Sub

    Public Sub CleanUpAllHiddenPages()
        'For Each info As TabPageData In hiddenPages.Values
        '    info.Page.Dispose()
        'Next
        hiddenPages.Clear()
    End Sub

End Class