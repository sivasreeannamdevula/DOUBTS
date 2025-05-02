import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  route:Router=inject(Router)
  activeRoue:ActivatedRoute=inject(ActivatedRoute)
  onclick()
  {
    //  this.route.navigate(['Home'])
    // this.route.navigateByUrl('About/Contact')
    this.route.navigate(['About/Contact'],{relativeTo:this.activeRoue})
  }
}
