import { Component, OnInit } from '@angular/core';
import { clickService } from 'src/Services/click.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
   OnClick()
    {
      let instance=new clickService();
      instance.OnClick();
    }
}
