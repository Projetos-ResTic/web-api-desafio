# Web API Pedidos

Neste projeto, aplicamos o conteúdo da Unidade 8 para desenvolver uma API completa utilizando o **Entity Framework**. O objetivo é transformar o modelo de banco de dados criado anteriormente em uma API funcional, consolidando o conhecimento em modelagem de dados e desenvolvimento de APIs em C#.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 8
- **ORM**: Entity Framework Core
- **Banco de Dados**: SQL Server

## Objetivo do Projeto

O projeto visa desenvolver uma API funcional a partir de um modelo de banco de dados existente, permitindo operações CRUD (Create, Read, Update, Delete) nas entidades definidas. Este desafio é ideal para consolidar o conhecimento em **modelagem de dados**, **mapeamento de entidades** e **configuração de relacionamentos** no **Entity Framework**.

## Configuração do Ambiente

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/Projetos-ResTic/web-api-desafio.git
2. Navegue até a pasta do projeto
   ```bash
     cd web-api-desafio

3. **Instale as dependências**
   ```bash
      dotnet restore

4. **Configuração de Banco de Dados**
   ```bash
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;"
     }
   }

5. **Aplicar Migrações: Execute o comando abaixo para criar as tabelas no banco de dados**
```bash
dotnet ef database update
