Imports MySql.Data.MySqlClient

Public Class ArchiveForm
    Private dt As DataTable
    Private parentForm As RecordsForm ' Reference to parent form for refreshing

    ' Constructor with parent form reference
    Public Sub New(Optional parent As RecordsForm = Nothing)
        ' This call is required by the designer
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call
        parentForm = parent
    End Sub

    ' Form Load Event
    Private Sub ArchiveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(600, 400)
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Configure DataGridView
        dgvArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvArchive.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvArchive.MultiSelect = False
        dgvArchive.ReadOnly = True

        ' Load archived data
        LoadArchiveData()
    End Sub

    ' Load archived student records from database
    Private Sub LoadArchiveData()
        Try
            ' Get archived data using DatabaseManager
            dt = DatabaseManager.GetArchiveData()

            ' Add computed FullName column for easier display
            If dt.Rows.Count > 0 AndAlso Not dt.Columns.Contains("FullName") Then
                dt.Columns.Add("FullName", GetType(String))
                For Each row As DataRow In dt.Rows
                    Dim fullName As String = row("FirstName").ToString() & " "
                    If Not String.IsNullOrWhiteSpace(row("MiddleName").ToString()) Then
                        fullName += row("MiddleName").ToString() & " "
                    End If
                    fullName += row("LastName").ToString()
                    If Not String.IsNullOrWhiteSpace(row("Suffix").ToString()) Then
                        fullName += " " & row("Suffix").ToString()
                    End If
                    row("FullName") = fullName.Trim()
                Next
            End If

            ' Bind to DataGridView
            dgvArchive.DataSource = dt

            ' Hide detailed columns for better overview
            HideDetailedColumns()

            ' Update button states
            UpdateButtonStates()

            ' Update title to show count
            lblTitle.Text = $"Archived Student Records ({dt.Rows.Count} records)"

        Catch ex As Exception
            MessageBox.Show("Error loading archived records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Hide columns that are too detailed for the overview
    Private Sub HideDetailedColumns()
        Try
            ' Hide individual name components since we have FullName
            If dgvArchive.Columns.Contains("FirstName") Then dgvArchive.Columns("FirstName").Visible = False
            If dgvArchive.Columns.Contains("MiddleName") Then dgvArchive.Columns("MiddleName").Visible = False
            If dgvArchive.Columns.Contains("LastName") Then dgvArchive.Columns("LastName").Visible = False
            If dgvArchive.Columns.Contains("Suffix") Then dgvArchive.Columns("Suffix").Visible = False

            ' Hide detailed address and family info
            If dgvArchive.Columns.Contains("PlaceOfBirth") Then dgvArchive.Columns("PlaceOfBirth").Visible = False
            If dgvArchive.Columns.Contains("Phone") Then dgvArchive.Columns("Phone").Visible = False
            If dgvArchive.Columns.Contains("Email") Then dgvArchive.Columns("Email").Visible = False
            If dgvArchive.Columns.Contains("MotherName") Then dgvArchive.Columns("MotherName").Visible = False
            If dgvArchive.Columns.Contains("MotherAddress") Then dgvArchive.Columns("MotherAddress").Visible = False
            If dgvArchive.Columns.Contains("MotherPhone") Then dgvArchive.Columns("MotherPhone").Visible = False
            If dgvArchive.Columns.Contains("MotherOccupation") Then dgvArchive.Columns("MotherOccupation").Visible = False
            If dgvArchive.Columns.Contains("FatherName") Then dgvArchive.Columns("FatherName").Visible = False
            If dgvArchive.Columns.Contains("FatherAddress") Then dgvArchive.Columns("FatherAddress").Visible = False
            If dgvArchive.Columns.Contains("FatherPhone") Then dgvArchive.Columns("FatherPhone").Visible = False
            If dgvArchive.Columns.Contains("FatherOccupation") Then dgvArchive.Columns("FatherOccupation").Visible = False
            If dgvArchive.Columns.Contains("GuardianName") Then dgvArchive.Columns("GuardianName").Visible = False
            If dgvArchive.Columns.Contains("GuardianPhone") Then dgvArchive.Columns("GuardianPhone").Visible = False
            If dgvArchive.Columns.Contains("GuardianOccupation") Then dgvArchive.Columns("GuardianOccupation").Visible = False

            ' Set column headers to be more user-friendly
            If dgvArchive.Columns.Contains("StudentID") Then dgvArchive.Columns("StudentID").HeaderText = "Student ID"
            If dgvArchive.Columns.Contains("FullName") Then dgvArchive.Columns("FullName").HeaderText = "Full Name"
            If dgvArchive.Columns.Contains("DOB") Then dgvArchive.Columns("DOB").HeaderText = "Date of Birth"
            If dgvArchive.Columns.Contains("YearLevel") Then dgvArchive.Columns("YearLevel").HeaderText = "Year Level"
            If dgvArchive.Columns.Contains("ArchivedDate") Then dgvArchive.Columns("ArchivedDate").HeaderText = "Archived Date"
        Catch ex As Exception
            ' Ignore column visibility errors - they might not exist
        End Try
    End Sub

    ' Update button states based on selection
    Private Sub UpdateButtonStates()
        Dim hasSelection As Boolean = dgvArchive.SelectedRows.Count > 0
        btnRestore.Enabled = hasSelection
        btnDelete.Enabled = hasSelection
    End Sub

    ' DataGridView selection changed event
    Private Sub dgvArchive_SelectionChanged(sender As Object, e As EventArgs) Handles dgvArchive.SelectionChanged
        UpdateButtonStates()
    End Sub

    ' Restore selected record back to students table
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If dgvArchive.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to restore.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvArchive.SelectedRows(0)
        Dim studentID As String = selectedRow.Cells("StudentID").Value.ToString()
        Dim fullName As String = ""

        ' Get student name for confirmation message
        If dgvArchive.Columns.Contains("FullName") Then
            Dim cell = selectedRow.Cells("FullName")
            If cell IsNot Nothing AndAlso Not IsDBNull(cell.Value) Then
                fullName = cell.Value.ToString()
            End If
        End If

        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to restore this student record back to active records?" & vbCrLf &
            $"Student: {fullName}",
            "Confirm Restore",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Try
                ' Restore using DatabaseManager
                If DatabaseManager.RestoreFromArchive(studentID) Then
                    MessageBox.Show("Student record restored successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadArchiveData() ' Refresh the archive display

                    ' Refresh parent form if available
                    If parentForm IsNot Nothing Then
                        parentForm.RefreshRecords()
                    End If
                Else
                    MessageBox.Show("Failed to restore student record. The Student ID might already exist in active records.", "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Error restoring record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Permanently delete selected record from archive
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvArchive.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to delete permanently.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvArchive.SelectedRows(0)
        Dim studentID As String = selectedRow.Cells("StudentID").Value.ToString()
        Dim fullName As String = ""

        ' Get student name for confirmation message
        If dgvArchive.Columns.Contains("FullName") Then
            Dim cell = selectedRow.Cells("FullName")
            If cell IsNot Nothing AndAlso Not IsDBNull(cell.Value) Then
                fullName = cell.Value.ToString()
            End If
        End If

        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to PERMANENTLY DELETE this record?" & vbCrLf &
            $"Student: {fullName}" & vbCrLf & vbCrLf &
            "This action CANNOT be undone!",
            "Confirm Permanent Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                ' Delete permanently using DatabaseManager
                If DatabaseManager.DeleteFromArchive(studentID) Then
                    MessageBox.Show("Student record permanently deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadArchiveData() ' Refresh the display
                Else
                    MessageBox.Show("Failed to delete student record from archive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Refresh the archive data
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadArchiveData()
        MessageBox.Show("Archive records refreshed successfully!", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Close the form
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Form closing event
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        ' Clean up resources if needed
        MyBase.OnFormClosing(e)
    End Sub

End Class