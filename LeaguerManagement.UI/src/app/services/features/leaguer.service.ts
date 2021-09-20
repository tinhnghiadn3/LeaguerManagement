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
  StatusStatisticModel, RatingResultModel,
} from '@app/models';
import {LoadOptions} from 'devextreme/data/load_options';
import {AttachmentService} from '@app/services/features/attachment.service';

@Injectable({
  providedIn: 'root'
})
export class LeaguerService {

  constructor(private baseService: ApiService,
              private attachmentService: AttachmentService) {
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
   * Rating Result
   */

  addRatingResult(adding: RatingResultModel): Observable<number> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/rating-results`, adding);
  }

  updateRatingResult(updating: RatingResultModel): Observable<boolean> {
    return this.baseService.update(`${API_ENDPOINT.Leaguers}/rating-results`, updating);
  }

  deleteRatingResult(resultId: number) {
    return this.baseService.delete(`${API_ENDPOINT.Leaguers}/rating-results/${resultId}`);
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

  uploadLeaguerAttachment(files: File[], uploading: ReferenceWithAttachmentModel<LeaguerModel>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/${uploading.reference.id}/attachments`;
    return this.attachmentService.uploadAttachment(files, uploading, url);
  }

  uploadAvatar(files: File[], uploading: ReferenceWithAttachmentModel<LeaguerModel>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/${uploading.reference.id}/avatars`;
    return this.attachmentService.uploadAttachment(files, uploading, url);
  }

  uploadOfficialAttachment(files: File[], uploading: ReferenceWithAttachmentModel<AppliedDocumentModel>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Leaguers}/${uploading.reference.id}/officials`;
    return this.attachmentService.uploadAttachment(files, uploading, url);
  }
}
