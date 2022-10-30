export interface ChangePasswordFromForget {
    userId: number;
    token: string;
    password: string;
    confirmPassword: string;
}