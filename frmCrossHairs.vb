Imports System
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports clsImg = GameEngine.v2.clsImg

Public Class frmCrossHairs
    Public mainForm As Object
    Public frm As Form
    Public TrackMouseTF As Boolean = True

    Dim WithEvents timInvalidate As New Timer


    Private Sub frmCrossHairs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Normal
        CenterToScreen()
        KeyPreview = True
        DoubleBuffered = True
        AllowDrop = True
        ControlBox = False
        MinimizeBox = False
        MaximizeBox = True
        Text = ""
        FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Top = 0
        TopMost = True
        BackColor = Color.Azure
        TransparencyKey = Color.Azure

        BackgroundImage = Image.FromFile("C:\Users\Public\ImgDir\CrossHairs\scope 433.png")
        BackgroundImageLayout = ImageLayout.Stretch
        'Size = BackgroundImage.Size
        Size = New Size(100, 100)

        ContextMenuStrip = cmsMain
        timInvalidate.Start()
    End Sub

    Private Sub frmCrossHairs_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub tsmBackGroundImageBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBackGroundImageBTN.Click
        BackgroundImage = Image.FromFile("C:\Users\Public\ImgDir\CrossHairs\crosshair2.png")
        Size = New Size(100, 100)

    End Sub

    Private Sub tsmGDIImageBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmGDIImageBTN.Click

    End Sub

    Private Sub tsmPictureBoxImageBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPictureBoxImageBTN.Click

    End Sub

    Private Sub tsmSelectCHLBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSelectCHLBL.Click
        cmsMain.Show()
    End Sub

    Private Sub tsmCloseBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCloseBTN.Click
        Close()
    End Sub

    Private Sub timInvalidate_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timInvalidate.Tick
        'track mouse
        If TrackMouseTF Then
            Location = New Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height - 50)
        End If

    End Sub
End Class