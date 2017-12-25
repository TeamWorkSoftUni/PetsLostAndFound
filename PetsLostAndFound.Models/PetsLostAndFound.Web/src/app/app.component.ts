import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private _httpService: Http) { }

  apiValues: string[] = [];

  ngOnInit() {
    this._httpService.get('/api/index').subscribe(values => {
      this.apiValues = values.json() as string[];
    });
  }

}
//import { Component } from '@angular/core';
//import { Router, NavigationEnd } from '@angular/router';

//@Component({
//  moduleId: module.id,
//  selector: 'app-root',
//  templateUrl: './app.component.html',
//  styleUrls: ['./app.component.css']
//})
//export class AppComponent {
//  constructor(private router: Router) { }

//  ngOnInit() {
//    this.router.events.subscribe((evt) => {
//      if (!(evt instanceof NavigationEnd)) {
//        return;
//      }
//      window.scrollTo(0, 0)
//    });
//  }
//}
