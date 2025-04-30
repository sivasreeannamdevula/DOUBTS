import { Component, OnInit, Output ,EventEmitter} from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  searchText:string="";

  @Output()
  searchTextEmitter=new EventEmitter<string>();
 
  onInputEmitter()
  {
    this.searchTextEmitter.emit(this.searchText);
  }
}
