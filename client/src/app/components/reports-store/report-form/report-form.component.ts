import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ReportService } from '../../../services/report.service';
import { FileUploader } from 'ng2-file-upload';
import { Router } from '@angular/router';

import { Constants } from '../../../constants/constants';

@Component({
  selector: 'app-report-form',
  templateUrl: './report-form.component.html',
  styleUrls: ['./report-form.component.css']
})
export class ReportFormComponent implements OnInit {

  public userId: string;
  public isFound: boolean = false;
  public isLost: boolean = false;
  public selectedStatusType: string
  public reportToRegister: FormGroup;
  public location: {}
  public targetPet: {}
  public targetPetImagesId: {}
  public hasImages: boolean = false
  public hasLocation: boolean = false
  
 
  constructor(public fb: FormBuilder,
      public reportService: ReportService,
      public router: Router) {

  }

  ngOnInit() {

      this.reportToRegister = this.fb.group({
          'statusType': ['', Validators.required],
          'lostFoundDate': ['', Validators.required],
          'content': [''],
          'rfid': ['', Validators.required],
          'rewardSum': [''],
      });
  }

 
  onClickStatusType(event){
    if(event.target.value === 'lost') {
      this.isLost = true
      this.isFound = false
      this.selectedStatusType = 'lost'
    } else if(event.target.value === 'found'){
      this.isFound = true
      this.isLost = false
      this.selectedStatusType = 'found'
    }
  }

  selectedLocation(event) {
    this.location = event
    this.hasLocation = true
  }

  onNewPet(event) {
    this.targetPet = event
  }

  onUploadedImagesId(event) {
    this.targetPetImagesId = event
    this.hasImages = true
  }

  register(file): void {
    this.userId = 'string' //localStorage.getItem('userId')
    this.reportToRegister.value.location = this.location
    this.reportToRegister.value.userId = this.userId
    this.reportToRegister.value.targetPet = this.targetPet
    this.reportToRegister.value.targetPetImagesId = this.targetPetImagesId
    

    console.log(this.reportToRegister.value)
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
  }

}
