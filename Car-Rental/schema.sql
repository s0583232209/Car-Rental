-- ============================================================
--  CarRentalDB – MySQL Schema
--  פרויקט השכרת רכבים | יצירת מסד נתונים מלא
-- ============================================================
DROP SCHEMA car_rental;
CREATE DATABASE IF NOT EXISTS car_rental;

USE car_rental;

-- ============================================================
--  1. Customers
-- ============================================================
CREATE TABLE IF NOT EXISTS Customers (
    Id          INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FullName    VARCHAR(100)    NOT NULL,
    Email       VARCHAR(150)    NOT NULL UNIQUE,
    Phone       VARCHAR(20)     NOT NULL
);

-- ============================================================
--  2. Vehicles
-- ============================================================
CREATE TABLE IF NOT EXISTS Vehicles (
    Id              INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Manufacturer    VARCHAR(50)     NOT NULL,
    Model           VARCHAR(50)     NOT NULL,
    Year            INT             NOT NULL,
    LicensePlate    VARCHAR(20)     NOT NULL UNIQUE,
    DailyPrice      INT  NOT NULL,

    CONSTRAINT CHK_Vehicles_DailyPrice
        CHECK (DailyPrice > 0)
);

-- ============================================================
--  3. Rentals
-- ============================================================
CREATE TABLE IF NOT EXISTS Rentals (
    Id          INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    CustomerId  INT             NOT NULL,
    CarId       INT             NOT NULL,
    StartDate   DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP,
    EndDate     DATETIME        NULL,           -- NULL = השכרה פעילה


    CONSTRAINT FK_Rentals_Customer
        FOREIGN KEY (CustomerId)
        REFERENCES Customers (Id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,

    CONSTRAINT FK_Rentals_Vehicle
        FOREIGN KEY (CarId)
        REFERENCES Vehicles (Id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,

    CONSTRAINT CHK_Rentals_Dates
        CHECK (EndDate IS NULL OR EndDate > StartDate)
);

-- ============================================================
--  4. Payments
-- ============================================================
CREATE TABLE IF NOT EXISTS Payments (
    Id          INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    RentalId    INT             NOT NULL,
    PaymentDate DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP,
    TotalPrice  decimal(10, 2)  NOT NULL DEFAULT 0,

    CONSTRAINT FK_Payments_Rental
        FOREIGN KEY (RentalId)
        REFERENCES Rentals (Id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,

    CONSTRAINT CHK_TotalPrice
        CHECK (TotalPrice > 0)
);

-- ============================================================
--  Sample Data – נתוני דוגמה
-- ============================================================

INSERT INTO Customers (FullName, Email, Phone) VALUES
    ('ישראל ישראלי',  'israel@example.com',  '050-1111111'),
    ('שרה כהן',       'sara@example.com',    '052-2222222'),
    ('דוד לוי',       'david@example.com',   '054-3333333');

INSERT INTO Vehicles (Manufacturer, Model, Year, LicensePlate, DailyPrice) VALUES
    ('Toyota',  'Corolla',  2021, '123-45-678', 250.00),
    ('Hyundai', 'Tucson',   2022, '234-56-789', 350.00),
    ('Kia',     'Sportage', 2023, '345-67-890', 320.00),
    ('Mazda',   'CX-5',     2022, '456-78-901', 380.00);

INSERT INTO Rentals (CustomerId, CarId, StartDate, EndDate) VALUES
    (1, 1, '2024-01-10 09:00:00', '2024-01-13 09:00:00'),
    (2, 2, '2024-01-15 10:00:00', '2024-01-18 10:00:00'),
    (3, 3, NOW(),                 NULL                  );   -- השכרה פעילה

INSERT INTO Payments (RentalId, TotalPrice, PaymentDate) VALUES
    (1, 750.00,  '2024-01-13 09:30:00'),
    (2, 1050.00, '2024-01-18 11:00:00');

-- ============================================================
--  Useful Queries – שאילתות שימושיות
-- ============================================================

-- כל ההשכרות הפעילות כרגע
-- SELECT r.Id, c.FullName, v.Manufacturer, v.Model, r.StartDate
-- FROM Rentals r
-- JOIN Customers c ON r.CustomerId = c.Id
-- JOIN Vehicles  v ON r.CarId      = v.Id
-- WHERE r.EndDate IS NULL;

-- כל הרכבים הזמינים (לא מושכרים כרגע)
-- SELECT * FROM Vehicles
-- WHERE Id NOT IN (
--     SELECT CarId FROM Rentals WHERE EndDate IS NULL
-- );

-- סה"כ הכנסות לפי רכב
-- SELECT v.Manufacturer, v.Model, SUM(p.Amount) AS TotalRevenue
-- FROM Payments p
-- JOIN Rentals r ON p.RentalId = r.Id
-- JOIN Vehicles v ON r.CarId = v.Id
-- GROUP BY v.Id;