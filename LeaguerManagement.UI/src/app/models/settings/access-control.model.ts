export class AccessControlModel {
  id: number;
  name: string;

  constructor(init?: Partial<AccessControlModel>) {
    Object.assign(this, init);
  }
}

export class RoleModel {
  id: number;
  name: string;
  accessControlIds: number[] = [];

  constructor(init?: Partial<RoleModel>) {
    Object.assign(this, init);
  }
}

export class AccessOfRoleModel {
  id: number;
  roleId: number;
  accessControlId: number;
  isActivated: boolean;

  constructor(init?: Partial<AccessOfRoleModel>) {
    Object.assign(this, init);
  }
}
