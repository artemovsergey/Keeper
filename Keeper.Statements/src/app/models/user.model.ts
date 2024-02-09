export interface User {
  id: number;
  email: string;
  login: string;
  password: string;
  roleId: Role[];
}

export interface Role {
  id: number;
  name: string;
  users: User[] | null;
}
