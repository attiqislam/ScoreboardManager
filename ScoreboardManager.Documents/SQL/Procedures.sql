-------------------------- START: Players -------------------------------------------

IF (select count(*) from sys.all_objects where name = 'PlayersInsert') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE PlayersInsert AS RETURN 0;'); 
	END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to insert record of a player in database.
-- =============================================
ALTER PROCEDURE PlayersInsert
	@FirstName varchar(80),
	@LastName varchar(80),
	@Email varchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Players
	(
		FirstName,
		LastName,
		Email
	)
	VALUES
	(
		@FirstName,
		@LastName,
		@Email
	)

    SELECT CAST(SCOPE_IDENTITY() AS int);
END
GO

IF (select count(*) from sys.all_objects where name = 'PlayersUpdate') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE PlayersUpdate AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to update record of a player in database.
-- =============================================
ALTER PROCEDURE PlayersUpdate
	@PlayerID int,
	@FirstName varchar(80),
	@LastName varchar(80),
	@Email varchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Players
	SET FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email
	
	WHERE PlayerID = @PlayerID
    
END
GO

IF (select count(*) from sys.all_objects where name = 'PlayersGet') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE PlayersGet AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 24.08.2020
-- Description	: SP to get record of a player.
-- =============================================
ALTER PROCEDURE PlayersGet
	@PlayerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Players
	WHERE PlayerID = @PlayerID
    
END
GO

IF (select count(*) from sys.all_objects where name = 'PlayersGetAll') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE PlayersGetAll AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to get record of all players.
-- =============================================
ALTER PROCEDURE PlayersGetAll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Players
    
END
GO

IF (select count(*) from sys.all_objects where name = 'IsPlayerExist') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE IsPlayerExist AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to check whether a player is already exist or not.
-- =============================================
ALTER PROCEDURE IsPlayerExist
	@Email varchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Players
    WHERE Email = @Email
END
GO

-------------------------- END: Players -------------------------------------------

-------------------------- Start: Matchs -------------------------------------------

IF (select count(*) from sys.all_objects where name = 'MatchsInsert') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE MatchsInsert AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to inset record of a match into database.
-- =============================================
ALTER PROCEDURE MatchsInsert
	@MatchName varchar(100),
	@MatchVenue varchar(100),
	@MatchDateTime smalldatetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Matchs
	(
		MatchName,
		MatchVenue,
		MatchDateTime
	)
	VALUES
	(
		@MatchName,
		@MatchVenue,
		@MatchDateTime
	)

    SELECT CAST(SCOPE_IDENTITY() AS int);
END
GO

IF (select count(*) from sys.all_objects where name = 'MatchsUpdate') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE MatchsUpdate AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to update record of a match in database.
-- =============================================
ALTER PROCEDURE MatchsUpdate
	@MatchID int,
	@MatchName varchar(100),
	@MatchVenue varchar(100),
	@MatchDateTime smalldatetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 UPDATE Matchs
	SET		MatchName = @MatchName,
			MatchVenue = @MatchVenue,
			MatchDateTime = @MatchDateTime
	WHERE MatchID = @MatchID
END
GO

IF (select count(*) from sys.all_objects where name = 'MatchsGetAll') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE MatchsGetAll AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to get record of all match.
-- =============================================
ALTER PROCEDURE MatchsGetAll
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Matchs
END
GO

IF (select count(*) from sys.all_objects where name = 'IsMatchExist') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE IsMatchExist AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to check whether a match is existing in database or not.
-- =============================================
ALTER PROCEDURE IsMatchExist
	@MatchName varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Matchs
	WHERE MatchName = @MatchName

END
GO
-------------------------- END: Matchs -------------------------------------------

-------------------------- Start: Points -------------------------------------------

IF (select count(*) from sys.all_objects where name = 'PointsInsert') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE PointsInsert AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to insert a Point in database.
-- =============================================
ALTER PROCEDURE PointsInsert
	@PlayerID int,
	@MatchID int,
	@Point int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Points
	(
		PlayerID,
		MatchID,
		Point
	)
	VALUES
	(
		@PlayerID,
		@MatchID,
		@Point
	)

    SELECT CAST(SCOPE_IDENTITY() AS int);
END
GO

IF (select count(*) from sys.all_objects where name = 'PointsUpdate') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE PointsUpdate AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to update a Point in database.
-- =============================================
ALTER PROCEDURE PointsUpdate
	@PlayerID int,
	@MatchID int,
	@Point int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Points
	SET	Point = @Point

	WHERE PlayerID = @PlayerID
	AND	  MatchID = @MatchID
	    
END
GO

IF (select count(*) from sys.all_objects where name = 'PointsGetAll') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE PointsGetAll AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to get all Points from database.
-- =============================================
ALTER PROCEDURE PointsGetAll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT p.PlayerID, p.FirstName, p.LastName, SUM(s.Point) as TotalPoints
	FROM Points s
	JOIN Players p ON p.PlayerID = s.PlayerID
	GROUP BY  p.PlayerID, p.FirstName, p.LastName
	ORDER BY TotalPoints DESC
    
END
GO

IF (select count(*) from sys.all_objects where name = 'IsPointExist') = 0
	BEGIN
		EXEC ('CREATE PROCEDURE IsPointExist AS RETURN 0;'); 
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Attiq-ul Islam
-- Create date	: 18.08.2020
-- Description	: SP to check whether Point of a player is exist in the table.
-- =============================================
ALTER PROCEDURE IsPointExist
	@PlayerID int,
	@MatchID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Points
	WHERE PlayerID = @PlayerID
	AND	  MatchID = @MatchID
    
END
GO
-------------------------- END: Points -------------------------------------------


