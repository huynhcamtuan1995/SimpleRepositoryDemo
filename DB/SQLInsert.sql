USE [WMSDB]
GO
/****** Object:  StoredProcedure [dbo].[my_CreateData]    Script Date: 24/12/2020 12:58:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[my_CreateData]
as
begin
DECLARE @CateCount int, @TotalRow int;

SET ROWCOUNT 1
select @TotalRow = (COUNT(*) OVER())
FROM Categories c 
ORDER BY c.ID
SET ROWCOUNT 1
select @TotalRow
SET @CateCount = @TotalRow

WHILE @CateCount > 0
  BEGIN
	-- Add a new employee
	INSERT INTO Categories(Name)
	SELECT CONVERT(varchar(255), NEWID())

	SET @CateCount = @CateCount - 1
  END

DECLARE @ProductCount int
SET @ProductCount = 150000

WHILE @ProductCount > 0
  BEGIN
	-- Add a new employee
	INSERT INTO Products(Name,Quantity, CategoryID)

	SELECT CONVERT(varchar(255), NEWID()), 
		Ceiling((RAND() * 100)),
		Ceiling((RAND() * 500))

	SET @ProductCount = @ProductCount - 1
  END
end