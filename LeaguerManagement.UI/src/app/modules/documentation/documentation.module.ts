import { NgModule } from '@angular/core';
import { DocumentationComponent } from './documentation.component';
import {ThemeModule} from '@app/theme/theme.module';
import {SharedModule} from '@app/shared/shared.module';
import {RouterModule} from '@angular/router';


@NgModule({
  declarations: [DocumentationComponent],
  imports: [
    ThemeModule,
    SharedModule,
    RouterModule.forChild([
      {path: '', component: DocumentationComponent}
    ]),
  ]
})
export class DocumentationModule { }
