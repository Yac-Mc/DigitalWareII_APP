import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { RegisterForm } from '../interfaces/register-form';
import { LoginForm } from '../interfaces/login-form';
import { Router } from '@angular/router';

const base_url = environment.base_url;

@Injectable({
  providedIn: 'root'
})
export class UserService {

  token: string = '';

  constructor(private http: HttpClient, private router: Router) { }

  validateToken(): Observable<boolean>{
    this.token = localStorage.getItem('token') || '';
    return this.http.get(`${base_url}/user`).pipe(
      tap( (resp: any) =>  { localStorage.setItem('token', resp.token) }
      ),
      map(resp => true),
      catchError(error => of(false))
    );
  }

  createUser(formData: RegisterForm){
    return this.http.post(`${base_url}/user/register`, formData)
    .pipe(
      tap( (resp: any) => {
        localStorage.setItem('token', resp.token)
      })
    )
  }

  login(formData: LoginForm){
    return this.http.post(`${base_url}/user/login`, formData)
      .pipe(
        tap( (resp: any) => {
          localStorage.setItem('token', resp.token)
        })
      )
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login')
  }

  getToken() {
    return this.token;
  }
}
