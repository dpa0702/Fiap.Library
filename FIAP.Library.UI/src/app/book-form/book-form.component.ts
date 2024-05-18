import { Component } from '@angular/core';

import { Book } from '../book';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent {

  genres = ['Fantasy', 'Selfhelp', 'Horror', 'Trip', 'Romance'];

  model = new Book(1, 'Book Name', 'Book Author', this.genres[3]);

  submitted = false;

  onSubmit() { this.submitted = true; }


  newbook() {
    this.model = new Book(3, '', '', '');
  }

  skyDog(): Book {
    const myBook =  new Book(2, 'Book Name 2',
                           'Book Author 2',
                           'Selfhelp');
    console.log('My book is called ' + myBook.name);
    return myBook;
  }

  showFormControls(form: any) {
    return form && form.controls.name &&
    form.controls.name.value;
  }
}
