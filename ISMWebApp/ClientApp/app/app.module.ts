import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { FooterComponent } from './components/footer/footer.component';
import { ContactPageComponent } from './components/contact/contact-page/contact-page.component';
import { AboutPageComponent } from './components/about-page/about-page.component';
import { EducationServicesComponent } from './components/education-services/education-services.component';
import { MigrationServicesComponent } from './components/migration-services/migration-services.component';
import { LanguageServicesComponent } from './components/language-services/language-services.component';
import { ContactFormComponent } from './components/contact/contact-form/contact-form.component';
import { AustraliaOfficeComponent } from './components/contact/australia-office/australia-office.component';
import { ThailandOfficeComponent } from './components/contact/thailand-office/thailand-office.component';
import { TurkeyOfficeComponent } from './components/contact/turkey-office/turkey-office.component';
import { VisasService } from './services/visas.service';
import { VisasPagesComponent } from './components/visas-pages/visas-pages.component';
import { CourseComponent } from './components/course/course.component';
import { InstituteService } from './services/institute.service';
import { CourseService } from './services/course.service';
import { SearchbyComponent } from './components/searchby/searchby.component';
import { EnrollFormComponent } from './components/enroll-form/enroll-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    NotFoundComponent,
    FooterComponent,
    ContactPageComponent,
    AboutPageComponent,
    EducationServicesComponent,
    MigrationServicesComponent,
    LanguageServicesComponent,
    ContactFormComponent,
    AustraliaOfficeComponent,
    ThailandOfficeComponent,
    TurkeyOfficeComponent,
    VisasPagesComponent,
    CourseComponent,
    SearchbyComponent,
    EnrollFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    VisasService,
    InstituteService,
    CourseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
