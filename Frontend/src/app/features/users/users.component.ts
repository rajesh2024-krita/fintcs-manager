
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="space-y-6">
      <h1 class="text-2xl font-bold text-gray-900">Users Management</h1>
      <div class="card">
        <p class="text-center text-gray-500">Users management functionality will be implemented here.</p>
      </div>
    </div>
  `
})
export class UsersComponent {}
