# MiniCRM.RazorPages

Mini CRM de Atendimento Comercial criado com ASP.NET Core Razor Pages, C#, Entity Framework Core, SQL Server LocalDB e Bootstrap.

O objetivo do projeto é servir como estudo prático e portfólio para vagas de Desenvolvedor C# Júnior, mantendo uma estrutura simples, clara e próxima do uso comum em projetos .NET.

## Tecnologias usadas

- C#
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap
- Visual Studio

## Funcionalidades

- Cadastro, login e logout de usuário.
- Senha salva com hash usando `PasswordHasher`.
- Bloqueio de páginas internas para usuários não autenticados.
- Dashboard com totais por status de cliente.
- CRUD completo de clientes.
- Busca de clientes por nome ou e-mail.
- Status do cliente: Novo, Em negociação, Fechado e Perdido.
- Registro de atendimentos vinculados a clientes.
- CRUD de atendimentos.
- Tipos de atendimento: WhatsApp, Ligação, E-mail e Reunião.

## Como executar

1. Abra a solução `MiniCRM.slnx` no Visual Studio.
2. Confirme a connection string em `MiniCRM.RazorPages/appsettings.json`.
3. No Package Manager Console, selecione o projeto `MiniCRM.RazorPages`.
4. Execute:

```powershell
Update-Database
```

5. Rode o projeto pelo Visual Studio.
6. Crie um usuário na tela de cadastro e acesse o sistema.

Também é possível executar via terminal:

```powershell
dotnet tool restore
dotnet tool run dotnet-ef database update --project .\MiniCRM.RazorPages\MiniCRM.RazorPages.csproj --startup-project .\MiniCRM.RazorPages\MiniCRM.RazorPages.csproj
dotnet run --project .\MiniCRM.RazorPages\MiniCRM.RazorPages.csproj
```

## Prints da aplicação

Adicione aqui os prints depois de rodar o projeto:

- Tela de login
- Dashboard
- Lista de clientes
- Detalhes do cliente
- Cadastro de atendimento

```text
docs/images/login.png
docs/images/dashboard.png
docs/images/clientes.png
docs/images/detalhes-cliente.png
docs/images/atendimento.png
```

## Objetivo de aprendizado

Este projeto foi criado para praticar os fundamentos de uma aplicação web em C#:

- Criação de páginas Razor Pages.
- Uso de PageModels.
- Validação com Data Annotations.
- Persistência com Entity Framework Core.
- Relacionamento entre entidades.
- Migrations.
- Autenticação simples com cookies.
- Organização básica de um projeto ASP.NET Core.

