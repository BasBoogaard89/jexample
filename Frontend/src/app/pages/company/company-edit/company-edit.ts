import { Component, inject } from '@angular/core';
import { MaterialModule } from '../../../modules/material-module';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';

@Component({
    selector: 'app-company-edit',
    imports: [CommonModule, MaterialModule, ReactiveFormsModule],
    templateUrl: './company-edit.html',
    styleUrl: './company-edit.scss'
})
export class CompanyEdit {
    companyForm: FormGroup;
    dialogRef = inject(DialogRef<CompanyEdit>);
    data = inject(DIALOG_DATA);

    constructor(private fb: FormBuilder) {
        this.companyForm = this.fb.group({
            name: ['', Validators.required],
            address: this.fb.group({
                street: ['', Validators.required],
                number: ['', Validators.required],
                zipCode: ['', Validators.required],
                city: ['', Validators.required]
            }),
            vacancies: this.fb.array([])
        });

        this.companyForm.patchValue(this.data);

        this.addVacancy();
    }

    get vacancies(): FormArray {
        return this.companyForm.get('vacancies') as FormArray;
    }

    addVacancy(): void {
        const vacancyGroup = this.fb.group({
            title: ['', Validators.required],
            content: ['']
        });

        this.vacancies.push(vacancyGroup);
    }

    onSubmit(): void {
        if (this.companyForm.valid) {
            this.dialogRef.close(this.companyForm.value);
        }
    }
}
