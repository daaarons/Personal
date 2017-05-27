Imports System
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports clsImg = GameEngine.v2.clsImg

Public Class frmControls
    Public mainForm As Object
    Public frm As Form

    Public MoveModeTF As Boolean = False
    Public SizeModeTF As Boolean = False
    Public WxHModeTF As Boolean = False

    Dim WithEvents timChanges As New Timer

    Private Sub frmControls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        DoubleBuffered = True
        AllowDrop = True
        ControlBox = True
        MinimizeBox = False
        MaximizeBox = True
        Text = ""
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        ' Opacity = 0.7
        BackColor = Color.Azure
        TransparencyKey = Color.Azure


        ContextMenuStrip = cmsMain

        picStop.Image = My.Resources.Sign_Stop_icon
        picTop.Image = My.Resources.Arrow_Red
        picBottom.Image = Flip_Me("Rotate180FlipNone", My.Resources.Arrow_Red)
        picLeft.Image = Flip_Me("Rotate270FlipNone", My.Resources.Arrow_Red)
        picRight.Image = Flip_Me("Rotate90FlipNone", My.Resources.Arrow_Red)

        picMoveMode.Image = My.Resources.Red_Light_ON
        picSizeMode.Image = My.Resources.Red_Light_ON
        picWxH.Image = My.Resources.Red_Light_ON

        For i = 0 To mainForm.LOImg.Count - 1
            cmbElement.Items.Add(i)
        Next

        Dim A = mainForm.LOImg(mainForm.activeImgIdx)
    
        If A.gifSR < 1 Then nudSR.Value = 0 Else nudSR.Value = A.gifSr / 1
        If (A.gifSR Mod 10) * tbSR.Maximum >= 1 Then tbSR.Value = 0 Else tbSR.Value = (A.gifSR Mod 10) * tbSR.Maximum
        Dim c As Double = A.gifSR Mod 10
        'MsgBox(c & vbCrLf & (A.gifSR Mod 10) & vbCrLf & (A.gifSR Mod 10) * tbSR.Maximum)
        nudSpeedLR.Value = A.speedLR
        nudSpeedUD.Value = A.speedUD
        timChanges.Start()
    End Sub


    Private Sub frmCanvas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If mainForm.activeImgIdx < 0 Then Exit Sub
        Dim A = mainForm.LOImg(mainForm.activeImgIdx)


        If MoveModeTF Then
            'mainForm.MoveModeTF = MoveModeTF
            Select Case e.KeyCode
                Case Keys.Left
                    A.Left -= 1
                Case Keys.Right
                    A.Left += 1
                Case Keys.Up
                    A.Top -= 1
                Case Keys.Down
                    A.Top += 1
            End Select
        End If
        If SizeModeTF Then
            'mainForm.SizeModeTF = SizeModeTF
            Select Case e.KeyCode
                Case Keys.Left
                Case Keys.Right
                    A.Left += 5
                    A.Top -= 15
            End Select
        End If
        If WxHModeTF Then
            'mainForm.WxHModeTF = WxHModeTF
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
            A.Set_Location(PointToClient((New Point(Cursor.Position.X, Cursor.Position.Y))))
        End If




        Select Case e.KeyCode
            Case Keys.C
                Close()

        End Select

    End Sub

    Private Sub frmControls_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        timChanges.Stop()
        mainForm.lblInfo.show()
    End Sub

    

    '## cmsMain - Menu Items ##
    Private Sub tsmMoveModeBTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmMoveModeBTN.Click, picMoveMode.Click
        If MoveModeTF Then
            MoveModeTF = False : tsmMoveModeBTN.Text = "Move Mode ON"
            picMoveMode.Image = My.Resources.Red_Light_ON
            mainForm.picMoveMode.Image = My.Resources.Red_Light_ON
        Else
            MoveModeTF = True : tsmMoveModeBTN.Text = "Move Mode OFF"
            picMoveMode.Image = My.Resources.Green_Light_ON
            mainForm.picMoveMode.Image = My.Resources.Green_Light_ON
        End If
        mainForm.MoveModeTF = MoveModeTF
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

    Private Sub tsmWxHModeBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmWxHModeBTN.Click, picWxH.Click
        If WxHModeTF Then
            WxHModeTF = False : tsmWxHModeBTN.Text = "WxH Mode ON"
            picWxH.Image = My.Resources.Red_Light_ON
        Else
            WxHModeTF = True : tsmWxHModeBTN.Text = "WxH Mode OFF"
            picWxH.Image = My.Resources.Green_Light_ON
        End If
    End Sub


    Private Sub cmbElement_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbElement.SelectedValueChanged
        mainForm.activeImgIdx = cmbElement.SelectedIndex
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        If Label12.ForeColor = Color.Red Then
            Label12.ForeColor = Color.Lime
            Label12.Text = "Enable Controls"
            grpControls.Enabled = False
        Else
            Label12.ForeColor = Color.Red
            Label12.Text = "Disable Controls"
            grpControls.Enabled = True
        End If
    End Sub



    Private Sub timChanges_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timChanges.Tick
        If mainForm.activeImgIdx < 0 Then Exit Sub
        Dim A = mainForm.LOImg(mainForm.activeImgIdx)

        With A
            If .seqMoveLR = 99 Then
                picLeft.Image = Flip_Me("Rotate270FlipNone", My.Resources.Arrow_Red)
                picRight.Image = Flip_Me("Rotate90FlipNone", My.Resources.Arrow_Red)
            Else
                Change_Direction(.seqMoveLR)
            End If
            If .seqMoveUD = 99 Then
                ' = My.Resources.Arrow_Red
                picTop.Image = My.Resources.Arrow_Red
                picBottom.Image = Flip_Me("Rotate180FlipNone", My.Resources.Arrow_Red)
            Else
                Change_Direction(.seqMoveUD)
            End If








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
            lblName.Text = .Name
            Label7.Text = .RatioLeftToW
            Label16.Text = .RatioTopToH
            Label14.Text = frame
            Label17.Text = .RatiotSizeWidthToW & " , " & .RatiotSizeHeightToH & vbCrLf _
            & Convert.ToInt32(mainForm.Width / .RatiotSizeWidthToW) & " , " & Convert.ToInt32(mainForm.Height / .RatiotSizeHeightToH)

            Label18.Text = .Width / Image.FromFile(.gifBGI).Width
            If SizeModeTF Then
                .gifSR = nudSR.Value + (tbSR.Value / 10)
                .Set_Size()
            End If

            lblSRDisplay.Text = nudSR.Value + tbSR.Value * 0.1
            lblSpeedLR.Text = .speedLR
            lblSpeedUD.Text = .speedUD
        End With

    End Sub

    

    Private Sub btnSaveAllProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAllProperties.Click
        mainForm.SAVE_Elements_Properties()
    End Sub


    '##......##
    Private Sub Change_Direction(ByVal Dir As Integer)
        Label21.Text = Dir
        Select Case Dir
            Case EAST
                picRight.Image = Flip_Me("Rotate90FlipNone", My.Resources.Arrow_Green)
            Case WEST
                picLeft.Image = Flip_Me("Rotate270FlipNone", My.Resources.Arrow_Green)
            Case NORTH
                picTop.Image = My.Resources.Arrow_Green
            Case SOUTH
                picBottom.Image = Flip_Me("Rotate180FlipNone", My.Resources.Arrow_Green)
        End Select
    End Sub

    '## WASD ##
#Region "Buttons WASD"

    Private Sub btnNorth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNorth.Click
        Dim A As clsImg = mainForm.LOImg(mainForm.activeImgIdx)
        A.Top -= 5
    End Sub

    Private Sub btnWest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWest.Click

    End Sub

    Private Sub btnSouth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSouth.Click
        Dim A As clsImg = mainForm.LOImg(mainForm.activeImgIdx)
        A.Top += 5
    End Sub

    Private Sub btnEast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEast.Click

    End Sub
#End Region

    '## LRTB ##
#Region "Buttons LRTB"
    Private Sub btnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTop.Click
        Dim Ele As clsImg = mainForm.LOImg(mainForm.activeImgIdx)
        If Ele.seqMoveUD = NORTH Then Ele.seqMoveLR = 99 Else Ele.seqMoveLR = NORTH
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        Dim Ele As clsImg = mainForm.LOImg(mainForm.activeImgIdx)
        If Ele.seqMoveLR = WEST Then Ele.seqMoveLR = 99 Else Ele.seqMoveLR = WEST
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        Dim Ele As clsImg = mainForm.LOImg(mainForm.activeImgIdx)
        If Ele.seqMoveLR = EAST Then Ele.seqMoveLR = 99 Else Ele.seqMoveLR = EAST
    End Sub

    Private Sub btnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBottom.Click
        Dim Ele As clsImg = mainForm.LOImg(mainForm.activeImgIdx)
        If Ele.seqMoveUD = SOUTH Then Ele.seqMoveLR = 99 Else Ele.seqMoveLR = SOUTH
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
#End Region

    '## pic LRTB ##
#Region "pic LRTB"
    Private Sub pic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTop.Click, picBottom.Click, picLeft.Click, picRight.Click, picStop.Click
        Dim PB As PictureBox = CType(sender, PictureBox)
        Dim A As clsImg = mainForm.LOImg(mainForm.activeImgIdx)
        With PB
            .BorderStyle = BorderStyle.Fixed3D
            Select Case sender.name
                Case "picTop"
                    If A.seqMoveUD = 99 Then A.seqMoveUD = NORTH Else A.seqMoveUD = 99
                Case "picBottom"
                    If A.seqMoveUD = 99 Then A.seqMoveUD = SOUTH Else A.seqMoveUD = 99
                Case "picLeft"
                    If A.seqMoveLR = 99 Then A.seqMoveLR = WEST Else A.seqMoveLR = 99
                Case "picRight"
                    If A.seqMoveLR = 99 Then A.seqMoveLR = EAST Else A.seqMoveLR = 99
                Case "picStop"
                    A.seqMoveUD = 99 : A.seqMoveLR = 99

            End Select
        End With
    End Sub

    Private Sub pic_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTop.MouseLeave, picBottom.MouseLeave, picLeft.MouseLeave, picRight.MouseLeave, picStop.MouseLeave
        Dim PB As PictureBox = CType(sender, PictureBox)
        With PB
            .BorderStyle = BorderStyle.FixedSingle
        End With
        'Cursor.Current = Cursors.Default
    End Sub
#End Region

    

    Private Sub tbSR_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSR.Scroll
        If mainForm.activeImgIdx < 0 Then Exit Sub
        Dim A = mainForm.LOImg(mainForm.activeImgIdx)

        'lblSRDisplay.Text = nudSR.Value + tbSR.Value / 10
        A.gifsr = nudSR.Value + tbSR.Value / 10
    End Sub

    Private Sub nudSR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSR.ValueChanged
        If mainForm.activeImgIdx < 0 Then Exit Sub
        Dim A = mainForm.LOImg(mainForm.activeImgIdx)

        'lblSRDisplay.Text = nudSR.Value + tbSR.Value / 10
        A.gifsr = nudSR.Value + tbSR.Value / 10
    End Sub

    Private Sub nudSpeedLR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSpeedLR.ValueChanged
        If mainForm.activeImgIdx < 0 Then Exit Sub
        Dim A = mainForm.LOImg(mainForm.activeImgIdx)
        A.speedLR = nudSpeedLR.Value
    End Sub

    Private Sub nudSpeedUD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSpeedUD.ValueChanged
        If mainForm.activeImgIdx < 0 Then Exit Sub
        Dim A = mainForm.LOImg(mainForm.activeImgIdx)
        A.speedUD = nudSpeedUD.Value
    End Sub
End Class