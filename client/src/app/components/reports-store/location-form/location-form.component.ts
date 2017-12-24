import { Component, OnInit, ElementRef, NgZone, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormControl} from '@angular/forms';
import { } from 'googlemaps';
import { MapsAPILoader } from '@agm/core';
import { OutletContext } from '@angular/router/src/router_outlet_context';

@Component({
  selector: 'app-location-form',
  templateUrl: './location-form.component.html',
  styleUrls: ['./location-form.component.css']
})
export class LocationFormComponent implements OnInit {
  locationName: string;
 
  public latitude: number;
  public longitude: number;
  public searchControl: FormControl;
  public zoom: number;
  public mapType: string = 'terrain'
  @Output() selectedLocation = new EventEmitter<Object>()

  @ViewChild("search")
  public searchElementRef: ElementRef;


  constructor(
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone,
  ) { }

  ngOnInit() {

   
    //set google maps defaults
    this.zoom = 4;
    this.latitude = 39.8282;
    this.longitude = -98.5795;

    //create search FormControl
    this.searchControl = new FormControl();

    //set current position
    this.setCurrentPosition();

    //load Places Autocomplete
    this.mapsAPILoader.load().then(() => {
      let autocomplete = new google.maps.places.Autocomplete(this.searchElementRef.nativeElement, {
        types: ["address"]
      });
      autocomplete.addListener("place_changed", () => {
        this.ngZone.run(() => {
          
          //get the place result
          let place: google.maps.places.PlaceResult = autocomplete.getPlace();
          this.locationName = place.formatted_address;
          //console.log(place)
          //verify result
          if (place.geometry === undefined || place.geometry === null) {
            return;
          }

          //set latitude, longitude and zoom
          this.latitude = place.geometry.location.lat();
          this.longitude = place.geometry.location.lng();
         
          this.zoom = 12;
        });
      });
    });
  }

  private setCurrentPosition() {
    if ("geolocation" in navigator) {  
      navigator.geolocation.getCurrentPosition((position) => {
        this.latitude = position.coords.latitude;
        this.longitude = position.coords.longitude;
        this.zoom = 12;
      });
    }
  }

  centerChanged(event) {
    
    this.latitude = event.lat;
    this.longitude = event.lng;
    this.selectedLocation.emit({
      locationAdress: this.locationName,
      latitude: this.latitude,
      longitude: this.longitude
    })
  }

  changeViewMap() {
    if(this.mapType === 'terrain') {
      this.mapType ='satellite'
    } else {
      this.mapType ='terrain'
    }
  }

}
