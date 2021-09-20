export class RatingResultModel {
  id: number;
  year: string;
  ratingId: number;
  ratingName: string;
  leaguerId: number;

  constructor(init?: Partial<RatingResultModel>) {
    Object.assign(this, init);
  }
}
