import {ChangeOfficialDocumentModel, DropDownModel} from '@app/models';

export class LookupModel {
  roles: DropDownModel[] = [];
  units: DropDownModel[] = [];
  statuses: DropDownModel[] = [];
  changeOfficialDocumentTypes: DropDownModel[] = [];
  changeOfficialDocuments: ChangeOfficialDocumentModel[] = [];

  constructor(init?: Partial<LookupModel>) {
    Object.assign(this, init);
  }
}
