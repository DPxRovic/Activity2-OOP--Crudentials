Imports MySql.Data.MySqlClient

Public Class DatabaseManager
    Private ReadOnly connectionString As String = "server=localhost;user id=root;password=;database=studentdb"

    ' Get connection string (public method for other classes)
    Public Function GetConnectionString() As String
        Return connectionString
    End Function

    ' Ensure the students table exists with all fields
    Public Sub EnsureTableExists()
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "
                CREATE TABLE IF NOT EXISTS students (
                    StudentID VARCHAR(20) PRIMARY KEY,
                    LastName VARCHAR(50),
                    FirstName VARCHAR(50),
                    MiddleName VARCHAR(50),
                    Suffix VARCHAR(10),
                    Address VARCHAR(255),
                    PlaceOfBirth VARCHAR(100),
                    DOB DATE,
                    Age INT,
                    Gender VARCHAR(20),
                    Nationality VARCHAR(50),
                    Course VARCHAR(50),
                    YearLevel VARCHAR(20),
                    Section CHAR(1),
                    Phone VARCHAR(15),
                    Email VARCHAR(150),
                    MotherName VARCHAR(50),
                    MotherAddress VARCHAR(100),
                    MotherPhone VARCHAR(15),
                    MotherOccupation VARCHAR(50),
                    FatherName VARCHAR(50),
                    FatherAddress VARCHAR(100),
                    FatherPhone VARCHAR(15),
                    FatherOccupation VARCHAR(50),
                    GuardianName VARCHAR(50),
                    GuardianPhone VARCHAR(15),
                    GuardianOccupation VARCHAR(50)
                )"
            Using cmd As New MySqlCommand(query, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Ensure the archive table exists with all fields (same structure as students + timestamp)
    Public Sub EnsureArchiveTableExists()
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "
                CREATE TABLE IF NOT EXISTS archive (
                    StudentID VARCHAR(20) PRIMARY KEY,
                    LastName VARCHAR(50),
                    FirstName VARCHAR(50),
                    MiddleName VARCHAR(50),
                    Suffix VARCHAR(10),
                    Address VARCHAR(255),
                    PlaceOfBirth VARCHAR(100),
                    DOB DATE,
                    Age INT,
                    Gender VARCHAR(20),
                    Nationality VARCHAR(50),
                    Course VARCHAR(50),
                    YearLevel VARCHAR(20),
                    Section CHAR(1),
                    Phone VARCHAR(15),
                    Email VARCHAR(150),
                    MotherName VARCHAR(50),
                    MotherAddress VARCHAR(100),
                    MotherPhone VARCHAR(15),
                    MotherOccupation VARCHAR(50),
                    FatherName VARCHAR(50),
                    FatherAddress VARCHAR(100),
                    FatherPhone VARCHAR(15),
                    FatherOccupation VARCHAR(50),
                    GuardianName VARCHAR(50),
                    GuardianPhone VARCHAR(15),
                    GuardianOccupation VARCHAR(50),
                    ArchivedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                )"
            Using cmd As New MySqlCommand(query, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Small helper to validate section input on server-side
    Private Function IsValidSectionForDb(section As String) As Boolean
        If String.IsNullOrWhiteSpace(section) Then Return False
        Return System.Text.RegularExpressions.Regex.IsMatch(section.Trim(), "^[A-Za-z]$")
    End Function

    ' CREATE: Insert a new student record
    Public Function InsertStudent(student As StudentRecord) As Boolean
        ' Validate Section server-side to avoid storing invalid sections
        If Not IsValidSectionForDb(student.Section) Then
            Return False
        End If

        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "INSERT INTO students (StudentID, LastName, FirstName, MiddleName, Suffix, Address, PlaceOfBirth, DOB, Age, Gender, Nationality, Course, YearLevel, Section, Phone, Email, MotherName, MotherAddress, MotherPhone, MotherOccupation, FatherName, FatherAddress, FatherPhone, FatherOccupation, GuardianName, GuardianPhone, GuardianOccupation) " &
                                  "VALUES (@StudentID, @LastName, @FirstName, @MiddleName, @Suffix, @Address, @PlaceOfBirth, @DOB, @Age, @Gender, @Nationality, @Course, @YearLevel, @Section, @Phone, @Email, @MotherName, @MotherAddress, @MotherPhone, @MotherOccupation, @FatherName, @FatherAddress, @FatherPhone, @FatherOccupation, @GuardianName, @GuardianPhone, @GuardianOccupation)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID)
                cmd.Parameters.AddWithValue("@LastName", student.LastName)
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName)
                cmd.Parameters.AddWithValue("@MiddleName", student.MiddleName)
                cmd.Parameters.AddWithValue("@Suffix", student.Suffix)
                cmd.Parameters.AddWithValue("@Address", student.Address)
                cmd.Parameters.AddWithValue("@PlaceOfBirth", student.PlaceOfBirth)
                cmd.Parameters.AddWithValue("@DOB", If(student.DOB = Date.MinValue, CType(DBNull.Value, Object), student.DOB))
                cmd.Parameters.AddWithValue("@Age", student.Age)
                cmd.Parameters.AddWithValue("@Gender", student.Gender)
                cmd.Parameters.AddWithValue("@Nationality", student.Nationality)
                cmd.Parameters.AddWithValue("@Course", student.Course)
                cmd.Parameters.AddWithValue("@YearLevel", student.YearLevel)
                cmd.Parameters.AddWithValue("@Section", student.Section)
                cmd.Parameters.AddWithValue("@Phone", student.Phone)
                cmd.Parameters.AddWithValue("@Email", student.Email)
                cmd.Parameters.AddWithValue("@MotherName", student.MotherName)
                cmd.Parameters.AddWithValue("@MotherAddress", student.MotherAddress)
                cmd.Parameters.AddWithValue("@MotherPhone", student.MotherPhone)
                cmd.Parameters.AddWithValue("@MotherOccupation", student.MotherOccupation)
                cmd.Parameters.AddWithValue("@FatherName", student.FatherName)
                cmd.Parameters.AddWithValue("@FatherAddress", student.FatherAddress)
                cmd.Parameters.AddWithValue("@FatherPhone", student.FatherPhone)
                cmd.Parameters.AddWithValue("@FatherOccupation", student.FatherOccupation)
                cmd.Parameters.AddWithValue("@GuardianName", student.GuardianName)
                cmd.Parameters.AddWithValue("@GuardianPhone", student.GuardianPhone)
                cmd.Parameters.AddWithValue("@GuardianOccupation", student.GuardianOccupation)
                conn.Open()
                Return cmd.ExecuteNonQuery() = 1
            End Using
        End Using
    End Function

    ' READ: Get all student records
    Public Function GetAllStudents() As DataTable
        Dim dt As New DataTable()
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "SELECT * FROM students"
            Using cmd As New MySqlCommand(query, conn)
                conn.Open()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' UPDATE: Update a student record by StudentID (Basic fields only - for backward compatibility)
    Public Function UpdateStudent(student As StudentRecord) As Boolean
        If Not IsValidSectionForDb(student.Section) Then
            Return False
        End If

        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "UPDATE students SET LastName=@LastName, FirstName=@FirstName, MiddleName=@MiddleName, Address=@Address, PlaceOfBirth=@PlaceOfBirth, DOB=@DOB, Age=@Age, Gender=@Gender, Nationality=@Nationality, Course=@Course, YearLevel=@YearLevel, Section=@Section WHERE StudentID=@StudentID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID)
                cmd.Parameters.AddWithValue("@LastName", student.LastName)
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName)
                cmd.Parameters.AddWithValue("@MiddleName", student.MiddleName)
                cmd.Parameters.AddWithValue("@Address", student.Address)
                cmd.Parameters.AddWithValue("@PlaceOfBirth", student.PlaceOfBirth)
                cmd.Parameters.AddWithValue("@DOB", If(student.DOB = Date.MinValue, CType(DBNull.Value, Object), student.DOB))
                cmd.Parameters.AddWithValue("@Age", student.Age)
                cmd.Parameters.AddWithValue("@Gender", student.Gender)
                cmd.Parameters.AddWithValue("@Nationality", student.Nationality)
                cmd.Parameters.AddWithValue("@Course", student.Course)
                cmd.Parameters.AddWithValue("@YearLevel", student.YearLevel)
                cmd.Parameters.AddWithValue("@Section", student.Section)
                conn.Open()
                Return cmd.ExecuteNonQuery() = 1
            End Using
        End Using
    End Function

    ' UPDATE COMPLETE: Update a student record with ALL fields (for UpdateStudentRegistration form)
    Public Function UpdateStudentComplete(student As StudentRecord) As Boolean
        If Not IsValidSectionForDb(student.Section) Then
            Return False
        End If

        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "UPDATE students SET " &
                                  "LastName=@LastName, FirstName=@FirstName, MiddleName=@MiddleName, Suffix=@Suffix, " &
                                  "Address=@Address, PlaceOfBirth=@PlaceOfBirth, DOB=@DOB, Age=@Age, " &
                                  "Gender=@Gender, Nationality=@Nationality, Course=@Course, YearLevel=@YearLevel, Section=@Section, " &
                                  "Phone=@Phone, Email=@Email, " &
                                  "MotherName=@MotherName, MotherAddress=@MotherAddress, MotherPhone=@MotherPhone, MotherOccupation=@MotherOccupation, " &
                                  "FatherName=@FatherName, FatherAddress=@FatherAddress, FatherPhone=@FatherPhone, FatherOccupation=@FatherOccupation, " &
                                  "GuardianName=@GuardianName, GuardianPhone=@GuardianPhone, GuardianOccupation=@GuardianOccupation " &
                                  "WHERE StudentID=@StudentID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID)
                cmd.Parameters.AddWithValue("@LastName", student.LastName)
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName)
                cmd.Parameters.AddWithValue("@MiddleName", student.MiddleName)
                cmd.Parameters.AddWithValue("@Suffix", student.Suffix)
                cmd.Parameters.AddWithValue("@Address", student.Address)
                cmd.Parameters.AddWithValue("@PlaceOfBirth", student.PlaceOfBirth)
                cmd.Parameters.AddWithValue("@DOB", If(student.DOB = Date.MinValue, CType(DBNull.Value, Object), student.DOB))
                cmd.Parameters.AddWithValue("@Age", student.Age)
                cmd.Parameters.AddWithValue("@Gender", student.Gender)
                cmd.Parameters.AddWithValue("@Nationality", student.Nationality)
                cmd.Parameters.AddWithValue("@Course", student.Course)
                cmd.Parameters.AddWithValue("@YearLevel", student.YearLevel)
                cmd.Parameters.AddWithValue("@Section", student.Section)
                cmd.Parameters.AddWithValue("@Phone", student.Phone)
                cmd.Parameters.AddWithValue("@Email", student.Email)
                cmd.Parameters.AddWithValue("@MotherName", student.MotherName)
                cmd.Parameters.AddWithValue("@MotherAddress", student.MotherAddress)
                cmd.Parameters.AddWithValue("@MotherPhone", student.MotherPhone)
                cmd.Parameters.AddWithValue("@MotherOccupation", student.MotherOccupation)
                cmd.Parameters.AddWithValue("@FatherName", student.FatherName)
                cmd.Parameters.AddWithValue("@FatherAddress", student.FatherAddress)
                cmd.Parameters.AddWithValue("@FatherPhone", student.FatherPhone)
                cmd.Parameters.AddWithValue("@FatherOccupation", student.FatherOccupation)
                cmd.Parameters.AddWithValue("@GuardianName", student.GuardianName)
                cmd.Parameters.AddWithValue("@GuardianPhone", student.GuardianPhone)
                cmd.Parameters.AddWithValue("@GuardianOccupation", student.GuardianOccupation)
                conn.Open()
                Return cmd.ExecuteNonQuery() = 1
            End Using
        End Using
    End Function

    ' DELETE: Delete a student record by StudentID
    Public Function DeleteStudent(studentID As String) As Boolean
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "DELETE FROM students WHERE StudentID=@StudentID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", studentID)
                conn.Open()
                Return cmd.ExecuteNonQuery() = 1
            End Using
        End Using
    End Function

    ' Returns the next StudentID for the current year (format: YYYY0001, YYYY0002, ...)
    Public Function GetNextStudentID() As String
        Dim year As String = DateTime.Now.Year.ToString()
        Dim nextNumber As Integer = 1
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM students WHERE StudentID LIKE @YearPrefix"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@YearPrefix", year & "%")
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                nextNumber = count + 1
            End Using
        End Using
        Return year & nextNumber.ToString("D4")
    End Function

    ' === ARCHIVE SYSTEM METHODS ===

    ' Move student record to archive (copies to archive table then deletes from students)
    Public Shared Function MoveToArchive(student As StudentRecord) As Boolean
        Try
            Dim db As New DatabaseManager()
            db.EnsureArchiveTableExists() ' Ensure archive table exists

            Using conn As New MySqlConnection(db.GetConnectionString())
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' Insert into archive table
                        Dim insertQuery As String = "INSERT INTO archive (StudentID, LastName, FirstName, MiddleName, Suffix, Address, PlaceOfBirth, DOB, Age, Gender, Nationality, Course, YearLevel, Section, Phone, Email, MotherName, MotherAddress, MotherPhone, MotherOccupation, FatherName, FatherAddress, FatherPhone, FatherOccupation, GuardianName, GuardianPhone, GuardianOccupation) " &
                                                    "VALUES (@StudentID, @LastName, @FirstName, @MiddleName, @Suffix, @Address, @PlaceOfBirth, @DOB, @Age, @Gender, @Nationality, @Course, @YearLevel, @Section, @Phone, @Email, @MotherName, @MotherAddress, @MotherPhone, @MotherOccupation, @FatherName, @FatherAddress, @FatherPhone, @FatherOccupation, @GuardianName, @GuardianPhone, @GuardianOccupation)"
                        Using insertCmd As New MySqlCommand(insertQuery, conn, transaction)
                            insertCmd.Parameters.AddWithValue("@StudentID", student.StudentID)
                            insertCmd.Parameters.AddWithValue("@LastName", student.LastName)
                            insertCmd.Parameters.AddWithValue("@FirstName", student.FirstName)
                            insertCmd.Parameters.AddWithValue("@MiddleName", student.MiddleName)
                            insertCmd.Parameters.AddWithValue("@Suffix", student.Suffix)
                            insertCmd.Parameters.AddWithValue("@Address", student.Address)
                            insertCmd.Parameters.AddWithValue("@PlaceOfBirth", student.PlaceOfBirth)
                            insertCmd.Parameters.AddWithValue("@DOB", If(student.DOB = Date.MinValue, CType(DBNull.Value, Object), student.DOB))
                            insertCmd.Parameters.AddWithValue("@Age", student.Age)
                            insertCmd.Parameters.AddWithValue("@Gender", student.Gender)
                            insertCmd.Parameters.AddWithValue("@Nationality", student.Nationality)
                            insertCmd.Parameters.AddWithValue("@Course", student.Course)
                            insertCmd.Parameters.AddWithValue("@YearLevel", student.YearLevel)
                            insertCmd.Parameters.AddWithValue("@Section", student.Section)
                            insertCmd.Parameters.AddWithValue("@Phone", student.Phone)
                            insertCmd.Parameters.AddWithValue("@Email", student.Email)
                            insertCmd.Parameters.AddWithValue("@MotherName", student.MotherName)
                            insertCmd.Parameters.AddWithValue("@MotherAddress", student.MotherAddress)
                            insertCmd.Parameters.AddWithValue("@MotherPhone", student.MotherPhone)
                            insertCmd.Parameters.AddWithValue("@MotherOccupation", student.MotherOccupation)
                            insertCmd.Parameters.AddWithValue("@FatherName", student.FatherName)
                            insertCmd.Parameters.AddWithValue("@FatherAddress", student.FatherAddress)
                            insertCmd.Parameters.AddWithValue("@FatherPhone", student.FatherPhone)
                            insertCmd.Parameters.AddWithValue("@FatherOccupation", student.FatherOccupation)
                            insertCmd.Parameters.AddWithValue("@GuardianName", student.GuardianName)
                            insertCmd.Parameters.AddWithValue("@GuardianPhone", student.GuardianPhone)
                            insertCmd.Parameters.AddWithValue("@GuardianOccupation", student.GuardianOccupation)
                            insertCmd.ExecuteNonQuery()
                        End Using

                        ' Delete from students table
                        Dim deleteQuery As String = "DELETE FROM students WHERE StudentID = @StudentID"
                        Using deleteCmd As New MySqlCommand(deleteQuery, conn, transaction)
                            deleteCmd.Parameters.AddWithValue("@StudentID", student.StudentID)
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        ' Commit transaction
                        transaction.Commit()
                        Return True
                    Catch ex As Exception
                        transaction.Rollback()
                        Return False
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Restore student record from archive (copies back to students table then deletes from archive)
    Public Shared Function RestoreFromArchive(studentID As String) As Boolean
        Try
            Dim db As New DatabaseManager()
            Using conn As New MySqlConnection(db.GetConnectionString())
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' Get student record from archive
                        Dim student As StudentRecord = GetStudentFromArchive(studentID)
                        If student Is Nothing Then
                            Return False
                        End If

                        ' Insert back into students table (validate Section)
                        If Not System.Text.RegularExpressions.Regex.IsMatch(student.Section.Trim(), "^[A-Za-z]$") Then
                            ' Section invalid, block restore
                            Return False
                        End If

                        Dim insertQuery As String = "INSERT INTO students (StudentID, LastName, FirstName, MiddleName, Suffix, Address, PlaceOfBirth, DOB, Age, Gender, Nationality, Course, YearLevel, Section, Phone, Email, MotherName, MotherAddress, MotherPhone, MotherOccupation, FatherName, FatherAddress, FatherPhone, FatherOccupation, GuardianName, GuardianPhone, GuardianOccupation) " &
                                                    "VALUES (@StudentID, @LastName, @FirstName, @MiddleName, @Suffix, @Address, @PlaceOfBirth, @DOB, @Age, @Gender, @Nationality, @Course, @YearLevel, @Section, @Phone, @Email, @MotherName, @MotherAddress, @MotherPhone, @MotherOccupation, @FatherName, @FatherAddress, @FatherPhone, @FatherOccupation, @GuardianName, @GuardianPhone, @GuardianOccupation)"
                        Using insertCmd As New MySqlCommand(insertQuery, conn, transaction)
                            insertCmd.Parameters.AddWithValue("@StudentID", student.StudentID)
                            insertCmd.Parameters.AddWithValue("@LastName", student.LastName)
                            insertCmd.Parameters.AddWithValue("@FirstName", student.FirstName)
                            insertCmd.Parameters.AddWithValue("@MiddleName", student.MiddleName)
                            insertCmd.Parameters.AddWithValue("@Suffix", student.Suffix)
                            insertCmd.Parameters.AddWithValue("@Address", student.Address)
                            insertCmd.Parameters.AddWithValue("@PlaceOfBirth", student.PlaceOfBirth)
                            insertCmd.Parameters.AddWithValue("@DOB", If(student.DOB = Date.MinValue, CType(DBNull.Value, Object), student.DOB))
                            insertCmd.Parameters.AddWithValue("@Age", student.Age)
                            insertCmd.Parameters.AddWithValue("@Gender", student.Gender)
                            insertCmd.Parameters.AddWithValue("@Nationality", student.Nationality)
                            insertCmd.Parameters.AddWithValue("@Course", student.Course)
                            insertCmd.Parameters.AddWithValue("@YearLevel", student.YearLevel)
                            insertCmd.Parameters.AddWithValue("@Section", student.Section)
                            insertCmd.Parameters.AddWithValue("@Phone", student.Phone)
                            insertCmd.Parameters.AddWithValue("@Email", student.Email)
                            insertCmd.Parameters.AddWithValue("@MotherName", student.MotherName)
                            insertCmd.Parameters.AddWithValue("@MotherAddress", student.MotherAddress)
                            insertCmd.Parameters.AddWithValue("@MotherPhone", student.MotherPhone)
                            insertCmd.Parameters.AddWithValue("@MotherOccupation", student.MotherOccupation)
                            insertCmd.Parameters.AddWithValue("@FatherName", student.FatherName)
                            insertCmd.Parameters.AddWithValue("@FatherAddress", student.FatherAddress)
                            insertCmd.Parameters.AddWithValue("@FatherPhone", student.FatherPhone)
                            insertCmd.Parameters.AddWithValue("@FatherOccupation", student.FatherOccupation)
                            insertCmd.Parameters.AddWithValue("@GuardianName", student.GuardianName)
                            insertCmd.Parameters.AddWithValue("@GuardianPhone", student.GuardianPhone)
                            insertCmd.Parameters.AddWithValue("@GuardianOccupation", student.GuardianOccupation)
                            insertCmd.ExecuteNonQuery()
                        End Using

                        ' Delete from archive table
                        Dim deleteQuery As String = "DELETE FROM archive WHERE StudentID = @StudentID"
                        Using deleteCmd As New MySqlCommand(deleteQuery, conn, transaction)
                            deleteCmd.Parameters.AddWithValue("@StudentID", studentID)
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        ' Commit transaction
                        transaction.Commit()
                        Return True
                    Catch ex As Exception
                        transaction.Rollback()
                        Return False
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Delete permanently from archive
    Public Shared Function DeleteFromArchive(studentID As String) As Boolean
        Try
            Dim db As New DatabaseManager()
            Using conn As New MySqlConnection(db.connectionString)
                Dim query As String = "DELETE FROM archive WHERE StudentID = @StudentID"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudentID", studentID)
                    conn.Open()
                    Return cmd.ExecuteNonQuery() = 1
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Get all archived student records
    Public Shared Function GetArchiveData() As DataTable
        Try
            Dim db As New DatabaseManager()
            db.EnsureArchiveTableExists() ' Ensure archive table exists

            Dim dt As New DataTable()
            Using conn As New MySqlConnection(db.connectionString)
                Dim query As String = "SELECT * FROM archive ORDER BY ArchivedDate DESC"
                Using cmd As New MySqlCommand(query, conn)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            End Using
            Return dt
        Catch ex As Exception
            Return New DataTable()
        End Try
    End Function

    ' Helper method to get a student record from archive
    Private Shared Function GetStudentFromArchive(studentID As String) As StudentRecord
        Try
            Dim db As New DatabaseManager()
            Using conn As New MySqlConnection(db.connectionString)
                Dim query As String = "SELECT * FROM archive WHERE StudentID = @StudentID"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudentID", studentID)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim student As New StudentRecord()
                            student.StudentID = reader("StudentID").ToString()
                            student.LastName = If(IsDBNull(reader("LastName")), "", reader("LastName").ToString())
                            student.FirstName = If(IsDBNull(reader("FirstName")), "", reader("FirstName").ToString())
                            student.MiddleName = If(IsDBNull(reader("MiddleName")), "", reader("MiddleName").ToString())
                            student.Suffix = If(IsDBNull(reader("Suffix")), "", reader("Suffix").ToString())
                            student.Address = If(IsDBNull(reader("Address")), "", reader("Address").ToString())
                            student.PlaceOfBirth = If(IsDBNull(reader("PlaceOfBirth")), "", reader("PlaceOfBirth").ToString())
                            student.DOB = If(IsDBNull(reader("DOB")), Date.MinValue, Convert.ToDateTime(reader("DOB")))
                            student.Age = If(IsDBNull(reader("Age")), 0, Convert.ToInt32(reader("Age")))
                            student.Gender = If(IsDBNull(reader("Gender")), "", reader("Gender").ToString())
                            student.Nationality = If(IsDBNull(reader("Nationality")), "", reader("Nationality").ToString())
                            student.Course = If(IsDBNull(reader("Course")), "", reader("Course").ToString())
                            student.YearLevel = If(IsDBNull(reader("YearLevel")), "", reader("YearLevel").ToString())
                            student.Section = If(IsDBNull(reader("Section")), "", reader("Section").ToString())
                            student.Phone = If(IsDBNull(reader("Phone")), "", reader("Phone").ToString())
                            student.Email = If(IsDBNull(reader("Email")), "", reader("Email").ToString())
                            student.MotherName = If(IsDBNull(reader("MotherName")), "", reader("MotherName").ToString())
                            student.MotherAddress = If(IsDBNull(reader("MotherAddress")), "", reader("MotherAddress").ToString())
                            student.MotherPhone = If(IsDBNull(reader("MotherPhone")), "", reader("MotherPhone").ToString())
                            student.MotherOccupation = If(IsDBNull(reader("MotherOccupation")), "", reader("MotherOccupation").ToString())
                            student.FatherName = If(IsDBNull(reader("FatherName")), "", reader("FatherName").ToString())
                            student.FatherAddress = If(IsDBNull(reader("FatherAddress")), "", reader("FatherAddress").ToString())
                            student.FatherPhone = If(IsDBNull(reader("FatherPhone")), "", reader("FatherPhone").ToString())
                            student.FatherOccupation = If(IsDBNull(reader("FatherOccupation")), "", reader("FatherOccupation").ToString())
                            student.GuardianName = If(IsDBNull(reader("GuardianName")), "", reader("GuardianName").ToString())
                            student.GuardianPhone = If(IsDBNull(reader("GuardianPhone")), "", reader("GuardianPhone").ToString())
                            student.GuardianOccupation = If(IsDBNull(reader("GuardianOccupation")), "", reader("GuardianOccupation").ToString())
                            Return student
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Return Nothing on error
        End Try
        Return Nothing
    End Function

End Class

' Helper class to represent a student record
Public Class StudentRecord
    Public Property StudentID As String
    Public Property LastName As String
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property Suffix As String
    Public Property Address As String
    Public Property PlaceOfBirth As String
    Public Property DOB As Date
    Public Property Age As Integer
    Public Property Gender As String
    Public Property Nationality As String
    Public Property Course As String
    Public Property YearLevel As String
    Public Property Section As String
    Public Property Phone As String
    Public Property Email As String
    Public Property MotherName As String
    Public Property MotherAddress As String
    Public Property MotherPhone As String
    Public Property MotherOccupation As String
    Public Property FatherName As String
    Public Property FatherAddress As String
    Public Property FatherPhone As String
    Public Property FatherOccupation As String
    Public Property GuardianName As String
    Public Property GuardianPhone As String
    Public Property GuardianOccupation As String
End Class