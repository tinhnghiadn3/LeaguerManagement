export class SearchResultBaseModel<T> {
  data: T;
  totalCount: number = 0;

  public constructor(init?: Partial<SearchResultBaseModel<T>>) {
    Object.assign(this, init);
  }
}

export class LoadOptionModel {
  loadOptions: any;
  textFilter: string;
  typeFilter: number;

  public constructor(init?: Partial<LoadOptionModel>) {
    Object.assign(this, init);
  }
}
