-- Desenvolvido por Matheus Donato --
DROP TABLE IF EXISTS estados;
DROP TABLE IF EXISTS cidades;
DROP TABLE IF EXISTS clientes;
DROP TABLE IF EXISTS projetos;
DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS categorias;
DROP TABLE IF EXISTS tarefas;

SELECT * FROM estados;

CREATE TABLE estados(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	sigla VARCHAR(2) NOT NULL,
	data_criacao DATETIME2(7) NOT NULL,
	registro_ativo BIT NOT NULL
);

CREATE TABLE cidades(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_estado INT NOT NULL,
	FOREIGN KEY(id_estado) REFERENCES estados(id),
	nome VARCHAR(50) NOT NULL,
	numero_habitantes INT,
	data_criacao DATETIME2(7) NOT NULL,
	registro_ativo BIT NOT NULL
);

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_cidade INT NOT NULL,
	FOREIGN KEY(id_cidade) REFERENCES cidades(id),
	nome VARCHAR(50) NOT NULL,
	cpf VARCHAR(50) NOT NULL,
	data_nascimento DATETIME2(7) NOT NULL,
	numero INT NOT NULL,
	complemento NCHAR(10) NOT NULL,
	logradouro NCHAR(10) NOT NULL,
	cep NCHAR(10) NOT NULL,
	data_criacao DATETIME2(7) NOT NULL,
	registro_ativo BIT NOT NULL
);

CREATE TABLE projetos(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_cliente INT NOT NULL,
	FOREIGN KEY(id_cliente) REFERENCES clientes(id),
	nome VARCHAR(50) NOT NULL,
	data_criacao DATETIME2(7) NOT NULL,
	data_finalizacao DATETIME2(7) NOT NULL,
	registro_ativo BIT NOT NULL
);

CREATE TABLE usuarios(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	login VARCHAR(50) NOT NULL,
	senha VARCHAR(50) NOT NULL,
	data_criacao DATETIME2(7) NOT NULL,
	registro_ativo BIT NOT NULL
);

CREATE TABLE categorias(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	data_criacao DATETIME2(7) NOT NULL,
	registro_ativo BIT NOT NULL
);

CREATE TABLE tarefas(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_usuario_responsavel INT NOT NULL,
	FOREIGN KEY(id_usuario_responsavel) REFERENCES usuarios(id),
	id_projeto INT NOT NULL,
	FOREIGN KEY(id_projeto) REFERENCES projetos(id),
	id_categoria INT NOT NULL,
	FOREIGN KEY(id_categoria) REFERENCES categorias(id),
	titulo VARCHAR(50) NOT NULL,
	descricao TEXT NOT NULL,
	duracao DATETIME2(7) NOT NULL,
	data_criacao DATETIME2(7) NOT NULL,
	registro_ativo BIT NOT NULL
);