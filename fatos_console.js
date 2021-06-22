//Requisita número de fatos e retorna a respectiva informação, por meio do console. 
//Consulta a API por meio de require e tratamento da informação em JSON

//Inicialização da interface com o usuário
const readline = require('readline');

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.question('Qual a quantidade de fatos que deseja receber?', (answer) => {
  // TODO: Log the answer in a database

  //Requisição de dados da API
  var quantidade = answer;
  var url = "https://dog-facts-api.herokuapp.com/api/v1/resources/dogs?number=" + quantidade;

  //Importar o xmlhttprequest
  var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;

  var xhttp = new XMLHttpRequest();
  xhttp.open("GET", url, true);

  xhttp.onreadystatechange = function () {//Função a ser chamada quando a requisição retornar do servidor
    if (xhttp.readyState === 4 && xhttp.status === 200) {//Verifica se o retorno do servidor deu certo
      let resposta = JSON.parse(xhttp.responseText);
      let i = 0;
      for (i = 0; i < resposta.length; i++) {
        console.log("Fato" + (i + 1) + ": " + resposta[i].fact + "\n");
      }
      console.log("Fim do programa!");
    }
  }

  xhttp.send();//A execução do script CONTINUARÁ mesmo que a requisição não tenha retornado do servidor

  rl.close();
});