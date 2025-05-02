import { Component, Input, OnInit, Output ,EventEmitter} from '@angular/core';


@Component({
  selector: 'app-child-of-app',
  templateUrl: './child-of-app.component.html',
  styleUrls: ['./child-of-app.component.css']
})
export class ChildOfAppComponent  {

  constructor() { }

  @Input()
  product:string="";
  @Input("alias")
  name:string="";

  // e data ni parent lo use cheyyali
  childData:string="Data From Child";
  // first manam oka custom event ni create cheyyali using EventEmitter
  @Output() customevent=new EventEmitter<string>();

  //raising an event
  sendData()
  {
    this.customevent.emit(this.childData);
  }

}
