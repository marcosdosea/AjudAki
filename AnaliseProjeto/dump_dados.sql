USE `ajudaki`;

-- Inserir dados nas tabelas
-- Tabela `Assinatura`
INSERT INTO `ajudaki`.`Assinatura` (`nome`, `status`, `valor`, `descricao`) VALUES 
('FREE', 'ATIVA', 0.00, 'Plano gratuito.'),
('BÁSICO', 'ATIVA', 29.90, 'Plano básico com funcionalidades limitadas.'),
('AVANÇADO', 'INATIVA', 59.90, 'Plano avançado com todas as funcionalidades.');

-- Tabela `Pessoa`
INSERT INTO `ajudaki`.`Pessoa` (`nome`, `cpf`, `celular`, `telefone`, `dataNascimento`, `email`, `cep`, `bairro`, `rua`, `numResidencia`, `pontoReferencia`, `tipoPessoa`, `idAssinatura`) VALUES 
('João Silva', '12345678901', '11999999999', '1133334444', '1985-01-15', 'joao.silva@email.com', '12345678', 'Centro', 'Rua A', '123', 'Perto da padaria', 'CLIENTE', 1),
('Maria Oliveira', '98765432102', '21988888888', '2133335555', '1990-07-20', 'maria.oliveira@email.com', '87654321', 'Vila Nova', 'Rua B', '456', 'Próximo ao mercado', 'PROFISSIONAL', 2),
('Carlos Pereira', '11122233345', '31977777777', NULL, '1978-11-05', 'carlos.pereira@email.com', '65432109', 'Jardim', 'Rua C', '789', NULL, 'ADMINISTRADOR', 3);

-- Tabela `Agenda`
INSERT INTO `ajudaki`.`Agenda` (`data`, `turno`, `turnoOcupado`, `diaOcupado`) VALUES 
('2024-10-01 08:00:00', 'MANHÃ', 0, 0),
('2024-10-01 14:00:00', 'TARDE', 0, 0),
('2024-10-01 19:00:00', 'NOITE', 1, 1);

-- Tabela `AreaAtuacao`
INSERT INTO `ajudaki`.`AreaAtuacao` (`nome`) VALUES 
('Elétrica'),
('Hidráulica'),
('Pintura');

-- Tabela `TipoServico`
INSERT INTO `ajudaki`.`TipoServico` (`nome`, `idAgenda`, `idAreaAtuacao`) VALUES 
('Instalação de Tomadas', 1, 1),
('Reparo de Encanamento', 2, 2),
('Pintura de Paredes', 3, 3);

-- Tabela `SolicitacaoServico`
INSERT INTO `ajudaki`.`SolicitacaoServico` (`nome`, `dataHoraSolicitacao`, `status`, `valor`, `descricao`, `idCliente`, `idProfissional`, `idTipoServico`) VALUES 
('Solicitação de Instalação', '2024-10-10 10:00:00', 'PENDENTE', 150.00, 'Instalação de 5 tomadas.', 1, 2, 1),
('Solicitação de Reparo', '2024-10-11 11:30:00', 'ACEITO', 200.00, 'Reparo de vazamento no banheiro.', 2, 3, 2);

-- Tabela `Servico`
INSERT INTO `ajudaki`.`Servico` (`nome`, `data`, `idTipoServico`, `idAreaAtuacao`, `idProfissional`) VALUES 
('Serviço de Instalação', '2024-10-12 09:00:00', 1, 1, 2),
('Serviço de Pintura', '2024-10-12 15:00:00', 3, 3, 3);

-- Tabela `Contratacao`
INSERT INTO `ajudaki`.`Contratacao` (`nome`, `data`, `cep`, `bairro`, `rua`, `numResidencia`, `pontoReferencia`, `status`, `idServico`, `idCliente`) VALUES 
('Contratação de Instalação', '2024-10-13 10:00:00', '12345678', 'Centro', 'Rua A', '123', 'Perto da escola', 'PENDENTE', 1, 1),
('Contratação de Pintura', '2024-10-13 14:00:00', '87654321', 'Vila Nova', 'Rua B', '456', 'Próximo ao supermercado', 'ACEITO', 2, 2);

-- Tabela `Avaliacao`
INSERT INTO `ajudaki`.`Avaliacao` (`notaServico`, `notaProfissional`, `status`, `comentario`, `idContratacao`) VALUES 
(5, 4, 1, 'Ótimo serviço!', 1),
(4, 5, 1, 'Profissional excelente!', 2);

-- Tabela `PagamentoAssinatura`
INSERT INTO `ajudaki`.`PagamentoAssinatura` (`dataPagamento`, `status`, `idProfissional`, `idAssinatura`) VALUES 
('2024-10-01 10:00:00', 'PAGO', 2, 2),
('2024-09-01 10:00:00', 'ATRASADO', 2, 2);

-- Tabela `PessoaAgenda`
INSERT INTO `ajudaki`.`PessoaAgenda` (`idPessoa`, `idAgenda`) VALUES 
(1, 1),
(2, 2),
(3, 3);
