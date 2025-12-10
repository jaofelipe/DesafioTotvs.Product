# Descrição do Projeto

Este é o frontend do desafio técnico de cadastro de produtos, desenvolvido em Angular 19 Standalone, utilizando:

✔ Standalone Components (sem módulos)

✔ Lazy loading com rotas standalone

✔ Arquitetura limpa organizada

✔ HttpClient com injeção automática via providers

✔ Formulários reativos (Reactive Forms)

✔ Tema claro + tema escuro (Dark Mode)

✔ Design system em CSS com variáveis

✔ Layout moderno e responsivo

A aplicação se comunica com a API .NET 8 (DDD + Clean Architecture) para realizar operações CRUD de produtos.

## Arquitetura do Projeto

```bash
src/
  main.ts                → bootstrapApplication + providers
  environments/
    environment.ts
    environment.prod.ts

  app/
    app.component.ts     → componente raiz standalone
    app.component.html
    app.routes.ts        → rotas principais

    models/
        product.model.ts
    services/
        product.service.ts

    components/products/
      products.routes.ts
      list/
        product-list.component.ts
        product-list.component.html
      form/
        product-form.component.ts
        product-form.component.html

styles.css               → design system + tema escuro
```

## Padrões e boas práticas aplicadas

✔ Componentes 100% standalone

✔ Uso de DI via provideHttpClient()

✔ Lazy loading sem NgModules

✔ CSS global com variáveis de tema

✔ Responsividade e foco em UX

## Tema Claro + Tema Escuro

Toda a aplicação usa um design system baseado em variáveis CSS:

```
:root → tema claro
.dark-mode → tema escuro
```

O botão de alternância entre os temas está no AppComponent:

```bash
toggleTheme() {
  document.body.classList.toggle('dark-mode');
}
```

## Requisitos

Node.js 18 ou superior

Angular CLI 17+

Backend em execução (API .NET 8):

HTTP: ``` http://localhost:5000 ```

ou HTTPS: ``` https://localhost:5001 ```

Configuração do ambiente (arquivo environment.ts):
```
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
```

▶️ Como executar o projeto
1️⃣ Instale as dependências
```bash
npm install
```
2️⃣ Inicie o servidor de desenvolvimento
```bash
ng serve
```

O frontend estará disponível em:
```bash
http://localhost:4200
```

🏗️ Build para produção
```bash
ng build
```

Os artefatos de produção irão para:
```bash
dist/desafio-app/
```

## Funcionalidades

✔ Listar produtos com tabela responsiva

✔ Criar novo produto

✔ Editar produto

✔ Excluir produto com confirmação

✔ Campos validados com Reactive Forms

✔ Mensagens amigáveis de erro

✔ Formatação brasileira de moeda

## Diferenciais Técnicos

✔ Arquitetura standalone moderna

✔ Lazy loading real sem NgModules

✔ Design system com tema escuro/claro

✔ Componentes desacoplados

✔ Frontend alinhado às novas recomendações do Angular (2024–2025)
