export interface CommentCreateDto {
  content: string;
  videoId: string;
  userId: string;
  parentCommentId?: string;
}

export interface Comment {
  id: string;
  content: string;
  videoId: string;
  userId: string;
  user?: User;
  parentCommentId?: string;
  replies?: Comment[];
  likes: number;
  dislikes: number;
  createdAt: Date;
  updatedAt: Date;
  isEdited: boolean;
}

export interface LikeCreateDto {
  videoId?: string;
  commentId?: string;
  userId: string;
  isLike: boolean; // true for like, false for dislike
}

export interface Like {
  id: string;
  videoId?: string;
  commentId?: string;
  userId: string;
  user?: User;
  isLike: boolean;
  createdAt: Date;
}

export interface VideoInteraction {
  hasLiked: boolean;
  hasDisliked: boolean;
  hasCommented: boolean;
  userComment?: Comment;
}

import { User } from './user.model';