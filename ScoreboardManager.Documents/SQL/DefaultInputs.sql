
-------------------------- START: Players -------------------------------------------

IF NOT EXISTS(SELECT * FROM Players WHERE Email = 'edson.Pele@test.com')
	BEGIN
		INSERT INTO Players(FirstName,LastName,Email)
			VALUES('Edson','Pele','edson.Pele@test.com');
	END

IF NOT EXISTS(SELECT * FROM Players WHERE Email = 'lionel.messi@test.com')
	BEGIN
		INSERT INTO Players(FirstName,LastName,Email)
			VALUES('Lionel','Messi','lionel.messi@test.com');
	END

IF NOT EXISTS(SELECT * FROM Players WHERE Email = 'david.beckham@test.com')
	BEGIN
		INSERT INTO Players(FirstName,LastName,Email)
			VALUES('David','Beckham','david.beckham@test.com');
	END

IF NOT EXISTS(SELECT * FROM Players WHERE Email = 'cristiano.ronaldo@test.com')
	BEGIN
		INSERT INTO Players(FirstName,LastName,Email)
			VALUES('Cristiano','Ronaldo','cristiano.ronaldo@test.com');
	END

IF NOT EXISTS(SELECT * FROM Players WHERE Email = 'diego.maradona@test.com')
	BEGIN
		INSERT INTO Players(FirstName,LastName,Email)
			VALUES('Diego','Maradona','diego.maradona@test.com');
	END

-------------------------- END: Players -------------------------------------------

-------------------------- START: Matchs -------------------------------------------

IF NOT EXISTS(SELECT * FROM Matchs WHERE MatchName = 'Test Match 1')
	BEGIN
		INSERT INTO Matchs(MatchName,MatchVenue,MatchDateTime)
			VALUES('Test Match 1','Allianz Arena','05-28-2017');
	END

IF NOT EXISTS(SELECT * FROM Matchs WHERE MatchName = 'Test Match 2')
	BEGIN
		INSERT INTO Matchs(MatchName,MatchVenue,MatchDateTime)
			VALUES('Test Match 2','Camp Nou','06-10-2017');
	END

IF NOT EXISTS(SELECT * FROM Matchs WHERE MatchName = 'Test Match 3')
	BEGIN
		INSERT INTO Matchs(MatchName,MatchVenue,MatchDateTime)
			VALUES('Test Match 3','Stadium TFC','06-15-2017');
	END

IF NOT EXISTS(SELECT * FROM Matchs WHERE MatchName = 'Test Match 4')
	BEGIN
		INSERT INTO Matchs(MatchName,MatchVenue,MatchDateTime)
			VALUES('Test Match 4','Camp Nou','06-16-2017');
	END

IF NOT EXISTS(SELECT * FROM Matchs WHERE MatchName = 'Test Match 5')
	BEGIN
		INSERT INTO Matchs(MatchName,MatchVenue,MatchDateTime)
			VALUES('Test Match 5','Stadium TFC','06-18-2017');
	END
-------------------------- END: Matchs -------------------------------------------


-------------------------- Start: Points -------------------------------------------


		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(1,1,1);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(1,2,0);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(1,3,4);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(1,4,3);


		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(2,1,0);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(2,2,2);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(2,3,5);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(2,4,2);

		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(3,1,1);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(3,2,4);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(3,3,2);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(3,4,0);

		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(4,1,2);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(4,2,3);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(4,3,2);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(4,4,3);

		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(5,1,2);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(5,2,2);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(5,3,1);
		INSERT INTO Points(PlayerID,MatchID,Point) VALUES(5,4,1);


-------------------------- END: Points -------------------------------------------
