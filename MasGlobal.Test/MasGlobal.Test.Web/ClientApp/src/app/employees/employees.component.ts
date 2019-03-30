import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { FormGroup, FormBuilder } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
/** employees component*/
export class EmployeesComponent implements OnInit {

  employees: Array<Employee> = new Array<Employee>();
  employeeForm: FormGroup;
  loading = false;
  submitted = false;

  /** employees ctor */
  constructor(private formBuilder: FormBuilder,
    private employeeService: EmployeeService) {

  }

  ngOnInit(): void {
    this.employeeForm = this.formBuilder.group({
      txtId: ['']
    });
  }

  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;    
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }

  get f() { return this.employeeForm.controls; }

  getEmployees(id: number) {
    this.employeeService.getEmployees(id)
      .then(
        data => {
          this.employees = null;
          if (data) {
            this.employees = data as Array<Employee>;
            this.loading = false;
          }
        }).catch(error => {
          alert(error);
          this.loading = false;
        });
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.employeeForm.invalid) {
      return;
    }
    this.loading = true;

    this.getEmployees(this.f.txtId.value === "" ? null : this.f.txtId.value);
  }
}
