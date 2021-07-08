export class ChangeOfficialDocumentModel {
  id: number;
  name: string;
  changeOfficialDocumentTypeId: number;

  constructor(init?: Partial<ChangeOfficialDocumentModel>) {
    Object.assign(this, init);
  }
}
