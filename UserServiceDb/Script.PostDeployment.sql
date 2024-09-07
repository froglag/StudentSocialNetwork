if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, UniversityId, FacultyId, SpecializationId, Email)
	values ('Yergazy', 'Karibay', 1, 1, 1, 'yergazykaribay@gmail.com'),
	('Yerkebulan', 'Kaldybaev', 1, 1, 1, 'Yerklik@gmail.com');
end