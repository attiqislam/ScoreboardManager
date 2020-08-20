CREATE TABLE Players
(
	PlayerID int Primary Key IDENTITY(1,1) NOT NULL,
	FirstName varchar(80) NOT NULL,
	LastName varchar(80) NOT NULL,
	Email varchar(80) NOT NULL
)

CREATE TABLE Matchs
(
	MatchID int Primary Key IDENTITY(1,1) NOT NULL,
	MatchName varchar(100) NOT NULL,
	MatchVenue varchar(100) NOT NULL,
	MatchDateTime smalldatetime NOT NULL
)

CREATE TABLE Points
(
	PlayerID int NOT NULL CONSTRAINT Pk_Players_PlayerID_Fk_Points_PlayerID FOREIGN KEY(PlayerID) REFERENCES Players(PlayerID),
	MatchID int NOT NULL CONSTRAINT Pk_Matchs_MatchID_Fk_Points_MatchID FOREIGN KEY(MatchID) REFERENCES Matchs(MatchID),
	Point int NOT NULL
)