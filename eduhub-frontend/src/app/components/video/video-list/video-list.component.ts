import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-video-list',
  template: `
    <div class="container mt-4">
      <h2>Video List</h2>
      <div class="alert alert-info">
        <i class="fas fa-info-circle me-2"></i>
        Video list component is ready for implementation. Category: {{ categoryId || 'All' }}
      </div>
    </div>
  `
})
export class VideoListComponent implements OnInit {
  categoryId: string | null = null;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
  }
}