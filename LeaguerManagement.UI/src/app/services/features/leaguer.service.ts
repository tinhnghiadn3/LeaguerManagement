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

  getAllStaffs(loadOptions: LoadOptions): Observable<SearchResultBaseModel<LeaguerModel[]>> {
    return this.baseService.post(`${API_ENDPOINT.Leaguers}/search`, loadOptions);
  }
  //
  // checkExistConfirmData(data: CheckingExistDataModel): Observable<number> {
  //   return this.baseService.post(`${API_ENDPOINT.Staffs}/confirm/check`, data);
  // }
  //
  // checkExistCopyData(certificateNumber: string): Observable<number> {
  //   return this.baseService.update(`${API_ENDPOINT.Staffs}/copy/check/${certificateNumber}`);
  // }

  deleteCartography(fileId: number) {
    return this.baseService.delete(`${API_ENDPOINT.Leaguers}/cartography/${fileId}`);
  }
}
