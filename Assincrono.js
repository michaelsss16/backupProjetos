//exemplo de requisição assíncrona de dados por meio de console
var url = "https://dicasdejavascript.com.br/exemplo.txt";//url para obtenção dos dados 

var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
var xhttp = new XMLHttpRequest();
xhttp.open("GET", url, true);//true indica requisição assíncrona 

xhttp.onreadystatechange = function(){//Função a ser chamada quando a requisição retornar do servidor
    if ( xhttp.readyState == 4 && xhttp.status == 200 ) {//Verifica se o retorno do servidor deu certo
        console.log(xhttp.responseText);
    }
}

xhttp.send();//A execução do script CONTINUARÁ mesmo que a requisição não tenha retornado do servidor