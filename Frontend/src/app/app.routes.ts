
import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { roleGuard } from './core/guards/role.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadComponent: () => import('./features/auth/login/login.component').then(c => c.LoginComponent)
  },
  {
    path: 'dashboard',
    canActivate: [authGuard],
    loadComponent: () => import('./features/dashboard/dashboard.component').then(c => c.DashboardComponent)
  },
  {
    path: 'societies',
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] },
    loadComponent: () => import('./features/societies/societies.component').then(c => c.SocietiesComponent)
  },
  {
    path: 'users',
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] },
    loadComponent: () => import('./features/users/users.component').then(c => c.UsersComponent)
  },
  {
    path: 'members',
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] },
    loadComponent: () => import('./features/members/members.component').then(c => c.MembersComponent)
  },
  {
    path: 'loans',
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] },
    loadComponent: () => import('./features/loans/loans.component').then(c => c.LoansComponent)
  },
  {
    path: '**',
    redirectTo: '/dashboard'
  }
];
