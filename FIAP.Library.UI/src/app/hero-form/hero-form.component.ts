import { Component, Injectable, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../book';

@Component({
  selector: 'app-hero-form',
  templateUrl: './hero-form.component.html',
  styleUrls: ['./hero-form.component.css']
})

@Injectable({
  providedIn: 'root',
  })

export class HeroFormComponent implements OnInit{

  constructor(private httpClient: HttpClient) {}

  powers = ['Really Smart', 'Super Flexible',
            'Super Hot', 'Weather Changer'];

  model = new Hero(18, 'Dr. IQ', this.powers[0], 'Chuck Overstreet');

  submitted = false;

  onSubmit() { this.submitted = true; }

  newHero() {
    this.model = new Hero(42, '', '');
  }

  skyDog(): Hero {
    const myHero =  new Hero(42, 'SkyDog',
                           'Fetch any object at any distance',
                           'Leslie Rollover');
    console.log('My hero is called ' + myHero.name); // "My hero is called SkyDog"
    return myHero;
  }

  newAlert() : Observable<any> {
    alert('Newalert');
    const url = 'https://pokeapi.co/api/v2/pokemon/1';
    var obj = this.httpClient.get<string>(url);
    return obj;
  }

  ngOnInit(): void {
    //alert('onInit');
    this.getBooksDetails().subscribe((data) => {
      console.log(data);
    });
  }

  getBooksDetails(): Observable<Book[]> {
    const url = 'https://localhost:7219/Book/GetBookById/3';
    return this.httpClient.get<Book[]>(url);
  }

  //////// NOT SHOWN IN DOCS ////////

  // Reveal in html:
  //   Name via form.controls = {{showFormControls(heroForm)}}
  showFormControls(form: any) {
    return form && form.controls.name &&
    form.controls.name.value; // Dr. IQ
  }

  /////////////////////////////

}
