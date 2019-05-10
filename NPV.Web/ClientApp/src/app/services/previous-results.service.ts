import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { PreviousResultsModel } from '..//models/previous-results.model';
import { CalculationModel } from '..//models/calculation.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PreviousResultsService {

  private baseUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getPreviousResults() : Observable<Array<PreviousResultsModel>> {
    return this.httpClient.get<Array<PreviousResultsModel>>(this.baseUrl + "previous-results");
  }

  saveResults(calculationModel : CalculationModel) : Observable<any> {
    return this.httpClient.post<any>(this.baseUrl + "previous-results/save", calculationModel);
  }
}
