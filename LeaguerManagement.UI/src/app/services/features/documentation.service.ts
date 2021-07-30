import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {DocumentationModel, ReferenceWithAttachmentModel} from '@app/models';
import {API_ENDPOINT} from '@app/services/endpoints';
import {ApiService} from '@app/services/shared';

@Injectable({
  providedIn: 'root'
})

export class DocumentationService {

  constructor(private baseService: ApiService) {
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
    return this.baseService.delete(`${API_ENDPOINT.Leaguers}/${documentationId}`);
  }
}
