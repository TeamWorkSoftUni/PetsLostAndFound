import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpHeadersService } from './http-headers.service'
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Constants } from '../constants/constants';

const RegisterUrl: string = Constants.hostUrl + 'api/reports/create';
const ReportsGetUrl: string = Constants.hostUrl + 'api/reports/all';



@Injectable()
export class ReportService {

    private loggedIn: boolean = false;

    constructor(
        private http: Http,
        private httpHedersService: HttpHeadersService
    ) {

    }

    registerReport(reportToRegister: Object): Observable<any> {
        return this.http.post(RegisterUrl, reportToRegister, this.httpHedersService.getHeaders())
            .map((res: Response) => {
                let body = res.json();
                
                return {
                    status: res.status,
                    body: res.json()
                }
            })
    }

    getAllReports(): Observable<any> {
        return this.http.get(ReportsGetUrl, this.httpHedersService.getHeaders())
            .map((res: Response) => {
                console.log('HEREEEEE')
                console.log(res)
                
                return {
                    status: res.status,
                    body: res.json()
                }
            })
    }
}