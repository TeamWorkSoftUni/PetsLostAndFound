import { Component, OnInit } from '@angular/core';
import { ReportService } from '../../../services/report.service'

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  public reports: any[] = [];
  public dogs: any[] = [];
  public cats: any[] = [];
  public births: any[] = [];
  public others: any[] = [];

  constructor(public reportService: ReportService) { }

  ngOnInit() {
    this.reportService.getAllReports()
            .subscribe((reports) => {
              this.reports = reports;
              for(let report of this.reports) {
                let petType = report.petType;
                switch(petType) {
                  case 'dog': this.dogs.push(report); break;
                  case 'cat': this.cats.push(report); break;
                  case 'birth': this.births.push(report); break;
                  case 'other': this.others.push(report); break;
                }
              }
            });
  }

}
