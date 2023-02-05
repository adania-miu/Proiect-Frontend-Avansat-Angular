
export interface Username{
  username: string;
}
export enum UserRole {
  Admin = 'Admin',
  User = 'User'
}

export const allRoles: UserRole[] = [
  UserRole.Admin,
  UserRole.User
];

export interface IUser {
  id: number;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
  roles: UserRole[];
  token: string;
}

export interface User {
  userName: string;
  email: string;
  firstName: string;
  lastName: string;
  iban: string;
}

export interface IUserSignup {
  username: string;
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  role: UserRole[];
}

export interface IUserLogin {
  email: string;
  password: string;
}

export function rolesAtLeast(role: UserRole): UserRole[] {
  switch (role) {
    case UserRole.User:
      return [UserRole.User, UserRole.Admin];
    case UserRole.Admin:
      return [UserRole.Admin];
    default:
      return [UserRole.User];
  }
}

export function checkRoles(user: IUser | null, expectedRole: UserRole): boolean {
  if (!user) {
    return false;
  }
  const allowedRoles = rolesAtLeast(expectedRole);
  return allowedRoles.some((r: UserRole) => user.roles.includes(r));
}

export interface Sold {
  sold: number;
}
