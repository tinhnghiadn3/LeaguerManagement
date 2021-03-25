export class ChangePasswordModel {
  email: string;
  currentPass: string;
  newPass: string;
  confirmPass: string;

  public constructor(init?: Partial<ChangePasswordModel>) {
    Object.assign(this, init);
  }
}

