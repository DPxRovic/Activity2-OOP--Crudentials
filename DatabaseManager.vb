Imports MySql.Data.MySqlClient

Public Class DatabaseManager
    Private ReadOnly connectionString As String = "server=localhost;user id=root;password=;database=studentdb"

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
                    Section VARCHAR(10),
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

    ' CREATE: Insert a new student record
    Public Function InsertStudent(student As StudentRecord) As Boolean
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
                cmd.Parameters.AddWithValue("@DOB", student.DOB)
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
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "UPDATE students SET LastName=@LastName, FirstName=@FirstName, MiddleName=@MiddleName, Address=@Address, PlaceOfBirth=@PlaceOfBirth, DOB=@DOB, Age=@Age, Gender=@Gender, Nationality=@Nationality, Course=@Course, YearLevel=@YearLevel, Section=@Section WHERE StudentID=@StudentID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID)
                cmd.Parameters.AddWithValue("@LastName", student.LastName)
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName)
                cmd.Parameters.AddWithValue("@MiddleName", student.MiddleName)
                cmd.Parameters.AddWithValue("@Address", student.Address)
                cmd.Parameters.AddWithValue("@PlaceOfBirth", student.PlaceOfBirth)
                cmd.Parameters.AddWithValue("@DOB", student.DOB)
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
                cmd.Parameters.AddWithValue("@DOB", student.DOB)
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