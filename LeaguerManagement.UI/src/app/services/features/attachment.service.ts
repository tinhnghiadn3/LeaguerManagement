import {Injectable} from '@angular/core';
import {AttachmentModel, ReferenceWithAttachmentModel} from '@app/models';
import {API_ENDPOINT} from '@app/services/endpoints';
import {Observable} from 'rxjs';
import {ApiService} from '@app/services/shared';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {HttpEventType, HttpResponse} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AttachmentService {

  constructor(private baseService: ApiService) {
  }


  uploadAttachment(files: File[], uploading: ReferenceWithAttachmentModel<any>, url: string,
                   propertyName = 'attachments'): Promise<AttachmentModel[]> {
    const counting = files.length > 1 ? (files.length + ' files') : ('1 file');
    return new Promise((resolve, reject) => {
      uploading.isUploading = true;
      this.baseService.postFile(url, files).subscribe((event) => {
        if (event.type === HttpEventType.UploadProgress) {
          uploading.uploadingPercent = Math.round(100 * event.loaded / event.total);
        } else if (event instanceof HttpResponse) {
          uploading.uploadingPercent = 0;
          uploading.isUploading = false;
          //
          // Show success message
          AppNotify.success(`Upload ${counting} thành công`);
          //
          // Add to attachments list
          const attachments = event.body as AttachmentModel[];
          AttachmentModel.addAttachments(uploading, attachments, propertyName);

          // Resolve
          resolve(event.body as AttachmentModel[]);
        }
      }, (error) => {
        AppNotify.error((error as any).error.message);
        uploading.uploadingPercent = 0;
        uploading.isUploading = false;
        reject();
      });
    });
  }

  /**
   * Applied Attachment of File
   */

  uploadAppliedAttachment(files: File[], uploading: ReferenceWithAttachmentModel<any>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/${uploading.reference.fileId}/applied/${uploading.reference.id}/attachments`;
    return this.uploadAttachment(files, uploading, url);
  }

  /**
   * Copied Attachment of copy
   */

  uploadCopiedAttachment(files: File[], uploading: ReferenceWithAttachmentModel<any>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/copy/${uploading.reference.fileId}/document/${uploading.reference.id}/attachments`;
    return this.uploadAttachment(files, uploading, url);
  }

  renameAttachment(attachment: AttachmentModel, pathType: string): Observable<AttachmentModel> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/${pathType}/attachments/rename`, {
      attachmentId: attachment.id,
      referenceId: attachment.referenceId,
      newName: attachment.fileName
    });
  }

  deleteAttachment(referenceId: number, attachmentId: number, pathType: string) {
    return this.baseService.delete(`${API_ENDPOINT.Leaguers}/${pathType}/${referenceId}/attachments/${attachmentId}`);
  }
}
