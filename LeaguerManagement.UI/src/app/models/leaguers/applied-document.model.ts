export class AppliedDocumentModel {
  id: number;
  leaguerId: number;
  name: string;
  officialDocumentId: number;
  //
  changeOfficialDocumentTypeId: number;

  constructor(init?: Partial<AppliedDocumentModel>) {
    Object.assign(this, init);
  }
}
