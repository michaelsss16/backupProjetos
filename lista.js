//exemplo de utilização de listas em js
let lista = [1, 2, 3, 4, 5];
let emptylista = [];
emptylista = lista;
emptylista[emptylista.length]= 6;
var teste = lista.concat(emptylista);

console.log(teste);