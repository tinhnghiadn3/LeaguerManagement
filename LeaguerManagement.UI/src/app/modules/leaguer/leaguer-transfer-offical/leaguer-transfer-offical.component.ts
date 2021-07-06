import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {LeaguerModel} from '@app/models';

@Component({
  selector: 'app-leaguer-transfer-offical',
  templateUrl: './leaguer-transfer-offical.component.html',
  styleUrls: ['./leaguer-transfer-offical.component.scss']
})
export class LeaguerTransferOfficalComponent implements OnInit {


  @Input() isProcessing = false;
  @Input() selectedLeaguer: LeaguerModel = new LeaguerModel();

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
  @Output() onHidden: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() {
  }

  ngOnInit(): void {
  }

}
