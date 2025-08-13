import { CanActivateFn } from '@angular/router';

export const studentAuthGuard: CanActivateFn = (route, state) => {

  const token = localStorage.getItem('token');
    let role: string | null = null;

  if (token) {
  const payload = JSON.parse(atob(token.split('.')[1]));
  role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  console.log(role);
  }

  if (token != null  && role == 'student') {

    return true;

  }

  return false;




};
