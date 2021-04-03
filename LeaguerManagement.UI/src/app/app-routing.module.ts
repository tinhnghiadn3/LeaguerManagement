import {NgModule} from '@angular/core';
import {Routes, RouterModule, ExtraOptions} from '@angular/router';
import {AuthGuard, GuestGuard} from '@app/services/auth';
import {ErrorComponent, ForbiddenComponent} from './theme/components';
import {LoginComponent} from './theme/components/login/login.component';
import {ForgotComponent} from './theme/components/forgot/forgot.component';
import {NgxPermissionsGuard} from 'ngx-permissions';

const routes: Routes = [
  {
    path: '', redirectTo: 'home', pathMatch: 'full'
  },
  {
    path: 'home',
    loadChildren: () => import('@app/modules/home/home.module').then(m => m.HomeModule),
    canActivate: [AuthGuard],
  },
  {
    path: 'leaguer',
    loadChildren: () => import('@app/modules/leaguer/leaguer.module').then(m => m.LeaguerModule),
    canActivate: [AuthGuard],
  },
  {
    path: 'settings',
    loadChildren: () => import('@app/modules/settings/settings.module').then(m => m.SettingsModule),
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['Settings'],
        redirectTo: 'forbidden'
      }
    }
  },
  {
    path: 'login', component: LoginComponent, canActivate: [GuestGuard]
  },
  {
    path: 'forgot', component: ForgotComponent, canActivate: [GuestGuard]
  },
  {
    path: 'forbidden',
    component: ForbiddenComponent
  },
  {
    path: '**', component: ErrorComponent
  }
];

const config: ExtraOptions = {
  useHash: false
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
