﻿Public Class ProgressWindow
    Private MainUI As DockerUI

    Private _ProgressBarTotal As Integer
    Private _ProgressBarPage As Integer
    Private _ProgressMessageStatus As String

    Public Property ProgressBarTotal As Integer
        Get
            Return _ProgressBarTotal
        End Get
        Set(value As Integer)
            _ProgressBarTotal = value
            overallprogress.Value = ProgressBarTotal
        End Set
    End Property

    Public Property ProgressBarPage As Integer
        Get
            Return _ProgressBarPage
        End Get
        Set(value As Integer)
            _ProgressBarPage = value
            pageprogress.Value = ProgressBarPage
        End Set
    End Property

    Public Property ProgressMessageStatus As String
        Get
            Return _ProgressMessageStatus
        End Get
        Set(value As String)
            _ProgressMessageStatus = value
            message.Content = ProgressMessageStatus
        End Set
    End Property

    Private Sub bt_cancel_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_cancel.Click
    End Sub
End Class
