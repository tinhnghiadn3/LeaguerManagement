import {Component, EventEmitter, Input, OnDestroy, OnInit, Output} from '@angular/core';
import {AppliedDocumentModel, ChangeOfficialDocumentModel, DropDownModel, LeaguerModel, ReferenceWithAttachmentModel} from '@app/models';
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

  generateData() {
    this.officialDocumentTypes.forEach(type => {
      const documents = this.officialDocuments.filter(_ => _.changeOfficialDocumentTypeId === type.key);
      documents.forEach(document => {
        this.appliedDocuments.push(new ReferenceWithAttachmentModel<AppliedDocumentModel>({
          reference: new AppliedDocumentModel({
            leaguerId: this.selectedLeaguer.id,
            officialDocumentId: document.id,
            officialDocumentName: document.name,
            officialDocumentTypeId: type.key
          }),
          attachments: [],
          totalAttachments: 0,
        }));
      });
    });
  }

  addAttachment(fileInput: HTMLInputElement, data) {
    if (!data || !data.reference || !data.reference.id) {
      AppNotify.warning('Lưu mới danh sách trước khi tải tệp đính kèm');
      return;
    }
    fileInput.click();
  }

  uploadLeaguerAttachment(e, data) {
    if (!e || !e.target || !e.target.files || !e.target.files.length || !data || !data.reference.id) {
      return;
    }
    this.leaguerService.uploadLeaguerAttachment(e.target.files, data).then();
    // Clear file selection
    e.target.value = null;
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
