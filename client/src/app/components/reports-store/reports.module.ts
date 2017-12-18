import { NgModule } from '@angular/core';
import { AppRoutingModule } from '../../app-routing.module';

import { LocationFormComponent } from './location-form/location-form.component';
import { ReportsComponent } from './reports/reports.component';
import { ReportFormComponent } from './report-form/report-form.component';

// Modules
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AgmCoreModule } from '@agm/core';

// Services
import { ReportService } from '../../services/report.service';
import { ImagesFormComponent } from './images-form/images-form.component';
import { PetFormComponent } from './pet-form/pet-form.component';



@NgModule({
  declarations: [ 
    ReportsComponent,    
    LocationFormComponent,
    ReportFormComponent,
    ImagesFormComponent,
    PetFormComponent,
  ],
  imports: [ 
    CommonModule, 
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyBEFONV9Qm5seghvVJomqOmmXY5fHqxcDY',
      libraries: ["places"]
    })
  ],
  exports: [ 
    ReportsComponent,
    
  ],
  providers: [ 
    ReportService
   ]
})
export class ReportsModule {  } 