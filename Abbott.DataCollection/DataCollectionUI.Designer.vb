<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataCollectionUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButtonProcessData = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LabelPleaseWait = New System.Windows.Forms.Label()
        Me.LabelProgressDetails = New System.Windows.Forms.Label()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.ButtonOpenLogReader = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonProcessData
        '
        Me.ButtonProcessData.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonProcessData.Location = New System.Drawing.Point(86, 81)
        Me.ButtonProcessData.Name = "ButtonProcessData"
        Me.ButtonProcessData.Size = New System.Drawing.Size(116, 23)
        Me.ButtonProcessData.TabIndex = 0
        Me.ButtonProcessData.Text = "Process Data"
        Me.ButtonProcessData.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 44)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(312, 10)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 1
        '
        'LabelPleaseWait
        '
        Me.LabelPleaseWait.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPleaseWait.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPleaseWait.Location = New System.Drawing.Point(12, 7)
        Me.LabelPleaseWait.Name = "LabelPleaseWait"
        Me.LabelPleaseWait.Size = New System.Drawing.Size(309, 15)
        Me.LabelPleaseWait.TabIndex = 2
        Me.LabelPleaseWait.Text = "Processing data. Please wait..."
        Me.LabelPleaseWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelProgressDetails
        '
        Me.LabelProgressDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelProgressDetails.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgressDetails.Location = New System.Drawing.Point(9, 22)
        Me.LabelProgressDetails.Name = "LabelProgressDetails"
        Me.LabelProgressDetails.Size = New System.Drawing.Size(312, 15)
        Me.LabelProgressDetails.TabIndex = 3
        Me.LabelProgressDetails.Text = "process details"
        Me.LabelProgressDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundWorker
        '
        Me.BackgroundWorker.WorkerReportsProgress = True
        '
        'ButtonOpenLogReader
        '
        Me.ButtonOpenLogReader.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenLogReader.Location = New System.Drawing.Point(208, 81)
        Me.ButtonOpenLogReader.Name = "ButtonOpenLogReader"
        Me.ButtonOpenLogReader.Size = New System.Drawing.Size(116, 23)
        Me.ButtonOpenLogReader.TabIndex = 4
        Me.ButtonOpenLogReader.Text = "Open Log Reader"
        Me.ButtonOpenLogReader.UseVisualStyleBackColor = True
        '
        'DataCollectionUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 112)
        Me.Controls.Add(Me.ButtonOpenLogReader)
        Me.Controls.Add(Me.LabelProgressDetails)
        Me.Controls.Add(Me.LabelPleaseWait)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonProcessData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DataCollectionUI"
        Me.Text = "Data Collection"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonProcessData As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents LabelPleaseWait As Label
    Friend WithEvents LabelProgressDetails As Label
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ButtonOpenLogReader As Button
End Class
