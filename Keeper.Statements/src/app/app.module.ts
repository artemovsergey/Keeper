import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AngularMaterialModule } from './angular-material.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './components/users/users.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserEditComponent } from './components/user-edit/user-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RoleEditComponent } from './components/role-edit/role-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    NavMenuComponent,
    UserEditComponent,
    RoleEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    AngularMaterialModule



  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
