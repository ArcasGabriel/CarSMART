import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VechicleService {

  constructor(private http: HttpClient) { 
    
  }
 
  create(vehicle) {
    return this.http.post('/api/vehicles', vehicle); 
  }
}
