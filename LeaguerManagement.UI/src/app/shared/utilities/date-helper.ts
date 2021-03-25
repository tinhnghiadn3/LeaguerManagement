export {};

declare global {
  interface Date {

    getMonday: () => Date;

    getSunday: () => Date;

    getNextMonday: () => Date;

    getNextSunday: () => Date;

    getFirstDateOfMonth: () => Date;

    getLastDateOfMonth: () => Date;

    getFirstDateOfNextMonth: () => Date;

    getLastDateOfNextMonth: () => Date;

    specifyUTCKind: () => Date;

    getDateOnly: () => Date;

    addDays: (days: number) => Date;

    toSerializeFormatDate: () => string;

    isMonthEqualTo(date: Date): boolean;

    isBetween(from: Date, to: Date): boolean;

    isBetweenDateOnly(from: Date, to: Date): boolean;

    compareDate(date: Date): number;

  }
}

Date.prototype.getMonday = function(): Date {
  const day = this.getDay();
  const diff = this.getDate() - day + (day === 0 ? -6 : 1);
  return new Date(this.setDate(diff));
};

Date.prototype.getSunday = (): Date => {
  const sunday = new Date();
  sunday.setDate(sunday.getDate() + (7 - sunday.getDay()) % 7);

  return sunday;
};

Date.prototype.getNextMonday = (): Date => {
  const nextMonday = new Date();
  nextMonday.setDate(nextMonday.getDate() + (1 + 7 - nextMonday.getDay()) % 7);

  return nextMonday;
};

Date.prototype.getNextSunday = (): Date => {
  const nextSunday = new Date();
  nextSunday.setDate(nextSunday.getDate() + (7 + 7 - nextSunday.getDay() % 7));

  return nextSunday;
};

Date.prototype.getFirstDateOfMonth = function(): Date {
  return new Date(this.getFullYear(), this.getMonth(), 1);
};

Date.prototype.getLastDateOfMonth = function(): Date {
  return new Date(this.getFullYear(), this.getMonth() + 1, 0);
};

Date.prototype.getFirstDateOfNextMonth = function(): Date {
  return new Date(this.getFullYear(), this.getMonth() + 1, 1);
};

Date.prototype.getLastDateOfNextMonth = function(): Date {
  return new Date(this.getFullYear(), this.getMonth() + 2, 0);
};

Date.prototype.compareDate = function(date: Date): number {
  const firstDate = new Date(this.setHours(0, 0, 0, 0)).getTime();
  const secondDate = new Date(date.setHours(0, 0, 0, 0)).getTime();
  if (firstDate > secondDate) {
    return 1;
  }
  if (firstDate === secondDate) {
    return 0;
  }
  if (firstDate < secondDate) {
    return -1;
  }
};

Date.prototype.specifyUTCKind = function(): Date {
  return new Date(Date.UTC(this.getFullYear(), this.getMonth(), this.getDate()));
};

Date.prototype.getDateOnly = function(): Date {
  return new Date(this.setHours(0, 0, 0, 0));
};

Date.prototype.isBetween = function(from: Date, to: Date): boolean {
  return this >= from && this <= to;
};

Date.prototype.toSerializeFormatDate = function(): string {
  return `${this.getFullYear()}-${this.getMonth() + 1}-${this.getDate()}`;
};

Date.prototype.isBetweenDateOnly = function(from: Date, to: Date): boolean {
  from = new Date(from.getFullYear(), from.getMonth(), from.getDate());
  to = new Date(to.getFullYear(), to.getMonth(), to.getDate());
  const self = new Date(this.getFullYear(), this.getMonth(), this.getDate());
  return self >= from && self <= to;
};

Date.prototype.addDays = function(days: number) {
  // tslint:disable-next-line:radix
  this.setDate(this.getDate() + days);
  return this;
};
