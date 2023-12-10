# Task Manager API

## Sobre

Este � o reposit�rio para a API do Task Manager, uma aplica��o para gerenciamento de tarefas e projetos.

## Pr�-requisitos

Antes de iniciar, certifique-se de ter o seguinte instalado em seu sistema:

- Docker
- Docker Compose
- Git (opcional, para clonar o reposit�rio)

## Como usar

### Clonando o Reposit�rio

Para obter o c�digo-fonte em sua m�quina local, clone o reposit�rio Git usando:

git clone https://github.com/tigasnogueira/TaskManager.git
cd TaskManager


Se voc� n�o estiver usando Git, pode simplesmente baixar e extrair o c�digo-fonte do [GitHub](https://github.com/tigasnogueira/TaskManager).

### Executando com Docker Compose

Dentro do diret�rio do projeto, inicie a aplica��o e o banco de dados com Docker Compose usando:

docker-compose up -d


Isso iniciar� os servi�os definidos no arquivo `docker-compose.yml`, incluindo a API do Task Manager e o SQL Server.

### Acessando a Aplica��o

Com os cont�ineres em execu��o, a API do Task Manager estar� dispon�vel em:

http://localhost:8000

Voc� pode acessar esta URL usando um navegador ou ferramentas como Postman para interagir com a API.

### Executando Migrations

Para executar as migrations e configurar o banco de dados, siga estas etapas:

1. Abra o Package Manager Console no Visual Studio.
2. Defina o projeto `TaskManager.Infra.Data` como o projeto padr�o.
3. Execute o comando `Update-Database`.

### Limpeza

Para parar e remover os cont�ineres, e tamb�m os volumes do Docker Compose, use:

docker-compose down -v

Se voc� fizer altera��es no c�digo-fonte e quiser refleti-las no Docker, remova tamb�m o volume da aplica��o com:

docker volume rm [NOME_DO_VOLUME]
