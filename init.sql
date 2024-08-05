

-- Database: raillogistic

--DROP DATABASE IF EXISTS raillogistic;

CREATE TABLE IF NOT EXISTS Shipments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Origin VARCHAR(255) NOT NULL,
    Destination VARCHAR(255) NOT NULL,
    EstimatedArrivalTime DATETIME NOT NULL,
    CurrentLocation VARCHAR(255),
    Status VARCHAR(50),
    RailcarId INT,
    FOREIGN KEY (RailcarId) REFERENCES Railcars(Id)
);

INSERT INTO Shipments (Origin, Destination, EstimatedArrivalTime, CurrentLocation, Status, RailcarId)
VALUES
('New York', 'Los Angeles', '2024-08-10 15:30:00', 'Chicago', 'InTransit', 1),
('San Francisco', 'Houston', '2024-08-12 12:00:00', 'Denver', 'Delayed', 2),
('Miami', 'Seattle', '2024-08-14 18:45:00', 'Atlanta', 'InTransit', 3);


CREATE TABLE IF NOT EXISTS ShipmentEvents (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ShipmentId INT,
    Timestamp DATETIME NOT NULL,
    EventType VARCHAR(50) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    FOREIGN KEY (ShipmentId) REFERENCES Shipments(Id)
);

INSERT INTO ShipmentEvents (ShipmentId, Timestamp, EventType, Location)
VALUES
(1, '2024-08-05 08:00:00', 'Departure', 'New York'),
(1, '2024-08-06 12:00:00', 'Arrival', 'Chicago'),
(2, '2024-08-08 14:30:00', 'Departure', 'San Francisco'),
(2, '2024-08-09 16:00:00', 'Delay', 'Denver'),
(3, '2024-08-07 10:00:00', 'Departure', 'Miami'),
(3, '2024-08-08 11:30:00', 'Arrival', 'Atlanta');


CREATE TABLE IF NOT EXISTS Railcars (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    SerialNumber VARCHAR(255) NOT NULL,
    Status VARCHAR(50) NOT NULL
);


-- Insert into Railcars
INSERT INTO Railcars (SerialNumber, Status)
VALUES 
('RC12345', 'InTransit'),
('RC67890', 'UnderMaintenance'),
('RC54321', 'Available');


-- Insert into Shipments
INSERT INTO Shipments (Origin, Destination, EstimatedArrivalTime, CurrentLocation, Status, RailcarId)
VALUES ('Chicago', 'San Diego', '2024-08-16 10:30:00', 'Kansas City', 'InTransit', 3);

-- Insert into ShipmentEvents
INSERT INTO ShipmentEvents (ShipmentId, Timestamp, EventType, Location)
VALUES (4, '2024-08-12 09:00:00', 'Departure', 'Chicago');


