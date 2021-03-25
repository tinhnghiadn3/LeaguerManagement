export class NotificationModel {
  id: number;
  name: string;
  startDate: Date;
  endDate: Date;
  description: string;

  constructor(init?: Partial<NotificationModel>) {
    Object.assign(this, init);
  }
}
