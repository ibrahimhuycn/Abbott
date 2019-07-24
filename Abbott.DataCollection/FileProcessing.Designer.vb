<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileProcessing
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
        Me.ButtonProcessFiles = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LabelDataProcessDisplay = New System.Windows.Forms.Label()
        Me.BackgroundWorkerLogProcessor = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'ButtonProcessFiles
        '
        Me.ButtonProcessFiles.Location = New System.Drawing.Point(88, 42)
        Me.ButtonProcessFiles.Name = "ButtonProcessFiles"
        Me.ButtonProcessFiles.Size = New System.Drawing.Size(101, 23)
        Me.ButtonProcessFiles.TabIndex = 0
        Me.ButtonProcessFiles.Text = "Process Files"
        Me.ButtonProcessFiles.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 23)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(265, 16)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 1
        '
        'LabelDataProcessDisplay
        '
        Me.LabelDataProcessDisplay.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataProcessDisplay.Location = New System.Drawing.Point(12, 6)
        Me.LabelDataProcessDisplay.Name = "LabelDataProcessDisplay"
        Me.LabelDataProcessDisplay.Size = New System.Drawing.Size(265, 14)
        Me.LabelDataProcessDisplay.TabIndex = 2
        Me.LabelDataProcessDisplay.Text = "DataProcessDisplay"
        Me.LabelDataProcessDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BackgroundWorkerLogProcessor
        '
        Me.BackgroundWorkerLogProcessor.WorkerReportsProgress = True
        '
        'FileProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 69)
        Me.Controls.Add(Me.LabelDataProcessDisplay)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonProcessFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FileProcessing"
        Me.Text = "FileProcessing"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonProcessFiles As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents LabelDataProcessDisplay As Label
    Friend WithEvents BackgroundWorkerLogProcessor As System.ComponentModel.BackgroundWorker
End Class
