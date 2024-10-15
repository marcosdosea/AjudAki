-- SET FOREIGN_KEY_CHECKS = 0;

-- TRUNCATE TABLE `PagamentoAssinatura`;
-- TRUNCATE TABLE `Avaliacao`;
-- TRUNCATE TABLE `Contratacao`;
-- TRUNCATE TABLE `Servico`;
-- TRUNCATE TABLE `SolicitacaoServico`;
-- TRUNCATE TABLE `TipoServico`;
-- TRUNCATE TABLE `AreaAtuacao`;
-- TRUNCATE TABLE `PessoaAgenda`;
-- TRUNCATE TABLE `Agenda`;
-- TRUNCATE TABLE `Pessoa`;
-- TRUNCATE TABLE `Assinatura`;


USE `ajudaki`;

-- Inserindo dados na tabela Assinatura
INSERT INTO `Assinatura` (`nome`, `status`, `valor`, `descricao`)
VALUES
('FREE', 'ATIVA', 0.00, 'Plano gratuito'),
('BÁSICO', 'ATIVA', 29.90, 'Plano básico mensal'),
('AVANÇADO', 'INATIVA', 59.90, 'Plano avançado com recursos adicionais');

-- Inserindo dados na tabela Pessoa
INSERT INTO `Pessoa` (`nome`, `cpf`, `celular`, `telefone`, `dataNascimento`, `email`, `cep`, `bairro`, `rua`, `numResidencia`, `pontoReferencia`, `tipoPessoa`, `idAssinatura`)
VALUES
('João Silva', '12345678901', '11999999999', '1133334444', '1985-01-15', 'joao.silva@email.com', '12345678', 'Centro', 'Rua A', '123', 'Perto da padaria', 'CLIENTE', 1),
('Maria Oliveira', '98765432100', '21988888888', '2133335555', '1990-07-20', 'maria.oliveira@email.com', '87654321', 'Vila Nova', 'Rua B', '456', 'Próximo ao mercado', 'PROFISSIONAL', 2),
('Carlos Pereira', '11122233344', '31977777777', NULL, '1978-11-05', 'carlos.pereira@email.com', '65432109', 'Jardim', 'Rua C', '789', NULL, 'ADMINISTRADOR', 3);

-- Inserindo dados na tabela Agenda
INSERT INTO `Agenda` (`data`, `turno`, `turnoOcupado`, `diaOcupado`)
VALUES
('2024-10-14 08:00:00', 'MANHÃ', 1, 0),
('2024-10-14 14:00:00', 'TARDE', 0, 0),
('2024-10-15 19:00:00', 'NOITE', 1, 1);

-- Inserindo dados na tabela AreaAtuacao
INSERT INTO `AreaAtuacao` (`nome`)
VALUES
('Elétrica'),
('Hidráulica'),
('Pintura');

-- Inserindo dados na tabela TipoServico
INSERT INTO `TipoServico` (`nome`, `idAgenda`, `idAreaAtuacao`)
VALUES
('Instalação de Tomadas', 1, 1),
('Reparo de Encanamento', 2, 2),
('Pintura de Paredes', 3, 3);

-- Inserindo dados na tabela SolicitacaoServico
INSERT INTO `SolicitacaoServico` (`nome`, `dataHoraSolicitacao`, `status`, `valor`, `descricao`, `idCliente`, `idProfissional`, `idTipoServico`)
VALUES
('Troca de Fiação', '2024-10-13 09:30:00', 'ACEITO', 150.00, 'Troca completa da fiação elétrica', 1, 2, 1),
('Conserto de Vazamento', '2024-10-14 16:00:00', 'PENDENTE', 200.00, 'Vazamento na cozinha', 1, 2, 2);

-- Inserindo dados na tabela Servico
INSERT INTO `Servico` (`nome`, `data`, `idTipoServico`, `idAreaAtuacao`, `idProfissional`)
VALUES
('Instalação de Lâmpadas', '2024-10-14 09:00:00', 1, 1, 2),
('Reparo de Torneira', '2024-10-15 10:00:00', 2, 2, 2);

-- Inserindo dados na tabela Contratacao
INSERT INTO `Contratacao` (`nome`, `data`, `cep`, `bairro`, `rua`, `numResidencia`, `pontoReferencia`, `status`, `idServico`, `idCliente`)
VALUES
('Troca de Disjuntores', '2024-10-14 08:00:00', '12345678', 'Centro', 'Rua D', '101', 'Em frente ao parque', 'FINALIZADO', 1, 1),
('Conserto de Chuveiro', '2024-10-15 14:00:00', '87654321', 'Vila Nova', 'Rua E', '202', 'Próximo ao posto', 'PENDENTE', 2, 1);

-- Inserindo dados na tabela Avaliacao
INSERT INTO `Avaliacao` (`notaServico`, `notaProfissional`, `status`, `comentario`, `idContratacao`)
VALUES
(5, 4, 1, 'Serviço excelente, mas demorou um pouco.', 1),
(3, 2, 1, 'O serviço poderia ter sido melhor.', 2);

-- Inserindo dados na tabela PagamentoAssinatura
INSERT INTO `PagamentoAssinatura` (`dataPagamento`, `status`, `idProfissional`, `idAssinatura`, `nomePlano`) 
VALUES ('2024-10-01 10:00:00', 'PAGO', 2, 2, 'Plano Avançado'), 
       ('2024-09-01 10:00:00', 'ATRASADO', 2, 2, 'Plano Básico');

-- Inserindo dados na tabela PessoaAgenda
INSERT INTO `PessoaAgenda` (`idPessoa`, `idAgenda`)
VALUES
(2, 1),
(3, 2);
