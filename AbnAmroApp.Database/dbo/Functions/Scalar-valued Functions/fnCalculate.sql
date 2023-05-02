
CREATE FUNCTION fnCalculate
(
	@Number INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
)
RETURNS NVARCHAR(100)

AS
BEGIN 
	IF (([dbo].fnIsDivisibleBy(@Number, 3) = 1) AND ([dbo].fnIsDivisibleBy(@Number, 5) = 1))
		RETURN @FirstName + ' ' + @LastName
	ELSE IF ([dbo].fnIsDivisibleBy(@Number, 3) = 1)
		RETURN @FirstName
	ELSE IF ([dbo].fnIsDivisibleBy(@Number, 5) = 1)
		RETURN @LastName

	RETURN @Number
END
