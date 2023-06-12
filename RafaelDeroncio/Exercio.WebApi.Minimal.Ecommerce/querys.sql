DROP TABLE IF EXISTS Order_Products;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Customers;

CREATE TABLE Customers (
    id INTEGER PRIMARY KEY,
    name TEXT,
    birth_date TEXT,
    phone_number TEXT,
    email TEXT,
    identification_doc TEXT,
    address TEXT,
    register_date TEXT
);

CREATE TABLE Orders (
    id INTEGER PRIMARY KEY,
    customer_id INTEGER,
    order_date TEXT,
    total_amount REAL,
    FOREIGN KEY (customer_id) REFERENCES Customers(id)
);

CREATE TABLE Products (
    id INTEGER PRIMARY KEY,
    name TEXT,
    price REAL
);

CREATE TABLE Order_Products (
    id INTEGER PRIMARY KEY,
    order_id INTEGER,
    product_id INTEGER,
    quantity INTEGER,
    FOREIGN KEY (order_id) REFERENCES Orders(id),
    FOREIGN KEY (product_id) REFERENCES Products(id)
);

INSERT INTO Customers (name, birth_date, phone_number, email, identification_doc, address, register_date) VALUES
    ('João Silva', '1990-01-15', '987654321', 'joao.silva@example.com', '123456789', 'Rua A, 123', '2023-06-01'),
    ('Maria Souza', '1985-05-20', '987654322', 'maria.souza@example.com', '987654321', 'Avenida B, 456', '2023-06-02'),
    ('Pedro Santos', '1992-11-10', '987654323', 'pedro.santos@example.com', '654321987', 'Rua C, 789', '2023-06-03'),
    ('Ana Lima', '1998-03-25', '987654324', 'ana.lima@example.com', '789654321', 'Avenida D, 321', '2023-06-04'),
    ('José Pereira', '1980-07-12', '987654325', 'jose.pereira@example.com', '159753486', 'Rua E, 654', '2023-06-05'),
    ('Carla Rocha', '1995-09-08', '987654326', 'carla.rocha@example.com', '357951482', 'Avenida F, 987', '2023-06-06'),
    ('Paulo Costa', '1982-02-18', '987654327', 'paulo.costa@example.com', '753951486', 'Rua G, 321', '2023-06-07'),
    ('Fernanda Oliveira', '1993-12-07', '987654328', 'fernanda.oliveira@example.com', '951753486', 'Avenida H, 654', '2023-06-08'),
    ('Ricardo Almeida', '1987-06-30', '987654329', 'ricardo.almeida@example.com', '159753684', 'Rua I, 987', '2023-06-09'),
    ('Sandra Gonçalves', '1991-04-22', '987654330', 'sandra.goncalves@example.com', '951753684', 'Avenida J, 321', '2023-06-10'),
    ('Márcio Castro', '1984-08-05', '987654331', 'marcio.castro@example.com', '753951468', 'Rua K, 654', '2023-06-11'),
    ('Lúcia Santos', '1997-10-27', '987654332', 'lucia.santos@example.com', '159753846', 'Avenida L, 987', '2023-06-12'),
    ('Rafaela Pereira', '1983-01-08', '987654333', 'rafaela.pereira@example.com', '951753468', 'Rua M, 321', '2023-06-13'),
    ('Júlio Rodrigues', '1994-07-03', '987654334', 'julio.rodrigues@example.com', '753951648', 'Avenida N, 654', '2023-06-14'),
    ('Patrícia Costa', '1989-03-16', '987654335', 'patricia.costa@example.com', '159753846', 'Rua O, 987', '2023-06-15'),
    ('Fábio Pereira', '1996-11-09', '987654336', 'fabio.pereira@example.com', '951753864', 'Avenida P, 321', '2023-06-16'),
    ('Andréa Gonçalves', '1986-05-04', '987654337', 'andrea.goncalves@example.com', '753951846', 'Rua Q, 654', '2023-06-17'),
    ('Carlos Almeida', '1999-02-17', '987654338', 'carlos.almeida@example.com', '159758436', 'Avenida R, 987', '2023-06-18'),
    ('Beatriz Lima', '1981-12-10', '987654339', 'beatriz.lima@example.com', '951758436', 'Rua S, 321', '2023-06-19'),
    ('Gustavo Rodrigues', '1990-06-23', '987654340', 'gustavo.rodrigues@example.com', '753958416', 'Avenida T, 654', '2023-06-20');
	
-- Inserts para a tabela "Products"
INSERT INTO Products (name, price) VALUES
    ('Camiseta Branca', 29.99),
    ('Calça Jeans', 79.99),
    ('Tênis Esportivo', 99.99),
    ('Bolsa de Couro', 149.99),
    ('Óculos de Sol', 59.99),
    ('Smartphone', 699.99),
    ('Notebook', 1199.99),
    ('Televisão', 799.99),
    ('Fones de Ouvido', 149.99),
    ('Relógio Inteligente', 249.99),
    ('Câmera Digital', 399.99),
    ('Console de Videogame', 499.99),
    ('Tablet', 299.99),
    ('Impressora', 129.99),
    ('Monitor', 249.99);
	
-- Inserts para a tabela "Orders"
INSERT INTO Orders (customer_id, order_date, total_amount) VALUES
    (1, '2023-06-01', 150.99),
    (2, '2023-06-02', 99.50),
    (3, '2023-06-03', 250.75),
    (4, '2023-06-04', 75.20),
    (5, '2023-06-05', 199.99),
    (6, '2023-06-06', 329.50),
    (7, '2023-06-07', 500.00),
    (8, '2023-06-08', 179.99),
    (9, '2023-06-09', 299.00),
    (10, '2023-06-10', 89.95);

-- Inserts para a tabela "Order_Products"
INSERT INTO Order_Products (order_id, product_id, quantity) VALUES
    (1, 1, 2),
    (1, 3, 1),
    (2, 2, 3),
    (2, 4, 1),
    (3, 5, 1),
    (3, 6, 2),
    (3, 8, 1),
    (4, 7, 1),
    (4, 9, 3),
    (5, 10, 2),
    (6, 2, 1),
    (6, 4, 1),
    (6, 6, 1),
    (7, 3, 1),
    (7, 5, 2),
    (7, 7, 1),
    (8, 1, 3),
    (8, 6, 1),
    (9, 4, 2),
    (10, 2, 1);

	
