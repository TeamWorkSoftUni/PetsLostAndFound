import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegisterComponent } from './components/authentication/register/register.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { ReportsComponent } from './components/reports-store/reports/reports.component'
import { ReportFormComponent } from './components/reports-store/report-form/report-form.component';
import { DetailsReportComponent } from './components/reports-store/details-report/details-report.component';
import { DeleteReportComponent } from './components/reports-store/delete-report/delete-report.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'reports', component: ReportsComponent },
  { path: 'report-form', component: ReportFormComponent },
  { path: 'pet/details/:id', component: DetailsReportComponent },
  { path: 'pet/delete', component: DeleteReportComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
