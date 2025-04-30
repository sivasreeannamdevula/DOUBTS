import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Directives';
  listOfGreetings=["hey","hi","hello","namasthe","shukriya"]
  listOfStrings:string[]=['a','ewd'];
  searchText='';
  listOfObjects =[
    {
           id:1,
           name:'Sivasree',
           age:22,
           place:'Rajahmundry',
           gender:'female',
           availableinStock:true
    },
    {
      id:2,
      name:'Chaitanya',
      age:29,
      place:'rajahmundry',
      gender:'female',
      availableinStock:false
    },
    {
       id:3,
       name:'Roja',
       age:20,
       place:'KKd',
       gender:'female',
       availableinStock:false
    },
    {
        id:4,
        name:'uday',
        age:21,
        place:'Hyd',
        gender:'male',
        availableinStock:true
    }
  ]

  isEmpty:string='de'
}
