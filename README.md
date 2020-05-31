Fiz o banco de dados em SQL Server, está aqui no Git um backup do mesmo, favor subir este backup para executar os testes.

Fiz o BackEnd usando .Net Core 3.2 em uma arquitetura de API REST usando Swagger para documentar a mesma e como ORM usei o Dapper, pois o mesmo é muito mais rápido e de fácil implementação.

O FrontEnd fiz usando arquitetura MVC tambem em .Net Core 3.2 e usei a estratégia de resiliência "Retry" usando o Polly na camada de controller, ou seja, mesmo que você esqueça de rodar o projeto de API, você terá 30 segundos para fazer isso, antes de gerar uma excessão para o front. Fiz as telas que considero mais importante para o teste "Pedido" e "Fechar Pedido" na tela de "Pedido" você pode criar um novo pedido e lançar os lanches ou escolher um pedido já aberto e lançar mais lanches para o mesmo. Já na tela "Fechar Pedido" você escolhe o pedido aberto, será listado todos os itens de cada lanche, depois você pode aplicar o desconto, onde o sistema irá fazer os cálculos necessários e recarregar a lista dos itens com os valores corrigidos, depois é só clicar no botão fechar pedido.

Fiz o Test Unitário também em .Net Core.

Não fiz a virtualização em Docker pois não sei fazer, pois em todos os projetos que precisei usar Docker foi outra equipe que criou, mas, caso eu venha a fazer parte da equipe Mutant e seja necessário implementar Docker, eu não tenho problema nenhum em aprender e diciminar o conhecimento para a equipe.
