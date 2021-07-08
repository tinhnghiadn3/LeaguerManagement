import {Component, Input, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Subscription} from 'rxjs';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {isEqual} from 'lodash';
import {AppNotify} from '@app/shared/utilities/notification-helper';

import {LookupService} from '@app/services/shared';
import {LoggedUserService} from '@app/services/auth';
import {SettingsService} from '@app/services/features';
import {AccessControlModel, LoggedUserModel, RoleModel} from '@app/models';
import DataSource from 'devextreme/data/data_source';
import {LookupDataType} from '@app/shared/enums';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components';

@Component({
  selector: 'app-access-control',
  templateUrl: './access-control.component.html',
  styleUrls: ['./access-control.component.scss']
})
export class AccessControlComponent implements OnInit, OnDestroy {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('deletingAccessControlConfirmBox', {static: true}) deletingAccessControlConfirmBox: PopoverConfirmBoxComponent;

  @Input() pageSize = 20;

  roleDataSource: DataSource;
  accessControlDataSource: DataSource;
  currentUser: LoggedUserModel = new LoggedUserModel();
  selectedRole: RoleModel = new RoleModel();
  accessControls: AccessControlModel[] = [];
  selectedAccessControl: AccessControlModel = new AccessControlModel();
  accessControlsOfRole: AccessControlModel[] = [];
  selectedRowKeys: any[] = [];

  isSelectedRowKeys: boolean = false;
  isShowEditingPopup: boolean = false;
  isShowEditingAccessControlPopup: boolean = false;
  isProcessing: boolean = false;

  GENERAL_MESSAGE = GENERAL_MESSAGE;
  subscription: Subscription = new Subscription();

  constructor(private settingsService: SettingsService,
              private lookupService: LookupService,
              private loggedUserService: LoggedUserService) {
    this.currentUser = this.loggedUserService.loggedUser;
  }

  ngOnInit() {
    this.getRoles();
    this.getAccessControls();
  }

  getRoles() {
    this.roleDataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        return this.settingsService.getRoles(loadOptions).toPromise();
      }
    });
  }

  getAccessControls() {
    this.accessControlDataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        return this.settingsService.getAccessControls(loadOptions).toPromise().then(result => {
          this.accessControls = result.data;
          return {
            data: result.data || [],
            totalCount: result.totalCount
          };
        });
      }
    });
  }

  unSelectRow() {
    this.selectedRowKeys = [];
    this.accessControlsOfRole = [];
    setTimeout(() => {
      this.isSelectedRowKeys = false;
    }, 250);
  }

  refreshRoles() {
    setTimeout(() => {
      this.getRoles();
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

  onShowEditingPopup(data: RoleModel = null) {
    this.selectedRole = data || new RoleModel();
    this.selectedRole.id = data && data.id ? data.id : 0;
    this.accessControlsOfRole = this.accessControls.filter(_ => this.selectedRole.accessControlIds.includes(_.id));
    this.isShowEditingPopup = true;
  }

  onSave(e: RoleModel) {
    if (!e.id || e.id === 0) {
      this.onAdded(e);
    } else {
      this.onUpdated(e);
    }
  }

  onAdded(e) {
    const adding: RoleModel = e;
    this.showProcessing();
    this.settingsService.addRole(adding).subscribe(() => {
      this.isShowEditingPopup = false;
      this.lookupService.reloadLookup([LookupDataType.Roles]);
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Vai trò', adding.name));
      this.refreshRoles();
    }, () => {
      this.hideProcessing();
      this.refreshRoles();
    });
  }

  onUpdated(e) {
    const updating: RoleModel = e;
    updating.name = updating.name.trim();
    if (isEqual(updating, this.selectedRole)) {
      this.isShowEditingPopup = false;
      return;
    }
    this.showProcessing();
    this.settingsService.updateRole(updating).subscribe(() => {
      this.lookupService.reloadLookup([LookupDataType.Roles]);
      this.hideProcessing();
      this.isShowEditingPopup = false;
      AppNotify.success(GENERAL_MESSAGE.UPDATE_SUCCESS.format('Vai trò', updating.name));
      this.refreshRoles();
    }, () => {
      this.hideProcessing();
      this.refreshRoles();
    });
  }

  openDeletingConfirmPopup(role: RoleModel, e) {
    this.selectedRole = role;
    if (this.deletingConfirmBox) {
      this.deletingConfirmBox.show(e.currentTarget);
    }
  }

  onDelete() {
    if (!this.selectedRole) {
      return false;
    }
    this.showProcessing();
    this.settingsService.deleteRole(this.selectedRole.id).subscribe(() => {
      this.lookupService.reloadLookup([LookupDataType.Roles]);
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Vai trò', this.selectedRole.name));
      this.refreshRoles();
      this.unSelectRow();
    }, () => {
      this.hideProcessing();
    });
  }

  /**
   * Access Control
   */

  refreshAccessControls() {
    setTimeout(() => {
      this.getAccessControls();
    }, 100);
  }

  onShowEditingAccessControlPopup(data: AccessControlModel = null) {
    this.selectedAccessControl = data || new AccessControlModel();
    this.selectedAccessControl.id = data && data.id ? data.id : 0;
    this.isShowEditingAccessControlPopup = true;
  }

  onSaveAccessControl(e: AccessControlModel) {
    if (!e.id || e.id === 0) {
      this.onAddedAccessControl(e);
    } else {
      this.onUpdatedAccessControl(e);
    }
  }

  onAddedAccessControl(e) {
    const adding: AccessControlModel = e;
    this.showProcessing();
    this.settingsService.addAccessControl(adding).subscribe(() => {
      this.isShowEditingAccessControlPopup = false;
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.ADD_SUCCESS.format('Quyền', adding.name));
      this.refreshAccessControls();
    }, () => {
      this.hideProcessing();
      this.refreshAccessControls();
    });
  }

  onUpdatedAccessControl(e) {
    const updating: AccessControlModel = e;
    updating.name = updating.name.trim();
    if (isEqual(updating, this.selectedAccessControl)) {
      this.isShowEditingAccessControlPopup = false;
      return;
    }
    this.showProcessing();
    this.settingsService.updateAccessControl(updating).subscribe(() => {
      this.hideProcessing();
      this.isShowEditingAccessControlPopup = false;
      AppNotify.success(GENERAL_MESSAGE.UPDATE_SUCCESS.format('Quyền', updating.name));
      this.refreshAccessControls();
    }, () => {
      this.hideProcessing();
      this.refreshAccessControls();
    });
  }

  openDeletingAccessControlConfirmPopup(type: AccessControlModel, e) {
    this.selectedAccessControl = type;
    if (this.deletingAccessControlConfirmBox) {
      this.deletingAccessControlConfirmBox.show(e.currentTarget);
    }
  }

  onDeleteAccessControl() {
    if (!this.selectedAccessControl) {
      return false;
    }
    this.showProcessing();
    this.settingsService.deleteAccessControl(this.selectedAccessControl.id).subscribe(() => {
      this.hideProcessing();
      AppNotify.success(GENERAL_MESSAGE.DELETE_SUCCESS.format('Quyền', this.selectedAccessControl.name));
      this.refreshAccessControls();
    }, () => {
      this.hideProcessing();
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
