import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DxValidationGroupComponent} from 'devextreme-angular';
import {BaseSettingModel} from '@app/models';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {cloneDeep} from 'lodash';
@Component({
  selector: 'app-base-setting-editing',
  templateUrl: './base-setting-editing.component.html',
  styleUrls: ['./base-setting-editing.component.scss']
})
export class BaseSettingEditingComponent implements OnInit {
  @ViewChild('validationGroup', {static: false}) validationGroup: DxValidationGroupComponent;

  @Input() fieldLabel: string = 'Tên';
  @Input() isProcessing: boolean = false;
  @Input() selectedModel: BaseSettingModel = new BaseSettingModel();

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
  @Output() onEditingModelChange: EventEmitter<BaseSettingModel> = new EventEmitter<BaseSettingModel>();
  @Output() onHidden: EventEmitter<boolean> = new EventEmitter<boolean>();

  model: BaseSettingModel = new BaseSettingModel();

  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor() {
  }

  ngOnInit() {
    this.model = cloneDeep(this.selectedModel);
  }

  onSave() {
    if (this.validationGroup.instance.validate().isValid) {
      this.onEditingModelChange.emit(this.model);
    }
  }

  onCancel() {
    this.visible = false;
  }
}
