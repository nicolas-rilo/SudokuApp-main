
USE [sudokuapp]


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Sudoku_Cells_Puzzle]') AND type in ('U'))
DROP TABLE [Sudoku_Cells_Puzzle]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Sudoku_Cells_Solution]') AND type in ('U'))
DROP TABLE [Sudoku_Cells_Solution]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Killer_Cell]') AND type in ('U'))
DROP TABLE [Killer_Cell]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Arrow_Cell]') AND type in ('U'))
DROP TABLE [Arrow_Cell]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Thermo_Cell]') AND type in ('U'))
DROP TABLE [Thermo_Cell]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Participant]') AND type in ('U'))
DROP TABLE [Participant]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Review]') AND type in ('U'))
DROP TABLE [Review]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Arrow]') AND type in ('U'))
DROP TABLE [Arrow]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Thermo]') AND type in ('U'))
DROP TABLE [Thermo]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Killer_box]') AND type in ('U'))
DROP TABLE [Killer_box]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Tournament]') AND type in ('U'))
DROP TABLE [Tournament]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Sudoku]') AND type in ('U'))
DROP TABLE [Sudoku]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Users]') AND type in ('U'))
DROP TABLE [Users]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Cell]') AND type in ('U'))
DROP TABLE [Cell]
GO







CREATE TABLE Users (
	usrId bigint IDENTITY(1,1) NOT NULL,
	userName varchar(30) NOT NULL,
	password varchar(50) NOT NULL,
	firstName varchar(30) NOT NULL,
	lastName varchar(40) NOT NULL,
	email varchar(60) NOT NULL,
	admin bit,
	idiom VARCHAR(64) NULL,
	country VARCHAR(64) NULL,

	CONSTRAINT [PK_Users] PRIMARY KEY (usrId),
	CONSTRAINT [UniqueKey_Login] UNIQUE (userName)
)

CREATE TABLE Sudoku (
	sudokuId bigint IDENTITY(1,1) NOT NULL,
	usrId bigint NOT NULL,
	name varchar(300) NOT NULL,
	rules varchar(600),
	dificulty varchar(6),
	normal bit,
	killer bit,
	thermal bit,
	arrow bit,
	custom bit,

	CONSTRAINT [PK_Sudoku] PRIMARY KEY (sudokuId),
	CONSTRAINT fk_usrId FOREIGN KEY (usrId) REFERENCES Users(usrId)
)


CREATE TABLE Cell(
	cellId bigint IDENTITY(1,1) NOT NULL,
	row_index INT,
	image INT,
    col_index INT,
	cell_value INT,

	CONSTRAINT PK_Cell PRIMARY KEY (cellId),
	CONSTRAINT row_index CHECK (row_index BETWEEN 1 AND 9),
	CONSTRAINT col_index CHECK (col_index BETWEEN 1 AND 9),
	CONSTRAINT cell_value CHECK (cell_value BETWEEN 0 AND 9),
)

CREATE TABLE Sudoku_Cells_Puzzle(
	sudokuId bigint NOT NULL,
	cellId bigint NOT NULL,

	CONSTRAINT PK_Sudoku_Cells_Puzzle PRIMARY KEY (sudokuId, cellId),
    CONSTRAINT fk_Sudoku_Cells_Puzzle_sudokuId FOREIGN KEY (sudokuId) REFERENCES Sudoku(sudokuId),
    CONSTRAINT fk_Sudoku_Cells_Puzzle_cellId FOREIGN KEY (cellId) REFERENCES Cell(cellId)
)

CREATE TABLE Sudoku_Cells_Solution(
	sudokuId bigint NOT NULL,
	cellId bigint NOT NULL,

	CONSTRAINT PK_Sudoku_Cells_Solution PRIMARY KEY (sudokuId, cellId),
    CONSTRAINT fk_Sudoku_Cells_Solution_sudokuId FOREIGN KEY (sudokuId) REFERENCES Sudoku(sudokuId),
    CONSTRAINT fk_Sudoku_Cells_Solution_cellId FOREIGN KEY (cellId) REFERENCES Cell(cellId)
)

CREATE TABLE Killer_box(
	killerId bigint IDENTITY(1,1) NOT NULL,
	sudokuId bigint NOT NULL,
	killer_value INT,

	CONSTRAINT PK_Killer PRIMARY KEY (killerId),
    CONSTRAINT fk_Killer_box_sudokuId FOREIGN KEY (sudokuId) REFERENCES Sudoku(sudokuId)
)

CREATE TABLE Killer_Cell(
	killerId bigint NOT NULL,
	cellId bigint NOT NULL,

	CONSTRAINT PK_Killer_Cell PRIMARY KEY (killerId, cellId),
    CONSTRAINT fk_Killer_Cell_killerId FOREIGN KEY (killerId) REFERENCES Killer_box(killerId),
    CONSTRAINT fk_Killer_Cell_cellId FOREIGN KEY (cellId) REFERENCES Cell(cellId)
)

CREATE TABLE Arrow(
	arrowId bigint IDENTITY(1,1) NOT NULL,
	sudokuId bigint NOT NULL,
	start_cell bigint NOT NULL,
	end_cell bigint NOT NULL,

	CONSTRAINT PK_Arrow PRIMARY KEY (arrowId),
    CONSTRAINT fk_Arrow_sudokuId FOREIGN KEY (sudokuId) REFERENCES Sudoku(sudokuId),
    CONSTRAINT fk_Arrow_start_cell FOREIGN KEY (start_cell) REFERENCES Cell(cellId),
    CONSTRAINT fk_Arrow_end_cell FOREIGN KEY (end_cell) REFERENCES Cell(cellId)
)

CREATE TABLE Arrow_Cell(
	arrowId bigint NOT NULL,
	cellId bigint NOT NULL,

	CONSTRAINT PK_Arrow_Cell PRIMARY KEY (arrowId, cellId),
    CONSTRAINT fk_Arrow_Cell_arrowId FOREIGN KEY (arrowId) REFERENCES Arrow(arrowId),
    CONSTRAINT fk_Arrow_Cell_cellId FOREIGN KEY (cellId) REFERENCES Cell(cellId)
)

CREATE TABLE Thermo(
	thermoId bigint IDENTITY(1,1) NOT NULL,
	sudokuId bigint NOT NULL,
	start_cell bigint NOT NULL,
	end_cell bigint NOT NULL,

	CONSTRAINT PK_Thermo PRIMARY KEY (thermoId),
    CONSTRAINT fk_Thermo_sudokuId FOREIGN KEY (sudokuId) REFERENCES Sudoku(sudokuId),
    CONSTRAINT fk_Thermo_start_cell FOREIGN KEY (start_cell) REFERENCES Cell(cellId),
    CONSTRAINT fk_Thermo_end_cell FOREIGN KEY (end_cell) REFERENCES Cell(cellId)
)

CREATE TABLE Thermo_Cell(
	thermoId bigint NOT NULL,
	cellId bigint NOT NULL,

	CONSTRAINT PK_Thermo_Cell PRIMARY KEY (thermoId, cellId),
    CONSTRAINT fk_Thermo_Cell_thermoId FOREIGN KEY (thermoId) REFERENCES Thermo(thermoId),
    CONSTRAINT fk_Thermo_Cell_cellId FOREIGN KEY (cellId) REFERENCES Cell(cellId)
)

CREATE TABLE Tournament(
	tournamentId bigint IDENTITY(1,1) NOT NULL,
	sudokuId bigint NOT NULL,
	start_time DATETIME,
	finish_time DATETIME,

	CONSTRAINT PK_Tournament PRIMARY KEY (tournamentId),
    CONSTRAINT fk_Tournament_sudokuId FOREIGN KEY (sudokuId) REFERENCES Sudoku(sudokuId)
)

CREATE TABLE Participant(
	userId bigint NOT NULL,
	tournamentId bigint NOT NULL,
	time TIME NOT NULL,

	CONSTRAINT PK_Participant PRIMARY KEY (userId,tournamentId),
    CONSTRAINT fk_Participant_userId FOREIGN KEY (userId) REFERENCES Users(usrId),
	CONSTRAINT fk_Participant_tournamentId FOREIGN KEY (tournamentId) REFERENCES Tournament(tournamentId)
)

CREATE TABLE Review(
	sudokuId bigint NOT NULL,
	usrId bigint NOT NULL,
	review_value INT,

	CONSTRAINT PK_Review PRIMARY KEY (sudokuId,usrId),
	CONSTRAINT fk_Review_sudokuId FOREIGN KEY (sudokuId) REFERENCES Sudoku(sudokuId),
	CONSTRAINT fk_Review_userId FOREIGN KEY (usrId) REFERENCES Users(usrId),
	CONSTRAINT review_value_index CHECK (review_value BETWEEN 1 AND 5),

)

INSERT INTO Users (userName ,password ,firstName, lastName,email ,admin,idiom ,country)
VALUES('HOLA','ypeBEsobvcr6wjGzmiPcTaeG7/gUfE5yuYB3ha/uSLs=','ADMIN','ADMIN','admin@admin.es',1,'en','US' )
GO
