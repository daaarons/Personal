Imports System
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports clsImg = GameEngine.v2.clsImg

Public Class frmGame1
#Region "Main Declaration"
    Public mainForm As Object = Me
    Dim imgDir = "C:\Users\Public\ImgDir"
    Private animatedImage As New Bitmap(Image.FromFile(imgDir & "\Person\iron-walk.gif"))
    Private currentlyAnimating As Boolean = False
    'Public LOPerson As New List(Of struPerson)()
    Public CountTO As Integer = 10

    Public MoveModeTF As Boolean = False
    Public SizeModeTF As Boolean = False
    Public WxHModeTF As Boolean = False

    Public WithEvents lblInfo As New Label With {.Parent = Me, .Name = "lblInfo", _
    .Text = "lblInfo", .AutoSize = True, _
    .Font = New System.Drawing.Font("Arial", 12, FontStyle.Bold), _
    .Location = New Point(.Width * 2, 0), _
    .BackColor = Color.Black, _
    .ForeColor = Color.Red}

    Dim WithEvents txtInfo As New TextBox With {.Multiline = True, _
                                               .Font = New System.Drawing.Font("Courier New", 10, FontStyle.Bold), _
                                               .BackColor = Color.White, _
                                               .ForeColor = Color.Blue, _
                                               .Width = 500, .Height = 100, _
                                                .WordWrap = False, _
                                                .ScrollBars = ScrollBars.Both} '.Parent = Me,


    Dim WithEvents timInvalidate As New Timer
#End Region

    Private Sub frmGame1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Size = New Size(1077, 640)
        'MinimumSize = New Size(804, 588)
        WindowState = FormWindowState.Normal
        CenterToScreen()
        KeyPreview = True
        DoubleBuffered = True
        AllowDrop = True
        ControlBox = True
        MinimizeBox = False
        MaximizeBox = True
        Text = ""
        FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Top = 0

        BackgroundImage = Image.FromFile("C:\Users\Public\ImgDir\Terrain\image 82.jpg")
        BackgroundImageLayout = ImageLayout.Stretch
        ContextMenuStrip = cmsMain

        picMoveMode.Image = My.Resources.Red_Light_ON
        picSizeMode.Image = My.Resources.Red_Light_ON
        picWxH.Image = My.Resources.Red_Light_ON
        panControls.Hide()

        Create_New()
        Start()

        timInvalidate.Start()
        timCoords.Start()
        txtInfo.Left = lblInfo.Right + 50

        For i = 0 To LOImg.Count - 1
            cmbElement.Items.Add(i)
            'frmControls.cmbElement.Items.Add(i)
        Next

        'activeImgIdx = Get_LOimg_ID(Get_LOimg_ID("Heli Main"))
        Dim b = ";;;;;;30" & "; Size: " & Size.ToString & Environment.NewLine _
        & "Counter" & ";" _
        & "Name-ID ;" _
        & "Left ;" _
        & "Time" & Environment.NewLine

        'My.Computer.FileSystem.WriteAllText("c:\users\donovan\desktop\ss.csv", b, False)
        txtInfo.Text = txtInfo.Text & b
        _sw.Start()

    End Sub


    Private Sub timInvalidate_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timInvalidate.Tick
        Invalidate()

        If frmCrossHairs.Visible Then
            'frmCrossHairs.Location = New Point(PointToClient(New Point(Cursor.Position.X + Width / 2, Cursor.Position.Y - Height - 50)))
        End If
        With LOImg(mainForm.activeImgIdx)
            Dim s As String = ""
            If .Name = "Flash" And .Left <= 0 Then StopWatch_Start() : s = "SW Started"
            If .Name = "Flash" And .Left >= Right Then StopWatch_Stop() : s = "SW Stopped"
            If .Name = "Flash" And Between(.Left, 0, Right) Then 'And .Left Mod 5 = 0 Then
                Dim a As clsImg = LOImg(Get_LOimg_ID("Flash"))
                Dim b As String = ""
                Dim elapsed As Long = Nothing
                elapsed = _sw.ElapsedTicks

                With a
                    b = runCounter & ";" _
                    & .Name & "-" & .ID & ";" _
                    & .Left & ";" _
                    & (elapsed / Stopwatch.Frequency) * 1000 & ";" _
                    & Environment.NewLine
                End With

                ' My.Computer.FileSystem.WriteAllText("c:\users\donovan\desktop\ss.csv", b, True)
                txtInfo.Text = txtInfo.Text & b

            End If

            If Not frmControls.Visible Then

                mainForm.lblInfo.Text = .Name & "-" & .ID & vbCrLf _
              & .Left & "x" & .Top & vbCrLf _
              & Top & "," & Right & vbCrLf _
              & Width & "," & Height & vbCrLf _
              & .Size.ToString & vbCrLf _
              & "frm"

                Dim frame As Integer = 0
                If Path.GetExtension(.gifBGI) = ".gif" Then frame = .Get_Max_Index()

                lblSize.Text = .Size.ToString()
                lblLocation.Text = .Location.ToString
                lblSR.Text = .gifSR
                lblName.Text = .Name & vbCrLf _
                & "Frames: " & frame
            End If
            If SizeModeTF Then
                ' .gifSR = nudSR.Value + (tbSR.Value / 10)
                'Label6.Text = tbSR.Value / 10
                '.Set_Size()
            End If


        End With

    End Sub

    Private Sub frmGame1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If mainForm.activeImgIdx < 0 Then Exit Sub
        Dim A = LOImg(mainForm.activeImgIdx)

        If MoveModeTF Then
            Select Case e.KeyCode
                Case Keys.Left
                    LOImg(mainForm.activeImgIdx).Left -= 1
                Case Keys.Right
                    LOImg(mainForm.activeImgIdx).Left += 1
                Case Keys.Up
                    LOImg(mainForm.activeImgIdx).Top -= 1
                Case Keys.Down
                    LOImg(mainForm.activeImgIdx).Top += 1
            End Select
        End If
        If SizeModeTF Then
            Select Case e.KeyCode
                Case Keys.Left
                Case Keys.Right
                    A.Left += 5
                    A.Top -= 15
            End Select
        End If
        If WxHModeTF Then
            A.setSizeManuallyTF = True
            Select Case e.KeyCode
                Case Keys.Left
                    A.Width -= 1
                Case Keys.Right
                    A.Width += 1
                Case Keys.Up
                    A.Height += 1
                Case Keys.Down
                    A.Height -= 1
            End Select
            A.Set_Size(A.Width, A.Height)
        End If

        If e.Control And e.KeyCode = Keys.M Then
            'MsgBox("ppp")
            A.Set_Location(PointToClient((New Point(Cursor.Position.X, Cursor.Position.Y))))
        End If
        Select Case e.KeyCode
            Case Keys.F
                SHOW_EditForm()

        End Select

    End Sub

    Private Sub frmGame1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Computer.FileSystem.WriteAllText("c:\users\donovan\desktop\ss.csv", txtInfo.Text, False)
    End Sub

    Private Sub SHOW_EditForm()
        With frmControls
            .mainForm = Me
            .frm = Me
            .TopMost = True
            .Show()
            lblInfo.Hide()

            If WindowState = FormWindowState.Maximized Then
                .Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - .Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - .Height) / 2)
            Else
                .Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - .Width) / 2, ClientSize.Height - .Height - 8)
            End If

        End With
    End Sub

    Public Sub SAVE_Elements_Properties()
        Dim FN As String = "C:\Users\Public\Games New\GamesNew.csv"
        Dim B As String = "Index;Name;In Game Name;Flip;Rotate;CA;Cat;SMLR;SMUD;SMD;SLR;SUD;gifSR;TI;L;T;W;H;RTW;RTH;gifBGI;RW2W;RH2H" & Environment.NewLine
        My.Computer.FileSystem.WriteAllText(FN, B, False)

        For i = 0 To LOImg.Count - 1
            With LOImg(i)
                .RatioLeftToW = .Left / Width
                .RatioTopToH = .Top / Height

                Dim A As String = i & "; " _
                & Path.GetFileNameWithoutExtension(.gifBGI) & "; " _
                & .Name & "; " _
                & .flipMe & "; " _
                & .rotatemeTF & "; " _
                & .continuousAnimation & "; " _
                & .Category & "; " _
                & .seqMoveLR & "; " _
                & .seqMoveUD & "; " _
                & .seqMoveDiagonal & "; " _
                & .SpeedLR & "; " _
                & .SpeedUD & "; " _
                & .gifSR & "; " _
                & .TI & "; " _
                & .Left & "; " _
                & .Top & "; " _
                & .Width & "; " _
                & .Height & "; " _
                & .RatioLeftToW & "; " _
                & .RatioTopToH & "; " _
                & .RatiotSizeWidthToW & "; " _
                & .RatiotSizeHeightToH & "; " _
                & .gifBGI & Environment.NewLine
                My.Computer.FileSystem.WriteAllText(FN, A, True)
            End With
        Next
    End Sub


    '## Drag & Drop to Form ##
#Region "   Drag & Drop cmbFiles "
    Private Sub Frm_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim theFiles() As String = CType(e.Data.GetData("FileDrop", True), String())
        Dim fa = System.IO.File.GetAttributes(theFiles(0))

        If fa = 16 Or fa = 17 Or fa = 48 Then 'folder
            For Each file As String In IO.Directory.GetFiles(thefiles(0), "*.*")
                'Pad_With_Zeros(file)
            Next
            'MsgBox(intCounter)
        ElseIf fa = 32 Then 'file

            For Each theFile As String In theFiles
                Create_New(idxImg, theFile)
            Next
        End If
    End Sub

    Private Sub Frm_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
#End Region


    '## Track Mouse Simple ##
#Region "	Track Mouse Simple "
    Dim mouseX, mouseY As Integer
    Dim WithEvents timCoords As New Timer
    Dim WithEvents lblDisplay As New Label With {.Parent = Me, .Location = New Point(10, 10), .Visible = True, .BackColor = Color.Black, .ForeColor = Color.Yellow, .AutoSize = True, .Font = New System.Drawing.Font("Courier New", 12, FontStyle.Bold)}

    Private Sub timCoords_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timCoords.Tick
        lblDisplay.Left = lblInfo.Right + 300
        'this is easier and gives the relative pos of mouse to form
        If Visible Then lblDisplay.Text = PointToClient(Cursor.Position).ToString
        If PointToClient(Cursor.Position).X >= Width - 100 Then lblInfo.Left = 0
    End Sub
#End Region

    '## STOP Watch ##
#Region "Stop Watch"
    Private _sw As New Stopwatch
    Dim runCounter As Integer = 0
    Private Sub StopWatch_Start()
        Dim a As clsImg = LOImg(activeImgIdx)
        Dim b As String
        Dim elapsed As Long
        elapsed = _sw.ElapsedTicks

        With a
            b = runCounter & ";" _
            & .Name & "-" & .ID & ";" _
            & .Left & ";" _
            & (elapsed / Stopwatch.Frequency) * 1000 & ";" & "start" & Environment.NewLine & Environment.NewLine
        End With
        runCounter += 1
        _sw.Start()

        'My.Computer.FileSystem.WriteAllText("c:\users\donovan\desktop\ss.csv", b, True)
        txtInfo.Text = txtInfo.Text & b

        'End If

    End Sub

    Private Sub StopWatch_Stop()
        Dim a As clsImg = LOImg(activeImgIdx)
        Dim b As String
        Dim elapsed As Long
        elapsed = _sw.ElapsedTicks

        With a
            b = runCounter & ";" _
            & .Name & "-" & .ID & ";" _
            & .Left.ToString & ";" _
           & (elapsed / Stopwatch.Frequency) * 1000 & ";" & "end" & Environment.NewLine
        End With

        'runCounter += 1
        _sw.Stop()
        'My.Computer.FileSystem.WriteAllText("c:\users\donovan\desktop\ss.csv", b, True)
        txtInfo.Text = txtInfo.Text & b

        _sw.Reset()
    End Sub
#End Region

    '## Frame Rate Counter
#Region "Frame Rate Counter"
    Private framerateFont As Font = _
        New Font("Verdana", 12, FontStyle.Regular, GraphicsUnit.Pixel)


    Private Sub FrameRate_Counter_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim currFrameRate = 0
        e.Graphics.DrawString(currFrameRate & " F/sec", framerateFont, Brushes.Black, 800, 0)
    End Sub

#End Region

    '## Simulated Drag & Drop Form Objects ##
#Region "   DRAGGABLE OBJECTS       "
    Dim MoveMe As Boolean
    Dim DraggableObj_X, DraggableObj_Y As Integer

    Private Sub AddHandlers()
        Dim A = panControls

        AddHandler A.MouseDown, AddressOf Obj_MouseDown
        AddHandler A.MouseMove, AddressOf obj_MouseMove
        AddHandler A.MouseUp, AddressOf obj_MouseUp
    End Sub

    Private Sub Obj_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        MoveMe = True
        DraggableObj_X = e.X
        DraggableObj_Y = e.Y
    End Sub

    Private Sub obj_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If MoveMe Then
            sender.Left = PointToClient(Cursor.Position).X - DraggableObj_X
            sender.Top = PointToClient(Cursor.Position).Y - DraggableObj_Y
        End If
    End Sub

    Private Sub obj_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        MoveMe = False
    End Sub
#End Region


    '## Class clsImg MAIN SECTION ##
#Region "clsImg Main Section"
#Region "clsImg Main Declaration"
    Public LOImg As New List(Of clsImg)()
    Public CountToImg As Integer = 0
    Public idxImg As Integer = 0
    Public maxImg As Integer = 0
    Public arrImg() As clsImg
    Public activeImgIdx As Integer = -1
    Public CountHowMany As Integer = 0
    Public iAngle As Integer = 0
    Dim _RecNO As Integer = -1
#End Region

    Private Sub Create_New()
        Dim MainImageDir As String = "C:\Users\Public\ImgDir"
        Dim FN As String = ""
        Dim j As Integer = 0
        Dim Nme As String = ""
        Dim CountTO As Integer = 1

        Dim Flip As Boolean = False
        Dim rotateTF As Boolean = False
        Dim CA As Boolean = True
        Dim Disposed As Boolean = False
        Dim ShowidTF As Boolean = False
        Dim DrawRectTF As Boolean = False

        Dim RE As Boolean = False  ' RandomEntry (Random Top)
        Dim minRET As Integer = 0
        Dim maxRET As Integer = 0 'min,max random Entry top (.minRandomTop, maxRandomTop)


        Dim SR As Single = 1
        Dim op As Single = 1

        Dim Energy As Integer = 0
        Dim Cat As String = ""

        Dim L As Integer = 0
        Dim T As Integer = 0
        Dim W As Integer = 0
        Dim H As Integer = 0

        Dim TI As Integer = 100 'Timer Interval for timFrames (GIF's)

        Dim seqMoveLR As Integer = 99
        Dim seqMoveUD As Integer = 99
        Dim seqMoveDia As Integer = 99

        Dim speedLR As Integer = 5
        Dim speedUD As Integer = 3
        'Dim speedDia As Integer = 5

        For i = 0 To CountTO
            j = i
            FN = MainImageDir & "\Elements (Tools)\QuestionSpin.png"
            Cat = "IM"
            Nme = "IM" & i.ToString()

            Select Case i
                Case 0
                    SR = 0.5
                    FN = MainImageDir & "\Elements (Tools)\QuestionSpin.png"
                    T = -8
                    Nme = "Holding Image"
                    Cat = "Holding Image"
                    'seqMoveLR = EAST
                Case 1
                    speedLR = 50
                    SR = 0.5
                    FN = MainImageDir & "\Air\burun_attack_helicopter - (288x112).gif"
                    T = 10
                    Nme = "Heli Main"
                    Cat = "Helicopter"
                    TI = 10
                    'seqMoveLR = EAST
                Case 2
                    speedLR = 20
                    SR = 0.2
                    FN = MainImageDir & "\space\Interceptor 1 (UFO Series).png"
                    T = 30
                    Nme = "Interceptor 1"
                    Cat = ""
                    CA = False
                    seqMoveLR = EAST
                Case 3

                    'T = Convert.ToInt32(Height * 0.067)
                    'L = Convert.ToInt32(Width * 0.14)
                    T = 0
                    L = 0

                Case 4
                    'T = Convert.ToInt32(Height * 0.067)
                    'L = Convert.ToInt32(Width * 0.14)
                Case 5
                    FN = MainImageDir & "\Person\anim 00009.gif"
                    Nme = "Terrorist"
                Case 10

            End Select
            W = Image.FromFile(FN).Width ' * SR
            H = Image.FromFile(FN).Height ' * SR
            If Cat = "IM" Then T = Me.Bottom - H - 30 : seqMoveLR = EAST : SR = 0.5
            Try
                Quick_Draw_Images(i, FN, Nme, _
                                  Flip, rotateTF, _
                                  CA, Cat, _
                                  seqMoveLR, seqMoveUD, seqMoveDia, _
                                  speedLR, speedUD, _
                                  SR, TI, _
                                  L, T, _
                                  W, H)

                With LOImg(i)
                    .gifOpacity = op
                    .Energy = Energy
                    .Disposed = Disposed
                    .showidTF = ShowidTF

                    '.Fixed = False
                    .DrawRectTF = DrawRectTF

                    .RandomEntry = RE
                    .minRandomTop = minRET
                    .maxRandomTop = maxRET
                    .Show_ID()

                    If Path.GetExtension(.gifBGI) = ".gif" Then .continuousAnimation = True : .stopAnimation = False
                    If .flipMe Then .gifImage = Flip_Me("RotateNoneFlipX", .gifImage)

                    .Set_Interval(.TI)
                    ' .timCombined.Start()
                    '.timMovement.Start()
                End With

            Catch ex As Exception
                MsgBox("Create_New" & vbCrLf & j & vbCrLf & ex.Message)
                'If ex.Message.Contains("Index was out of range") Then timWarning.Start() : grpWarningGroup.Hide()
            End Try



            '## Reset Variables #
            FN = ""
            j = 0
            Nme = ""
            CountTO = 9
            Flip = False
            rotateTF = False
            DrawRectTF = False
            CA = True
            Disposed = False

            SR = 1
            op = 1

            Energy = 0

            RE = False
            minRET = 0
            maxRET = 0

            seqMoveLR = 99
            seqMoveUD = 99
            seqMoveDia = 99

            speedLR = 5
            speedUD = 3
            TI = 100
            L = 0 : T = 0 : W = 0 : H = 0

        Next
    End Sub

    Private Sub Create_New(ByVal i As Integer, ByVal theFile As String)
        Dim MainImageDir As String = "C:\Users\Public\ImgDir"
        Dim FN As String = theFile
        Dim j As Integer = 0
        Dim Nme As String = Path.GetFileNameWithoutExtension(theFile) & i.ToString
        'Dim CountTO As Integer = 1

        Dim Flip As Boolean = False
        Dim rotateTF As Boolean = False
        Dim CA As Boolean = True
        Dim Disposed As Boolean = False
        Dim ShowidTF As Boolean = False
        Dim DrawRectTF As Boolean = False

        Dim RE As Boolean = False  ' RandomEntry (Random Top)
        Dim minRET As Integer = 0
        Dim maxRET As Integer = 0 'min,max random Entry top (.minRandomTop, maxRandomTop)


        Dim SR As Single = 1
        Dim op As Single = 1

        Dim Energy As Integer = 0
        Dim Cat As String = ""

        Dim L As Integer = 0
        Dim T As Integer = 0
        Dim W As Integer = 0
        Dim H As Integer = 0

        Dim TI As Integer = 100 'Timer Interval for timFrames (GIF's)

        Dim seqMoveLR As Integer = 99
        Dim seqMoveUD As Integer = 99
        Dim seqMoveDia As Integer = 99

        Dim speedLR As Integer = 5
        Dim speedUD As Integer = 3
        'Dim speedDia As Integer = 5

        'speedLR = 50
        'SR = 0.5
        'FN = MainImageDir & "\Air\burun_attack_helicopter - (288x112).gif"
        Top = 10
        'Nme = "Heli Main"
        'Cat = "Helicopter"
        'TI = 10
        'seqMoveLR = EAST

    
   
        W = Image.FromFile(FN).Width
        H = Image.FromFile(FN).Height
            If Cat = "IM" Then T = Me.Bottom - H - 30 : seqMoveLR = EAST : SR = 0.5
            Try
                Quick_Draw_Images(i, FN, Nme, _
                                  Flip, rotateTF, _
                                  CA, Cat, _
                                  seqMoveLR, seqMoveUD, seqMoveDia, _
                                  speedLR, speedUD, _
                                  SR, TI, _
                                  L, T, _
                                  W, H)

                With LOImg(i)
                    .gifOpacity = op
                    .Energy = Energy
                    .Disposed = Disposed
                    .showidTF = ShowidTF

                    '.Fixed = False
                    .DrawRectTF = DrawRectTF

                    .RandomEntry = RE
                    .minRandomTop = minRET
                    .maxRandomTop = maxRET
                    .Show_ID()

                    If Path.GetExtension(.gifBGI) = ".gif" Then .continuousAnimation = True : .stopAnimation = False
                    If .flipMe Then .gifImage = Flip_Me("RotateNoneFlipX", .gifImage)

                    .Set_Interval(.TI)
                    ' .timCombined.Start()
                    '.timMovement.Start()
                End With

            Catch ex As Exception
                MsgBox("Create_New" & vbCrLf & j & vbCrLf & ex.Message)
                'If ex.Message.Contains("Index was out of range") Then timWarning.Start() : grpWarningGroup.Hide()
            End Try



            '## Reset Variables #
            FN = ""
            j = 0
            Nme = ""
            CountTO = 9
            Flip = False
            rotateTF = False
            DrawRectTF = False
            CA = True
            Disposed = False

            SR = 1
            op = 1

            Energy = 0

            RE = False
            minRET = 0
            maxRET = 0

            seqMoveLR = 99
            seqMoveUD = 99
            seqMoveDia = 99

            speedLR = 5
            speedUD = 3
            TI = 100
            L = 0 : T = 0 : W = 0 : H = 0

    End Sub

    Private Sub Quick_Draw_Images(ByVal i As Integer, ByVal theFile As String, ByVal Nme As String, _
                                  ByVal Flip As Boolean, ByVal rotateTF As Boolean, _
                                  ByVal CA As Boolean, ByVal Cat As String, _
                                  ByVal seqMoveLR As Integer, ByVal seqMoveUD As Integer, ByVal seqMoveDia As Integer, _
                                  ByVal speedLR As Integer, ByVal speedUD As Integer,
                                  ByVal SR As Double, ByVal TI As Integer, _
                                  ByVal L As Integer, ByVal T As Integer, _
                                  ByVal W As Integer, ByVal H As Integer)

        Dim FN As String = theFile

        Dim GI As Image
        Dim OP As Single = 1 'opacity

        Dim MF As Integer = 1 'maxFrames
        Dim SN As Integer = 0 'next action seqNext
        Dim fixedFrame As Integer = 0
        Dim SA As Integer = 0 'seqaction
        Dim MC As Integer = 30 'mastercount

        Dim Bounce As Boolean = False
        Dim hasFrames As Boolean = False
        Dim Fixed As Boolean = False
        Dim Disposed As Boolean = False
        Dim Visible As Boolean = True
        Dim Docked As Boolean = False
        Dim ShowID As Boolean = False
        'Dim Flip As Boolean = False
        Dim FlipUD As Boolean = False
        Dim RE As Boolean = False 'randomEntry
        Dim isCharTF As Boolean = False
        Dim Action As String = ""
        Dim RecNO As Integer = -1
        Dim ssmTF As Boolean = False 'set size manually

        If Nme = "" Then Name = Path.GetFileNameWithoutExtension(theFile) Else Name = Nme
        GI = Image.FromFile(FN)
        'L = Cursor.Position.X
        'T = Cursor.Position.Y
        'W = (GI.Width / MF) * SR 'used fro sprite sheet with frames
        'H = GI.Height * SR


        '## Bridge ##
        'If i > CountToImg Then Exit Sub

        LOImg.Add(New clsImg(Me))
        With LOImg(i)
            .mainForm = Me
            .Frm = Me
            .ID = i
            .RecNo = _RecNO
            .Name = Name
            .Category = Cat
            .Action = Action

            '.maxFrames = MF
            .gifSR = SR
            .gifBGI = FN
            .gifImage = SafeImageFromFile(.gifBGI)

            .Left = L
            .Top = T
            .Width = W  '(.gifImage.Width / .maxFrames) * .gifSR
            .Height = H
            .setSizeManuallyTF = ssmTF
            .SpeedLR = speedLR
            .SpeedUD = speedUD

            .seqMoveLR = seqMoveLR
            .seqMoveUD = seqMoveUD
            .seqNext = SN
            .TI = TI

            '.hasFrames = hasFrames
            .flipMe = Flip
            .flipUD = FlipUD
            .DockedTF = Docked
            .Disposed = Disposed
            .Visible = Visible
            .continuousAnimation = CA
            .RandomEntry = RE
            .showidTF = ShowID
            .ActivatedTF = True

            '.masterCount = MC
            .gifOpacity = OP

            .arrSpeed(0) = .SpeedLR
            .arrSpeed(1) = .SpeedUD
            .startLeft = .seqMoveLR

            If .Width > .Height Then
                .AspectRatio = .Height / .Width
            Else
                .AspectRatio = .Width / .Height
            End If

            .RatioLeftToW = .Left / Width
            .RatioTopToH = .Top / Height
            .RatiotSizeWidthToW = .Width / Width
            .RatiotSizeHeightToH = .Height / Height

            .Rotate_ME(rotateTF)

            If Path.GetExtension(.gifBGI) = ".gif" Then
                If CA Then .Start_Frames() 'Else .Set_pngIndex(0) : .Start_FrameSet(.gifBGI)
                'If CA Then .Start_ImG_Frames()
            Else
                If .flipMe Then .gifImage = Flip_Me("RotateNoneFlipX", .gifImage)
            End If

            If Bounce Then .Bounce()
            .Post_Load()

            If hasFrames Then
                '.Do_Frames_Array(LOImg(i), .gifBGI, .maxFrames)
                'If Not CA Then .Set_iFrames(fixedFrame)
            End If

            With .timCombined
                .Interval = TI
                .Start()
            End With



            '.timMonitor.Start()
            '.timMovement.Start()
            'MsgBox(.Name & Environment.NewLine & .Left & vbCrLf & Right)
        End With

        'If isCharTF Then UpDate_tbl_Characrters()
        _RecNO = -1
        mainForm.activeImgIdx = i


        idxImg += 1
        CountToImg += 1
        'Refresh_Total_Images()
    End Sub

    Private Sub Start()
        'Dim BGI As String = imagePATH & "\BackGround\space_scene 5403.jpg"
        'BackgroundImage = Image.FromFile(BGI)

        Try
            If Get_LOimg_ID("Flash") >= 0 Then
                With LOImg(Get_LOimg_ID("Flash"))
                    '.Left = (mainForm.width - .Width) / 2
                    '.Top = mainForm.height - .Height * 3
                    '.Set_Interval(350)
                    '.TI = 50
                    .fixedIndex = 0
                    .setIndexTF = False
                    .Fixed = False
                    .SpeedLR = 30
                    .seqMoveLR = EAST
                    .seqNext = 1
                End With
            End If

            If Get_LOimg_ID("IM3") >= 0 Then
                With LOImg(Get_LOimg_ID("IM3"))
                    .Left = Width * 0.73 '1180
                    .Top = Height * 0.587 '538
                    .RatioLeftToW = .Left / Width
                    .RatioTopToH = .Top / Height



                    '.Set_Interval(500)
                    .fixedIndex = 0
                    .setIndexTF = False
                    .Fixed = False
                    .SpeedLR = 20
                    .seqMoveLR = 99
                    .seqNext = 1
                End With
            End If

            If Get_LOimg_ID("IM4") >= 0 Then
                With LOImg(Get_LOimg_ID("IM4"))
                    .Left = mainForm.Width * 0.081064356
                    .Top = mainForm.height * 0.77510917
                    '.Top = 
                    '.Left = 1164
                    '.Top = 532
                    .showidTF = True
                    .Set_Interval(300)
                    .fixedIndex = 0
                    .setIndexTF = False
                    .Fixed = False
                    .seqMoveLR = EAST
                    .seqNext = 1
                End With
            End If

            If Get_LOimg_ID("Terrorist") >= 0 Then
                With LOImg(Get_LOimg_ID("Terrorist"))
                    .Left = (mainForm.width - .Width) / 2
                    .Top = mainForm.height - .Height * 3
                    '.Left =
                    ' .Top = 
                    '.Set_Interval(350)
                    '.TI = 50
                    .setSizeManuallyTF = True
                    .Width = LOImg(Get_LOimg_ID("IM4")).Width * LOImg(Get_LOimg_ID("IM4")).gifSR
                    .Height = LOImg(Get_LOimg_ID("IM4")).Height * LOImg(Get_LOimg_ID("IM4")).gifSR
                    '.Width = Width * 0.495633188
                    '.Height = Height * 0.073019802
                    .Set_Size(.Width, .Height)
                    .fixedIndex = 0
                    .setIndexTF = False
                    .Fixed = False
                    .SpeedLR = 30
                    .seqMoveLR = EAST
                    .seqNext = 1
                End With
            End If

            If Get_LOimg_ID("Fighting BackGround") >= 0 Then
                With LOImg(Get_LOimg_ID("Fighting BackGround"))
                    ' .Left = 0 '(mainForm.width - .Width) / 2
                    ' .Top = mainForm.height - .Height
                    '.Set_Interval(500)
                    '.fixedIndex = 0
                    '.setIndexTF = True
                    '.Fixed = False
                    '.seqMoveLR = 99
                    .setSizeManuallyTF = True
                    .Set_Size(mainForm.width, mainForm.height)
                    .seqNext = 1
                End With
            End If




            'Populate_dgvLOIMG_From_LOImg()
        Catch ex As Exception
            'Trigger_Warning("Sub Start" & vbCrLf & LOImg.Count - 1 & vbCrLf & ex.Message)
            MsgBox("Sub Start" & vbCrLf & LOImg.Count - 1 & vbCrLf & ex.Message)
        End Try
    End Sub


    Public Shared Function SafeImageFromFile(ByVal path As String) As Image
        Dim bytes = File.ReadAllBytes(path)
        Using ms As New MemoryStream(bytes)
            Dim img = Image.FromStream(ms)
            Return img
        End Using
    End Function

    Public Function Get_LOimg_ID(ByVal Nme As String) As Integer
        Dim idx = -1

        For i = 0 To LOImg.Count - 1
            Try
                If UCase(LOImg(i).Name) = UCase(Nme) Then idx = i : Exit For
            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim CallingMethod As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace
                'Dim CurrentMethod As String = System.Reflection.MethodBase.GetCurrentMethod().Name
                'Trigger_Warning("Calling: " & CallingMethod.GetFrame(1).GetMethod.Name & vbCrLf & "Current: " & CurrentMethod & vbCrLf & ex.Message)
            End Try
        Next

        Return idx
    End Function

    Public Function GET_mainForm_BOUNDS(ByVal Edge As String) As Integer ', ByVal ID As Integer
        Dim L As Integer = Nothing

        Select Case Edge
            Case "LEFT"
                L = 0 '-LOImg(ID).Width
            Case "RIGHT"
                L = mainForm.Width
        End Select
        'Label1.Text = Edge & Space(3) & L
        Return L
    End Function

    '## Change Sequence ##
    Public Sub Change_Sequence(ByVal ID As Integer, ByVal seqAction As Integer)
        Try
            Select Case ID




                '## END MAIN SELECT ##
            End Select ' Main Select

        Catch ex As Exception
            'Text = ex.Message
            mainForm.lblinfo.text = "change seq ID: " & ID & " seqAction: [" & seqAction & "]" & vbCrLf & ex.Message
        End Try
    End Sub
#End Region

    '## cmsMain - Menu Items ##
#Region "Menu Items"
    Private Sub tsmMoveModeBTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmMoveModeBTN.Click, picMoveMode.Click
        If MoveModeTF Then
            MoveModeTF = False : tsmMoveModeBTN.Text = "Move Mode ON"
            picMoveMode.Image = My.Resources.Red_Light_ON
        Else
            MoveModeTF = True : tsmMoveModeBTN.Text = "Move Mode OFF"
            picMoveMode.Image = My.Resources.Green_Light_ON
        End If
    End Sub

    Private Sub tsmSizeModeBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSizeModeBTN.Click, picSizeMode.Click
        If SizeModeTF Then
            SizeModeTF = False : tsmSizeModeBTN.Text = "Size Mode ON"
            picSizeMode.Image = My.Resources.Red_Light_ON
        Else
            SizeModeTF = True : tsmSizeModeBTN.Text = "Size Mode OFF"
            picSizeMode.Image = My.Resources.Green_Light_ON
        End If
    End Sub

    Private Sub tsmShowHideControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShowHideControlsBTN.Click
        If panControls.Visible Then panControls.Hide() Else panControls.Show()
        'panControls.Size = New Size(314, 211)
        panControls.Location = New Point((Width - panControls.Width) / 2, (Height - panControls.Height) / 2)
    End Sub

    Private Sub tsmWxHModeBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmWxHModeBTN.Click, picWxH.Click
        If WxHModeTF Then
            WxHModeTF = False : tsmWxHModeBTN.Text = "WxH Mode ON"
            picWxH.Image = My.Resources.Red_Light_ON
        Else
            WxHModeTF = True : tsmWxHModeBTN.Text = "WxH Mode OFF"
            picWxH.Image = My.Resources.Green_Light_ON
        End If
    End Sub

    Private Sub tsmEditFormBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditFormBTN.Click
        SHOW_EditForm()
    End Sub

    Private Sub cmbElement_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbElement.SelectedValueChanged
        activeImgIdx = cmbElement.SelectedIndex
    End Sub

    '## Cross Hairs ##
    Private Sub tsmCrossHairsBTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmCrossHairsBTN.Click
        With frmCrossHairs
            .mainForm = Me
            .frm = Me

            .Show()
            .Size = New Size(75, 75)
            .Location = New Point(Cursor.Position.X - .Width / 2, Cursor.Position.Y - .Height - 50)
        End With
    End Sub

    Private Sub tsmCrossHairsCloseBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCrossHairsCloseBTN.Click
        frmCrossHairs.Close()
    End Sub

    Private Sub tsmCrossHairsStopTrackingMouseBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCrossHairsStopTrackingMouseBTN.Click
        If frmCrossHairs.TrackMouseTF Then frmCrossHairs.TrackMouseTF = False Else frmCrossHairs.TrackMouseTF = True
    End Sub
#End Region


    Private Sub frmGame1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Text = Size.ToString
        If LOImg.Count - 1 < 0 Then Exit Sub
        Dim FW As Integer = Width
        Dim FH As Integer = Height

        ' MsgBox(Size.ToString)
        If WindowState = FormWindowState.Maximized Then
            FW = Screen.PrimaryScreen.WorkingArea.Width
            FH = Screen.PrimaryScreen.WorkingArea.Height
        End If

        Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2)
        For i = 0 To LOImg.Count - 1
            With LOImg(i)
                Dim L = FW * .RatioLeftToW
                Dim T = FH * .RatioTopToH
                Dim W = Convert.ToInt32(Width * .RatiotSizeWidthToW)
                Dim H = Convert.ToInt32(Height * .RatiotSizeHeightToH)
                .Set_Size(W, H)
                .Set_Location(L, T)
            End With

        Next
    End Sub
End Class
