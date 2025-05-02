import { Component, OnInit } from '@angular/core';
import { cwd } from 'process';

@Component({
  selector: 'app-ngmodule',
  templateUrl: './ngmodule.component.html',
  styleUrls: ['./ngmodule.component.css']
})
export class NgmoduleComponent  {

  constructor() { }

  name:string="firstname"
  triggered(event:any)
  {
      this.name=event.target.value
      console.log(this.name);
  }
}
