import {ModuleWithProviders, NgModule} from '@angular/core';
import {AuthenticationService, AuthGuard, GuestGuard, LoggedUserService} from '@app/services/auth';
import {ApiService, AppLoadService, HelperService} from '@app/services/shared';
import {
  AttachmentsViewerComponent, BaseSettingEditingComponent,
  PopoverConfirmBoxComponent,
  PopoverTitleComponent, TabsComponent,
  UploadAttachmentsComponent, YesNoConfirmComponent,
} from './base-components';
import {ThemeModule} from '../theme/theme.module';
import {YearDatePipe} from '@app/shared/pipes/year.datepipe';
import {LeaguerAddingComponent} from '@app/shared/feature-components';

const PROVIDERS = [
  //
  AuthGuard,
  GuestGuard,
  //
  ApiService,
  HelperService,
  AppLoadService,
  AuthenticationService,
  LoggedUserService,
  //
];

const COMPONENTS = [
  //
  // BASE
  PopoverConfirmBoxComponent,
  PopoverTitleComponent,
  TabsComponent,
  AttachmentsViewerComponent,
  UploadAttachmentsComponent,
  BaseSettingEditingComponent,
  YesNoConfirmComponent,
  //
  // FEATURE
  LeaguerAddingComponent,
  //
  // PIPE
  YearDatePipe
];

@NgModule({
  imports: [
    ThemeModule
  ],
  declarations: [...COMPONENTS],
  exports: [...COMPONENTS]
})
export class SharedModule {
  static forRoot() {
    return {
      ngModule: SharedModule,
      providers: [...PROVIDERS],
    } as ModuleWithProviders<SharedModule>;
  }
}
