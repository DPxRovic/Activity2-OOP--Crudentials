Public Class UpdateStudentRegistration
    Private originalStudentID As String
    Private db As DatabaseManager

    ' Constructor to receive student data from RecordsForm
    Public Sub New(studentRecord As DataRow)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        db = New DatabaseManager()
        PopulateFormFields(studentRecord)
        originalStudentID = studentRecord("StudentID").ToString()
    End Sub

    ' Populate all form fields with the selected student's data
    Private Sub PopulateFormFields(studentRecord As DataRow)
        Try
            ' Basic Information
            txtStudentID.Text = studentRecord("StudentID").ToString()
            txtLastName.Text = studentRecord("LastName").ToString()
            txtFirstName.Text = studentRecord("FirstName").ToString()
            txtMiddleName.Text = If(studentRecord("MiddleName") Is DBNull.Value, "", studentRecord("MiddleName").ToString())

            ' Set Suffix combobox
            Dim suffixValue As String = If(studentRecord("Suffix") Is DBNull.Value, "", studentRecord("Suffix").ToString())
            If String.IsNullOrWhiteSpace(suffixValue) OrElse suffixValue = "N/A" Then
                cboSuffix.SelectedIndex = 5 ' N/A
            Else
                cboSuffix.Text = suffixValue
            End If

            ' Parse address back to components (assuming it was stored as comma-separated)
            Dim address As String = If(studentRecord("Address") Is DBNull.Value, "", studentRecord("Address").ToString())
            If Not String.IsNullOrWhiteSpace(address) Then
                Dim addressParts() As String = address.Split(","c)
                If addressParts.Length >= 1 Then txtStreetName.Text = addressParts(0).Trim()
                If addressParts.Length >= 2 Then txtBarangay.Text = addressParts(1).Trim()
                If addressParts.Length >= 3 Then txtCity.Text = addressParts(2).Trim()
                If addressParts.Length >= 4 Then txtProvince.Text = addressParts(3).Trim()
                If addressParts.Length >= 5 Then txtZipCode.Text = addressParts(4).Trim()
            End If

            txtPlaceOfBirth.Text = If(studentRecord("PlaceOfBirth") Is DBNull.Value, "", studentRecord("PlaceOfBirth").ToString())

            ' Date of Birth and Age
            If Not studentRecord("DOB") Is DBNull.Value Then
                txtDOB.Value = Convert.ToDateTime(studentRecord("DOB"))
            End If
            txtAge.Text = If(studentRecord("Age") Is DBNull.Value, "", studentRecord("Age").ToString())

            ' Set Gender combobox
            Dim genderValue As String = If(studentRecord("Gender") Is DBNull.Value, "", studentRecord("Gender").ToString())
            If Not String.IsNullOrWhiteSpace(genderValue) Then
                cboGender.Text = genderValue
            End If

            ' Set Nationality combobox
            Dim nationalityValue As String = If(studentRecord("Nationality") Is DBNull.Value, "", studentRecord("Nationality").ToString())
            If Not String.IsNullOrWhiteSpace(nationalityValue) Then
                cboNationality.Text = nationalityValue
            End If

            ' Academic Information
            Dim courseValue As String = If(studentRecord("Course") Is DBNull.Value, "", studentRecord("Course").ToString())
            If Not String.IsNullOrWhiteSpace(courseValue) Then
                cboCourse.Text = courseValue
            End If

            Dim yearLevelValue As String = If(studentRecord("YearLevel") Is DBNull.Value, "", studentRecord("YearLevel").ToString())
            If Not String.IsNullOrWhiteSpace(yearLevelValue) Then
                cboYearLevel.Text = yearLevelValue
            End If

            txtSection.Text = If(studentRecord("Section") Is DBNull.Value, "", studentRecord("Section").ToString())

            ' Contact Information
            txtPhone.Text = If(studentRecord("Phone") Is DBNull.Value, "", studentRecord("Phone").ToString())
            txtEmail.Text = If(studentRecord("Email") Is DBNull.Value, "", studentRecord("Email").ToString())

            ' Parent/Guardian Information
            txtMotherName.Text = If(studentRecord("MotherName") Is DBNull.Value, "", studentRecord("MotherName").ToString())
            txtMotherAddress.Text = If(studentRecord("MotherAddress") Is DBNull.Value, "", studentRecord("MotherAddress").ToString())
            txtMotherPhone.Text = If(studentRecord("MotherPhone") Is DBNull.Value, "", studentRecord("MotherPhone").ToString())
            txtMotherOccupation.Text = If(studentRecord("MotherOccupation") Is DBNull.Value, "", studentRecord("MotherOccupation").ToString())
            txtFatherName.Text = If(studentRecord("FatherName") Is DBNull.Value, "", studentRecord("FatherName").ToString())
            txtFatherAddress.Text = If(studentRecord("FatherAddress") Is DBNull.Value, "", studentRecord("FatherAddress").ToString())
            txtFatherPhone.Text = If(studentRecord("FatherPhone") Is DBNull.Value, "", studentRecord("FatherPhone").ToString())
            txtFatherOccupation.Text = If(studentRecord("FatherOccupation") Is DBNull.Value, "", studentRecord("FatherOccupation").ToString())
            txtGuardianName.Text = If(studentRecord("GuardianName") Is DBNull.Value, "", studentRecord("GuardianName").ToString())
            txtGuardianPhone.Text = If(studentRecord("GuardianPhone") Is DBNull.Value, "", studentRecord("GuardianPhone").ToString())
            txtGuardianOccupation.Text = If(studentRecord("GuardianOccupation") Is DBNull.Value, "", studentRecord("GuardianOccupation").ToString())

        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Update button click event
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Validate only the required fields
        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtStudentID.Text) OrElse
           String.IsNullOrWhiteSpace(txtAge.Text) OrElse
           cboNationality.SelectedIndex = -1 OrElse
           cboGender.SelectedIndex = -1 OrElse
           cboCourse.SelectedIndex = -1 OrElse
           cboYearLevel.SelectedIndex = -1 OrElse
           String.IsNullOrWhiteSpace(txtSection.Text) Then

            MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Update Unsuccessful."
            Return
        End If

        ' Validate Section format
        If Not IsValidSection(txtSection.Text) Then
            MessageBox.Show("Please follow the format provided for Section.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Update Unsuccessful."
            Return
        End If

        ' Create updated student record
        Try
            Dim student As New StudentRecord()
            student.StudentID = txtStudentID.Text.Trim()
            student.LastName = txtLastName.Text.Trim()
            student.FirstName = txtFirstName.Text.Trim()
            student.MiddleName = txtMiddleName.Text.Trim()
            student.Suffix = If(cboSuffix.SelectedIndex = -1, "", cboSuffix.SelectedItem.ToString())

            ' Build address from components
            Dim addressParts As New List(Of String)
            If Not String.IsNullOrWhiteSpace(txtStreetName.Text) Then addressParts.Add(txtStreetName.Text.Trim())
            If Not String.IsNullOrWhiteSpace(txtBarangay.Text) Then addressParts.Add(txtBarangay.Text.Trim())
            If Not String.IsNullOrWhiteSpace(txtCity.Text) Then addressParts.Add(txtCity.Text.Trim())
            If Not String.IsNullOrWhiteSpace(txtProvince.Text) Then addressParts.Add(txtProvince.Text.Trim())
            If Not String.IsNullOrWhiteSpace(txtZipCode.Text) Then addressParts.Add(txtZipCode.Text.Trim())
            student.Address = String.Join(", ", addressParts)

            student.PlaceOfBirth = txtPlaceOfBirth.Text.Trim()
            student.DOB = txtDOB.Value
            student.Age = Integer.Parse(txtAge.Text)
            student.Gender = cboGender.SelectedItem.ToString()
            student.Nationality = cboNationality.SelectedItem.ToString()
            student.Course = cboCourse.SelectedItem.ToString()
            student.YearLevel = cboYearLevel.SelectedItem.ToString()
            student.Section = txtSection.Text.Trim()
            student.Phone = txtPhone.Text.Trim()
            student.Email = txtEmail.Text.Trim()
            student.MotherName = txtMotherName.Text.Trim()
            student.MotherAddress = txtMotherAddress.Text.Trim()
            student.MotherPhone = txtMotherPhone.Text.Trim()
            student.MotherOccupation = txtMotherOccupation.Text.Trim()
            student.FatherName = txtFatherName.Text.Trim()
            student.FatherAddress = txtFatherAddress.Text.Trim()
            student.FatherPhone = txtFatherPhone.Text.Trim()
            student.FatherOccupation = txtFatherOccupation.Text.Trim()
            student.GuardianName = txtGuardianName.Text.Trim()
            student.GuardianPhone = txtGuardianPhone.Text.Trim()
            student.GuardianOccupation = txtGuardianOccupation.Text.Trim()

            ' Update the database record
            If db.UpdateStudentComplete(student) Then
                lblStatus.ForeColor = Color.Green
                lblStatus.Text = "Update successful!"
                MessageBox.Show("Student record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Update failed. Please try again."
                MessageBox.Show("Failed to update student record in database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Update failed. Please try again."
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancel button click event
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to cancel? Any unsaved changes will be lost.",
            "Cancel Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' === Helper Functions (Same as Registration Form) ===

    ' Validation Function : Section
    Private Function IsValidSection(section As String) As Boolean
        Dim pattern As String = "^\d-[A-Z]$"
        Return System.Text.RegularExpressions.Regex.IsMatch(section, pattern)
    End Function

    ' Shows a message to inform user about the specified format for Section.
    Private Sub txtSection_TextChanged(sender As Object, e As EventArgs) Handles txtSection.TextChanged
        If String.IsNullOrWhiteSpace(txtSection.Text) Then
            lblSectionError.Text = ""
        ElseIf Not IsValidSection(txtSection.Text.Trim()) Then
            lblSectionError.Text = "Format : 0-X"
        Else
            lblSectionError.Text = ""
        End If
    End Sub

    ' Form load event
    Private Sub UpdateStudentRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLastName.Focus()
    End Sub

    ' When exiting, prompt the user to prevent sudden exit with unsaved changes.
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to exit? Any unsaved changes will be lost.",
            "Exit Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )
        If result = DialogResult.No Then
            e.Cancel = True
        End If
        MyBase.OnFormClosing(e)
    End Sub
End Class