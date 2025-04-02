# Lead Management Api
## Descrição
Esta api Restful foi desenvolvida em C# com .Net Core 6 e esta nos permite gerenciar leads para uma determinada empresa. 
Utilizamos o ORM Entity Framework e como banco de dados o Sql Server.  

## Pré-requisitos
Antes de iniciar confira se tem instalado os seguintes itens:
- **.Net Sdk (6.0)**
- **Sql Server**
- **Visual Studio Community 2022**
- **Ferramenta de gerenciamento de banco de dados (ex: Sql Server Management studio)**
- **Git (Para realizar a clonagem do repositório)**

## Instalação
1. Clone este repositório com o seguinte comando: git clone https://github.com/Mhellsing/LeadManagementApi.git
2. Configure as variáveis de ambiente no arquivo appsettings.json conforme o exemplo a seguir:
   ![image](https://github.com/user-attachments/assets/f14fa201-5a9e-4a3f-8625-908e9ec3d76d)

## Iniciar o servidor
1. Clicando na seta apontando para baixo Selecione: "IIS Express", para executar o projeto basta 
clicar no ícone da seta verde (no ícone totalmente preenchido de cor verde) conforme a imagem abaixo.
  
![image](https://github.com/user-attachments/assets/e856f03f-d580-4bd7-b5a9-d0a669c733ec)

2. Esta api será disponibilizada no endereço: https://localhost:44360

### Endpoints Disponíveis

| Método | Endpoint                            | Descrição                                        |
|--------|-------------------------------------|--------------------------------------------------|
| GET    | `/Leads/GetLeadsWithStatusNew`      | Retorna todas as leads com status: New           |
| GET    | `/Leads/GetLeadsWithStatusAccepted` | Retorna todas as leads com status: Accepted      |
| POST   | `/Leads/AcceptLead`                 | Aceita uma lead                                  |
| POST   | `/Leads/DeclineLead`                | Recusa uma lead                                  |
### Exemplo de response GET /Leads/GetLeadsWithStatusNew & /Leads/GetLeadsWithStatusAccepted
{  
  "message": ,  
  "statusCode": ,  
  "leads": [  ]  
}

### Exemplo de request POST /Leads/AcceptLead & POST /Leads/DeclineLead
{  
  "id": 0,  
  "firstName": "string",  
  "lastName": "string",  
  "dateCreated": "datetime",  
  "suburb": "string",  
  "category": "string",  
  "description": "string",  
  "price": 0,  
  "status": 1,  
  "email": "string",  
  "phoneNumber": "string"  
}

### Estrutura de Pastas
- LeadManagementApi
   - Controllers        (Controladores da API)
   - Enums              (Enums para status das leads)
   - Extensions         (Extensão da interface IServiceCollection para registro de serviços e injeção de dependência)
   - Messages           (Armazenar mensagens utilizadas no código)
   - Models             (Modelos de dados)
   - Repository         (Configuração do DbContext e da camada de dados)
   - Services           (Lógica de negócios)
   - appsettings.json   (Configurações da aplicação)
   - Program.cs         (Ponto de entrada da aplicação)

### Tecnologias Utilizadas
- C#
- .NET Core 6
- Visual Studio Community 2022
- ORM: Entity Framework Core
- SQL Server
- Swagger para documentação da api
  Após iniciar a api você pode acessar a documentação gerada pelo swagger acessando o link: https://localhost:44360/swagger/v1/swagger.json

### Scripts Úteis
1. Para alimentar a base de dados primeiramente é necessário executar o script de criação de tabelas conforme o exemplo abaixo:  
**CREATE TABLE Leads (  
 Id INT IDENTITY(1,1) PRIMARY KEY,  
 FirstName NVARCHAR(100) NOT NULL,  
 LastName NVARCHAR(100) NOT NULL,  
 Suburb NVARCHAR(100) NULL,  
 Category NVARCHAR(100) NULL,  
 Description NVARCHAR(500) NULL,  
 Price DECIMAL(18,2) NOT NULL,  
 Status INT NOT NULL,  
 Email NVARCHAR(100) NULL,  
 PhoneNumber NVARCHAR(20) NULL,  
 DateCreated DATETIME NOT NULL  as
);**
2. Para popular esta tabela após sua criação basta utilizar o seguinte script:  
**INSERT INTO Leads (FirstName, LastName, Suburb, Category, Description, Price, Status, Email, PhoneNumber, DateCreated)
VALUES(insira aqui os valores referentes a cada atributo os separando por vírgula(,) lembrando de respeitar o tipo deste atributo e as sintaxes do sql server);**
