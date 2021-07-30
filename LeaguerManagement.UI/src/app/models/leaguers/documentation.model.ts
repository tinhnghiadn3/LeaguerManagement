export class DocumentationModel {
  id: number;
  name: string;

  constructor(init?: Partial<DocumentationModel>) {
    Object.assign(this, init);
  }
}
