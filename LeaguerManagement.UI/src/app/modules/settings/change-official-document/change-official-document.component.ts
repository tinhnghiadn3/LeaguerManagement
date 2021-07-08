import {Component, Input, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components';
import DataSource from 'devextreme/data/data_source';
import {BaseSettingModel, ChangeOfficialDocumentModel, DropDownModel} from '@app/models';
import {Subscription} from 'rxjs';
import {SettingsService} from '@app/services/features';
import {LookupService} from '@app/services/shared';
import {LookupDataType} from '@app/shared/enums';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {isEqual} from 'lodash';

@Component({
  selector: 'app-change-official-document',
  templateUrl: './change-official-document.component.html',
  styleUrls: ['./change-official-document.component.scss']
})
export class ChangeOfficialDocumentComponent implements OnInit, OnDestroy {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('deletingAccessControlConfirmBox', {static: true}) deletingTypeConfirmBox: PopoverConfirmBoxComponent;

  @Input() pageSize = 20;

  typeDataSource: DataSource;
  documentDataSource: DataSource;
  selectedType: BaseSettingModel = new BaseSettingModel();
  selectedDocument: ChangeOfficialDocumentModel = new ChangeOfficialDocumentModel();

  types: DropDownModel[] = [];

  isShowEditingPopup: boolean = false;
  isShowEditingDocumentPopup: boolean = false;
  isProcessing: boolean = false;

  GENERAL_MESSAGE = GENERAL_MESSAGE;
  subscription: Subscription = new Subscription();

  constructor(private settingsService: SettingsService,
              private lookupService: LookupService) {
    this.subscription.add(
      this.lookupService.lookup.subscribe(lookup => {
        this.types = lookup.changeOfficialDocumentTypes;
      })
    );
  }

  ngOnInit() {
    this.getChangeOfficialDocumentTypes();
    this.getChangeOfficialDocuments();
  }

  getChangeOfficialDocumentTypes() {
    this.typeDataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        return this.settingsService.getChangeOfficialDocumentTypes(loadOptions).toPromise();
      }
    });
  }

  onShowEditingPopup(data: BaseSettingModel = null) {
    this.selectedType = data || new BaseSettingModel();
    this.isShowEditingPopup = true;
  }

  onSaveType(e: BaseSettingModel) {
    if (!e.id || e.id === 0) {
      this.addChangeOfficialDocumentType(e);
    } else {
      this.updateChangeOfficialDocumentType(e);
    }
  }

  addChangeOfficialDocumentType(e) {
    const adding: BaseSettingModel = e;
    this.showProcessing();
    this.settingsService.addChangeOfficialDocumentType(adding).subscribe(() => {
      this.isShowEditingPopup = false;
      this.lookupService.reloadLookup([LookupDataType.ChangeOfficialDocumentTypes]);
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Loại giấy tờ/biểu mẫu', adding.name));
      this.refreshTypes();
    }, () => {
      this.hideProcessing();
      this.refreshTypes();
    });
  }

  updateChangeOfficialDocumentType(e) {
    const updating: BaseSettingModel = e;
    updating.name = updating.name.trim();
    if (isEqual(updating, this.selectedType)) {
      this.isShowEditingPopup = false;
      return;
    }
    this.showProcessing();
    this.settingsService.updateChangeOfficialDocumentType(updating).subscribe(() => {
      this.lookupService.reloadLookup([LookupDataType.ChangeOfficialDocumentTypes]);
      this.hideProcessing();
      this.isShowEditingPopup = false;
      AppNotify.success(GENERAL_MESSAGE.UPDATE_SUCCESS.format('Loại giấy tờ/biểu mẫu', updating.name));
      this.refreshTypes();
    }, () => {
      this.hideProcessing();
      this.refreshTypes();
    });
  }

  openDeletingConfirmPopup(base: BaseSettingModel, e) {
    this.selectedType = base;
    if (this.deletingConfirmBox) {
      this.deletingConfirmBox.show(e.currentTarget);
    }
  }

  deleteChangeOfficialDocumentType() {
    if (!this.selectedType) {
      return false;
    }
    this.showProcessing();
    this.settingsService.deleteChangeOfficialDocumentType(this.selectedType.id).subscribe(() => {
      this.lookupService.reloadLookup([LookupDataType.ChangeOfficialDocumentTypes]);
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Loại biểu mẫu/giấy tờ', this.selectedType.name));
      this.refreshTypes();
    }, () => {
      this.hideProcessing();
    });
  }

  /**
   * Access Control
   */

  getChangeOfficialDocuments() {
    this.documentDataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        return this.settingsService.getChangeOfficialDocuments(loadOptions).toPromise();
      }
    });
  }

  onShowEditingDocumentPopup(data: ChangeOfficialDocumentModel = null) {
    this.selectedDocument = data || new ChangeOfficialDocumentModel();
    this.isShowEditingDocumentPopup = true;
  }

  onSaveDocument(e: ChangeOfficialDocumentModel) {
    if (!e.id || e.id === 0) {
      this.addChangeOfficialDocument(e);
    } else {
      this.updateChangeOfficialDocument(e);
    }
  }

  addChangeOfficialDocument(e) {
    const adding: ChangeOfficialDocumentModel = e;
    this.showProcessing();
    this.settingsService.addChangeOfficialDocument(adding).subscribe(() => {
      this.isShowEditingDocumentPopup = false;
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Giấy tờ/biểu mẫu', adding.name));
      this.refreshDocuments();
    }, () => {
      this.hideProcessing();
      this.refreshDocuments();
    });
  }

  updateChangeOfficialDocument(e) {
    const updating: ChangeOfficialDocumentModel = e;
    updating.name = updating.name.trim();
    if (isEqual(updating, this.selectedDocument)) {
      this.isShowEditingDocumentPopup = false;
      return;
    }
    this.showProcessing();
    this.settingsService.updateChangeOfficialDocument(updating).subscribe(() => {
      this.hideProcessing();
      this.isShowEditingDocumentPopup = false;
      AppNotify.success(GENERAL_MESSAGE.UPDATE_SUCCESS.format('Giấy tờ/biểu mẫu', updating.name));
      this.refreshDocuments();
    }, () => {
      this.hideProcessing();
      this.refreshDocuments();
    });
  }

  openDeletingDocumentConfirmPopup(type: ChangeOfficialDocumentModel, e) {
    this.selectedDocument = type;
    if (this.deletingTypeConfirmBox) {
      this.deletingTypeConfirmBox.show(e.currentTarget);
    }
  }

  deleteChangeOfficialDocument() {
    if (!this.selectedDocument) {
      return false;
    }
    this.showProcessing();
    this.settingsService.deleteChangeOfficialDocument(this.selectedDocument.id).subscribe(() => {
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Giấy tờ/biểu mẫu', this.selectedDocument.name));
      this.refreshDocuments();
    }, () => {
      this.hideProcessing();
    });
  }

  /**
   * Utilities
   */

  refreshDocuments() {
    setTimeout(() => {
      this.getChangeOfficialDocuments();
    }, 100);
  }

  refreshTypes() {
    setTimeout(() => {
      this.getChangeOfficialDocumentTypes();
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
