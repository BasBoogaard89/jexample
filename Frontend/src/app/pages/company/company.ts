import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MaterialModule } from '../../modules/material-module';
import { CompanyDto, CompanyFilterDto, CompanyService } from '../../generated/api';
import { AxiosHttpRequest } from '../../generated/api/core/AxiosHttpRequest';
import { OpenAPI } from '../../generated/api/core/OpenAPI';
import { Dialog } from '@angular/cdk/dialog';
import { CompanyEdit } from './company-edit/company-edit';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-company',
    imports: [FormsModule, MaterialModule],
    templateUrl: './company.html',
    styleUrl: './company.scss'
})
export class Company implements AfterViewInit {
    @ViewChild(MatSort) sort!: MatSort;

    displayedColumns: string[] = ["name", "vacancies", "options"];
    companies: MatTableDataSource<CompanyDto> = new MatTableDataSource<CompanyDto>();
    filters: CompanyFilterDto = {};
    expandedElement: CompanyDto | null = null;

    private companyService: CompanyService;

    constructor(private dialog: Dialog) {
        const httpRequest = new AxiosHttpRequest(OpenAPI);
        this.companyService = new CompanyService(httpRequest);

        this.getAll();
    }

    ngAfterViewInit() {
        this.companies.sort = this.sort;
    }

    public getAll() {
        this.companyService.postCompanyGetAllFiltered(this.filters).then(result => {
            this.companies.data = result;
        });
    }

    public edit(id: number) {
        this.companyService.getCompany1(id).then(company => {
            if (!company) company = {};
            this.dialog.open(CompanyEdit, { data: company }).closed.subscribe(formData => this.save(id, formData));
        });
    }

    save(id: number, formData: any) {
        if (!formData) return;

        formData['id'] = id;

        this.companyService.postCompany(formData).then(_ => {
            this.getAll();
        });
    }

    public delete(id: number) {
        this.companyService.deleteCompany(id).then(_ => {
            this.getAll();
        });
    }

    isExpanded(element: any) {
        return this.expandedElement === element;
    }

    toggle(element: any) {
        this.expandedElement = this.isExpanded(element) ? null : element;
    }

    confirmDelete(id: number) {
        if (confirm("Weet je het zeker? Je kunt verwijderde data niet meer herstellen")) {
            this.delete(id);
        }
    }
}
