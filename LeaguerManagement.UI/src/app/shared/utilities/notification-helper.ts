import notify from 'devextreme/ui/notify';
import {confirm} from 'devextreme/ui/dialog';

export class AppNotify {

  private static getNotifyOption(message: string, type: string): object {
    const notifyOption = {
      message,
      width: undefined,
      position: {
        at: 'bottom center',
        my: 'bottom center',
        offset: '0 0'
      },
      animation: {
        show: {type: 'fade', duration: 400},
        hide: {
          type: 'fade', duration: 400,
          to: {opacity: 0}
        }
      }
    };

    const layoutElement = document.getElementsByTagName('app-layout-default')[0];
    const drawerElement = document.getElementsByTagName('dx-drawer')[0];
    const drawerContentElement = document.getElementsByClassName('dx-drawer-content')[0];

    if (layoutElement && drawerElement && drawerContentElement) {
      const parentContent = window.getComputedStyle(layoutElement);
      const childContent = window.getComputedStyle(drawerElement);
      const panelContentStyle = window.getComputedStyle(drawerContentElement);
      const marginRight = (parseFloat(parentContent.width) - parseFloat(childContent.width)) / 2;

      if (type === 'question') {
        notifyOption.position.offset = (-marginRight) + ' -115';
      } else {
        notifyOption.position.offset = (-marginRight) + ' 0';
      }

      notifyOption.width = parseFloat(panelContentStyle.width);
      notifyOption.position.at = 'bottom right';
      notifyOption.position.my = 'bottom right';

      return notifyOption;
    }

    if (!type) {
      return notifyOption;
    }
  }

  static info(message: string, type = null) {
    notify(this.getNotifyOption(message, type), 'info', 3000);
  }

  static warning(message: string, type = null) {
    notify(this.getNotifyOption(message, type), 'warning', 3000);
  }

  static error(message = '', type = null) {
    if (!message) {
      message = ERROR;
    }
    notify(this.getNotifyOption(message, type), 'error', 3000);
  }

  static success(message: string, type = null) {
    notify(this.getNotifyOption(message, type), 'success', 3000);
  }

  static confirm(message: string, title: string): Promise<boolean> {
    return confirm(message, title);
  }
}

export const ERROR = 'Something Bad Happened';
