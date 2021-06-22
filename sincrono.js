//Exemplo de script que requisita dados de uma api erb de modo síncrono 

var url = "https://dicasdejavascript.com.br/exemplo.txt";//Sua URL
var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
var xhttp = new XMLHttpRequest();
xhttp.open("GET", url, false);

xhttp.send();//A execução do script pára aqui até a requisição retornar do servidor

console.log(xhttp.responseText);