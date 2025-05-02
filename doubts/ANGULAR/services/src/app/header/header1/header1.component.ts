import { Component, OnInit } from '@angular/core';
import { clickService } from 'src/Services/click.service';
import { userService } from 'src/Services/user.service';

@Component({
  selector: 'app-header1',
  templateUrl: './header1.component.html',
  styleUrls: ['./header1.component.css'],
  //here if we have this then when any newuser gets added via header component it will not get reflected as both are
  //using different instnaces of userService...inorder to avoid this...we create an instance in the parent and pass it to child
  // providers:[userService]
})
export class Header1Component implements OnInit {

  constructor(private userService:userService) { }
  usersList=this.userService.GetAllUsers();

  ngOnInit(): void {
  }
  
   OnClick()
    {
      let instance=new clickService();
      instance.OnClick();
    }
}
