export class HolidayModel {
  id: number;
  name: string;
  year: number | null;
  date: Date;
  isSaturday: boolean = false;
  isSunday: boolean = false;
  is11: boolean = false;
  is304: boolean = false;
  is15: boolean = false;
  is29: boolean = false;
  isSettings: boolean = false;

  constructor(init?: Partial<HolidayModel>) {
    Object.assign(this, init);
  }
}
