let dado=  {
nome: "Michael",
};
let dado2 = JSON.stringify(dado)+"\n"+JSON.stringify(dado);
//console.log(typeof(dado2)+"\n");
//console.log(dado2);
var str = "123456\n";
var str2 = "123456\n";
str = str.slice(0, -1);
console.log(str===str2);
console.log(str);
console.log(str2);
