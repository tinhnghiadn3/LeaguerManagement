import {Component} from '@angular/core';
import {AccessControls, AccessControlValue} from '@app/shared/constants';
import {DeviceDetectorService} from '@app/services/shared';
import {Router} from '@angular/router';
import {AuthenticationService, LoggedUserService} from '@app/services/auth';


@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent {

  menuItems: any[] = [];
  currentMenu: any;

  constructor(private loggedUserService: LoggedUserService,
              private authService: AuthenticationService,
              private router: Router,
              public deviceService: DeviceDetectorService) {
    const permissions = loggedUserService.userPermissions;

    this.menuItems = [
      {
        text: 'Trang chủ', path: '/home', expanded: true, selected: false, childrenItem: [],
        visible: true,
      },
      {
        text: 'Đảng viên', path: '/leaguer', expanded: true, selected: false, childrenItem: [],
        visible: true,
      },
      {
        text: 'Tài liệu tham khảo', path: '/documentation', expanded: true, selected: false, childrenItem: [],
        visible: true,
      },
      {
        text: 'Tổng hợp/Thống kê', path: '/statistic', expanded: true, selected: false, childrenItem: [],
        visible: true,
      },
      {
        text: 'Cài đặt', path: '/settings', expanded: true, selected: false,
        visible: permissions.includes(AccessControls.find(_ => _.id === AccessControlValue.Settings).symbol),
        childrenItem: [
          {path: '/settings/access-controls', text: 'Phân quyền', selected: false},
          {path: '/settings/users', text: 'Người dùng', selected: false}
        ]
      },
    ];

    this.detectCurrentRoute();
  }

  detectCurrentRoute() {
    const currentUrl = this.router.url;
    this.currentMenu = this.menuItems.find(_ => currentUrl.includes(_.path));
  }
}
