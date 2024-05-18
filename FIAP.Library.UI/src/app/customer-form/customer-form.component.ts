import { Component } from '@angular/core';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent {

  documents = ['RG', 'CPF', 'CNH', 'PASSPORT', 'Outros'];

  model = new Customer(1, 'customer Name', 'customer Phone', 'customer Email', 'customer Address', this.documents[3]);

  submitted = false;

  onSubmit() { this.submitted = true; }


  newcustomer() {
    this.model = new Customer(3, '', '', '', '', '');
  }

  skyDog(): Customer {
    const mycustomer =  new Customer(2, 'customer Name 2',
                           'customer Phone 2',
                           'customer Email 2',
                           'customer Address 2',
                           'CNH');
    console.log('My customer is called ' + mycustomer.name);
    return mycustomer;
  }

  showFormControls(form: any) {
    return form && form.controls.name &&
    form.controls.name.value;
  }
}
