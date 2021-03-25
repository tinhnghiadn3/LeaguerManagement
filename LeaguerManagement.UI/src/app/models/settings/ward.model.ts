export class WardModel {
  id: number;
  name: string;
  districtId: number;

  constructor(init?: Partial<WardModel>) {
    Object.assign(this, init);
  }
}
