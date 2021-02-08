import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { AlertsService } from '../../services/alerts.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public formSubmitted = false;

  public loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
    password: ['', Validators.required]
  });

  constructor(private router: Router, private fb: FormBuilder, private userService: UserService, private alertsService: AlertsService) { }

  ngOnInit(): void {
  }

  login(){
    this.formSubmitted = true;
    if(this.loginForm.invalid){
      return;
    }

    this.userService.login(this.loginForm.value).subscribe(resp => {
      this.router.navigateByUrl('/');
    }, (err) => {
      console.warn(err);
      this.alertsService.getShowAlert('Error', 'Error al ingresar', 'error')
    })
  }

  invalidField(field: string): boolean{
    return (this.loginForm.get(field)?.invalid && this.formSubmitted) ? true : false;
  }

}
