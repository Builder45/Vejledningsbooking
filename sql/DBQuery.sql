CREATE TABLE Underviser
(
    UnderviserId int NOT NULL,
    Navn VARCHAR(50) Not NULL,

    PRIMARY KEY (UnderviserId)
);

CREATE TABLE Hold
(
    HoldId int NOT NULL,

    PRIMARY KEY (HoldId)
);

CREATE TABLE Kalender
(
    UnderviserId int REFERENCES Underviser(UnderviserId) NOT NULL,
    HoldId int REFERENCES Hold(HoldId) NOT NULL,
 
    PRIMARY KEY (UnderviserId, HoldId)
);

CREATE TABLE Studerende
(
    StuderendeId int NOT NULL,
    Navn VARCHAR(50) NOT NULL,
    HoldId int NOT NULL,

    PRIMARY KEY (StuderendeId),

    FOREIGN KEY (HoldId) REFERENCES Hold(HoldId)
);

CREATE TABLE BookingVindue
(
    BookingVindueId int NOT NULL,
    StartTidspunkt DATETIME NOT NULL,
    SlutTidspunkt DATETIME NOT NULL,
    UnderviserId int NOT NULL,
    HoldId int NOT NULL,

    PRIMARY KEY (BookingVindueId),

    FOREIGN KEY (UnderviserId, HoldId) REFERENCES Kalender(UnderviserId, HoldId)
);

CREATE TABLE Booking
(
    BookingId int NOT NULL,
    StartTidspunkt DATETIME NOT NULL,
    SlutTidspunkt DATETIME NOT NULL,
    BookingVindueId int NOT NULL,
    StuderendeId int NOT NULL,

    PRIMARY KEY (BookingId),
 
    FOREIGN KEY (StuderendeId) REFERENCES Studerende(StuderendeId),
    FOREIGN KEY (BookingVindueId) REFERENCES BookingVindue(BookingVindueId)
);