if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, University, Faculty, Specialization, Email)
	values ('Yergazy', 'Karibay', 'CZU', 'PEF', 'informatics', 'yergazykaribay@gmail.com'),
	('Yerkebulan', 'Kaldybaev', 'CZU', 'PEF', 'informatics', 'Yerklik@gmail.com');
end