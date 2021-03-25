import {Injectable} from '@angular/core';

import {ApiService} from '@app/services/shared/api.service';

@Injectable()
export class RegisterService {

  constructor(private apiService: ApiService) {
  }
}
