var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from "@angular/core";
let EmployeeService = class EmployeeService {
    constructor(http) {
        this.http = http;
        this.url = "/api/employees";
    }
    getEmployees() {
        return this.http.get(this.url);
    }
    getEmployee(id) {
        return this.http.get(this.url + '/' + id);
    }
    createEmployee(employee) {
        return this.http.post(this.url, employee);
    }
    updateEmployee(employee) {
        return this.http.put(this.url, employee);
    }
    deleteEmployee(id) {
        return this.http.delete(this.url + '/' + id);
    }
};
EmployeeService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], EmployeeService);
export { EmployeeService };
//# sourceMappingURL=employee.service.js.map