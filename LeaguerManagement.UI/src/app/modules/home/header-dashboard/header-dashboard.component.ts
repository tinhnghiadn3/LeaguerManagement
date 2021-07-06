import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PercentPipe} from '@angular/common';
import {DropDownModel, StatusStatisticsModel} from '@app/models';

@Component({
  selector: 'app-header-dashboard',
  templateUrl: './header-dashboard.component.html',
  styleUrls: ['./header-dashboard.component.scss']
})
export class HeaderDashboardComponent implements OnInit {

  private _statuses: DropDownModel[] = [];
  @Input()
  get statuses(): DropDownModel[] {
    return this._statuses;
  }

  set statuses(value) {
    this._statuses = value;
    this.generateData();
  }

  @Output() onSelectedStatusChange = new EventEmitter();

  pipe: any = new PercentPipe('en-US');

  statusStatistics: StatusStatisticsModel[] = [];

  customizeTooltip = (arg: any) => {
    return {
      text: arg.valueText + ' - ' + this.pipe.transform(arg.percent, '1.2-2')
    };
  };

  constructor() {
  }

  ngOnInit() {
  }

  generateData() {
    this.statuses.forEach(status => {
      this.statusStatistics.push(new StatusStatisticsModel({
        statusId: status.key,
        statusName: status.value,
        amount: this.randomNumber(10, 50)
      }));
    });
  }

  pointClickHandler(e) {
    e.target.select();
    this.onSelectedStatusChange.emit(e.target.data.statusId);
  }

  randomNumber(min, max) {
    return Math.random() * (max - min) + min;
  }
}
