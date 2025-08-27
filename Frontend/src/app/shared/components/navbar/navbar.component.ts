
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <nav class="bg-white shadow-lg">
      <div class="container mx-auto px-4">
        <div class="flex justify-between items-center py-4">
          <div class="flex items-center space-x-4">
            <h1 class="text-2xl font-bold text-primary-600">Fintcs</h1>
            <span class="text-sm text-gray-500">Finance Management System</span>
          </div>
          
          <div *ngIf="currentUser$ | async as user" class="flex items-center space-x-6">
            <div class="hidden md:flex space-x-4">
              <a routerLink="/dashboard" 
                 routerLinkActive="text-primary-600" 
                 class="text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium">
                Dashboard
              </a>
              
              <a *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/societies"
                 routerLinkActive="text-primary-600"
                 class="text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium">
                Societies
              </a>
              
              <a *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/users"
                 routerLinkActive="text-primary-600"
                 class="text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium">
                Users
              </a>
              
              <a *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/members"
                 routerLinkActive="text-primary-600"
                 class="text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium">
                Members
              </a>
              
              <a *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/loans"
                 routerLinkActive="text-primary-600"
                 class="text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium">
                Loans
              </a>
            </div>
            
            <div class="flex items-center space-x-4">
              <span class="text-sm text-gray-700">Welcome, {{user.name}}</span>
              <span class="text-xs bg-primary-100 text-primary-800 px-2 py-1 rounded-full">{{user.role}}</span>
              <button (click)="logout()" 
                      class="text-red-600 hover:text-red-800 text-sm font-medium">
                Logout
              </button>
            </div>
          </div>
        </div>
      </div>
    </nav>
  `
})
export class NavbarComponent {
  currentUser$ = this.authService.currentUser$;

  constructor(private authService: AuthService) {}

  hasRole(roles: string[]): boolean {
    return this.authService.hasRole(roles);
  }

  logout(): void {
    this.authService.logout();
  }
}
