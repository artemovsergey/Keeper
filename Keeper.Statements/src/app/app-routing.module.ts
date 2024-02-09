import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component'
import { RoleEditComponent } from './role/role-edit.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'user/:id', component: LoginComponent },
  { path: 'users', component: HomeComponent, pathMatch: 'full' },
  { path: 'user', component: LoginComponent },

  { path: 'roles/:id', component: RoleEditComponent },
  { path: 'role', component: RoleEditComponent }

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})


export class AppRoutingModule { }
