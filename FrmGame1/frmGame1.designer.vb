<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGame1
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
        Me.tsmEditFormBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmCrossHairsLBL = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCrossHairsBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCrossHairsStopTrackingMouseBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCrossHairsCloseBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmShowHideControlsBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmMoveModeBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSizeModeBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmWxHModeBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.panControls = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.nudSR = New System.Windows.Forms.NumericUpDown()
        Me.tbSR = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSR = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picWxH = New System.Windows.Forms.PictureBox()
        Me.picSizeMode = New System.Windows.Forms.PictureBox()
        Me.picMoveMode = New System.Windows.Forms.PictureBox()
        Me.cmsMain.SuspendLayout()
        Me.panControls.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nudSR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.picWxH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSizeMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMoveMode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmsMain
        '
        Me.cmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmEditFormBTN, Me.ToolStripSeparator2, Me.tsmCrossHairsLBL, Me.tsmCrossHairsBTN, Me.tsmCrossHairsStopTrackingMouseBTN, Me.tsmCrossHairsCloseBTN, Me.ToolStripSeparator1, Me.tsmShowHideControlsBTN, Me.tsmMoveModeBTN, Me.tsmSizeModeBTN, Me.tsmWxHModeBTN})
        Me.cmsMain.Name = "cmsMain"
        Me.cmsMain.Size = New System.Drawing.Size(186, 214)
        '
        'tsmEditFormBTN
        '
        Me.tsmEditFormBTN.Name = "tsmEditFormBTN"
        Me.tsmEditFormBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmEditFormBTN.Text = "Edit Form"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(182, 6)
        '
        'tsmCrossHairsLBL
        '
        Me.tsmCrossHairsLBL.Enabled = False
        Me.tsmCrossHairsLBL.Name = "tsmCrossHairsLBL"
        Me.tsmCrossHairsLBL.Size = New System.Drawing.Size(185, 22)
        Me.tsmCrossHairsLBL.Text = "CrossHairs"
        '
        'tsmCrossHairsBTN
        '
        Me.tsmCrossHairsBTN.Name = "tsmCrossHairsBTN"
        Me.tsmCrossHairsBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmCrossHairsBTN.Text = "Cross Hairs Show"
        '
        'tsmCrossHairsStopTrackingMouseBTN
        '
        Me.tsmCrossHairsStopTrackingMouseBTN.Name = "tsmCrossHairsStopTrackingMouseBTN"
        Me.tsmCrossHairsStopTrackingMouseBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmCrossHairsStopTrackingMouseBTN.Text = "Stop Tracking Mouse"
        '
        'tsmCrossHairsCloseBTN
        '
        Me.tsmCrossHairsCloseBTN.Name = "tsmCrossHairsCloseBTN"
        Me.tsmCrossHairsCloseBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmCrossHairsCloseBTN.Text = "Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(182, 6)
        '
        'tsmShowHideControlsBTN
        '
        Me.tsmShowHideControlsBTN.Name = "tsmShowHideControlsBTN"
        Me.tsmShowHideControlsBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmShowHideControlsBTN.Text = "Show/Hide Controls"
        '
        'tsmMoveModeBTN
        '
        Me.tsmMoveModeBTN.Name = "tsmMoveModeBTN"
        Me.tsmMoveModeBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmMoveModeBTN.Text = "Move Mode ON"
        '
        'tsmSizeModeBTN
        '
        Me.tsmSizeModeBTN.Name = "tsmSizeModeBTN"
        Me.tsmSizeModeBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmSizeModeBTN.Text = "Size Mode ON"
        '
        'tsmWxHModeBTN
        '
        Me.tsmWxHModeBTN.Name = "tsmWxHModeBTN"
        Me.tsmWxHModeBTN.Size = New System.Drawing.Size(185, 22)
        Me.tsmWxHModeBTN.Text = "WxH Mode ON"
        '
        'panControls
        '
        Me.panControls.BackColor = System.Drawing.Color.Navy
        Me.panControls.Controls.Add(Me.Panel1)
        Me.panControls.Controls.Add(Me.Label11)
        Me.panControls.Controls.Add(Me.picWxH)
        Me.panControls.Controls.Add(Me.Label10)
        Me.panControls.Controls.Add(Me.Label9)
        Me.panControls.Controls.Add(Me.Panel2)
        Me.panControls.Controls.Add(Me.picSizeMode)
        Me.panControls.Controls.Add(Me.picMoveMode)
        Me.panControls.Controls.Add(Me.lblName)
        Me.panControls.Controls.Add(Me.Label7)
        Me.panControls.Controls.Add(Me.lblSR)
        Me.panControls.Controls.Add(Me.lblLocation)
        Me.panControls.Controls.Add(Me.lblSize)
        Me.panControls.Controls.Add(Me.Label5)
        Me.panControls.Controls.Add(Me.Label4)
        Me.panControls.Controls.Add(Me.Label3)
        Me.panControls.Controls.Add(Me.Label2)
        Me.panControls.Controls.Add(Me.Label1)
        Me.panControls.Location = New System.Drawing.Point(264, 166)
        Me.panControls.Name = "panControls"
        Me.panControls.Size = New System.Drawing.Size(360, 254)
        Me.panControls.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.nudSR)
        Me.Panel1.Controls.Add(Me.tbSR)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(191, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 74)
        Me.Panel1.TabIndex = 22
        '
        'nudSR
        '
        Me.nudSR.Location = New System.Drawing.Point(3, 3)
        Me.nudSR.Name = "nudSR"
        Me.nudSR.Size = New System.Drawing.Size(44, 20)
        Me.nudSR.TabIndex = 10
        '
        'tbSR
        '
        Me.tbSR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbSR.Location = New System.Drawing.Point(53, 3)
        Me.tbSR.Name = "tbSR"
        Me.tbSR.Size = New System.Drawing.Size(104, 45)
        Me.tbSR.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(62, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "NN"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(102, 199)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "WxH"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(55, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "SR"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(4, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 16)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Loc"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.cmbElement)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 225)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 29)
        Me.Panel2.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(4, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Select Element"
        '
        'cmbElement
        '
        Me.cmbElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.Location = New System.Drawing.Point(219, 4)
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(92, 21)
        Me.cmbElement.TabIndex = 16
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Navy
        Me.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Yellow
        Me.lblName.Location = New System.Drawing.Point(93, 102)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(49, 16)
        Me.lblName.TabIndex = 9
        Me.lblName.Text = "Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(93, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Label7"
        '
        'lblSR
        '
        Me.lblSR.AutoSize = True
        Me.lblSR.BackColor = System.Drawing.Color.Navy
        Me.lblSR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSR.ForeColor = System.Drawing.Color.Yellow
        Me.lblSR.Location = New System.Drawing.Point(93, 51)
        Me.lblSR.Name = "lblSR"
        Me.lblSR.Size = New System.Drawing.Size(29, 16)
        Me.lblSR.TabIndex = 7
        Me.lblSR.Text = "SR"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.BackColor = System.Drawing.Color.Navy
        Me.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.Yellow
        Me.lblLocation.Location = New System.Drawing.Point(93, 28)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(67, 16)
        Me.lblLocation.TabIndex = 6
        Me.lblLocation.Text = "Location"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.BackColor = System.Drawing.Color.Navy
        Me.lblSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.ForeColor = System.Drawing.Color.Yellow
        Me.lblSize.Location = New System.Drawing.Point(93, 4)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(38, 16)
        Me.lblSize.TabIndex = 5
        Me.lblSize.Text = "Size"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(4, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(4, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(4, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "SR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(4, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Location"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Size"
        '
        'picWxH
        '
        Me.picWxH.Location = New System.Drawing.Point(101, 160)
        Me.picWxH.Name = "picWxH"
        Me.picWxH.Size = New System.Drawing.Size(30, 30)
        Me.picWxH.TabIndex = 20
        Me.picWxH.TabStop = False
        '
        'picSizeMode
        '
        Me.picSizeMode.Location = New System.Drawing.Point(53, 160)
        Me.picSizeMode.Name = "picSizeMode"
        Me.picSizeMode.Size = New System.Drawing.Size(30, 30)
        Me.picSizeMode.TabIndex = 14
        Me.picSizeMode.TabStop = False
        '
        'picMoveMode
        '
        Me.picMoveMode.Location = New System.Drawing.Point(7, 160)
        Me.picMoveMode.Name = "picMoveMode"
        Me.picMoveMode.Size = New System.Drawing.Size(30, 30)
        Me.picMoveMode.TabIndex = 13
        Me.picMoveMode.TabStop = False
        '
        'frmGame1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 549)
        Me.Controls.Add(Me.panControls)
        Me.Name = "frmGame1"
        Me.Text = "Form1"
        Me.cmsMain.ResumeLayout(False)
        Me.panControls.ResumeLayout(False)
        Me.panControls.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudSR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picWxH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSizeMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMoveMode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmsMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmMoveModeBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nudSR As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSR As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbSR As System.Windows.Forms.TrackBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tsmSizeModeBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tsmShowHideControlsBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tsmWxHModeBTN As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents cmbElement As System.Windows.Forms.ComboBox
    Friend WithEvents tsmEditFormBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents picSizeMode As System.Windows.Forms.PictureBox
    Public WithEvents picMoveMode As System.Windows.Forms.PictureBox
    Public WithEvents picWxH As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmCrossHairsBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCrossHairsLBL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCrossHairsStopTrackingMouseBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCrossHairsCloseBTN As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents panControls As System.Windows.Forms.Panel

End Class
