import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, AbstractControl, AsyncValidatorFn} from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../enviroments/enviroment';
import { Role } from '../../models/user.model';

@Component({
  selector: 'app-role-edit',
  templateUrl: './role-edit.component.html',
  styleUrl: './role-edit.component.scss'
})

export class RoleEditComponent implements OnInit {

  title?: string;
  form!: FormGroup;
  role?: Role;
  id?: number;
  roles?: Role[];

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient) {
  }

  ngOnInit() {
    this.form = this.fb.group({
      name: ['',
        Validators.required,
        this.isRoleUniq()
      ], 
    });

    this.loadData();
  }


  loadData() {
    // retrieve the ID from the 'id' parameter
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = idParam ? +idParam : 0;
    if (this.id) {
      // EDIT MODE
      // fetch the role from the server
      var url = environment.baseUrl + "api/Roles/" + this.id;
      this.http.get<Role>(url).subscribe(result => {
        this.role = result;
        this.title = "Редактировать - " + this.role.name;
        // update the form with the role value
        this.form.patchValue(this.role);
      }, error => console.error(error));
    }
    else {
      // ADD NEW MODE
      this.title = "Создать новую роль";
    }
  }


  onSubmit() {
    var role = (this.id) ? this.role : <Role>{};
    if (role) {
      role.name = this.form.controls['name'].value;

      if (this.id) {
        // EDIT mode
        var url = environment.baseUrl + 'api/Roles/' + role.id;
        this.http
          .put<Role>(url, role)
          .subscribe(result => {

            console.log("Роль " + role!.id + " обновлена");
            // go back to roles view
            this.router.navigate(['/roles']);
          }, error => console.error(error));
      }
      else {
        // ADD NEW mode
        var url = environment.baseUrl + 'api/Roles';
        this.http
          .post<Role>(url, role)
          .subscribe(result => {
            console.log("Роль " + result.id + " создана");
            // go back to roles view
            this.router.navigate(['/roles']);
          }, error => console.error(error));
      }
    }
  }

  isRoleUniq(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{
      [key: string]: any
    } | null> => {

      var role = <Role>{};
      role.id = (this.id) ? this.id : 0;
      role.name = this.form.controls['name'].value;

      var url = environment.baseUrl + 'api/Roles/IsUniqName';
      return this.http.post<boolean>(url, role)
        .pipe(map(result => {
          return (result ? { isRoleUniq: true } : null);
        }));
    }
  }
}
