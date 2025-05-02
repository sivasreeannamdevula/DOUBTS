import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { StringinterpolationComponent } from './stringinterpolation/stringinterpolation.component';
import { PropertInterpolationComponent } from './propert-interpolation/propert-interpolation.component';
import { EventbinidngComponent } from './eventbinidng/eventbinidng.component';
import { NgmoduleComponent } from './ngmodule/ngmodule.component';
import { FormsModule, NgModel } from '@angular/forms';
import { ChildOfAppComponent } from './child-of-app/child-of-app.component';
@NgModule({
  declarations: [
    AppComponent,
    StringinterpolationComponent,
    PropertInterpolationComponent,
    EventbinidngComponent,
    NgmoduleComponent,
    ChildOfAppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
