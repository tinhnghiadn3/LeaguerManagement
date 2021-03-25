import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DxValidationGroupComponent} from 'devextreme-angular';
import {AccessControlModel, RoleModel} from '@app/models/settings/access-control.model';
import {cloneDeep} from 'lodash';
import {GENERAL_MESSAGE} from '@app/shared/messages';

@Component({
  selector: 'app-role-edit',
  templateUrl: './role-edit.component.html',
  styleUrls: ['./role-edit.component.scss']
})
export class RoleEditComponent implements OnInit {
  @ViewChild('validationGroup', {static: false}) validationGroup: DxValidationGroupComponent;

  @Input() isProcessing: boolean = false;
  @Input() selectedRole: RoleModel = new RoleModel();
  @Input() accessControls: AccessControlModel[] = [];
  @Input() accessControlsOfRole: AccessControlModel[] = [];

  private _visible: boolean = false;
  @Input()
  get visible(): boolean {
    return this._visible;
  }

  set visible(value: boolean) {
    this._visible = value;
    this.visibleChange.emit(value);
  }

  @Output() visibleChange = new EventEmitter();
  @Output() onEditingLocationChange: EventEmitter<RoleModel> = new EventEmitter<RoleModel>();
  @Output() onHidden: EventEmitter<boolean> = new EventEmitter<boolean>();

  role: RoleModel = new RoleModel();

  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor() {
  }

  ngOnInit() {
    this.role = cloneDeep(this.selectedRole);
  }

  onSave() {
    if (this.validationGroup.instance.validate().isValid) {
      if (this.accessControlsOfRole.length > 0) {
        this.role.accessControlIds = this.accessControlsOfRole.map(_ => _.id);
      }
      this.onEditingLocationChange.emit(this.role);
    }
  }

  onCancel() {
    this.visible = false;
  }
}
