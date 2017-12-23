"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var app_routing_module_1 = require("./app-routing.module");
var forms_1 = require("@angular/forms");
var ng2_file_upload_1 = require("ng2-file-upload");
var reports_module_1 = require("./components/reports-store/reports.module");
var app_component_1 = require("./app.component");
var header_component_1 = require("./components/shared/header/header.component");
var footer_component_1 = require("./components/shared/footer/footer.component");
var register_component_1 = require("./components/authentication/register/register.component");
var login_component_1 = require("./components/authentication/login/login.component");
var home_component_1 = require("./components/home/home.component");
var http_headers_service_1 = require("./services/http-headers.service");
var authentication_service_1 = require("./services/authentication.service");
var user_service_1 = require("./services/user.service");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                header_component_1.HeaderComponent,
                footer_component_1.FooterComponent,
                register_component_1.RegisterComponent,
                login_component_1.LoginComponent,
                home_component_1.HomeComponent,
            ],
            imports: [
                platform_browser_1.BrowserModule,
                app_routing_module_1.AppRoutingModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                http_1.HttpModule,
                ng2_file_upload_1.FileUploadModule,
                reports_module_1.ReportsModule
            ],
            providers: [
                http_headers_service_1.HttpHeadersService,
                authentication_service_1.AuthenticationService,
                user_service_1.UserService
            ],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map