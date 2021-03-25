import {dxValidationGroupResult} from 'devextreme/ui/validation_group';
import {of} from 'rxjs';
import {DxValidationGroupComponent} from 'devextreme-angular';

export class DevExtremeHelper {
  static validateAsync(group: DxValidationGroupComponent): Promise<boolean> {
    if (!group || !group.instance) {
      return of(false).toPromise();
    }
    return this.waitAsyncValidate(group.instance.validate());
  }

  private static waitAsyncValidate(group: dxValidationGroupResult): Promise<boolean> {
    const validator = group;
    if (validator.status !== 'pending') {
      return of(validator.isValid).toPromise();
    }
    return (validator.complete as Promise<dxValidationGroupResult>).then(res => {
      if (res.status === 'pending') {
        return this.waitAsyncValidate(res);
      }
      return res.isValid;
    });
  }
}
