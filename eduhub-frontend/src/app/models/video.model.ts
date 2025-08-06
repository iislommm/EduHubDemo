export interface VideoCreateDto {
  title: string;
  description: string;
  price: number;
  thumbnailUrl?: string;
  videoUrl: string;
  categoryId: string;
  instructorId: string;
  duration?: number;
  tags?: string[];
  isPublished: boolean;
}

export interface Video {
  id: string;
  title: string;
  description: string;
  price: number;
  thumbnailUrl?: string;
  videoUrl: string;
  categoryId: string;
  instructorId: string;
  instructor?: Instructor;
  category?: Category;
  duration?: number;
  tags?: string[];
  isPublished: boolean;
  views: number;
  likes: number;
  dislikes: number;
  createdAt: Date;
  updatedAt: Date;
  comments?: Comment[];
}

export interface Instructor {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  profileImage?: string;
  bio?: string;
  channelId?: string;
  channel?: Channel;
}

export interface Category {
  id: string;
  name: string;
  description?: string;
  icon?: string;
  color?: string;
  isActive: boolean;
}

export interface CategoryCreateDto {
  name: string;
  description?: string;
  icon?: string;
  color?: string;
  isActive: boolean;
}