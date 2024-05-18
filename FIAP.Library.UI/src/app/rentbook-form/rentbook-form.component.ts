import { Component } from '@angular/core';

import { RentBook } from '../rentbook';

@Component({
  selector: 'app-rentbook-form',
  templateUrl: './rentbook-form.component.html',
  styleUrls: ['./rentbook-form.component.css']
})
export class RentBookFormComponent {

  statues = ['Reserved', 'Borrowed', 'Canceled'];

  model = new RentBook(1, '01/01/2000', '01/01/2000', '01/01/2000', 1, 1, this.statues[0]);

  submitted = false;

  onSubmit() { this.submitted = true; }


  newbook() {
    this.model = new RentBook(3, '01/01/2000', '01/01/2000', '01/01/2000', 1, 1, 'Reserved');
  }

  skyDog(): RentBook {
    const myRentBook =  new RentBook(2, '01/01/2000', '01/01/2000', '01/01/2000', 1, 1, 'Reserved');
    console.log('My rental is called ' + myRentBook.id);
    return myRentBook;
  }

  showFormControls(form: any) {
    return form && form.controls.name &&
    form.controls.name.value;
  }
}
