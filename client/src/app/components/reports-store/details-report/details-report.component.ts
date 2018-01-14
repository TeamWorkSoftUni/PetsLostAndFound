import { Component, OnInit, Input, ViewChild, ElementRef, NgZone } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReportService } from '../../../services/report.service';
import { CloudinaryUploader, CloudinaryOptions } from 'ng2-cloudinary';

@Component({
  selector: 'app-details-report',
  templateUrl: './details-report.component.html',
  styleUrls: ['./details-report.component.css']
})
export class DetailsReportComponent implements OnInit {

  report: {} = {
    id: '',
    location: '',
    petType: '',
    targetPetImagesId: '',
    targetPet: ''
  }
  isLost: boolean = false;
  isFound: boolean = false;

  

  public latitude: string ;
  public longitude: string ;
  public zoom: number = 15;
  public mapType: string = 'terrain'
  

  uploader: CloudinaryUploader = new CloudinaryUploader(
    new CloudinaryOptions({ cloudName: 'dqoigfeno', uploadPreset: 'ntgsijh9' })
  );

  constructor(
    private route: ActivatedRoute,
    public reportService: ReportService
    
  ) {
  }
  
  targetId: any;  // -> wanted parameter (use your object type)
  
  ngOnInit() {
      // get URL parameters
      this.route.params.subscribe(params => {
        this.targetId = params['id']; // --> Name must match wanted parameter
      });

      this.reportService.getReportById(this.targetId)
            .subscribe((report) => {
              this.report = report.body;
              this.latitude = this.report['location'].latitude;
              this.longitude = this.report['location'].longitude;
              if(report.body.statusType === 'Lost') {
                this.isLost = true
                this.isFound = false
                
              } else {
                this.isFound = true
                this.isLost = false
                
              }

              
              console.log(this.latitude)
            });
  }

  changeViewMap() {
    if(this.mapType === 'terrain') {
      this.mapType ='satellite'
    } else {
      this.mapType ='terrain'
    }
  }
}
