import {Injectable} from '@angular/core';
import {ApiService} from '@app/services/shared';
import {Observable} from 'rxjs';
import {API_ENDPOINT} from '@app/services/endpoints';
import {
  SearchResultBaseModel,
  LeaguerModel,
  ReferenceWithAttachmentModel,
  AttachmentModel,
  CheckExistDataModel,
  AppliedDocumentModel,
  StatusStatisticModel,
} from '@app/models';
import {LoadOptions} from 'devextreme/data/load_options';
import {HttpEventType, HttpResponse} from '@angular/common/http';
import {AppNotify} from '@app/shared/utilities/notification-helper';

@Injectable({
  providedIn: 'root'
})
export class LeaguerService {

  constructor(private baseService: ApiService) {
  }

  getCurrentLeaguers(loadOptions: LoadOptions): Observable<SearchResultBaseModel<LeaguerModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/current`, loadOptions);
  }

  getStatusStatistics(): Observable<StatusStatisticModel[]> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/statistic`);
  }

  getAllLeaguers(loadOptions: LoadOptions): Observable<SearchResultBaseModel<LeaguerModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/search`, loadOptions);
  }

  getLeaguer(id: number): Observable<ReferenceWithAttachmentModel<LeaguerModel>> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/${id}/detail`);
  }

  checkExistData(params: CheckExistDataModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/check`, params);
  }

  addLeaguer(adding: LeaguerModel): Observable<number> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}`, adding);
  }

  updateLeaguer(updating: LeaguerModel): Observable<number> {
    return this.baseService.update(`${API_ENDPOINT.Leaguers}`, updating);
  }

  deleteLeaguer(leagerId: number) {
    return this.baseService.delete(`${API_ENDPOINT.Leaguers}/${leagerId}`);
  }

  exportExcel(): Observable<Blob> {
    return this.baseService.download(`${API_ENDPOINT.Leaguers}/export`);
  }

  /**
   * Applied Official Document
   */

  getOfficialDocuments(leagerId: number): Observable<ReferenceWithAttachmentModel<AppliedDocumentModel>[]> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/${leagerId}/official-documents`);
  }

  changeToOfficial(leaguerId: number): Observable<boolean> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/${leaguerId}/change/official`);
  }

  changeToOut(leaguerId: number): Observable<boolean> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/${leaguerId}/change/out`);
  }

  changeToDead(leaguerId: number): Observable<boolean> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/${leaguerId}/change/dead`);
  }

  /**
   * Attachment
   */

  uploadAttachment(files: File[], uploading: ReferenceWithAttachmentModel<any>, url: string): Promise<AttachmentModel[]> {
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
          AttachmentModel.addAttachments(uploading, attachments);

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

  uploadLeaguerAttachment(files: File[], uploading: ReferenceWithAttachmentModel<LeaguerModel>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/${uploading.reference.id}/attachments`;
    return this.uploadAttachment(files, uploading, url);
  }

  uploadAvatar(files: File[], uploading: ReferenceWithAttachmentModel<LeaguerModel>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/${uploading.reference.id}/avatars`;
    return this.uploadAttachment(files, uploading, url);
  }

  uploadOfficialAttachment(files: File[], uploading: ReferenceWithAttachmentModel<AppliedDocumentModel>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/${uploading.reference.id}/officials`;
    return this.uploadAttachment(files, uploading, url);
  }
}
