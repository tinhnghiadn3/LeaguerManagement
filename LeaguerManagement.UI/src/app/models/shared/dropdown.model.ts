export class DropDownModel {
  key: number;
  value: string;

  constructor(init?: Partial<DropDownModel>) {
    Object.assign(this, init);
  }
}
