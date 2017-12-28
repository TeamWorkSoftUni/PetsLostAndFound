"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var app_routing_module_1 = require("../../app-routing.module");
var location_form_component_1 = require("./location-form/location-form.component");
var reports_component_1 = require("./reports/reports.component");
var report_form_component_1 = require("./report-form/report-form.component");
var images_form_component_1 = require("./images-form/images-form.component");
var pet_form_component_1 = require("./pet-form/pet-form.component");
var register_component_1 = require("../../components/authentication/register/register.component");
// Modules
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/common/http");
var core_2 = require("@agm/core");
var platform_browser_1 = require("@angular/platform-browser");
var ng2_cloudinary_1 = require("ng2-cloudinary");
var ng2_file_upload_1 = require("ng2-file-upload");
// Services
var report_service_1 = require("../../services/report.service");
var ReportsModule = (function () {
    function ReportsModule() {
    }
    return ReportsModule;
}());
ReportsModule = __decorate([
    core_1.NgModule({
        declarations: [
            reports_component_1.ReportsComponent,
            location_form_component_1.LocationFormComponent,
            report_form_component_1.ReportFormComponent,
            images_form_component_1.ImagesFormComponent,
            pet_form_component_1.PetFormComponent,
            register_component_1.RegisterComponent
        ],
        imports: [
            common_1.CommonModule,
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule,
            http_1.HttpClientModule,
            app_routing_module_1.AppRoutingModule,
            core_2.AgmCoreModule.forRoot({
                apiKey: 'AIzaSyBEFONV9Qm5seghvVJomqOmmXY5fHqxcDY',
                libraries: ["places"]
            }),
            platform_browser_1.BrowserModule,
            ng2_cloudinary_1.Ng2CloudinaryModule,
            ng2_file_upload_1.FileUploadModule
        ],
        exports: [
            reports_component_1.ReportsComponent,
        ],
        providers: [
            report_service_1.ReportService
        ]
    })
], ReportsModule);
exports.ReportsModule = ReportsModule;
//# sourceMappingURL=reports.module.js.map