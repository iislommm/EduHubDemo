import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { VideoService } from '../../services/video.service';
import { CategoryService } from '../../services/category.service';
import { AuthService } from '../../services/auth.service';
import { Video, Category } from '../../models/video.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  featuredVideos: Video[] = [];
  categories: Category[] = [];
  searchQuery = '';
  loading = true;

  constructor(
    private videoService: VideoService,
    private categoryService: CategoryService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadFeaturedContent();
  }

  loadFeaturedContent() {
    this.loading = true;
    
    // Load featured videos and categories in parallel
    Promise.all([
      this.videoService.getFeaturedVideos(6).toPromise(),
      this.categoryService.getActiveCategories().toPromise()
    ]).then(([videos, categories]) => {
      this.featuredVideos = videos || [];
      this.categories = categories || [];
      this.loading = false;
    }).catch(error => {
      console.error('Error loading featured content:', error);
      this.loading = false;
    });
  }

  onSearch() {
    if (this.searchQuery.trim()) {
      this.router.navigate(['/videos'], { 
        queryParams: { search: this.searchQuery.trim() } 
      });
    }
  }

  navigateToCategory(categoryId: string) {
    this.router.navigate(['/category', categoryId]);
  }

  navigateToVideo(videoId: string) {
    this.router.navigate(['/videos', videoId]);
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  formatPrice(price: number): string {
    return price === 0 ? 'Free' : `$${price}`;
  }

  getInstructorName(video: Video): string {
    if (video.instructor) {
      return `${video.instructor.firstName} ${video.instructor.lastName}`;
    }
    return 'Unknown Instructor';
  }
}