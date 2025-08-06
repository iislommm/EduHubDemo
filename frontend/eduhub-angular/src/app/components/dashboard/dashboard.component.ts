import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-dashboard',
  template: `
    <div class="container mt-4">
      <h2>Dashboard</h2>
      <div class="alert alert-info">
        <i class="fas fa-info-circle me-2"></i>
        Dashboard component is ready for implementation. User: {{ currentUser?.firstName }} {{ currentUser?.lastName }}
      </div>
    </div>
  `
})
export class DashboardComponent implements OnInit {
  currentUser: User | null = null;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.currentUser = this.authService.getCurrentUser();
  }
}