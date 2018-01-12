import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterdata'
})

export class FilterdataPipe implements PipeTransform {

  transform(reports: Array<any>, arg: string): any { 
    return reports.filter(function(report){ 
           return report.petType.toLowerCase().includes(arg.toLowerCase());
    })
  }
}