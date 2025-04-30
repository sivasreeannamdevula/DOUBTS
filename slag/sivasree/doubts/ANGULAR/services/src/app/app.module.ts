import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { Header1Component } from './header/header1/header1.component';
import { BodyComponent } from './body/body.component';
import { FooterComponent } from './footer/footer.component';
import { clickService } from 'src/Services/click.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    Header1Component,
    BodyComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  //singleton
  providers: [clickService],
  bootstrap: [AppComponent]
})
export class AppModule { }
