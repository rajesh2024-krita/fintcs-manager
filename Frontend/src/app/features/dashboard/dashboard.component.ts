
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../core/services/auth.service';
import { LoginResponse } from '../../core/models/user.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="space-y-6">
      <div class="text-center">
        <h1 class="text-3xl font-bold text-gray-900">Welcome to Fintcs</h1>
        <p class="mt-2 text-lg text-gray-600">Finance Management System Dashboard</p>
      </div>

      <div *ngIf="currentUser" class="card">
        <h2 class="text-xl font-semibold mb-4">User Information</h2>
        <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
          <div>
            <p class="text-sm text-gray-600">Name</p>
            <p class="font-medium">{{currentUser.name}}</p>
          </div>
          <div>
            <p class="text-sm text-gray-600">Role</p>
            <p class="font-medium">{{currentUser.role}}</p>
          </div>
          <div *ngIf="currentUser.societyId">
            <p class="text-sm text-gray-600">Society ID</p>
            <p class="font-medium">{{currentUser.societyId}}</p>
          </div>
        </div>
      </div>

      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
        <div *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" class="card hover:shadow-lg transition-shadow cursor-pointer">
          <div class="flex items-center">
            <div class="p-3 rounded-full bg-blue-100 text-blue-600">
              <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4"></path>
              </svg>
            </div>
            <div class="ml-4">
              <h3 class="font-semibold">Societies</h3>
              <p class="text-sm text-gray-600">Manage societies</p>
            </div>
          </div>
        </div>

        <div *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" class="card hover:shadow-lg transition-shadow cursor-pointer">
          <div class="flex items-center">
            <div class="p-3 rounded-full bg-green-100 text-green-600">
              <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197m13.5-9a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0z"></path>
              </svg>
            </div>
            <div class="ml-4">
              <h3 class="font-semibold">Users</h3>
              <p class="text-sm text-gray-600">Manage system users</p>
            </div>
          </div>
        </div>

        <div *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" class="card hover:shadow-lg transition-shadow cursor-pointer">
          <div class="flex items-center">
            <div class="p-3 rounded-full bg-purple-100 text-purple-600">
              <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z"></path>
              </svg>
            </div>
            <div class="ml-4">
              <h3 class="font-semibold">Members</h3>
              <p class="text-sm text-gray-600">Manage society members</p>
            </div>
          </div>
        </div>

        <div *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" class="card hover:shadow-lg transition-shadow cursor-pointer">
          <div class="flex items-center">
            <div class="p-3 rounded-full bg-yellow-100 text-yellow-600">
              <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
              </svg>
            </div>
            <div class="ml-4">
              <h3 class="font-semibold">Loans</h3>
              <p class="text-sm text-gray-600">Manage loan applications</p>
            </div>
          </div>
        </div>
      </div>

      <div class="card">
        <h2 class="text-xl font-semibold mb-4">Quick Actions</h2>
        <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
          <button *ngIf="hasRole(['SuperAdmin'])" class="btn-primary">
            Create New Society
          </button>
          <button *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" class="btn-primary">
            Add New Member
          </button>
          <button *ngIf="hasRole(['SuperAdmin', 'SocietyAdmin'])" class="btn-primary">
            Process Loan Application
          </button>
        </div>
      </div>
    </div>
  `
})
export class DashboardComponent implements OnInit {
  currentUser: LoginResponse | null = null;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.currentUser$.subscribe(user => {
      this.currentUser = user;
    });
  }

  hasRole(roles: string[]): boolean {
    return this.authService.hasRole(roles);
  }
}
