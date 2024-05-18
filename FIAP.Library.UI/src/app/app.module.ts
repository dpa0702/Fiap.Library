import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HeroFormComponent } from './hero-form/hero-form.component';
import { BookFormComponent } from './book-form/book-form.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { RentBookFormComponent } from './rentbook-form/rentbook-form.component';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    HeroFormComponent,
    BookFormComponent,
    CustomerFormComponent,
    RentBookFormComponent
  ],
  providers: [],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
