import { Component, OnInit } from '@angular/core';
import { clickService } from 'src/Services/click.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
   OnClick()
    {
      
      let instance=new clickService();
      instance.OnClick();
    }
}
