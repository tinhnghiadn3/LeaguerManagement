export class SingleOrDefaultModel<T> {
	id: number;
	value: T;

  public constructor(init?: Partial<SingleOrDefaultModel<T>>) {
    Object.assign(this, init);
  }
}
