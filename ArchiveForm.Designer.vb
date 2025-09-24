<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArchiveForm
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
        pnlTop = New Panel()
        lblTitle = New Label()
        dgvArchive = New DataGridView()
        pnlBottom = New Panel()
        btnClose = New Button()
        btnRefresh = New Button()
        btnDelete = New Button()
        btnRestore = New Button()
        txtSearchArchive = New TextBox()
        btnSearchArchive = New Button()
        pnlTop.SuspendLayout()
        CType(dgvArchive, ComponentModel.ISupportInitialize).BeginInit()
        pnlBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTop
        ' 
        pnlTop.Controls.Add(lblTitle)
        pnlTop.Dock = DockStyle.Top
        pnlTop.Location = New Point(0, 0)
        pnlTop.Name = "pnlTop"
        pnlTop.Size = New Size(920, 60)
        pnlTop.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(20, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(308, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Archived Student Records"
        ' 
        ' dgvArchive
        ' 
        dgvArchive.AllowUserToAddRows = False
        dgvArchive.AllowUserToDeleteRows = False
        dgvArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvArchive.BackgroundColor = SystemColors.ControlLight
        dgvArchive.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvArchive.Dock = DockStyle.Fill
        dgvArchive.Location = New Point(0, 60)
        dgvArchive.MultiSelect = False
        dgvArchive.Name = "dgvArchive"
        dgvArchive.ReadOnly = True
        dgvArchive.RowHeadersWidth = 51
        dgvArchive.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvArchive.Size = New Size(920, 470)
        dgvArchive.TabIndex = 1
        ' 
        ' pnlBottom
        ' 
        pnlBottom.Controls.Add(btnClose)
        pnlBottom.Controls.Add(btnRefresh)
        pnlBottom.Controls.Add(btnDelete)
        pnlBottom.Controls.Add(btnRestore)
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(0, 530)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(920, 70)
        pnlBottom.TabIndex = 2
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.Location = New Point(770, 15)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 40)
        btnClose.TabIndex = 3
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(330, 15)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 40)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(156, 15)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(168, 40)
        btnDelete.TabIndex = 1
        btnDelete.Text = "Delete Permanently"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnRestore
        ' 
        btnRestore.Location = New Point(20, 15)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(130, 40)
        btnRestore.TabIndex = 0
        btnRestore.Text = "Restore Selected"
        btnRestore.UseVisualStyleBackColor = True
        ' 
        ' txtSearchArchive
        ' 
        txtSearchArchive.Location = New Point(23, 20)
        txtSearchArchive.Name = "txtSearchArchive"
        txtSearchArchive.Size = New Size(200, 27)
        txtSearchArchive.TabIndex = 0
        ' 
        ' btnSearchArchive
        ' 
        btnSearchArchive.Location = New Point(230, 20)
        btnSearchArchive.Name = "btnSearchArchive"
        btnSearchArchive.Size = New Size(80, 27)
        btnSearchArchive.TabIndex = 1
        btnSearchArchive.Text = "Search"
        btnSearchArchive.UseVisualStyleBackColor = True
        ' 
        ' ArchiveForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(920, 600)
        Controls.Add(dgvArchive)
        Controls.Add(pnlBottom)
        Controls.Add(pnlTop)
        Controls.Add(txtSearchArchive)
        Controls.Add(btnSearchArchive)
        MinimumSize = New Size(600, 400)
        Name = "ArchiveForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Archived Student Records"
        pnlTop.ResumeLayout(False)
        pnlTop.PerformLayout()
        CType(dgvArchive, ComponentModel.ISupportInitialize).EndInit()
        pnlBottom.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents dgvArchive As DataGridView
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnRestore As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtSearchArchive As TextBox
    Friend WithEvents btnSearchArchive As Button
End Class