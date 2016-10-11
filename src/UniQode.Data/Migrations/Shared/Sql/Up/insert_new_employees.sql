declare @firstName varchar(50), 
		@lastName varchar(50),
		@title varchar(50),
		@email varchar(50),
		@urlPart varchar(200),
		@id uniqueidentifier

select	@urlPart = 'https://uniqodewebstorage.blob.core.windows.net/profile-pictures/'


-- ################################################################################################

select	@firstName = 'Alan',
		@lastName = 'Larsson',
		@title = 'UX sensei',
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

select	@firstName = 'Emma',
		@lastName = 'Carlström',
		@title = 'Java Elite',
		@email = lower(@firstName) + '.carlstrom@uniqode.se'
		
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

select	@firstName = 'Fredrik',
		@lastName = 'Mäkilä',
		@title = 'Java Champion',
		@email = lower(@firstName) + '.makila@uniqode.se'
		
select	@id = case when exists(select Id from [secondary].Employees where FirstName = @firstName and LastName = @lastName) then (select Id from [secondary].Employees where FirstName = @firstName and LastName = @lastName) else newid() end

if not exists (select Id from [secondary].Employees where Id = @id)
begin
	insert into [secondary].Employees(Id, FirstName, LastName, Title, Email, ShortDescription, [Description])
	values (@id, @firstName, @lastName, @title, @email, '...', '... ...')
end
	
if not exists (select Id from [secondary].ProfilePictures where Id = @id)
begin
	insert into [secondary].ProfilePictures(Id, OriginalUrl, SquareUrl)
	values (@id, @urlPart + lower(@firstName) + '-m.png', @urlPart + 'sq-' + lower(@firstName) + '-m.png')
end

if not exists (select Id from [primary].Employees where Id = @id)
begin
	insert into [primary].Employees(Id, FirstName, LastName, Title, Email, ShortDescription, [Description])
	values (@id, @firstName, @lastName, @title, @email, '...', '... ...')
end

if not exists (select Id from [primary].ProfilePictures where Id = @id)
begin
	insert into [primary].ProfilePictures(Id, OriginalUrl, SquareUrl)
	values (@id, @urlPart + lower(@firstName) + '-m.png', @urlPart + 'sq-' + lower(@firstName) + '-m.png')
end