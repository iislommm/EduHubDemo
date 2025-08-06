import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Routing
import { AppRoutingModule } from './app-routing.module';

// Components
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AboutComponent } from './components/shared/about/about.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { VideoDetailComponent } from './components/video/video-detail/video-detail.component';
import { VideoListComponent } from './components/video/video-list/video-list.component';
import { ChannelComponent } from './components/video/channel/channel.component';
import { AdminPanelComponent } from './components/admin/admin-panel.component';

// Services
import { AuthService } from './services/auth.service';
import { VideoService } from './services/video.service';
import { CategoryService } from './services/category.service';
import { ChannelService } from './services/channel.service';

// Guards
import { AuthGuard, AdminGuard, InstructorGuard } from './guards/auth.guard';

// Interceptors
import { AuthInterceptor } from './interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    AboutComponent,
    DashboardComponent,
    VideoDetailComponent,
    VideoListComponent,
    ChannelComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [
    AuthService,
    VideoService,
    CategoryService,
    ChannelService,
    AuthGuard,
    AdminGuard,
    InstructorGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }