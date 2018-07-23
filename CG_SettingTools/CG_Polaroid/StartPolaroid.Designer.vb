<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartPolaroid
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_outlineborder = New System.Windows.Forms.CheckBox()
        Me.bt_Browse = New System.Windows.Forms.Button()
        Me.t_alamat = New System.Windows.Forms.TextBox()
        Me.statusstrip = New System.Windows.Forms.StatusStrip()
        Me.ts_progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.t_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btUndo = New System.Windows.Forms.Button()
        Me.btRedo = New System.Windows.Forms.Button()
        Me.btDelete = New System.Windows.Forms.Button()
        Me.bt_FittoFrame = New System.Windows.Forms.Button()
        Me.bt_RotateCounterClockwise = New System.Windows.Forms.Button()
        Me.bt_RotateClockwise = New System.Windows.Forms.Button()
        Me.folderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.bWorker = New System.ComponentModel.BackgroundWorker()
        Me.bt_Abort = New System.Windows.Forms.Button()
        Me.bt_CreatePolaroid = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.statusstrip.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_outlineborder)
        Me.GroupBox1.Controls.Add(Me.bt_Browse)
        Me.GroupBox1.Controls.Add(Me.t_alamat)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 76)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import Photo dari Folder"
        '
        'cb_outlineborder
        '
        Me.cb_outlineborder.AutoSize = True
        Me.cb_outlineborder.Location = New System.Drawing.Point(12, 49)
        Me.cb_outlineborder.Name = "cb_outlineborder"
        Me.cb_outlineborder.Size = New System.Drawing.Size(116, 17)
        Me.cb_outlineborder.TabIndex = 6
        Me.cb_outlineborder.Text = "Pakai Garis Outline"
        Me.cb_outlineborder.UseVisualStyleBackColor = True
        '
        'bt_Browse
        '
        Me.bt_Browse.Location = New System.Drawing.Point(251, 22)
        Me.bt_Browse.Name = "bt_Browse"
        Me.bt_Browse.Size = New System.Drawing.Size(67, 20)
        Me.bt_Browse.TabIndex = 1
        Me.bt_Browse.Text = "Cari..."
        Me.bt_Browse.UseVisualStyleBackColor = True
        '
        't_alamat
        '
        Me.t_alamat.Location = New System.Drawing.Point(12, 22)
        Me.t_alamat.Name = "t_alamat"
        Me.t_alamat.ReadOnly = True
        Me.t_alamat.Size = New System.Drawing.Size(233, 20)
        Me.t_alamat.TabIndex = 0
        '
        'statusstrip
        '
        Me.statusstrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_progress, Me.t_status})
        Me.statusstrip.Location = New System.Drawing.Point(0, 251)
        Me.statusstrip.Name = "statusstrip"
        Me.statusstrip.Size = New System.Drawing.Size(354, 22)
        Me.statusstrip.TabIndex = 2
        Me.statusstrip.Text = "StatusStrip1"
        '
        'ts_progress
        '
        Me.ts_progress.Name = "ts_progress"
        Me.ts_progress.Size = New System.Drawing.Size(100, 16)
        '
        't_status
        '
        Me.t_status.Name = "t_status"
        Me.t_status.Size = New System.Drawing.Size(39, 17)
        Me.t_status.Text = "Ready"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btUndo)
        Me.GroupBox2.Controls.Add(Me.btRedo)
        Me.GroupBox2.Controls.Add(Me.btDelete)
        Me.GroupBox2.Controls.Add(Me.bt_FittoFrame)
        Me.GroupBox2.Controls.Add(Me.bt_RotateCounterClockwise)
        Me.GroupBox2.Controls.Add(Me.bt_RotateClockwise)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 176)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 61)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tools"
        '
        'btUndo
        '
        Me.btUndo.Image = Global.CG_SettingTools.My.Resources.Resources.arrow_undo
        Me.btUndo.Location = New System.Drawing.Point(224, 19)
        Me.btUndo.Name = "btUndo"
        Me.btUndo.Size = New System.Drawing.Size(44, 36)
        Me.btUndo.TabIndex = 5
        Me.btUndo.UseVisualStyleBackColor = True
        '
        'btRedo
        '
        Me.btRedo.Image = Global.CG_SettingTools.My.Resources.Resources.arrow_redo
        Me.btRedo.Location = New System.Drawing.Point(274, 19)
        Me.btRedo.Name = "btRedo"
        Me.btRedo.Size = New System.Drawing.Size(44, 36)
        Me.btRedo.TabIndex = 4
        Me.btRedo.UseVisualStyleBackColor = True
        '
        'btDelete
        '
        Me.btDelete.Image = Global.CG_SettingTools.My.Resources.Resources.image_delete
        Me.btDelete.Location = New System.Drawing.Point(161, 19)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(44, 36)
        Me.btDelete.TabIndex = 3
        Me.btDelete.UseVisualStyleBackColor = True
        '
        'bt_FittoFrame
        '
        Me.bt_FittoFrame.Image = Global.CG_SettingTools.My.Resources.Resources.arrow_out
        Me.bt_FittoFrame.Location = New System.Drawing.Point(111, 19)
        Me.bt_FittoFrame.Name = "bt_FittoFrame"
        Me.bt_FittoFrame.Size = New System.Drawing.Size(44, 36)
        Me.bt_FittoFrame.TabIndex = 2
        Me.bt_FittoFrame.UseVisualStyleBackColor = True
        '
        'bt_RotateCounterClockwise
        '
        Me.bt_RotateCounterClockwise.Image = Global.CG_SettingTools.My.Resources.Resources.arrow_rotate_anticlockwise
        Me.bt_RotateCounterClockwise.Location = New System.Drawing.Point(61, 19)
        Me.bt_RotateCounterClockwise.Name = "bt_RotateCounterClockwise"
        Me.bt_RotateCounterClockwise.Size = New System.Drawing.Size(44, 36)
        Me.bt_RotateCounterClockwise.TabIndex = 1
        Me.bt_RotateCounterClockwise.UseVisualStyleBackColor = True
        '
        'bt_RotateClockwise
        '
        Me.bt_RotateClockwise.Image = Global.CG_SettingTools.My.Resources.Resources.arrow_rotate_clockwise
        Me.bt_RotateClockwise.Location = New System.Drawing.Point(11, 19)
        Me.bt_RotateClockwise.Name = "bt_RotateClockwise"
        Me.bt_RotateClockwise.Size = New System.Drawing.Size(44, 36)
        Me.bt_RotateClockwise.TabIndex = 0
        Me.bt_RotateClockwise.UseVisualStyleBackColor = True
        '
        'bWorker
        '
        Me.bWorker.WorkerReportsProgress = True
        Me.bWorker.WorkerSupportsCancellation = True
        '
        'bt_Abort
        '
        Me.bt_Abort.Enabled = False
        Me.bt_Abort.Location = New System.Drawing.Point(23, 138)
        Me.bt_Abort.Name = "bt_Abort"
        Me.bt_Abort.Size = New System.Drawing.Size(307, 32)
        Me.bt_Abort.TabIndex = 4
        Me.bt_Abort.Text = "Batalkan"
        Me.bt_Abort.UseVisualStyleBackColor = True
        '
        'bt_CreatePolaroid
        '
        Me.bt_CreatePolaroid.Location = New System.Drawing.Point(24, 100)
        Me.bt_CreatePolaroid.Name = "bt_CreatePolaroid"
        Me.bt_CreatePolaroid.Size = New System.Drawing.Size(306, 32)
        Me.bt_CreatePolaroid.TabIndex = 1
        Me.bt_CreatePolaroid.Text = "Buat Polaroid"
        Me.bt_CreatePolaroid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_CreatePolaroid.UseVisualStyleBackColor = True
        '
        'StartPolaroid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 273)
        Me.Controls.Add(Me.bt_Abort)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.statusstrip)
        Me.Controls.Add(Me.bt_CreatePolaroid)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "StartPolaroid"
        Me.ShowIcon = False
        Me.Text = "CG Polaroid v0.7"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.statusstrip.ResumeLayout(False)
        Me.statusstrip.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_Browse As System.Windows.Forms.Button
    Friend WithEvents t_alamat As System.Windows.Forms.TextBox
    Friend WithEvents bt_CreatePolaroid As System.Windows.Forms.Button
    Friend WithEvents statusstrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ts_progress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents t_status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents folderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents bWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents bt_Abort As System.Windows.Forms.Button
    Friend WithEvents bt_RotateCounterClockwise As System.Windows.Forms.Button
    Friend WithEvents bt_RotateClockwise As System.Windows.Forms.Button
    Friend WithEvents bt_FittoFrame As System.Windows.Forms.Button
    Friend WithEvents btDelete As System.Windows.Forms.Button
    Friend WithEvents btUndo As System.Windows.Forms.Button
    Friend WithEvents btRedo As System.Windows.Forms.Button
    Friend WithEvents cb_outlineborder As System.Windows.Forms.CheckBox
End Class
