import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Employee } from "../model/employee";

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {

    private url = "/api/employees";

    constructor(private http: HttpClient) { }

    getEmployees(filter: any) {
        let param = this.url + "?departments=" + (filter.departments == undefined ? '' : filter.departments);
        return this.http.get(param);
    }

    getEmployee(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createEmployee(employee: Employee) {
        return this.http.post(this.url, employee);
    }

    updateEmployee(employee: Employee) {
        return this.http.put(this.url, employee);
    }

    deleteEmployee(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}