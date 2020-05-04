use MinhHungShop

go
create proc Sp_CreateProductCategory(@Name nvarchar(250))
as
begin
	Insert into ProductCategory (Name) values(@Name)
end

GO
CREATE PROC sp_SelectTopProduct
AS
BEGIN
	SELECT TOP 9 * 
	FROM Product
	ORDER BY Product.ViewCount
END

GO
CREATE PROC sp_SelectProductByCategory(@ID bigint)
AS
BEGIN
	SELECT * 
	FROM Product p JOIN ProductCategory AS pc 
	ON (P.CategoryID = PC.ID)
END

GO
CREATE PROC sp_DeleteProductCategoryById(@ID bigint)
AS
BEGIN
	DELETE FROM ProductCategory
	WHERE ProductCategory.ID = ID
END

GO
CREATE PROC sp_FindProductCategoryById(@ID bigint)
AS
BEGIN
	SELECT * FROM ProductCategory
	WHERE ProductCategory.ID = @ID
END

