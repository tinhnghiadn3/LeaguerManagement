import {ReferenceWithAttachmentModel} from '@app/models/shared/attachment.model';
import {AppliedDocumentModel} from '@app/models/leaguers/applied-document.model';

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
  statusId: number;
  isActivated: boolean;
  //
  avatarId: number;
  avatarImg: string;
  //
  officialDocuments: ReferenceWithAttachmentModel<AppliedDocumentModel>[] = [];

  constructor(init?: Partial<LeaguerModel>) {
    Object.assign(this, init);
  }

  public static copy(source: LeaguerModel, destination: LeaguerModel) {
    if (!source || !destination) {
      return destination;
    }

    Object.assign(destination, source);

    return destination;
  }

  public static clone(source: LeaguerModel): LeaguerModel {
    return LeaguerModel.copy(source, new LeaguerModel());
  }
}
