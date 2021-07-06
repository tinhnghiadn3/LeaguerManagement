import {Component, Input, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {AttachmentsViewerComponent, PopoverConfirmBoxComponent} from '../index';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {AttachmentModel, ReferenceWithAttachmentModel} from '@app/models';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {DxTextBoxComponent} from 'devextreme-angular';
import {KeyCode} from '@app/shared/enums';
import {finalize} from 'rxjs/operators';
import {AttachmentService} from '@app/services/features/attachment.service';
import {ALLOWED_FILE_TYPES} from '@app/shared/constants';

@Component({
  selector: 'app-upload-attachments',
  templateUrl: 'upload-attachments.component.html',
  styleUrls: ['./upload-attachments.component.scss']
})

export class UploadAttachmentsComponent implements OnInit {
  @ViewChild('attachmentsViewer', {static: true}) attachmentsViewer: AttachmentsViewerComponent;
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('renamingTextBox', {static: false}) renamingTextBox: DxTextBoxComponent;

  @Input() leaguerId: number;

  private _data: ReferenceWithAttachmentModel<any> = new ReferenceWithAttachmentModel<any>();
  @Input()
  get data() {
    AttachmentModel.setAttachmentsList(this._data.attachments, this.leaguerId);
    return this._data;
  }

  set data(value) {
    this._data = value;
    AttachmentModel.setAttachmentsList(this._data.attachments, this.leaguerId);
  }

  @Output() onAttachmentChanged = new EventEmitter();

  selectedAttachment: AttachmentModel = new AttachmentModel();

  isShowDisagreePopup: boolean = false;
  isProcessing: boolean = false;

  allowedFileTypes = ALLOWED_FILE_TYPES;
  GENERAL_MESSAGE = GENERAL_MESSAGE;

  private validCharacters = '^[\\w\\-. ]+$';

  constructor(private attachmentService: AttachmentService) {
  }

  ngOnInit() {
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

  showAttachment(attachment: AttachmentModel) {
    this.attachmentsViewer.showAttachment(attachment);
  }

  saveNameFile(attachment: AttachmentModel, isOnRow = true) {
    if (!this.renamingTextBox || !this.renamingTextBox.instance) {
      return;
    }

    const isValueValid = this.renamingTextBox.instance.option('isValid');
    if (!isValueValid && isOnRow) {
      return;
    }

    if (isValueValid) {
      const newName = attachment.tmpName + attachment.fileExtension;
      if (newName !== attachment.fileName) {
        attachment.fileName = newName;
        this.attachmentService.renameAttachment(attachment, attachment.referenceName).subscribe(res => {
          attachment = res;
          AppNotify.success('Sửa tên file thành công ');
        });
      }
    }

    attachment.isEditing = false;
  }

  validateFileName(e) {
    const regex = new RegExp(this.validCharacters);
    if (!regex.test(e.event.key) && e.event.keyCode !== 13) {
      e.event.preventDefault();
    }
  }

  cancelEditNameByEscape(e, attachment: AttachmentModel) {
    if (e.event.keyCode === KeyCode.Escape) {
      attachment.isEditing = false;
    }
  }

  showRename(attachment: AttachmentModel) {
    this.selectedAttachment = attachment;
    attachment.isEditing = true;
    const name = attachment.fileName;
    attachment.tmpName = name.slice(0, name.lastIndexOf('.'));
    if (!attachment.isDeleting) {
      setTimeout(() => {
        if (this.renamingTextBox) {
          this.renamingTextBox.instance.focus();
        }
      }, 100);
    }
  }

  deleteAttachment() {
    const model = this._data;
    this.selectedAttachment.isDeleting = true;
    this.showProcessing();
    this.attachmentService.deleteAttachment(this.selectedAttachment.referenceId,
      this.selectedAttachment.id, this.selectedAttachment.referenceName).pipe(
      finalize(() => {
        this.hideProcessing();
        this.selectedAttachment.isDeleting = false;
      }))
      .subscribe(() => {
        if (!model || !model.attachments || !model.attachments.length) {
          return;
        }
        const index = AttachmentModel.removeAttachment(model, this.selectedAttachment.id);
        //
        // Select another or close
        this.attachmentsViewer.selectAnotherAttachmentOrClose(index, this.selectedAttachment);

        AppNotify.success('Xóa file thành công ');
      });
  }

  confirmDelete(event, attachment: AttachmentModel) {
    if (!event || !attachment || !this.deletingConfirmBox || !this._data) {
      return;
    }

    this.selectedAttachment = attachment;
    this.deletingConfirmBox.show(event.currentTarget);
  }
}
