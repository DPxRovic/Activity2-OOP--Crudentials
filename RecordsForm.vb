Public Class RecordsForm
    Private dt As DataTable
    Private db As DatabaseManager

    Private Sub RecordsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(600, 400)
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.AutoSize = False
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Initialize database manager
        db = New DatabaseManager()

        ' Load data from database
        LoadStudentRecords()

        ' Configure DataGridView
        dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecords.MultiSelect = False
        dgvRecords.ReadOnly = True
    End Sub

    Private Sub LoadStudentRecords()
        Try
            ' Get all students from database
            dt = db.GetAllStudents()

            ' Add a computed FullName column for easier display
            If Not dt.Columns.Contains("FullName") Then
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
            dgvRecords.DataSource = dt

            ' Hide columns that might be too detailed for the overview
            If dgvRecords.Columns.Contains("MotherName") Then dgvRecords.Columns("MotherName").Visible = False
            If dgvRecords.Columns.Contains("MotherAddress") Then dgvRecords.Columns("MotherAddress").Visible = False
            If dgvRecords.Columns.Contains("MotherPhone") Then dgvRecords.Columns("MotherPhone").Visible = False
            If dgvRecords.Columns.Contains("MotherOccupation") Then dgvRecords.Columns("MotherOccupation").Visible = False
            If dgvRecords.Columns.Contains("FatherName") Then dgvRecords.Columns("FatherName").Visible = False
            If dgvRecords.Columns.Contains("FatherAddress") Then dgvRecords.Columns("FatherAddress").Visible = False
            If dgvRecords.Columns.Contains("FatherPhone") Then dgvRecords.Columns("FatherPhone").Visible = False
            If dgvRecords.Columns.Contains("FatherOccupation") Then dgvRecords.Columns("FatherOccupation").Visible = False
            If dgvRecords.Columns.Contains("GuardianName") Then dgvRecords.Columns("GuardianName").Visible = False
            If dgvRecords.Columns.Contains("GuardianPhone") Then dgvRecords.Columns("GuardianPhone").Visible = False
            If dgvRecords.Columns.Contains("GuardianOccupation") Then dgvRecords.Columns("GuardianOccupation").Visible = False
            If dgvRecords.Columns.Contains("FirstName") Then dgvRecords.Columns("FirstName").Visible = False
            If dgvRecords.Columns.Contains("MiddleName") Then dgvRecords.Columns("MiddleName").Visible = False
            If dgvRecords.Columns.Contains("LastName") Then dgvRecords.Columns("LastName").Visible = False
            If dgvRecords.Columns.Contains("Suffix") Then dgvRecords.Columns("Suffix").Visible = False
            If dgvRecords.Columns.Contains("PlaceOfBirth") Then dgvRecords.Columns("PlaceOfBirth").Visible = False
            If dgvRecords.Columns.Contains("Phone") Then dgvRecords.Columns("Phone").Visible = False
            If dgvRecords.Columns.Contains("Email") Then dgvRecords.Columns("Email").Visible = False

        Catch ex As Exception
            MessageBox.Show("Error loading student records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim filterText As String = txtSearch.Text.Trim()
        If String.IsNullOrWhiteSpace(filterText) Then
            MessageBox.Show("Please enter a Student ID or Name to search.")
            Return
        End If

        Try
            Dim foundRows() As DataRow = dt.Select($"StudentID LIKE '%{filterText}%' OR FullName LIKE '%{filterText}%'")
            If foundRows.Length > 0 Then
                dgvRecords.DataSource = foundRows.CopyToDataTable()
            Else
                MessageBox.Show("No matching records found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching records: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStudentRecords()
        MessageBox.Show("Records refreshed successfully!")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvRecords.SelectedRows.Count > 0 Then
            Try
                ' Get the selected row
                Dim selectedRow As DataGridViewRow = dgvRecords.SelectedRows(0)
                Dim studentID As String = selectedRow.Cells("StudentID").Value.ToString()

                ' Find the corresponding DataRow in the DataTable
                Dim studentRecord As DataRow = Nothing
                For Each row As DataRow In dt.Rows
                    If row("StudentID").ToString() = studentID Then
                        studentRecord = row
                        Exit For
                    End If
                Next

                If studentRecord IsNot Nothing Then
                    ' Open the UpdateStudentRegistration form with the selected student's data
                    Dim updateForm As New UpdateStudentRegistration(studentRecord)
                    updateForm.ShowDialog()

                    ' Refresh the records after the update form is closed
                    LoadStudentRecords()
                Else
                    MessageBox.Show("Error: Could not find student record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error opening update form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a record to update.")
        End If
    End Sub

    ' Modified Archive button (previously Delete button)
    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        If dgvRecords.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvRecords.SelectedRows(0)
            Dim studentID As String = selectedRow.Cells("StudentID").Value.ToString()
            Dim fullName As String = ""

            ' Get student name for confirmation message
            If dgvRecords.Columns.Contains("FullName") Then
                Dim cell = selectedRow.Cells("FullName")
                If cell IsNot Nothing AndAlso Not IsDBNull(cell.Value) Then
                    fullName = cell.Value.ToString()
                End If
            End If

            Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to archive this student record?" & vbCrLf &
                $"Student: {fullName}" & vbCrLf & vbCrLf &
                "The record will be moved to archive and can be restored later.",
                "Confirm Archive",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If result = DialogResult.Yes Then
                Try
                    ' Find the complete student record from the DataTable
                    Dim studentRecord As DataRow = Nothing
                    For Each row As DataRow In dt.Rows
                        If row("StudentID").ToString() = studentID Then
                            studentRecord = row
                            Exit For
                        End If
                    Next

                    If studentRecord IsNot Nothing Then
                        ' Convert DataRow to StudentRecord object
                        Dim student As New StudentRecord()
                        student.StudentID = studentRecord("StudentID").ToString()
                        student.LastName = If(IsDBNull(studentRecord("LastName")), "", studentRecord("LastName").ToString())
                        student.FirstName = If(IsDBNull(studentRecord("FirstName")), "", studentRecord("FirstName").ToString())
                        student.MiddleName = If(IsDBNull(studentRecord("MiddleName")), "", studentRecord("MiddleName").ToString())
                        student.Suffix = If(IsDBNull(studentRecord("Suffix")), "", studentRecord("Suffix").ToString())
                        student.Address = If(IsDBNull(studentRecord("Address")), "", studentRecord("Address").ToString())
                        student.PlaceOfBirth = If(IsDBNull(studentRecord("PlaceOfBirth")), "", studentRecord("PlaceOfBirth").ToString())
                        student.DOB = If(IsDBNull(studentRecord("DOB")), Date.MinValue, Convert.ToDateTime(studentRecord("DOB")))
                        student.Age = If(IsDBNull(studentRecord("Age")), 0, Convert.ToInt32(studentRecord("Age")))
                        student.Gender = If(IsDBNull(studentRecord("Gender")), "", studentRecord("Gender").ToString())
                        student.Nationality = If(IsDBNull(studentRecord("Nationality")), "", studentRecord("Nationality").ToString())
                        student.Course = If(IsDBNull(studentRecord("Course")), "", studentRecord("Course").ToString())
                        student.YearLevel = If(IsDBNull(studentRecord("YearLevel")), "", studentRecord("YearLevel").ToString())
                        student.Section = If(IsDBNull(studentRecord("Section")), "", studentRecord("Section").ToString())
                        student.Phone = If(IsDBNull(studentRecord("Phone")), "", studentRecord("Phone").ToString())
                        student.Email = If(IsDBNull(studentRecord("Email")), "", studentRecord("Email").ToString())
                        student.MotherName = If(IsDBNull(studentRecord("MotherName")), "", studentRecord("MotherName").ToString())
                        student.MotherAddress = If(IsDBNull(studentRecord("MotherAddress")), "", studentRecord("MotherAddress").ToString())
                        student.MotherPhone = If(IsDBNull(studentRecord("MotherPhone")), "", studentRecord("MotherPhone").ToString())
                        student.MotherOccupation = If(IsDBNull(studentRecord("MotherOccupation")), "", studentRecord("MotherOccupation").ToString())
                        student.FatherName = If(IsDBNull(studentRecord("FatherName")), "", studentRecord("FatherName").ToString())
                        student.FatherAddress = If(IsDBNull(studentRecord("FatherAddress")), "", studentRecord("FatherAddress").ToString())
                        student.FatherPhone = If(IsDBNull(studentRecord("FatherPhone")), "", studentRecord("FatherPhone").ToString())
                        student.FatherOccupation = If(IsDBNull(studentRecord("FatherOccupation")), "", studentRecord("FatherOccupation").ToString())
                        student.GuardianName = If(IsDBNull(studentRecord("GuardianName")), "", studentRecord("GuardianName").ToString())
                        student.GuardianPhone = If(IsDBNull(studentRecord("GuardianPhone")), "", studentRecord("GuardianPhone").ToString())
                        student.GuardianOccupation = If(IsDBNull(studentRecord("GuardianOccupation")), "", studentRecord("GuardianOccupation").ToString())

                        ' Move to archive using DatabaseManager
                        If DatabaseManager.MoveToArchive(student) Then
                            MessageBox.Show("Record moved to archive successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadStudentRecords() ' Refresh the data
                        Else
                            MessageBox.Show("Failed to move record to archive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Error: Could not find student record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error archiving record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a record to archive.")
        End If
    End Sub

    ' New button to open Archive form
    Private Sub btnOpenArchive_Click(sender As Object, e As EventArgs) Handles btnOpenArchive.Click
        Try
            Dim archiveForm As New ArchiveForm(Me) ' Pass reference to refresh records when needed
            archiveForm.ShowDialog()

            ' Refresh records in case any were restored
            LoadStudentRecords()
        Catch ex As Exception
            MessageBox.Show("Error opening archive: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to go back to registration?",
            "Confirm",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' Public method to refresh records (called from ArchiveForm when restoring)
    Public Sub RefreshRecords()
        LoadStudentRecords()
    End Sub

    Private Sub pnlTop_Paint(sender As Object, e As PaintEventArgs) Handles pnlTop.Paint
    End Sub
End Class