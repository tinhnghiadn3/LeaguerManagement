import {Injectable} from '@angular/core';
import {ApiService} from '@app/services/shared';
import {Observable} from 'rxjs';
import {API_ENDPOINT} from '@app/services/endpoints';
import {
  SearchResultBaseModel, LeaguerModel
} from '@app/models';
import {LoadOptions} from 'devextreme/data/load_options';

@Injectable({
  providedIn: 'root'
})
export class LeaguerService {

  constructor(private baseService: ApiService) {
  }

  getCurrentLeaguers(loadOptions: LoadOptions): Observable<SearchResultBaseModel<LeaguerModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/current`, loadOptions);
  }

  getAllLeaguers(loadOptions: LoadOptions): Observable<SearchResultBaseModel<LeaguerModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/search`, loadOptions);
  }

  getLeaguer(id: number): Observable<LeaguerModel> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/${id}`);
  }

  checkExistData(cardNumber: string, id: number): Observable<boolean> {
    return this.baseService.get(`${API_ENDPOINT.Leaguers}/${id}/check/${cardNumber}`);
  }
  //
  // checkExistCopyData(certificateNumber: string): Observable<number> {
  //   return this.baseService.update(`${API_ENDPOINT.Staffs}/copy/check/${certificateNumber}`);
  // }

  addLeaguer(adding: LeaguerModel): Observable<number> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}`, adding);
  }

  updateLeaguer(updating: LeaguerModel): Observable<number> {
    return this.baseService.update(`${API_ENDPOINT.Leaguers}`, updating);
  }

  deleteCartography(fileId: number) {
    return this.baseService.delete(`${API_ENDPOINT.Leaguers}/cartography/${fileId}`);
  }
}
