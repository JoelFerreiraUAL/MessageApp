import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/common/services/auth/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

 public loginForm: FormGroup;
 public isLoading=false;
 constructor(private authService:AuthService,private router: Router) {
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
 onSubmit(){
  if(!this.loginForm.valid)return
  this.isLoading=true;
  const {email,password}=this.loginForm.value;
  this.authService.login(email,password).subscribe((result:any)=>{
    this.isLoading=false;
    this.router.navigate(["/"]);
  })
 }
}
