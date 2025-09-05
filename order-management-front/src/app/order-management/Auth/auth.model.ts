export interface LoginRequest {
  userName: string;
  password: string;
}

export interface AuthResponse {
  accessToken: string;
  expiresAt: string;
  userName: string;
  role: 'Customer' | 'SalesManager';
  customerId?: number | null;
  employeeId?: number | null;
}
