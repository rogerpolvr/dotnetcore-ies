# IES

IES é uma web app desenvolvida como estudo em conjunto com algumas literaturas da [Casa do Código](https://www.casadocodigo.com.br/).

## :computer: Tecnologias
* .NetCore 3.1
* Entity Framework Core
* SQLServer Express

## :scroll: Comandos
* Download da imagem SQLServer para Docker/Linux
```console
docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04
```

* Criar uma instancia do SQLServer no Docker com o nome "IES_database" e senha "12345a!".
```console
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=12345a!" -p 1433:1433 --name IES_database -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04
 ```

## :page_facing_up: Referências
:book: **Livro**: [ASP.NET Core MVC](https://www.casadocodigo.com.br/products/livro-aspnet-core-mvc) - Aplicações modernas em conjunto com o Entity Framework.

 :bust_in_silhouette: **Autor**: Everton Coimbra de Araújo.

![ASP.NET Core MVC](https://cdn.shopify.com/s/files/1/0155/7645/products/8ROjv5OVfks54j7FvDehRuYHax0-et96hKHyplURGe4_large.jpg?v=1518105341)
