/*
    drop table if exists fornecedor_servico;
    drop table if exists fornecedor_horario;
    drop table if exists agendamento_historico;
    drop table if exists agendamentos;
    drop table if exists tipos_servicos;
    drop table if exists cidades;
    drop table if exists fornecedores;
    drop table if exists clientes;
	drop table if exists usuarios;
*/

create table if not exists tipos_servicos (
	id    int auto_increment not null, 
	nome  varchar(255) not null,
	primary key pk_tipos_servicos (id)
);


create table if not exists usuarios (
	id       int auto_increment not null,

	nome     varchar(255) not null, -- nome do profissional/salão ou cliente
	email    varchar(255) not null,
	senha    varchar(255) not null,
	role     varchar(20) not null,

	telefone varchar(255) null,
	cpf_cnpj varchar(20) null,

	primary key pk_usuarios (id),
	unique uq_email (email),
	CHECK (role in ('FORNECEDOR', 'CLIENTE'))
);


create table if not exists clientes (
	id                  int auto_increment not null,

	usuario_id          int not null,
	sexo                varchar(30) null,
	dt_nascimento       date null,

	logradouro          varchar(255) null,
	numero              varchar(255) null,
	complemento         varchar(255) null,
	bairro              varchar(255) null,
	cidade              varchar(255) null,
	uf                  varchar(2) null,
	cep                 varchar(15) null,

	latitude            numeric(14, 12) null,
	longitude           numeric(14, 12) null,

	primary key pk_clientes (id),
	foreign key fk_clientes_usuario (usuario_id) references usuarios (id),
	CHECK (sexo in ('Masculino', 'Feminino', 'Não informar'))
);


create table if not exists fornecedores (
	id                  int auto_increment not null,

	usuario_id          int not null,
	descricao           text not null, -- descrição do local, serviços, etc

	instagram           varchar(250) null,
	facebook            varchar(250) null,
	twitter             varchar(250) null,
	whatsapp            varchar(250) null,
	
	avaliacao_media     numeric(2, 1) null,
	qtd_avaliacoes      int not null,
	
	logradouro          varchar(255) null,
	numero              varchar(255) null,
	complemento         varchar(255) null,
	bairro              varchar(255) null,
	cidade              varchar(255) null,
	uf                  varchar(2) null,
	cep                 varchar(15) null,

	latitude            numeric(14, 12) null,
	longitude           numeric(14, 12) null,

	primary key pk_fornecedores (id),
	foreign key fk_fornecedores_usuario (usuario_id) references usuarios (id)
);


create table if not exists fornecedor_servico (
	id                  int auto_increment not null,
	fornecedor_id       int not null,
	tipo_servico_id     int not null,

	tempo_medio         numeric(6,2) not null,
	tempo_medio_text    varchar(10) not null,

	primary key pk_fornecedor_servico (id),
	foreign key fk_fornecedor_servico_fornecedor (fornecedor_id) references fornecedores (id),
	foreign key fk_fornecedor_servico_tipo (tipo_servico_id) references tipos_servicos (id)
);


create table if not exists fornecedor_horario (
	id                  int auto_increment not null,
	fornecedor_id       int not null,
	
	dia_semana          int not null,
	fechado             bit not null,
	expediente_inicio   varchar(10) null,
	intervalo_inicio    varchar(10) null,
	intervalo_fim       varchar(10) null,
	expediente_fim      varchar(10) null,

	primary key pk_fornecedor_horario (id),
	foreign key fk_fornecedor_servico_fornecedor (fornecedor_id) references fornecedores (id)
);


create table if not exists agendamentos (
	id                  int auto_increment not null,
	fornecedor_id       int not null,
	cliente_id          int not null,
	tipo_servico_id     int not null,
	data_agendamento    date not null,
	hora_inicio         datetime not null,
	hora_fim            datetime not null,
	avaliacao           int null,
	status_agendamento  varchar(20) not null,

	primary key pk_agendamentos (id),
	foreign key fk_agendamentos_fornecedor (fornecedor_id) references fornecedores (id),
	foreign key fk_agendamentos_cliente (cliente_id) references clientes (id),
	foreign key fk_agendamentos_tipo (tipo_servico_id) references tipos_servicos (id),
	CHECK (status_agendamento in ('Pendente', 'Finalizado', 'Cancelado'))
);


create table if not exists agendamento_historico (
	id                  int auto_increment not null,
	agendamento_id      int not null,
	usuario_id          int not null,
	status_agendamento  varchar(20) not null,
	dt_historico        datetime not null,
	primary key pk_agendamento_historico (id),
	foreign key fk_agendamento_historico_agenda (agendamento_id) references agendamentos (id),
	foreign key fk_agendamento_historico_usuario (usuario_id) references usuarios (id),
	CHECK (status_agendamento in ('Pendente', 'Finalizado', 'Cancelado'))
);



create table if not exists cidades (
	id    int auto_increment not null,
	uf    varchar(2) not null, 
	nome  varchar(255) not null,
	primary key pk_cidades (id)
);


