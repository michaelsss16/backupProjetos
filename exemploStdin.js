//exemplo de leitura de dado pelo console
const readline = require('readline');

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.question('Qual a quantidade de fatos que deseja receber?', (answer) => {
  // TODO: Log the answer in a database
  console.log(`Resposta:  ${answer}`);

  rl.close();
});
