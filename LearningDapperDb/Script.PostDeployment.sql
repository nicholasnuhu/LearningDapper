if not exists(select 1 FROM [User])
BEGIN
INSERT INTO [User](FirstName, LastName)
VALUES('Nick', 'Nuhu'),
		('Emmanuel' , 'Shamaki'),
		('Sunday' , 'Alu'),
		('Kavani' , 'Nuhu'),
		('Godiya' , 'Shamaki')
END
