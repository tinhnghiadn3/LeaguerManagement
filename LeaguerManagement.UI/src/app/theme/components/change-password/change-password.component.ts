import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DxPopupComponent, DxTextBoxComponent, DxValidationGroupComponent} from 'devextreme-angular';
import {debounceTime, distinctUntilChanged, finalize} from 'rxjs/operators';
import {Subscription} from 'rxjs';
import {AuthenticationService} from '@app/services/auth';
import {ChangePasswordModel} from '@app/models/authentication/change-password.model';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {AppNotify} from '@app/shared/utilities/notification-helper';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  @ViewChild('changePasswordPopup', {static: true}) changePasswordPopup: DxPopupComponent;
  @ViewChild('validationGroup', {static: false}) validationGroup: DxValidationGroupComponent;
  @ViewChild('oldPasswordTextBox', {static: false}) oldPasswordTextBox: DxTextBoxComponent;
  @ViewChild('confirmPasswordTextBox', {static: false}) confirmPasswordTextBox: DxTextBoxComponent;
  @ViewChild('newPasswordTextBox', {static: false}) newPasswordTextBox: DxTextBoxComponent;

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

  password: ChangePasswordModel = new ChangePasswordModel({
    currentPass: '',
    newPass: '',
    confirmPass: ''
  });

  GENERAL_MESSAGE = GENERAL_MESSAGE;

  isChanging: boolean = false;
  isAllowChangePassword: boolean = false;

  valueChangedSubscription: Subscription;
  valueChanged = new EventEmitter<object>();

  passwordComparisonCallBack = () => this.passwordComparison();

  constructor(private authService: AuthenticationService) {
    this.valueChangedSubscription = this.valueChanged.pipe(
      debounceTime(200),
      distinctUntilChanged(),
    ).subscribe(() => {
      this.isAllowChangePassword =
        !!this.oldPasswordTextBox.value && !!this.newPasswordTextBox.value && !!this.confirmPasswordTextBox.value &&
        this.oldPasswordTextBox.isValid && this.newPasswordTextBox.isValid && this.confirmPasswordTextBox.isValid;
    });
  }

  ngOnInit() {
  }

  show() {
    if (this.validationGroup) {
      this.validationGroup.instance.reset();
    }
    this.password = new ChangePasswordModel({
      currentPass: '',
      newPass: '',
      confirmPass: ''
    });
    this.changePasswordPopup.instance.show();
  }

  passwordComparison() {
    return this.password.newPass;
  }

  userInputData() {
    this.valueChanged.next({isCheck: true});
  }

  onChange() {
    this.isChanging = true;
    const changePassword = this.password;
    changePassword.email = this.authService.loggedUser.email;
    this.authService.changePassword(this.password).pipe(
      finalize(() => this.isChanging = false))
      .subscribe(() => {
          this.visible = false;
          AppNotify.success('Cập nhật mật khẩu thành công');
      }, () => this.isChanging = false);
  }
}
