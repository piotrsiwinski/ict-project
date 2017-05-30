-- Universities
SET IDENTITY_INSERT [ictDb_dev].[dbo].[Universities] ON 
INSERT INTO [ictDb_dev].[dbo].[Universities]([Id],[Name]) VALUES(1, 'Politechnika Poznańska');
INSERT INTO [ictDb_dev].[dbo].[Universities]([Id],[Name]) VALUES(2, 'Uniwersytet Ekonomiczny w Poznaniu');
INSERT INTO [ictDb_dev].[dbo].[Universities]([Id],[Name]) VALUES(3, 'Uniwersytet Adama Mickiewicza');
INSERT INTO [ictDb_dev].[dbo].[Universities]([Id],[Name]) VALUES(4, 'Uniwersytet Przyrodniczy');
INSERT INTO [ictDb_dev].[dbo].[Universities]([Id],[Name]) VALUES(5, 'Uniwersytet Medyczny');

SET IDENTITY_INSERT [ictDb_dev].[dbo].[Universities] OFF 

-- Faculties
SET IDENTITY_INSERT [ictDb_dev].[dbo].[Faculties] ON 
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (1, 'Wydział Architektury', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (2, 'Wydział Budownictwa i Inżynierii Środowiska', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (3, 'Wydział Budowy Maszyn i Zarządzania', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (4, 'Wydział Elektroniki i Telekomunikacji', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (5, 'Wydział Elektryczny', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (6, 'Wydział Fizyki Techniczej', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (7, 'Wydział Informatyki', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (8, 'Wydział Inżynierii Zarządzania', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (9, 'Wydział Maszyn Roboczych i Transportu', 1);
INSERT INTO [ictDb_dev].[dbo].[Faculties]([Id],[Name],[University_Id]) VALUES (10, 'Wydział Technologii Chemicznej', 1);
SET IDENTITY_INSERT [ictDb_dev].[dbo].[Faculties] OFF 

-- MajorBases
SET IDENTITY_INSERT [ictDb_dev].[dbo].[MajorBases] ON
INSERT INTO [ictDb_dev].[dbo].[MajorBases]([Id],[Name],[Faculty_Id]) values (1, 'Automatyka i Robotyka', 5);
INSERT INTO [ictDb_dev].[dbo].[MajorBases]([Id],[Name],[Faculty_Id]) values (2, 'Elektrotechnika', 5);
INSERT INTO [ictDb_dev].[dbo].[MajorBases]([Id],[Name],[Faculty_Id]) values (3, 'Energetyka', 5);
INSERT INTO [ictDb_dev].[dbo].[MajorBases]([Id],[Name],[Faculty_Id]) values (4, 'Informatyka', 5);
INSERT INTO [ictDb_dev].[dbo].[MajorBases]([Id],[Name],[Faculty_Id]) values (5, 'Matematyka', 5);
INSERT INTO [ictDb_dev].[dbo].[MajorBases]([Id],[Name],[Faculty_Id]) values (6, 'Matematyka w technice', 5);

SET IDENTITY_INSERT [ictDb_dev].[dbo].[MajorBases] OFF

-- Majors
SET IDENTITY_INSERT [ictDb_dev].[dbo].[Majors] ON
INSERT INTO [ictDb_dev].[dbo].[Majors]([Id],[StartYear],[MajorBase_Id]) VALUES(1, '2012-10-01', 4);
INSERT INTO [ictDb_dev].[dbo].[Majors]([Id],[StartYear],[MajorBase_Id]) VALUES(2, '2013-10-01', 4);
INSERT INTO [ictDb_dev].[dbo].[Majors]([Id],[StartYear],[MajorBase_Id]) VALUES(3, '2014-10-01', 4);
INSERT INTO [ictDb_dev].[dbo].[Majors]([Id],[StartYear],[MajorBase_Id]) VALUES(4, '2015-10-01', 4);
INSERT INTO [ictDb_dev].[dbo].[Majors]([Id],[StartYear],[MajorBase_Id]) VALUES(5, '2016-10-01', 4);
INSERT INTO [ictDb_dev].[dbo].[Majors]([Id],[StartYear],[MajorBase_Id]) VALUES(6, '2017-10-01', 4);

SET IDENTITY_INSERT [ictDb_dev].[dbo].[Majors] OFF

-- Courses
SET IDENTITY_INSERT [ictDb_dev].[dbo].[Courses] ON 
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(1, 'Sztuczna Inteligencja');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(2, 'Wybrane Technologie Internetowe');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(3, 'Podstawy Teleinformatyki');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(4, 'Inżynieria Oprogramowania');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(5, 'Projekt Zespołowy');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(6, 'Telefonia IP');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(7, 'Eksploatacja Sieci Komputerowych');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(8, 'Systemy Mobilne');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(9, 'Administrowanie Wybranymi Systemami Informatycznymi');
INSERT INTO [ictDb_dev].[dbo].[Courses]([Id],[Name]) VALUES(10, 'Seminarium Dyplomowe');


SET IDENTITY_INSERT [ictDb_dev].[dbo].[Courses] OFF


-- Classes
SET IDENTITY_INSERT [ictDb_dev].[dbo].[Classes] ON
INSERT INTO [ictDb_dev].[dbo].[Classes]([Id],[StartDateTime],[Course_Id]) VALUES(1, '2017-06-02 15:45', 3);
INSERT INTO [ictDb_dev].[dbo].[Classes]([Id],[StartDateTime],[Course_Id]) VALUES(2, '2017-05-19 15:45', 3);
INSERT INTO [ictDb_dev].[dbo].[Classes]([Id],[StartDateTime],[Course_Id]) VALUES(3, '2017-05-04 15:45', 3);
INSERT INTO [ictDb_dev].[dbo].[Classes]([Id],[StartDateTime],[Course_Id]) VALUES(4, '2017-04-20 15:45', 3);
INSERT INTO [ictDb_dev].[dbo].[Classes]([Id],[StartDateTime],[Course_Id]) VALUES(5, '2017-04-06 15:45', 3);
INSERT INTO [ictDb_dev].[dbo].[Classes]([Id],[StartDateTime],[Course_Id]) VALUES(6, '2017-03-23 15:45', 3);

SET IDENTITY_INSERT [ictDb_dev].[dbo].[Classes] OFF