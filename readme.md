# .NET Learning Ground

Este repositório contém uma aplicação .NET desenvolvida para estudo e aprofundamento em várias tecnologias e práticas modernas de desenvolvimento. O objetivo é criar um ambiente prático para aprender e demonstrar conhecimentos técnicos relevantes para o mercado.

## 💻 Tecnologias e Conceitos Abordados

### Implementado até o momento:

#### Testes Automatizados

- Testes unitários com xUnit e Moq
- Testes de integração com SQLite em memória
- Padrões AAA (Arrange-Act-Assert)
- Verificação de comportamento com Mocks

### Próximos tópicos:

- TDD (Test-Driven Development)
- Mensageria (RabbitMQ/Azure Service Bus)
- Cache com Redis
- Clean Architecture
- API RESTful completa

## 📋 Estrutura do Projeto

```
ProductManagement/
├── ProductManagement.API (Web API)
├── ProductManagement.Core (Regras de negócio)
├── ProductManagement.Infrastructure (Acesso a dados)
├── ProductManagement.Tests.Unit (Testes unitários)
└── ProductManagement.Tests.Integration (Testes de integração)
```

## 🧪 Testes Implementados

### Testes Unitários

- Testes de serviço com isolamento de dependências usando Moq
- Verificação de comportamento e resultados
- Cenários de sucesso e falha

### Testes de Integração

- Testes de repositório usando SQLite em memória
- Verificação de operações CRUD reais no banco de dados
- Isolamento entre execuções de teste

## 💻 Como Executar

Pré-requisitos

.NET 8.0 SDK ou superior
Visual Studio 2022, VS Code ou Rider

#### Passos

1. Clone o repositório

```
git clone https://github.com/seu-usuario/net-estudos.git
```

2. Restaure os pacotes

```
dotnet restore
```

3. Execute os testes

```
dotnet test
```

4. Execute a aplicação

```
cd ProductManagement.API
dotnet run
```

## 📚 Conceitos Aprendidos

### Testes Automatizados

Uso do padrão AAA (Arrange-Act-Assert)
Simulação de dependências com Moq
Verificação de comportamento com Verify
Configuração de banco de dados em memória para testes
Isolamento de testes

## 🗺️ Roadmap

### Fase 1: Testes ✅

- Configuração de testes unitários e de integração
- Implementação de exemplos básicos

### Fase 2: TDD 🔄

- Refatoração usando Test-Driven Development
- Implementação completa de funcionalidades guiada por testes

### Fase 3: Mensageria 📬

- Integração com sistema de mensageria
- Implementação de padrões pub/sub
- Processamento assíncrono

### Fase 4: Cache com Redis 💾

- Estratégias de cache
- Implementação de Redis para performance

### Fase 5: Refinamento da Arquitetura 🏗️

- Aplicação de Clean Architecture
- Separação clara de responsabilidades
- Implementação de padrões de projeto

## 📝 Notas de Aprendizado

Lições sobre Testes

Importância de usar um banco de dados separado para testes
Configuração adequada do contexto do Entity Framework para testes
Uso de SQLite em memória para testes rápidos e isolados
Tratamento adequado de recursos com IDisposable em testes

Dicas para Entrevistas

Demonstre compreensão sobre a importância de testes automatizados
Explique as diferenças entre testes unitários e de integração
Mostre como usar mocks para isolar dependências
Discuta como o TDD pode melhorar a qualidade do código

## 📄 Licença

Este projeto está sob a licença MIT.

Desenvolvido com ❤️ para aprendizado e aprimoramento técnico.
