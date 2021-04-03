import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-yes-no-confirm',
  templateUrl: './yes-no-confirm.component.html',
  styleUrls: ['./yes-no-confirm.component.scss']
})
export class YesNoConfirmComponent {
  @Input() question: string;
  @Input() modelName: string;

  @Output() onConfirmed: EventEmitter<any> = new EventEmitter<any>();
  @Output() onCanceled: EventEmitter<any> = new EventEmitter<any>();

  constructor() {
  }

  onConfirmClick() {
    this.onConfirmed.emit();
  }

  onCancelClick() {
    this.onCanceled.emit();
  }
}
