# MiniCRM.RazorPages

Mini CRM de Atendimento Comercial desenvolvido com **ASP.NET Core Razor Pages**, **C#**, **Entity Framework Core**, **SQL Server LocalDB** e **Bootstrap**.

Este projeto foi criado como estudo prático e portfólio para vagas de **Desenvolvedor C# Júnior**. A proposta é mostrar uma aplicação web simples, organizada e funcional, sem arquitetura complexa ou bibliotecas desnecessárias.

## Status do Projeto

![Build](https://github.com/AndreLuizGimenez/MiniCRM.RazorPages/actions/workflows/dotnet.yml/badge.svg)

## Tecnologias Usadas

- C#
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap
- Visual Studio

## Funcionalidades

- Cadastro de usuário.
- Login e logout.
- Senha salva com hash usando `PasswordHasher`.
- Bloqueio de páginas internas para usuários não autenticados.
- Dashboard com indicadores comerciais.
- Cadastro, listagem, edição, detalhes e exclusão de clientes.
- Busca de clientes por nome ou e-mail.
- Status do cliente: Novo, Em negociação, Fechado e Perdido.
- Registro de atendimentos vinculados a clientes.
- Listagem, edição e exclusão de atendimentos.
- Tipos de atendimento: WhatsApp, Ligação, E-mail e Reunião.

## Pré-requisitos

Para rodar este projeto localmente, instale:

- Visual Studio 2022 ou superior
- .NET 8 SDK
- SQL Server LocalDB

O SQL Server LocalDB normalmente já vem junto com o Visual Studio quando a carga de trabalho de desenvolvimento ASP.NET/.NET está instalada.

## Como Executar no Visual Studio

1. Clone o repositório:

```powershell
git clone https://github.com/AndreLuizGimenez/MiniCRM.RazorPages.git
```

2. Entre na pasta do projeto:

```powershell
cd MiniCRM.RazorPages
```

3. Abra a solução no Visual Studio:

```text
MiniCRM.slnx
```

4. Abra o Package Manager Console:

```text
Tools > NuGet Package Manager > Package Manager Console
```

5. No Package Manager Console, selecione o projeto:

```text
MiniCRM.RazorPages
```

6. Execute o comando para criar o banco de dados:

```powershell
Update-Database
```

7. Pressione `F5` ou clique em `Run`.

8. Crie um usuário na tela de cadastro e acesse o sistema.

## Como Executar Pelo Terminal

Na raiz do repositório, execute:

```powershell
dotnet restore
dotnet tool restore
dotnet tool run dotnet-ef database update --project .\MiniCRM.RazorPages\MiniCRM.RazorPages.csproj --startup-project .\MiniCRM.RazorPages\MiniCRM.RazorPages.csproj
dotnet run --project .\MiniCRM.RazorPages\MiniCRM.RazorPages.csproj
```

Depois acesse no navegador a URL exibida no terminal, normalmente:

```text
http://localhost:5091
```

## Banco de Dados

O projeto usa SQL Server LocalDB.

A connection string está em:

```text
MiniCRM.RazorPages/appsettings.json
```

Connection string padrão:

```text
Server=(localdb)\mssqllocaldb;Database=MiniCRM_RazorPages;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
```

O banco criado se chama:

```text
MiniCRM_RazorPages
```

Tabelas principais:

- `Users`
- `Customers`
- `Attendances`
- `__EFMigrationsHistory`

## Testes no GitHub

Este projeto possui GitHub Actions configurado.

A cada `push` ou `pull request`, o GitHub executa:

```powershell
dotnet restore
dotnet build --no-restore
```

Importante: o GitHub Actions valida se o projeto compila, mas não abre a aplicação no navegador, porque este projeto usa SQL Server LocalDB e foi pensado para rodar localmente no Visual Studio.

## Prints da Aplicação

Espaço reservado para adicionar imagens depois:

```text
docs/images/login.png
docs/images/dashboard.png
docs/images/clientes.png
docs/images/detalhes-cliente.png
docs/images/atendimento.png
```

Sugestão de prints:

- Tela de login
- Dashboard
- Lista de clientes
- Cadastro de cliente
- Detalhes do cliente
- Cadastro de atendimento

## Estrutura do Projeto

```text
MiniCRM.RazorPages/
├── Data/
│   ├── Migrations/
│   └── MiniCrmDbContext.cs
├── Models/
│   ├── ApplicationUser.cs
│   ├── Attendance.cs
│   ├── AttendanceType.cs
│   ├── Customer.cs
│   └── CustomerStatus.cs
├── Pages/
│   ├── Account/
│   ├── Attendances/
│   ├── Customers/
│   ├── Dashboard/
│   └── Shared/
├── wwwroot/
├── Program.cs
└── appsettings.json
```

## Objetivo de Aprendizado

Este projeto foi criado para praticar:

- Razor Pages.
- PageModels.
- Validação com Data Annotations.
- Entity Framework Core.
- Migrations.
- SQL Server LocalDB.
- Relacionamento entre entidades.
- Autenticação simples com cookies.
- Hash de senha.
- Organização básica de uma aplicação ASP.NET Core.

## Observação

Este projeto não usa ASP.NET Core Identity completo de propósito. A autenticação foi feita de forma simples com cookies e `PasswordHasher`, para facilitar o entendimento de quem está aprendendo C# e ASP.NET Core.

Para um sistema real em produção, o recomendado seria estudar e usar ASP.NET Core Identity.
