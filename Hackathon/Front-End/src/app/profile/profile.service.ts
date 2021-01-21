import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile } from './profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private url = 'http://localhost:3000/profiles';

  readonly headers = new HttpHeaders({
    'X-PO-SCREEN-LOCK': 'true'
  });

  constructor(private http: HttpClient) { }

  save(profile: Profile) {
    return this.http.post(this.url, profile, { headers: this.headers});
  }

  update(id, profile: Profile) {
    return this.http.put(`${this.url}/${id}`, profile, { headers: this.headers});
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`, { headers: this.headers });
  }

  getAll(): Observable<Array<Profile>> {
    return this.http.get(this.url) as Observable<Array<Profile>>;
  }

  get(id: number) {
    return this.http.get(`${this.url}/${id}`, { headers: this.headers });
  }

}
