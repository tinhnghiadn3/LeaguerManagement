import {Component, OnInit} from '@angular/core';
import {LoginModel} from '@app/models';
import {AuthenticationService} from '@app/services/auth';
import {VALIDATION_REGEX} from '@app/shared/constants';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {DxValidationGroupComponent} from 'devextreme-angular';
import {LookupService} from '@app/services/shared';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userName = '';
  password = '';
  rememberMe: boolean = false;
  isSubmitting: boolean = false;
  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor(private authService: AuthenticationService,
              private lookupService: LookupService) {
  }

  ngOnInit() {
  }

  onLoginClick(validationGroup: DxValidationGroupComponent) {
    if (!validationGroup.instance.validate().isValid) {
      return;
    }
    const param = new LoginModel({
      username: this.userName,
      password: this.password,
      rememberMe: this.rememberMe,
      timezoneOffset: (new Date()).getTimezoneOffset()
    });
    this.isSubmitting = true;
    this.authService.login(param).subscribe((data) => {
      this.isSubmitting = false;
      //
      this.authService.setCurrentUser(data);
      //
      this.authService.redirectToHome('/');
      // Only call to cache api
      this.authService.getCurrentUserInfo().subscribe();
      //
      this.lookupService.getLookup().subscribe(res => {
        this.lookupService.setLookup(res);
      });
    }, () => {
      this.isSubmitting = false;
    });
  }

  removeSpaces() {
    if (this.userName) {
      this.userName = this.userName.replace(/\s/g, '');
    }
  }
}
