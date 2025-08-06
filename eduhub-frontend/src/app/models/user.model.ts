export interface SignUpDto {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  phoneNumber?: string;
  dateOfBirth?: Date;
  role?: UserRole;
}

export interface UserLoginDto {
  email: string;
  password: string;
}

export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber?: string;
  dateOfBirth?: Date;
  role: UserRole;
  profileImage?: string;
  createdAt: Date;
  updatedAt: Date;
  isActive: boolean;
  channelId?: string;
}

export interface AuthResponse {
  token: string;
  user: User;
  expiresIn: number;
}

export enum UserRole {
  User = 'User',
  Instructor = 'Instructor',
  Admin = 'Admin',
  SuperAdmin = 'SuperAdmin'
}