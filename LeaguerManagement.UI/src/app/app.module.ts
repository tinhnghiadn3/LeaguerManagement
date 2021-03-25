import {BrowserModule} from '@angular/platform-browser';
import {APP_INITIALIZER, Injector, NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {AppLoadService} from '@app/services/shared';
import {ACCESS_TOKEN_KEY, AUTH_SCHEME} from '@app/shared/constants';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import {NgxPermissionsModule} from 'ngx-permissions';
import {JwtModule} from '@auth0/angular-jwt';
import {ThemeModule} from './theme/theme.module';
import {SharedModule} from '@app/shared/shared.module';
import {LoginComponent} from './theme/components/login/login.component';
import {ForgotComponent} from './theme/components/forgot/forgot.component';


export function initializeApp(injector: Injector) {
  return (): Promise<any> => {
    const appInitService = injector.get(AppLoadService);
    return appInitService.initApp();
  };
}

export function accessTokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN_KEY) ? decodeURIComponent(
    atob(localStorage.getItem(ACCESS_TOKEN_KEY))
  ) : null;
}

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    //
    NgxPermissionsModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: accessTokenGetter,
        authScheme: AUTH_SCHEME,
        allowedDomains: [
          new RegExp('\/assets\/.*')
        ]
      }
    }),
    //
    ThemeModule.forRoot(),
    SharedModule.forRoot(),
    AppRoutingModule,
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    ForgotComponent
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [Injector],
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
