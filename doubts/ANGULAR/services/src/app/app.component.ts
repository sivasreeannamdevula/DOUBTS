import { Component } from '@angular/core';
import { clickService } from 'src/Services/click.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  //telling injector what to provide
  // providers:[clickService]
})
export class AppComponent {
  title = 'services';
  clickservice:clickService;
  //telling injector how to provide
  constructor(clickserv:clickService)
  {
    this.clickservice=clickserv;
  }
  OnClick()
  {
    //AppComponent class is tightly coupled(any chnage in that class effects this class)
    //  on clickService class so to avoid this we use dependecncy injection
    // let instance=new clickService();
    this.clickservice.OnClick();
  }
}
