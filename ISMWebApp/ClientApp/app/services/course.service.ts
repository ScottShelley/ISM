import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CourseService {

  constructor(private http: HttpClient) { }

  public get() {
    return this.http.get('/api/course');
  }

  public getById(id: number) {
    return this.http.get(`/api/course/${id}`);
  }

  public getCourseInstituteById(id: number) {
    return this.http.get(`/api/course/courseinstitute/${id}`);
  }

}
