import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {AccessControlModel} from '@app/models/settings/access-control.model';
import {DxValidationGroupComponent} from 'devextreme-angular';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {cloneDeep} from 'lodash';

@Component({
  selector: 'app-access-control-edit',
  templateUrl: './access-control-edit.component.html',
  styleUrls: ['./access-control-edit.component.scss']
})
export class AccessControlEditComponent implements OnInit {
  @ViewChild('validationGroup', {static: false}) validationGroup: DxValidationGroupComponent;

  @Input() isProcessing: boolean = false;
  @Input() selectedAccessControl: AccessControlModel = new AccessControlModel();

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
  @Output() onEditingLocationChange: EventEmitter<AccessControlModel> = new EventEmitter<AccessControlModel>();
  @Output() onHidden: EventEmitter<boolean> = new EventEmitter<boolean>();

  accessControl: AccessControlModel = new AccessControlModel();

  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor() {
  }

  ngOnInit() {
    this.accessControl = cloneDeep(this.selectedAccessControl);
  }

  onSave() {
    if (this.validationGroup.instance.validate().isValid) {
      this.onEditingLocationChange.emit(this.accessControl);
    }
  }

  onCancel() {
    this.visible = false;
  }
}
