import {NgModule} from '@angular/core';
import {SettingsComponent} from './settings.component';
import {RouterModule} from '@angular/router';
import {SharedModule} from '@app/shared/shared.module';
import {UserComponent} from './user/user.component';
import {AccessControlComponent} from './access-control/access-control.component';
import {ThemeModule} from '@app/theme/theme.module';
import {AccessControlEditComponent} from './access-control/access-control-edit/access-control-edit.component';
import {UserEditingComponent} from '@app/modules/settings/user/user-editing/user-editing.component';
import { RoleEditComponent } from './access-control/role-edit/role-edit.component';
import { ChangeOfficialDocumentComponent } from './change-official-document/change-official-document.component';
import { OfficialDocumentComponent } from './change-official-document/official-document/official-document.component';

@NgModule({
  declarations: [
    SettingsComponent,
    UserComponent,
    UserEditingComponent,
    AccessControlComponent,
    AccessControlEditComponent,
    RoleEditComponent,
    ChangeOfficialDocumentComponent,
    OfficialDocumentComponent,
  ],
  imports: [
    ThemeModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: '', component: SettingsComponent,
      }
    ]),
  ]
})
export class SettingsModule {
}
