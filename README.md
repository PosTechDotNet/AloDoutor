# Clínica Alo Doutor
## Índice
- [Clínica Alo Doutor](#clínica-alo-doutor)
  - [Histórico da Clínica](#histórico-da-clínica)
  - [Solução](#solução)
  - [Como Executar o Projeto](#Como-executar-o-projeto)
  - [DDD](#ddd)
    - [Domain Storytelling](#domain-storytelling)
    - [Domínios e Contextos Delimitados Identificados](#domínios-e-contextos-delimitados-identificados)
        - [Domínios](#domínios)
        - [Contextos Delimitados](#contextos-delimitados)
  - [Critérios de Aceite](#critérios-de-aceite)
  - [Screenshots da solução](#screenshots-da-solução)
  - [Tecnologias Utilizadas](#tecnologias-utilizadas-🛠️)


## Histórico da Clínica

A clímica Alô Doutor provê um serviço gratuito de consultas médicas para a população utilizando o sistema de atendimento presencial. 

A  clínica foi fundada em 2010 e desde então vem atendendo a população de forma gratuita. A clínica conta com médicos voluntários que atendem a população de segunda a sexta das 8h às 18h. 

Os médicos realizam consultas humanizadas de 1 hora e tem um intervalo de almoço das 12:00 as 14:00.

Atualmente todo o trabalho da clínica é feito de forma manual em fichas de papel, porém a clínica está buscando modernizar o seu sistema de marcação de consultas para melhorar a experiência do paciente e do médico.

Nesse momento foi solicitado que a informatização fosse realizada sem melhorias no processo atual.

## Solução
Desenvolvimento de uma Web Api em .NET Core com uma abordagem em Code First Migrations, e o Entity Framework para a persistência dos dados em um banco de dados Sql Server.

## Como Executar o Projeto
Inicializa o banco de dados e as APIs (É necessário ter o docker e docker-compose instalados na máquina local):

```console
docker-compose up -d
```
### DDD
Para a modelagem da solução utilizamos o Domain Driven Design e fizemos uso do Domain Storytelling para transformar o conhecimento sobre o domínio em requisitos para o desenvolvimento da solução via um Software.
#### Domain Storytelling

O time de desenvolvimento conversou com o responsável administrativo pela clínica e identificou os seguintes pontos:

![Cadastro do Médico](./documentacao/imagens/01-CadastroMedico.png)
</br>
</br>
![Cadastro do Paciente](./documentacao/imagens/02-CadastroPaciente.png)
</br>
</br>
![Agendamento Consulta](./documentacao/imagens/03-AgendamentoConsulta.png)




#### Domínios e Contextos Delimitados Identificados

##### Domínios

![Domínios Identificados](./documentacao/imagens/dominiosAloDoutor.png)



#### Contextos Delimitados

![Mapa de Contextos Delimitados](./documentacao/imagens/mapaContextos.png)


### Critérios de Aceite

- Cadastro de Médico 
    - As seguintes informações são obrigatórias no cadastro:
        - Nome
        - CPF
        - CRM
        - Telefone
        - Endereço
        - Estado
        - CEP
    - A especialidade é opcional
    - Um médico pode atender em mais de uma especialidade
    - Não podem haver dois médicos com o mesmo CRM
    - Não podem haver dois médicos com o mesmo CPF
    - O CPF deve ter 11 caracteres númericos
    - Nome precisa ter no mínimo 2 caracteres
    - Estado e endereço deve ter mais do que 2 caracteres
    

</br>

- Cadastro do Paciente
    - As seguintes informações são obrigatórias:
        - Nome
        - CPF
        - Idade
        - Telefone
        - Endereço
        - Estado
        - CEP

    - Não podem haver dois pacientes com o mesmo CPF
    - O CPF deve ter 11 caracteres númericos
<br>

- Marcação de Consultas
    - O Paciente e o Médico já devem estar cadastrados
    - Só podem ser considerados médicos que tem especialidade associada
    - As consultas só podem ser agendadas para os seguites dias:
        - Segunda-feira a Sexta-feira das 09h às 18h
    - Cada consulta tem duração de 1 hora obrigatoriamente
    - Não há necessidade de considerar feriados
    - As consultas devem ser agendadas com um mínimo de 2 horas de antecedência
    - O Paciente não pode marcar duas consultas no mesmo dia e horário
    - A consulta pode ser cancelada pelos usuários do sistema
    - Para reagendamentos e cancelamentos são necessários no mínimo 2 dias de antecedência (desconsiderando fins de semana)
   
<br>

- Controle de Acesso
    - Todas as funcionalizadas devem ser executadas por um Usuário previamente cadastrado no sistema
    - O sistema deve ter 2 tipos de usuário:
        - Administrador: Acesso a cadastro de usuário e as funcionalidades do Alô Doutor
        - Operador: Acesso somente as funcionalidades do Alô Doutor
    - Se o usuário não estiver autenticado, ele não pode acessar as funcionalidades do sistema
    - O usuário cadastrado contará com nome, cpf e email. Todos são obrigatórios, sendo que:
        - O Email deve ser válido
        - A Senha deve ter o mínimo de 6 caracteres
            - A senha deve ser composta por 1 carater não alfanúmerico, 1 digito (0-9), 1 letra caixa baixa (a-z), 1 letra caixa alta (A-Z)  
            - No momento do cadastro precisa ser inserida 2 vezes

### Screenshots da solução
    COLOCAR AS IMAGENS DA API AQUI
## Tecnologias Utilizadas 🛠️

| Tecnologias | Uso
------------ | -------------
[C#](https://docs.microsoft.com/en-us/dotnet/csharp/) | Linguagem de Programação
[.NET](https://dotnet.microsoft.com/) | Framework web
[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) | Biblioteca para persistência de Dados (ORM)
[Serilog](https://serilog.net/) | Captura de Logs
[Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) | Editor de Código
[Docker](https://www.docker.com/) | Criação de Containers
