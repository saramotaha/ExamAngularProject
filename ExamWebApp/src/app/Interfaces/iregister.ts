// In your IRegister interface file
export interface IRegister {

  Name: string
  Email: string
  Password: string
  ConfirmPassword: string
  role: 'student'  // 'student' | 'teacher'
}
