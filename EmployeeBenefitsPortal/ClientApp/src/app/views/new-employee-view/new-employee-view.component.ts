import { Component } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators, FormBuilder, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DependentType } from 'src/app/models/dependent-type';
import { Dependent } from 'src/app/models/dependent';
import { Employee } from 'src/app/models/employee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
    selector: 'app-new-employee',
    templateUrl: './new-employee-view.component.html',
    styleUrls: ['./new-employee-view.component.scss']
})
export class NewEmployeeComponent {
    newEmployeeForm: FormGroup;
    showSpouse = false;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private employeesSvc: EmployeesService
    ){
        this.initForm();
    }

    initForm() {
        this.newEmployeeForm = this.formBuilder.group({
            firstName: new FormControl(null, [Validators.required]),
            lastName: new FormControl(null, [Validators.required]),
            spouseFirstName: new FormControl(null),
            spouseLastName: new FormControl(null),
            children: this.formBuilder.array([])
        });
    }

    addSpouse() {
        this.markCtrlAsRequired(this.newEmployeeForm.controls['spouseFirstName']);
        this.markCtrlAsRequired(this.newEmployeeForm.controls['spouseLastName']);
        this.showSpouse = true;
    }

    removeSpouse() {
        this.resetCtrl(this.newEmployeeForm.controls['spouseFirstName']);
        this.resetCtrl(this.newEmployeeForm.controls['spouseLastName'])
        this.showSpouse = false;
    }

    addChild() {
        let newChild = this.newChild();
        this.markCtrlAsRequired(newChild.controls['firstName']);
        this.markCtrlAsRequired(newChild.controls['lastName']);
        this.children().push(newChild);
    }

    children() {
        return this.newEmployeeForm.get('children') as FormArray;
    }

    newChild() {
        return this.formBuilder.group({
            firstName: '',
            lastName: '',
            type: new FormControl(DependentType.Child)
        })
    }

    removeChild(idx: number) {
        let children = this.children() as FormArray;
        let child = children.controls[idx] as FormGroup;
        this.resetCtrl(child.controls['firstName']);
        this.resetCtrl(child.controls['lastName']);
        this.children().removeAt(idx);
    }

    markCtrlAsRequired(ctrl: AbstractControl) {
        ctrl.setValidators(Validators.required);
        ctrl.updateValueAndValidity();
    }

    resetCtrl(ctrl: AbstractControl) {
        ctrl.setValue(null);
        ctrl.clearValidators();
        ctrl.updateValueAndValidity();
    }

    createEmployee() {
        const formValues = this.newEmployeeForm.value;
        let dependents = <Dependent[]> [];

        if (formValues.spouseFirstName !== null && formValues.spouseLastName !== null) {
            dependents.push({ firstName: formValues.spouseFirstName, lastName: formValues.spouseLastName, type: DependentType.Spouse });
        }

        if (formValues.children && formValues.children.length > 0) {
            formValues.children.forEach(child => {
                dependents.push(child);
            });
        }

        let employee = <Employee>{
            firstName: formValues.firstName,
            lastName: formValues.lastName,
            dependents: dependents
        }

        this.employeesSvc.addEmployee(employee).subscribe(result => {
            this.router.navigateByUrl('/');
        }, error => console.error(error));
    }
}
