export class ApartmentModel {
  id: number;
  name: string;
  wardId: number;

  constructor(init?: Partial<ApartmentModel>) {
    Object.assign(this, init);
  }
}
