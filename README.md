# Projeto Store 

Este projeto é uma implementação de um microserviço ecommerce baseado em uma arquitetura limpa (Clean Architecture), utilizando C# com .NET Core 6, Entity Framework Core, Key Vault e frontend em Angular.

## Tecnologias Utilizadas

### Backend
- **.NET 6 Core**: Framework para construção de APIs RESTful.
- **Entity Framework Core**: ORM para interação com o banco de dados SQL Server.
- **Key Vault**: Utilizado para gerenciamento seguro de chaves e credenciais sensíveis.
- **Clean Architecture**: Padrão arquitetural para garantir separação de responsabilidades e facilidade de manutenção.
- **BDD (Behavior Driven Development)**: Implementação de testes automatizados utilizando a abordagem BDD, garantindo que os requisitos sejam bem compreendidos e os testes sejam facilmente lidos e mantidos.

### Frontend
- **Angular**: Framework para construção de interfaces de usuário dinâmicas e reativas.

### Banco de Dados
- **SQL Server**: Sistema de gerenciamento de banco de dados relacional utilizado para persistência dos dados.

## Funcionalidades

- **Autenticação**: Implementação de um sistema de autenticação seguro. Baseado em Roles,auth e endpoints abertos
- **Persistência com Entity Framework Core**: Utiliza EF Core para interação com o banco de dados.
- **Migrations com Entity Framework Core**: Utiliza EF Core para migrações no SQL Server
- **Armazenamento Seguro com Key Vault**: Armazena informações sensíveis como senhas e chaves de API de forma segura. ( para acessar meu banco de testes, entre em contato)
- **Testes BDD**: Utilização de testes baseados em comportamento para garantir que a aplicação esteja funcionando conforme esperado em diferentes cenários de uso.

## Requisitos

- .NET 6 SDK
- Node.js e npm
- SQL Server
- Azure Key Vault (entre em contato para acessar meu ambiente de desenvolvimento)

## Estrutura do Projeto

###Backend (Clean Architecture)
O backend é desenvolvido seguindo os princípios da Clean Architecture, garantindo modularidade, testabilidade e escalabilidade. A estrutura é organizada em camadas bem definidas:

- UseCases: Contém as entidades, interfaces e a lógica central de domínio, totalmente independente de frameworks ou tecnologias específicas. Essa camada representa o coração da aplicação.

- Gateways: Abriga implementações específicas de infraestrutura, como acesso ao banco de dados (por exemplo, EF Core), integrações com o Key Vault, e demais interações externas.

- Controllers: Responsável pela camada de apresentação, implementando as APIs RESTful que expõem os recursos da aplicação.

Essa separação clara de responsabilidades permite que alterações em uma camada não impactem diretamente as demais, promovendo manutenibilidade e flexibilidade no desenvolvimento.

### Frontend (Angular)
O frontend foi desenvolvido utilizando o framework Angular, com uma estrutura de componentes e serviços bem definida para garantir uma manutenção simples e uma boa escalabilidade. A arquitetura segue os seguintes padrões:

- **Componentes**: Cada componente é responsável por uma parte específica da interface de usuário.
- **Serviços**: Os serviços são responsáveis pela lógica de negócios e pela comunicação com as APIs backend.
- **Modelos**: Modelos e interfaces definem a estrutura dos dados que são manipulados pela aplicação.

### Board de Tarefas (GitHub Tasks)
As tarefas do projeto são organizadas no GitHub através do board de tarefas. Cada item é categorizado e atribuído a um membro da equipe, com o objetivo de garantir um desenvolvimento ágil e colaborativo. As tarefas incluem:

- **Tarefas Técnicas**: Refletem as implementações técnicas que precisam ser feitas, como ajustes no código, configurações de infraestrutura, entre outros.

## Instalação

### Backend

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   cd nome-do-repositorio
****

2. Configuração do SQL Server com Docker
  Execute o SQL Server utilizando Docker:

bash
    Copiar código
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Password" -p 1433:1433 --name sql_server_dev -d mcr.microsoft.com/mssql/server:2022-latest
    Substitua YourStrong!Password pela senha desejada para o administrador.
    Certifique-se de que a porta 1433 está disponível.

3.Configuração do Ambiente de Desenvolvimento
  Entre em contato comigo para acesso ao keyvault e meu banco de desenvolvimento
  Ou 
  Altere na classe program a linha 69 "var connectionString" para utilizar o SQL instanciado via docker no passo anterior

4.Acesso ao Key Vault ( opcional )
  Solicite acesso ao Key Vault enviando um e-mail para:
  matheuspaes19@gmail.com

 5.Aplique as Migrações do Banco de Dados
  Execute o comando abaixo para preparar o banco:

  bash
  Copiar código
  dotnet ef database update

 6.Inicie o Backend
  Execute o projeto storei.api:

  bash
  Copiar código
  dotnet run --project ./store.api/Dockerfile
 



