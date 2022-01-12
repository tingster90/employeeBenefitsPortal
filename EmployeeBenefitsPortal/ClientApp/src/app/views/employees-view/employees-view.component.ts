import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee';
import { BenefitOverview } from 'src/app/models/benefit-overview';
import { EmployeesService } from 'src/app/services/employees.service';
import { BenefitService } from 'src/app/services/benefit.service';
import { DependentType } from 'src/app/models/dependent-type';

@Component({
    selector: 'app-employees',
    templateUrl: './employees-view.component.html',
    styleUrls: ['./employees-view.component.scss'],
})
export class EmployeesComponent implements OnInit {
    employees: Employee[] = [];
    benefitOverview: BenefitOverview;
    showBenefitCost = false;
    DependentType = DependentType;
    selectedEmployeeId: string;

    constructor(
        private benefitSvc: BenefitService,
        private employeeSvc: EmployeesService,
        private router: Router
    ) {}

    ngOnInit() {
        this.getAllEmployees();
    }

    addEmployee() {
        this.router.navigateByUrl('/add');
    }

    getAllEmployees() {
        this.employeeSvc.getAllEmployees().subscribe(result => {
            this.employees = result;
        }, error => console.error(error));
    }

    previewBenefitCost(employeeId: string) {
        this.benefitSvc.getBenefitCostPreview(employeeId).subscribe(
            result => {
                this.benefitOverview = result;
                this.showBenefitCost = true;
                this.selectedEmployeeId = employeeId;
            }, error => {
                console.error(error);
                this.showBenefitCost = false;
            });
    }

    deleteEmployee(employeeId: string) {
        this.employeeSvc.deleteEmployee(employeeId).subscribe(() => {
            this.employees = this.employees.filter(employee => employee.id !== employeeId);

            if (this.benefitOverview.employeeId === employeeId) {
                this.benefitOverview = null;
                this.showBenefitCost = false;
            }
        }, error => console.error(error));
    }
}
