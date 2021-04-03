export class LeaguerModel {
  id: number;
  unitId: number;
  name: string;
  bornYear: number;
  gender: boolean;
  religion: string;
  folk: string;
  homeTown: string;
  educationalLevel: string;
  politicalTheoryLevel: string;
  foreignLanguageLevel: string;
  specializeMajor: string;
  beforeEnteringCareer: string;
  currentCareer: string;
  position: string;
  preliminaryApplyDate: Date | null;
  officialApplyDate: Date | null;
  cardNumber: string;
  backgroundNumber: string;
  badgeNumber: string;
  moveOutDated: string;
  officeComing: string;
  moveInDated: string;
  atOffice: string;
  deadDate: string;
  deathReason: string;
  getOutDate: string;
  formOut: string;
  phone: number;
  notes: string;
  isActivated: boolean;

  constructor(init?: Partial<LeaguerModel>) {
    Object.assign(this, init);
  }
}
