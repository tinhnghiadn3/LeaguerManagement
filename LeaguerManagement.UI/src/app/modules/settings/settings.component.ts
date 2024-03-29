import {Component, OnDestroy, OnInit} from '@angular/core';
import {LoggedUserModel} from '@app/models';
import {AppRoleValue, SETTING_ITEMS, SETTING_VALUE} from '@app/shared/constants';
import {Router} from '@angular/router';
import {LoggedUserService} from '@app/services/auth';
import {LookupService} from '@app/services/shared';
import {LookupModel} from '@app/models/shared/ref.model';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit, OnDestroy {

  isSmall: boolean = false;
  loggedUser: LoggedUserModel = new LoggedUserModel();
  tabs = SETTING_ITEMS;
  selectedTab = SETTING_ITEMS[0];
  settingValue = SETTING_VALUE;
  subscription: Subscription = new Subscription();

  constructor(private router: Router,
              private loggedUserService: LoggedUserService,
              private lookupService: LookupService) {
    this.loggedUser = this.loggedUserService.loggedUser;

    this.subscription.add(
      this.lookupService.getLookup().subscribe((lookup: LookupModel) => {
        this.lookupService.setLookup(lookup);
      })
    );
  }

  ngOnInit() {
    this.getTabItemsToShow();
  }

  changeTab(tab) {
    this.selectedTab = tab;
  }

  private getTabItemsToShow() {
    if (this.tabs.length === 0) {
      this.router.navigate(['/forbidden']).then();
    }
    if (this.loggedUser.roleId === AppRoleValue.Manager) {
      this.tabs = SETTING_ITEMS.filter(_ => _.value !== SETTING_VALUE.User && _.value !== SETTING_VALUE.RoleAndAccessControl);
      this.selectedTab = this.tabs[0];
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
