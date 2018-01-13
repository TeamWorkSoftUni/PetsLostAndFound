import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../../services/authentication.service';
import { UserService } from '../../../services/user.service';

import { Constants } from '../../../constants/constants';

const AuthToken: string = Constants.authTokent;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public userToLogin: FormGroup;
  public error: boolean = false;
  public errorMessage: string;

  constructor(private fb: FormBuilder,
      private _authService: AuthenticationService,
      private _router: Router,
      public userService: UserService
  ) {
  }

  ngOnInit() {
      this.userToLogin = this.fb.group({
          'email': ['', Validators.compose([Validators.required])],
          'password': ['', Validators.compose([Validators.required, Validators.minLength(4)])],
      });
  }
  
  login(): void {
    console.log(this.userToLogin.value);
      this._authService.login(JSON.stringify(this.userToLogin.value))
          .subscribe((res: any) => {
              this.userService.getLoggedUser()
                  .subscribe((x) => {
                      this.userService.loggedUser = x.user;
                      console.log(x.user);
                      this._router.navigate(['/home']);

                  },
                  (error) => {
                      localStorage.removeItem(AuthToken);
                      this.userService.loggedUser = null;
                      this._router.navigate(['/home']);
                      console.log('Error in user service');

                  });
          },
          (err: any) => {
              let notificationMsg = JSON.parse(err._body).message;
              this.error = true;
              this.errorMessage = notificationMsg;
              setTimeout(() => {
                  this.error = false;

              }, 2500);
          });

      this._router.navigate(['/home']);
  }
}
