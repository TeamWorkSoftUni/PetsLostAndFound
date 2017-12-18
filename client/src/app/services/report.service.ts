import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpHeadersService } from './http-headers.service'
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Constants } from '../constants/constants';

const RegisterUrl: string = Constants.hostUrl + 'api/report';


@Injectable()
export class ReportService {

    private loggedIn: boolean = false;

    constructor(
        private http: Http,
        private httpHedersService: HttpHeadersService
    ) {

    }

    registerReport(reportToRegister: Object): Observable<any> {
        return this.http.post(RegisterUrl, reportToRegister, {withCredentials: true})
            .map((res: Response) => {
                let body = res.json();
                
                return {
                    status: res.status,
                    body: res.json()
                }
            })
    }

    
}