import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-video-detail',
  template: `
    <div class="container mt-4">
      <h2>Video Detail</h2>
      <div class="alert alert-info">
        <i class="fas fa-info-circle me-2"></i>
        Video detail component is ready for implementation. Video ID: {{ videoId }}
      </div>
    </div>
  `
})
export class VideoDetailComponent implements OnInit {
  videoId: string | null = null;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.videoId = this.route.snapshot.paramMap.get('id');
  }
}