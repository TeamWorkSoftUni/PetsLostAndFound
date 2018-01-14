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
              this.reports = reports.body;
              console.log(this.reports)
              for(let report of this.reports) {
                
                let petType = report.pet.petType;
                switch(petType) {
                  case 0: this.dogs.push(report); break;
                  case 1: this.cats.push(report); break;
                  case 2: this.births.push(report); break;
                  case 3: this.others.push(report); break;
                }
              }
            });
  }

}
