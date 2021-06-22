
//A string apresenta uma lista de objetos referentes a informações pessoais de uma pessoa //exemplo simples de tratamento e chamada de dados  contidos em uma string no formato json

//let clienteTexto = '{"nome":"Angelo", "idade":86, "cidade":"São Paulo", "estado":"SP"}';

//Exemplo de tratamento json 
//texto de entrada em uma lista de objetos json
let clienteTexto2 = '[{"nome":"Angelo", "idade":86, "cidade":"São Paulo", "estado":"SP"}, {"nome":"Michael", "idade":23, "cidade":"Minas Gerais", "estado":"MG"}]';
let cliente = JSON.parse(clienteTexto2);
console.log(cliente[1].nome);
