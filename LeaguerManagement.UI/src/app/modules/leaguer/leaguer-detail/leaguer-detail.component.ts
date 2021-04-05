import {Component, OnDestroy, OnInit} from '@angular/core';
import {DropDownModel, LeaguerModel} from '@app/models';
import {Subscription} from 'rxjs';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {LookupService} from '@app/services/shared';
import {LeaguerService} from '@app/services/features/leaguer.service';
import {ActivatedRoute} from '@angular/router';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {GENDER_ITEMS} from '@app/shared/constants';

@Component({
  selector: 'app-leaguer-detail',
  templateUrl: './leaguer-detail.component.html',
  styleUrls: ['./leaguer-detail.component.scss']
})
export class LeaguerDetailComponent implements OnInit, OnDestroy {
  isLoading: boolean = false;
  isProcessing: boolean = false;

  leaguer: LeaguerModel = new LeaguerModel();
  units: DropDownModel[] = [];
  statuses: DropDownModel[] = [];

  isShowStreetEditingPopup: boolean = false;
  isExistData: boolean = false;
  leaguerId: number;

  now: Date = new Date();
  minDate: Date;
  maxDate: Date;
  subscription = new Subscription();

  GENDER_ITEMS = GENDER_ITEMS;
  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor(private lookupService: LookupService,
              private leaguerService: LeaguerService,
              private activatedRoute: ActivatedRoute) {
    this.subscription.add(
      this.activatedRoute.paramMap.subscribe(params => {
        this.leaguerId = +params.get('id');
        this.getLeaguer();
      })
    );

    this.subscription.add(
      this.lookupService.lookup.subscribe(lookup => {
        this.units = lookup.units;
        this.statuses = lookup.statuses;
      }));
  }

  ngOnInit() {
    this.minDate = this.now;
    this.maxDate = this.now;
  }

  getLeaguer() {
    this.isLoading = true;
    this.leaguerService.getLeaguer(this.leaguerId).subscribe(res => {
      this.leaguer = res;
      this.isLoading = false;
    }, () => {
      this.isLoading = false;
    });
  }

  save(validationGroup) {
    const validated = validationGroup.instance.validate();
    if (!validated.isValid) {
      return;
    }
    this.showProcessing();
    this.leaguerService.updateLeaguer(this.leaguer).subscribe(() => {
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Đảng viên', this.leaguer.name));
      this.hideProcessing();
      this.refresh();
    }, () => {
      this.hideProcessing();
    });
  }

  checkExistData() {
    if (!this.leaguer.cardNumber || !this.leaguer.cardNumber.trim()) {
      this.isExistData = false;
      return;
    }

    this.showProcessing();
    this.leaguerService.checkExistData(this.leaguer.cardNumber, this.leaguer.id).subscribe(res => {
      if (!res) {
        AppNotify.warning('Số thẻ Đảng viên đã tồn tại');
      }
      this.hideProcessing();
    }, () => {
      this.hideProcessing();
    });
  }

  refresh() {
    setTimeout(() => {
      this.getLeaguer();
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
