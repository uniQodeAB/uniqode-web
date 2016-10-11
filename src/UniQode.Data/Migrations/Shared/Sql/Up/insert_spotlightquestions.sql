/**************************************************************
*** Cleanup
**************************************************************/

DELETE FROM [primary].SpotlightQuestions
DELETE FROM [secondary].SpotlightQuestions

GO


/**************************************************************
**************************************************************/

DECLARE @id UNIQUEIDENTIFIER, @text VARCHAR(512)

SELECT @id = NEWID(), @text = 'What motivates you?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'Why uniQode?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'What makes you a star?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'The best with uniQode?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'When not owning the qode, what do you do?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'How do you deliver value?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'What is your ambition?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'Who are you?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'The most important at a workplace?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)

SELECT @id = NEWID(), @text = 'What is your vision?'
INSERT INTO [primary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)
INSERT INTO [secondary].SpotlightQuestions(Id, [Text])
VALUES (@id, @text)