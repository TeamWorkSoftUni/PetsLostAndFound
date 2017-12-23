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
var report_service_1 = require("../../../services/report.service");
var router_1 = require("@angular/router");
var ReportFormComponent = /** @class */ (function () {
    function ReportFormComponent(fb, reportService, router) {
        this.fb = fb;
        this.reportService = reportService;
        this.router = router;
        this.isFound = false;
        this.isLost = false;
        this.hasImages = false;
        this.hasLocation = false;
        this.hasPet = false;
    }
    ReportFormComponent.prototype.ngOnInit = function () {
        this.reportToRegister = this.fb.group({
            'statusType': ['', forms_1.Validators.required],
            'lostFoundDate': ['', forms_1.Validators.required],
            'content': [''],
            'rfid': [''],
            'rewardSum': [''],
        });
    };
    ReportFormComponent.prototype.onClickStatusType = function (event) {
        if (event.target.value === 'lost') {
            this.isLost = true;
            this.isFound = false;
            this.selectedStatusType = 'lost';
        }
        else if (event.target.value === 'found') {
            this.isFound = true;
            this.isLost = false;
            this.selectedStatusType = 'found';
        }
    };
    ReportFormComponent.prototype.selectedLocation = function (event) {
        this.location = event;
        this.hasLocation = true;
    };
    ReportFormComponent.prototype.onNewPet = function (event) {
        this.targetPet = event;
        this.hasPet = true;
    };
    ReportFormComponent.prototype.onUploadedImagesId = function (event) {
        this.targetPetImagesId = event;
        this.hasImages = true;
    };
    ReportFormComponent.prototype.register = function (file) {
        this.userId = 'string'; //localStorage.getItem('userId')
        this.reportToRegister.value.location = this.location;
        this.reportToRegister.value.userId = this.userId;
        this.reportToRegister.value.targetPet = this.targetPet;
        this.reportToRegister.value.targetPetImagesId = this.targetPetImagesId;
        console.log(JSON.stringify(this.reportToRegister.value));
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
    };
    ReportFormComponent = __decorate([
        core_1.Component({
            selector: 'app-report-form',
            templateUrl: './report-form.component.html',
            styleUrls: ['./report-form.component.css']
        }),
        __metadata("design:paramtypes", [forms_1.FormBuilder,
            report_service_1.ReportService,
            router_1.Router])
    ], ReportFormComponent);
    return ReportFormComponent;
}());
exports.ReportFormComponent = ReportFormComponent;
//# sourceMappingURL=report-form.component.js.map