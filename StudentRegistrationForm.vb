Imports System.Text.RegularExpressions

Public Class StudentRegistrationForm
    Private ErrorProvider1 As New ErrorProvider()

    ' Register button
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Validate only the required fields
        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtStudentID.Text) OrElse
           String.IsNullOrWhiteSpace(txtAge.Text) OrElse
           cboNationality.SelectedIndex = -1 OrElse
           cboGender.SelectedIndex = -1 OrElse
           cboCourse.SelectedIndex = -1 OrElse
           cboYearLevel.SelectedIndex = -1 OrElse
           cmbSection.SelectedItem Is Nothing Then

            MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Registration Unsuccessful."
            Return
        End If

        ' Validate Student ID format
        If Not IsValidStudentID(txtStudentID.Text) Then
            MessageBox.Show("Please follow the format provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Registration Unsuccessful."
            Return
        End If

        ' Validate Section format (single letter)
        If Not IsValidSection(cmbSection.SelectedItem.ToString()) Then
            MessageBox.Show("Please select a valid Section (letters only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblSectionError.Text = "Select A-F"
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Registration Unsuccessful."
            Return
        End If

        ' Validate all name and occupation fields
        If Not ValidateAllNameFields() Then
            MessageBox.Show("Please correct the highlighted fields before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Registration Unsuccessful."
            Return
        End If

        ' Create student record and save to database
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
            student.Section = cmbSection.SelectedItem.ToString()
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

            ' Save to database
            Dim db As New DatabaseManager()
            If db.InsertStudent(student) Then
                lblStatus.ForeColor = Color.Green
                lblStatus.Text = "Registration successful!"
                MessageBox.Show("Student registered.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' After successful registration, clear the registration form.
                ClearAllFields(Me)
                ' Generate new student ID for next registration
                txtStudentID.Text = db.GetNextStudentID()
            Else
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Registration failed. Please try again."
                MessageBox.Show("Failed to save student record to database. Ensure Section is a single letter A–F.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Registration failed. Please try again."
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' === Name/OCCUPATION VALIDATION ===

    ' Regex: Only letters, spaces, apostrophes, hyphens, periods
    Private Function IsValidNameInput(text As String) As Boolean
        Return Regex.IsMatch(text, "^[A-Za-z .'-]+$")
    End Function

    ' Validate all name/occupation fields at once
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

    ' Handles KeyPress for all name/occupation fields
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

    ' Also validate on TextChanged (for pasted text)
    Private Sub NameField_TextChanged(sender As Object, e As EventArgs) Handles _
        txtLastName.TextChanged, txtFirstName.TextChanged, txtMiddleName.TextChanged,
        txtMotherName.TextChanged, txtFatherName.TextChanged, txtGuardianName.TextChanged,
        txtMotherOccupation.TextChanged, txtFatherOccupation.TextChanged, txtGuardianOccupation.TextChanged

        ValidateNameField(DirectCast(sender, TextBox))
    End Sub

    ' Clear button function
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Check if any control has data
        If Not HasAnyData(Me) Then
            MessageBox.Show("Nothing to clear.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Clear everything
        ClearAllFields(Me)

        ' Reset status label
        lblStatus.ForeColor = Color.Red
        lblStatus.Text = "Please fill in all required fields."
    End Sub


    ' === Helper Functions ===

    ' Recursively clears all TextBoxes & ComboBoxes
    Private Sub ClearAllFields(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox Then
                ' Don't clear Student ID as it's auto-generated
                If DirectCast(ctrl, TextBox).Name <> "txtStudentID" Then
                    DirectCast(ctrl, TextBox).Clear()
                End If
            ElseIf TypeOf ctrl Is ComboBox Then
                DirectCast(ctrl, ComboBox).SelectedIndex = -1
            ElseIf ctrl.HasChildren Then
                ClearAllFields(ctrl)
            End If
        Next
    End Sub

    ' Recursively checks if any field has data
    Private Function HasAnyData(parent As Control) As Boolean
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox Then
                ' Skip Student ID and Age fields as they're auto-generated
                If DirectCast(ctrl, TextBox).Name <> "txtStudentID" AndAlso
                   DirectCast(ctrl, TextBox).Name <> "txtAge" Then
                    If Not String.IsNullOrWhiteSpace(DirectCast(ctrl, TextBox).Text) Then
                        Return True
                    End If
                End If
            ElseIf TypeOf ctrl Is ComboBox Then
                If DirectCast(ctrl, ComboBox).SelectedIndex <> -1 Then
                    Return True
                End If
            ElseIf ctrl.HasChildren Then
                If HasAnyData(ctrl) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function


    ' Validation Function : Student ID
    Private Function IsValidStudentID(studentID As String) As Boolean
        ' Updated to match the auto-generated format: YYYY0001
        Dim pattern As String = "^\d{8}$"
        Return System.Text.RegularExpressions.Regex.IsMatch(studentID, pattern)
    End Function

    ' Validation Function : Section (single letter)
    Private Function IsValidSection(section As String) As Boolean
        Dim pattern As String = "^[A-Za-z]$"
        Return System.Text.RegularExpressions.Regex.IsMatch(section.Trim(), pattern)
    End Function

    ' Clear the section error when selection changes
    Private Sub cmbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSection.SelectedIndexChanged
        If cmbSection.SelectedItem Is Nothing Then
            lblSectionError.Text = ""
        ElseIf Not IsValidSection(cmbSection.SelectedItem.ToString()) Then
            lblSectionError.Text = "Select A-F"
        Else
            lblSectionError.Text = ""
        End If
    End Sub

    ' Shows a message to inform user about the specified format for Student ID
    Private Sub txtStudentID_TextChanged(sender As Object, e As EventArgs) Handles txtStudentID.TextChanged
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            lblStudentIDError.Text = ""
        ElseIf Not IsValidStudentID(txtStudentID.Text.Trim()) Then
            lblStudentIDError.Text = "Format : YYYY0001"
        Else
            lblStudentIDError.Text = ""
        End If
    End Sub

    ' When exiting, prompt the user to prevent sudden exit.
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to exit? Unless you have registered, any information given will be lost.",
            "Exit Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )
        If result = DialogResult.No Then
            e.Cancel = True
        End If
        MyBase.OnFormClosing(e)
    End Sub

    ' Set focus to Last Name when the form loads
    Private Sub StudentRegistrationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As New DatabaseManager()
        db.EnsureTableExists() ' <-- This line ensures the table is created if missing
        db.EnsureArchiveTableExists()
        ' Ensure section combo is populated (designer already sets items, this is defensive)
        If cmbSection.Items.Count = 0 Then
            cmbSection.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F"})
        End If
        txtStudentID.Text = db.GetNextStudentID()
        txtStudentID.ReadOnly = True
        txtLastName.Focus()
    End Sub

    Private Sub btnRecords_Click(sender As Object, e As EventArgs) Handles btnRecords.Click
        Me.Hide()
        Dim recordsForm As New RecordsForm(Me)
        recordsForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub grpAcademic_Enter(sender As Object, e As EventArgs) Handles grpAcademic.Enter

    End Sub

    Private Sub scrollPanel_Paint(sender As Object, e As PaintEventArgs) Handles scrollPanel.Paint

    End Sub

    Private Sub txtStudentID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudentID.KeyDown
        e.SuppressKeyPress = True
    End Sub
End Class