
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SocietyService } from '../../core/services/society.service';
import { Society } from '../../core/models/society.model';

@Component({
  selector: 'app-societies',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="space-y-6">
      <div class="flex justify-between items-center">
        <h1 class="text-2xl font-bold text-gray-900">Societies Management</h1>
        <button (click)="showCreateForm = !showCreateForm" class="btn-primary">
          {{showCreateForm ? 'Cancel' : 'Add New Society'}}
        </button>
      </div>

      <!-- Create Society Form -->
      <div *ngIf="showCreateForm" class="card">
        <h2 class="text-xl font-semibold mb-4">Create New Society</h2>
        <form [formGroup]="societyForm" (ngSubmit)="onSubmit()" class="space-y-4">
          <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label class="form-label">Society Name *</label>
              <input type="text" formControlName="name" class="form-input">
              <div *ngIf="societyForm.get('name')?.invalid && societyForm.get('name')?.touched" 
                   class="text-red-500 text-sm mt-1">
                Society name is required
              </div>
            </div>
            <div>
              <label class="form-label">Registration No</label>
              <input type="text" formControlName="registrationNo" class="form-input">
            </div>
            <div>
              <label class="form-label">City</label>
              <input type="text" formControlName="city" class="form-input">
            </div>
            <div>
              <label class="form-label">Phone</label>
              <input type="text" formControlName="phone" class="form-input">
            </div>
            <div>
              <label class="form-label">Email</label>
              <input type="email" formControlName="email" class="form-input">
            </div>
            <div>
              <label class="form-label">Website</label>
              <input type="url" formControlName="website" class="form-input">
            </div>
          </div>
          
          <div>
            <label class="form-label">Address</label>
            <textarea formControlName="address" class="form-input" rows="3"></textarea>
          </div>

          <!-- Interest Rates Section -->
          <div class="border-t pt-4">
            <h3 class="text-lg font-medium mb-3">Interest Rates (%)</h3>
            <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
              <div>
                <label class="form-label">Dividend Rate</label>
                <input type="number" step="0.01" formControlName="dividendRate" class="form-input">
              </div>
              <div>
                <label class="form-label">OD Rate</label>
                <input type="number" step="0.01" formControlName="odRate" class="form-input">
              </div>
              <div>
                <label class="form-label">CD Rate</label>
                <input type="number" step="0.01" formControlName="cdRate" class="form-input">
              </div>
              <div>
                <label class="form-label">Loan Rate</label>
                <input type="number" step="0.01" formControlName="loanRate" class="form-input">
              </div>
              <div>
                <label class="form-label">Emergency Loan Rate</label>
                <input type="number" step="0.01" formControlName="emergencyLoanRate" class="form-input">
              </div>
              <div>
                <label class="form-label">LAS Rate</label>
                <input type="number" step="0.01" formControlName="lasRate" class="form-input">
              </div>
            </div>
          </div>

          <!-- Limits Section -->
          <div class="border-t pt-4">
            <h3 class="text-lg font-medium mb-3">Limits</h3>
            <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
              <div>
                <label class="form-label">Share Limit</label>
                <input type="number" step="0.01" formControlName="shareLimit" class="form-input">
              </div>
              <div>
                <label class="form-label">Loan Limit</label>
                <input type="number" step="0.01" formControlName="loanLimit" class="form-input">
              </div>
              <div>
                <label class="form-label">Emergency Loan Limit</label>
                <input type="number" step="0.01" formControlName="emergencyLoanLimit" class="form-input">
              </div>
            </div>
          </div>

          <!-- Bounce Charge Section -->
          <div class="border-t pt-4">
            <h3 class="text-lg font-medium mb-3">Bounce Charge</h3>
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <label class="form-label">Amount</label>
                <input type="number" step="0.01" formControlName="bounceChargeAmount" class="form-input">
              </div>
              <div>
                <label class="form-label">Type</label>
                <select formControlName="bounceChargeType" class="form-input">
                  <option value="">Select Type</option>
                  <option value="Excess Provision">Excess Provision</option>
                  <option value="Cash">Cash</option>
                  <option value="HDFC Bank">HDFC Bank</option>
                  <option value="Inverter">Inverter</option>
                </select>
              </div>
            </div>
          </div>

          <div class="flex space-x-4">
            <button type="submit" [disabled]="societyForm.invalid || loading" class="btn-primary">
              {{loading ? 'Creating...' : 'Create Society'}}
            </button>
            <button type="button" (click)="showCreateForm = false" class="btn-secondary">
              Cancel
            </button>
          </div>
        </form>
      </div>

      <!-- Societies List -->
      <div class="card">
        <h2 class="text-xl font-semibold mb-4">Societies List</h2>
        <div *ngIf="loading" class="text-center py-4">Loading...</div>
        <div *ngIf="!loading && societies.length === 0" class="text-center py-4 text-gray-500">
          No societies found
        </div>
        <div *ngIf="!loading && societies.length > 0" class="overflow-x-auto">
          <table class="min-w-full divide-y divide-gray-200">
            <thead class="bg-gray-50">
              <tr>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Name</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">City</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Phone</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Email</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Status</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Actions</th>
              </tr>
            </thead>
            <tbody class="bg-white divide-y divide-gray-200">
              <tr *ngFor="let society of societies">
                <td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{{society.name}}</td>
                <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{{society.city}}</td>
                <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{{society.phone}}</td>
                <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{{society.email}}</td>
                <td class="px-6 py-4 whitespace-nowrap">
                  <span class="px-2 inline-flex text-xs leading-5 font-semibold rounded-full"
                        [class]="society.isPendingApproval ? 'bg-yellow-100 text-yellow-800' : 'bg-green-100 text-green-800'">
                    {{society.isPendingApproval ? 'Pending' : 'Active'}}
                  </span>
                </td>
                <td class="px-6 py-4 whitespace-nowrap text-sm font-medium">
                  <button class="text-indigo-600 hover:text-indigo-900 mr-2">Edit</button>
                  <button class="text-red-600 hover:text-red-900">Delete</button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  `
})
export class SocietiesComponent implements OnInit {
  societies: Society[] = [];
  showCreateForm = false;
  loading = false;
  societyForm: FormGroup;

  constructor(
    private societyService: SocietyService,
    private fb: FormBuilder
  ) {
    this.societyForm = this.fb.group({
      name: ['', Validators.required],
      address: [''],
      city: [''],
      phone: [''],
      fax: [''],
      email: [''],
      website: [''],
      registrationNo: [''],
      dividendRate: [0],
      odRate: [0],
      cdRate: [0],
      loanRate: [0],
      emergencyLoanRate: [0],
      lasRate: [0],
      shareLimit: [0],
      loanLimit: [0],
      emergencyLoanLimit: [0],
      bounceChargeAmount: [0],
      bounceChargeType: ['']
    });
  }

  ngOnInit(): void {
    this.loadSocieties();
  }

  loadSocieties(): void {
    this.loading = true;
    this.societyService.getSocieties().subscribe({
      next: (societies) => {
        this.societies = societies;
        this.loading = false;
      },
      error: (error) => {
        console.error('Error loading societies:', error);
        this.loading = false;
      }
    });
  }

  onSubmit(): void {
    if (this.societyForm.valid) {
      this.loading = true;
      this.societyService.createSociety(this.societyForm.value).subscribe({
        next: () => {
          this.loading = false;
          this.showCreateForm = false;
          this.societyForm.reset();
          this.loadSocieties();
        },
        error: (error) => {
          console.error('Error creating society:', error);
          this.loading = false;
        }
      });
    }
  }
}
