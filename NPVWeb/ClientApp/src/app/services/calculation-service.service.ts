import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CalculationModel } from '../models/calculation.model';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CalculationServiceService {

  baseUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getCalculationResult(calculationModel: CalculationModel) : Observable<object> {

    let params = new HttpParams()
    let headers = new HttpHeaders();

    headers.append('Content-Type', 'application/json');
    params.set("calculationModel", JSON.stringify(calculationModel));

    return this.httpClient.get<CalculationModel>(this.baseUrl + "Calculation/CalculateNPV", { headers: headers, params: params });
  }
}
