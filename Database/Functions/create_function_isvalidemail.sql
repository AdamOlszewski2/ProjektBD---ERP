USE ProjektBD
Go
CREATE FUNCTION dbo.IsValidEmail(@EMAIL varchar(255))

RETURNS bit as
BEGIN     
  DECLARE @bitRetVal as Bit
  IF (@EMAIL <> '' AND @EMAIL NOT LIKE '_%@__%.__%')
     SET @bitRetVal = 0  -- Invalid
  ELSE 
    SET @bitRetVal = 1   -- Valid
  RETURN @bitRetVal
END 