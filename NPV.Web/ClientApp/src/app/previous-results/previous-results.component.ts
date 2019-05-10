import { Component, OnInit } from '@angular/core';
import { PreviousResultsService } from '..//services/previous-results.service';
import { PreviousResultsModel } from '..//models/previous-results.model';

@Component({
  selector: 'app-previous-results',
  templateUrl: './previous-results.component.html',
  styleUrls: ['./previous-results.component.css'],
  providers: [PreviousResultsService]
})
export class PreviousResultsComponent implements OnInit {

  previousResults = new Array<PreviousResultsModel>();

  constructor(private previousResultsService: PreviousResultsService) { }

  ngOnInit() {
    this.previousResultsService.getPreviousResults().subscribe(previousResults => {
      this.previousResults = previousResults;
    })
  }
}
