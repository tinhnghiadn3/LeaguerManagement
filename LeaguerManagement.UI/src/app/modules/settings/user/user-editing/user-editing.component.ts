import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {cloneDeep} from 'lodash';
import {DxValidationGroupComponent} from 'devextreme-angular';
import {DropDownModel, UserModel} from '@app/models';
import {GENERAL_MESSAGE} from '@app/shared/messages';

@Component({
  selector: 'app-user-editing',
  templateUrl: './user-editing.component.html',
  styleUrls: ['./user-editing.component.scss']
})
export class UserEditingComponent implements OnInit {
  @ViewChild('validationGroup', {static: false}) validationGroup: DxValidationGroupComponent;

  @Input() isProcessing = false;
  @Input() selectedUser: UserModel = new UserModel();
  @Input() roles: DropDownModel[] = [];
  @Input() units: DropDownModel[] = [];

  private _visible = false;
  @Input()
  get visible(): boolean {
    return this._visible;
  }

  set visible(value: boolean) {
    this._visible = value;
    this.visibleChange.emit(value);
  }

  @Output() visibleChange = new EventEmitter();
  @Output() onEditingLocationChange: EventEmitter<UserModel> = new EventEmitter<UserModel>();
  @Output() onHidden: EventEmitter<boolean> = new EventEmitter<boolean>();

  user: UserModel = new UserModel();
  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor() {
  }

  ngOnInit() {
    this.user = cloneDeep(this.selectedUser);
  }

  onSave() {
    if (this.validationGroup.instance.validate().isValid) {
      this.onEditingLocationChange.emit(this.user);
    }
  }

  onCancel() {
    this.visible = false;
  }
}
