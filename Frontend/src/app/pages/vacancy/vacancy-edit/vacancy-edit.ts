import { Component, inject } from '@angular/core';
import { MaterialModule } from '../../../modules/material-module';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';

@Component({
    selector: 'app-vacancy-edit',
    imports: [CommonModule, MaterialModule, ReactiveFormsModule],
    templateUrl: './vacancy-edit.html',
    styleUrl: './vacancy-edit.scss'
})
export class VacancyEdit {
    form: FormGroup;
    dialogRef = inject(DialogRef<VacancyEdit>);
    data = inject(DIALOG_DATA);

    constructor(private fb: FormBuilder) {
        this.form = this.fb.group({
            title: ['', Validators.required],
            content: [''],
            companyId: ['', Validators.required]
        });

        this.form.patchValue(this.data.vacancy);
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
