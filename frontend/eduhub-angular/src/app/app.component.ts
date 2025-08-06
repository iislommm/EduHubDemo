import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  template: `
    <app-navbar></app-navbar>
    <main class="main-content">
      <router-outlet></router-outlet>
    </main>
  `,
  styles: [`
    .main-content {
      min-height: calc(100vh - 80px);
      padding-top: 80px; /* Account for fixed navbar */
    }
  `]
})
export class AppComponent implements OnInit {
  title = 'EduHub';

  constructor(private authService: AuthService) {}

  ngOnInit() {
    // Initialize authentication state on app start
    this.authService.isAuthenticated();
  }
}