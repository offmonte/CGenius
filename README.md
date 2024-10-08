# CGenius

## Definindo a Arquitetura da API

Optamos por desenvolver a aplica��o em uma arquitetura monol�tica em vez de microsservi�os, devido � aus�ncia de uma perspectiva clara de crescimento futuro. A aplica��o j� est� praticamente completa em termos de funcionalidades, e as futuras modifica��es ser�o apenas ajustes ou melhorias nas funcionalidades j� implementadas. A arquitetura monol�tica oferece maior simplicidade no desenvolvimento e nos testes, facilitando a integra��o entre os componentes, reduzindo a complexidade e tornando o desenvolvimento mais �gil e eficiente.

## CRUD da API

Para garantir o correto funcionamento do CRUD e dos relacionamentos entre as entidades, siga a ordem de cria��o dos registros (POST) de acordo com as depend�ncias:

### Ordem de Postagem
1. **Atendente** (necess�rio para criar Venda)
2. **Plano** (necess�rio para criar Script)
3. **Script** (necess�rio para criar Cliente e Venda)
4. **Cliente** (necess�rio para criar Especificacao e Venda)
5. **Especificacao** (necess�rio para criar Venda)
6. **Venda** (�ltima entidade, pois depende de todas as anteriores)

---

## Exemplos de JSONs para POST

### 1. Atendente
```json
{
  "cpfAtendente": "98765432100",
  "nomeAtendente": "Maria Souza",
  "setor": "Vendas",
  "senha": "senha123",
  "perfilAtendente": "Atendente Senior",
  "vendas": []
}
```

### 2. Plano
```json
{
    "NomePlano": "Plano Premium Plus",
    "DescricaoPlano": "Acesso ilimitado a todos os servi�os.",
    "ValorPlano": 199.99,
    "scripts": [],
    "vendas": []
}
```

### 3. Script
```json
{
    "DescricaoScript": "Script de venda para clientes premium.",
    "IdPlano": 1
}
```

### 4. Cliente
```json
{
    "CpfCliente": "12345678900",
    "NomeCliente": "Jo�o da Silva",
    "DtNascimento": "1990-05-21",
    "Genero": "Masculino",
    "Cep": "12345678",
    "Telefone": "11987654321",
    "Email": "joao.silva@gmail.com",
    "PerfilCliente": "Cliente Premium",
    "IdScript": 1
}
```

### 5. Especificacao
```json
{
    "TipoCartaoCredito": "Black",
    "GastoMensal": 5000.00,
    "ViajaFrequentemente": true,
    "Interesses": "Tecnologia",
    "Profissao": "Engenheiro",
    "RendaMensal": 10000.00,
    "Dependentes": 2,
    "CpfCliente": "12345678900"
}
```



### 6. Venda
```json
{
    "CpfAtendente": "98765432100",
    "CpfCliente": "12345678900",
    "IdScript": 1,
    "IdPlano": 1,
    "IdEspecificacao": 1
}
```


## Integrantes

RM99814- Anna Soares
RM98214- Gabriel Cirilo
RM551423-Izabelly Oliveira
RM551604- Lucas Monte
RM99578-Marcos Garrido
