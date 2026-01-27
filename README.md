📘 README DO **BACK-END** (API C# / .NET)
Arquivo: `README.md` no repositório do **IteraDisc (Back-end)**

```md
# IteraDisc – Back-end (API)

API REST desenvolvida em C# (.NET) responsável por toda a lógica de negócio da loja virtual de discos IteraDisc.
Ela gerencia produtos, vendas e itens de venda, fornecendo dados para o front-end através de requisições HTTP.

Este projeto representa a camada de servidor da aplicação.

---

## 🚀 Tecnologias Utilizadas

- C#
- ASP.NET Core
- .NET 6+
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)

---

## 🧱 Arquitetura

O projeto utiliza arquitetura em camadas:

- **Domínio** → Entidades do sistema  
- **Repositório** → Acesso ao banco de dados  
- **Serviços** → Regras de negócio  
- **Controllers** → Endpoints da API  
- **Infraestrutura** → Contexto de banco e configurações  

Isso garante:
- Organização
- Baixo acoplamento
- Facilidade de manutenção
- Escalabilidade

---

## 📁 Estrutura de Pastas

```

IteraDisc
│
├── Dominio
│   └── Entidades
│       ├── Produto.cs
│       ├── Venda.cs
│       └── ItemVenda.cs
│
├── Repositorio
│   ├── Interfaces
│   └── Implementacoes
│
├── Servicos
│   ├── Interfaces
│   └── Implementacoes
│
├── Aplicacao
│   └── Controllers
│
└── Infraestrutura
└── ContextoBanco

````

---

## ⚙️ Pré-requisitos

- Windows 10 ou superior  
- .NET SDK 6.0 ou superior  
- Visual Studio 2022  
- SQL Server (LocalDB, Express ou completo)

---

## ▶️ Como Executar o Projeto

1. Clone o repositório:
```bash
git clone <url-do-repositorio-backend>
````

2. Abra a solução no Visual Studio 2022.

3. Configure a string de conexão no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=IteraDiscDb;Trusted_Connection=True;"
}
```

4. Execute o projeto pelo Visual Studio (F5).

5. Acesse o Swagger no navegador:

```
https://localhost:xxxx/swagger
```

---

## 🌐 Endpoints Principais

### Produtos

| Método | Endpoint           | Descrição            |
| ------ | ------------------ | -------------------- |
| GET    | /api/produtos      | Lista todos produtos |
| GET    | /api/produtos/{id} | Busca produto por ID |
| POST   | /api/produtos      | Cria novo produto    |
| PUT    | /api/produtos/{id} | Atualiza produto     |
| DELETE | /api/produtos/{id} | Remove produto       |

---

### Vendas

| Método | Endpoint    | Descrição      |
| ------ | ----------- | -------------- |
| POST   | /api/vendas | Cria uma venda |
| GET    | /api/vendas | Lista vendas   |

---

## 🗄️ Modelo de Dados Simplificado

Entidades principais:

* **Produto**

  * ProdutoId
  * Nome
  * Descricao
  * Preco

* **Venda**

  * VendaId
  * Data
  * Lista<ItemVenda>

* **ItemVenda**

  * ItemVendaId
  * ProdutoId
  * Vendido (bool)
  * Descartado (bool)

Relacionamento:

```
Produto 1 ─── * ItemVenda
Venda    1 ─── * ItemVenda
```

---

## 📌 Regras Importantes do Sistema

* Um ItemVenda só pode gerar venda se:

  * Vendido = false
  * Descartado = false
* Itens descartados não devem ser considerados na criação de vendas.
* A validação de regras ocorre na camada de Serviços.

---

## 🧪 Testes e Documentação

* Toda a API é documentada automaticamente pelo Swagger.
* Use o Swagger para:

  * Testar endpoints
  * Validar requisições
  * Conferir respostas

---

## 📌 Observações Finais

Este projeto representa a base lógica da aplicação IteraDisc.
Ele foi desenvolvido com foco em organização, boas práticas e estrutura profissional de uma API REST real.

```

