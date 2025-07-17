import { Component, inject } from '@angular/core';
import { MaterialModule } from '../../../modules/material-module';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-company-edit',
    imports: [CommonModule, MaterialModule, ReactiveFormsModule, RouterModule],
    templateUrl: './company-edit.html',
    styleUrl: './company-edit.scss'
})
export class CompanyEdit {
    form: FormGroup;
    dialogRef = inject(DialogRef<CompanyEdit>);
    data = inject(DIALOG_DATA);
    hasVacancies = this.data.vacancies && this.data.vacancies.length > 0;

    constructor(private fb: FormBuilder) {
        this.form = this.fb.group({
            name: ['', Validators.required],
            address: this.fb.group({
                street: ['', Validators.required],
                number: ['', Validators.required],
                zipCode: ['', Validators.required],
                city: ['', Validators.required]
            })
        });

        this.form.patchValue(this.data);
    }

    onSubmit(): void {
        if (this.form.valid) {
            this.dialogRef.close(this.form.value);
        }
    }

    public closeDialog() {
        this.dialogRef.close();
    }
}
