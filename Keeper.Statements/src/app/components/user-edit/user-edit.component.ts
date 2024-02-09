import { Component, OnInit } from '@angular/core';
import { HttpClient,HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn} from '@angular/forms';
import { environment } from '../../../enviroments/enviroment'

import { User, Role } from '../../models/user.model'

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrl: './user-edit.component.scss'
})

export class UserEditComponent {

  title?: string;
  form!: FormGroup;
  user?: User;
  id?: number;
  roles?: Role[];


  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient) {
  }


  ngOnInit() {
    this.form = new FormGroup({
      email: new FormControl('',Validators.required),
      login: new FormControl('',Validators.required),
      password: new FormControl('',Validators.required),
      roleId: new FormControl('',Validators.required)
    }, null, this.isUniqEmail());

    this.loadData();
  }

  loadData() {

    this.loadRoles();
    console.log(this.loadRoles());

    // retrieve the ID from the 'id' parameter
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = idParam ? +idParam : 0;
    if (this.id) {
      // EDIT MODE
      // fetch the User from the server
      var url = environment.baseUrl + 'api/Users/' + this.id;
      this.http.get<User>(url).subscribe(result => {
        this.user = result;
        this.title = "Edit - " + this.user.email;
        // update the form with the User value
        this.form.patchValue(this.user);
      }, error => console.error(error));
    }
    else {
      // ADD NEW MODE
      this.title = "Create a new User";
    }
  }


  loadRoles() {
    // fetch all the roles from the server
    var url = environment.baseUrl + 'api/Roles';

    // var params = new HttpParams()
    // .set("pageIndex", "0")
    // .set("pageSize", "9999")
    // .set("sortColumn", "name");
    
    this.http.get<Role[]>(url).subscribe(response => {
    this.roles = response;
    console.log(response);
    }, error => console.error(error));
    }


  onSubmit() {
    var user = (this.id) ? this.user : <User>{};
    if (user) {
      user.email = this.form.controls['email'].value;
      user.login = this.form.controls['login'].value;
      user.password = this.form.controls['password'].value;
      user.roleId = this.form.controls['roleId'].value;

      if (this.id) {
        // EDIT mode
        var url = environment.baseUrl + 'api/Users/' + user.id;
        this.http
          .put<User>(url, user)
          .subscribe(result => {
            console.log("User " + user!.id + " has been updated.");
            // go back to cities view
            this.router.navigate(['/users']);
          }, error => console.error(error));
      }
      else {
        // ADD NEW mode
        var url = environment.baseUrl + 'api/Users';
        this.http
          .post<User>(url,user)
          .subscribe(result => {
            console.log("User " + result.id + " has been created.");
            // go back to cities view
            this.router.navigate(['/users']);
          }, error => console.error(error));
      }
    }
  }


  isUniqEmail(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{ [key: string]: any } |
   null> => {
    var user = <User>{};
    user.id = (this.id) ? this.id : 0;
    user.login = this.form.controls['login'].value;
    user.email = this.form.controls['email'].value;
    user.password = this.form.controls['password'].value;
    user.roleId = this.form.controls['roleId'].value;
    var url = environment.baseUrl + 'api/Users/isUniqEmail';
    return this.http.post<boolean>(url, user).pipe(map(result => {
    return (result ? { isUniqEmail: true } : null);
    }));
    }
   
    }

}

