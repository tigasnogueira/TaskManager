# Task Manager API

## Sobre

Este é o repositório para a API do Task Manager, uma aplicação para gerenciamento de tarefas e projetos.

## Pré-requisitos

Antes de iniciar, certifique-se de ter o seguinte instalado em seu sistema:

- Docker
- Docker Compose
- Git (opcional, para clonar o repositório)

## Como usar

### Clonando o Repositório

Para obter o código-fonte em sua máquina local, clone o repositório Git usando:

git clone https://github.com/tigasnogueira/TaskManager.git
cd TaskManager


Se você não estiver usando Git, pode simplesmente baixar e extrair o código-fonte do [GitHub](https://github.com/tigasnogueira/TaskManager).

### Executando com Docker Compose

Dentro do diretório do projeto, inicie a aplicação e o banco de dados com Docker Compose usando:

docker-compose up -d


Isso iniciará os serviços definidos no arquivo `docker-compose.yml`, incluindo a API do Task Manager e o SQL Server.

### Acessando a Aplicação

Com os contêineres em execução, a API do Task Manager estará disponível em:

http://localhost:8000

Você pode acessar esta URL usando um navegador ou ferramentas como Postman para interagir com a API.

### Executando Migrations

Para executar as migrations e configurar o banco de dados, siga estas etapas:

1. Abra o Package Manager Console no Visual Studio.
2. Defina o projeto `TaskManager.Infra.Data` como o projeto padrão.
3. Execute o comando `Update-Database`.

### Limpeza

Para parar e remover os contêineres, e também os volumes do Docker Compose, use:

docker-compose down -v

Se você fizer alterações no código-fonte e quiser refleti-las no Docker, remova também o volume da aplicação com:

docker volume rm [NOME_DO_VOLUME]
