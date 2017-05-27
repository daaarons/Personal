Imports System
Imports System.Drawing
Imports clsImg = GameLibs.clsImgNew

Public Class frmImageAnimator
    Public LOImg As New List(Of clsImg)()
    Public LOPerson As New List(Of struPerson)()
    Public CountTO As Integer = 10

    Private Sub frmImageAnimator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        WindowState = FormWindowState.Maximized

        BackgroundImage = Image.FromFile("C:\Users\Public\ImgDir\Terrain\image 82.jpg")
        BackgroundImageLayout = ImageLayout.Stretch

        For i = 0 To CountTO
            Quick_Draw_Images(i)
        Next
    End Sub

    Public Sub OnFrameChanged(ByVal obj As Object, ByVal e As EventArgs)
        Invalidate()
    End Sub

    Public Sub OnFrameChanged()
        'Invalidate()
    End Sub


    Structure struPerson
        Public ID As Integer
        Public Name As String
        Public Left As Integer
        Public Top As Integer
        Public Width, Height As Integer
        Public gifImage As Image
        Public gifBGI As String

    End Structure

    Private Sub Quick_Draw_Images(ByVal i As Integer)
        Dim speedLR As Integer = 10
        Dim MainImageDir As String = "C:\Users\Public\ImgDir"
        Dim BGI As String = MainImageDir & "\Person\iron-walk.gif"
        Dim top As Integer = 150
        Dim SR As Double = 1
        Dim Name As String = "IM" + i.ToString


        Select Case i
            Case 0
                speedLR = 50
                SR = 0.35
                BGI = MainImageDir & "\Person\Flash Run Extremly Fast.gif"
                top = 10
                Name = "Flash"
            Case 1
                speedLR = 20
                SR = 0.2
                BGI = MainImageDir & "\space\Interceptor 1 (UFO Series).png"
                top = 30
                Name = "Interceptor 1"
            Case 2
            Case 3

            Case 4
            Case 10

        End Select

        LOImg.Add(New clsImg(Me))
        With LOImg(i)
            .ID = i
            .Name = Name
            .gifBGI = BGI
            .gifImage = Image.FromFile(BGI)
            .speedLR = speedLR
            .gifSR = SR
            .Width = .gifImage.Width * .gifSR
            .Height = .gifImage.Height * .gifSR
            .Left = .Width * .speedLR
            '.Top = (.Height + top)
            .Top = Bottom - .Height - 30
            If .Name = "Flash" Then .Top = Bottom - .Height - 150
            If .Name = "Interceptor 1" Then .Top = 100
        End With

        speedLR = 0
        SR = 1
        BGI = ""
        top = 0

    End Sub



    Private Sub frmImageAnimator_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

    End Sub
End Class