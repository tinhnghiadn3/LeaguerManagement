import {EventEmitter, Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {ApiService} from './api.service';
import {cloneDeep, join} from 'lodash';
import {LookupModel} from '@app/models/shared/ref.model';
import {LookupDataType} from '@app/shared/enums';
import {API_ENDPOINT} from '@app/services/endpoints';

@Injectable({
  providedIn: 'root'
})
export class LookupService {
  private _lookup: BehaviorSubject<LookupModel> = new BehaviorSubject(new LookupModel());
  private _onLookupChange: EventEmitter<LookupModel> = new EventEmitter<LookupModel>();

  constructor(private baseService: ApiService) {
  }

  /**
   *
   * Reference Lookup
   *
   */

  get lookup(): Observable<LookupModel> {
    return this._lookup.asObservable();
  }

  private get lookups(): LookupModel {
    return this._lookup.getValue();
  }

  getLookup(lookupNames?: LookupDataType[]): Observable<LookupModel> {
    let params = '';
    if (lookupNames && lookupNames.length) {
      params = `?keys=${join(lookupNames, ',')}`;
    }

    return this.baseService.get(`${API_ENDPOINT.Settings}/lookup${params}`);
  }

  setLookup(value: LookupModel) {
    this._lookup.next(value);
    this._onLookupChange.emit(value);
  }

  reloadLookup(lookupNames?: LookupDataType[]) {
    const currentLookup = cloneDeep(this.lookups) as LookupModel;

    this.getLookup(lookupNames).subscribe((data: LookupModel) => {
      lookupNames.forEach(lookupName => {
        switch (lookupName) {
          case LookupDataType.Roles:
            currentLookup.roles = data.roles;
            break;
          case LookupDataType.Units:
            currentLookup.units = data.units;
            break;
          case LookupDataType.Statuses:
            currentLookup.statuses = data.statuses;
            break;
          default:
            break;
        }
      });

      this.setLookup(currentLookup);
    });
  }
}
