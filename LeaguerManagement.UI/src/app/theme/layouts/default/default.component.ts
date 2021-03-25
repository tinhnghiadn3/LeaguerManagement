import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

import {DeviceDetectorService} from '@app/services/shared';

@Component({
  selector: 'app-layout-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.scss']
})
export class DefaultLayoutComponent implements OnInit {
  isUseNative: boolean;

  constructor(private router: Router, private deviceService: DeviceDetectorService) {
    this.isUseNative = deviceService.isMobile() || deviceService.isTablet();
  }

  ngOnInit() {
  }
}

