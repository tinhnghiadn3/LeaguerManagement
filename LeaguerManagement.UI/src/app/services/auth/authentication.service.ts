import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {Observable} from 'rxjs';
import {NgxPermissionsService} from 'ngx-permissions';
import {JwtHelperService} from '@auth0/angular-jwt';

import {
  ACCESS_TOKEN_KEY, AccessControls,
  HOME_URL_KEY,
  IMAGE_TOKEN_KEY,
  JOB_APPSTORAGE_KEY,
  REFRESH_TOKEN_KEY,
} from '@app/shared/constants';
import {API_ENDPOINT} from '@app/services/endpoints';
import {AppStorage, ImageUtility} from '../../shared/utilities';

import {ApiService} from '@app/services/shared/api.service';
import {LoggedUserService} from '@app/services/auth/logged-user.service';
import {LoggedUserModel} from '@app/models/authentication/logged-user.model';
import {AuthenticationUserModel} from '@app/models/authentication/authentication-user.model';
import {LoginModel} from '@app/models/authentication/login.model';
import {ChangePasswordModel} from '@app/models/authentication/change-password.model';

@Injectable()
export class AuthenticationService {
  constructor(private router: Router,
              private jwtHelper: JwtHelperService,
              private permissionsService: NgxPermissionsService,
              private apiService: ApiService,
              private loggedUserService: LoggedUserService) {
  }

  get currentUser(): Observable<LoggedUserModel> {
    return this.loggedUserService.currentUser;
  }

  get loggedUser(): LoggedUserModel {
    return this.loggedUserService.loggedUser;
  }

  removeTokens() {
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    localStorage.removeItem(IMAGE_TOKEN_KEY);
    localStorage.removeItem(REFRESH_TOKEN_KEY);
    localStorage.removeItem(HOME_URL_KEY);
  }

  removeSessionData() {
    AppStorage.removeSessionData(JOB_APPSTORAGE_KEY);
  }

  isLoggedIn(): boolean {
    if (!this.apiService.accessToken) {
      return false;
    }

    if (this.jwtHelper.isTokenExpired(this.apiService.accessToken)) {
      return false;
    }
    // Will be refresh token
    return true;
  }

  setCurrentUser(result: AuthenticationUserModel) {
    //
    // Set access token
    AppStorage.storeTokenData(ACCESS_TOKEN_KEY, result.accessToken);
    AppStorage.storeTokenData(IMAGE_TOKEN_KEY, result.imageToken);
    AppStorage.storeTokenData(REFRESH_TOKEN_KEY, result.refreshToken);
    //
    // Set logged user information
    this.setCurrentUserInfo(result.user);
  }

  setCurrentUserInfo(user: LoggedUserModel) {
    ImageUtility.setAvatar(user);
    this.loggedUserService.setLoggedUser(user);
    //
    //
    const permissions = AccessControls.filter(_ => user.accessControlIds.includes(_.id)).map(_ => _.symbol);
    this.loggedUserService.setCurrentPermissions(permissions);
    this.permissionsService.loadPermissions(permissions || []);
  }

  redirectToHome(homeUrl?: string) {
    if (!homeUrl) {
      homeUrl = AppStorage.getTokenData(HOME_URL_KEY);
    }
    if (homeUrl) {
      this.router.navigateByUrl(homeUrl).then();
    } else {
      console.error('None homeUrl');
      this.router.navigate(['/']).then();
    }
  }

  removeCurrentUser(navigateToLogin = true) {
    //
    this.loggedUserService.setLoggedUser(null);
    //
    this.permissionsService.flushPermissions();
    //
    this.removeTokens();
    //
    this.removeSessionData();
    //
    if (navigateToLogin) {
      this.apiService.navigateToLogin();
    }
  }

  getCurrentUserInfo(): Observable<LoggedUserModel> {
    return this.apiService.get<LoggedUserModel>(`${API_ENDPOINT.Auth}/current-user`);
  }

  login(param: LoginModel): Observable<AuthenticationUserModel> {
    return this.apiService.post<AuthenticationUserModel>(`${API_ENDPOINT.Auth}/login`, param);
  }

  changePassword(param: ChangePasswordModel): Observable<boolean> {
    return this.apiService.post<boolean>(`${API_ENDPOINT.Auth}/change`, param);
  }

  // TODO: Move to logged-user service
  logout() {
    this.apiService.get(`${API_ENDPOINT.Auth}/logout`).toPromise().then();
    //
    this.removeCurrentUser(true);
  }
}
