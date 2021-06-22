//script que realiza consulta assíncrona a api web 
//utilizada pelo arquivo web_fatos_v1

function Pesquisar() {
    var valor = document.getElementById("valor").value;

    var url = ("https://dog-facts-api.herokuapp.com/api/v1/resources/dogs?number=" + valor);
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", url, true);

    xhttp.onreadystatechange = function () {//Função a ser chamada quando a requisição retornar do servidor
        if ((xhttp.readyState === 4) && (xhttp.status === 200)) {
            alert("Pesquisa realizada com sucesso!");

            //Construindo a mensagem de resposta
            let resposta = JSON.parse(xhttp.responseText);
            let i = 0;
            let mensagemConstrutor = "";
            for (i = 0; i < resposta.length; i++) {
                //mensagemConstrutor += ("Fato" + (i + 1) + ": " + resposta[i].fact + "<br>");
                mensagemConstrutor += `Fato ${i + 1}: ${resposta[i].fact}<br>`;
            }
            document.getElementById("mensagemResposta").innerHTML = mensagemConstrutor;
    }
    }
    xhttp.send();//A execução do script CONTINUARÁ mesmo que a requisição não tenha retornado do servidor
}//fim pesquisar

//definindo variáveis de elementos
var btn1 = document.getElementById("btn1");

//definindo eventListeners
btn1.addEventListener("click", Pesquisar);