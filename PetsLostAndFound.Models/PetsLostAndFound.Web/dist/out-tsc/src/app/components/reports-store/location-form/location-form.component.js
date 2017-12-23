"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var core_2 = require("@agm/core");
var LocationFormComponent = /** @class */ (function () {
    function LocationFormComponent(mapsAPILoader, ngZone) {
        this.mapsAPILoader = mapsAPILoader;
        this.ngZone = ngZone;
        this.mapType = 'terrain';
        this.selectedLocation = new core_1.EventEmitter();
    }
    LocationFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        //set google maps defaults
        this.zoom = 4;
        this.latitude = 39.8282;
        this.longitude = -98.5795;
        //create search FormControl
        this.searchControl = new forms_1.FormControl();
        //set current position
        this.setCurrentPosition();
        //load Places Autocomplete
        this.mapsAPILoader.load().then(function () {
            var autocomplete = new google.maps.places.Autocomplete(_this.searchElementRef.nativeElement, {
                types: ["address"]
            });
            autocomplete.addListener("place_changed", function () {
                _this.ngZone.run(function () {
                    //get the place result
                    var place = autocomplete.getPlace();
                    console.log(place);
                    //verify result
                    if (place.geometry === undefined || place.geometry === null) {
                        return;
                    }
                    //set latitude, longitude and zoom
                    _this.latitude = place.geometry.location.lat();
                    _this.longitude = place.geometry.location.lng();
                    _this.zoom = 12;
                });
            });
        });
    };
    LocationFormComponent.prototype.setCurrentPosition = function () {
        var _this = this;
        if ("geolocation" in navigator) {
            navigator.geolocation.getCurrentPosition(function (position) {
                _this.latitude = position.coords.latitude;
                _this.longitude = position.coords.longitude;
                _this.zoom = 12;
            });
        }
    };
    LocationFormComponent.prototype.centerChanged = function (event) {
        this.latitude = event.lat;
        this.longitude = event.lng;
        this.selectedLocation.emit({
            latitude: this.latitude,
            longitude: this.longitude
        });
    };
    LocationFormComponent.prototype.changeViewMap = function () {
        if (this.mapType === 'terrain') {
            this.mapType = 'satellite';
        }
        else {
            this.mapType = 'terrain';
        }
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", Object)
    ], LocationFormComponent.prototype, "selectedLocation", void 0);
    __decorate([
        core_1.ViewChild("search"),
        __metadata("design:type", core_1.ElementRef)
    ], LocationFormComponent.prototype, "searchElementRef", void 0);
    LocationFormComponent = __decorate([
        core_1.Component({
            selector: 'app-location-form',
            templateUrl: './location-form.component.html',
            styleUrls: ['./location-form.component.css']
        }),
        __metadata("design:paramtypes", [core_2.MapsAPILoader,
            core_1.NgZone])
    ], LocationFormComponent);
    return LocationFormComponent;
}());
exports.LocationFormComponent = LocationFormComponent;
//# sourceMappingURL=location-form.component.js.map