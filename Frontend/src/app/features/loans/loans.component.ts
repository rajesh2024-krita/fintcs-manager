
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-loans',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="space-y-6">
      <h1 class="text-2xl font-bold text-gray-900">Loans Management</h1>
      <div class="card">
        <p class="text-center text-gray-500">Loans management functionality will be implemented here.</p>
      </div>
    </div>
  `
})
export class LoansComponent {}
