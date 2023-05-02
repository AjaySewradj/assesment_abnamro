
CREATE FUNCTION fnIsDivisibleBy
(
	@Number INT,
	@Divisor INT
)
RETURNS BIT

AS
BEGIN 
	RETURN (IIF((@Number % @Divisor) = 0, 1, 0))
END