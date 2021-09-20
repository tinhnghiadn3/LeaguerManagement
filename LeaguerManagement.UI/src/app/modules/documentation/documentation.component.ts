import {Component, OnInit, ViewChild} from '@angular/core';
import {DocumentationModel, LoggedUserModel, ReferenceWithAttachmentModel} from '@app/models';
import {DocumentationService} from '@app/services/features/documentation.service';
import {ALLOWED_FILE_TYPES, AppRoleValue} from '@app/shared/constants';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {isEqual} from 'lodash';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components';
import {API_ENDPOINT} from '@app/services/endpoints';
import {LoggedUserService} from '@app/services/auth';

@Component({
  selector: 'app-documentation',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.scss']
})
export class DocumentationComponent implements OnInit {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;

  isLoading: boolean = false;
  isProcessing: boolean = false;
  isShowEditingPopup: boolean = false;
  allowEditing: boolean = false;

  documentations: ReferenceWithAttachmentModel<DocumentationModel>[] = [];
  selectedDocumentation: DocumentationModel = new DocumentationModel();
  loggedUser: LoggedUserModel = new LoggedUserModel();

  endPoint: string = API_ENDPOINT.Documentations;
  ALLOWED_FILE_TYPES = ALLOWED_FILE_TYPES;
  GENERAL_MESSAGE = GENERAL_MESSAGE;
  appRoleValue = AppRoleValue;

  constructor(private documentationService: DocumentationService,
              private loggedUserService: LoggedUserService) {
    this.loggedUser = this.loggedUserService.loggedUser;
    this.allowEditing = this.loggedUser.roleId === AppRoleValue.Admin || this.loggedUser.roleId === AppRoleValue.Manager;
  }

  ngOnInit() {
    this.getDocumentations();
  }

  getDocumentations() {
    this.isLoading = true;
    this.documentationService.getDocumentations().subscribe(res => {
      this.documentations = res;
      this.isLoading = false;
    }, () => {
      this.isLoading = false;
    });
  }

  onAdded(e) {
    const adding: DocumentationModel = e;
    adding.id = 0;
    this.showProcessing();
    this.documentationService.addDocumentation(adding).subscribe(() => {
      this.isShowEditingPopup = false;
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Tài liệu', adding.name));
      this.refresh();
    }, () => {
      this.hideProcessing();
      this.refresh();
    });
  }

  onUpdated(e) {
    const updating: DocumentationModel = e;
    updating.name = updating.name.trim();
    if (isEqual(updating, this.selectedDocumentation)) {
      this.isShowEditingPopup = false;
      return;
    }
    this.showProcessing();
    this.documentationService.updateDocumentation(updating).subscribe(() => {
      this.hideProcessing();
      this.isShowEditingPopup = false;
      AppNotify.success(GENERAL_MESSAGE.UPDATE_SUCCESS.format('Tài liệu', updating.name));
      this.refresh();
    }, () => {
      this.hideProcessing();
      this.refresh();
    });
  }

  openDeletingConfirmPopup(type: DocumentationModel, e) {
    this.selectedDocumentation = type;
    if (this.deletingConfirmBox) {
      this.deletingConfirmBox.show(e.currentTarget);
    }
  }

  onDelete() {
    if (!this.selectedDocumentation) {
      return false;
    }
    this.showProcessing();
    this.documentationService.deleteDocumentation(this.selectedDocumentation.id).subscribe(() => {
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Tài liệu', this.selectedDocumentation.name));
      this.refresh();
    }, () => {
      this.hideProcessing();
    });
  }

  onShowEditingPopup(data: DocumentationModel = null) {
    this.selectedDocumentation = data || new DocumentationModel();
    this.isShowEditingPopup = true;
  }

  onSave(e: DocumentationModel) {
    if (!e.id || e.id === 0) {
      this.onAdded(e);
    } else {
      this.onUpdated(e);
    }
  }

  addAttachment(fileInput: HTMLInputElement, data) {
    if (!data || !data.reference || !data.reference.id) {
      AppNotify.warning('Lưu mới trước khi tải tệp đính kèm');
      return;
    }
    fileInput.click();
  }

  uploadDocumentationAttachment(e, data) {
    if (!e || !e.target || !e.target.files || !e.target.files.length || !data || !data.reference.id) {
      return;
    }
    this.documentationService.uploadDocumentationAttachment(e.target.files, data).then();
    // Clear file selection
    e.target.value = null;
  }

  /**
   * Utilites
   */

  refresh() {
    setTimeout(() => {
      this.getDocumentations();
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
}
