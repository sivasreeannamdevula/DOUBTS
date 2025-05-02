import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';

export const routes: Routes = [
    //define routes here
    {path:'Home', component:HomeComponent},
    {path:'About', component:AboutComponent},
    {path:'About/Contact', component:ContactComponent}
];
