O projeto é uma melhoria do projeto Biblioteca, onde irei desenvolver funcionalidades utilzando o ASP.NET Core e também o Entity Framework.
Funcionalides do projeto:

📚 Cadastro, consulta e remoção de livros; 

👤 Cadastro de usuários; 

📅 Registro de empréstimos e devoluções com validação de datas; 

⚠️ Notificações sobre atrasos ou devoluções em dia.

Além das funcionalidades básicas, também planejo implementar algumas melhorias e validações adicionais, desafiando ainda mais minhas habilidades.

## 🔄 API de Sincronização

O projeto expõe um endpoint especial para sincronização de livros com sistemas externos:

- **Endpoint:** `GET /api/books/sync`
- **Autenticação:** API Key (via header `X-Api-Key`)
- **Resposta:** Lista de livros para sincronização

### Configuração

1. Copie `appsettings.Example.json` para `appsettings.Development.json`
2. Configure a chave de API em `SyncApiKey`
3. Este arquivo está no `.gitignore` e não será commitado

**Importante:**
- O arquivo `appsettings.Development.json` contém secrets e está excluído do controle de versão
- Para produção, use variáveis de ambiente ou Azure Key Vault
