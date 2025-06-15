-- Create the Products table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);

-- Insert some sample data
INSERT INTO Products (Name, Quantity, Price) VALUES
('Laptop', 10, 50000.00),
('Mouse', 50, 500.00);

-- Stored procedure: Get all products
CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END;

-- Stored procedure: Get product by ID
CREATE PROCEDURE GetProductById
    @Id INT
AS
BEGIN
    SELECT * FROM Products WHERE Id = @Id;
END;

-- Stored procedure: Insert new product
CREATE PROCEDURE AddProduct
    @Name NVARCHAR(100),
    @Quantity INT,
    @Price DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Products (Name, Quantity, Price)
    VALUES (@Name, @Quantity, @Price);
END;
