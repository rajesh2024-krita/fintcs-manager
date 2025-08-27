
export interface User {
  id: number;
  edpNo: string;
  name: string;
  addressOffice: string;
  addressResidence: string;
  designation: string;
  phoneOffice: string;
  phoneResidence: string;
  mobile: string;
  email: string;
  username: string;
  role: 'SuperAdmin' | 'SocietyAdmin' | 'User' | 'Member';
  societyId?: number;
  createdAt: Date;
  updatedAt: Date;
}

export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  role: string;
  name: string;
  societyId?: number;
}
