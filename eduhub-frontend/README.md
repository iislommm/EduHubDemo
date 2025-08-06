# EduHub Frontend

A modern, responsive Angular application for the EduHub online learning platform.

## 🚀 Features

### ✅ Implemented Features

- **Modern UI/UX**: Beautiful, responsive design with Bootstrap 5 and custom SCSS
- **Authentication System**: Complete login/register functionality with JWT token management
- **Navigation**: Fixed navbar with search functionality and user menu
- **Homepage**: Hero section, featured courses, categories, and statistics
- **About Us Page**: Team information, mission/vision, and contact details
- **Routing**: Protected routes with authentication guards
- **API Integration**: HTTP client setup with interceptors for authentication
- **Responsive Design**: Mobile-first approach with modern CSS animations

### 🔄 Ready for Implementation

- **User Dashboard**: Profile management and channel creation
- **Video Browsing**: Category filtering and search functionality
- **Video Player**: Detailed video pages with comments and likes
- **Instructor Channels**: Channel management and video uploads
- **Admin Panel**: User and category management for administrators

## 🛠 Technology Stack

- **Angular 17**: Latest Angular framework
- **TypeScript**: Type-safe development
- **Bootstrap 5**: Modern CSS framework
- **SCSS**: Enhanced CSS with variables and mixins
- **RxJS**: Reactive programming for HTTP requests
- **Font Awesome**: Icon library
- **Google Fonts**: Inter font family

## 📁 Project Structure

```
src/
├── app/
│   ├── components/
│   │   ├── auth/           # Login & Register components
│   │   ├── home/           # Homepage component
│   │   ├── navbar/         # Navigation component
│   │   ├── shared/         # Shared components (About, etc.)
│   │   ├── dashboard/      # User dashboard
│   │   ├── video/          # Video-related components
│   │   └── admin/          # Admin panel
│   ├── models/             # TypeScript interfaces and DTOs
│   ├── services/           # API services
│   ├── guards/             # Route guards
│   ├── interceptors/       # HTTP interceptors
│   └── app.module.ts       # Main application module
├── environments/           # Environment configurations
├── assets/                 # Static assets
└── styles.scss            # Global styles
```

## 🚀 Getting Started

### Prerequisites

- Node.js (v16 or higher)
- npm or yarn
- Angular CLI

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd eduhub-frontend
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Configure environment**
   - Update `src/environments/environment.ts` with your API URL
   - Default API URL: `http://localhost:5000/api`
   - Telegram contact link: `https://t.me/sayfalseee`

4. **Start the development server**
   ```bash
   npm run serve
   ```
   or
   ```bash
   ng serve --host 0.0.0.0 --port 4200
   ```

5. **Open your browser**
   Navigate to `http://localhost:4200`

## 🔧 Configuration

### Environment Variables

Update the environment files with your configuration:

```typescript
// src/environments/environment.ts
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api',
  telegramLink: 'https://t.me/sayfalseee'
};
```

### API Integration

The application is configured to work with a .NET backend API. Ensure your backend is running on the configured API URL.

## 📱 Features Overview

### Authentication
- **Login**: Email/password authentication
- **Register**: User registration with validation
- **JWT Token Management**: Automatic token handling
- **Route Protection**: Guards for authenticated and admin routes

### Navigation
- **Responsive Navbar**: Fixed navigation with mobile support
- **Search Functionality**: Global search across courses
- **User Menu**: Profile dropdown with logout functionality
- **Contact Integration**: Direct Telegram link

### Homepage
- **Hero Section**: Engaging landing with search
- **Featured Courses**: Showcase of popular content
- **Categories**: Browse by subject areas
- **Statistics**: Platform metrics and achievements

### User Experience
- **Loading States**: Smooth loading indicators
- **Error Handling**: User-friendly error messages
- **Form Validation**: Real-time form validation
- **Animations**: Smooth CSS transitions and animations

## 🎨 Design System

### Color Palette
- **Primary**: #4f46e5 (Indigo)
- **Secondary**: #10b981 (Emerald)
- **Background**: #f8f9fa (Light gray)
- **Text**: #333 (Dark gray)

### Typography
- **Font Family**: Inter (Google Fonts)
- **Font Weights**: 300, 400, 500, 600, 700

### Components
- **Cards**: Elevated design with hover effects
- **Buttons**: Rounded corners with smooth transitions
- **Forms**: Clean inputs with validation states
- **Navigation**: Fixed header with dropdown menus

## 🚧 Development Roadmap

### Phase 1: Core Features (Completed ✅)
- [x] Project setup and configuration
- [x] Authentication system
- [x] Navigation and routing
- [x] Homepage with featured content
- [x] About Us page
- [x] Responsive design

### Phase 2: User Features (Ready for Implementation)
- [ ] User dashboard and profile management
- [ ] Video browsing and filtering
- [ ] Video player with interactions
- [ ] Comment system
- [ ] User enrollment and progress tracking

### Phase 3: Instructor Features
- [ ] Channel creation and management
- [ ] Video upload functionality
- [ ] Analytics and reporting
- [ ] Revenue tracking

### Phase 4: Admin Features
- [ ] User management
- [ ] Category management
- [ ] Content moderation
- [ ] Platform analytics

## 🧪 Testing

Run the test suite:
```bash
npm test
```

Build for production:
```bash
npm run build
```

## 📦 Deployment

### Production Build
```bash
ng build --configuration=production
```

### Docker Support
Create a Dockerfile for containerized deployment:

```dockerfile
FROM node:18-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

FROM nginx:alpine
COPY --from=build /app/dist/eduhub-frontend /usr/share/nginx/html
EXPOSE 80
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is licensed under the MIT License.

## 📞 Support

For support and questions:
- **Telegram**: [https://t.me/sayfalseee](https://t.me/sayfalseee)
- **Email**: Contact through the platform

## 🙏 Acknowledgments

- Angular team for the amazing framework
- Bootstrap team for the CSS framework
- Font Awesome for the icon library
- Google Fonts for the typography

---

**EduHub** - Empowering education through technology 🎓