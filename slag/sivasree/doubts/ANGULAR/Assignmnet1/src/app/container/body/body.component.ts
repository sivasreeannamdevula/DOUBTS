import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent {

  
 
    products = [
      { TransactionType: "Credit", DueDate: "2024-04-10", DueDays: 30, Category: "Banking", Priority: "Medium" },
      { TransactionType: "Debit", DueDate: "2024-04-15", DueDays: 15, Category: "Banking", Priority: "High" },
      { TransactionType: "Loan", DueDate: "2024-05-01", DueDays: 60, Category: "Finance", Priority: "Low" },
      { TransactionType: "EMI", DueDate: "2024-06-05", DueDays: 45, Category: "Loans", Priority: "Medium" },
      { TransactionType: "Bill Payment", DueDate: "2024-04-20", DueDays: 10, Category: "Utilities", Priority: "High" },
      { TransactionType: "Salary Credit", DueDate: "2024-04-30", DueDays: 0, Category: "Income", Priority: "Medium" },
      { TransactionType: "Investment", DueDate: "2024-07-01", DueDays: 90, Category: "Finance", Priority: "Low" },
      { TransactionType: "Insurance Premium", DueDate: "2024-06-15", DueDays: 40, Category: "Insurance", Priority: "Medium" },
      { TransactionType: "Tax Payment", DueDate: "2024-09-30", DueDays: 180, Category: "Government", Priority: "High" },
      { TransactionType: "Rent Payment", DueDate: "2024-05-05", DueDays: 20, Category: "Housing", Priority: "High" },
      { TransactionType: "Gold", DueDate: "2024-07-05", DueDays: 2, Category: "Investment", Priority: "Low" }
  ];
  
  @Input()
  searchText:string="";

  filteredProducts()
  {
   let res= this.products.filter(x=>x.TransactionType.toLowerCase().includes(this.searchText.toLowerCase())
                                        ||  x.Category.toLowerCase().includes(this.searchText.toLowerCase()) 
                                        || x.DueDate.toLowerCase().includes(this.searchText.toLowerCase())
                                        || x.Priority.toLowerCase().includes(this.searchText.toLowerCase())
                                       || x.DueDays.toString().includes(this.searchText.toLowerCase()));
   
      return res;
    

  }
  
}
