![rpgfightapi2](https://user-images.githubusercontent.com/103686624/235682019-99bcf7e7-04cd-486c-be4d-5ee77f1232c3.jpg)

## Requerimentos
- Instalar [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Instalar [Sql Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- Usando **cmd.exe**, 
- -Usando **cmd.exe**, acesse a pasta da aplicação usadno `cd "pasta\da\aplicação"`, use o comando `dotnet restore` para instalar as dependências, 
`dotnet ef database update` e `dotnet watch run` para rodar, será aberta uma aba do navagedor no Swagger, onde você pode testar a aplicação.
## Usando a API
### Auth
Na parte de autenticação, você tem que criar um usuário e depois logar usando sua senha, será retornado um Token. Com o token em mãos, clique em [Authorize]
e insira `bearer {token}`, como mostrado na foto.
<br>
![bearer](https://user-images.githubusercontent.com/103686624/235690086-c5269f13-4967-49b9-abb3-e5fc78b173e1.jpg)
### DungeonMaster
Nessa seção, é possível ver as informações sobre classes, armas, skills, personagens, armaduras e efeitos. 
### Wardrobe
Aqui é onde você pode criar, customizar, edita, deletar e ver seu personagem.
### Guild
Aqui você pode, assim como com seu personagem, criar e editar um inimigo ou pode selecionar algum existente.
### Fight
Por fim, quando você estiver com um personagem e inimigo pronto, você pode criar uma luta entre eles.
## Sobre
Esse é um projeto que foi criado com o fim de testar minhas habilidades em C#, na plataforma .NET, Asp.Net, EntityFramework e CRUD. A ideia foi criar um jogo
onde você colocar dois personagens para lutar e ver o resultado, onde para gerar resultados diferentes, você muda atributos dos lutadores, troca arma, habilidades, etc. 
