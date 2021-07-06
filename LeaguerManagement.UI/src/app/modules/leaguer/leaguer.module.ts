import {NgModule} from '@angular/core';
import {LeaguerComponent} from './leaguer.component';
import {LeaguerListComponent} from './leaguer-list/leaguer-list.component';
import {LeaguerDetailComponent} from './leaguer-detail/leaguer-detail.component';
import {ThemeModule} from '@app/theme/theme.module';
import {SharedModule} from '@app/shared/shared.module';
import {RouterModule} from '@angular/router';
import { LeaguerTransferOfficalComponent } from './leaguer-transfer-offical/leaguer-transfer-offical.component';


@NgModule({
  declarations: [LeaguerComponent, LeaguerListComponent, LeaguerDetailComponent, LeaguerTransferOfficalComponent],
  imports: [
    ThemeModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: '', component: LeaguerComponent, children: [
          {path: '', component: LeaguerListComponent},
          {path: ':id/detail', component: LeaguerDetailComponent}
        ]
      }
    ]),
  ]
})
export class LeaguerModule {
}
