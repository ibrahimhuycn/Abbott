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
        Me.ProgressBarDataProcess = New System.Windows.Forms.ProgressBar()
        Me.LabelDataProcessDisplay = New System.Windows.Forms.Label()
        Me.BackgroundWorkerLogProcessor = New System.ComponentModel.BackgroundWorker()
        Me.LabelDataUpload = New System.Windows.Forms.Label()
        Me.ProgressBarDataUpload = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'ButtonProcessFiles
        '
        Me.ButtonProcessFiles.Location = New System.Drawing.Point(88, 80)
        Me.ButtonProcessFiles.Name = "ButtonProcessFiles"
        Me.ButtonProcessFiles.Size = New System.Drawing.Size(101, 23)
        Me.ButtonProcessFiles.TabIndex = 0
        Me.ButtonProcessFiles.Text = "Process Files"
        Me.ButtonProcessFiles.UseVisualStyleBackColor = True
        '
        'ProgressBarDataProcess
        '
        Me.ProgressBarDataProcess.Location = New System.Drawing.Point(12, 23)
        Me.ProgressBarDataProcess.Name = "ProgressBarDataProcess"
        Me.ProgressBarDataProcess.Size = New System.Drawing.Size(265, 16)
        Me.ProgressBarDataProcess.Step = 1
        Me.ProgressBarDataProcess.TabIndex = 1
        '
        'LabelDataProcessDisplay
        '
        Me.LabelDataProcessDisplay.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataProcessDisplay.Location = New System.Drawing.Point(12, 6)
        Me.LabelDataProcessDisplay.Name = "LabelDataProcessDisplay"
        Me.LabelDataProcessDisplay.Size = New System.Drawing.Size(265, 14)
        Me.LabelDataProcessDisplay.TabIndex = 2
        Me.LabelDataProcessDisplay.Text = "DataProcessDisplay"
        '
        'BackgroundWorkerLogProcessor
        '
        Me.BackgroundWorkerLogProcessor.WorkerReportsProgress = True
        '
        'LabelDataUpload
        '
        Me.LabelDataUpload.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataUpload.Location = New System.Drawing.Point(12, 41)
        Me.LabelDataUpload.Name = "LabelDataUpload"
        Me.LabelDataUpload.Size = New System.Drawing.Size(265, 14)
        Me.LabelDataUpload.TabIndex = 4
        Me.LabelDataUpload.Text = "Data Upload Process"
        '
        'ProgressBarDataUpload
        '
        Me.ProgressBarDataUpload.Location = New System.Drawing.Point(12, 58)
        Me.ProgressBarDataUpload.Name = "ProgressBarDataUpload"
        Me.ProgressBarDataUpload.Size = New System.Drawing.Size(265, 16)
        Me.ProgressBarDataUpload.Step = 1
        Me.ProgressBarDataUpload.TabIndex = 3
        '
        'FileProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 109)
        Me.Controls.Add(Me.LabelDataUpload)
        Me.Controls.Add(Me.ProgressBarDataUpload)
        Me.Controls.Add(Me.LabelDataProcessDisplay)
        Me.Controls.Add(Me.ProgressBarDataProcess)
        Me.Controls.Add(Me.ButtonProcessFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FileProcessing"
        Me.Text = "FileProcessing"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonProcessFiles As Button
    Friend WithEvents ProgressBarDataProcess As ProgressBar
    Friend WithEvents LabelDataProcessDisplay As Label
    Friend WithEvents BackgroundWorkerLogProcessor As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelDataUpload As Label
    Friend WithEvents ProgressBarDataUpload As ProgressBar
End Class
