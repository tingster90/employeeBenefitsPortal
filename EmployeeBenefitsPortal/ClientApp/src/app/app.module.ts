import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { EmployeesComponent } from './views/employees-view/employees-view.component';
import { NewEmployeeComponent } from './views/new-employee-view/new-employee-view.component';
import { BenefitService } from './services/benefit.service';
import { EmployeesService } from './services/employees.service';

@NgModule({
    declarations: [
        AppComponent,
        NewEmployeeComponent,
        EmployeesComponent,
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', component: EmployeesComponent, pathMatch: 'full' },
            { path: 'add', component: NewEmployeeComponent },
        ])
    ],
    providers: [
        BenefitService,
        EmployeesService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
