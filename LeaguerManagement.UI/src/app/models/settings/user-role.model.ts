export class UserRoleModel {
  id: number;
  name: string;

  constructor(init?: Partial<UserRoleModel>) {
    Object.assign(this, init);
  }
}
