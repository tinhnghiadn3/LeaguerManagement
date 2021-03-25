import {NgModule} from '@angular/core';
import {HomeComponent} from './home.component';
import {ThemeModule} from '@app/theme/theme.module';
import {SharedModule} from '@app/shared/shared.module';
import {RouterModule} from '@angular/router';
import { HeaderDashboardComponent } from './header-dashboard/header-dashboard.component';

@NgModule({
  declarations: [HomeComponent, HeaderDashboardComponent],
  imports: [
    ThemeModule,
    SharedModule,
    RouterModule.forChild([
      {path: '', component: HomeComponent}
    ]),
  ]
})
export class HomeModule {
}
