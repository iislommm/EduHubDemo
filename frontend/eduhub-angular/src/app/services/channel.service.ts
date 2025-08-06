import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Channel, ChannelCreateDto, ChannelStats } from '../models/channel.model';

@Injectable({
  providedIn: 'root'
})
export class ChannelService {

  constructor(private http: HttpClient) {}

  // Get channel by ID
  getChannelById(id: string): Observable<Channel> {
    return this.http.get<Channel>(`${environment.apiUrl}/channels/${id}`);
  }

  // Get channel by instructor ID
  getChannelByInstructorId(instructorId: string): Observable<Channel> {
    return this.http.get<Channel>(`${environment.apiUrl}/channels/instructor/${instructorId}`);
  }

  // Get current user's channel
  getMyChannel(): Observable<Channel> {
    return this.http.get<Channel>(`${environment.apiUrl}/channels/my-channel`);
  }

  // Create channel
  createChannel(channelDto: ChannelCreateDto): Observable<Channel> {
    return this.http.post<Channel>(`${environment.apiUrl}/channels`, channelDto);
  }

  // Update channel
  updateChannel(id: string, channelDto: Partial<ChannelCreateDto>): Observable<Channel> {
    return this.http.put<Channel>(`${environment.apiUrl}/channels/${id}`, channelDto);
  }

  // Delete channel
  deleteChannel(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/channels/${id}`);
  }

  // Get channel statistics
  getChannelStats(id: string): Observable<ChannelStats> {
    return this.http.get<ChannelStats>(`${environment.apiUrl}/channels/${id}/stats`);
  }

  // Subscribe to channel
  subscribeToChannel(channelId: string): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}/channels/${channelId}/subscribe`, {});
  }

  // Unsubscribe from channel
  unsubscribeFromChannel(channelId: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/channels/${channelId}/subscribe`);
  }

  // Check if user is subscribed to channel
  isSubscribed(channelId: string): Observable<boolean> {
    return this.http.get<boolean>(`${environment.apiUrl}/channels/${channelId}/is-subscribed`);
  }

  // Get all channels (for browsing)
  getAllChannels(page: number = 1, limit: number = 12): Observable<{channels: Channel[], totalCount: number}> {
    return this.http.get<{channels: Channel[], totalCount: number}>(`${environment.apiUrl}/channels?page=${page}&limit=${limit}`);
  }
}