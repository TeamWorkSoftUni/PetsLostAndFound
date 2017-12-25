import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { CloudinaryOptions, CloudinaryUploader } from 'ng2-cloudinary'


@Component({
  selector: 'app-images-form',
  templateUrl: './images-form.component.html',
  styleUrls: ['./images-form.component.css']
})
export class ImagesFormComponent implements OnInit {
  imagesId: [string];
  @Output() uploadedImagesId = new EventEmitter()
  
  uploader: CloudinaryUploader = new CloudinaryUploader(
      new CloudinaryOptions({ cloudName: 'dqoigfeno', uploadPreset: 'ntgsijh9' })
  );

  constructor(){
      //Override onSuccessItem to retrieve the imageId
      this.uploader.onSuccessItem = (item: any, response: string, status: number, headers: any): any => {
          let res: any = JSON.parse(response);
          if(!this.imagesId){
            this.imagesId = ['']
            this.imagesId[0] = res.public_id;
          } else {
            this.imagesId.push(res.public_id);
          }
          this.uploadedImagesId.emit(this.imagesId)
          console.log(this.imagesId)
          return { item, response, status, headers };
      };
  }

  upload() {
      this.uploader.uploadAll();
      //this.uploadedImagesId.emit(this.imagesId)
      console.log(this.imagesId)
  }

  ngOnInit() {
  }

}
