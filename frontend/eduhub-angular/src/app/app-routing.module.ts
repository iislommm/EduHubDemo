import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard, AdminGuard, InstructorGuard } from './guards/auth.guard';

// Import components (will be created)
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AboutComponent } from './components/shared/about/about.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { VideoDetailComponent } from './components/video/video-detail/video-detail.component';
import { VideoListComponent } from './components/video/video-list/video-list.component';
import { ChannelComponent } from './components/video/channel/channel.component';
import { AdminPanelComponent } from './components/admin/admin-panel.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'about', component: AboutComponent },
  { 
    path: 'dashboard', 
    component: DashboardComponent, 
    canActivate: [AuthGuard] 
  },
  { path: 'videos', component: VideoListComponent },
  { path: 'videos/:id', component: VideoDetailComponent },
  { path: 'category/:categoryId', component: VideoListComponent },
  { path: 'channel/:channelId', component: ChannelComponent },
  { 
    path: 'admin', 
    component: AdminPanelComponent, 
    canActivate: [AdminGuard] 
  },
  { path: '**', redirectTo: '' } // Wildcard route for 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }