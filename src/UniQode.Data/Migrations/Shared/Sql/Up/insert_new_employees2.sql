declare @firstName varchar(50), 
		@lastName varchar(50),
		@title varchar(50),
		@email varchar(50),
		@urlPart varchar(200),
		@text varchar(1000),
		@id uniqueidentifier,
		@spotlightId UNIQUEIDENTIFIER, 
		@spotlightQuestionId UNIQUEIDENTIFIER

select	@urlPart = 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/'


-- ################################################################################################

select	@firstName = 'Viktoria',
		@lastName = 'Provatkina',
		@title = 'Elite Tester',
		@email = lower(@firstName) + '.' + lower(@lastName) + '@uniqode.se'
		
select	@id = case when exists(select Id from [secondary].Employees where FirstName = @firstName and LastName = @lastName) then (select Id from [secondary].Employees where FirstName = @firstName and LastName = @lastName) else newid() end

if not exists (select Id from [secondary].Employees where Id = @id)
begin
	insert into [secondary].Employees(Id, FirstName, LastName, Title, Email, ShortDescription, [Description])
	values (@id, @firstName, @lastName, @title, @email, '...', '... ...')
end
	
if not exists (select Id from [secondary].ProfilePictures where Id = @id)
begin
	insert into [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
	values (@id, @urlPart + lower(@firstName) + '.png', @urlPart + 'sq-' + lower(@firstName) + '.png')
end

if not exists (select Id from [primary].Employees where Id = @id)
begin
	insert into [primary].Employees(Id, FirstName, LastName, Title, Email, ShortDescription, [Description])
	values (@id, @firstName, @lastName, @title, @email, '...', '... ...')
end

if not exists (select Id from [primary].ProfilePictures where Id = @id)
begin
	insert into [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
	values (@id, @urlPart + lower(@firstName) + '.png', @urlPart + 'sq-' + lower(@firstName) + '.png')
end


SELECT 
	@spotlightId = NEWID(), 
	@spotlightQuestionId = Id, 
	@text = 'My motivation is - be more patient, be more curious and be smarter today than you were yesterday.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'What motivates you?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@spotlightId, @id, @spotlightQuestionId, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@spotlightId, @id, @spotlightQuestionId, @text)

SELECT 
	@spotlightId = NEWID(), 
	@spotlightQuestionId = Id, 
	@text = 'By prioritize and by choosing reliable sources among lot of information.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'How do you deliver value?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@spotlightId, @id, @spotlightQuestionId, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@spotlightId, @id, @spotlightQuestionId, @text)

SELECT 
	@spotlightId = NEWID(), 
	@spotlightQuestionId = Id, 
	@text = 'Best thing is the spirit in the team and development of me as a tester. I´m free to educate myself at the same time as I can use my knowledge on an assignment.'
FROM [primary].SpotlightQuestions 
WHERE [Text] = 'The best with uniQode?'

INSERT INTO [primary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@spotlightId, @id, @spotlightQuestionId, @text)
INSERT INTO [secondary].Spotlights(Id, Employee_Id, SpotlightQuestion_Id, Answer)
VALUES (@spotlightId, @id, @spotlightQuestionId, @text)


-- ################################################################################################

select	@firstName = 'Niklas',
		@lastName = 'Maront',
		@title = 'Business Analyst',
		@email = lower(@firstName) + '.' + lower(@lastName) + '@uniqode.se'
		
select	@id = case when exists(select Id from [secondary].Employees where FirstName = @firstName and LastName = @lastName) then (select Id from [secondary].Employees where FirstName = @firstName and LastName = @lastName) else newid() end

if not exists (select Id from [secondary].Employees where Id = @id)
begin
	insert into [secondary].Employees(Id, FirstName, LastName, Title, Email, ShortDescription, [Description])
	values (@id, @firstName, @lastName, @title, @email, '...', '... ...')
end
	
if not exists (select Id from [secondary].ProfilePictures where Id = @id)
begin
	insert into [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
	values (@id, @urlPart + lower(@firstName) + '.png', @urlPart + 'sq-' + lower(@firstName) + '.png')
end

if not exists (select Id from [primary].Employees where Id = @id)
begin
	insert into [primary].Employees(Id, FirstName, LastName, Title, Email, ShortDescription, [Description])
	values (@id, @firstName, @lastName, @title, @email, '...', '... ...')
end

if not exists (select Id from [primary].ProfilePictures where Id = @id)
begin
	insert into [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
	values (@id, @urlPart + lower(@firstName) + '.png', @urlPart + 'sq-' + lower(@firstName) + '.png')
end


-- ################################################################################################
