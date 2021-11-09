import {ApiService} from '@app/services/shared';
import {Observable} from 'rxjs';
import {API_ENDPOINT} from '@app/services/endpoints';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  constructor(private baseService: ApiService) {
  }

  export5BTC(year: number): Observable<Blob> {
    return this.baseService.download(`${API_ENDPOINT.Statistics}/5btc/${year}`);
  }

  export4TW(year: number): Observable<Blob> {
    return this.baseService.download(`${API_ENDPOINT.Statistics}/4tw/${year}`);
  }
}
