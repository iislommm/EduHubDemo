import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Category, CategoryCreateDto } from '../models/video.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) {}

  // Get all categories
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${environment.apiUrl}/categories`);
  }

  // Get active categories only
  getActiveCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${environment.apiUrl}/categories/active`);
  }

  // Get category by ID
  getCategoryById(id: string): Observable<Category> {
    return this.http.get<Category>(`${environment.apiUrl}/categories/${id}`);
  }

  // Create category (admin only)
  createCategory(categoryDto: CategoryCreateDto): Observable<Category> {
    return this.http.post<Category>(`${environment.apiUrl}/categories`, categoryDto);
  }

  // Update category (admin only)
  updateCategory(id: string, categoryDto: Partial<CategoryCreateDto>): Observable<Category> {
    return this.http.put<Category>(`${environment.apiUrl}/categories/${id}`, categoryDto);
  }

  // Delete category (admin only)
  deleteCategory(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/categories/${id}`);
  }

  // Toggle category active status (admin only)
  toggleCategoryStatus(id: string): Observable<Category> {
    return this.http.patch<Category>(`${environment.apiUrl}/categories/${id}/toggle-status`, {});
  }
}