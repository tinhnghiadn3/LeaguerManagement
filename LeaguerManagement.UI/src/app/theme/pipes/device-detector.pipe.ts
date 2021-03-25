import {Pipe, PipeTransform} from '@angular/core';

import {DeviceDetectorService} from '@app/services/shared';

@Pipe({
  name: 'deviceDetector'
})
export class DeviceDetectorPipe implements PipeTransform {
  constructor(protected deviceDetectorService: DeviceDetectorService) {
  }

  transform(value: boolean, size: 'mobile' | 'tablet' | 'desktop'): boolean {
    switch (size) {
      case 'mobile':
        return this.deviceDetectorService.isMobile();
      case 'tablet':
        return this.deviceDetectorService.isTablet();
      case 'desktop':
        return this.deviceDetectorService.isDesktop();
      default :
        return value;
    }
  }
}
