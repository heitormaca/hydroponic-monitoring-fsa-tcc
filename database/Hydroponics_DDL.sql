CREATE DATABASE Hydroponics;
USE Hydroponics;
CREATE TABLE Usuario(
	id_usuario INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(70) NOT NULL,
	email VARCHAR(70) NOT NULL,
	senha VARCHAR(255) NOT NULL,
	imagem TEXT
);
CREATE TABLE Estufa(
	id_estufa INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50) NOT NULL
);
CREATE TABLE Bancada(
	id_bancada INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50) NOT NULL,
	semeio VARCHAR(50) NOT NULL,
	dataInicio DATETIME NOT NULL,
	dataFim DATETIME NOT NULL,
	statusBancada BIT DEFAULT(1),
	sensorTempBancMax FLOAT NOT NULL,
	sensorTempBancMin FLOAT NOT NULL,
	sensorTempSolMax FLOAT NOT NULL,
	sensorTempSolMin FLOAT NOT NULL,
	sensorPhMax FLOAT NOT NULL,
	sensorPhMin FLOAT NOT NULL,
	sensorEcMax FLOAT NOT NULL,
	sensorEcMin FLOAT NOT NULL,
	id_estufa INT FOREIGN KEY REFERENCES Estufa(id_estufa)
);
CREATE TABLE BancadaSensores(
	id_bancadaSensores INT IDENTITY PRIMARY KEY NOT NULL,
	sensorTempBanc FLOAT NOT NULL,
	sensorTempSol FLOAT NOT NULL,
	sensorPh FLOAT NOT NULL,
	sensorEc FLOAT NOT NULL,
	id_bancada INT FOREIGN KEY REFERENCES Bancada(id_bancada)
);
	
	
	





