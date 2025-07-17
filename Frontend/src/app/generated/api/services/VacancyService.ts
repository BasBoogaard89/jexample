/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { VacancyDto } from '../models/VacancyDto';
import type { VacancyDto2 } from '../models/VacancyDto2';
import type { VacancyFilterDto } from '../models/VacancyFilterDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import type { BaseHttpRequest } from '../core/BaseHttpRequest';
export class VacancyService {
    constructor(public readonly httpRequest: BaseHttpRequest) {}
    /**
     * @param requestBody
     * @returns VacancyDto OK
     * @throws ApiError
     */
    public postVacancyGetAllFiltered(
        requestBody: VacancyFilterDto,
    ): CancelablePromise<Array<VacancyDto>> {
        return this.httpRequest.request({
            method: 'POST',
            url: '/Vacancy/GetAllFiltered',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @returns any OK
     * @throws ApiError
     */
    public getVacancy(): CancelablePromise<any> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/Vacancy',
        });
    }
    /**
     * @param requestBody
     * @returns any OK
     * @throws ApiError
     */
    public postVacancy(
        requestBody: VacancyDto2,
    ): CancelablePromise<any> {
        return this.httpRequest.request({
            method: 'POST',
            url: '/Vacancy',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param id
     * @returns any OK
     * @throws ApiError
     */
    public getVacancy1(
        id: number,
    ): CancelablePromise<any> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/Vacancy/{id}',
            path: {
                'id': id,
            },
        });
    }
    /**
     * @param id
     * @returns boolean OK
     * @throws ApiError
     */
    public deleteVacancy(
        id: number,
    ): CancelablePromise<boolean> {
        return this.httpRequest.request({
            method: 'DELETE',
            url: '/Vacancy/{id}',
            path: {
                'id': id,
            },
        });
    }
}
