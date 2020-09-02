import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Department } from "../model/department";

@Injectable({
    providedIn: 'root'
})

export class DepartmentService {

    private url = "/api/departments";

    constructor(private http: HttpClient) { }

    getDepartments(filter: any) {
        let param = this.url + "?name=" + (filter.name == undefined ? '' : filter.name);
        return this.http.get(param);
    }

    getDepartment(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createDepartment(department: Department) {
        return this.http.post(this.url, department);
    }

    updateDepartment(department: Department) {
        return this.http.put(this.url, department);
    }

    deleteDepartment(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}