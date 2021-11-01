import { NgModule } from '@angular/core';
import { StatisticComponent } from './statistic.component';
import {ThemeModule} from '@app/theme/theme.module';
import {SharedModule} from '@app/shared/shared.module';
import {RouterModule} from '@angular/router';



@NgModule({
  declarations: [StatisticComponent],
  imports: [
    ThemeModule,
    SharedModule,
    RouterModule.forChild([
      {path: '', component: StatisticComponent}
    ]),
  ]
})
export class StatisticModule { }
