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
var http_headers_service_1 = require("./http-headers.service");
require("rxjs/add/operator/map");
var constants_1 = require("../constants/constants");
var RegisterUrl = constants_1.Constants.hostUrl + 'api/report';
var ReportService = /** @class */ (function () {
    function ReportService(http, httpHedersService) {
        this.http = http;
        this.httpHedersService = httpHedersService;
        this.loggedIn = false;
    }
    ReportService.prototype.registerReport = function (reportToRegister) {
        return this.http.post(RegisterUrl, reportToRegister, { withCredentials: true })
            .map(function (res) {
            var body = res.json();
            return {
                status: res.status,
                body: res.json()
            };
        });
    };
    ReportService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [typeof (_a = typeof http_1.Http !== "undefined" && http_1.Http) === "function" && _a || Object, http_headers_service_1.HttpHeadersService])
    ], ReportService);
    return ReportService;
    var _a;
}());
exports.ReportService = ReportService;
//# sourceMappingURL=report.service.js.map