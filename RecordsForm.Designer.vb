<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RecordsForm
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
        txtSearch = New TextBox()
        btnSearch = New Button()
        dgvRecords = New DataGridView()
        pnlBottom = New Panel()
        btnUpdate = New Button()
        btnArchive = New Button()
        btnRefresh = New Button()
        btnBack = New Button()
        pnlTop.SuspendLayout()
        CType(dgvRecords, ComponentModel.ISupportInitialize).BeginInit()
        pnlBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTop
        ' 
        pnlTop.Controls.Add(txtSearch)
        pnlTop.Controls.Add(btnSearch)
        pnlTop.Dock = DockStyle.Top
        pnlTop.Location = New Point(0, 0)
        pnlTop.Margin = New Padding(3, 4, 3, 4)
        pnlTop.Name = "pnlTop"
        pnlTop.Size = New Size(914, 67)
        pnlTop.TabIndex = 0
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearch.Location = New Point(23, 20)
        txtSearch.Margin = New Padding(3, 4, 3, 4)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(685, 27)
        txtSearch.TabIndex = 0
        ' 
        ' btnSearch
        ' 
        btnSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSearch.Location = New Point(731, 20)
        btnSearch.Margin = New Padding(3, 4, 3, 4)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(137, 31)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' dgvRecords
        ' 
        dgvRecords.AllowUserToAddRows = False
        dgvRecords.AllowUserToDeleteRows = False
        dgvRecords.BackgroundColor = SystemColors.ControlLight
        dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRecords.Dock = DockStyle.Fill
        dgvRecords.Location = New Point(0, 67)
        dgvRecords.Margin = New Padding(3, 4, 3, 4)
        dgvRecords.Name = "dgvRecords"
        dgvRecords.RowHeadersWidth = 51
        dgvRecords.Size = New Size(914, 533)
        dgvRecords.TabIndex = 1
        ' 
        ' pnlBottom
        ' 
        pnlBottom.Controls.Add(btnUpdate)
        pnlBottom.Controls.Add(btnArchive)
        pnlBottom.Controls.Add(btnRefresh)
        pnlBottom.Controls.Add(btnBack)
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(0, 600)
        pnlBottom.Margin = New Padding(3, 4, 3, 4)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(914, 80)
        pnlBottom.TabIndex = 2
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnUpdate.Location = New Point(23, 20)
        btnUpdate.Margin = New Padding(3, 4, 3, 4)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(137, 40)
        btnUpdate.TabIndex = 0
        btnUpdate.Text = "Update Record"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnArchive
        ' 
        btnArchive.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnArchive.Location = New Point(183, 20)
        btnArchive.Margin = New Padding(3, 4, 3, 4)
        btnArchive.Name = "btnArchive"
        btnArchive.Size = New Size(137, 40)
        btnArchive.TabIndex = 1
        btnArchive.Text = "Archive Record"
        btnArchive.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(343, 20)
        btnRefresh.Margin = New Padding(3, 4, 3, 4)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(137, 40)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "Refresh Data"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnBack.Location = New Point(731, 20)
        btnBack.Margin = New Padding(3, 4, 3, 4)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(160, 40)
        btnBack.TabIndex = 3
        btnBack.Text = "Back to Registration"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' RecordsForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 680)
        Controls.Add(dgvRecords)
        Controls.Add(pnlBottom)
        Controls.Add(pnlTop)
        Margin = New Padding(3, 4, 3, 4)
        Name = "RecordsForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Student Records"
        pnlTop.ResumeLayout(False)
        pnlTop.PerformLayout()
        CType(dgvRecords, ComponentModel.ISupportInitialize).EndInit()
        pnlBottom.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dgvRecords As DataGridView
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnArchive As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnBack As Button
End Class
