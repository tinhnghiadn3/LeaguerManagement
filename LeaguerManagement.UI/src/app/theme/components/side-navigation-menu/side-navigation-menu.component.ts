import * as events from 'devextreme/events';
import {Subscription} from 'rxjs';
import {
  Component, Output, Input, EventEmitter,
  ViewChild, ElementRef, AfterViewInit, OnDestroy, OnInit
} from '@angular/core';

import {DxTreeViewComponent} from 'devextreme-angular/ui/tree-view';
import {AuthenticationService, LoggedUserService} from '@app/services/auth';
import {DeviceDetectorService} from '@app/services/shared';
import {LoggedUserModel} from '@app/models';
import {AccessControls, AccessControlValue, AppRoleValue} from '@app/shared/constants';
import {Router} from '@angular/router';

@Component({
  selector: 'app-side-navigation-menu',
  templateUrl: './side-navigation-menu.component.html',
  styleUrls: ['./side-navigation-menu.component.scss']
})
export class SideNavigationMenuComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild(DxTreeViewComponent, {static: true}) menu: DxTreeViewComponent;

  @Output()
  selectedItemChanged = new EventEmitter<string>();

  @Output()
  openMenu = new EventEmitter<any>();

  @Input()
  set selectedItem(value: string) {
    if (this.menu.instance) {
      this.menu.instance.selectItem(value);
    }
  }

  private _compactMode = false;
  @Input()
  get compactMode() {
    return this._compactMode;
  }

  set compactMode(val) {
    this._compactMode = val;
    if (val && this.menu.instance) {
      this.menu.instance.collapseAll();
    }
  }

  items: any[];
  currentUser: LoggedUserModel = new LoggedUserModel();
  subscription: Subscription = new Subscription();
  isUseNative: boolean;

  constructor(private elementRef: ElementRef,
              private loggedUserService: LoggedUserService,
              private authService: AuthenticationService,
              private router: Router,
              private deviceService: DeviceDetectorService) {
    this.isUseNative = deviceService.isMobile() || deviceService.isTablet();
    const permissions = loggedUserService.userPermissions;

    this.items = [
      {
        text: 'Cài đặt', path: '/settings', expanded: true, selected: false,
        visible: permissions.includes(AccessControls.find(_ => _.id === AccessControlValue.Settings).symbol),
        items: [
          {path: '/settings/access-controls', text: 'Phân quyền', selected: false},
          // {path: '/settings/report-types', text: 'Loại báo cáo', selected: false},
          {path: '/settings/departments', text: 'Phòng ban', selected: false},
          // {path: '/settings/units', text: 'Đơn vị', selected: false},
          {path: '/settings/users', text: 'Người dùng', selected: false}
        ]
      },
    ];
  }

  ngOnInit() {
    this.items.forEach(item => {
      if (window.location.pathname.includes(item.path)) {
        item.selected = true;
        item.items.forEach(child => {
          child.selected = child.path === window.location.pathname;
        });
      }
    });

    this.subscription.add(this.loggedUserService.currentUser.subscribe((user) => {
      this.currentUser = user;
    }));
  }

  updateSelection(event) {
    const nodeClass = 'dx-treeview-node';
    const selectedClass = 'dx-state-selected';
    const leafNodeClass = 'dx-treeview-node-is-leaf';
    const element: HTMLElement = event.element;

    const rootNodes = element.querySelectorAll(`.${nodeClass}:not(.${leafNodeClass})`);

    Array.from(rootNodes).forEach(node => {
      node.classList.remove(selectedClass);
    });

    let selectedNode = element.querySelector(`.${nodeClass}.${selectedClass}`);
    while (selectedNode && selectedNode.parentElement) {
      if (selectedNode.classList.contains(nodeClass)) {
        selectedNode.classList.add(selectedClass);
      }

      selectedNode = selectedNode.parentElement;
    }
  }

  onItemClick(event) {
    this.selectedItemChanged.emit(event);
  }

  onMenuInitialized(event) {
    event.component.option('deferRendering', false);
  }

  logOut() {
    this.authService.logout();
  }

  ngAfterViewInit() {
    events.on(this.elementRef.nativeElement, 'dxclick', (e) => {
      this.openMenu.next(e);
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    events.off(this.elementRef.nativeElement, 'dxclick');
  }
}
