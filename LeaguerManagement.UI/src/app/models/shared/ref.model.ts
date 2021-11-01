import {ChangeOfficialDocumentModel, DropDownModel} from '@app/models';

export class LookupModel {
  roles: DropDownModel[] = [];
  units: DropDownModel[] = [];
  statuses: DropDownModel[] = [];
  changeOfficialDocumentTypes: DropDownModel[] = [];
  changeOfficialDocuments: ChangeOfficialDocumentModel[] = [];
  ratings: DropDownModel[] = [];
  years: DropDownModel[] = [];

  constructor(init?: Partial<LookupModel>) {
    Object.assign(this, init);
  }
}
