import {Component, Input, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {isEqual} from 'lodash';
import {UserEditingComponent} from '@app/modules/settings/user/user-editing/user-editing.component';
import {DropDownModel, LoggedUserModel, UserModel} from '@app/models';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {SettingsService} from '@app/services/features';
import {LoggedUserService} from '@app/services/auth';
import {AppNotify} from '@app/shared/utilities/notification-helper';
import {LookupService} from '@app/services/shared/lookup.service';
import {Subscription} from 'rxjs';
import DataSource from 'devextreme/data/data_source';
import {AppRoleValue} from '@app/shared/constants';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit, OnDestroy {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('editingComponent', {static: true}) editingComponent: UserEditingComponent;

  @Input() pageSize = 20;
  @Input() isAllowSettingAdminUser: boolean = false;

  userDataSource: DataSource;
  users: UserModel[] = [];
  roles: DropDownModel[] = [];
  units: DropDownModel[] = [];

  currentUser: LoggedUserModel = new LoggedUserModel();
  selectedUser: UserModel = new UserModel();

  isShowEditingPopup = false;

  isProcessing = false;

  GENERAL_MESSAGE = GENERAL_MESSAGE;
  AppRoleValue = AppRoleValue;
  subscription: Subscription = new Subscription();

  constructor(private settingsService: SettingsService,
              private lookupService: LookupService,
              private loggedUserService: LoggedUserService) {
    this.currentUser = this.loggedUserService.loggedUser;
    this.subscription.add(
      this.lookupService.lookup.subscribe(lookup => {
        this.roles = lookup.roles;
        this.units = lookup.units;
      }));
  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.userDataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        return this.settingsService.getUsers(loadOptions).toPromise();
      }
    });
  }

  refresh() {
    setTimeout(() => {
      this.getUsers();
    }, 100);
  }

  showProcessing() {
    setTimeout(() => {
      this.isProcessing = true;
    });
  }

  hideProcessing() {
    setTimeout(() => {
      this.isProcessing = false;
    });
  }

  onAdded(e) {
    const adding: UserModel = e;
    adding.id = 0;
    this.showProcessing();
    this.settingsService.addUser(adding).subscribe(() => {
      this.isShowEditingPopup = false;
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Người dùng', adding.name));
      this.refresh();
    }, () => {
      this.hideProcessing();
      this.refresh();
    });
  }

  onUpdated(e) {
    const updating: UserModel = e;
    updating.name = updating.name.trim();
    updating.email = updating.email.trim();
    if (isEqual(updating, this.selectedUser)) {
      this.isShowEditingPopup = false;
      return;
    }
    this.showProcessing();
    this.settingsService.updateUser(updating).subscribe(() => {
      this.hideProcessing();
      this.isShowEditingPopup = false;
      AppNotify.success(GENERAL_MESSAGE.UPDATE_SUCCESS.format('Người dùng', updating.name));
      this.refresh();
    }, () => {
      this.hideProcessing();
      this.refresh();
    });
  }

  openDeletingConfirmPopup(type: UserModel, e) {
    this.selectedUser = type;
    if (this.deletingConfirmBox) {
      this.deletingConfirmBox.show(e.currentTarget);
    }
  }

  onDelete() {
    if (!this.selectedUser) {
      return false;
    }
    this.showProcessing();
    this.settingsService.deleteUser(this.selectedUser.id).subscribe(() => {
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Người dùng', this.selectedUser.name));
      this.refresh();
    }, () => {
      this.hideProcessing();
    });
  }

  onShowEditingPopup(data: UserModel = null) {
    this.selectedUser = data || new UserModel();
    this.selectedUser.id = data && data.id ? data.id : 0;
    this.isShowEditingPopup = true;
  }

  onSave(e: UserModel) {
    if (!e.id || e.id === 0) {
      this.onAdded(e);
    } else {
      this.onUpdated(e);
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
