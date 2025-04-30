import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { rejects } from 'assert';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'ReactiveForms';
  formSTATUS:string='';
  reactiveForm=new FormGroup(
    {
      
       //siva is the defualt value
       firstname:new FormControl('siva',[Validators.required,this.notAllowed],AppComponent.isAlreadyTaken),
       
       //sree is the defualt value
       lastname:new FormControl('sree',[Validators.required,  Validators.maxLength(10)]),
       phone:new FormControl(null),
       dob:new FormControl(null),
       //male is the defualt value
       gender:new FormControl('male'),
       country:new FormControl('usa'),
       addr:new FormGroup(
        {
          address:new FormControl(null),
          city:new FormControl(null,Validators.required),
          postal:new FormControl(null),
       
        }
       ),
       skills:new FormArray(
        [
          new FormControl(null,Validators.required),
          
        ]
       ),
       experience:new FormArray([])

    }
  )

  get skills() {
    return this.reactiveForm.get('skills') as FormArray;
  }

  get experience() {
    return this.reactiveForm.get('experience') as FormArray;
  }
  
  AddSkill()
  {
    (this.reactiveForm.get('skills') as FormArray).push(new FormControl(null))
  }

  Delete(index:number)
  {
    (this.reactiveForm.get('skills') as FormArray).removeAt(index)
  }

  AddExperience()
  {
    (this.reactiveForm.get('experience') as FormArray).push(
      new FormGroup({
        companyName:new FormControl(null),
        start:new FormControl(null),
        end:new FormControl(null)

      }
    ))
  }


  DeleteExperience(index:number)
  {
    (this.reactiveForm.get('experience') as FormArray).removeAt(index)
  }

  //CREATING CUSTOM VALIDATOR
    notAllowed(control:AbstractControl)
  {
      if(!control.value && control.value.indexOf('@')!=-1)
      {
        return {customValidator:true};
      }
      return null;
  }

  //asynC Validator--as it is returning a promise
  static isAlreadyTaken(control:AbstractControl):Promise<any>
  {
    return FirstNameAllowed(control.value);
 
  }

  ngOnInit()
{
  this.reactiveForm.
  //this event gets triggered whenever lastname chnages(here we are listening on a fromcontrol)
  this.reactiveForm.controls['firstname']?.valueChanges.subscribe((x)=>
    {
        console.log(x);
    });

    //here we are listening on the formgroup(which is reactiveForm)
    // this.reactiveForm.valueChanges.subscribe((x)=>
    //   {
    //       console.log(x);
    //   });


     //statusChnages on each FormControl
    // this.reactiveForm.get('lastname')?.statusChanges.subscribe((x)=>
    //   {
    //       console.log(x);
    //   });

      
      //statusChnages on the formGroup---if atleast one is invalid the status is invalid
      //VALID,INVALID,PENDING
      // this.reactiveForm.statusChanges.subscribe((x)=>
      //   {
      //       console.log(x);
      //       this.formSTATUS=x;
      //   });
}

 onclick()
 {

  //setting the value of the whole form
  // this.reactiveForm.setValue(
  //   {
  //     firstname:this.reactiveForm.get('lastname')?.value,
  //     lastname:this.reactiveForm.get('lastname')?.value,
  //     phone:'',
  //     dob:'',
  //     gender:'',
  //     country:new FormControl('usa'),
  //     addr:
  //      {
  //        address:this.reactiveForm.get('addr.address')?.value,
  //        city:this.reactiveForm.get('addr.city')?.value,
  //        postal:new FormControl(null),
      
  //      },
  //     skills:this.reactiveForm.get('skills')?.value,
  //     experience:[]
  //     }
  //   );


    //instead of setting the whole form we can set the individual formControl as below
    // this.reactiveForm.get('lastname')?.setValue("sreejaaa");

    //no need to specify the complete structure
    this.reactiveForm.patchValue(
      {
        lastname:35,
        address:
        {
          
          city:'Rjahmundry'
        }
      }
    );
 }
  
  Onsubmission()
  {
    console.log(this.reactiveForm);
  }
}


//something like an api call to check whether the entered firstname already present or not
//this funtion is calss independent ,instance indepenedent
function FirstNameAllowed(firstname:string)
{
   const takenFirstNames=['sree','ss','sivasree','mani'];
   return new Promise((resolve,reject)=>
   {
      setTimeout(()=>
      {
        if(takenFirstNames.includes(firstname))
        {
           resolve({alreadyTaken:true});
        }
        else
        {
           resolve(null);
        }
      },5000);
   }
  )
}

// addvalidator,setvalidtor,clearvalid,removevalidator,stepper forms(parent to child),typed forms