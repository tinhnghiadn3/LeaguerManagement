import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PercentPipe} from '@angular/common';
import {StatusStatisticModel} from '@app/models';
import {LeaguerService} from '@app/services/features/leaguer.service';

@Component({
  selector: 'app-header-dashboard',
  templateUrl: './header-dashboard.component.html',
  styleUrls: ['./header-dashboard.component.scss']
})
export class HeaderDashboardComponent {

  @Input() statusStatistics: StatusStatisticModel[] = [];
  @Output() onSelectedStatusChange = new EventEmitter();

  pipe: any = new PercentPipe('en-US');
  isLoading: boolean = false;

  customizeTooltip(arg: any) {
    return {
      text: arg.valueText + ' - ' + this.pipe.transform(arg.percent, '1.2-2')
    };
  }

  constructor() {
  }

  pointClickHandler(e) {
    e.target.select();
    this.onSelectedStatusChange.emit(e.target.data.statusId);
  }

  randomNumber(min, max) {
    return Math.random() * (max - min) + min;
  }
}
