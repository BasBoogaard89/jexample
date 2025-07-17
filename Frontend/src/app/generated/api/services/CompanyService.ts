/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CompanyDto } from '../models/CompanyDto';
import type { CompanyFilterDto } from '../models/CompanyFilterDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import type { BaseHttpRequest } from '../core/BaseHttpRequest';
export class CompanyService {
    constructor(public readonly httpRequest: BaseHttpRequest) {}
    /**
     * @param requestBody
     * @returns CompanyDto OK
     * @throws ApiError
     */
    public postCompanyGetAllFiltered(
        requestBody: CompanyFilterDto,
    ): CancelablePromise<Array<CompanyDto>> {
        return this.httpRequest.request({
            method: 'POST',
            url: '/Company/GetAllFiltered',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @returns any OK
     * @throws ApiError
     */
    public getCompany(): CancelablePromise<any> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/Company',
        });
    }
    /**
     * @param requestBody
     * @returns any OK
     * @throws ApiError
     */
    public postCompany(
        requestBody: CompanyDto,
    ): CancelablePromise<any> {
        return this.httpRequest.request({
            method: 'POST',
            url: '/Company',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param id
     * @returns any OK
     * @throws ApiError
     */
    public getCompany1(
        id: number,
    ): CancelablePromise<any> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/Company/{id}',
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
    public deleteCompany(
        id: number,
    ): CancelablePromise<boolean> {
        return this.httpRequest.request({
            method: 'DELETE',
            url: '/Company/{id}',
            path: {
                'id': id,
            },
        });
    }
}
