import { Component, OnInit, NgZone, Output, ViewChild, EventEmitter, ElementRef } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../services/authentication.service';
import { FileUploader } from 'ng2-file-upload';
import { Router } from '@angular/router';

import { } from 'googlemaps';
import { MapsAPILoader } from '@agm/core';
import { OutletContext } from '@angular/router/src/router_outlet_context';

import { CloudinaryOptions, CloudinaryUploader } from 'ng2-cloudinary'

import { Constants } from '../../../constants/constants';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  public userId: string;
  public userEmail: string;
  public errorMessage: string;
  public stepOne: boolean = true;
  public error: boolean = false;
  public isError: boolean = false;

  public userToRegister: FormGroup;

  public locationName: string;
  public searchControl: FormControl;
  public latitude: number;
  public longitude: number;

  public userImagesId: {}
  @ViewChild("search")
  public searchElementRef: ElementRef;

  constructor(
      public fb: FormBuilder,
      public authService: AuthenticationService,
      public router: Router,
      private mapsAPILoader: MapsAPILoader,
      private ngZone: NgZone
    ) {
  }

  ngOnInit() {
      this.userToRegister = this.fb.group({
          'username': ['', Validators.required],
          'email': ['', Validators.required],
          'telephoneNumber': ['', Validators.compose([Validators.required, Validators.minLength(7)])],
          'locationName': ['', Validators.required],
          'password': ['', Validators.compose([Validators.required, Validators.minLength(6)])],
          'confirmedPassword': ['', Validators.compose([Validators.required, Validators.minLength(6)])],
          'userImagesId': this.userImagesId,
          'latitude': this.latitude,
          'longitude': this.longitude
      });

    //create search FormControl
    this.searchControl = new FormControl();

    this.setCurrentPosition();

    //load Places Autocomplete
    this.mapsAPILoader.load().then(() => {
      console.log(this.searchControl)
      let autocomplete = new google.maps.places.Autocomplete(this.searchElementRef.nativeElement);
      autocomplete.addListener("place_changed", () => {
        this.ngZone.run(() => {
          
          //get the place result
          let place: google.maps.places.PlaceResult = autocomplete.getPlace();
          this.locationName = place.formatted_address;
        });
      });
    });
  }

  onUploadedImagesId(event) {
    this.userImagesId = event;
    //this.hasImages = true
  }

  register(file): void {
    this.userToRegister.value.userImagesId = this.userImagesId
    console.log(JSON.stringify(this.userToRegister.value))
      // this.authService
      //     .register(this.userToRegister.value)
      //     .subscribe((res: any) => {
      //         this.userId = res.body.id;
      //         this.userEmail = res.body.email;

      //         this.stepOne = false;

      //         this.router.navigate(['/home']);


      //       },
      //     (err: any) => {

      //         let notificationMsg = JSON.parse(err._body).message;
      //         this.error = true
      //         this.errorMessage = notificationMsg;
      //         setTimeout(() => {
      //             this.error = false;

      //         }, 4500);
      //     });
      this.router.navigate(['/home']);
  }

  private setCurrentPosition() {
    if ("geolocation" in navigator) {  
      navigator.geolocation.getCurrentPosition((position) => {
        this.latitude = position.coords.latitude;
        this.longitude = position.coords.longitude;
      });
    }
  }
 }
