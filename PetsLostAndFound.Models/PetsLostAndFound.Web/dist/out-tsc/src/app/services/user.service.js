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
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
var constants_1 = require("./../constants/constants");
var UserByIdUrl = constants_1.Constants.hostUrl + 'api/users/user/';
var GetLoggedUserUrl = constants_1.Constants.hostUrl + 'api/auth/getLoggedUser';
var GetUsersUrl = constants_1.Constants.hostUrl + 'api/users';
var AuthToken = constants_1.Constants.authTokent;
var UserService = (function () {
    function UserService(http) {
        this.http = http;
    }
    UserService.prototype.getAllUsers = function () {
        return this.http.get(GetUsersUrl).map(function (response) { return response.json(); });
    };
    UserService.prototype.getUserData = function (userId) {
        var url = "" + UserByIdUrl + userId;
        return this.http.get(url).map(function (response) { return response.json(); });
    };
    UserService.prototype.getLoggedUser = function () {
        var _this = this;
        var token = localStorage.getItem(AuthToken);
        var authToken = {
            'token': token
        };
        return this.http.post(GetLoggedUserUrl, authToken, { withCredentials: true })
            .map(function (res) {
            var body = res.json();
            _this.loggedUser = body.user;
            return {
                status: res.status,
                user: body.user
            };
        });
    };
    UserService.prototype.isLoggedIn = function () {
        var userDataString = localStorage.getItem(AuthToken);
        if (!userDataString) {
            return Observable_1.Observable.of(false);
        }
        return this.getLoggedUser()
            .map(function (res) {
            if (+res.status == 200) {
                return true;
            }
            return false;
        });
    };
    return UserService;
}());
UserService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], UserService);
exports.UserService = UserService;
//# sourceMappingURL=user.service.js.map