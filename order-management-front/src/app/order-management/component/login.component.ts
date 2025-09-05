import { Component } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
  <div class="login-wrapper">
    <form [formGroup]="form" (ngSubmit)="submit()" class="card">
      <h2>Iniciar sesión</h2>

      <label>Usuario</label>
      <input type="text" formControlName="userName" autocomplete="username" />

      <label>Contraseña</label>
      <input type="password" formControlName="password" autocomplete="current-password" />

      <button type="submit" [disabled]="loading || form.invalid">
        {{ loading ? 'Ingresando...' : 'Ingresar' }}
      </button>

      <p class="error" *ngIf="error">{{ error }}</p>
    </form>
  </div>
  `,
  styles: [`
    .login-wrapper { min-height: 80vh; display: grid; place-items: center; padding: 16px; }
    .card { width: 320px; padding: 20px; border-radius: 12px; box-shadow: 0 10px 30px rgba(0,0,0,.08); background: #fff; display: grid; gap: 12px; }
    .card h2 { margin: 0 0 8px; }
    .card label { font-size: 12px; opacity: .7; }
    .card input { padding: 10px; border: 1px solid #ddd; border-radius: 8px; }
    .card button { padding: 10px; border: 0; border-radius: 8px; cursor: pointer; }
    .error { color: #c00; font-size: 12px; margin: 4px 0 0; }
  `]
})
export class LoginComponent {
  loading = false;
  error: string | null = null;

  form = this.fb.group({
    userName: ['', Validators.required],
    password: ['', Validators.required]
  });

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {}

  submit() {
    if (this.form.invalid) return;
    this.loading = true; this.error = null;

    this.auth.login(this.form.value as any).subscribe({
      next: (res) => { this.loading = false; this.router.navigate(['/orders']); 
        const role = (res as any).role ?? localStorage.getItem('user_role');

      if (role === 'Customer') {
        this.router.navigate(['/orders']);
      } else if (role === 'SalesManager') {
        this.router.navigate(['/sales']);
      } else {
        this.router.navigate(['/']);
      }
      },
      error: () => { this.loading = false; this.error = 'Usuario o contraseña inválidos'; }
    });
  }
}
