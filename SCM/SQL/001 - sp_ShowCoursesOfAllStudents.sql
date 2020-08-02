CREATE OR ALTER PROCEDURE sp_ShowCoursesOfAllStudents
	@showDeleted bit = 0
AS
BEGIN
	SELECT
		St.Id AS 'Student Id',
		St.FirstName AS 'Student Name',
		St.Surname AS 'Student Surname',

		Co.Id AS 'Course Id',
		Co.Name AS 'Course Name',
		Co.TeacherName 'Course Teacher'

	FROM Students AS St WITH (NOLOCK)
		INNER JOIN StudentCourses AS StCo WITH (NOLOCK) ON StCo.StudentId = St.Id
		INNER JOIN Courses AS Co WITH (NOLOCK) ON StCo.CourseId = Co.Id
	WHERE
		(@showDeleted = 1 OR St.DeleteDate IS NULL)
		AND
		(@showDeleted = 1 OR Co.DeleteDate IS NULL)
	ORDER BY
		St.Id Asc
END
GO


--/*
	exec sp_ShowCoursesOfAllStudents
--*/exec sp_ShowCoursesOfAllStudents @showDeleted = 1

