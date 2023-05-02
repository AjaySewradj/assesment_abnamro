
CREATE FUNCTION fnCalculateAll
(
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
)
RETURNS @result TABLE (result NVARCHAR(100))

AS
BEGIN 
	DECLARE @index int = 1

	WHILE @index <= 100
	BEGIN
		DECLARE @foo NVARCHAR(100)
		SET @foo = [dbo].fnCalculate(@index, @FirstName, @LastName)

		insert into @result values(@foo)

		SET @index = @index + 1
	END

	RETURN
END