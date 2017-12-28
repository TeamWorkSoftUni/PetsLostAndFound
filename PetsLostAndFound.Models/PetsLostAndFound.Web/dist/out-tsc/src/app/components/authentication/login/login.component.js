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
var router_1 = require("@angular/router");
var authentication_service_1 = require("../../../services/authentication.service");
var user_service_1 = require("../../../services/user.service");
var constants_1 = require("../../../constants/constants");
var AuthToken = constants_1.Constants.authTokent;
var LoginComponent = (function () {
    function LoginComponent(fb, _authService, _router, userService) {
        this.fb = fb;
        this._authService = _authService;
        this._router = _router;
        this.userService = userService;
        this.error = false;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.userToLogin = this.fb.group({
            'email': ['', forms_1.Validators.compose([forms_1.Validators.required])],
            'password': ['', forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(4)])],
        });
    };
    LoginComponent.prototype.login = function () {
        console.log(this.userToLogin.value);
        // this._authService.login(this.userToLogin.value)
        //     .subscribe((res: any) => {
        //         this.userService.getLoggedUser()
        //             .subscribe((x) => {
        //                 this.userService.loggedUser = x.user;
        //                 console.log(x.user);
        //                 this._router.navigate(['/home']);
        //             },
        //             (error) => {
        //                 localStorage.removeItem(AuthToken);
        //                 this.userService.loggedUser = null;
        //                 this._router.navigate(['/home']);
        //                 console.log('Error in user service');
        //             });
        //     },
        //     (err: any) => {
        //         let notificationMsg = JSON.parse(err._body).message;
        //         this.error = true;
        //         this.errorMessage = notificationMsg;
        //         setTimeout(() => {
        //             this.error = false;
        //         }, 2500);
        //     });
        this._router.navigate(['/home']);
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        selector: 'app-login',
        templateUrl: './login.component.html',
        styleUrls: ['./login.component.css']
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder,
        authentication_service_1.AuthenticationService,
        router_1.Router,
        user_service_1.UserService])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map