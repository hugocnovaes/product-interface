\# Projeto med-tc



Este é um projeto full-stack com um frontend em Angular, um backend de API RESTful em ASP.NET e um banco de dados MS SQL Server executado em um contêiner Docker.



\## Pré-requisitos



Antes de começar, certifique-se de ter o seguinte software instalado em sua máquina:



\* \[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

\* \[Node.js e npm](https://nodejs.org/) (versão 18 ou superior)

\* \[Angular CLI](https://angular.io/cli)

\* \[Docker Desktop](https://www.docker.com/products/docker-desktop)

\* \[SQL Server Management Studio](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) (Opcional, para gerenciar o banco de dados)



\## 🚀 Começando



Siga estas instruções para configurar e executar o projeto em seu ambiente local.



\### 1. Clone o Repositório



```bash

git clone https://github.com/hugocnovaes/product-interface.git

cd \[NOME-DA-PASTA-CRIADA-NA-SUA-MAQUINA]

```



\### 2. Configuração do Banco de Dados (Backend)



O banco de dados MS SQL Server é executado dentro de um contêiner Docker.



\*\*a. Inicie o Contêiner do Docker:\*\*



Na raiz do projeto, execute o seguinte comando para criar e iniciar o contêiner do SQL Server.



```bash

docker-compose up -d

```



O contêiner pode levar alguns minutos para estar totalmente pronto para aceitar conexões.



\*\*b. Restaure o Banco de Dados:\*\*



O backup do banco de dados (`medTC.bak`) está localizado na pasta `/database`. Para restaurá-lo, primeiro copie o arquivo para dentro do contêiner e, em seguida, execute o comando de restauração.



```bash

\# Copie o arquivo .bak para o contêiner

docker cp database/medTC.bak Dev\_SQLServer:/var/opt/mssql/data/medTC.bak



\# Execute o comando de restauração via sqlcmd

docker exec -it Dev\_SQLServer /opt/mssql-tools/bin/sqlcmd \\

&nbsp;  -S localhost -U SA -P "Admin@1234" \\

&nbsp;  -Q "RESTORE DATABASE \[medTC] FROM DISK = N'/var/opt/mssql/data/medTC.bak' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5"

```



\### 3. Configuração do Backend (ASP.NET)



\*\*a. Navegue até a pasta da API:\*\*



```bash

cd backend/medTC.ZAPI

```



\*\*b. Restaure as dependências do .NET:\*\*



```bash

dotnet restore

```



\*\*c. Execute a API:\*\*



```bash

dotnet run --launch-profile http

```



A API estará em execução em `http://localhost:5247`. Você pode acessar a documentação do Swagger em `http://localhost:5247/swagger`.



\### 4. Configuração do Frontend (Angular)



\*\*a. Navegue até a pasta do frontend:\*\*



```bash

\# A partir da raiz do projeto

cd frontend/med-tc

```



\*\*b. Crie o arquivo de ambiente:\*\*



Crie uma cópia do arquivo `environment.ts.example` e renomeie-a para `environment.ts` dentro de `src/environments/`.



\* \*\*`src/environments/environment.ts`\*\*:

&nbsp;   ```typescript

&nbsp;   export const environment = {

&nbsp;     production: false,

&nbsp;     apiUrl: 'http://localhost:5247/api'

&nbsp;   };

&nbsp;   ```



\*\*c. Instale as dependências do npm:\*\*



```bash

npm install

```



\*\*d. Execute a aplicação Angular:\*\*



```bash

ng serve

```



A aplicação estará disponível em `http://localhost:4200/`.



\## ✅ Uso



Após seguir todos os passos, a aplicação estará totalmente funcional:

\* Frontend Angular: `http://localhost:4200/`

\* Backend ASP.NET API: `http://localhost:5247/`

\* Swagger UI: `http://localhost:5247/swagger`

