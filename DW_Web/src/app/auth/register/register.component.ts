import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';
import { AlertsService } from '../../services/alerts.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{

  public formSubmitted = false;

  public regsiterForm = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    surname: ['', [Validators.required, Validators.minLength(3)]],
    username: ['', [Validators.required, Validators.minLength(2)]],
    email: ['', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
    password: ['', Validators.required, Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$')],
    password2: ['', Validators.required]
  }, {
    validators: this.equalsPasswords('password','password2')
  }
  );

  constructor(private fb: FormBuilder, private userService: UserService, private router: Router, private alertsService: AlertsService) { }

  createUser(){
    this.formSubmitted = true;
    if(this.regsiterForm.invalid){
      return;
    }

    this.userService.createUser(this.regsiterForm.value).subscribe(resp => {
      this.router.navigateByUrl('/');
    }, (err) => {
      console.warn(err);
      this.alertsService.getShowAlert('Error', 'El usuario ya existe', 'error')
    });
  }

  invalidField(field: string): boolean{
    return (this.regsiterForm.get(field)?.invalid && this.formSubmitted) ? true : false;
  }

  invalidPasswords(): boolean{
    const pass1 = this.regsiterForm.get('password')?.value;
    const pass2 = this.regsiterForm.get('password2')?.value;
    if((pass1 !== pass2) && this.formSubmitted){
      return true;
    }else{
      return false;
    }
  }

  equalsPasswords(pass1: string, pass2: string){
    return (formGroup: FormGroup)=> {
      const pass1Control = formGroup.get(pass1);
      const pass2Control = formGroup.get(pass2);
      if(pass1Control?.value === pass2Control?.value){
        pass2Control?.setErrors(null);
      }else{
        pass2Control?.setErrors({ noEquals: true });
      }
    }
  }
}
