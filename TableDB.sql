CREATE TABLE [dbo].[Lasers] (
    [LaserID]                INT             NOT NULL,
    [LaserName]              NVARCHAR (250)  NULL,
    [MaximumPower]           DECIMAL (10, 2) NULL,
    [MaximumWeldingDuration] INT             NULL,
    [NumberOfTriggeredWelds] INT             NULL,
    [ConsumedEnergy]         DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([LaserID] ASC)
);


INSERT INTO [dbo].[Lasers] ([LaserID], [LaserName], [MaximumPower], [MaximumWeldingDuration], [NumberOfTriggeredWelds], [ConsumedEnergy])
VALUES
    (1, 'Laser A', 150.00, 600, 100, 20.5),
    (2, 'Laser B', 200.00, 800, 120, 25.0),
    (3, 'Laser C', 180.00, 700, 110, 22.5);
