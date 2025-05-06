//string
let str1="i am string"
console.log(typeof str1);
//directly we can give the value or store in an vraible ask for that variable type
console.log(typeof "kl");


//number---both integers and floating are numbers in js
let num=90;
let nun1=98.980;
console.log(typeof num);
console.log(typeof nun1);


//boolean
let bool=true;
let bool2=0;              //0,1 are numbers and not boolean like other languages
console.log(typeof bool);
console.log(typeof bool2);


//undefined
//if we dont assign any value then js treats ut as undefined
let un;
console.log(un);
console.log(typeof un);



//null
let h=null;
console.log(h);
//typeof null is object 
console.log(typeof h);



//object---non-primitive datatype(as greater than 1 values can be assigned to single object)
let obj=[];
let obj1={};
let obj2={name:"hehe",age:45};
console.log(typeof obj);
console.log(typeof obj1);
console.log(typeof obj2);


let userName="Paltech";
let age=90;
console.log("My company name is "+userName+ " and it started around "+age +" years ago");
console.log(`My compnay name is ${userName} and it started ${age} ago`);
