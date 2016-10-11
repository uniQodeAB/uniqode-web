/**************************************************************
*** Cleanup
**************************************************************/

DELETE FROM [primary].Employees
DELETE FROM [secondary].Employees

DELETE FROM [primary].ProfilePictures
DELETE FROM [secondary].ProfilePictures

DELETE FROM [primary].ExternalReferences
DELETE FROM [secondary].ExternalReferences

DELETE FROM [primary].Spotlights
DELETE FROM [secondary].Spotlights

GO

/**************************************************************
**************************************************************/

DECLARE @employeeId UNIQUEIDENTIFIER, 
		@tmpId UNIQUEIDENTIFIER, 
		@tmpId2 UNIQUEIDENTIFIER,
		@text NVARCHAR(MAX)

/*
        Facebook		1
        LinkedIn		2
        Twitter			3
        Github			4
        Stackoverflow	5
*/


/**************************************************************
*** Carl
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Carl', 'Ripa', 'carl.ripa@uniqode.se', '.Net Sensei', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Carl', 'Ripa', 'carl.ripa@uniqode.se', '.Net Sensei', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/carl.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-carl.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/carl.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-carl.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/cjripa')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/cjripa')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 3, 'https://twitter.com/carljripa')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 3, 'https://twitter.com/carljripa')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 4, 'https://github.com/cbird')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 4, 'https://github.com/cbird')

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'The pursuit of knowledge. I try to always be updated with information about the newest patterns and techniques, continuously perfecting my skills and ability to deliver good and modern solutions.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'What motivates you?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'To be part of a small, but fantasic group of skilled people. Then in the meantime also be a part of the bigger QGroup with all it�s inspiring people.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'The best with uniQode?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'To communicate with your collegues as soon as a problem arise. The sooner it can be fixed, the better it is for everybody. There should be no shame in this type of communication and everyone should be transparent about it.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'The most important at a workplace?'
 
INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)



/**************************************************************
*** Gustav
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Gustav', 'Linderup', 'gustav.linderup@uniqode.se', 'Project Manager', 'At UniQode I get to focus on continuously creating value for my customers and helping them achieve their goals. At the same time I get to work with truly dedicated and passionate people that are among the best in the industry.', 'I work at UniQode because I believe that a close knitted team of highly professional people can achieve things that otherwise isn''t possible. Here we are all an integrated and core part of the company and can directly influence the direction we are taking. At UniQode I get to focus on continuously creating value for my customers and helping them achieve their goals. At the same time I get to work with truly dedicated and passionate people that are among the best in the industry.')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Gustav', 'Linderup', 'gustav.linderup@uniqode.se', 'Project Manager', 'At UniQode I get to focus on continuously creating value for my customers and helping them achieve their goals. At the same time I get to work with truly dedicated and passionate people that are among the best in the industry.', 'I work at UniQode because I believe that a close knitted team of highly professional people can achieve things that otherwise isn''t possible. Here we are all an integrated and core part of the company and can directly influence the direction we are taking. At UniQode I get to focus on continuously creating value for my customers and helping them achieve their goals. At the same time I get to work with truly dedicated and passionate people that are among the best in the industry.')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/gustav.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-gustav.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/gustav.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-gustav.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/gustav-linderup-17a3792b')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/gustav-linderup-17a3792b')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 3, 'https://twitter.com/lindekarl')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 3, 'https://twitter.com/lindekarl')



/**************************************************************
*** Johan
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Johan', 'Suleiko Allansson', 'johan.allansson@uniqode.se', '.Net Guru', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Johan', 'Suleiko Allansson', 'cjohan.allansson@uniqode.se', '.Net Guru', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/johan.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-johan.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/johan.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-johan.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/johan-suleiko-allansson-4042a021')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/johan-suleiko-allansson-4042a021')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 3, 'https://twitter.com/johanallansson')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 3, 'https://twitter.com/johanallansson')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 4, 'https://github.com/allansson')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 4, 'https://github.com/allansson')



/**************************************************************
*** Magnus
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Magnus', 'Rydén', 'magnus.ryden@uniqode.se', '.Net virtuoso', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Magnus', 'Rydén', 'magnus.ryden@uniqode.se', '.Net virtuoso', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/magnus.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-magnus.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/magnus.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-magnus.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://www.linkedin.com/in/magnus-ryd%C3%A9n-3aab8249/en')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://www.linkedin.com/in/magnus-ryd%C3%A9n-3aab8249/en')


SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'Challenges which makes me have to redefine previous approaches. Problemsolving on this level makes me feel alive, I�m that type of person.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'What motivates you?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'To be a part of a group of interesting people who inspire eachother on both the professional and social level.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'The best with uniQode?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'I mix it up a bit with violin and cello. This is another passion that has stayed with me through he years.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'When not owning the qode, what do you do?'
 
INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)



/**************************************************************
*** Per T
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Per', 'Thomasson', 'per.thomasson@uniqode.se', 'UX Jedi', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Per', 'Thomasson', 'per.thomasson@uniqode.se', 'UX Jedi', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/per-t.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-per-t.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/per-t.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-per-t.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/per-thomasson-46a44726')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/per-thomasson-46a44726')

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'I love problem solving, both code related and such you are faced with when creating a user interface. Even design offer resistance that has to be dealt with.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'What motivates you?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'As an consultant I am used to have my whishes put in second place but at UniQode I''m the one in focus, I''m the star!'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'Why uniQode?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)

SELECT 
	@tmpId = NEWID(), 
	@tmpId2 = Id, 
	@text = 'My diversity and my ability to interact, both in terms of expertise and socially.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'What makes you a star?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@tmpId, @employeeId, @tmpId2, @text)



/**************************************************************
*** Andreas H
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Andreas', 'Hall', 'andreas.hall@uniqode.se', '.Net Developer', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Andreas', 'Hall', 'andreas.hall@uniqode.se', '.Net Developer', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/andreas-h.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-andreas-h.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/andreas-h.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-andreas-h.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/andreashall')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/andreashall')



/**************************************************************
*** Andreas P
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Andreas', 'Petersen', 'andreas.petersen@uniqode.se', 'VD', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Andreas', 'Petersen', 'andreas.petersen@uniqode.se', 'VD', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/andreas-p.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-andreas-p.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/andreas-p.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-andreas-p.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/andreas-petersen-46408922')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/andreas-petersen-46408922')



/**************************************************************
*** Anna
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Anna', 'Häll Rivera', 'anna.hall.rivera@uniqode.se', '.Net Diva', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Anna', 'Häll Rivera', 'anna.hall.rivera@uniqode.se', '.Net Diva', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/anna.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-anna.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/anna.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-anna.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/anna-h�ll-rivera-029a1327')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/anna-h�ll-rivera-029a1327')



/**************************************************************
*** Awat
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Awat', 'Suleimanpoor', 'awat.suleimanpoor@uniqode.se', '.Net Master', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Awat', 'Suleimanpoor', 'awat.suleimanpoor@uniqode.se', '.Net Master', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/awat.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-awat.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/awat.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-awat.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/awat-suleimanpoor-054130111')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/awat-suleimanpoor-054130111')



/**************************************************************
*** Christer
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Christer', 'Zielinski', 'christer.zielinski@uniqode.se', '.Net Virtuoso', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Christer', 'Zielinski', 'christer.zielinski@uniqode.se', '.Net Virtuoso', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/christer.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-christer.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/christer.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-christer.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/christerzielinski')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/christerzielinski')



/**************************************************************
*** Fredrik
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Fredrik', 'Hedblad', 'fredrik.hedblad@uniqode.se', '.Net Master', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Fredrik', 'Hedblad', 'fredrik.hedblad@uniqode.se', '.Net Master', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/fredrik.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-fredrik.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/fredrik.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-fredrik.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/fredrik-hedblad-b4647652/en')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/fredrik-hedblad-b4647652/en')



/**************************************************************
*** Keith
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Keith', 'Gibbs', 'keith.gibbs@uniqode.se', 'ECMASCRIPT WARRIOR', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Keith', 'Gibbs', 'keith.gibbs@uniqode.se', 'ECMASCRIPT WARRIOR', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/keith.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-keith.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/keith.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-keith.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/keithjgibbs')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/keithjgibbs')



/**************************************************************
*** Per E
**************************************************************/

SELECT @employeeId = NEWID()
INSERT INTO [primary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Per', 'Ericson', 'per.ericson@uniqode.se', '.Net Jedi', '...', '... ...')
INSERT INTO [secondary].Employees(Id, FirstName, LastName, Email, Title, ShortDescription, [Description])
VALUES (@employeeId, 'Per', 'Ericson', 'per.ericson@uniqode.se', '.Net Jedi', '...', '... ...')

INSERT INTO [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/per-e.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-per-e.png')
INSERT INTO [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
VALUES (@employeeId, 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/per-e.png', 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/sq-per-e.png')

SELECT @tmpId = NEWID()
INSERT INTO [primary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/per-ericson-24b38999')
INSERT INTO [secondary].ExternalReferences(Id, Employee_Id, [Type], [Url])
VALUES (@tmpId, @employeeId, 2, 'https://se.linkedin.com/in/per-ericson-24b38999')



/**************************************************************
*** Sanity check
**************************************************************/

--SELECT * FROM [primary].Employees
--SELECT * FROM [secondary].Employees

--SELECT * FROM [primary].ProfilePictures
--SELECT * FROM [secondary].ProfilePictures

--SELECT * FROM [primary].ExternalReferences
--SELECT * FROM [secondary].ExternalReferences

--SELECT * FROM [primary].Spotlights
--SELECT * FROM [secondary].Spotlights