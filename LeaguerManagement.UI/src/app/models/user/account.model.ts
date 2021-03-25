export class AccountLoginInput {
  emailAddress: string;
  password: string;
  isKeepSignedIn: boolean = false;
  timezoneOffset: number;

  public constructor(init?: Partial<AccountLoginInput>) {
    Object.assign(this, init);
  }
}

export class ChangePassword {
  email: string;
  oldPassword: string;
  newPassword: string;
  confirmNewPassword: string;
  companyNo: number;

  public constructor(init?: Partial<ChangePassword>) {
    Object.assign(this, init);
  }
}
