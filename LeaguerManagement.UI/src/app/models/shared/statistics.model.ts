export class StatusStatisticsModel {
  statusId: number;
  statusName: string;
  amount: number;

  public constructor(init?: Partial<StatusStatisticsModel>) {
    Object.assign(this, init);
  }
}
