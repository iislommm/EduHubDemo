import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-channel',
  template: `
    <div class="container mt-4">
      <h2>Channel</h2>
      <div class="alert alert-info">
        <i class="fas fa-info-circle me-2"></i>
        Channel component is ready for implementation. Channel ID: {{ channelId }}
      </div>
    </div>
  `
})
export class ChannelComponent implements OnInit {
  channelId: string | null = null;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.channelId = this.route.snapshot.paramMap.get('channelId');
  }
}