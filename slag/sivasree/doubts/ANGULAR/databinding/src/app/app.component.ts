import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  product1:string="hellofrom app";
  anil:string="ANIL SWAMY";

  //child nunchi vachina data
  fromchild:string="";
  ParentEvent(event:any)
  {
       this.fromchild=event.childData;
  }

  onclick(input:HTMLInputElement)
  {
    console.log(input.value);
  }
}
