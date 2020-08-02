CREATE OR ALTER PROCEDURE sp_ShowStudentsWithAvailability
	@showDeleted bit = 0
AS
BEGIN
	SELECT
		St.Id AS 'Student Id',
		St.FirstName AS 'Student Name',
		St.Surname AS 'Student Surname',

		COUNT(Co.Id) AS 'Courses Enrolled'

	FROM Students AS St WITH (NOLOCK)
		INNER JOIN StudentCourses AS StCo WITH (NOLOCK) ON StCo.StudentId = St.Id
		INNER JOIN Courses AS Co WITH (NOLOCK) ON StCo.CourseId = Co.Id	
	WHERE
		(@showDeleted = 1 OR St.DeleteDate IS NULL)
		/*
		Even if showDeleted is enabled I don't see how not showing Students because of deleted Courses could be of any help
		(@showDeleted = 1 OR Co.DeleteDate IS NULL)
		*/
	GROUP BY
		St.Id,
		St.FirstName,
		St.Surname
	HAVING COUNT(Co.Id) < 5
	
	ORDER BY
		St.Id Asc
END
GO


--/*
	exec sp_ShowStudentsWithAvailability
--*/exec sp_ShowStudentsWithAvailability @showDeleted = 1

