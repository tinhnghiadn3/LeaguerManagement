export class LoggedUserModel {
  id: number;
  name: string;
  email: string;
  unitId: number;
  roleId: number;
  accessControlIds: number[] = [];

  public constructor(init?: Partial<LoggedUserModel>) {
    Object.assign(this, init);
  }
}
