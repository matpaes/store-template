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

- **Microserviço de Pagamento**: Permite o controle de pagamentos mensais, incluindo operações de CRUD (criação, leitura, atualização e exclusão).
- **Autenticação**: Implementação de um sistema de autenticação seguro.
- **Persistência com Entity Framework Core**: Utiliza EF Core para interação com o banco de dados.
- **Armazenamento Seguro com Key Vault**: Armazena informações sensíveis como senhas e chaves de API de forma segura.
- **Testes BDD**: Utilização de testes baseados em comportamento para garantir que a aplicação esteja funcionando conforme esperado em diferentes cenários de uso.

## Requisitos

- .NET 6 SDK
- Node.js e npm
- SQL Server
- Azure Key Vault (para armazenar credenciais seguras)

## Estrutura do Projeto

### Backend (Clean Architecture)
O backend é estruturado utilizando a arquitetura limpa (Clean Architecture), que garante que a aplicação seja modular, testável e facilmente escalável. A estrutura é dividida da seguinte forma:

- **Core**: Contém as entidades, interfaces e lógica de domínio. Esta camada é independente de qualquer framework ou tecnologia específica.
- **Infrastructure**: Implementações específicas do framework, como EF Core, acesso ao Key Vault, e interação com o banco de dados.
- **WebAPI**: A camada de apresentação da aplicação, onde as APIs RESTful são implementadas e expostas.
  
A arquitetura limpa separa bem as responsabilidades, garantindo que mudanças em uma camada não afetem diretamente outras camadas.

### Frontend (Angular)
O frontend foi desenvolvido utilizando o framework Angular, com uma estrutura de componentes e serviços bem definida para garantir uma manutenção simples e uma boa escalabilidade. A arquitetura segue os seguintes padrões:

- **Componentes**: Cada componente é responsável por uma parte específica da interface de usuário.
- **Serviços**: Os serviços são responsáveis pela lógica de negócios e pela comunicação com as APIs backend.
- **Modelos**: Modelos e interfaces definem a estrutura dos dados que são manipulados pela aplicação.

### Board de Tarefas (GitHub Tasks)
As tarefas do projeto são organizadas no GitHub através do board de tarefas. Cada item é categorizado e atribuído a um membro da equipe, com o objetivo de garantir um desenvolvimento ágil e colaborativo. As tarefas incluem:

- **Histórias de Usuário**: Definem as funcionalidades a serem implementadas e os requisitos do sistema.
- **Tarefas Técnicas**: Refletem as implementações técnicas que precisam ser feitas, como ajustes no código, configurações de infraestrutura, entre outros.
- **Bugs**: Relacionados a problemas e falhas que precisam ser corrigidos.
- **Testes**: Itens que garantem que as funcionalidades foram testadas adequadamente, incluindo a escrita de testes BDD.

## Instalação

### Backend

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   cd nome-do-repositorio
****
