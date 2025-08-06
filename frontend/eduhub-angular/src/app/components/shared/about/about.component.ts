import { Component } from '@angular/core';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent {
  telegramLink = environment.telegramLink;

  teamMembers = [
    {
      name: 'John Smith',
      role: 'Founder & CEO',
      image: 'assets/team/john.jpg',
      bio: 'Passionate educator with 10+ years in EdTech',
      social: {
        linkedin: '#',
        twitter: '#'
      }
    },
    {
      name: 'Sarah Johnson',
      role: 'Head of Content',
      image: 'assets/team/sarah.jpg',
      bio: 'Expert in curriculum design and educational content',
      social: {
        linkedin: '#',
        twitter: '#'
      }
    },
    {
      name: 'Mike Chen',
      role: 'Lead Developer',
      image: 'assets/team/mike.jpg',
      bio: 'Full-stack developer building the future of learning',
      social: {
        linkedin: '#',
        github: '#'
      }
    },
    {
      name: 'Emily Davis',
      role: 'UX Designer',
      image: 'assets/team/emily.jpg',
      bio: 'Creating intuitive and engaging learning experiences',
      social: {
        linkedin: '#',
        dribbble: '#'
      }
    }
  ];

  features = [
    {
      icon: 'fas fa-graduation-cap',
      title: 'Expert Instructors',
      description: 'Learn from industry professionals and certified educators'
    },
    {
      icon: 'fas fa-laptop',
      title: 'Interactive Learning',
      description: 'Engaging content with hands-on projects and real-world applications'
    },
    {
      icon: 'fas fa-certificate',
      title: 'Certified Courses',
      description: 'Earn recognized certificates upon course completion'
    },
    {
      icon: 'fas fa-users',
      title: 'Community Support',
      description: 'Connect with fellow learners and get help when you need it'
    },
    {
      icon: 'fas fa-mobile-alt',
      title: 'Learn Anywhere',
      description: 'Access your courses on any device, anytime, anywhere'
    },
    {
      icon: 'fas fa-chart-line',
      title: 'Track Progress',
      description: 'Monitor your learning journey with detailed progress tracking'
    }
  ];

  stats = [
    { number: '50,000+', label: 'Students Enrolled' },
    { number: '1,200+', label: 'Courses Available' },
    { number: '500+', label: 'Expert Instructors' },
    { number: '98%', label: 'Student Satisfaction' }
  ];
}