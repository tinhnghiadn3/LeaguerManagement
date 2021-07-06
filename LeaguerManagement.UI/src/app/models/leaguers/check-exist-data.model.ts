export class CheckExistDataModel {
  leaguerId: number;
  cardNumber: string;
  leaguerName: string;

  constructor(init?: Partial<CheckExistDataModel>) {
    Object.assign(this, init);
  }
}
