Imports Microsoft.Win32.SafeHandles

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateStudentRegistration
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblHeader = New Label()
        grpStudentInfo = New GroupBox()
        txtStudentID = New TextBox()
        txtDOB = New DateTimePicker()
        cboGender = New ComboBox()
        txtAge = New TextBox()
        txtLastName = New TextBox()
        txtFirstName = New TextBox()
        txtMiddleName = New TextBox()
        lblDOB = New Label()
        lblGender = New Label()
        lblAge = New Label()
        lblLastName = New Label()
        lblFirstName = New Label()
        lblMiddleName = New Label()
        lblStudentID = New Label()
        cboNationality = New ComboBox()
        lblNationality = New Label()
        cboSuffix = New ComboBox()
        lblSuffix = New Label()
        txtStreetName = New TextBox()
        txtBarangay = New TextBox()
        txtCity = New TextBox()
        txtProvince = New TextBox()
        txtZipCode = New TextBox()
        lblStreetName = New Label()
        lblBarangay = New Label()
        lblCity = New Label()
        lblProvince = New Label()
        lblZipCode = New Label()
        txtPlaceOfBirth = New TextBox()
        lblPlaceOfBirth = New Label()
        lblStudentIDError = New Label()
        Label1 = New Label()
        grpAcademic = New GroupBox()
        txtSection = New TextBox()
        cboYearLevel = New ComboBox()
        cboCourse = New ComboBox()
        lblSection = New Label()
        lblYear = New Label()
        lblCourse = New Label()
        lblSectionError = New Label()
        grpContact = New GroupBox()
        txtPhone = New TextBox()
        txtEmail = New TextBox()
        lblPhone = New Label()
        lblEmail = New Label()
        btnUpdate = New Button()
        btnCancel = New Button()
        lblStatus = New Label()
        grpParentGuardian = New GroupBox()
        txtGuardianOccupation = New TextBox()
        lblGuardianOccupation = New Label()
        txtGuardianPhone = New TextBox()
        lblGuardianPhone = New Label()
        lblMotherName = New Label()
        txtMotherName = New TextBox()
        lblMotherAddress = New Label()
        txtMotherAddress = New TextBox()
        lblMotherPhone = New Label()
        txtMotherPhone = New TextBox()
        lblMotherOccupation = New Label()
        txtMotherOccupation = New TextBox()
        lblFatherName = New Label()
        txtFatherName = New TextBox()
        lblFatherAddress = New Label()
        txtFatherAddress = New TextBox()
        lblFatherPhone = New Label()
        txtFatherPhone = New TextBox()
        lblFatherOccupation = New Label()
        txtFatherOccupation = New TextBox()
        lblGuardianName = New Label()
        txtGuardianName = New TextBox()
        scrollPanel = New Panel()
        vScrollBar = New VScrollBar()
        grpStudentInfo.SuspendLayout()
        grpAcademic.SuspendLayout()
        grpContact.SuspendLayout()
        grpParentGuardian.SuspendLayout()
        scrollPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHeader.Location = New Point(186, 12)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(345, 37)
        lblHeader.TabIndex = 0
        lblHeader.Text = "Update Student Registration"
        ' 
        ' grpStudentInfo
        ' 
        grpStudentInfo.Controls.Add(txtStudentID)
        grpStudentInfo.Controls.Add(txtDOB)
        grpStudentInfo.Controls.Add(cboGender)
        grpStudentInfo.Controls.Add(txtAge)
        grpStudentInfo.Controls.Add(txtLastName)
        grpStudentInfo.Controls.Add(txtFirstName)
        grpStudentInfo.Controls.Add(txtMiddleName)
        grpStudentInfo.Controls.Add(lblDOB)
        grpStudentInfo.Controls.Add(lblGender)
        grpStudentInfo.Controls.Add(lblAge)
        grpStudentInfo.Controls.Add(lblLastName)
        grpStudentInfo.Controls.Add(lblFirstName)
        grpStudentInfo.Controls.Add(lblMiddleName)
        grpStudentInfo.Controls.Add(lblStudentID)
        grpStudentInfo.Controls.Add(cboNationality)
        grpStudentInfo.Controls.Add(lblNationality)
        grpStudentInfo.Controls.Add(cboSuffix)
        grpStudentInfo.Controls.Add(lblSuffix)
        grpStudentInfo.Controls.Add(txtStreetName)
        grpStudentInfo.Controls.Add(txtBarangay)
        grpStudentInfo.Controls.Add(txtCity)
        grpStudentInfo.Controls.Add(txtProvince)
        grpStudentInfo.Controls.Add(txtZipCode)
        grpStudentInfo.Controls.Add(lblStreetName)
        grpStudentInfo.Controls.Add(lblBarangay)
        grpStudentInfo.Controls.Add(lblCity)
        grpStudentInfo.Controls.Add(lblProvince)
        grpStudentInfo.Controls.Add(lblZipCode)
        grpStudentInfo.Controls.Add(txtPlaceOfBirth)
        grpStudentInfo.Controls.Add(lblPlaceOfBirth)
        grpStudentInfo.Controls.Add(lblStudentIDError)
        grpStudentInfo.Location = New Point(34, 109)
        grpStudentInfo.Margin = New Padding(3, 4, 3, 4)
        grpStudentInfo.Name = "grpStudentInfo"
        grpStudentInfo.Padding = New Padding(3, 4, 3, 4)
        grpStudentInfo.Size = New Size(617, 491)
        grpStudentInfo.TabIndex = 0
        grpStudentInfo.TabStop = False
        grpStudentInfo.Text = "Student Information"
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Location = New Point(146, 132)
        txtStudentID.Margin = New Padding(3, 4, 3, 4)
        txtStudentID.Name = "txtStudentID"
        txtStudentID.ReadOnly = True
        txtStudentID.Size = New Size(171, 27)
        txtStudentID.TabIndex = 4
        ' 
        ' txtDOB
        ' 
        txtDOB.CustomFormat = "MM/dd/yyyy"
        txtDOB.Format = DateTimePickerFormat.Custom
        txtDOB.Location = New Point(146, 380)
        txtDOB.Margin = New Padding(3, 4, 3, 4)
        txtDOB.Name = "txtDOB"
        txtDOB.Size = New Size(114, 27)
        txtDOB.TabIndex = 9
        ' 
        ' cboGender
        ' 
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList
        cboGender.FormattingEnabled = True
        cboGender.Items.AddRange(New Object() {"Male", "Female", "Prefer not to say"})
        cboGender.Location = New Point(457, 435)
        cboGender.Margin = New Padding(3, 4, 3, 4)
        cboGender.Name = "cboGender"
        cboGender.Size = New Size(137, 28)
        cboGender.TabIndex = 11
        ' 
        ' txtAge
        ' 
        txtAge.Location = New Point(146, 435)
        txtAge.Margin = New Padding(3, 4, 3, 4)
        txtAge.Name = "txtAge"
        txtAge.ReadOnly = True
        txtAge.Size = New Size(42, 27)
        txtAge.TabIndex = 12
        txtAge.TabStop = False
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(146, 35)
        txtLastName.Margin = New Padding(3, 4, 3, 4)
        txtLastName.MaxLength = 25
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(150, 27)
        txtLastName.TabIndex = 0
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(146, 75)
        txtFirstName.Margin = New Padding(3, 4, 3, 4)
        txtFirstName.MaxLength = 25
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(150, 27)
        txtFirstName.TabIndex = 1
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Location = New Point(411, 72)
        txtMiddleName.Margin = New Padding(3, 4, 3, 4)
        txtMiddleName.MaxLength = 25
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(150, 27)
        txtMiddleName.TabIndex = 2
        ' 
        ' lblDOB
        ' 
        lblDOB.AutoSize = True
        lblDOB.Location = New Point(24, 387)
        lblDOB.Name = "lblDOB"
        lblDOB.Size = New Size(104, 20)
        lblDOB.TabIndex = 4
        lblDOB.Text = "Date of Birth *"
        ' 
        ' lblGender
        ' 
        lblGender.AutoSize = True
        lblGender.Location = New Point(350, 439)
        lblGender.Name = "lblGender"
        lblGender.Size = New Size(67, 20)
        lblGender.TabIndex = 3
        lblGender.Text = "Gender *"
        ' 
        ' lblAge
        ' 
        lblAge.AutoSize = True
        lblAge.Location = New Point(24, 439)
        lblAge.Name = "lblAge"
        lblAge.Size = New Size(46, 20)
        lblAge.TabIndex = 2
        lblAge.Text = "Age *"
        ' 
        ' lblLastName
        ' 
        lblLastName.AutoSize = True
        lblLastName.Location = New Point(23, 39)
        lblLastName.Name = "lblLastName"
        lblLastName.Size = New Size(89, 20)
        lblLastName.TabIndex = 1
        lblLastName.Text = "Last Name *"
        ' 
        ' lblFirstName
        ' 
        lblFirstName.AutoSize = True
        lblFirstName.Location = New Point(23, 79)
        lblFirstName.Name = "lblFirstName"
        lblFirstName.Size = New Size(90, 20)
        lblFirstName.TabIndex = 1
        lblFirstName.Text = "First Name *"
        ' 
        ' lblMiddleName
        ' 
        lblMiddleName.AutoSize = True
        lblMiddleName.Location = New Point(305, 79)
        lblMiddleName.Name = "lblMiddleName"
        lblMiddleName.Size = New Size(100, 20)
        lblMiddleName.TabIndex = 1
        lblMiddleName.Text = "Middle Name"
        ' 
        ' lblStudentID
        ' 
        lblStudentID.AutoSize = True
        lblStudentID.Location = New Point(24, 136)
        lblStudentID.Name = "lblStudentID"
        lblStudentID.Size = New Size(89, 20)
        lblStudentID.TabIndex = 0
        lblStudentID.Text = "Student ID *"
        ' 
        ' cboNationality
        ' 
        cboNationality.DropDownStyle = ComboBoxStyle.DropDownList
        cboNationality.FormattingEnabled = True
        cboNationality.Items.AddRange(New Object() {"Filipino", "Chinese", "Japanese", "Korean", "American", "Others"})
        cboNationality.Location = New Point(457, 383)
        cboNationality.Margin = New Padding(3, 4, 3, 4)
        cboNationality.Name = "cboNationality"
        cboNationality.Size = New Size(137, 28)
        cboNationality.TabIndex = 10
        ' 
        ' lblNationality
        ' 
        lblNationality.AutoSize = True
        lblNationality.Location = New Point(350, 387)
        lblNationality.Name = "lblNationality"
        lblNationality.Size = New Size(92, 20)
        lblNationality.TabIndex = 7
        lblNationality.Text = "Nationality *"
        ' 
        ' cboSuffix
        ' 
        cboSuffix.DropDownStyle = ComboBoxStyle.DropDownList
        cboSuffix.FormattingEnabled = True
        cboSuffix.Items.AddRange(New Object() {"Jr.", "I", "II", "III", "IV", "N/A"})
        cboSuffix.Location = New Point(396, 35)
        cboSuffix.Margin = New Padding(3, 4, 3, 4)
        cboSuffix.Name = "cboSuffix"
        cboSuffix.Size = New Size(79, 28)
        cboSuffix.TabIndex = 3
        ' 
        ' lblSuffix
        ' 
        lblSuffix.AutoSize = True
        lblSuffix.Location = New Point(305, 39)
        lblSuffix.Name = "lblSuffix"
        lblSuffix.Size = New Size(46, 20)
        lblSuffix.TabIndex = 15
        lblSuffix.Text = "Suffix"
        ' 
        ' txtStreetName
        ' 
        txtStreetName.Location = New Point(146, 173)
        txtStreetName.Margin = New Padding(3, 4, 3, 4)
        txtStreetName.MaxLength = 50
        txtStreetName.Name = "txtStreetName"
        txtStreetName.Size = New Size(200, 27)
        txtStreetName.TabIndex = 5
        ' 
        ' txtBarangay
        ' 
        txtBarangay.Location = New Point(421, 170)
        txtBarangay.Margin = New Padding(3, 4, 3, 4)
        txtBarangay.MaxLength = 30
        txtBarangay.Name = "txtBarangay"
        txtBarangay.Size = New Size(150, 27)
        txtBarangay.TabIndex = 6
        ' 
        ' txtCity
        ' 
        txtCity.Location = New Point(146, 213)
        txtCity.Margin = New Padding(3, 4, 3, 4)
        txtCity.MaxLength = 30
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(150, 27)
        txtCity.TabIndex = 7
        ' 
        ' txtProvince
        ' 
        txtProvince.Location = New Point(421, 213)
        txtProvince.Margin = New Padding(3, 4, 3, 4)
        txtProvince.MaxLength = 30
        txtProvince.Name = "txtProvince"
        txtProvince.Size = New Size(150, 27)
        txtProvince.TabIndex = 8
        ' 
        ' txtZipCode
        ' 
        txtZipCode.Location = New Point(146, 253)
        txtZipCode.Margin = New Padding(3, 4, 3, 4)
        txtZipCode.MaxLength = 10
        txtZipCode.Name = "txtZipCode"
        txtZipCode.Size = New Size(100, 27)
        txtZipCode.TabIndex = 9
        ' 
        ' lblStreetName
        ' 
        lblStreetName.AutoSize = True
        lblStreetName.Location = New Point(24, 173)
        lblStreetName.Name = "lblStreetName"
        lblStreetName.Size = New Size(92, 20)
        lblStreetName.TabIndex = 17
        lblStreetName.Text = "Street Name"
        ' 
        ' lblBarangay
        ' 
        lblBarangay.AutoSize = True
        lblBarangay.Location = New Point(350, 173)
        lblBarangay.Name = "lblBarangay"
        lblBarangay.Size = New Size(71, 20)
        lblBarangay.TabIndex = 17
        lblBarangay.Text = "Barangay"
        ' 
        ' lblCity
        ' 
        lblCity.AutoSize = True
        lblCity.Location = New Point(24, 213)
        lblCity.Name = "lblCity"
        lblCity.Size = New Size(34, 20)
        lblCity.TabIndex = 17
        lblCity.Text = "City"
        ' 
        ' lblProvince
        ' 
        lblProvince.AutoSize = True
        lblProvince.Location = New Point(350, 213)
        lblProvince.Name = "lblProvince"
        lblProvince.Size = New Size(65, 20)
        lblProvince.TabIndex = 17
        lblProvince.Text = "Province"
        ' 
        ' lblZipCode
        ' 
        lblZipCode.AutoSize = True
        lblZipCode.Location = New Point(24, 253)
        lblZipCode.Name = "lblZipCode"
        lblZipCode.Size = New Size(70, 20)
        lblZipCode.TabIndex = 17
        lblZipCode.Text = "Zip Code"
        ' 
        ' txtPlaceOfBirth
        ' 
        txtPlaceOfBirth.Location = New Point(146, 313)
        txtPlaceOfBirth.Margin = New Padding(3, 4, 3, 4)
        txtPlaceOfBirth.MaxLength = 75
        txtPlaceOfBirth.Name = "txtPlaceOfBirth"
        txtPlaceOfBirth.Size = New Size(447, 27)
        txtPlaceOfBirth.TabIndex = 10
        ' 
        ' lblPlaceOfBirth
        ' 
        lblPlaceOfBirth.AutoSize = True
        lblPlaceOfBirth.Location = New Point(24, 313)
        lblPlaceOfBirth.Name = "lblPlaceOfBirth"
        lblPlaceOfBirth.Size = New Size(97, 20)
        lblPlaceOfBirth.TabIndex = 19
        lblPlaceOfBirth.Text = "Place of Birth"
        ' 
        ' lblStudentIDError
        ' 
        lblStudentIDError.AutoSize = True
        lblStudentIDError.ForeColor = Color.Red
        lblStudentIDError.Location = New Point(146, 163)
        lblStudentIDError.Name = "lblStudentIDError"
        lblStudentIDError.Size = New Size(0, 20)
        lblStudentIDError.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(211, 60)
        Label1.Name = "Label1"
        Label1.Size = New Size(316, 25)
        Label1.TabIndex = 9
        Label1.Text = "* means required, otherwise optional."
        ' 
        ' grpAcademic
        ' 
        grpAcademic.Controls.Add(txtSection)
        grpAcademic.Controls.Add(cboYearLevel)
        grpAcademic.Controls.Add(cboCourse)
        grpAcademic.Controls.Add(lblSection)
        grpAcademic.Controls.Add(lblYear)
        grpAcademic.Controls.Add(lblCourse)
        grpAcademic.Controls.Add(lblSectionError)
        grpAcademic.Location = New Point(34, 999)
        grpAcademic.Margin = New Padding(3, 4, 3, 4)
        grpAcademic.Name = "grpAcademic"
        grpAcademic.Padding = New Padding(3, 4, 3, 4)
        grpAcademic.Size = New Size(617, 133)
        grpAcademic.TabIndex = 2
        grpAcademic.TabStop = False
        grpAcademic.Text = "Academic Details"
        ' 
        ' txtSection
        ' 
        txtSection.Location = New Point(457, 33)
        txtSection.Margin = New Padding(3, 4, 3, 4)
        txtSection.MaxLength = 3
        txtSection.Name = "txtSection"
        txtSection.Size = New Size(137, 27)
        txtSection.TabIndex = 3
        ' 
        ' cboYearLevel
        ' 
        cboYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cboYearLevel.FormattingEnabled = True
        cboYearLevel.Items.AddRange(New Object() {"1st Year", "2nd Year", "3rd Year", "4th Year"})
        cboYearLevel.Location = New Point(149, 80)
        cboYearLevel.Margin = New Padding(3, 4, 3, 4)
        cboYearLevel.Name = "cboYearLevel"
        cboYearLevel.Size = New Size(205, 28)
        cboYearLevel.TabIndex = 2
        ' 
        ' cboCourse
        ' 
        cboCourse.DropDownStyle = ComboBoxStyle.DropDownList
        cboCourse.FormattingEnabled = True
        cboCourse.Items.AddRange(New Object() {"BSCRIM", "BSBA", "BSA", "BSAIS", "BSEntrep", "BSE", "BECED", "BSCS", "BSIS", "BSIT", "BSTM", "BSHM", "BSOAD", "BTLED", "BSMATH", "BSPsych", "ABPolSci", "BPA", "BSIE", "BSCE", "BSEE", "BSEMC", "BACOMM"})
        cboCourse.Location = New Point(149, 33)
        cboCourse.Margin = New Padding(3, 4, 3, 4)
        cboCourse.MaxDropDownItems = 5
        cboCourse.Name = "cboCourse"
        cboCourse.Size = New Size(205, 28)
        cboCourse.TabIndex = 1
        ' 
        ' lblSection
        ' 
        lblSection.AutoSize = True
        lblSection.Location = New Point(377, 37)
        lblSection.Name = "lblSection"
        lblSection.Size = New Size(68, 20)
        lblSection.TabIndex = 2
        lblSection.Text = "Section *"
        ' 
        ' lblYear
        ' 
        lblYear.AutoSize = True
        lblYear.Location = New Point(23, 84)
        lblYear.Name = "lblYear"
        lblYear.Size = New Size(85, 20)
        lblYear.TabIndex = 1
        lblYear.Text = "Year Level *"
        ' 
        ' lblCourse
        ' 
        lblCourse.AutoSize = True
        lblCourse.Location = New Point(23, 37)
        lblCourse.Name = "lblCourse"
        lblCourse.Size = New Size(64, 20)
        lblCourse.TabIndex = 0
        lblCourse.Text = "Course *"
        ' 
        ' lblSectionError
        ' 
        lblSectionError.AutoSize = True
        lblSectionError.ForeColor = Color.Red
        lblSectionError.Location = New Point(457, 67)
        lblSectionError.Name = "lblSectionError"
        lblSectionError.Size = New Size(0, 20)
        lblSectionError.TabIndex = 11
        ' 
        ' grpContact
        ' 
        grpContact.Controls.Add(txtPhone)
        grpContact.Controls.Add(txtEmail)
        grpContact.Controls.Add(lblPhone)
        grpContact.Controls.Add(lblEmail)
        grpContact.Location = New Point(34, 1141)
        grpContact.Margin = New Padding(3, 4, 3, 4)
        grpContact.Name = "grpContact"
        grpContact.Padding = New Padding(3, 4, 3, 4)
        grpContact.Size = New Size(617, 107)
        grpContact.TabIndex = 3
        grpContact.TabStop = False
        grpContact.Text = "Contact Information"
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(457, 40)
        txtPhone.Margin = New Padding(3, 4, 3, 4)
        txtPhone.MaxLength = 11
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(137, 27)
        txtPhone.TabIndex = 2
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(149, 40)
        txtEmail.Margin = New Padding(3, 4, 3, 4)
        txtEmail.MaxLength = 150
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(205, 27)
        txtEmail.TabIndex = 1
        ' 
        ' lblPhone
        ' 
        lblPhone.AutoSize = True
        lblPhone.Location = New Point(377, 44)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(50, 20)
        lblPhone.TabIndex = 1
        lblPhone.Text = "Phone"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(23, 44)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(46, 20)
        lblEmail.TabIndex = 0
        lblEmail.Text = "Email"
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = SystemColors.Control
        btnUpdate.Location = New Point(169, 1255)
        btnUpdate.Margin = New Padding(3, 4, 3, 4)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(114, 47)
        btnUpdate.TabIndex = 5
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = SystemColors.Control
        btnCancel.Location = New Point(290, 1255)
        btnCancel.Margin = New Padding(3, 4, 3, 4)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(114, 47)
        btnCancel.TabIndex = 6
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblStatus.ForeColor = Color.Blue
        lblStatus.Location = New Point(211, 1306)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(250, 28)
        lblStatus.TabIndex = 8
        lblStatus.Text = "Modify the fields as needed."
        ' 
        ' grpParentGuardian
        ' 
        grpParentGuardian.Controls.Add(txtGuardianOccupation)
        grpParentGuardian.Controls.Add(lblGuardianOccupation)
        grpParentGuardian.Controls.Add(txtGuardianPhone)
        grpParentGuardian.Controls.Add(lblGuardianPhone)
        grpParentGuardian.Controls.Add(lblMotherName)
        grpParentGuardian.Controls.Add(txtMotherName)
        grpParentGuardian.Controls.Add(lblMotherAddress)
        grpParentGuardian.Controls.Add(txtMotherAddress)
        grpParentGuardian.Controls.Add(lblMotherPhone)
        grpParentGuardian.Controls.Add(txtMotherPhone)
        grpParentGuardian.Controls.Add(lblMotherOccupation)
        grpParentGuardian.Controls.Add(txtMotherOccupation)
        grpParentGuardian.Controls.Add(lblFatherName)
        grpParentGuardian.Controls.Add(txtFatherName)
        grpParentGuardian.Controls.Add(lblFatherAddress)
        grpParentGuardian.Controls.Add(txtFatherAddress)
        grpParentGuardian.Controls.Add(lblFatherPhone)
        grpParentGuardian.Controls.Add(txtFatherPhone)
        grpParentGuardian.Controls.Add(lblFatherOccupation)
        grpParentGuardian.Controls.Add(txtFatherOccupation)
        grpParentGuardian.Controls.Add(lblGuardianName)
        grpParentGuardian.Controls.Add(txtGuardianName)
        grpParentGuardian.Location = New Point(34, 608)
        grpParentGuardian.Margin = New Padding(3, 4, 3, 4)
        grpParentGuardian.Name = "grpParentGuardian"
        grpParentGuardian.Padding = New Padding(3, 4, 3, 4)
        grpParentGuardian.Size = New Size(617, 364)
        grpParentGuardian.TabIndex = 1
        grpParentGuardian.TabStop = False
        grpParentGuardian.Text = "Parent/Guardian Information"
        ' 
        ' txtGuardianOccupation
        ' 
        txtGuardianOccupation.Location = New Point(423, 319)
        txtGuardianOccupation.Margin = New Padding(3, 4, 3, 4)
        txtGuardianOccupation.MaxLength = 25
        txtGuardianOccupation.Name = "txtGuardianOccupation"
        txtGuardianOccupation.Size = New Size(171, 27)
        txtGuardianOccupation.TabIndex = 32
        ' 
        ' lblGuardianOccupation
        ' 
        lblGuardianOccupation.AutoSize = True
        lblGuardianOccupation.Location = New Point(331, 325)
        lblGuardianOccupation.Name = "lblGuardianOccupation"
        lblGuardianOccupation.Size = New Size(85, 20)
        lblGuardianOccupation.TabIndex = 31
        lblGuardianOccupation.Text = "Occupation"
        ' 
        ' txtGuardianPhone
        ' 
        txtGuardianPhone.Location = New Point(167, 319)
        txtGuardianPhone.Margin = New Padding(3, 4, 3, 4)
        txtGuardianPhone.MaxLength = 11
        txtGuardianPhone.Name = "txtGuardianPhone"
        txtGuardianPhone.Size = New Size(150, 27)
        txtGuardianPhone.TabIndex = 30
        ' 
        ' lblGuardianPhone
        ' 
        lblGuardianPhone.AutoSize = True
        lblGuardianPhone.Location = New Point(24, 323)
        lblGuardianPhone.Name = "lblGuardianPhone"
        lblGuardianPhone.Size = New Size(50, 20)
        lblGuardianPhone.TabIndex = 29
        lblGuardianPhone.Text = "Phone"
        ' 
        ' lblMotherName
        ' 
        lblMotherName.AutoSize = True
        lblMotherName.Location = New Point(23, 40)
        lblMotherName.Name = "lblMotherName"
        lblMotherName.Size = New Size(137, 20)
        lblMotherName.TabIndex = 14
        lblMotherName.Text = "Mother's Full Name"
        ' 
        ' txtMotherName
        ' 
        txtMotherName.Location = New Point(167, 36)
        txtMotherName.Margin = New Padding(3, 4, 3, 4)
        txtMotherName.MaxLength = 35
        txtMotherName.Name = "txtMotherName"
        txtMotherName.Size = New Size(427, 27)
        txtMotherName.TabIndex = 0
        ' 
        ' lblMotherAddress
        ' 
        lblMotherAddress.AutoSize = True
        lblMotherAddress.Location = New Point(23, 80)
        lblMotherAddress.Name = "lblMotherAddress"
        lblMotherAddress.Size = New Size(62, 20)
        lblMotherAddress.TabIndex = 17
        lblMotherAddress.Text = "Address"
        ' 
        ' txtMotherAddress
        ' 
        txtMotherAddress.Location = New Point(167, 76)
        txtMotherAddress.Margin = New Padding(3, 4, 3, 4)
        txtMotherAddress.MaxLength = 75
        txtMotherAddress.Name = "txtMotherAddress"
        txtMotherAddress.Size = New Size(427, 27)
        txtMotherAddress.TabIndex = 1
        ' 
        ' lblMotherPhone
        ' 
        lblMotherPhone.AutoSize = True
        lblMotherPhone.Location = New Point(23, 120)
        lblMotherPhone.Name = "lblMotherPhone"
        lblMotherPhone.Size = New Size(50, 20)
        lblMotherPhone.TabIndex = 19
        lblMotherPhone.Text = "Phone"
        ' 
        ' txtMotherPhone
        ' 
        txtMotherPhone.Location = New Point(167, 116)
        txtMotherPhone.Margin = New Padding(3, 4, 3, 4)
        txtMotherPhone.MaxLength = 11
        txtMotherPhone.Name = "txtMotherPhone"
        txtMotherPhone.Size = New Size(150, 27)
        txtMotherPhone.TabIndex = 2
        ' 
        ' lblMotherOccupation
        ' 
        lblMotherOccupation.AutoSize = True
        lblMotherOccupation.Location = New Point(331, 120)
        lblMotherOccupation.Name = "lblMotherOccupation"
        lblMotherOccupation.Size = New Size(85, 20)
        lblMotherOccupation.TabIndex = 20
        lblMotherOccupation.Text = "Occupation"
        ' 
        ' txtMotherOccupation
        ' 
        txtMotherOccupation.Location = New Point(423, 116)
        txtMotherOccupation.Margin = New Padding(3, 4, 3, 4)
        txtMotherOccupation.MaxLength = 25
        txtMotherOccupation.Name = "txtMotherOccupation"
        txtMotherOccupation.Size = New Size(171, 27)
        txtMotherOccupation.TabIndex = 3
        ' 
        ' lblFatherName
        ' 
        lblFatherName.AutoSize = True
        lblFatherName.Location = New Point(23, 160)
        lblFatherName.Name = "lblFatherName"
        lblFatherName.Size = New Size(129, 20)
        lblFatherName.TabIndex = 21
        lblFatherName.Text = "Father's Full Name"
        ' 
        ' txtFatherName
        ' 
        txtFatherName.Location = New Point(167, 156)
        txtFatherName.Margin = New Padding(3, 4, 3, 4)
        txtFatherName.MaxLength = 35
        txtFatherName.Name = "txtFatherName"
        txtFatherName.Size = New Size(427, 27)
        txtFatherName.TabIndex = 4
        ' 
        ' lblFatherAddress
        ' 
        lblFatherAddress.AutoSize = True
        lblFatherAddress.Location = New Point(23, 200)
        lblFatherAddress.Name = "lblFatherAddress"
        lblFatherAddress.Size = New Size(62, 20)
        lblFatherAddress.TabIndex = 23
        lblFatherAddress.Text = "Address"
        ' 
        ' txtFatherAddress
        ' 
        txtFatherAddress.Location = New Point(167, 196)
        txtFatherAddress.Margin = New Padding(3, 4, 3, 4)
        txtFatherAddress.MaxLength = 75
        txtFatherAddress.Name = "txtFatherAddress"
        txtFatherAddress.Size = New Size(427, 27)
        txtFatherAddress.TabIndex = 5
        ' 
        ' lblFatherPhone
        ' 
        lblFatherPhone.AutoSize = True
        lblFatherPhone.Location = New Point(23, 240)
        lblFatherPhone.Name = "lblFatherPhone"
        lblFatherPhone.Size = New Size(50, 20)
        lblFatherPhone.TabIndex = 25
        lblFatherPhone.Text = "Phone"
        ' 
        ' txtFatherPhone
        ' 
        txtFatherPhone.Location = New Point(167, 236)
        txtFatherPhone.Margin = New Padding(3, 4, 3, 4)
        txtFatherPhone.MaxLength = 11
        txtFatherPhone.Name = "txtFatherPhone"
        txtFatherPhone.Size = New Size(150, 27)
        txtFatherPhone.TabIndex = 6
        ' 
        ' lblFatherOccupation
        ' 
        lblFatherOccupation.AutoSize = True
        lblFatherOccupation.Location = New Point(331, 240)
        lblFatherOccupation.Name = "lblFatherOccupation"
        lblFatherOccupation.Size = New Size(85, 20)
        lblFatherOccupation.TabIndex = 27
        lblFatherOccupation.Text = "Occupation"
        ' 
        ' txtFatherOccupation
        ' 
        txtFatherOccupation.Location = New Point(423, 236)
        txtFatherOccupation.Margin = New Padding(3, 4, 3, 4)
        txtFatherOccupation.MaxLength = 25
        txtFatherOccupation.Name = "txtFatherOccupation"
        txtFatherOccupation.Size = New Size(171, 27)
        txtFatherOccupation.TabIndex = 7
        ' 
        ' lblGuardianName
        ' 
        lblGuardianName.AutoSize = True
        lblGuardianName.Location = New Point(23, 280)
        lblGuardianName.Name = "lblGuardianName"
        lblGuardianName.Size = New Size(149, 20)
        lblGuardianName.TabIndex = 28
        lblGuardianName.Text = "Guardian's Full Name"
        ' 
        ' txtGuardianName
        ' 
        txtGuardianName.Location = New Point(167, 276)
        txtGuardianName.Margin = New Padding(3, 4, 3, 4)
        txtGuardianName.MaxLength = 35
        txtGuardianName.Name = "txtGuardianName"
        txtGuardianName.Size = New Size(427, 27)
        txtGuardianName.TabIndex = 8
        ' 
        ' scrollPanel
        ' 
        scrollPanel.AutoScroll = True
        scrollPanel.Controls.Add(lblHeader)
        scrollPanel.Controls.Add(Label1)
        scrollPanel.Controls.Add(grpStudentInfo)
        scrollPanel.Controls.Add(grpParentGuardian)
        scrollPanel.Controls.Add(grpAcademic)
        scrollPanel.Controls.Add(grpContact)
        scrollPanel.Controls.Add(btnUpdate)
        scrollPanel.Controls.Add(btnCancel)
        scrollPanel.Controls.Add(lblStatus)
        scrollPanel.Location = New Point(0, 0)
        scrollPanel.Name = "scrollPanel"
        scrollPanel.Size = New Size(686, 767)
        scrollPanel.TabIndex = 100
        ' 
        ' vScrollBar
        ' 
        vScrollBar.Location = New Point(0, 0)
        vScrollBar.Name = "vScrollBar"
        vScrollBar.Size = New Size(21, 100)
        vScrollBar.TabIndex = 0
        ' 
        ' UpdateStudentRegistration
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(686, 773)
        Controls.Add(scrollPanel)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "UpdateStudentRegistration"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Update Student Registration"
        grpStudentInfo.ResumeLayout(False)
        grpStudentInfo.PerformLayout()
        grpAcademic.ResumeLayout(False)
        grpAcademic.PerformLayout()
        grpContact.ResumeLayout(False)
        grpContact.PerformLayout()
        grpParentGuardian.ResumeLayout(False)
        grpParentGuardian.PerformLayout()
        scrollPanel.ResumeLayout(False)
        scrollPanel.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents grpStudentInfo As GroupBox
    Friend WithEvents txtDOB As DateTimePicker
    Friend WithEvents cboGender As ComboBox
    Friend WithEvents txtAge As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents lblDOB As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents lblAge As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblMiddleName As Label
    Friend WithEvents lblStudentID As Label
    Friend WithEvents grpAcademic As GroupBox
    Friend WithEvents txtSection As TextBox
    Friend WithEvents cboYearLevel As ComboBox
    Friend WithEvents cboCourse As ComboBox
    Friend WithEvents lblSection As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lblCourse As Label
    Friend WithEvents grpContact As GroupBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblSectionError As Label
    Friend WithEvents lblStudentIDError As Label
    Friend WithEvents cboNationality As ComboBox
    Friend WithEvents lblNationality As Label
    Friend WithEvents cboSuffix As ComboBox
    Friend WithEvents lblSuffix As Label
    Friend WithEvents txtStreetName As TextBox
    Friend WithEvents txtBarangay As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtProvince As TextBox
    Friend WithEvents txtZipCode As TextBox
    Friend WithEvents lblStreetName As Label
    Friend WithEvents lblBarangay As Label
    Friend WithEvents lblCity As Label
    Friend WithEvents lblProvince As Label
    Friend WithEvents lblZipCode As Label
    Friend WithEvents txtPlaceOfBirth As TextBox
    Friend WithEvents lblPlaceOfBirth As Label
    Friend WithEvents grpParentGuardian As GroupBox
    Friend WithEvents lblMotherName As Label
    Friend WithEvents txtMotherName As TextBox
    Friend WithEvents lblMotherAddress As Label
    Friend WithEvents txtMotherAddress As TextBox
    Friend WithEvents lblMotherPhone As Label
    Friend WithEvents txtMotherPhone As TextBox
    Friend WithEvents lblMotherOccupation As Label
    Friend WithEvents txtMotherOccupation As TextBox
    Friend WithEvents lblFatherName As Label
    Friend WithEvents txtFatherName As TextBox
    Friend WithEvents lblFatherAddress As Label
    Friend WithEvents txtFatherAddress As TextBox
    Friend WithEvents lblFatherPhone As Label
    Friend WithEvents txtFatherPhone As TextBox
    Friend WithEvents lblFatherOccupation As Label
    Friend WithEvents txtFatherOccupation As TextBox
    Friend WithEvents lblGuardianName As Label
    Friend WithEvents txtGuardianName As TextBox
    Friend WithEvents scrollPanel As Panel
    Friend WithEvents vScrollBar As VScrollBar
    Friend WithEvents Label1 As Label
    Friend WithEvents txtGuardianOccupation As TextBox
    Friend WithEvents lblGuardianOccupation As Label
    Friend WithEvents txtGuardianPhone As TextBox
    Friend WithEvents lblGuardianPhone As Label

    ' === Input Validation Event Handlers (Same as Registration Form) ===
    Private Sub txtLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastName.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
       Not Char.IsLetter(e.KeyChar) AndAlso
       Not Char.IsWhiteSpace(e.KeyChar) AndAlso
       e.KeyChar <> "'"c AndAlso
       e.KeyChar <> "-"c AndAlso
       e.KeyChar <> "."c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirstName.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
       Not Char.IsLetter(e.KeyChar) AndAlso
       Not Char.IsWhiteSpace(e.KeyChar) AndAlso
       e.KeyChar <> "'"c AndAlso
       e.KeyChar <> "-"c AndAlso
       e.KeyChar <> "."c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMiddleName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMiddleName.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
       Not Char.IsLetter(e.KeyChar) AndAlso
       Not Char.IsWhiteSpace(e.KeyChar) AndAlso
       e.KeyChar <> "'"c AndAlso
       e.KeyChar <> "-"c AndAlso
       e.KeyChar <> "."c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        Dim cursorPos As Integer = txtLastName.SelectionStart
        txtLastName.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text.ToLower())
        txtLastName.SelectionStart = cursorPos
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        Dim cursorPos As Integer = txtFirstName.SelectionStart
        txtFirstName.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFirstName.Text.ToLower())
        txtFirstName.SelectionStart = cursorPos
    End Sub

    Private Sub txtMiddleName_TextChanged(sender As Object, e As EventArgs) Handles txtMiddleName.TextChanged
        Dim cursorPos As Integer = txtMiddleName.SelectionStart
        txtMiddleName.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMiddleName.Text.ToLower())
        txtMiddleName.SelectionStart = cursorPos
    End Sub

    Private Sub txtDOB_ValueChanged(sender As Object, e As EventArgs) Handles txtDOB.ValueChanged
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - txtDOB.Value.Year
        If (txtDOB.Value > today.AddYears(-age)) Then
            age -= 1
        End If
        txtAge.Text = age.ToString()
    End Sub

    ' === Phone fields: Numbers only ===
    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMotherPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMotherPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFatherPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFatherPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtGuardianPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGuardianPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' === ZIP Code: Numbers only ===
    Private Sub txtZipCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtZipCode.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class