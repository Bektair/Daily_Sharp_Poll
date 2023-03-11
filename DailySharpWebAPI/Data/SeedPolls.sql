SELECT * FROM Contributors;
SELECT * FROM Polls;
Select * FROM Questions;
Select * FROM PollPosts;
Select * FROM Alternatives;
Select * FROM Reactions;
GO

INSERT INTO Contributors (DiscordId, NickName) 
VALUES('ICanDoBetter', 'Tamujin')
GO

-- Poll 1
declare @contId bigInt
set @contId = (SELECT TOP 1 id FROM Contributors ORDER BY Id DESC);

INSERT INTO Polls (Topic, OverallQuestion, ContributorId) 
VALUES ('ProtossUnit', '', @contId)
GO

declare @pollId bigInt
set @pollId = (SELECT TOP 1 id FROM Polls ORDER BY Id DESC);
INSERT INTO Questions (ImageName, QuestionTxt, PollId) 
VALUES ('stalkImg.png', 'What are Stalkers', @pollId)
GO

declare @pollId bigInt
set @pollId = (SELECT TOP 1 id FROM Polls ORDER BY Id DESC);
declare @questId bigInt
set @questId = (SELECT TOP 1 id FROM Questions ORDER BY Id DESC);
INSERT INTO PollPosts (PollId, DatePosted)
VALUES (@pollId, '20120618 10:36:09 AM')
GO

declare @questId bigInt
set @questId = (SELECT TOP 1 id FROM Questions ORDER BY Id DESC);
INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('Blue Long Legged', @questId)
INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('Hiding and following', @questId)
INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('Blinkers', @questId)
GO

declare @pollPostId bigInt
set @pollPostId = (SELECT TOP 1 id FROM PollPosts ORDER BY Id DESC);
INSERT INTO Reactions(Name, Amount, PollPostId) 
VALUES (':statslul:', 5, @pollPostId)
INSERT INTO Reactions(Name, Amount, PollPostId) 
VALUES (':feelsbadman:', 3, @pollPostId)
INSERT INTO Reactions(Name, Amount, PollPostId) 
VALUES (':ree:', 8, @pollPostId)
GO


-- Poll 2
declare @contId bigInt
set @contId = (SELECT TOP 1 id FROM Contributors ORDER BY Id DESC);
INSERT INTO Polls (Topic, OverallQuestion, ContributorId) 
VALUES ('ZergUnit', '', @contId)
GO
INSERT INTO Questions (ImageName, QuestionTxt) 
VALUES ('hydraImg.png', 'What first comes to mind when you hear the word Hydras')
GO

declare @pollId bigInt
set @pollId = (SELECT TOP 1 id FROM Polls ORDER BY Id DESC);
declare @questId bigInt
set @questId = (SELECT TOP 1 id FROM Questions ORDER BY Id DESC);

INSERT INTO PollsQuestions (PollId, QuestionId, DatePosted) 
VALUES (@pollId, @questId, '20120618 10:31:09 AM')
GO

declare @questId bigInt
set @questId = (SELECT TOP 1 id FROM Questions ORDER BY Id DESC);
declare @pollQuestId bigInt
set @pollQuestId = (SELECT TOP 1 id FROM PollsQuestions ORDER BY Id DESC);

INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('Semi-Pro player', @questId)
INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('A poster', @questId)
INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('The Korean Commercial for SC2', @questId)

INSERT INTO Reactions(Name, Amount, PollQuestionId) 
VALUES (':statslul:', 5, @pollQuestId)
INSERT INTO Reactions(Name, Amount, PollQuestionId) 
VALUES (':feelsbadman:', 3, @pollQuestId)
INSERT INTO Reactions(Name, Amount, PollQuestionId) 
VALUES (':ree:', 8, @pollQuestId)
GO


-- Poll 3
declare @contId bigInt
set @contId = (SELECT TOP 1 id FROM Contributors ORDER BY Id DESC);
INSERT INTO Polls (Topic, OverallQuestion, ContributorId) 
VALUES ('TerranUnit', '', @contId)
GO
INSERT INTO Questions (ImageName, QuestionTxt) 
VALUES ('marineImg.png', 'What are Marines')
GO

declare @pollId bigInt
set @pollId = (SELECT TOP 1 id FROM Polls ORDER BY Id DESC);
declare @questId bigInt
set @questId = (SELECT TOP 1 id FROM Questions ORDER BY Id DESC);

INSERT INTO PollsQuestions (PollId, QuestionId, DatePosted) 
VALUES (@pollId, @questId, '20120618 10:37:09 AM')
GO

declare @questId bigInt
set @questId = (SELECT TOP 1 id FROM Questions ORDER BY Id DESC);
declare @pollQuestId bigInt
set @pollQuestId = (SELECT TOP 1 id FROM PollsQuestions ORDER BY Id DESC);

INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('Semi-Pro player', @questId)
INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('A poster', @questId)
INSERT INTO Alternatives (AltTxt, QuestionId) 
VALUES ('The Korean Commercial for SC2', @questId)

INSERT INTO Reactions(Name, Amount, PollQuestionId) 
VALUES (':statslul:', 5, @pollQuestId)
INSERT INTO Reactions(Name, Amount, PollQuestionId) 
VALUES (':feelsbadman:', 3, @pollQuestId)
INSERT INTO Reactions(Name, Amount, PollQuestionId) 
VALUES (':ree:', 8, @pollQuestId)
GO

