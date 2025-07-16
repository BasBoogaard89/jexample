import { Component } from '@angular/core';
import { MaterialModule } from '../../modules/material-module';
import { CompanyDto, CompanyService } from '../../generated/api';
import { AxiosHttpRequest } from '../../generated/api/core/AxiosHttpRequest';
import { OpenAPI } from '../../generated/api/core/OpenAPI';
import { Dialog, DialogRef } from '@angular/cdk/dialog';
import { CompanyEdit } from './company-edit/company-edit';

@Component({
    selector: 'app-company',
    imports: [MaterialModule],
    templateUrl: './company.html',
    styleUrl: './company.scss'
})
export class Company {
    displayedColumns: string[] = ["id", "name", "options"];
    companies: CompanyDto[] = [];

    private companyService: CompanyService;

    constructor(private dialog: Dialog) {
        const httpRequest = new AxiosHttpRequest(OpenAPI);
        this.companyService = new CompanyService(httpRequest);

        this.getAll();
    }

    public getAll(): void {
        this.companyService.getCompany().then(result => {
            this.companies = result;
            console.log(this.companies);
        });
    }

    public edit(id: number) {
        this.companyService.getCompany1(id).then(company => {
            this.dialog.open(CompanyEdit, { data: company }).closed.subscribe(formData => this.save(id, formData));
        });
    }

    save(id: number, formData: any) {
        formData['id'] = id;
        
        this.companyService.postCompany(formData).then(_ => {
           this.getAll();
        });
    }

    public delete(id: number) {
        this.companyService.deleteCompany(id).then(id => {
            this.getAll();
        });
    }
}
