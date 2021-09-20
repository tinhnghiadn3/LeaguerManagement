import {Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {
  AttachmentModel,
  CheckExistDataModel,
  DropDownModel,
  LeaguerModel,
  RatingResultModel,
  ReferenceWithAttachmentModel
} from '@app/models';
import {Subscription} from 'rxjs';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {LookupService} from '@app/services/shared';
import {LeaguerService} from '@app/services/features/leaguer.service';
import {ActivatedRoute} from '@angular/router';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {ALLOWED_AVATAR_TYPES, ALLOWED_FILE_TYPES, GENDER_ITEMS} from '@app/shared/constants';
import {isEqual, cloneDeep} from 'lodash';
import {AppLeaguerStatus} from '@app/shared/enums';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components';

@Component({
  selector: 'app-leaguer-detail',
  templateUrl: './leaguer-detail.component.html',
  styleUrls: ['./leaguer-detail.component.scss']
})
export class LeaguerDetailComponent implements OnInit, OnDestroy {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;

  data: ReferenceWithAttachmentModel<LeaguerModel> = new ReferenceWithAttachmentModel<LeaguerModel>();
  leaguer: LeaguerModel = new LeaguerModel();
  selectedResult: RatingResultModel = new RatingResultModel();

  units: DropDownModel[] = [];
  statuses: DropDownModel[] = [];
  ratings: DropDownModel[] = [];

  isLoading: boolean = false;
  isProcessing: boolean = false;
  isShowAddingRatingResultPopup: boolean = false;
  isExistData: boolean = false;
  leaguerId: number;

  now: Date = new Date();
  minDate: Date;
  maxDate: Date;
  subscription = new Subscription();

  GENDER_ITEMS = GENDER_ITEMS;
  GENERAL_MESSAGE = GENERAL_MESSAGE;
  ALLOWED_FILE_TYPES = ALLOWED_FILE_TYPES;
  ALLOWED_AVATAR_TYPES = ALLOWED_AVATAR_TYPES;
  AppLeaguerStatus = AppLeaguerStatus;

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
        this.ratings = lookup.ratings;
      }));
  }

  ngOnInit() {
    this.minDate = this.now;
    this.maxDate = this.now;
  }

  getLeaguer() {
    this.isLoading = true;
    this.leaguerService.getLeaguer(this.leaguerId).subscribe(res => {
      this.data = res;
      this.leaguer = cloneDeep(this.data.reference || new LeaguerModel());
      this.setAvatar(this.leaguer.avatarId);
      this.isLoading = false;
    }, () => {
      this.isLoading = false;
    });
  }

  setAvatar(avatarId) {
    if (avatarId) {
      this.leaguer.avatarImg = AttachmentModel.getImageLink(avatarId, this.leaguerId, 'avatar');
    }
  }

  save(validationGroup) {
    const validated = validationGroup.instance.validate();
    if (!validated.isValid || isEqual(this.leaguer, this.data.reference)) {
      return;
    }
    this.showProcessing();
    this.leaguerService.updateLeaguer(this.leaguer).subscribe(() => {
      AppNotify.success(GENERAL_MESSAGE.UPDATE_SUCCESS.format('Đảng viên', this.data.reference.name));
      this.hideProcessing();
      this.refresh();
    }, () => {
      this.hideProcessing();
    });
  }

  checkExistData() {
    if (!this.data.reference.cardNumber || !this.data.reference.cardNumber.trim()
      || isEqual(this.leaguer.cardNumber, this.data.reference.cardNumber)) {
      this.isExistData = false;
      return;
    }
    this.showProcessing();
    const params = new CheckExistDataModel({
      leaguerId: this.leaguerId,
      cardNumber: this.leaguer.cardNumber,
      leaguerName: this.leaguer.name
    });
    this.leaguerService.checkExistData(params).subscribe(res => {
      if (!res) {
        AppNotify.warning('Số thẻ Đảng viên đã tồn tại');
      }
      this.hideProcessing();
    }, () => {
      this.hideProcessing();
    });
  }

  addAttachment(fileInput: HTMLInputElement) {
    if (!this.data || !this.data.reference || !this.data.reference.id) {
      AppNotify.warning('Lưu mới hồ sơ môi trường trước khi tải lên tệp đính kèm');
      return;
    }
    fileInput.click();
  }

  validateUploadingFile(e) {
    return !(!e || !e.target || !e.target.files || !e.target.files.length || !this.data || !this.data.reference.id);
  }

  uploadLeaguerAttachment(e) {
    if (!this.validateUploadingFile(e)) {
      return;
    }
    this.leaguerService.uploadLeaguerAttachment(e.target.files, this.data).then();
    // Clear file selection
    e.target.value = null;
  }

  uploadAvatar(e) {
    if (!this.validateUploadingFile(e)) {
      return;
    }
    this.leaguerService.uploadAvatar(e.target.files, this.data).then(res => {
      this.leaguer.avatarId = res[0].id;
      this.setAvatar(res[0].id);
    });
    // Clear file selection
    e.target.value = null;
  }

  removeImg() {
    this.leaguer.avatarId = 0;
    this.leaguer.avatarImg = '';
  }

  onShowAddingRatingResultPopup(result = null) {
    this.isShowAddingRatingResultPopup = true;
    this.selectedResult = result ?? new RatingResultModel({
      leaguerId: this.leaguerId
    });
  }

  focusFirstBox(yearBox) {
    setTimeout(() => {
      yearBox.instance.focus();
    }, 100);
  }

  onSaveRatingResult(validationGroup) {
    if (!validationGroup.instance.validate().isValid) {
      return;
    }
    this.showProcessing();
    if (this.selectedResult.id) {
      this.updateRatingResult();
    } else {
      this.addRatingResult();
    }
  }

  addRatingResult() {
    this.leaguerService.addRatingResult(this.selectedResult).subscribe((res) => {
      const result = cloneDeep(this.selectedResult);
      result.id = res;
      this.leaguer.ratingResults.push(result);
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Xếp loại năm', this.selectedResult.year));
      this.isShowAddingRatingResultPopup = false;
      this.hideProcessing();
      this.refresh();
    }, () => {
      this.hideProcessing();
    });
  }

  updateRatingResult() {
    this.leaguerService.updateRatingResult(this.selectedResult).subscribe(() => {
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Xếp loại năm', this.selectedResult.year));
      this.hideProcessing();
      this.refresh();
    }, () => {
      this.hideProcessing();
    });
  }

  onConfirmDeleteRatingResult(e, result) {
    this.selectedResult = result;
    if (this.deletingConfirmBox) {
      this.deletingConfirmBox.show(e.currentTarget);
    }
  }

  onDeleteRatingResult() {
    this.showProcessing();
    this.leaguerService.deleteRatingResult(this.selectedResult.id).subscribe(() => {
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Xếp loại năm', this.selectedResult.year));
      this.hideProcessing();
      this.refresh();
    }, () => {
      this.hideProcessing();
    });
  }

  /**
   * Utilites
   */

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
