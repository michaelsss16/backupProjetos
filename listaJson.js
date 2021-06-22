var lista = [];
lista.push({
nome: "michael",
idade:"23",
});
lista.push({nome: "jonathan", idade:"20"});

let jsonl = "";
lista.forEach(function (objeto){
jsonl+= (JSON.stringify(objeto)+"\n");
});
console.log(jsonl);
console.log("fim\ndo\nprograma\n");
