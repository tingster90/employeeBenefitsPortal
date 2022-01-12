import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Employee } from "../models/employee";

@Injectable()
export class EmployeesService {
    employeesBaseUrl: string;

    constructor(
        @Inject('BASE_URL') private baseUrl: string, 
        private http: HttpClient,
    ){
        this.employeesBaseUrl = `${this.baseUrl}employees`;
    }

    getAllEmployees(){
        return this.http.get<Employee[]>(this.employeesBaseUrl);
    }

    addEmployee(employee: Employee){
        return this.http.post(this.employeesBaseUrl, employee);
    }

    deleteEmployee(employeeId: string) {
        const route = `${this.employeesBaseUrl}/${employeeId}`;
        return this.http.delete(route);
    }
}