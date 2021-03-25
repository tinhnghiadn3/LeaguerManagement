export class LoggedUserModel {
  id: number;
  name: string;
  email: string;
  departmentId: number;
  departmentTypeId: number;
  unitId: number;
  roleId: number;
  accessControlIds: number[] = [];

  public constructor(init?: Partial<LoggedUserModel>) {
    Object.assign(this, init);
  }
}
