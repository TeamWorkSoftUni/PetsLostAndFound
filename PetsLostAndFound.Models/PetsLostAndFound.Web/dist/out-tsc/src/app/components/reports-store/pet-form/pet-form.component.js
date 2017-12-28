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
var PetFormComponent = (function () {
    function PetFormComponent() {
        this.newPet = new core_1.EventEmitter();
        this.hasPetType = false;
        this.hasPetDescription = false;
        this.model = {
            petType: '',
            petName: '',
            age: '',
            description: ''
        };
        console.log('tuks');
    }
    PetFormComponent.prototype.ngOnInit = function () {
    };
    PetFormComponent.prototype.isPetTypeValid = function (e) {
        console.log(e);
        if (e.target.value.length > 2) {
            this.hasPetType = true;
        }
    };
    PetFormComponent.prototype.isDescriptionValid = function (e) {
        if (e.target.value.length > 3) {
            this.hasPetDescription = true;
        }
    };
    PetFormComponent.prototype.petFillData = function (event) {
        this.newPet.emit(this.model);
    };
    return PetFormComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], PetFormComponent.prototype, "statusType", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Boolean)
], PetFormComponent.prototype, "isLost", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], PetFormComponent.prototype, "newPet", void 0);
PetFormComponent = __decorate([
    core_1.Component({
        selector: 'app-pet-form',
        templateUrl: './pet-form.component.html',
        styleUrls: ['./pet-form.component.css']
    }),
    __metadata("design:paramtypes", [])
], PetFormComponent);
exports.PetFormComponent = PetFormComponent;
//# sourceMappingURL=pet-form.component.js.map