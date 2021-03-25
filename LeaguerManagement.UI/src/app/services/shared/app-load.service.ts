import {Injectable, Injector} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {NgxPermissionsService} from 'ngx-permissions';
import {forkJoin, of} from 'rxjs';

import {AuthenticationService} from '@app/services/auth';
import {ApiService} from './api.service';
import {API_SERVICE_MESSAGE} from '@app/shared/messages';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {LookupService} from '@app/services/shared/lookup.service';


@Injectable()
export class AppLoadService {
  protected httpClient: HttpClient;
  protected permissionsService: NgxPermissionsService;
  protected apiService: ApiService;
  protected authService: AuthenticationService;
  protected lookupService: LookupService;

  constructor(private injector: Injector) {
    this.httpClient = this.injector.get(HttpClient);
    this.permissionsService = this.injector.get(NgxPermissionsService);
    this.apiService = this.injector.get(ApiService);
    this.authService = this.injector.get(AuthenticationService);
    this.lookupService = this.injector.get(LookupService);
  }

  initApp(): Promise<any> {
    //
    if (this.authService.isLoggedIn()) {
      // forkJoin to require all requests to complete
      const result = forkJoin({
        lookup: this.loadAppLookup(),
        user: this.loadUser()
      }).toPromise().then((response) => {
        // Handle here if needed
      }, () => {
        AppNotify.error(API_SERVICE_MESSAGE.ExpiredSessionMessage);
        this.authService.logout();
      });
      return result;
    } else {
      return of(true).toPromise();
    }
  }

  loadUser(): Promise<any> {
    return this.authService.getCurrentUserInfo().toPromise().then((user) => {
      this.authService.setCurrentUserInfo(user);
      //
      return user;
    });
  }

  loadAppLookup() {
    return this.lookupService.getLookup().toPromise().then((lookups) => {
      this.lookupService.setLookup(lookups);
      //
      return lookups;
    });
  }
}
