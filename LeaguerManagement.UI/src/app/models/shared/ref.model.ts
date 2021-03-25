import {DropDownModel} from '@app/models';

export class LookupModel {
  roles: DropDownModel[] = [];
  units: DropDownModel[] = [];
  statuses: DropDownModel[] = [];

  constructor(init?: Partial<LookupModel>) {
    Object.assign(this, init);
  }
}
