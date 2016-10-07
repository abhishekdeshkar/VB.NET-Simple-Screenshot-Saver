<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btncapture = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.clicktimer = New System.Windows.Forms.Timer(Me.components)
        Me.checkurl = New System.Windows.Forms.Timer(Me.components)
        Me.Timerwindow = New System.Windows.Forms.Timer(Me.components)
        Me.hell = New System.Windows.Forms.RichTextBox()
        Me.TimerSave = New System.Windows.Forms.Timer(Me.components)
        Me.TimerCheckDigits = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btncapture
        '
        Me.btncapture.Location = New System.Drawing.Point(5, 9)
        Me.btncapture.Name = "btncapture"
        Me.btncapture.Size = New System.Drawing.Size(93, 26)
        Me.btncapture.TabIndex = 0
        Me.btncapture.Text = "Capture"
        Me.btncapture.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(145, 17)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(57, 12)
        Me.btnsave.TabIndex = 1
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(5, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(155, 143)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'clicktimer
        '
        Me.clicktimer.Interval = 1000
        '
        'checkurl
        '
        Me.checkurl.Enabled = True
        Me.checkurl.Interval = 2000
        '
        'Timerwindow
        '
        Me.Timerwindow.Enabled = True
        Me.Timerwindow.Interval = 20
        '
        'hell
        '
        Me.hell.Location = New System.Drawing.Point(0, 0)
        Me.hell.Name = "hell"
        Me.hell.Size = New System.Drawing.Size(10, 10)
        Me.hell.TabIndex = 3
        Me.hell.Text = ""
        '
        'TimerSave
        '
        Me.TimerSave.Enabled = True
        Me.TimerSave.Interval = 30000
        '
        'TimerCheckDigits
        '
        Me.TimerCheckDigits.Enabled = True
        Me.TimerCheckDigits.Interval = 2000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(10, 10)
        Me.Controls.Add(Me.hell)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncapture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btncapture As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents clicktimer As System.Windows.Forms.Timer
    Friend WithEvents checkurl As System.Windows.Forms.Timer
    Friend WithEvents Timerwindow As System.Windows.Forms.Timer
    Friend WithEvents hell As System.Windows.Forms.RichTextBox
    Friend WithEvents TimerSave As System.Windows.Forms.Timer
    Friend WithEvents TimerCheckDigits As System.Windows.Forms.Timer

End Class
