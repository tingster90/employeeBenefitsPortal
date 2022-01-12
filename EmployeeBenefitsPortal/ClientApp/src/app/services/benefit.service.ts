import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { BenefitOverview } from "../models/benefit-overview";

@Injectable()
export class BenefitService {
    constructor(
        @Inject('BASE_URL') private baseUrl: string, 
        private http: HttpClient,
    ){}
    
    getBenefitCostPreview(employeeId: string){
        const route = `${this.baseUrl}benefit/${employeeId}`;
        return this.http.get<BenefitOverview>(route);
    }
}