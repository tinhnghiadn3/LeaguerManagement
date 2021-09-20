import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AttachmentModel, DocumentationModel, LeaguerModel, ReferenceWithAttachmentModel} from '@app/models';
import {API_ENDPOINT} from '@app/services/endpoints';
import {ApiService} from '@app/services/shared';
import {AttachmentService} from '@app/services/features/attachment.service';

@Injectable({
  providedIn: 'root'
})

export class DocumentationService {

  constructor(private baseService: ApiService,
              private attachmentService: AttachmentService) {
  }

  /**
   * Documentation
   */

  getDocumentations(): Observable<ReferenceWithAttachmentModel<DocumentationModel>[]> {
    return this.baseService.get(`${API_ENDPOINT.Documentations}`);
  }

  addDocumentation(adding: DocumentationModel): Observable<number> {
    return this.baseService.post(`${API_ENDPOINT.Documentations}`, adding);
  }

  updateDocumentation(updating: DocumentationModel): Observable<boolean> {
    return this.baseService.update(`${API_ENDPOINT.Documentations}`, updating);
  }

  deleteDocumentation(documentationId: number) {
    return this.baseService.delete(`${API_ENDPOINT.Documentations}/${documentationId}`);
  }

  uploadDocumentationAttachment(files: File[], uploading: ReferenceWithAttachmentModel<LeaguerModel>): Promise<AttachmentModel[]> {
    const url = `${API_ENDPOINT.Documentations}/${uploading.reference.id}/attachments`;
    return this.attachmentService.uploadAttachment(files, uploading, url);
  }
}
