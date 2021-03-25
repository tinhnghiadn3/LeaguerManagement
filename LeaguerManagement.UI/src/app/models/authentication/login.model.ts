export class LoginModel {
  username: string;
  password: string;
  rememberMe: boolean;
  timezoneOffset: number;

  public constructor(init?: Partial<LoginModel>) {
    Object.assign(this, init);
  }
}
