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
var ng2_cloudinary_1 = require("ng2-cloudinary");
var ImagesFormComponent = /** @class */ (function () {
    function ImagesFormComponent() {
        var _this = this;
        this.uploadedImagesId = new core_1.EventEmitter();
        this.uploader = new ng2_cloudinary_1.CloudinaryUploader(new ng2_cloudinary_1.CloudinaryOptions({ cloudName: 'dqoigfeno', uploadPreset: 'ntgsijh9' }));
        //Override onSuccessItem to retrieve the imageId
        this.uploader.onSuccessItem = function (item, response, status, headers) {
            var res = JSON.parse(response);
            if (!_this.imagesId) {
                _this.imagesId = [''];
                _this.imagesId[0] = res.public_id;
            }
            else {
                _this.imagesId.push(res.public_id);
            }
            _this.uploadedImagesId.emit(_this.imagesId);
            console.log(_this.imagesId);
            return { item: item, response: response, status: status, headers: headers };
        };
    }
    ImagesFormComponent.prototype.upload = function () {
        this.uploader.uploadAll();
        //this.uploadedImagesId.emit(this.imagesId)
        console.log(this.imagesId);
    };
    ImagesFormComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", Object)
    ], ImagesFormComponent.prototype, "uploadedImagesId", void 0);
    ImagesFormComponent = __decorate([
        core_1.Component({
            selector: 'app-images-form',
            templateUrl: './images-form.component.html',
            styleUrls: ['./images-form.component.css']
        }),
        __metadata("design:paramtypes", [])
    ], ImagesFormComponent);
    return ImagesFormComponent;
}());
exports.ImagesFormComponent = ImagesFormComponent;
//# sourceMappingURL=images-form.component.js.map