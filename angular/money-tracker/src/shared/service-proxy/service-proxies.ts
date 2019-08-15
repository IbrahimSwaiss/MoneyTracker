﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.0.4.0 (NJsonSchema v10.0.21.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

import * as moment from 'moment';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable()
export class MoneyServiceProxy {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    addBudget(name: string | null | undefined, monthlyBudget: number | undefined, weeklyBudget: number | undefined, monthlySavingAmount: number | undefined, monthlySavingPercentage: number | undefined, transactions: TransactionInput[] | null | undefined): Observable<void> {
        let url_ = this.baseUrl + "/api/money/add-budget?";
        if (name !== undefined)
            url_ += "Name=" + encodeURIComponent("" + name) + "&"; 
        if (monthlyBudget === null)
            throw new Error("The parameter 'monthlyBudget' cannot be null.");
        else if (monthlyBudget !== undefined)
            url_ += "MonthlyBudget=" + encodeURIComponent("" + monthlyBudget) + "&"; 
        if (weeklyBudget === null)
            throw new Error("The parameter 'weeklyBudget' cannot be null.");
        else if (weeklyBudget !== undefined)
            url_ += "WeeklyBudget=" + encodeURIComponent("" + weeklyBudget) + "&"; 
        if (monthlySavingAmount === null)
            throw new Error("The parameter 'monthlySavingAmount' cannot be null.");
        else if (monthlySavingAmount !== undefined)
            url_ += "MonthlySavingAmount=" + encodeURIComponent("" + monthlySavingAmount) + "&"; 
        if (monthlySavingPercentage === null)
            throw new Error("The parameter 'monthlySavingPercentage' cannot be null.");
        else if (monthlySavingPercentage !== undefined)
            url_ += "MonthlySavingPercentage=" + encodeURIComponent("" + monthlySavingPercentage) + "&"; 
        if (transactions !== undefined)
            transactions && transactions.forEach((item, index) => { 
                for (let attr in item)
        			if (item.hasOwnProperty(attr)) {
        				url_ += "Transactions[" + index + "]." + attr + "=" + encodeURIComponent("" + (<any>item)[attr]) + "&";
        			}
            });
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processAddBudget(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processAddBudget(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else
                return <Observable<void>><any>_observableThrow(response_);
        }));
    }

    protected processAddBudget(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return _observableOf<void>(<any>null);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<void>(<any>null);
    }

    getBudget(id: number | undefined): Observable<Budget | null> {
        let url_ = this.baseUrl + "/api/money/get-budget?";
        if (id === null)
            throw new Error("The parameter 'id' cannot be null.");
        else if (id !== undefined)
            url_ += "id=" + encodeURIComponent("" + id) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetBudget(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetBudget(<any>response_);
                } catch (e) {
                    return <Observable<Budget | null>><any>_observableThrow(e);
                }
            } else
                return <Observable<Budget | null>><any>_observableThrow(response_);
        }));
    }

    protected processGetBudget(response: HttpResponseBase): Observable<Budget | null> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? Budget.fromJS(resultData200) : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<Budget | null>(<any>null);
    }
}

export class TransactionInput implements ITransactionInput {
    name!: string | undefined;
    repeat!: number;
    amount!: number;

    constructor(data?: ITransactionInput) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.name = data["name"];
            this.repeat = data["repeat"];
            this.amount = data["amount"];
        }
    }

    static fromJS(data: any): TransactionInput {
        data = typeof data === 'object' ? data : {};
        let result = new TransactionInput();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["repeat"] = this.repeat;
        data["amount"] = this.amount;
        return data; 
    }
}

export interface ITransactionInput {
    name: string | undefined;
    repeat: number;
    amount: number;
}

export class EntityOfInteger implements IEntityOfInteger {
    id!: number;

    constructor(data?: IEntityOfInteger) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
        }
    }

    static fromJS(data: any): EntityOfInteger {
        data = typeof data === 'object' ? data : {};
        let result = new EntityOfInteger();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        return data; 
    }
}

export interface IEntityOfInteger {
    id: number;
}

export class AuditedEntityOfInteger extends EntityOfInteger implements IAuditedEntityOfInteger {
    createdBy!: number;
    createdOn!: moment.Moment;
    modifiedBy!: number | undefined;
    modifiedOn!: moment.Moment | undefined;

    constructor(data?: IAuditedEntityOfInteger) {
        super(data);
    }

    init(data?: any) {
        super.init(data);
        if (data) {
            this.createdBy = data["createdBy"];
            this.createdOn = data["createdOn"] ? moment(data["createdOn"].toString()) : <any>undefined;
            this.modifiedBy = data["modifiedBy"];
            this.modifiedOn = data["modifiedOn"] ? moment(data["modifiedOn"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): AuditedEntityOfInteger {
        data = typeof data === 'object' ? data : {};
        let result = new AuditedEntityOfInteger();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["createdBy"] = this.createdBy;
        data["createdOn"] = this.createdOn ? this.createdOn.toISOString() : <any>undefined;
        data["modifiedBy"] = this.modifiedBy;
        data["modifiedOn"] = this.modifiedOn ? this.modifiedOn.toISOString() : <any>undefined;
        super.toJSON(data);
        return data; 
    }
}

export interface IAuditedEntityOfInteger extends IEntityOfInteger {
    createdBy: number;
    createdOn: moment.Moment;
    modifiedBy: number | undefined;
    modifiedOn: moment.Moment | undefined;
}

export class FullAuditedEntityOfInteger extends AuditedEntityOfInteger implements IFullAuditedEntityOfInteger {
    isDeleted!: boolean;
    deletedBy!: number | undefined;
    deletedOn!: moment.Moment | undefined;

    constructor(data?: IFullAuditedEntityOfInteger) {
        super(data);
    }

    init(data?: any) {
        super.init(data);
        if (data) {
            this.isDeleted = data["isDeleted"];
            this.deletedBy = data["deletedBy"];
            this.deletedOn = data["deletedOn"] ? moment(data["deletedOn"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): FullAuditedEntityOfInteger {
        data = typeof data === 'object' ? data : {};
        let result = new FullAuditedEntityOfInteger();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["isDeleted"] = this.isDeleted;
        data["deletedBy"] = this.deletedBy;
        data["deletedOn"] = this.deletedOn ? this.deletedOn.toISOString() : <any>undefined;
        super.toJSON(data);
        return data; 
    }
}

export interface IFullAuditedEntityOfInteger extends IAuditedEntityOfInteger {
    isDeleted: boolean;
    deletedBy: number | undefined;
    deletedOn: moment.Moment | undefined;
}

export class Budget extends FullAuditedEntityOfInteger implements IBudget {
    name!: string | undefined;
    monthlyBudget!: number;
    weeklyBudget!: number;
    monthlySavingAmount!: number;
    monthlySavingPercentage!: number;
    transactions!: Transaction[] | undefined;

    constructor(data?: IBudget) {
        super(data);
    }

    init(data?: any) {
        super.init(data);
        if (data) {
            this.name = data["name"];
            this.monthlyBudget = data["monthlyBudget"];
            this.weeklyBudget = data["weeklyBudget"];
            this.monthlySavingAmount = data["monthlySavingAmount"];
            this.monthlySavingPercentage = data["monthlySavingPercentage"];
            if (Array.isArray(data["transactions"])) {
                this.transactions = [] as any;
                for (let item of data["transactions"])
                    this.transactions!.push(Transaction.fromJS(item));
            }
        }
    }

    static fromJS(data: any): Budget {
        data = typeof data === 'object' ? data : {};
        let result = new Budget();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["monthlyBudget"] = this.monthlyBudget;
        data["weeklyBudget"] = this.weeklyBudget;
        data["monthlySavingAmount"] = this.monthlySavingAmount;
        data["monthlySavingPercentage"] = this.monthlySavingPercentage;
        if (Array.isArray(this.transactions)) {
            data["transactions"] = [];
            for (let item of this.transactions)
                data["transactions"].push(item.toJSON());
        }
        super.toJSON(data);
        return data; 
    }
}

export interface IBudget extends IFullAuditedEntityOfInteger {
    name: string | undefined;
    monthlyBudget: number;
    weeklyBudget: number;
    monthlySavingAmount: number;
    monthlySavingPercentage: number;
    transactions: Transaction[] | undefined;
}

export class Transaction extends FullAuditedEntityOfInteger implements ITransaction {
    name!: string | undefined;
    repeat!: number;
    amount!: number;
    budgetId!: number;

    constructor(data?: ITransaction) {
        super(data);
    }

    init(data?: any) {
        super.init(data);
        if (data) {
            this.name = data["name"];
            this.repeat = data["repeat"];
            this.amount = data["amount"];
            this.budgetId = data["budgetId"];
        }
    }

    static fromJS(data: any): Transaction {
        data = typeof data === 'object' ? data : {};
        let result = new Transaction();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["repeat"] = this.repeat;
        data["amount"] = this.amount;
        data["budgetId"] = this.budgetId;
        super.toJSON(data);
        return data; 
    }
}

export interface ITransaction extends IFullAuditedEntityOfInteger {
    name: string | undefined;
    repeat: number;
    amount: number;
    budgetId: number;
}

export class SwaggerException extends Error {
    message: string;
    status: number; 
    response: string; 
    headers: { [key: string]: any; };
    result: any; 

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if(result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader(); 
            reader.onload = event => { 
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob); 
        }
    });
}