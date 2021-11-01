import {LeaguerModel} from '@app/models';

export enum KeyCode {
  Escape = 27,
  Space = 32,
  Enter = 13,
  ArrowDown = 40,
  ArrowUp = 38,
  Tab = 9
}

export enum LookupDataType {
  Roles = 'Roles',
  Units = 'Units',
  Statuses = 'Statuses',
  ChangeOfficialDocumentTypes = 'ChangeOfficialDocumentTypes',
  ChangeOfficialDocuments = 'ChangeOfficialDocuments',
  Ratings = 'Ratings',
  Years = 'Years',
}

export enum AppLeaguerStatus {
  Official = 1,
  Preliminary = 2,
  GetOut = 3,
  Dead = 4
}

