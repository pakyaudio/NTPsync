Imports System.IO
Imports System.Net

Public Class Form1
    Dim DateTimeNow As DateTime
    Dim Args(1) As String

    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            File.Copy(Application.StartupPath & "\NTPsync.exe", Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\NTPsync.exe", True)
        Catch ex As Exception

        End Try


        NotifyIcon1.Icon = My.Resources.clock_time_hour_watch_reload_refresh_512
        Do
            If CheckForInternetConnection() = True Then
                Try
                    DateTimeNow = Daytime.GetTime
                    If DateTimeNow.ToShortDateString <> DateString Then
                        Daytime.SetWindowsClock(Daytime.GetTime)
                    End If
                    Exit Do
                Catch ex As Exception

                End Try
            End If
        Loop
        Me.Close()
    End Sub
End Class
