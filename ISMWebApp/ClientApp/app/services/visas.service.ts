import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class VisasService {

  constructor(private http: HttpClient) { }

  getVisasCategory() {
      return this.http.get('/api/visas/');
  }

  getVisasByUrl(url: string) {
      return this.http.get(`/api/visas/${url}`);
  }

}
