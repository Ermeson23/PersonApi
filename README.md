# Desenvolvimento de uma API REST com C#

## 🎯 Objetivo
Construir uma API REST simples utilizando C# e .NET, com foco em persistência de dados usando Entity Framework Core e SQLite.

## 🧰 Tecnologias e Ferramentas Utilizadas
| Tecnologia                             | Finalidade                                                        |
| -------------------------------------- | ----------------------------------------------------------------- |
| **C# (.NET 9)**                        | Desenvolvimento da aplicação Web API                              |
| **Entity Framework Core**              | ORM para mapeamento objeto-relacional                             |
| **Managment Entity Framework**         | Interface CLI para gerenciamento do EF Core (migrações, DB, etc.) |
| `Microsoft.EntityFrameworkCore`        | Núcleo do EF Core                                                 |
| `Microsoft.EntityFrameworkCore.Sqlite` | Provedor SQLite para persistência local                           |
| `Microsoft.EntityFrameworkCore.Design` | Ferramentas para scaffolding e migrações                          |
| **Git**                                | Controle de versão do projeto                                     |
| **Swagger**                            | Geração automática de documentação da API                         |

## ⚙️ Configuração do Ambiente
### Pré-requisitos:
- .NET 9 SDK
- Git instalado
- SQLite (Útil para a visualização direta do banco - opcional)

## 🚀 Como Executar

- Navegue para um repositório de sua preferência:
  ``` cd my_repository ```
- Clone o repositório com este comando: ``` https://github.com/PersonApi.git ```
- Navegue para o repositório clonado: ``` cd PersonApi ```
- Execute a aplicação: ``` dotnet run ```
- Acesse a documentação da API: ``` https://localhost:<porta>/swagger ```
