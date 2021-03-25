export class UserModel {
  id: number;
  name: string;
  email: string;
  password?: string;
  roleId: number;
  jobPosition: string;

  public constructor(init?: Partial<UserModel>) {
    Object.assign(this, init);
  }
}

