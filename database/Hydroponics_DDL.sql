USE Hydroponics
go
CREATE TABLE Produtor(
	idProdutor INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(70) NOT NULL,
	email VARCHAR(70) NOT NULL,
	senha VARCHAR(255) NOT NULL,
	imagem TEXT
);
CREATE TABLE Estufa(
	idEstufa INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50) NOT NULL,
	dataInicio DATETIME DEFAULT GETDATE(),
	localizacao VARCHAR(50),
	idProdutor INT FOREIGN KEY REFERENCES Produtor(idProdutor)
);
CREATE TABLE Dispositivo(
	idDispositivo INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50) NOT NULL,
	endMac VARCHAR(50) NOT NULL
);
CREATE TABLE Medicao(
	idMedicao INT IDENTITY PRIMARY KEY NOT NULL,
	dataMedicao DATETIME DEFAULT SYSDATETIME(),
	sensorTempBanc FLOAT NOT NULL,
	sensorTempSol FLOAT NOT NULL,
	sensorPh FLOAT NOT NULL,
	sensorEc FLOAT NOT NULL,
	idDispositivo INT FOREIGN KEY REFERENCES Dispositivo(idDispositivo)
);
CREATE TABLE Bancada(
	idBancada INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50) NOT NULL,
	dataInicio DATETIME DEFAULT GETDATE(),
	localizacao VARCHAR(50),
	idEstufa INT FOREIGN KEY REFERENCES Estufa(idEstufa),
	idDispositivo INT FOREIGN KEY REFERENCES Dispositivo(idDispositivo)
);
CREATE TABLE Plantacao(
	idPlantacao INT IDENTITY PRIMARY KEY NOT NULL,
	observacoes Text,
	semeio VARCHAR(50) NOT NULL,
	dataInicio DATETIME DEFAULT GETDATE(),
	dataFim DATETIME NOT NULL,
	TempBancMax FLOAT NOT NULL,
	TempBancMin FLOAT NOT NULL,
	TempSolMax FLOAT NOT NULL,
	TempSolMin FLOAT NOT NULL,
	PhMax FLOAT NOT NULL,
	PhMin FLOAT NOT NULL,
	EcMax FLOAT NOT NULL,
	EcMin FLOAT NOT NULL,
	idBancada INT FOREIGN KEY REFERENCES Bancada(idBancada)
);


Use Hydroponics;
select * from Bancada;
delete from Estufa;

Insert into Estufa (nome,localizacao,idProdutor)
values ('Estufa 02', 'SETOR B',7); 



Insert into Bancada (nome,localizacao,idEstufa,idDispositivo)
values ('Bancada 06', 'SETOR B3',7,6); 

Insert into Dispositivo (nome,endMac)
values ('Dispositivo06','012345678X');
