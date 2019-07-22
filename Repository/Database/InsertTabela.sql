INSERT INTO estados(nome, sigla, data_criacao, registro_ativo) VALUES
('Santa Catarina', 'SC', '2019-01-01', 1),
('São Paulo', 'SP', '2019-02-02', 1),
('Rio de Janeiro', 'RJ', '2019-03-03', 1),
('Rio Grande do Sul', 'RS', '2019-04-04' , 1),
('Piauí', 'PI', '2019-05-05', 1);

INSERT INTO cidades(id_estado, nome, numero_habitantes, data_criacao, registro_ativo) VALUES
(1, 'Blumenau', 352460, '2018-06-06', 1),
(2, 'Ribeirão Preto', 590593, '2018-07-07', 1),
(3, 'Bom Jesus do Itabapoana', 35411, '2018-08-08', 1),
(4, 'Gramado', 31655, '2018-09-09', 1),
(5, 'Parnaíba', 137485, '2018-10-10', 1);

INSERT INTO clientes(id_cidade, nome, cpf, data_nascimento, numero, complemento, logradouro, cep, data_criacao, registro_ativo) VALUES
(5, 'João', '123.321.456-56', '1980-01-10', 2455, 'Nova A', 'Rua A', '44053816', '2017-11-11', 1),
(4, 'Carlos', '098.765.543-12', '1988-02-11', 1232, 'Rua Limpo', 'Rua Abel', '44089284', '2017-12-12', 1),
(3, 'Jose', '436.658.960-44', '1975-12-22', 1001, 'Queimadina', 'Rua A', '44050524', '2017-01-13', 1),
(2, 'Ronaldo', '333.675.897-33', '1988-11-23', 3452, 'Papagaio', 'Rua C', '44061080', '2017-02-14', 1),
(1, 'Camila', '645.867.087-22', '1999-04-27', 5467, 'Rua Limpo', 'Rua Adão', '44034084', '2017-03-15', 1);

INSERT INTO projetos(id_cliente, nome, data_criacao_projeto, data_finalizacao, data_criacao, registro_ativo) VALUES
(1, 'Projeto Almanaque', '1877-07-17', '1888-08-18', '2019-07-21', 1),
(2, 'Projeto Lidoriana', '2000-01-01', '2005-05-05', '2019-07-21', 1),
(3, 'Projeto Anarquia', '2017-07-17', '2019-07-29', '2019-07-21', 1),
(4, 'Projeto Elden Ring', '2019-12-22', '2021-06-16', '2019-07-21', 1),
(5, 'Projeto Hallucinated', '2018-03-13', '2019-05-18', '2019-07-21', 1);

INSERT INTO usuarios(nome, login, senha, data_criacao, registro_ativo) VALUES
('Lionelds', 'leoniano', '123321', '2019-07-19', 1),
('Charles', 'charada', 'charada123', '2018-08-23', 1),
('Miyazaki', 'leo', 'leo675', '2016-01-29', 1),
('Sabrina', 'bina', 'binalandia', '2015-04-22', 1),
('ryan', 'hugh', 'deadpool3', '2021-07-16', 1);

INSERT INTO categorias(nome, data_criacao, registro_ativo) VALUES
('Aniquilação', '2011-11-11', 1),
('Destruição', '2012-12-12', 1),
('Molecula', '2013-03-13', 1),
('Souls', '2014-04-14', 1),
('Tempo', '2015-05-15', 1);

INSERT INTO tarefas(id_usuario_responsavel, id_projeto, id_categoria, titulo, descricao, duracao, data_criacao, registro_ativo) VALUES
(5, 1, 5, 'Ras Al Ghul', 'Alucinado de tanto ficar na frente da manquina', '12:30:49', '2019-07-19', 1),
(3, 4, 4, 'Rage', 'A loucura ta muito alem do normal', '05:35:00', '2021-06-16', 1),
(1, 2, 2, 'Fear', 'Não compreendo o que esta acontecendo', '00:45:00', '2015-05-15', 1),
(2, 5, 3, 'Complicado', 'Isso é tudo pessoal', '02:25:00', '2016-12-26', 1),
(4, 3, 1, 'Dead', 'Nao consigo pensa em mais nada para colocar nesse caraio', '08:20:15', '2016-06-16', 1);