/**
 * App Config
 */

export const AUTH_SCHEME = 'Bearer ';
export const ACCESS_TOKEN_KEY = 'et';
export const REFRESH_TOKEN_KEY = 'ert';
export const IMAGE_TOKEN_KEY = 'eit';
export const HOME_URL_KEY = 'ehu';
export const REMEMBER_ME_KEY = 'er';

export const JOB_APPSTORAGE_KEY = 'crjk';

/**
 * Shared
 */

export const VALIDATION_REGEX = {
  // tslint:disable-next-line:max-line-length
  phone: /^[+]?(?=(?:[^\dx]*\d))(?:\(\d+(?:\.\d+)?\)|\d+(?:\.\d+)?)(?:[ -]?(?:\(\d+(?:\.\d+)?\)|\d+(?:\.\d+)?))*(?:[ ]?(?:x|ext)\.?[ ]?\d{1,5})?$/,
  email: /^[a-zA-Z0-9_\.]{3,32}@[a-zA-Z0-9]{2,}(\.[a-zA-Z0-9]{2,4}){1,2}$/,
  postCode: /^(\d{4})$/
};

// tslint:disable-next-line:max-line-length
// export const ALLOWED_FILE_TYPES = '.jpg,.jpeg,.png,.gif,.doc,.docx,.xls,.xlsx,.ppt,.pptx,.pdf,.rtf,.txt,.zip, .mp4,.webm, .mpeg4, .3gpp, .mov, .avi, .mpeg, .mpegps, .wmv, .flv, .ogg, .mp3, .m4a, .wav, .sql';
export const ALLOWED_FILE_TYPES = ['.JPG', '.jpg', '.jpeg', '.png', '.gif', '.doc', '.docx', '.xls', '.xlsx', '.ppt', '.pptx', '.pdf', '.rtf', '.txt'];
export const ALLOWED_AVATAR_TYPES = ['.JPG', '.jpg', '.jpeg', '.png', '.gif'];


export const AppRoleValue = {
  Admin: 1,
  Manager: 2,
};

export const AccessControlValue = {
  Settings: 1,
  Users: 2,
};

export const AccessControls = [
  {id: AccessControlValue.Settings, name: 'Cài đặt hệ thống', symbol: 'Settings'},
  {id: AccessControlValue.Users, name: 'Quản trị người dùng', symbol: 'Users'},
];

export const ADDING_USER_TYPE_VALUE = {
  Unit: 0,
  Department: 1,
};

export const YEAR_VALUE = {
  2020: 2020,
  2021: 2021,
};

export const AppYearItems = [
  {value: YEAR_VALUE['2020'], text: 'Năm 2020'},
  {value: YEAR_VALUE['2021'], text: 'Năm 2021'},
];

export const APP_STATUS_VALUE = {
  Yes: true,
  No: false,
  Null: null
};

export const ResultStatusItems = [
  {value: APP_STATUS_VALUE.Yes, text: 'Có hồ sơ'},
  {value: APP_STATUS_VALUE.No, text: 'Không có hồ sơ'},
  {value: APP_STATUS_VALUE.Null, text: 'Chưa kiểm tra'},
];

/**
 * Setting value
 */

export const SETTING_VALUE = {
  RoleAndAccessControl: 0,
  User: 1,
  OfficialDocument: 2
};

export const SETTING_ITEMS = [
  {value: SETTING_VALUE.RoleAndAccessControl, text: 'Quyền'},
  {value: SETTING_VALUE.User, text: 'Người dùng'},
  {value: SETTING_VALUE.OfficialDocument, text: 'Loại giấy tờ/biểu mẫu'},
];

/**
 * App Common
 */

export const GENDER_VALUE = {
  MAN: true,
  WOMEN: false
};

export const GENDER_ITEMS = [
  {value: GENDER_VALUE.MAN, text: 'Nam'},
  {value: GENDER_VALUE.WOMEN, text: 'Nữ'},
];
