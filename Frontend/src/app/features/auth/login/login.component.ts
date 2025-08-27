
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="min-h-screen flex items-center justify-center bg-gray-50 py-12 px-4 sm:px-6 lg:px-8">
      <div class="max-w-md w-full space-y-8">
        <div>
          <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
            Sign in to Fintcs
          </h2>
          <p class="mt-2 text-center text-sm text-gray-600">
            Finance Management System
          </p>
        </div>
        
        <form class="mt-8 space-y-6" [formGroup]="loginForm" (ngSubmit)="onSubmit()">
          <div class="space-y-4">
            <div>
              <label for="username" class="form-label">Username</label>
              <input id="username" 
                     type="text" 
                     formControlName="username"
                     class="form-input"
                     placeholder="Enter your username">
              <div *ngIf="loginForm.get('username')?.invalid && loginForm.get('username')?.touched" 
                   class="text-red-500 text-sm mt-1">
                Username is required
              </div>
            </div>
            
            <div>
              <label for="password" class="form-label">Password</label>
              <input id="password" 
                     type="password" 
                     formControlName="password"
                     class="form-input"
                     placeholder="Enter your password">
              <div *ngIf="loginForm.get('password')?.invalid && loginForm.get('password')?.touched" 
                   class="text-red-500 text-sm mt-1">
                Password is required
              </div>
            </div>
          </div>

          <div *ngIf="errorMessage" class="text-red-500 text-sm text-center">
            {{errorMessage}}
          </div>

          <div>
            <button type="submit" 
                    [disabled]="loginForm.invalid || loading"
                    class="w-full btn-primary disabled:opacity-50 disabled:cursor-not-allowed">
              <span *ngIf="loading" class="inline-block animate-spin rounded-full h-4 w-4 border-b-2 border-white mr-2"></span>
              {{loading ? 'Signing in...' : 'Sign in'}}
            </button>
          </div>
          
          <div class="text-sm text-center text-gray-600">
            <p>Default Super Admin:</p>
            <p><strong>Username:</strong> admin</p>
            <p><strong>Password:</strong> admin</p>
          </div>
        </form>
      </div>
    </div>
  `
})
export class LoginComponent {
  loginForm: FormGroup;
  loading = false;
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.loading = true;
      this.errorMessage = '';

      this.authService.login(this.loginForm.value).subscribe({
        next: () => {
          this.loading = false;
          this.router.navigate(['/dashboard']);
        },
        error: (error) => {
          this.loading = false;
          this.errorMessage = error.error?.message || 'Login failed. Please try again.';
        }
      });
    }
  }
}
