export interface ChannelCreateDto {
  name: string;
  description?: string;
  bannerImage?: string;
  profileImage?: string;
  externalLink?: string;
  instructorId: string;
}

export interface Channel {
  id: string;
  name: string;
  description?: string;
  bannerImage?: string;
  profileImage?: string;
  externalLink?: string;
  instructorId: string;
  instructor?: Instructor;
  subscribers: number;
  totalViews: number;
  videoCount: number;
  createdAt: Date;
  updatedAt: Date;
  isActive: boolean;
  videos?: Video[];
}

export interface ChannelStats {
  subscribers: number;
  totalViews: number;
  videoCount: number;
  totalRevenue: number;
}

import { Instructor } from './video.model';
import { Video } from './video.model';