import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Video, VideoCreateDto } from '../models/video.model';
import { Comment, CommentCreateDto, Like, LikeCreateDto } from '../models/interaction.model';

export interface VideoSearchParams {
  search?: string;
  categoryId?: string;
  instructorId?: string;
  minPrice?: number;
  maxPrice?: number;
  sortBy?: 'newest' | 'oldest' | 'popular' | 'price_low' | 'price_high';
  page?: number;
  limit?: number;
}

export interface VideoSearchResponse {
  videos: Video[];
  totalCount: number;
  currentPage: number;
  totalPages: number;
}

@Injectable({
  providedIn: 'root'
})
export class VideoService {

  constructor(private http: HttpClient) {}

  // Get all videos with optional filtering
  getVideos(params?: VideoSearchParams): Observable<VideoSearchResponse> {
    let httpParams = new HttpParams();
    
    if (params) {
      Object.keys(params).forEach(key => {
        const value = (params as any)[key];
        if (value !== undefined && value !== null) {
          httpParams = httpParams.set(key, value.toString());
        }
      });
    }

    return this.http.get<VideoSearchResponse>(`${environment.apiUrl}/videos`, { params: httpParams });
  }

  // Get featured videos for homepage
  getFeaturedVideos(limit: number = 6): Observable<Video[]> {
    return this.http.get<Video[]>(`${environment.apiUrl}/videos/featured?limit=${limit}`);
  }

  // Get video by ID
  getVideoById(id: string): Observable<Video> {
    return this.http.get<Video>(`${environment.apiUrl}/videos/${id}`);
  }

  // Create new video (instructor only)
  createVideo(videoDto: VideoCreateDto): Observable<Video> {
    return this.http.post<Video>(`${environment.apiUrl}/videos`, videoDto);
  }

  // Update video (instructor only)
  updateVideo(id: string, videoDto: Partial<VideoCreateDto>): Observable<Video> {
    return this.http.put<Video>(`${environment.apiUrl}/videos/${id}`, videoDto);
  }

  // Delete video (instructor only)
  deleteVideo(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/videos/${id}`);
  }

  // Get videos by category
  getVideosByCategory(categoryId: string, params?: VideoSearchParams): Observable<VideoSearchResponse> {
    const searchParams = { ...params, categoryId };
    return this.getVideos(searchParams);
  }

  // Get videos by instructor
  getVideosByInstructor(instructorId: string, params?: VideoSearchParams): Observable<VideoSearchResponse> {
    const searchParams = { ...params, instructorId };
    return this.getVideos(searchParams);
  }

  // Search videos globally
  searchVideos(query: string, params?: VideoSearchParams): Observable<VideoSearchResponse> {
    const searchParams = { ...params, search: query };
    return this.getVideos(searchParams);
  }

  // Increment video views
  incrementViews(videoId: string): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}/videos/${videoId}/view`, {});
  }

  // Get video comments
  getVideoComments(videoId: string): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${environment.apiUrl}/videos/${videoId}/comments`);
  }

  // Add comment to video
  addComment(commentDto: CommentCreateDto): Observable<Comment> {
    return this.http.post<Comment>(`${environment.apiUrl}/comments`, commentDto);
  }

  // Update comment
  updateComment(commentId: string, content: string): Observable<Comment> {
    return this.http.put<Comment>(`${environment.apiUrl}/comments/${commentId}`, { content });
  }

  // Delete comment
  deleteComment(commentId: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/comments/${commentId}`);
  }

  // Like/Unlike video or comment
  toggleLike(likeDto: LikeCreateDto): Observable<Like> {
    return this.http.post<Like>(`${environment.apiUrl}/likes`, likeDto);
  }

  // Get user's interaction with video
  getUserVideoInteraction(videoId: string): Observable<any> {
    return this.http.get(`${environment.apiUrl}/videos/${videoId}/interaction`);
  }

  // Purchase/Enroll in video
  purchaseVideo(videoId: string): Observable<any> {
    return this.http.post(`${environment.apiUrl}/videos/${videoId}/purchase`, {});
  }

  // Check if user has access to video
  hasVideoAccess(videoId: string): Observable<boolean> {
    return this.http.get<boolean>(`${environment.apiUrl}/videos/${videoId}/access`);
  }
}