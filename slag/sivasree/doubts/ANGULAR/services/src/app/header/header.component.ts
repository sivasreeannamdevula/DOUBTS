import { Component, OnInit } from '@angular/core';
import { clickService } from 'src/Services/click.service';
import { userService } from 'src/Services/user.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers:[userService]

})
export class HeaderComponent implements OnInit {

  name:string='';
  age:number=0;
  gender:string='male';

  ngOnInit(): void {
  }
  constructor(private userService:userService)
  {

  }

   AddUser()
   {
      this.userService.CreateUser(this.name,this.age,this.gender);
      console.log(this.userService.GetAllUsers());
   }
   OnClick()
    {
      let instance=new clickService();
      instance.OnClick();
    }
}
