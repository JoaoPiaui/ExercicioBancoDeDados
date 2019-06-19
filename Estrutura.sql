DROP TABLE peixes;
CREATE TABLE peixes (
id INT PRIMARY KEY IDENTITY,
nome VARCHAR(100),
raca VARCHAR(100),
preco DECIMAL(8,2),
quantidade int
);
SELECT id, nome, raca, preco, quantidade FROM peixes;























DROP TABLE colaboradores;
CREATE TABLE colaboradores(
id INT PRIMARY KEY IDENTITY,
nome VARCHAR(150),
cpf VARCHAR(14),
salario DECIMAL(8,2),
sexo VARCHAR(20),
cargo VARCHAR(30),
programador BIT
);

SELECT id,nome,cpf,salario,sexo,cargo,programador FROM colaboradores;
