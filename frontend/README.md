# EduHub Frontend

This folder contains all frontend applications and user interfaces for the EduHub platform.

## 📁 Structure

```
frontend/
└── eduhub-angular/     # Main Angular web application
    ├── src/
    │   ├── app/        # Angular application code
    │   ├── assets/     # Static assets (images, fonts, etc.)
    │   └── environments/ # Configuration files
    ├── package.json    # Dependencies and scripts
    └── README.md       # Detailed Angular app documentation
```

## 🚀 Applications

### **eduhub-angular** - Main Web Application
- **Technology**: Angular 17 + TypeScript
- **Port**: 4200
- **Purpose**: Primary web interface for students, instructors, and administrators

## 🛠 Quick Start

### Prerequisites
- Node.js (v16+)
- npm or yarn
- Angular CLI

### Run the Angular App
```bash
cd frontend/eduhub-angular
npm install
npm run serve
```

Open http://localhost:4200

## 🔗 Backend Integration

The frontend applications are configured to work with the EduHub .NET backend:
- **Backend API**: http://localhost:5000/api
- **Frontend Web**: http://localhost:4200

## 🚀 Future Applications

This structure allows for additional frontend applications:
- **Mobile App** (React Native/Flutter)
- **Admin Dashboard** (Separate Angular app)
- **Landing Page** (Static site)
- **Instructor Portal** (Dedicated interface)

## 📱 Development Workflow

1. **Start Backend**: Run the .NET API server
2. **Start Frontend**: Run the Angular development server
3. **Access Application**: Open browser to localhost:4200

Both applications can run simultaneously during development.