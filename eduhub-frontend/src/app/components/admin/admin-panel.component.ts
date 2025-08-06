import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-admin-panel',
  template: `
    <div class="container mt-4">
      <h2>Admin Panel</h2>
      <div class="alert alert-warning">
        <i class="fas fa-shield-alt me-2"></i>
        Admin panel component is ready for implementation. Only admins can access this area.
      </div>
    </div>
  `
})
export class AdminPanelComponent implements OnInit {

  constructor(private authService: AuthService) {}

  ngOnInit() {
    // Admin-only component
  }
}