import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculate',
  templateUrl: './calculate.component.html',
  styleUrls: ['./calculate.component.css']
})
export class CalculateComponent implements OnInit {

  cashFlowMinValue : number  = 1;
  cashFlowMaxValue : number  = 50;
  lifeOfProjectValue : number = 10;
  cashFlows : Array<object> = [];

  constructor() { }

  ngOnInit() {
    this.initializeCashFlow();
  }

  addCashFlow() {
    this.cashFlows = [];

    if (this.lifeOfProjectValue >= this.cashFlowMinValue && this.lifeOfProjectValue <= this.cashFlowMaxValue) {
      for (var index = 1; index < this.lifeOfProjectValue + 1; index++) {
        this.cashFlows.push({id: index, value: 0})
      }
    }
  }

  initializeCashFlow() {
    for (var index = 1; index < this.lifeOfProjectValue + 1; index++) {
      this.cashFlows.push({id: index, value: 0})
    }
  }
 }
