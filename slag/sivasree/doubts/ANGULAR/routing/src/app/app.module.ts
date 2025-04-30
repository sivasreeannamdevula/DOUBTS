import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';

import { NotFoundComponent } from './not-found/not-found.component';
import { RelativeComponent } from './relative/relative.component';
import { AbsoluteComponent } from './absolute/absolute.component';



const routes:Routes=[
  // {path:'',component:HomeComponent},
  //here we are redirecting to /home directly instead of localhost:2347
  // {path:'' ,redirectTo:'Home',pathMatch:'full'},
  { path:'Home',component:HomeComponent},
  { path:'About',component:AboutComponent},
  {path:'Contact',component:ContactComponent},
  {path:'Home/Relative',component:RelativeComponent},
  {path:'Absolute',component:AbsoluteComponent},
  //must be defined at the last as checking happens from top to bottom--if we write at top then every route matches to this
  {path:'**',component:NotFoundComponent}
]
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
   
    NotFoundComponent,
        RelativeComponent,
        AbsoluteComponent
  ],
  imports: [
    //3rd party libraries
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
