Imports System.Text.RegularExpressions

Public Class UpdateStudentRegistration
    Private originalStudentID As String
    Private db As DatabaseManager
    Private ErrorProvider1 As New ErrorProvider()
    Private originalData As StudentRecord
    Private isUpdated As Boolean = False
    Private parentForm As Form

    ' Constructor to receive student data from RecordsForm
    Public Sub New(studentRecord As DataRow, Optional parent As Form = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        db = New DatabaseManager()
        PopulateFormFields(studentRecord)
        originalStudentID = studentRecord("StudentID").ToString()
        originalData = GetCurrentStudentRecord() ' Store original data for change detection
        parentForm = parent
    End Sub

    ' Helper to safely get section value from either cmbSection (new) or txtSection (legacy)
    Private Function GetSectionValue() As String
        Dim cmb = TryCast(Me.Controls.Find("cmbSection", True).FirstOrDefault(), ComboBox)
        If cmb IsNot Nothing Then
            If cmb.SelectedItem Is Nothing Then Return ""
            Return cmb.SelectedItem.ToString().Trim()
        End If
        Dim txt = TryCast(Me.Controls.Find("txtSection", True).FirstOrDefault(), TextBox)
        If txt IsNot Nothing Then
            Return txt.Text.Trim()
        End If
        Return ""
    End Function

    ' Helper to set section value into UI (tries cmbSection first)
    Private Sub SetSectionValue(value As String)
        Dim cmb = TryCast(Me.Controls.Find("cmbSection", True).FirstOrDefault(), ComboBox)
        If cmb IsNot Nothing Then
            If String.IsNullOrWhiteSpace(value) Then
                cmb.SelectedIndex = -1
            Else
                Dim idx As Integer = cmb.Items.IndexOf(value)
                If idx >= 0 Then
                    cmb.SelectedIndex = idx
                Else
                    cmb.Items.Add(value)
                    cmb.SelectedItem = value
                End If
            End If
            Return
        End If
        Dim txt = TryCast(Me.Controls.Find("txtSection", True).FirstOrDefault(), TextBox)
        If txt IsNot Nothing Then
            txt.Text = value
        End If
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
                If cboSuffix.Items.Count > 5 Then cboSuffix.SelectedIndex = 5 ' N/A
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

            Dim sectionValue As String = If(studentRecord("Section") Is DBNull.Value, "", studentRecord("Section").ToString())
            SetSectionValue(sectionValue)

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

    ' Get the current form data as a StudentRecord for change detection
    Private Function GetCurrentStudentRecord() As StudentRecord
        Dim student As New StudentRecord()
        student.StudentID = txtStudentID.Text.Trim()
        student.LastName = txtLastName.Text.Trim()
        student.FirstName = txtFirstName.Text.Trim()
        student.MiddleName = txtMiddleName.Text.Trim()
        student.Suffix = If(cboSuffix.SelectedIndex = -1, "", cboSuffix.SelectedItem?.ToString())

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
        student.Age = If(String.IsNullOrWhiteSpace(txtAge.Text), 0, Integer.Parse(txtAge.Text))
        student.Gender = If(cboGender.SelectedIndex = -1, "", cboGender.SelectedItem?.ToString())
        student.Nationality = If(cboNationality.SelectedIndex = -1, "", cboNationality.SelectedItem?.ToString())
        student.Course = If(cboCourse.SelectedIndex = -1, "", cboCourse.SelectedItem?.ToString())
        student.YearLevel = If(cboYearLevel.SelectedIndex = -1, "", cboYearLevel.SelectedItem?.ToString())
        student.Section = GetSectionValue()
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
        Return student
    End Function

    ' Compare two StudentRecord objects for changes
    Private Function HasChanges() As Boolean
        Dim current = GetCurrentStudentRecord()
        Return Not StudentRecordEquals(originalData, current)
    End Function

    ' Deep compare two StudentRecord objects
    Private Function StudentRecordEquals(a As StudentRecord, b As StudentRecord) As Boolean
        If a Is Nothing OrElse b Is Nothing Then Return False
        Return a.StudentID = b.StudentID AndAlso
            a.LastName = b.LastName AndAlso
            a.FirstName = b.FirstName AndAlso
            a.MiddleName = b.MiddleName AndAlso
            a.Suffix = b.Suffix AndAlso
            a.Address = b.Address AndAlso
            a.PlaceOfBirth = b.PlaceOfBirth AndAlso
            a.DOB = b.DOB AndAlso
            a.Age = b.Age AndAlso
            a.Gender = b.Gender AndAlso
            a.Nationality = b.Nationality AndAlso
            a.Course = b.Course AndAlso
            a.YearLevel = b.YearLevel AndAlso
            a.Section = b.Section AndAlso
            a.Phone = b.Phone AndAlso
            a.Email = b.Email AndAlso
            a.MotherName = b.MotherName AndAlso
            a.MotherAddress = b.MotherAddress AndAlso
            a.MotherPhone = b.MotherPhone AndAlso
            a.MotherOccupation = b.MotherOccupation AndAlso
            a.FatherName = b.FatherName AndAlso
            a.FatherAddress = b.FatherAddress AndAlso
            a.FatherPhone = b.FatherPhone AndAlso
            a.FatherOccupation = b.FatherOccupation AndAlso
            a.GuardianName = b.GuardianName AndAlso
            a.GuardianPhone = b.GuardianPhone AndAlso
            a.GuardianOccupation = b.GuardianOccupation
    End Function

    ' Update button click event
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Validate only the required fields
        Dim sectionValue = GetSectionValue()
        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtStudentID.Text) OrElse
           String.IsNullOrWhiteSpace(txtAge.Text) OrElse
           cboNationality.SelectedIndex = -1 OrElse
           cboGender.SelectedIndex = -1 OrElse
           cboCourse.SelectedIndex = -1 OrElse
           cboYearLevel.SelectedIndex = -1 OrElse
           String.IsNullOrWhiteSpace(sectionValue) Then

            MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Update Unsuccessful."
            Return
        End If

        ' Validate Section format
        If Not System.Text.RegularExpressions.Regex.IsMatch(sectionValue.Trim(), "^[A-Za-z]$") Then
            MessageBox.Show("Please select a valid Section (letters only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Update Unsuccessful."
            Return
        End If

        ' Validate all name and occupation fields
        If Not ValidateAllNameFields() Then
            MessageBox.Show("Please correct the highlighted fields before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Update Unsuccessful."
            Return
        End If

        ' Check for changes before updating
        If Not HasChanges() Then
            MessageBox.Show("No changes detected. Update skipped.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblStatus.ForeColor = Color.Orange
            lblStatus.Text = "No changes made."
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
            student.Section = sectionValue
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
                isUpdated = True
                MessageBox.Show("Student record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Optionally, close or redirect
                Me.Close()
            Else
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Update failed. Please try again."
                MessageBox.Show("Failed to update student record in database. Ensure Section is a single letter A–F.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Update failed. Please try again."
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancel button click event
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If isUpdated OrElse Not HasChanges() Then
            Me.Close()
        Else
            Dim result As DialogResult = MessageBox.Show(
                "You have unsaved changes. Are you sure you want to cancel? Any unsaved changes will be lost.",
                "Cancel Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            )
            If result = DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    ' Form load event
    Private Sub UpdateStudentRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure combo exists and has items (defensive)
        Dim cmb = TryCast(Me.Controls.Find("cmbSection", True).FirstOrDefault(), ComboBox)
        If cmb IsNot Nothing AndAlso cmb.Items.Count = 0 Then
            cmb.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F"})
            cmb.DropDownStyle = ComboBoxStyle.DropDownList
        End If
        txtLastName.Focus()
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        ' Unsaved changes logic (if any)
        If isUpdated OrElse Not HasChanges() Then
            If parentForm IsNot Nothing Then parentForm.Show()
            MyBase.OnFormClosing(e)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show(
            "You have unsaved changes. Are you sure you want to exit? Any unsaved changes will be lost.",
            "Exit Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )
        If result = DialogResult.No Then
            e.Cancel = True
        Else
            If parentForm IsNot Nothing Then parentForm.Show()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    ' === Name/OCCUPATION VALIDATION ===

    Private Function IsValidNameInput(text As String) As Boolean
        Return Regex.IsMatch(text, "^[A-Za-z .'-]+$")
    End Function

    Private Function ValidateAllNameFields() As Boolean
        Dim valid As Boolean = True
        valid = ValidateNameField(txtLastName) AndAlso valid
        valid = ValidateNameField(txtFirstName) AndAlso valid
        valid = ValidateNameField(txtMiddleName) AndAlso valid
        valid = ValidateNameField(txtMotherName) AndAlso valid
        valid = ValidateNameField(txtFatherName) AndAlso valid
        valid = ValidateNameField(txtGuardianName) AndAlso valid
        valid = ValidateNameField(txtMotherOccupation) AndAlso valid
        valid = ValidateNameField(txtFatherOccupation) AndAlso valid
        valid = ValidateNameField(txtGuardianOccupation) AndAlso valid
        Return valid
    End Function

    Private Function ValidateNameField(tb As TextBox) As Boolean
        If String.IsNullOrWhiteSpace(tb.Text) Then
            ErrorProvider1.SetError(tb, "")
            Return True
        End If
        If Not IsValidNameInput(tb.Text) Then
            ErrorProvider1.SetError(tb, "Only letters, spaces, apostrophes, hyphens, and periods are allowed.")
            Return False
        Else
            ErrorProvider1.SetError(tb, "")
            Return True
        End If
    End Function

    Private Sub NameField_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        txtLastName.KeyPress, txtFirstName.KeyPress, txtMiddleName.KeyPress,
        txtMotherName.KeyPress, txtFatherName.KeyPress, txtGuardianName.KeyPress,
        txtMotherOccupation.KeyPress, txtFatherOccupation.KeyPress, txtGuardianOccupation.KeyPress

        Dim allowed = Char.IsControl(e.KeyChar) OrElse
                      Char.IsLetter(e.KeyChar) OrElse
                      e.KeyChar = " "c OrElse e.KeyChar = "'"c OrElse e.KeyChar = "-"c OrElse e.KeyChar = "."c

        If Not allowed Then
            e.Handled = True
            ErrorProvider1.SetError(DirectCast(sender, Control), "Only letters, spaces, apostrophes, hyphens, and periods are allowed.")
        Else
            ErrorProvider1.SetError(DirectCast(sender, Control), "")
        End If
    End Sub

    Private Sub NameField_TextChanged(sender As Object, e As EventArgs) Handles _
        txtLastName.TextChanged, txtFirstName.TextChanged, txtMiddleName.TextChanged,
        txtMotherName.TextChanged, txtFatherName.TextChanged, txtGuardianName.TextChanged,
        txtMotherOccupation.TextChanged, txtFatherOccupation.TextChanged, txtGuardianOccupation.TextChanged

        ValidateNameField(DirectCast(sender, TextBox))
    End Sub
End Class