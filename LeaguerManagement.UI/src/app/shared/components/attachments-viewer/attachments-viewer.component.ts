import {Component, EventEmitter, Injector, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DxPopupComponent} from 'devextreme-angular';
import {DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';
import {AttachmentModel} from '@app/models';
import {LeaguerService} from '@app/services/features/leaguer.service';

@Component({
  selector: 'app-attachments-viewer',
  templateUrl: './attachments-viewer.component.html',
  styleUrls: ['./attachments-viewer.component.scss']
})
export class AttachmentsViewerComponent implements OnInit {
  @ViewChild('attachmentPopup', {static: true}) attachmentPopup: DxPopupComponent;

  @Input() attachments: AttachmentModel[] = [];
  @Input() constructionId: number;

  private _selectedAttachment: AttachmentModel;
  @Input()
  get selectedAttachment(): AttachmentModel {
    return this._selectedAttachment;
  }

  set selectedAttachment(value: AttachmentModel) {
    this._selectedAttachment = value;
    if (value) {
      AttachmentModel.setAttachmentsList([value], this.constructionId);
    }

    this.selectedAttachmentChange.emit(value);
  }

  @Output() selectedAttachmentChange = new EventEmitter();

  url: SafeResourceUrl;

  constructor(private injector: Injector,
              private fileService: LeaguerService,
              private sanitizer: DomSanitizer) {
  }

  ngOnInit() {
    this.url = this.sanitizer.bypassSecurityTrustResourceUrl('1');
  }

  showAttachment(a: AttachmentModel) {
    if (!a || a.isDeleting || !this.attachmentPopup) {
      return;
    }

    this.selectedAttachment = a;
    const link = AttachmentModel.getPreviewLink(a.id, this.constructionId, a.referenceName);
    this.url = this.sanitizer.bypassSecurityTrustResourceUrl(link);
    if (!this.attachmentPopup.instance.option('visible')) {
      this.attachmentPopup.instance.show();
    }
  }

  haveNextAttachment(): boolean {
    if (!this.attachments || !this.attachments.length || !this.selectedAttachment) {
      return false;
    }

    const index = this.attachments.indexOf(this.selectedAttachment);

    return this.attachments.length > index + 1;
  }

  havePreviousAttachment(): boolean {
    if (!this.attachments || !this.attachments.length || !this.selectedAttachment) {
      return false;
    }

    const index = this.attachments.indexOf(this.selectedAttachment);

    return index !== 0;
  }

  openNextAttachment() {
    if (!this.haveNextAttachment()) {
      return;
    }

    const index = this.attachments.indexOf(this.selectedAttachment);
    const attachment = this.attachments[index + 1];

    this.showAttachment(attachment);
  }

  openPreviousAttachment() {
    if (!this.havePreviousAttachment()) {
      return;
    }

    const index = this.attachments.indexOf(this.selectedAttachment);
    const attachment = this.attachments[index - 1];

    this.showAttachment(attachment);
  }

  close() {
    if (!this.attachmentPopup) {
      return;
    }
    this.attachmentPopup.instance.hide();
  }

  selectAnotherAttachmentOrClose(index: number, attachment: AttachmentModel) {
    if (!this.attachmentPopup.instance.option('visible')) {
      return;
    }
    const attachments = this.attachments;

    //
    // Only select another when the current attachment the one that is deleted.
    if (attachment !== this.selectedAttachment) {
      return;
    }
    //
    // Close the viewer when there is no attachment left.
    if (!attachments || !attachments.length || index < 0) {
      this.close();
      return;
    }
    //
    // Open another one
    if (attachments.length > index) {
      this.showAttachment(attachments[index]);
    } else {
      this.showAttachment(attachments[attachments.length - 1]);
    }
  }
}
