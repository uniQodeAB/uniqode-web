SET IDENTITY_INSERT [secondary].[NewsArticles] ON;

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 11)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (11, 'ANNA HÄLL RIVERA TO UNIQODE!', 'anna-hll-rivera-to-uniqode', 'uniQode are proud to present our first recruitment. Highly recommended consultant Anna Häll Rivera chose uniQode for her next career step. This makes us both proud and happy! Anna joins us from ÅF and her first assignment at uniQode are at Scania. Welcome Anna!', '2015-05-06', '2015-05-06', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 13)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (13, 'MATTIAS BRONNER TO UNIQODE!', 'mattias-bronner-to-uniqode', 'uniQode are proud to announce that Mathias Bronner, talented and appreciated FrontEnd specialist, joins uniQode. Mathias, with experience from both the public and private sector, joins us from OmegaPoint and his first assignment at uniQode are at Arbetsförmedlingen. Welcome Mathias!', '2015-05-06', '2015-05-06', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 15)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (15, 'FREDRIK HEDBLAD CHOSE UNIQODE', 'fredrik-hedblad-chose-uniqode', 'UNIQODE IS GROWING! We are delighted to present Fredrik Hedblad, a truly experienced and appreciated .Net specialist. Fredrik joins us from RealTest and his first assignment through uniQode will be at ComHem. Welcome Fredrik!', '2015-05-06', '2015-05-06', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 24)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (24, 'PER ERICSON JOINS UNIQODE', 'per-ericson-joins-uniqode', 'Per Ericson, super skilled and experienced .Net developer chose uniQode & Qgroup for his next career step. We are very happy and proud that Per chose uniQode to continue his career as true specialist! Per joins us from RealTest and his first assignment at uniQode are at Com Hem. Welcome Per!', '2015-05-07', '2015-05-07', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 28)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (28, 'MARTIN BOHGARD, FRONTEND SPECIALIST TO UNIQODE', 'martin-bohgard-frontend-specialist-to-uniqode', 'We are proud to announce that Martin Bohgard joins uniQode. Martin is a gifted and experienced designer that really loves his craftsmanship. Martin joins us from Chas and his first assignment at uniQode is at Propellerhead. Big welcome Martin!', '2015-08-12', '2015-08-12', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 31)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (31, 'SUPER TALANTED CARL RIPA TO UNIQODE', 'super-talented-carl-ripa-to-uniqode', 'We are very delighted and proud that the super talented Carl Ripa joins uniQode! Carl joins us from Dynabyte and his first assignment at uniQode are at Tele2. Welcome Carl!!', '2015-08-24', '2015-08-24', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 36)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (36, 'WELCOME TO UNIQODE MAGNUS RYDÉN!', 'welcome-to-uniqode-magnus-rydn', 'We are proud and happy to inform that Magnus Rydén chose uniQode for his next career step. Magnus is a truly skilled .Net developer with expertise knowledge whitin GIT and FrontEnd. Magnus is joining us from ÅF and his first assignment at uniQode is at AtlasCopco.', '2015-10-01', '2015-10-01', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 39)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (39, 'CODING ROCK STAR KEITH GIBBS JOINS UNIQODE', 'coding-rock-star-keith-gibbs-joins-uniqode', 'We are happy to announce that the american ECMAScript warrior and coding rock star Keith Gibbs joins uniQode. Keith are joining us from HiQ and are performing his arts at ViaPlay as first assignment at uniQode.', '2015-10-22', '2015-10-22', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 42)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (42, 'JOHAN ALLANSSON CONNECTS WITH UNIQODE', 'johan-allansson-connects-with-uniqode', 'Johan is a extraordinary developer with a keen sense for systems design and an enthusiasm for large-scale, highly available distributed systems. Johan joins us from Dynabyte and his first assignment at uniQode will be at Svensk Adressändring. Welcome Johan!', '2015-11-23', '2015-11-23', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 48)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (48, 'PER THOMASSON, SENIOR WEB DESIGNER JOINS UNIQODE', 'per-thomasson-senior-web-designer-joins-uniqode', 'It is with pride and happines we welcome Per Thomasson to uniQode! Per is a Senior Webdesigner and Developer who create magic at Förenade Liv at the beginning of his journey with uniQode. Big Welcome Per!', '2016-01-15', '2016-01-15', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 51)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (51, 'CHRISTER ZIELINSKI TO UNIQODE', 'christer-zielinski-to-uniqode', 'We are pleased and happy to announce that Christer Zielinski now is a part of uniQode and that Christer has chosen uniQode as his next step in his career. Christers main focus is web development and .Net platform. Christer starts his first assignment at uniQode with PayEx. Welcome to uniQode Christer!', '2016-03-01', '2016-03-01', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 85)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (85, 'AWAT SULEIMANPOOR JOINS UNIQODE', 'awat-suleimanpoor-joins-uniqode', 'We are proud to announce that the skilled developer Awat Suleimanpoor joins uniQode. Awat, who joins us from Cygate, will do his first assignment at H&M. Big welcome to uniQode Awat!', '2016-03-04', '2016-03-04', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 88)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (88, 'A NEW STAR TO UNIQODE, WELCOME GUSTAV LINDERUP', 'a-new-star-to-uniqode-welcome-gustav-linderup', 'Highly recommended Gustav Linderup joins uniQode. It is with proudness we announce that Gustav Linderup has chosen uniQode as next step in his career. Gustav joins us from Nexus where he was responsible for development and maintaining neXus digital security services. With Gustav onboard uniQode continues to grow within project management and security. Gustav will do his first assignment at Tele2 as Project Manager. Big welcome Gustav!', '2016-03-16', '2016-03-16', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 93)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (93, 'SENIOR .NET CONSULTANT ANDREAS HALL JOINS UNIQODE!', 'senior-net-consultant-andreas-hall-joins-uniqode', 'It is with pride and happines we welcome Andreas Hall to uniQode! With Andreas onboard uniQode gets even stronger within Episerver and .Net as this is Andreas experts areas. Andreas begins his journey with uniQode at Svenska Kraftnät. Big big welcome to uniQode Andreas!', '2016-04-12', '2016-04-12', 'NEW HIRE')
END

IF NOT EXISTS (SELECT Id FROM [secondary].[NewsArticles] WHERE Id = 96)
BEGIN
	INSERT INTO [secondary].[NewsArticles](Id, Title, SearchableTitle, Body, Created, Modified, Category)
	VALUES (96, 'WELCOME TO UNIQODE EMMA CARLSTRÖM!', 'welcome-to-uniqode-emma-carlstrm', 'uniQode are proud to present that highly recommended consultant Emma Carlström chose uniQode for her next career step. This makes us proud and happy! Emmas first assignment at uniQode are at NCG. Welcome Emma!', '2016-08-30', '2016-08-30', 'NEW HIRE')
END

SET IDENTITY_INSERT [secondary].[NewsArticles] OFF;