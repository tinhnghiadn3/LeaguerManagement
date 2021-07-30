import {Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {DropDownModel, LeaguerModel, StatusStatisticModel} from '@app/models';
import {Subscription} from 'rxjs';
import {LookupService} from '@app/services/shared';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {LeaguerService} from '@app/services/features/leaguer.service';
import DataSource from 'devextreme/data/data_source';
import {Router} from '@angular/router';
import {GENDER_ITEMS} from '@app/shared/constants';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components/popover-confirm-box/popover-confirm-box.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('deletingAccessControlConfirmBox', {static: true}) deletingAccessControlConfirmBox: PopoverConfirmBoxComponent;

  pageSize = 20;
  dataSource: DataSource;

  units: DropDownModel[] = [];
  statuses: DropDownModel[] = [];
  files: LeaguerModel[] = [];
  statusStatistics: StatusStatisticModel[] = [];
  selectedFile: LeaguerModel = new LeaguerModel();

  isShowEditingPopup: boolean = false;
  isLoading: boolean = false;
  isProcessing: boolean = false;

  genderItems = GENDER_ITEMS;
  GENERAL_MESSAGE = GENERAL_MESSAGE;
  subscription: Subscription = new Subscription();

  constructor(private leaguerService: LeaguerService,
              private router: Router,
              private lookupService: LookupService) {
    this.subscription.add(
      this.lookupService.lookup.subscribe(lookup => {
        this.units = lookup.units;
        this.statuses = lookup.statuses;
      }));
  }

  ngOnInit() {
    this.getCurrentStaffs();
    this.getStatusStatistic();
  }

  getCurrentStaffs(statusId = null) {
    this.dataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        if (statusId) {
          loadOptions.filter = ['statusId', '=', statusId];
        }
        return this.leaguerService.getCurrentLeaguers(loadOptions).toPromise();
      }
    });
  }

  getStatusStatistic() {
    this.isLoading = true;
    this.leaguerService.getStatusStatistics().subscribe(res => {
      this.statusStatistics = res;
      this.isLoading = false;
    }, () => {
      this.isLoading = false;
    });
  }

  refresh() {
    setTimeout(() => {
      this.getCurrentStaffs();
    }, 100);
  }

  goToDetail(data: LeaguerModel) {
    this.router.navigate([`/leaguer/${data.id}/detail`]).then();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
