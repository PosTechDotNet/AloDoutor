# AloDoutor

## Sobre

Este projeto faz parte do trabalho de conclusão da primeira fase da POSTECH FIAP de Arquitetura de Sistemas .Net com Azure.


## Tecnologias Utilizadas

- Obrigatórias
    - ASP.Net Core 7.0
    - SQL Server 2022
    - Entity Framework Core 7.0.12
- Ferramenta de desenvolvimento utilizada
    - Visual Studio 2022
   

## Como executar

Existem duas opções para executar o projeto, utilizando o Docker ou executando localmente.

- Execução com Docker (recomendada):
    
    1- Se você estiver no Windows instale o [WSL](https://learn.microsoft.com/pt-br/windows/wsl/install)

    2- Instale o [Docker Desktop](https://www.docker.com/products/docker-desktop/)
    
    3- Clone o repositório
    
    4- No terminal vá até a pasta `/AloDoutor` e execute o comando `docker-compose up -d` para executar os containers das aplicações e do SQL Server
    
    5- Abra o navegador e acesse:
        -  `http://localhost:9191/swagger` para a API de autenticação e autorização
        -  `http://localhost:9090/swagger` para a API AloDoutor


- Execução local:
    1- Clone o repositório

    2- No terminal vá até a pasta `/AloDoutor` e execute o comando `dotnet restore` para restaurar as dependências do projeto
    
    3- Atualização da base de dados (este passo não é obrigatório pois a aplicação foi configurada para executar as migrations automaticamente, mas caso queira executar manualmente siga os passos abaixo):
    - Execute o comando `dotnet tool install --global dotnet-ef`
    - Vá para a pasta `/AloDoutor.Api`
    - Execute o comando `dotnet ef database update`
    - Vá para a pasta `/Identidade.Api`
    - Execute novamente o comando `dotnet ef database update`
    
    4- Executando os projetos:
    - Volte na pasta `/AloDoutor.Api` execute o comando `dotnet run` para executar o projeto
    - Abra um novo terminal na pasta `/Identidade.Api` execute o comando `dotnet run` para executar o projeto
    - Abra o navegador e acesse:
        -  `http://localhost:5002/swagger` para a API de autenticação e autorização
        -  `http://localhost:5001/swagger` para a API AloDoutor 




## Documentação

- [Levantamento de Requisitos](./documentacao/requisitos.md)
- [Utilizando a Autenticação e Autorização](./documentacao/autenticacao.md)