import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaguerComponent } from './leaguer.component';
import { LeaguerListComponent } from './leaguer-list/leaguer-list.component';
import { LeaguerDetailComponent } from './leaguer-detail/leaguer-detail.component';



@NgModule({
  declarations: [LeaguerComponent, LeaguerListComponent, LeaguerDetailComponent],
  imports: [
    CommonModule
  ]
})
export class LeaguerModule { }
