import { Component, OnInit, Output,EventEmitter } from '@angular/core';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

 
  searchText:string="";

onInputEmitter(value:any)
{
  this.searchText=value;
 
}


@Output()
searchEmitter=new EventEmitter<string>();

onSearchEmitter()
{
  this.searchEmitter.emit(this.searchText);
}

}
