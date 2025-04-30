import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'stringinterpolation',
  templateUrl: './stringinterpolation.component.html',
  styleUrls: ['./stringinterpolation.component.css']
})
export class StringinterpolationComponent   {

  constructor() { }
    name:string='Bag';
    age:Number=26;
    discount:Number=2;
    price:Number=600;
     product={
      name:'productname',
      price:'prductprice',
      cost:2456,
      discount:20,
      condition:false
     }

     getName()
     {
      return 'sivasree';
     }
 
}
