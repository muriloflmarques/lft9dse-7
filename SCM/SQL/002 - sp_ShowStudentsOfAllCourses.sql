CREATE OR ALTER PROCEDURE sp_ShowStudentsOfAllCourses
	@showDeleted bit = 0
AS
BEGIN
	SELECT
		Co.Id AS 'Course Id',
		Co.Name AS 'Course Name',
		Co.TeacherName 'Course Teacher',
		
		St.Id AS 'Student Id',
		St.FirstName AS 'Student Name',
		St.Surname AS 'Student Surname'

	FROM Courses AS Co WITH (NOLOCK)
		INNER JOIN StudentCourses AS StCo WITH (NOLOCK) ON StCo.CourseId = Co.Id
		INNER JOIN Students AS St WITH (NOLOCK) ON StCo.StudentId = St.Id
	WHERE
		(@showDeleted = 1 OR Co.DeleteDate IS NULL)
		AND
		(@showDeleted = 1 OR St.DeleteDate IS NULL)
	ORDER BY
		Co.Id Asc
END
GO


--/*
	exec sp_ShowStudentsOfAllCourses
--*/exec sp_ShowStudentsOfAllCourses @showDeleted = 1

