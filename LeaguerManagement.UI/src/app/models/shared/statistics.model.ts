export class StatusStatisticModel {
  statusId: number;
  statusName: string;
  amount: number;

  public constructor(init?: Partial<StatusStatisticModel>) {
    Object.assign(this, init);
  }
}
