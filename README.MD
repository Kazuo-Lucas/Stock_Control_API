# 📦 Controle de Estoque API

API REST simples desenvolvida com ASP.NET Core para simular o controle de produtos em estoque.

## 🚀 Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Swagger (OpenAPI)
- Entity Framework Core
- SQLite

## 📁 Estrutura Atual do Projeto

- `Models/Produto.cs`: Classe que representa o modelo de dados `Produto`.
- `Controllers/ProdutosController.cs`: Controller que expõe os endpoints da API.
- `Data/AppDbContext.cs`: Classe responsável pela configuração do contexto do banco de dados (Entity Framework Core).
- `Program.cs`: Ponto de entrada da aplicação, configurando o servidor e o Swagger.

## 🔧 Endpoints Implementadas

- [x] **GET /api/produtos** → Retorna todos os produtos
- [x] **GET /api/produtos/{id}** → Retorna um produto por ID
- [x] **POST /api/produtos** → Adiciona um novo produto
- [x] **POST /api/produtos/lote** → Adiciona vários novos produtos
- [x] **PUT /api/produtos/{id}** → Atualiza um produto existente
- [x] **DELETE /api/produtos/{id}** → Remove um produto

## 📓 Observações

- Os dados agora são persistidos em um banco SQLite, garantindo que não sejam perdidos após reiniciar a aplicação.
- A documentação Swagger é gerada automaticamente e está disponível em:  
  `https://localhost:{porta}/swagger`

## 🧪 Como Executar

1. Clone o repositório:
    ```bash
    git clone https://github.com/Kazuo-Lucas/Stock_Control_API.git

2. Execute o projeto:
    dotnet run

3. Acesse o Swagger no navegador:
    https://localhost:{porta}/swagger
