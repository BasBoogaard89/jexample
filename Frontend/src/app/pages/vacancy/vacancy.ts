import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MaterialModule } from '../../modules/material-module';
import { CompanyDto, CompanyService, VacancyDto, VacancyFilterDto, VacancyService } from '../../generated/api';
import { AxiosHttpRequest } from '../../generated/api/core/AxiosHttpRequest';
import { OpenAPI } from '../../generated/api/core/OpenAPI';
import { Dialog } from '@angular/cdk/dialog';
import { VacancyEdit } from './vacancy-edit/vacancy-edit';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { FormsModule } from '@angular/forms';
import { CommonModule, SlicePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-vacancy',
    imports: [CommonModule, FormsModule, MaterialModule, SlicePipe],
    templateUrl: './vacancy.html',
    styleUrl: './vacancy.scss'
})
export class Vacancy implements AfterViewInit {
    @ViewChild(MatSort) sort!: MatSort;

    displayedColumns: string[] = ["title", "company.name", "options"];
    vacancies: MatTableDataSource<VacancyDto> = new MatTableDataSource<VacancyDto>();
    companies: CompanyDto[] = [];
    filters: VacancyFilterDto = {};

    private vacancyService: VacancyService;
    private companyService: CompanyService;

    constructor(private dialog: Dialog, private route: ActivatedRoute) {
        const httpRequest = new AxiosHttpRequest(OpenAPI);
        this.vacancyService = new VacancyService(httpRequest);
        this.companyService = new CompanyService(httpRequest);

        this.getAll();
        this.getCompanies();

        this.route.queryParamMap.subscribe(params => {
            const companyId = params.get('companyId');
            if (companyId)
                this.filters.companyId = parseInt(companyId, 10);
        });
    }

    ngAfterViewInit() {
        this.vacancies.sort = this.sort;
    }

    public getAll() {
        this.vacancyService.postVacancyGetAllFiltered(this.filters).then(result => {
            this.vacancies.data = result;
        });
    }

    public edit(id: number) {
        this.vacancyService.getVacancy1(id).then(vacancy => {
            this.dialog.open(VacancyEdit, { data: { vacancy: vacancy, companies: this.companies } }).closed.subscribe(formData => this.save(id, formData));
        });
    }

    save(id: number, formData: any) {
        if (!formData) return;

        formData['id'] = id;

        this.vacancyService.postVacancy(formData).then(_ => {
            this.getAll();
        });
    }

    public delete(id: number) {
        this.vacancyService.deleteVacancy(id).then(_ => {
            this.getAll();
        });
    }

    getCompanies() {
        this.companyService.getCompany().then(result => {
            this.companies = result;
        });
    }

    confirmDelete(id: number) {
        if (confirm("Weet je het zeker? Je kunt verwijderde data niet meer herstellen")) {
            this.delete(id);
        }
    }
}
