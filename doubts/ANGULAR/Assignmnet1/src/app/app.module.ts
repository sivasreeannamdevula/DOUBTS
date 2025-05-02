import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ContainerComponent } from './container/container.component';
import { SearchComponent } from './container/header/search/search.component';
import { HeaderComponent } from './container/header/header.component';
import { NavbarComponent } from './container/header/navbar/navbar.component';
import { BodyComponent } from './container/body/body.component';
import { FormsModule } from '@angular/forms';
import { EventEmitter } from 'stream';

@NgModule({
  declarations: [
    AppComponent,
    ContainerComponent,
    SearchComponent,
    HeaderComponent,
    NavbarComponent,
    BodyComponent

  ],
  imports: [
    BrowserModule,
    FormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
