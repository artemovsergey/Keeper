import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './components/users/users.component';
import { UserEditComponent } from './components/user-edit/user-edit.component'
import { RoleEditComponent } from './components/role-edit/role-edit.component';


const routes: Routes = [
  { path: '', component: UsersComponent, pathMatch: 'full' },
  { path: 'user/:id', component: UserEditComponent },
  { path: 'users', component: UsersComponent, pathMatch: 'full' },
  { path: 'user', component: UserEditComponent },

  { path: 'roles/:id', component: RoleEditComponent },
  { path: 'role', component: RoleEditComponent }

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})


export class AppRoutingModule { }
