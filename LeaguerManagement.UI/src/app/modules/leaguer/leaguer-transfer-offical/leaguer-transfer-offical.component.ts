import {Component, EventEmitter, Input, OnDestroy, OnInit, Output} from '@angular/core';
import {
  AppliedDocumentModel,
  ChangeOfficialDocumentModel,
  DropDownModel,
  LeaguerModel,
  ReferenceWithAttachmentModel
} from '@app/models';
import {LookupService} from '@app/services/shared';
import {Subscription} from 'rxjs';
import {LeaguerService} from '@app/services/features/leaguer.service';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {ALLOWED_FILE_TYPES} from '@app/shared/constants';

@Component({
  selector: 'app-leaguer-transfer-offical',
  templateUrl: './leaguer-transfer-offical.component.html',
  styleUrls: ['./leaguer-transfer-offical.component.scss']
})
export class LeaguerTransferOfficalComponent implements OnInit, OnDestroy {

  @Input() selectedLeaguer: LeaguerModel = new LeaguerModel();

  private _visible = false;
  @Input()
  get visible(): boolean {
    return this._visible;
  }

  set visible(value: boolean) {
    this._visible = value;
    this.visibleChange.emit(value);
  }

  @Output() visibleChange = new EventEmitter();
  @Output() onHidden: EventEmitter<boolean> = new EventEmitter<boolean>();

  officialDocuments: ChangeOfficialDocumentModel[] = [];
  officialDocumentTypes: DropDownModel[] = [];
  appliedDocuments: ReferenceWithAttachmentModel<AppliedDocumentModel>[] = [];

  isLoading: boolean = false;
  isProcessing: boolean = false;
  subscription: Subscription = new Subscription();

  ALLOWED_FILE_TYPES = ALLOWED_FILE_TYPES;

  constructor(private lookupService: LookupService,
              private leaguerService: LeaguerService) {
    this.subscription.add(
      this.lookupService.lookup.subscribe(lookup => {
        this.officialDocuments = lookup.changeOfficialDocuments;
        this.officialDocumentTypes = lookup.changeOfficialDocumentTypes;
      })
    );
  }

  ngOnInit() {
    this.getAppliedDocuments();
  }

  getAppliedDocuments() {
    this.isLoading = true;
    this.leaguerService.getOfficialDocuments(this.selectedLeaguer.id).subscribe(res => {
      this.appliedDocuments = res;
      this.isLoading = false;
    }, () => {
      this.isLoading = false;
    });
  }

  addAttachment(fileInput: HTMLInputElement, data) {
    if (!data || !data.reference || !data.reference.id) {
      AppNotify.warning('Lưu mới danh sách trước khi tải tệp đính kèm');
      return;
    }
    fileInput.click();
  }

  uploadOfficialAttachment(e, data) {
    if (!e || !e.target || !e.target.files || !e.target.files.length || !data || !data.reference.id) {
      return;
    }
    this.leaguerService.uploadOfficialAttachment(e.target.files, data).then();
    // Clear file selection
    e.target.value = null;
  }

  validateBeforeChanging(): boolean {
    return this.appliedDocuments.some(_ => _.reference.changeOfficialDocumentTypeId !== 3 && !_.attachments.length);
  }

  changeOfficial() {
    // if (this.validateBeforeChanging()) {
    //   AppNotify.warning('Chưa cung cấp đủ Giấy tờ/Biểu mẫu');
    //   return;
    // }
    this.showProcessing();
    this.leaguerService.changeToOfficial(this.selectedLeaguer.id).subscribe(() => {
      AppNotify.success(`Công nhận đồng chí ${this.selectedLeaguer.name} là Đảng viên chính thức thành công`);
      this.visible = false;
      this.hideProcessing();
    }, () => {
      this.hideProcessing();
    });
  }

  cancel() {
    this.visible = false;
  }

  /**
   * Utilities
   */

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
