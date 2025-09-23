Public Class StudentRegistrationForm
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
           String.IsNullOrWhiteSpace(txtSection.Text) Then

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

        ' Validate Section format
        If Not IsValidSection(txtSection.Text) Then
            MessageBox.Show("Please follow the format provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            ' Save to database
            Dim db As New DatabaseManager()
            If db.InsertStudent(student) Then
                lblStatus.ForeColor = Color.Green
                lblStatus.Text = "Registration successful!"
                ' After successful registration, clear the registration form.
                ClearAllFields(Me)
                ' Generate new student ID for next registration
                txtStudentID.Text = db.GetNextStudentID()
            Else
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Registration failed. Please try again."
                MessageBox.Show("Failed to save student record to database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Registration failed. Please try again."
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        txtStudentID.Text = db.GetNextStudentID()
        txtStudentID.ReadOnly = True
        txtLastName.Focus()
    End Sub

    Private Sub btnRecords_Click(sender As Object, e As EventArgs) Handles btnRecords.Click
        Dim recordsForm As New RecordsForm()
        recordsForm.ShowDialog()
    End Sub

    Private Sub grpAcademic_Enter(sender As Object, e As EventArgs) Handles grpAcademic.Enter

    End Sub

    Private Sub scrollPanel_Paint(sender As Object, e As PaintEventArgs) Handles scrollPanel.Paint

    End Sub

    Private Sub txtStudentID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudentID.KeyDown
        e.SuppressKeyPress = True
    End Sub
End Class