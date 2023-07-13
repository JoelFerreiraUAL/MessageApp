import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from 'src/app/common/services/auth/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

 public loginForm: FormGroup;

 constructor(private authService:AuthService) {
 }
 ngOnInit(){
  this.prepareForm();
 }
 prepareForm(){
  this.loginForm = new FormGroup({
    email: new FormControl("",[
      Validators.required,
      Validators.email,
    ]),
    password:  new FormControl("",[
      Validators.required,
      Validators.minLength(5)
    ]),
  });
 }
}
