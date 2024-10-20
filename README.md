## Movies Web Api 

Uma web API sobre Filmes         

## Descrição          

Uma API onde você pode cadastrar filmes e usuários, toda a aplicação foi criada utilizando <br>
-> **.Net** <- juntamente com -> **Dapper** <- como ORM

🚧 No momento apenas tem a aplicação para a manipulação dos usuários, mas já irei trabalhar nos filmes 🚧

------------------------

## Tecnologias                                

Status: Obrigatório

| Dia | Descriçao | tecnologias |
|:---:|---------|:-----------:|
|  20/10  |Projeto iniciado| ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)  ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MySQL](https://img.shields.io/badge/mysql-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white) |

------------------------

## ⚙ Instalação   

Antes de começar, certifique-se de ter os seguintes requisitos instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- [MySQL](https://dev.mysql.com/downloads/) (se estiver utilizando um banco de dados MySQL)
- [Git](https://git-scm.com/) (para clonar o repositório)

1. **Clone o repositório:**
   Clone o projeto para o seu ambiente local utilizando o comando abaixo:

    ```bash
    git clone https://github.com/ItLrb/MoviesWebApi.git
    ```
2. **Entre no diretório do projeto:**

    ```bash
    cd MoviesWebApi
    ```
3. **Instale as dependências:**
  No diretório do projeto, execute o seguinte comando para restaurar as dependências do .NET:

    ```bash
    dotnet restore
    ```
4. **Configuração do banco de dados (Opcional, se estiver utilizando MySQL):**
  Se você estiver utilizando MySQL, edite o arquivo appsettings.json para incluir as informações de conexão com seu banco de dados:
    ```bash
    "ConnectionStrings": {
      "DefaultConnection": "server=localhost;user=root;database=UsersDB;password=root;"
    }
    ```

------------------------

### 📦 Executando a API

  ```bash
  dotnet run
  ```

A API estará disponível em http://localhost:5000 por padrão. Se estiver usando o Swagger, acesse http://localhost:5000/swagger para visualizar e interagir com a API.
