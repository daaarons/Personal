Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.IO


Module UtilFuncs
    Public NORTH = 0
    Public SOUTH = 180
    Public EAST = 90
    Public WEST = 270
    Public SOUTHEAST = 45
    Public NORTHEAST = -45
    Public SOUTHWEST = 225
    Public NORTHWEST = 135


    Public App_path As String = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName & "\"



    'resize images by percent and copy to folder
    Public Sub ResizeImage(ByVal path As String, ByVal fileName As String, ByVal percentResize As Double) ',Optional Folder As String = "imgdir\resized\")

        'resizes picture to fit
        Dim bm As New Bitmap(path & fileName)
        Dim width As Integer = bm.Width - (bm.Width * percentResize) 'image width. 
        Dim height As Integer = bm.Height - (bm.Height * percentResize)  'image height
        Dim thumb As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(thumb)

        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
        g.Dispose()
        bm.Dispose()

        'image path.
        Dim folder = "imgdir\resized\"
        Try
            thumb.Save(folder & fileName, System.Drawing.Imaging.ImageFormat.Png) 'can use any image format 
        Catch ex As Exception

        End Try

        thumb.Dispose()
    End Sub
    '
    '
    'Resize image by Dimensions passed (W/H) and copy to folder
    Public Sub ResizeImage(ByVal path As String, ByVal fileName As String, ByVal W As Integer, ByVal H As Integer) ',Optional Folder As String = "imgdir\resized\")
        'resizes picture to fit
        Dim bm As New Bitmap(path & fileName)
        Dim width As Integer = W 'image width. 
        Dim height As Integer = H  'image height
        Dim thumb As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(thumb)

        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
        g.Dispose()
        bm.Dispose()

        'image path.
        Dim folder = "imgdir\resized\"
        Try
            thumb.Save(folder & fileName, System.Drawing.Imaging.ImageFormat.Png) 'can use any image format 
        Catch ex As Exception

        End Try

        thumb.Dispose()
    End Sub


    '
    '
    Public Function Pic_HxW(ByVal filePathname As String) As String()
        'Get image H and w
        Dim arrHxW(2) As String
        arrHxW = Split(Image_Dim(Image.FromFile(App_path & filePathname)), "x")
        Return arrHxW
    End Function
    '
    '
    '
    '** Extract img dimensions
    Public Function Image_Dim(ByVal SDI As System.Drawing.Image) As String
        Dim bmp As Bitmap
        bmp = New Bitmap(SDI)

        Dim siz As SizeF = bmp.Size
        SDI.Dispose()
        Return siz.Height.ToString & "x" & siz.Width.ToString
    End Function
    '
    '
    Public Function Between(ByVal myleft As Integer, ByVal mainObjleft As Integer, ByVal mainObjright As Integer) As Integer
        Dim intOK As Integer = 0
        If myleft >= mainObjleft And myleft <= mainObjright Then
            intOK = 1
        End If
        Return intOK
    End Function
    '
    '
    Public Function Pad_With_Zeros(ByVal num As Integer) As String
        Dim strNum = ""
        If num >= 10000 Then
            'do nothing
        ElseIf Between(num, 1000, 9999) Then
            strNum = "0" & num.ToString()
        ElseIf Between(num, 100, 999) Then
            strNum = "00" & num.ToString()
        ElseIf Between(num, 10, 99) Then
            strNum = "000" & num.ToString()
        Else : Between(num, 0, 9)
            strNum = "0000" & num.ToString()
        End If

        Return Trim(strNum)
    End Function
    '
    '
    '*************************
    '** Rotation of objects **
    '*************************
    '
    Public Function RotateImg(ByVal bmpimage As Bitmap, ByVal angle As Single) As Bitmap
        Dim w As Integer = bmpimage.Width
        Dim h As Integer = bmpimage.Height
        Dim pf As PixelFormat = Nothing

        pf = bmpimage.PixelFormat
        Dim tempImg As New Bitmap(w, h, pf)
        Dim g As Graphics = Graphics.FromImage(tempImg)
        g.DrawImageUnscaled(bmpimage, 1, 1)
        g.Dispose()

        Dim path As New GraphicsPath()
        path.AddRectangle(New RectangleF(0.0F, 0.0F, w, h))

        Dim mtrx As New Matrix()
        'Using System.Drawing.Drawing2D.Matrix class

        mtrx.Rotate(angle)
        Dim rct As RectangleF = path.GetBounds(mtrx)
        Dim newImg As New Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf)
        g = Graphics.FromImage(newImg)
        g.TranslateTransform(-rct.X, -rct.Y)
        g.RotateTransform(angle)
        g.InterpolationMode = InterpolationMode.HighQualityBilinear
        g.DrawImageUnscaled(tempImg, 0, 0)
        g.Dispose()
        tempImg.Dispose()
        Return newImg
    End Function
    '
    '
    ' Rotate an image in increments of 90 Degrees.
    'Private Sub btnRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotate.Click
    Public Sub Rotate_By_90(ByVal picSource As String, ByVal picDest As Object, ByVal angle As Integer)
        ' Make sure something is selected.
        ' If cboRotationType.SelectedIndex < 0 Then Exit Sub


        Dim bm_out As New Bitmap(Bitmap.FromFile(picSource)) ' Make the output bitmap.
        Dim rotation_name As String = "" ' Find the rotation name.
        Select Case angle
            Case 0
                rotation_name = "RotateNoneFlipNone"
            Case 90
                rotation_name = "Rotate90FlipNone"
                'rotation_name = "Rotate90FlipX"
            Case 180
                rotation_name = "Rotate180FlipNone"
            Case 270
                rotation_name = "Rotate270FlipNone"

        End Select
        'rotation_name = rotation_name.Substring(0,rotation_name.IndexOf(" ("))
        Select Case rotation_name
            Case "Rotate180FlipNone"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case "Rotate180FlipX"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipX)
            Case "Rotate180FlipXY"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipXY)
            Case "Rotate180FlipY"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipY)

            Case "Rotate270FlipNone"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Case "Rotate270FlipX"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipX)
            Case "Rotate270FlipXY"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipXY)
            Case "Rotate270FlipY"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipY)

            Case "Rotate90FlipNone"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case "Rotate90FlipX"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipX)
            Case "Rotate90FlipXY"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipXY)
            Case "Rotate90FlipY"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipY)

            Case "RotateNoneFlipNone"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipNone)
            Case "RotateNoneFlipX"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Case "RotateNoneFlipXY"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipXY)
            Case "RotateNoneFlipY"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipY)
        End Select

        ' Display the result.
        'picDest.Image = bm_out
        picDest.backgroundimage = bm_out
    End Sub
    '
    ' 

    ' Same functionality as above but placed in a Function
    ' More useful this way
    '
    '
    Public Function Flip_Me(ByVal rotation_name As String, ByVal picSource As Bitmap) As Bitmap
        'Dim bm_out As New Bitmap(picSource.Image)
        Dim bm_out As New Bitmap(picSource)

        ' Find the rotation name.
        'Dim rotation_name As String = cboRotationType.Text
        'rotation_name = rotation_name.Substring(0,rotation_name.IndexOf(" ("))
        Select Case rotation_name
            Case "Rotate180FlipNone"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case "Rotate180FlipX"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipX)
            Case "Rotate180FlipXY"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipXY)
            Case "Rotate180FlipY"
                bm_out.RotateFlip(RotateFlipType.Rotate180FlipY)

            Case "Rotate270FlipNone"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Case "Rotate270FlipX"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipX)
            Case "Rotate270FlipXY"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipXY)
            Case "Rotate270FlipY"
                bm_out.RotateFlip(RotateFlipType.Rotate270FlipY)

            Case "Rotate90FlipNone"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case "Rotate90FlipX"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipX)
            Case "Rotate90FlipXY"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipXY)
            Case "Rotate90FlipY"
                bm_out.RotateFlip(RotateFlipType.Rotate90FlipY)

            Case "RotateNoneFlipNone"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipNone)
            Case "RotateNoneFlipX"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Case "RotateNoneFlipXY"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipXY)
            Case "RotateNoneFlipY"
                bm_out.RotateFlip(RotateFlipType.RotateNoneFlipY)
        End Select

        ' Display the result.
        'picDest.Image = bm_out
        'Me.BackgroundImage = bm_Out
        Return bm_out
    End Function
    '
    '
    '
    Public Function Get_RandomNumber(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    '
    ' DO NOT USE THIS ONE 
    Public Function Get_RandomValue(ByVal lowerbound As Integer, ByVal upperbound As Integer)
        Randomize()
        Dim randomValue As Single = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        Return randomValue
    End Function
    '
    '
    Public Function GetRandom(ByVal min As Integer, ByVal max As Integer) As Integer
        Static staticRandomGenerator As New System.Random
        max += 1
        Return staticRandomGenerator.Next(If(min > max, max, min), If(min > max, min, max))
    End Function
    '
    '
    Public Sub Center_Form(ByVal F As Form)

    End Sub
    '
    '
    Public Function BitmapToString(ByVal bImage As Bitmap) As String
        Try
            Dim data As String
            Dim ms As MemoryStream = New MemoryStream
            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            data = Convert.ToBase64String(ms.ToArray())
            Return data
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    '
    '
End Module

