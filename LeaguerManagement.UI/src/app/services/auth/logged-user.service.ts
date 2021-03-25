import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {LoggedUserModel} from '@app/models/authentication/logged-user.model';


@Injectable()
export class LoggedUserService {
  private _currentUser: BehaviorSubject<LoggedUserModel> = new BehaviorSubject(null);
  private _currentPermissions: BehaviorSubject<string[]> = new BehaviorSubject(null);

  constructor() {
  }

  get currentUser(): Observable<LoggedUserModel> {
    return this._currentUser.asObservable();
  }

  setLoggedUser(user: LoggedUserModel) {
    this._currentUser.next(user);
  }

  get loggedUserId(): number {
    const user = this._currentUser.getValue();
    return user ? user.id : null;
  }

  get loggedUser(): LoggedUserModel {
    return this._currentUser.getValue();
  }

  /**
   * Permission
   */

  get currentPermissions(): Observable<string[]> {
    return this._currentPermissions.asObservable();
  }

  setCurrentPermissions(permissions: string[]) {
    this._currentPermissions.next(permissions);
  }

  get userPermissions(): string[] {
    return this._currentPermissions.getValue();
  }
}
