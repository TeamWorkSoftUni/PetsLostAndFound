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
var authentication_service_1 = require("../../../services/authentication.service");
var router_1 = require("@angular/router");
var RegisterComponent = /** @class */ (function () {
    function RegisterComponent(fb, authService, router) {
        this.fb = fb;
        this.authService = authService;
        this.router = router;
        this.stepOne = true;
        this.error = false;
        this.isError = false;
    }
    RegisterComponent.prototype.ngOnInit = function () {
        this.userToRegister = this.fb.group({
            'username': ['', forms_1.Validators.required],
            'email': ['', forms_1.Validators.required],
            'password': ['', forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(6)])],
            'confirmedPassword': ['', forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(6)])]
        });
    };
    RegisterComponent.prototype.register = function (file) {
        console.log(this.userToRegister.value);
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
    RegisterComponent = __decorate([
        core_1.Component({
            selector: 'app-register',
            templateUrl: './register.component.html',
            styleUrls: ['./register.component.css']
        }),
        __metadata("design:paramtypes", [forms_1.FormBuilder,
            authentication_service_1.AuthenticationService,
            router_1.Router])
    ], RegisterComponent);
    return RegisterComponent;
}());
exports.RegisterComponent = RegisterComponent;
//# sourceMappingURL=register.component.js.map