import {ModuleWithProviders, NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {AutoFocusInputDirective} from './directives';
import {DeviceDetectorPipe} from './pipes/device-detector.pipe';
import {
  ErrorComponent,
  ForbiddenComponent,
  HeaderComponent,
  PopupContainerComponent,
  SideNavigationMenuComponent,
  UserPanelComponent
} from './components';
import {DefaultLayoutComponent, SingleCardLayoutComponent} from './layouts';
import {DeviceDetectorService} from '@app/services/shared';

import {
  DxButtonModule,
  DxContextMenuModule,
  DxDataGridModule,
  DxDrawerModule,
  DxListModule,
  DxLoadPanelModule,
  DxLookupModule,
  DxNumberBoxModule,
  DxPopoverModule,
  DxPopupModule,
  DxProgressBarModule,
  DxRadioGroupModule,
  DxScrollViewModule,
  DxSelectBoxModule,
  DxTextAreaModule,
  DxTextBoxModule,
  DxToolbarModule,
  DxTreeViewModule,
  DxValidationGroupModule,
  DxValidatorModule,
  DxTabsModule,
  DxDateBoxModule, DxCheckBoxModule
} from 'devextreme-angular';
import {ChangePasswordComponent} from '@app/theme/components/change-password/change-password.component';

//
//
const DEVEXTREME_MODULES = [
  DxDataGridModule,
  DxButtonModule,
  DxLoadPanelModule,
  DxTextAreaModule,
  DxValidationGroupModule,
  DxSelectBoxModule,
  DxTextBoxModule,
  DxNumberBoxModule,
  DxValidatorModule,
  DxRadioGroupModule,
  DxScrollViewModule,
  DxDrawerModule,
  DxTreeViewModule,
  DxPopoverModule,
  DxPopupModule,
  DxContextMenuModule,
  DxToolbarModule,
  DxProgressBarModule,
  DxListModule,
  DxLookupModule,
  DxTabsModule,
  DxDateBoxModule,
  DxCheckBoxModule
];
//
const BASE_MODULES = [
  CommonModule,
  RouterModule,
  FormsModule,
  ReactiveFormsModule
];

// Components for this module only
const COMPONENTS = [
  //
  ErrorComponent,
  ForbiddenComponent,
  //
  //
  SingleCardLayoutComponent,
  DefaultLayoutComponent,
  PopupContainerComponent,
  UserPanelComponent,
  SideNavigationMenuComponent,
  HeaderComponent,
  ChangePasswordComponent
];

// Components to share with others
const SHARED_COMPONENTS = [
  // PopupContainerComponent
];
//
const DIRECTIVES = [
  AutoFocusInputDirective
];
//
const PIPES = [
  DeviceDetectorPipe
];

const PROVIDERS = [
  DeviceDetectorService,
];

@NgModule({
  imports: [
    ...DEVEXTREME_MODULES,
    ...BASE_MODULES
  ],
  declarations: [
    ...DIRECTIVES,
    ...PIPES,
    ...COMPONENTS,
    ...SHARED_COMPONENTS,
  ],
  exports: [
    ...DEVEXTREME_MODULES,
    ...BASE_MODULES,
    ...DIRECTIVES,
    ...PIPES,
    ...COMPONENTS
  ],
  providers: [
    ...PROVIDERS,
  ]
})
export class ThemeModule {
  static forRoot(): ModuleWithProviders<ThemeModule> {
    return {
      ngModule: ThemeModule,
      providers: [...PROVIDERS],
    } as ModuleWithProviders<ThemeModule>;
  }
}
