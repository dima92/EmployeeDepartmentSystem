import { Component, OnInit } from "@angular/core";
import { Employee } from "../../model/employee";
import { EmployeeService } from "../../service/employee.service";
import { Department } from "../../model/department";
import { DepartmentService } from "../../service/department.service";
import { writeFileSync } from "fs";

@Component({
    selector: "app-employee",
    templateUrl: "./employee.component.html"
})
export class EmployeeComponent implements OnInit {

    employee: Employee = new Employee();
    employees: Employee[];
    department: Department = new Department();
    departments: Department[];
    status: boolean = true;
    isNew: boolean = true;
    employeeObj: {} = {};
    filter: {} = {};

    constructor(private employeeService: EmployeeService,
        private departmentService: DepartmentService) {
    }

    ngOnInit() {
        this.loadDepartments();
        this.loadEmployees();
    }

    loadEmployees() {
        this.employeeService.getEmployees(this.filter).subscribe((data: Employee[]) => {
            this.employees = data;
        },
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });
    }


    loadDepartments() {
        this.departmentService.getDepartments(this.filter).subscribe((data: Department[]) => {
            this.departments = data;
        },
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });
    }

    serializable() {
        this.employeeService.getEmployees(this.filter).subscribe((data: Employee[]) => {
            this.employees = data;
            let serialization = JSON.stringify(this.employees);
            console.log(serialization);
        })  
    }

    filterForm() {
        this.loadEmployees();
    }

    add() {
        this.employeeObj = {};
        this.status = false;
    }

    edit(employee) {
        this.status = false;
        this.isNew = false;
        console.log(this.employeeObj, employee);
        this.employeeObj = employee;

    }

    createEmployee(employee) {
        employee.departmentId = + employee.departmentId;
        this.employeeService.createEmployee(employee).subscribe((data: Employee) => {
            this.loadEmployees();
            this.status = true;
        });
    }


    deleteEmployee(id) {
        this.employeeService.deleteEmployee(id).subscribe(data => {
            this.loadEmployees();
        }),
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            };
    }

    cancel() {
        this.status = true;
        this.isNew = true;
    }

    save(employee) {
        this.employeeService.updateEmployee(employee).subscribe((data) => {
            this.loadEmployees();
            this.status = true;
        },
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });
    }
}