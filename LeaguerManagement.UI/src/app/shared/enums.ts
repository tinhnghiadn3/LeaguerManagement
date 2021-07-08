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
}

export enum AppLeaguerStatus {
  Handling = 1,
  Returning = 2,
  Finished = 3
}

