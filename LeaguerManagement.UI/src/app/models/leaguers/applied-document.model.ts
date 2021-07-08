export class AppliedDocumentModel {
  id: number;
  leaguerId: number;
  officialDocumentId: number;
  officialDocumentName: string;
  //
  officialDocumentTypeId: number;

  constructor(init?: Partial<AppliedDocumentModel>) {
    Object.assign(this, init);
  }
}
