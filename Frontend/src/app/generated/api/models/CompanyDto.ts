/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { AddressDto } from './AddressDto';
import type { VacancyDto } from './VacancyDto';
export type CompanyDto = {
    name: string;
    address: AddressDto;
    vacancies?: Array<VacancyDto>;
    id?: number;
};

