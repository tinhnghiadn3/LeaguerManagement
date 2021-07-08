import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {ApiService} from '@app/services/shared';
import {
  AccessOfRoleModel, BaseSettingModel, SearchResultBaseModel,
  UserModel, AccessControlModel, RoleModel, ChangeOfficialDocumentModel
} from '@app/models';
import {API_ENDPOINT} from '@app/services/endpoints';
import {LoadOptions} from 'devextreme/data/load_options';

@Injectable({
  providedIn: 'root'
})
export class SettingsService {


  constructor(private baseService: ApiService) {
  }

  /**
   * Role
   */

  getRoles(loadOptions: LoadOptions): Observable<RoleModel[]> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/roles/search`, loadOptions);
  }

  addRole(adding: RoleModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/roles`, adding);
  }

  updateRole(updating: RoleModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/roles`, updating);
  }

  deleteRole(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/roles/${id}`);
  }

  updateAccessOfRole(adding: AccessOfRoleModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/access-role`, adding);
  }

  /**
   * Access Control
   */

  getAccessControls(loadOptions: LoadOptions): Observable<SearchResultBaseModel<AccessControlModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/access-controls/search`, loadOptions);
  }

  addAccessControl(adding: AccessControlModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/access-controls`, adding);
  }

  updateAccessControl(updating: AccessControlModel): Observable<boolean> {
    return this.baseService.update(`${API_ENDPOINT.Settings}/access-controls`, updating);
  }

  deleteAccessControl(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/access-controls/${id}`);
  }

  /**
   * User
   */

  getUsers(loadOptions: LoadOptions): Observable<UserModel[]> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/users/search`, loadOptions);
  }

  addUser(adding: UserModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/users`, adding);
  }

  updateUser(updating: UserModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/users`, updating);
  }

  deleteUser(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/users/${id}`);
  }

  /**
   * Change Official Document Type
   */

  getChangeOfficialDocumentTypes(loadOptions: LoadOptions): Observable<SearchResultBaseModel<BaseSettingModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/official-document-types/search`, loadOptions);
  }

  addChangeOfficialDocumentType(adding: BaseSettingModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/official-document-types`, adding);
  }

  updateChangeOfficialDocumentType(updating: BaseSettingModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/official-document-types`, updating);
  }

  deleteChangeOfficialDocumentType(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/official-document-types/${id}`);
  }

  /**
   * Change Official Document Type
   */

  getChangeOfficialDocuments(loadOptions: LoadOptions): Observable<SearchResultBaseModel<ChangeOfficialDocumentModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/official-documents/search`, loadOptions);
  }

  addChangeOfficialDocument(adding: ChangeOfficialDocumentModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/official-documents`, adding);
  }

  updateChangeOfficialDocument(updating: ChangeOfficialDocumentModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/official-documents`, updating);
  }

  deleteChangeOfficialDocument(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/official-documents/${id}`);
  }
}
