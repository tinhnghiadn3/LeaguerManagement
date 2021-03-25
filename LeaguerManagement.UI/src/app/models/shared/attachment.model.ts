import {AppStorage} from '@app/shared/utilities/storage';
import {environment} from '@environment';
import {IMAGE_TOKEN_KEY} from '@app/shared/constants';
import {API_ENDPOINT} from '@app/services/endpoints';
import {STORAGE} from '@app/shared/utilities/system-strings';

export class AttachmentModel {
  id: number;
  referenceId: number;
  referenceName: string;
  filePath: string;
  fileUrl: string;
  fileName: string;
  fileSize: number;
  extension: string;
  fileExtension: string;
  createdDate: string;
  createdByUserId: number | null;
  createdByName: string;
  isImage: boolean;
  //
  // UI Only
  isDeleting: boolean;
  isEditing: boolean;
  tmpName: string;
  imageLink: string;
  linkDownload: string;
  reviewLink: string;

  constructor(init?: Partial<AttachmentModel>) {
    Object.assign(this, init);
  }

  public static addAttachments(model: any, attachments: AttachmentModel[], propertyName = 'attachments'): boolean {
    let isAdded = false;
    if (attachments && attachments.length) {
      if (propertyName === 'attachments') {
        model[propertyName] = model[propertyName] || [];
        attachments.forEach(attachment => {
          const existingAtt = model[propertyName].find(_ => _.id === attachment.id);
          if (existingAtt) {
            existingAtt.fileUrl = attachment.fileUrl;
          } else {
            model[propertyName].push(attachment);
            isAdded = true;
          }
        });
        model.totalAttachments = model[propertyName].length;
      } else {
        model.reference[propertyName] = model.reference[propertyName] || [];
        attachments.forEach(attachment => {
          const existingAtt = model.reference[propertyName].find(_ => _.id === attachment.id);
          if (existingAtt) {
            existingAtt.fileUrl = attachment.fileUrl;
          } else {
            model.reference[propertyName].push(attachment);
            isAdded = true;
          }
        });
      }
    }

    return isAdded;
  }

  public static removeAttachment(model: any, fileId: number, propertyName = 'attachments'): number {
    let index: number;
    if (propertyName === 'attachments') {
      model[propertyName] = model[propertyName] || [];
      index = model[propertyName].findIndex(_ => _.id === fileId);

      if (index < 0) {
        return index;
      }

      model[propertyName].splice(index, 1);

      model.totalAttachments = model[propertyName].length;
    } else {
      model.reference[propertyName] = model.reference[propertyName] || [];
      index = model.reference[propertyName].findIndex(_ => _.id === fileId);

      if (index < 0) {
        return index;
      }

      model.reference[propertyName].splice(index, 1);
    }

    return index;
  }

  public static setAttachmentsList(attachments: AttachmentModel[], fileId: number) {
    if (!attachments || !fileId) {
      return;
    }

    attachments.forEach(a => {
      a.linkDownload = AttachmentModel.getDownloadLink(a.id, fileId, a.referenceName);
      a.imageLink = AttachmentModel.getImageLink(a.id, fileId, a.referenceName);
      a.reviewLink = AttachmentModel.getPreviewLink(a.id, fileId, a.referenceName);
    });
  }

  public static getImageLink(attachmentId: number, fileId: number, referenceName: string): string {
    return this.getFileLink(attachmentId, fileId, 'image', referenceName);
  }

  public static getDownloadLink(attachmentId: number, fileId: number, referenceName: string): string {
    return this.getFileLink(attachmentId, fileId, 'download', referenceName);
  }

  public static getPreviewLink(attachmentId: number, fileId: number, referenceName: string): string {
    const link = this.getFileLink(attachmentId, fileId, 'download', referenceName);

    return STORAGE.LINK_PREVIEW + encodeURIComponent(link);
  }

  private static getFileLink(attachmentId: number, fileId: number, path: string, type: string): string {
    if (!attachmentId) {
      return null;
    }
    const imageToken = AppStorage.getTokenData(IMAGE_TOKEN_KEY);
    const baseUrl = environment.baseUrl ? environment.baseUrl : location.origin;

    return `${baseUrl}/${API_ENDPOINT.Attachments}/${type}/${path}?fileId=${fileId}&attId=${attachmentId}&sc=${imageToken}`;
  }
}

export class ReferenceWithAttachmentModel<T> {
  reference: T;
  attachments: AttachmentModel[] = [];
  totalAttachments: number;

  //
  // Attachment
  isUploading: boolean;
  uploadingPercent: number;

  constructor(init?: Partial<ReferenceWithAttachmentModel<T>>) {
    Object.assign(this, init);
  }
}
