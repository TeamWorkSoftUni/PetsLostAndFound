import { NgModule } from '@angular/core';
import { AppRoutingModule } from '../../app-routing.module';

import { LocationFormComponent } from './location-form/location-form.component';
import { ReportsComponent } from './reports/reports.component';
import { ReportFormComponent } from './report-form/report-form.component';
import { ImagesFormComponent } from './images-form/images-form.component';
import { PetFormComponent } from './pet-form/pet-form.component';
import { RegisterComponent} from '../../components/authentication/register/register.component';
import { ReportsTemplateComponent } from '../shared/reportTemplate/reportsTemplate.component';

// Modules
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AgmCoreModule } from '@agm/core';
import { BrowserModule } from '@angular/platform-browser';
import { Ng2CloudinaryModule } from 'ng2-cloudinary';
import { FileUploadModule } from 'ng2-file-upload';


// Services
import { ReportService } from '../../services/report.service';
import { DetailsReportComponent } from './details-report/details-report.component';
import { DeleteReportComponent } from './delete-report/delete-report.component';




@NgModule({
  declarations: [ 
    ReportsComponent,    
    LocationFormComponent,
    ReportFormComponent,
    ImagesFormComponent,
    PetFormComponent,
    RegisterComponent,
    ReportsTemplateComponent,
    DetailsReportComponent,
    DeleteReportComponent
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
    }),
    BrowserModule,
    Ng2CloudinaryModule,
    FileUploadModule
  ],
  exports: [ 
    ReportsComponent,
    ReportsTemplateComponent
    
  ],
  providers: [ 
    ReportService
   ]
})
export class ReportsModule {  } 