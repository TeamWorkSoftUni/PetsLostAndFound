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
  currentDateAsString: string;

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
  public hasPet: boolean = false
  currentDate: Date = new Date(Date.now())
  
 
  constructor(public fb: FormBuilder,
      public reportService: ReportService,
      public router: Router) {

  }

  ngOnInit() {
    this.currentDateAsString = this.currentDate.toISOString().substring(0,10)

      this.reportToRegister = this.fb.group({
          'statusType': ['', Validators.required],
          'lostFoundDate': ['', Validators.required],
          'content': ['no content'],
          'rfid': ['no rfid'],
          'rewardSum': ['0'],
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
    this.hasPet = true
  }

  onUploadedImagesId(event) {
    this.targetPetImagesId = event
    this.hasImages = true
  }

  register(file): void {
    this.userId = '328affdb-55c0-4e11-9996-e367b78037f5'//localStorage.getItem('userId')
    this.reportToRegister.value.location = this.location
    this.reportToRegister.value.userId = this.userId
    this.reportToRegister.value.targetPet = this.targetPet
    this.reportToRegister.value.targetPetImagesId = this.targetPetImagesId
    

    console.log(JSON.stringify(this.reportToRegister.value))
       this.reportService
           .registerReport(JSON.stringify(this.reportToRegister.value))
           .subscribe((res: any) => {
               console.log(res)

               this.router.navigate(['/home']);


             },
           (err: any) => {

               let notificationMsg = JSON.parse(err._body).message;
               console.log(notificationMsg)
           });
      this.router.navigate(['/home']);
  }

}
