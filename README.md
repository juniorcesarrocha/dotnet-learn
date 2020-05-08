# dotnetcore-learn
<p style="text-align: justify">
Projeto de estudos, onde são aplicados diversos recursos e padrões de desenvolvimento de software para .net core. O projeto é baseado em uma aplicação web api.
</p>
 
<p style="text-align: justify">
O projeto tem como objetivo de regra de negócio controlar o estoque de produtos.
</p>
<p style="text-align: justify">
Cada produto possui uma categoria e uma categoria pode conter diversos produtos. Para controlar a quantidade de um determinado produto em estoque, são contabilizados suas entradas e saídas de estoque do mesmo.
</p>
<p style="text-align: justify">
Foram criados diversos projetos cada qual com seu objetivo de aprendizado e sempre mantendo o mesmo domínio de negócio, conforme descrito anteriormente. 
Cada projeto segue uma ordem incremental, de modo que se consiga acompanhar a evolução de cada projeto separadamente e assim identificar de forma fácil os recursos utilizados para uma determinada funcionalidade. Os projetos utilizam .net core 3.1.
</p>
<p style="text-align: justify">
Segue abaixo a descrição de cada um dos projetos desenvolvidos até o momento:
</p>


- **01 - EntityFramework:** <p style="text-align: justify">Este projeto tem como objetivo aplicar o Entity Framework Core. Nele são criadas as entidades de domínio, modelos para gerar as tabelas no banco de dados SQLite. Também é neste projeto que as regras de domínio do negócio são criadas. Como mapeamento das entidades e exposição à API é utilizado o pacote do AutoMapper para que possa fornecer uma forma customizada de exposição dos dados e assim, não expor a entidade de domínio.
</p>

- **02 - Validation:** <p style="text-align: justify">Este projeto tem como objetivo customizar a resposta da API, onde é informado se a requisição obteve sucesso ou não. Além disso, para aplicar validações de entrada de dados, foi utilizado o pacote FluentValidation. Desta forma, as validações são aplicadas, antes de fazer alguma operação como inclusão, alteração ou exclusão de algum registro. Caso haja alguma falha na validação, uma mensagem é retornada como resposta da requisição.
</p>

- **03 - Identity:** <p style="text-align: justify">Este projeto tem como objetivo criar e autenticar usuários para a aplicação usando o recurso Identity. Neste projeto é criada uma base de dados separada para armazenar os usuários da aplicação.
</p>

- **04 - Security:** <p style="text-align: justify">Este projeto tem como objetivo aplicar autorizar o acesso às APIs. Quando o usuário realiza sua autenticação com sucesso, ele recebe um token de acesso para que somente desta forma, ele consiga fazer requisições de consumo às APIs. Foram aplicadas em algumas APIs, políticas de acesso, onde que somente o usuário autenticado com perfil de **Administrador** e que possui uma determinada permissão conseguirá utilizar o recurso.
</p>

- **05 MediatR:** <p style="text-align: justify">Este projeto tem como objetivo utilizar o pacote MediatR. Para isto, quando houver uma saída de estoque do produto e a quantidade do produto atual for menor ou igual a quantidade mínima definida em estoque.
É enviada uma notificação por e-mail para que os responsáveis possam saber que um produto está com o estoque baixo.
</p>
