import {Component, OnDestroy, OnInit} from '@angular/core';
import {LookupModel} from '@app/models/shared/ref.model';
import {LookupService} from '@app/services/shared';
import {Subscription} from 'rxjs';
import {DropDownModel} from '@app/models';
import {StatisticService} from '@app/services/features/statistic.service';
import {saveAs} from 'file-saver';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.scss']
})
export class StatisticComponent implements OnInit, OnDestroy {

  years: DropDownModel[] = [];

  selectedYear: number;
  isLoading: boolean = false;
  isProcessing: boolean = false;
  subscription: Subscription = new Subscription();

  constructor(private lookupService: LookupService,
              private statisticService: StatisticService) {
    this.subscription.add(
      this.lookupService.lookup.subscribe((lookup: LookupModel) => {
        this.years = lookup.years;
        console.log(this.years);
      })
    );
  }

  ngOnInit() {
    this.selectedYear = new Date().getFullYear();
  }

  export5BTC() {
    this.showProcessing();
    this.statisticService.export5BTC(this.selectedYear).subscribe(blob => {
      saveAs(blob, `Tong hop Ket qua danh gia phan loai Dang vien.xls`);
      this.hideProcessing();
    }, () => {
      this.hideProcessing();
    });
  }

  export4TW() {
    this.showProcessing();
    this.statisticService.export4TW(this.selectedYear).subscribe(blob => {
      saveAs(blob, `Thong ke chia theo Dan toc va Ton giao.xls`);
      this.hideProcessing();
    }, () => {
      this.hideProcessing();
    });
  }

  showProcessing() {
    setTimeout(() => {
      this.isProcessing = true;
    });
  }

  hideProcessing() {
    setTimeout(() => {
      this.isProcessing = false;
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
