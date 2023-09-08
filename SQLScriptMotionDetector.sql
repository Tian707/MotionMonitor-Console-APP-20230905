USE master; 

DROP DATABASE MotionDetector;
GO

CREATE DATABASE MotionDetector;
GO
USE MotionDetector;

CREATE TABLE Distances(
	ID INT IDENTITY (1,1) PRIMARY KEY,
	DistanceInCM FLOAT(50) NOT NULL,
	LightCount INT NOT NULL,;
	ReceivingTime DATETIME2 DEFAULT GETDATE() NOT NULL
);
--Precision: If you need high-precision time measurements (e.g., storing timestamps with fractions of a second) 
--or if you expect to perform calculations that require very precise time intervals,
-- DATETIME2 provides more flexibility in setting the desired level of precision.

--Storage Size: DATETIME2 might be more efficient for storage if you don't need the full precision of DATETIME. 
--Smaller storage requirements can be especially important in large databases with many rows.

-- Range: DATETIME2 has a broader supported range, which may be relevant if your application 
--deals with historical data or requires a date range that extends beyond the limits of DATETIME.


--populate db with data from Arduino

INSERT INTO Distances (DistanceInCM)
VALUES ( );
-------------------------------------------------------
--Stored procedures:
GO
CREATE PROCEDURE dbo.InsertIntoDistances
    @DistanceInCM float(50),
	@LightCount INT 
AS
BEGIN
    INSERT INTO Distances(
        DistanceInCM,
		LightCount
    )
    VALUES
    (
        @DistanceInCM,
		@LightCount
    )
END;
GO
        EXEC dbo.InsertIntoDistances @DistanceInCM = 3.5, @LightCount = 6;
		EXEC dbo.InsertIntoDistances @DistanceInCM = 25, @LightCount = 6;

-- DROP PROCEDURE dbo.InsertIntoDistances;

use this in c#:
https://dotnettutorials.net/lesson/ado-net-using-stored-procedure/?expand_article=1
