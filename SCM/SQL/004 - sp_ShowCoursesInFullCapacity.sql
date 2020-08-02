CREATE OR ALTER PROCEDURE sp_ShowCoursesInFullCapacity
	@showDeleted bit = 0
AS
BEGIN
	SELECT
		Co.Id AS 'Course Id',
		Co.Name AS 'Course Name',
		Co.TeacherName 'Course Teacher',

		COUNT(St.Id) AS 'Students Enrolled'

	FROM Courses AS Co WITH (NOLOCK)
		INNER JOIN StudentCourses AS StCo WITH (NOLOCK) ON StCo.CourseId = Co.Id
		INNER JOIN Students AS St WITH (NOLOCK) ON StCo.StudentId = St.Id	
	WHERE
		/*
		Even if showDeleted is enabled I (also) don't see how showing Courses as 'full capacity' because of deleted Students could be of any help
		(0 = 1 OR St.DeleteDate IS NULL)
		*/	
		(@showDeleted = 1 OR Co.DeleteDate IS NULL)
		
	GROUP BY
		Co.Id,
		Co.Name,
		Co.TeacherName,
		Co.Capacity
	HAVING COUNT(Co.Id) < Co.Capacity
	
	ORDER BY
		Co.Id Asc
END
GO


--/*
	exec sp_ShowCoursesInFullCapacity
--*/exec sp_ShowCoursesInFullCapacity @showDeleted = 1

