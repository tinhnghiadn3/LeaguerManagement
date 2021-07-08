import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DxValidationGroupComponent} from 'devextreme-angular';
import {ChangeOfficialDocumentModel, DropDownModel} from '@app/models';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {cloneDeep} from 'lodash';

@Component({
  selector: 'app-official-document',
  templateUrl: './official-document.component.html',
  styleUrls: ['./official-document.component.scss']
})
export class OfficialDocumentComponent implements OnInit {
  @ViewChild('validationGroup', {static: false}) validationGroup: DxValidationGroupComponent;

  @Input() isProcessing: boolean = false;
  @Input() selectedDocument: ChangeOfficialDocumentModel = new ChangeOfficialDocumentModel();
  @Input() types: DropDownModel[] = [];

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
  @Output() onSaveDocument: EventEmitter<ChangeOfficialDocumentModel> = new EventEmitter<ChangeOfficialDocumentModel>();

  document: ChangeOfficialDocumentModel = new ChangeOfficialDocumentModel();

  GENERAL_MESSAGE = GENERAL_MESSAGE;

  constructor() {
  }

  ngOnInit() {
    this.document = cloneDeep(this.selectedDocument);
  }

  onSave() {
    if (this.validationGroup.instance.validate().isValid) {
      this.onSaveDocument.emit(this.document);
    }
  }

  onCancel() {
    this.visible = false;
  }
}
