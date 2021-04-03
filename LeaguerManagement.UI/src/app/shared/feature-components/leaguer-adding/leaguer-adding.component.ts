import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DxValidationGroupComponent} from 'devextreme-angular';
import {DropDownModel, LeaguerModel} from '@app/models';
import {cloneDeep} from 'lodash';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {GENDER_ITEMS} from '@app/shared/constants';

@Component({
  selector: 'app-leaguer-adding',
  templateUrl: './leaguer-adding.component.html',
  styleUrls: ['./leaguer-adding.component.scss']
})
export class LeaguerAddingComponent implements OnInit {
  @ViewChild('validationGroup', {static: false}) validationGroup: DxValidationGroupComponent;

  @Input() isProcessing = false;
  @Input() selectedLeaguer: LeaguerModel = new LeaguerModel();
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
  @Output() onEditingChange: EventEmitter<LeaguerModel> = new EventEmitter<LeaguerModel>();
  @Output() onHidden: EventEmitter<boolean> = new EventEmitter<boolean>();

  leaguer: LeaguerModel = new LeaguerModel();
  genderItems = GENDER_ITEMS;
  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor() {
  }

  ngOnInit() {
    this.leaguer = cloneDeep(this.selectedLeaguer);
  }

  onSave() {
    if (this.validationGroup.instance.validate().isValid) {
      this.onEditingChange.emit(this.leaguer);
    }
  }

  onCancel() {
    this.visible = false;
  }
}
