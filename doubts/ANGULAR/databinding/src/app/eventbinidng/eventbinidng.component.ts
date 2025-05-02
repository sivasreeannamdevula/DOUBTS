import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'eventbinidng',
  templateUrl: './eventbinidng.component.html',
  styleUrls: ['./eventbinidng.component.css']
})
export class EventbinidngComponent {

  constructor() { }
  name:string="initial";
  a:number=0;
  method(event:any)
  {
    console.log(event);
    this. name=event.target.value
  }
  increment()
  {
    this.a++;
  }
  decrement()
  {
    this.a--;
  }
}
