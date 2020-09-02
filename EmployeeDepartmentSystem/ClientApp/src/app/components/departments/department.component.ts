import { Component, OnInit } from "@angular/core";
import { Department } from "../../model/department";
import { DepartmentService } from "../../service/department.service";

@Component({
    selector: "app-department",
    templateUrl: "./department.component.html"
})

export class DepartmentComponent {
    department: Department = new Department();
    departments: Department[];
    status: boolean = true;
    isNew: boolean = true;
    departmentObj: {} = {};
    filter: {} = {};

    constructor(private departmentService: DepartmentService) {
    }

    ngOnInit() {
        this.loadDepartments();
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

    filterForm() {
        this.loadDepartments();
    }

    add() {
        this.departmentObj = {
        };
        this.status = false;
    }

    edit(department) {
        this.status = false;
        this.isNew = false;
        this.departmentObj = department;
    }

    createDepartment(department) {
        this.departmentService.createDepartment(department).subscribe((data: Department) => {
            console.log(data);
            this.loadDepartments();
            this.status = true;
        });
    }


    deleteDepartment(id) {
        this.departmentService.deleteDepartment(id).subscribe(data => {
            this.loadDepartments();
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

    save(department) {
        this.departmentService.updateDepartment(department).subscribe((data) => {
            this.loadDepartments();
            this.status = true;
        },
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });
    }
}