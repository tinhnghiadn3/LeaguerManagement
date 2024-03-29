import {Component, ElementRef, OnDestroy, OnInit, ViewChild} from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import {AttachmentModel, DropDownModel, LeaguerModel, LoggedUserModel} from '@app/models';
import {GENDER_ITEMS} from '@app/shared/constants';
import {Subscription} from 'rxjs';
import {LeaguerService} from '@app/services/features/leaguer.service';
import {Router} from '@angular/router';
import {LookupService} from '@app/services/shared';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {AppLeaguerStatus} from '@app/shared/enums';
import {saveAs} from 'file-saver';
import {LoggedUserService} from '@app/services/auth';

@Component({
  selector: 'app-leaguer-list',
  templateUrl: './leaguer-list.component.html',
  styleUrls: ['./leaguer-list.component.scss']
})
export class LeaguerListComponent implements OnInit, OnDestroy {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('deletingAccessControlConfirmBox', {static: true}) deletingAccessControlConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('streaming', {static: false}) streamingCanvas: ElementRef;

  pageSize = 20;
  dataSource: DataSource;

  loggedUser: LoggedUserModel = new LoggedUserModel();
  units: DropDownModel[] = [];
  statuses: DropDownModel[] = [];
  leaguers: LeaguerModel[] = [];
  selectedLeaguer: LeaguerModel = new LeaguerModel();

  isShowEditingPopup: boolean = false;
  isShowTransferringPopup: boolean = false;
  isShowDeadConfirmPopup: boolean = false;
  isShowOutConfirmPopup: boolean = false;
  isLoading: boolean = false;
  isProcessing: boolean = false;

  genderItems = GENDER_ITEMS;
  GENERAL_MESSAGE = GENERAL_MESSAGE;
  AppLeaguerStatus = AppLeaguerStatus;
  subscription: Subscription = new Subscription();

  constructor(private leaguerService: LeaguerService,
              private router: Router,
              private lookupService: LookupService,
              private loggedUserService: LoggedUserService) {
    this.subscription.add(
      this.lookupService.lookup.subscribe(lookup => {
        this.units = lookup.units;
        this.statuses = lookup.statuses;
      }));
    this.loggedUser = this.loggedUserService.loggedUser;
  }

  ngOnInit() {
    this.getAllStaffs();
  }

  getAllStaffs() {
    this.dataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        return this.leaguerService.getAllLeaguers(loadOptions).toPromise();
      }
    });
  }

  contentReady(e) {
    if (!e.component.getSelectedRowKeys().length) {
      e.component.selectRowsByIndexes(0);
    }
  }

  selectionChanged(e) {
    e.component.collapseAll(-1);
    e.component.expandRow(e.currentSelectedRowKeys[0]);
    this.selectedLeaguer = e.currentSelectedRowKeys[0];
    // set avatar
    if (this.selectedLeaguer && this.selectedLeaguer.avatarId) {
      this.selectedLeaguer.avatarImg = AttachmentModel.getImageLink(this.selectedLeaguer.avatarId, this.selectedLeaguer.id, 'avatar');
    }
  }

  goToDetail(data: LeaguerModel) {
    this.router.navigate([`/leaguer/${data.id}/detail`]).then();
  }

  exportExcel() {
    this.showProcessing();
    this.leaguerService.exportExcel().subscribe(blob => {
      saveAs(blob, `Danh sach Dang Vien So TNMT.xlsx`);
      this.hideProcessing();
    }, () => {
      this.hideProcessing();
    });
  }

  onShowAddingPopup() {
    this.selectedLeaguer = new LeaguerModel();
    this.isShowEditingPopup = true;
  }

  onSave(e: LeaguerModel) {
    this.showProcessing();
    this.leaguerService.addLeaguer(e).subscribe(res => {
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Đảng viên', this.selectedLeaguer.name));
      this.router.navigate([`/leaguer/${res}/detail`]).then();
    }, () => {
      this.hideProcessing();
    });
  }

  openDeletingConfirmPopup(leaguer, e) {
    this.selectedLeaguer = leaguer;
    if (this.deletingConfirmBox) {
      this.deletingConfirmBox.show(e.currentTarget);
    }
  }

  onDelete() {
    if (!this.selectedLeaguer) {
      return;
    }
    this.showProcessing();
    this.leaguerService.deleteLeaguer(this.selectedLeaguer.id).subscribe(() => {
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Đảng viên', this.selectedLeaguer.name));
    }, () => {
      this.hideProcessing();
    });
  }

  onShowTransferPopup(leaguer) {
    this.selectedLeaguer = leaguer;
    this.isShowTransferringPopup = true;
  }

  showConfirmOutPopup(leaguer) {
    this.selectedLeaguer = leaguer;
    this.isShowOutConfirmPopup = true;
  }

  showConfirmDeadPopup(leaguer) {
    this.selectedLeaguer = leaguer;
    this.isShowDeadConfirmPopup = true;
  }

  onCancelTransferring() {
    this.isShowTransferringPopup = true;
  }

  changeToOut() {
    this.showProcessing();
    this.leaguerService.changeToOut(this.selectedLeaguer.id).subscribe(() => {
      AppNotify.success(`Chuyển Ra khỏi Đảng đồng chí ${this.selectedLeaguer.name} thành công`);
      this.isShowOutConfirmPopup = false;
      this.hideProcessing();
    }, () => {
      this.isShowOutConfirmPopup = false;
      this.hideProcessing();
    });
  }

  changeToDead() {
    this.showProcessing();
    this.leaguerService.changeToDead(this.selectedLeaguer.id).subscribe(() => {
      AppNotify.success(`Chuyển trạng thái qua đời của đồng chí ${this.selectedLeaguer.name} thành công`);
      this.isShowDeadConfirmPopup = false;
      this.hideProcessing();
    }, () => {
      this.isShowDeadConfirmPopup = false;
      this.hideProcessing();
    });
  }

  /**
   * Utilities
   */

  refresh() {
    setTimeout(() => {
      this.getAllStaffs();
    }, 100);
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
