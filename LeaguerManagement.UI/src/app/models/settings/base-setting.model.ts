export class BaseSettingModel {
  id: number;
  name: string;

  constructor(init?: Partial<BaseSettingModel>) {
    Object.assign(this, init);
  }
}
