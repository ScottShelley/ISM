import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ContactPageComponent } from './components/contact/contact-page/contact-page.component';
import { AboutPageComponent } from './components/about-page/about-page.component';
import { EducationServicesComponent } from './components/education-services/education-services.component';
import { MigrationServicesComponent } from './components/migration-services/migration-services.component';
import { LanguageServicesComponent } from './components/language-services/language-services.component';
import { AustraliaOfficeComponent } from './components/contact/australia-office/australia-office.component';
import { ThailandOfficeComponent } from './components/contact/thailand-office/thailand-office.component';
import { TurkeyOfficeComponent } from './components/contact/turkey-office/turkey-office.component';
import { VisasPagesComponent } from './components/visas-pages/visas-pages.component';
import { CourseComponent } from './components/course/course.component';
import { SearchbyComponent } from './components/searchby/searchby.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'about-us', component: AboutPageComponent},
  { path: 'contact-us', component: ContactPageComponent},
  { path: 'australia-contact', component: AustraliaOfficeComponent},
  { path: 'thailand-contact', component: ThailandOfficeComponent},
  { path: 'turkey-contact', component: TurkeyOfficeComponent},
  { path: 'education-services', component: EducationServicesComponent},
  { path: 'education-services/searchby/:value', component: SearchbyComponent},
  { path: 'education-services/searchby', redirectTo: "education-services"},
  { path: 'education-services/course/:id', component: CourseComponent},
  { path: 'education-services/course', redirectTo: "education-services"},
  { path: 'migration-services', component: MigrationServicesComponent},
  { path: 'migration-services/:url', component: VisasPagesComponent},
  { path: 'language-services', component: LanguageServicesComponent},
  { path: 'course', component: CourseComponent},
  { path: '**', component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
