import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {ApiService} from '@app/services/shared';
import {
  AccessOfRoleModel, ApartmentModel, BaseSettingModel, NotificationModel,
  WardModel, SearchResultBaseModel,
  UserModel, AccessControlModel, RoleModel
} from '@app/models';
import {API_ENDPOINT} from '@app/services/endpoints';
import {LoadOptions} from 'devextreme/data/load_options';
import {HolidayModel} from "@app/models/settings/holiday.model";

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
   * District
   */

  getDistricts(loadOptions: LoadOptions): Observable<SearchResultBaseModel<BaseSettingModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/districts/search`, loadOptions);
  }

  getDistrict(id): Observable<BaseSettingModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/districts/${id}`);
  }

  addDistrict(adding: BaseSettingModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/districts`, adding);
  }

  updateDistrict(updating: BaseSettingModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/districts`, updating);
  }

  deleteDistrict(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/districts/${id}`);
  }

  /**
   * Street
   */

  getStreets(loadOptions: LoadOptions): Observable<SearchResultBaseModel<BaseSettingModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/streets/search`, loadOptions);
  }

  getStreet(id): Observable<BaseSettingModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/streets/${id}`);
  }

  addStreet(adding: BaseSettingModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/streets`, adding);
  }

  updateStreet(updating: BaseSettingModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/streets`, updating);
  }

  deleteStreet(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/streets/${id}`);
  }

  /**
   * DocumentType
   */

  getDocumentTypes(loadOptions: LoadOptions): Observable<SearchResultBaseModel<BaseSettingModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/document-types/search`, loadOptions);
  }

  getDocumentType(id): Observable<BaseSettingModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/document-types/${id}`);
  }

  addDocumentType(adding: BaseSettingModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/document-types`, adding);
  }

  updateDocumentType(updating: BaseSettingModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/document-types`, updating);
  }

  deleteDocumentType(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/document-types/${id}`);
  }

  /**
   * CopyType
   */

  getCopyTypes(loadOptions: LoadOptions): Observable<SearchResultBaseModel<BaseSettingModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/copy-types/search`, loadOptions);
  }

  getCopyType(id): Observable<BaseSettingModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/copy-types/${id}`);
  }

  addCopyType(adding: BaseSettingModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/copy-types`, adding);
  }

  updateCopyType(updating: BaseSettingModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/copy-types`, updating);
  }

  deleteCopyType(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/copy-types/${id}`);
  }

  /**
   * CertificateType
   */

  getCertificateTypes(loadOptions: LoadOptions): Observable<SearchResultBaseModel<BaseSettingModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/certificate-types/search`, loadOptions);
  }

  getCertificateType(id): Observable<BaseSettingModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/certificate-types/${id}`);
  }

  addCertificateType(adding: BaseSettingModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/certificate-types`, adding);
  }

  updateCertificateType(updating: BaseSettingModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/certificate-types`, updating);
  }

  deleteCertificateType(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/certificate-types/${id}`);
  }

  /**
   * Notification
   */

  getNotifications(loadOptions: LoadOptions): Observable<SearchResultBaseModel<NotificationModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/notifications/search`, loadOptions);
  }

  getNotification(id): Observable<NotificationModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/notifications/${id}`);
  }

  addNotification(adding: BaseSettingModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/notifications`, adding);
  }

  updateNotification(updating: BaseSettingModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/notifications`, updating);
  }

  deleteNotification(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/notifications/${id}`);
  }

  /**
   * Ward
   */

  getWards(loadOptions: LoadOptions): Observable<SearchResultBaseModel<WardModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/wards/search`, loadOptions);
  }

  getWard(id): Observable<WardModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/ward/${id}`);
  }

  addWard(adding: WardModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/ward`, adding);
  }

  updateWard(updating: WardModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/ward`, updating);
  }

  deleteWard(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/ward/${id}`);
  }

  /**
   * Apartment
   */

  getApartments(loadOptions: LoadOptions): Observable<SearchResultBaseModel<ApartmentModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/apartments/search`, loadOptions);
  }

  getApartment(id): Observable<ApartmentModel> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/apartments/${id}`);
  }

  addApartment(adding: ApartmentModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/apartments`, adding);
  }

  updateApartment(updating: ApartmentModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/apartments`, updating);
  }

  deleteApartment(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/apartments/${id}`);
  }

  /**
   * Holiday
   */

  getHolidays(loadOptions: LoadOptions, year: number): Observable<SearchResultBaseModel<HolidayModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/holidays/search/${year}`, loadOptions);
  }

  getHolidaySettings(year: number): Observable<HolidayModel[]> {
    return this.baseService.get(`${API_ENDPOINT.Settings}/holidays/settings/${year}`);
  }

  addHolidaySettings(adding: HolidayModel) {
    return this.baseService.post(`${API_ENDPOINT.Settings}/holidays/settings`, adding);
  }

  updateHolidaySettings(updating: HolidayModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/holidays/settings`, updating);
  }

  addHoliday(adding: HolidayModel): Observable<boolean> {
    return this.baseService.post(`${API_ENDPOINT.Settings}/holidays`, adding);
  }

  updateHoliday(updating: HolidayModel) {
    return this.baseService.update(`${API_ENDPOINT.Settings}/holidays`, updating);
  }

  deleteHoliday(id: number): Observable<boolean> {
    return this.baseService.delete(`${API_ENDPOINT.Settings}/holidays/${id}`);
  }

  /**
   * Confirm Purpose
   */

  addConfirmPurpose(adding: BaseSettingModel): Observable<boolean>{
    return this.baseService.post(`${API_ENDPOINT.Settings}/purpose/confirm`, adding);
  }
}
