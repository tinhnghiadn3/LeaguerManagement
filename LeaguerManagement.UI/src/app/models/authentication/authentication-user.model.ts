import {LoggedUserModel} from '@app/models/authentication/logged-user.model';

export class AuthenticationUserModel {
  accessToken: string;
  imageToken: string;
  refreshToken: string;
  exp: number;
  id: number;
  user: LoggedUserModel;

  public constructor(init?: Partial<AuthenticationUserModel>) {
    Object.assign(this, init);
  }
}
