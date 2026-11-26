CREATE TABLE Measurements (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Temperature FLOAT NOT NULL,
	Humidity FLOAT NOT NULL,
	MeasurementTime INT NOT NULL
);