
CREATE FUNCTION fnIsDivisibleBy
(
	@Number INT,
	@Divisor INT
)
RETURNS BIT

AS
BEGIN 
	IF(@Divisor = 0) RETURN 0;
	RETURN (IIF((@Number % @Divisor) = 0, 1, 0))
END