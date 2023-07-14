import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayoutComponent } from './common/layout/main-layout/main-layout.component';
import { RouterModule, Routes } from '@angular/router';
import { AuthLayoutComponent } from './common/layout/auth-layout/auth-layout.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { CanActiveGuard } from './common/guards/can-active.guard';


const routes: Routes = [
  { path: '', component: MainLayoutComponent,canActivate:[CanActiveGuard] },
  { path: 'auth', component: AuthLayoutComponent, children:[

    {path: 'login', component: LoginComponent, },
    { path: 'register', component: RegisterComponent, }
  ] }

];

@NgModule({
  declarations: [],
  exports: [ RouterModule ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
