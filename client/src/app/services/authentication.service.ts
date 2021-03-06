import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpHeadersService } from './http-headers.service'
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Constants } from '../constants/constants';

const RegisterUrl: string = Constants.hostUrl + 'api/account/register';
const LoginUrl: string = Constants.hostUrl + 'api/account/login';
const LogoutUrl: string = Constants.hostUrl + 'api/logout';
const AuthToken: string = Constants.authTokent;

@Injectable()
export class AuthenticationService {

    private loggedIn: boolean = false;

    constructor(
        private http: Http,
        private httpHedersService: HttpHeadersService
    ) {

    }

    register(userToRegister: Object): Observable<any> {
        return this.http.post(RegisterUrl, userToRegister, this.httpHedersService.getHeaders())
            .map((res: Response) => {
                let body = res.json();
                let token = body.token;
                console.log(res)

               // localStorage.setItem(AuthToken, token);
                return {
                    status: res.status,
                    body: res.json()
                }
            })
    }

    login(userToLogin: Object): Observable<any> {
        return this.http.post(LoginUrl, userToLogin, this.httpHedersService.getHeaders())
            .map((res: Response) => {
                let body = res.json();
                let token = body.token;

                localStorage.setItem(AuthToken, token);
                localStorage.setItem('userId', body.id);
                
                this.loggedIn = true;
                return {
                    status: res.status,
                    body: res.json()
                }
            })
    }

    logout(): Observable<Response> {
        let options = this.httpHedersService.getHeaders();
        localStorage.removeItem(AuthToken);
        this.loggedIn = false;
        return this.http.get(LogoutUrl, {withCredentials: true});
    }
}