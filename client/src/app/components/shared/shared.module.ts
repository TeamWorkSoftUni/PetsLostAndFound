import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FileUploadModule } from 'ng2-file-upload';

import { HttpHeadersService } from '../../services/http-headers.service';
import { UserService } from '../../services/user.service';

import { AuthenticationService } from '../../services/authentication.service';
import { ReportsTemplateComponent } from './reportTemplate/reportsTemplate.component';

import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

import { FilterdataPipe } from './reportTemplate/reportsFilter.pipe';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    FileUploadModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    FooterComponent,
    HeaderComponent,
    FilterdataPipe
  ],
  declarations: [
    FooterComponent,
    HeaderComponent,
    FilterdataPipe
  ],
  providers: [
    HttpHeadersService,
    UserService,
    AuthenticationService,
  ]
})
export class SharedModule { }