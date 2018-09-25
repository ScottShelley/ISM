import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class InstituteService {

  constructor(private http: HttpClient) { }

  
  public get() {
    return this.http.get('/api/institute');
  }
  

}
