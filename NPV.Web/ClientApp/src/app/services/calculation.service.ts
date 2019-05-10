import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CalculationModel } from '..//models/calculation.model';
import { CalculationResponse } from '..//models/calculation-response.model';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CalculationService {

  private baseUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getCalculationResult(calculationModel: CalculationModel) : Observable<CalculationResponse> {
    return this.httpClient.post<CalculationResponse>(this.baseUrl + "calculation/calculate-npv", calculationModel);
  }
}
