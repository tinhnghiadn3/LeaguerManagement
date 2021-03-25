import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';

import {AuthenticationService} from '@app/services/auth';
import {LoggedUserModel} from '@app/models';

@Component({
  selector: 'app-user-panel',
  templateUrl: 'user-panel.component.html',
  styleUrls: ['./user-panel.component.scss']
})

export class UserPanelComponent implements OnDestroy {

  currentUser: LoggedUserModel = new LoggedUserModel();
  subscription: Subscription = new Subscription();
  isShowingPopup: boolean = false;
  isShowingUserDetail: boolean = false;

  menuItems = [];

  constructor(private authService: AuthenticationService) {
    this.subscription.add(
      this.authService.currentUser.subscribe((user) => {
        this.currentUser = user;
        this.menuItems = [
          {
            text: this.currentUser?.name,
            icon: '',
            onClick: () => {
            }
          },
          {
            text: 'Đổi mật khẩu',
            icon: 'fas fa-user',
            onClick: () => {
              this.isShowingPopup = true;
            }
          },
          {
            text: 'Đăng xuất',
            icon: 'fas fa-sign-out-alt',
            onClick: () => {
              this.authService.logout();
              this.isShowingUserDetail = false;
            }
          }
        ];
      }));
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
