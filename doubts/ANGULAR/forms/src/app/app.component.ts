import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'forms';
  firstname:string="hanuman";
  lastname:string="";
  isAgreed:boolean=false;


  // this function accepts the html form
  // RegistrationSubmitted2(val:HTMLFormElement)
  // {
  //   console.log(val);
  // }
  RegistrationSubmitted(form:NgForm)
  {
    console.log(form);
    // retrieving form data

    // console.log(val.controls['firstname'].value);
    // console.log(val.value.firstname);
    // console.log(val.value.lastname);
    // console.log(val.value.city);
    // console.log(val.value.country);

    // to access in group
    // console.log(form.value.address.city);

    this.firstname=form.controls['firstname'].value;
    this.lastname=form.value.lastname;

    // in this way we can only update in the forms object but not in the actual form
    // form.value.lastname=this.firstname;
    // form.controls['lastname'].value=this.firstname


  // form.setValue(
  //     {
  //       firstname: 'John',
  //       lastname: 'Doe',
  //       dob: '1990-01-01',
  //       phone: '1234567890',
  //       country: 'USA',
  //       gender: 'Male',
        
       
  //       AddressGroup:
  //       {
  //         city: 'New York',
  //         postalcode: '10001',
  //         address: '123 Main St',
  //       }
  //     }
  //   )

  // form.form.patchValue(
  //   {
  //     lastname:'sree' ,
  //     AddressGroup:
  //     {
  //       city:'rajahmundry'
  //     }

  //   }
  // )

  // resetting the form
  // form.reset();
  // //after reseting if we would like to add any data to fields
  // form.form.patchValue(
  //   {
  //     firstname:'sreee'
  //   }
  // )
  }
}
