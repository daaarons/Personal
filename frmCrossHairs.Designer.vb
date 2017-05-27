<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrossHairs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmsMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmSelectCHLBL = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmBackGroundImageBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPictureBoxImageBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmGDIImageBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmCloseBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsMain
        '
        Me.cmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSelectCHLBL, Me.ToolStripSeparator1, Me.tsmBackGroundImageBTN, Me.tsmPictureBoxImageBTN, Me.tsmGDIImageBTN, Me.ToolStripSeparator2, Me.tsmCloseBTN})
        Me.cmsMain.Name = "cmsMain"
        Me.cmsMain.Size = New System.Drawing.Size(168, 148)
        '
        'tsmSelectCHLBL
        '
        Me.tsmSelectCHLBL.Name = "tsmSelectCHLBL"
        Me.tsmSelectCHLBL.Size = New System.Drawing.Size(167, 22)
        Me.tsmSelectCHLBL.Text = "Select Cross Hairs"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(164, 6)
        '
        'tsmBackGroundImageBTN
        '
        Me.tsmBackGroundImageBTN.Name = "tsmBackGroundImageBTN"
        Me.tsmBackGroundImageBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmBackGroundImageBTN.Text = "BackGround "
        '
        'tsmPictureBoxImageBTN
        '
        Me.tsmPictureBoxImageBTN.Name = "tsmPictureBoxImageBTN"
        Me.tsmPictureBoxImageBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmPictureBoxImageBTN.Text = "PictureBox"
        '
        'tsmGDIImageBTN
        '
        Me.tsmGDIImageBTN.Name = "tsmGDIImageBTN"
        Me.tsmGDIImageBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmGDIImageBTN.Text = "GDI"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(164, 6)
        '
        'tsmCloseBTN
        '
        Me.tsmCloseBTN.Name = "tsmCloseBTN"
        Me.tsmCloseBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmCloseBTN.Text = "Close"
        '
        'frmCrossHairs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Name = "frmCrossHairs"
        Me.Text = "frmCrossHairs"
        Me.cmsMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmsMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmSelectCHLBL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBackGroundImageBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPictureBoxImageBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmGDIImageBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmCloseBTN As System.Windows.Forms.ToolStripMenuItem
End Class
