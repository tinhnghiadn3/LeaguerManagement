import {ApiService} from '@app/services/shared';
import {AttachmentService} from '@app/services/features/attachment.service';
import {Observable} from 'rxjs';
import {API_ENDPOINT} from '@app/services/endpoints';

export class StatisticService {

  constructor(private baseService: ApiService,
              private attachmentService: AttachmentService) {
  }

  export5BTC(year: number): Observable<Blob> {
    return this.baseService.download(`${API_ENDPOINT.Statistic}/invoice/${year}`);
  }

  export4TW(year: number): Observable<Blob> {
    return this.baseService.download(`${API_ENDPOINT.Statistic}/invoice/${year}`);
  }
}
