import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmployeeService {
  constructor(private http: HttpClient
    , @Inject('BASE_URL') private baseUrl: string) {

  }
  getEmployees(id: number) {
    return this.http.get(this.baseUrl + (id ? `api/employees/GetEmployees?id=${id}` : `api/employees/GetEmployees`)).toPromise()
      .then(result => {
        return result;
      });
  }
}
