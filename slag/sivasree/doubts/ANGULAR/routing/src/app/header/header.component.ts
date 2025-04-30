import { Component, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private route:Router,private activeroute:ActivatedRoute) { }

  ngOnInit(): void {
  }
   
  OnNavigation()
  {
    //by default navigate and navigateByUrl are absolute paths but we can make navigate as relative using
    //actu=uveroute object but we cannot make navigateByUrl as relative
    // this.route.navigate(['Home']);
    // this.route.navigate(['Home'],{relativeTo:this.activeroute});
    // this.route.navigateByUrl('Home');
  }
}
