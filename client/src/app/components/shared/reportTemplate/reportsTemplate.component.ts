import { Component, Input, OnInit  } from '@angular/core';
import { Router } from '@angular/router';
import { CloudinaryOptions, CloudinaryUploader } from 'ng2-cloudinary'

import { IReportPreview } from '../../reports-store/reports/IReportPreview';
import { UserService } from '../../../services/user.service';
import { FilterdataPipe } from './reportsFilter.pipe';

@Component({
    selector: 'reports-template',
    templateUrl: './reportTemplate.component.html',
    styleUrls: ['./reportsTemplate.component.css']
})
export class ReportsTemplateComponent implements OnInit {

  public filterName: string = 'all';

  @Input() public reports: IReportPreview[] = [];
  @Input() public dogs: IReportPreview[] = [];
  @Input() public cats: IReportPreview[] = [];
  @Input() public births: IReportPreview[] = [];
  @Input() public others: IReportPreview[] = [];

  @Input() public reportToShow:any;

    public success: string;
    public error: boolean;
    uploader: CloudinaryUploader = new CloudinaryUploader(
      new CloudinaryOptions({ cloudName: 'dqoigfeno', uploadPreset: 'ntgsijh9' })
    );

    constructor() {
      
     }

  
    changeFilter(filter) { 
      console.log(filter)
      console.log(this.dogs)
      console.log(this.reports)
      
      switch(filter) {
        case 'all': this.reportToShow = this.reports; break;
        case 'dog': this.reportToShow = this.dogs; break;
        case 'cat': this.reportToShow = this.cats; break;
        case 'birth': this.reportToShow = this.births; break;
        case 'other': this.reportToShow = this.others; break;
      }

      this.filterName = filter;
    } 

    ngOnInit(): void {
      console.log(this.reports)
      this.changeFilter('all')
    }

}
