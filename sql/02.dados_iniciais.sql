
DELIMITER $$

DROP PROCEDURE IF EXISTS preencher_dados_iniciais $$

CREATE PROCEDURE preencher_dados_iniciais () 
    BEGIN
	    declare lastid int;

	    if not exists (select * from tipos_servicos) then
	    	insert into tipos_servicos (id, nome)
	    	values 
	    	(1, 'Manicure'), 
	    	(2, 'Pedicure'),
	    	(3, 'Corte cabelo feminino'),
	    	(4, 'Corte e pintura de cabelo feminino'),
	    	(5, 'Progressiva'),
	    	(6, 'Corte de cabelo masculino'),
	    	(7, 'Barba');
	    end if;
	   
	    if not exists (select * from fornecedores) then
	    	insert into usuarios (nome, email, senha, role, telefone, cpf_cnpj) 
	    	values ('Salão Mariana', 'salao1@teste.com', MD5('123456'), 'FORNECEDOR', '5511999191919', '58283934000168');

	    	SELECT LAST_INSERT_ID() into lastid;
	    	
	    	insert into fornecedores (usuario_id, descricao, instagram, facebook, twitter, whatsapp, 
	    		logradouro, numero, complemento, bairro, cidade, uf, cep, latitude, longitude, avaliacao_media, qtd_avaliacoes)
	    	values (lastid, 'Salão de beleza com mais de 5 anos de excelência no atendimento de nossos clientes.', 'salaoteste1', 'salaoteste1', 'salaoteste1', '+5511999999999',
	    		'R. Dr. Miranda de Azevedo', '585', null, 'Pompeia', 'São Paulo', 'SP', '05027000',-23.5290456,-46.6881212, 4.33, 10);
	    	
	    	insert into usuarios (nome, email, senha, role, telefone, cpf_cnpj) 
	    	values ('João Cabeleireiro', 'cabeleireiro1@teste.com', MD5('123456'), 'FORNECEDOR', '5511999191988', '08678424079');

	    	SELECT LAST_INSERT_ID() into lastid;
	    	
	    	insert into fornecedores (usuario_id, descricao, instagram, facebook, twitter, whatsapp, 
	    		logradouro, numero, complemento, bairro, cidade, uf, cep, latitude, longitude, avaliacao_media, qtd_avaliacoes)
	    	values (lastid, 'Cabeleireiro com mais de 15 anos de experiência e clientela fiel.', 'cabeleireiroteste1', 'cabeleireiroteste1', 'cabeleireiroteste1', '+5511999999988',
	    		'R. Min. Ferreira Alves', '686', 'Sala 01', 'Pompeia', 'São Paulo', 'SP', '05009000',-23.529705,-46.6900665, null, 0);

	    end if;
    END $$

DELIMITER ;

CALL preencher_dados_iniciais();

drop procedure preencher_dados_iniciais;