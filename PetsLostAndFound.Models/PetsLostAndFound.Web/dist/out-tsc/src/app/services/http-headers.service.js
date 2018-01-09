"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var HttpHeadersService = /** @class */ (function () {
    function HttpHeadersService() {
    }
    HttpHeadersService.prototype.getHeaders = function (token) {
        var headersObject = {};
        headersObject['Content-Type'] = 'application/json';
        if (token) {
            headersObject['Authorization'] = token;
        }
        var headers = new http_1.Headers(headersObject);
        var options = new http_1.RequestOptions({ headers: headers });
        return options;
    };
    HttpHeadersService = __decorate([
        core_1.Injectable()
    ], HttpHeadersService);
    return HttpHeadersService;
}());
exports.HttpHeadersService = HttpHeadersService;
//# sourceMappingURL=http-headers.service.js.map