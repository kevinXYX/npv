import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CalculationModel } from '..//models/calculation.model';
import { CashFlowModel } from "..//models/cashflow.model";
import { NgForm } from '@angular/forms';
import { CalculationService } from '../services/calculation.service';
import { PreviousResultsService } from '../services/previous-results.service';
import { debug } from 'util';

@Component({
  selector: 'app-calculate',
  templateUrl: './calculate.component.html',
  styleUrls: ['./calculate.component.css'],
  providers: [CalculationService, PreviousResultsService]
})
export class CalculateComponent implements OnInit {

  cashFlowMinValue : number  = 1;
  cashFlowMaxValue : number  = 50; //added a max cashflow restriction here so that user won't accidentally add like 1000 or 10000 cashflows that would cause UI to hang
  calculationModel = new CalculationModel();
  netPresentValue : number = null;
  presentValueOfCashFlows : number = null;

  @ViewChild('npvForm') npvForm: NgForm;

  constructor(private calculationService: CalculationService, private previousResultsService: PreviousResultsService) { 
  }

  ngOnInit() {

    this.calculationModel.CashFlows = [];
    this.calculationModel.LifeOfProject = 10;

    this.initializeCashFlow();
  }

  addCashFlows() {
    this.calculationModel.CashFlows = [];

    if (this.calculationModel.LifeOfProject >= this.cashFlowMinValue && this.calculationModel.LifeOfProject <= this.cashFlowMaxValue) {
      for (var index = 1; index < this.calculationModel.LifeOfProject + 1; index++) {

        var cashFlow = new CashFlowModel();
      
        cashFlow.Year = index;
        cashFlow.Value = 0;

        this.calculationModel.CashFlows.push(cashFlow)
      }
    }
  }

  addSingleCashFlow() {
    if (this.calculationModel.LifeOfProject <= this.cashFlowMaxValue) { 
      var cashFlow = new CashFlowModel();
      var cashFlowRecords = this.calculationModel.CashFlows;
      var lastCashFlowRecord = cashFlowRecords[cashFlowRecords.length - 1];
  
      cashFlow.Year = lastCashFlowRecord.Year + 1;
      cashFlow.Value = 0;
  
      this.calculationModel.CashFlows.push(cashFlow)
      this.calculationModel.LifeOfProject = this.calculationModel.CashFlows.length;
    }
  }

  removeCashFlow(cashFlow : CashFlowModel) {
    if (this.calculationModel.LifeOfProject > this.cashFlowMinValue) {
      this.calculationModel.CashFlows = this.calculationModel.CashFlows.filter(x => x.Year != cashFlow.Year);
      this.calculationModel.LifeOfProject = this.calculationModel.CashFlows.length;
    }
  }

  initializeCashFlow() {
    for (var index = 1; index < this.calculationModel.LifeOfProject + 1; index++) {
      var cashFlow = new CashFlowModel();

      cashFlow.Year = index;
      cashFlow.Value = 0;

      this.calculationModel.CashFlows.push(cashFlow)
    }
  }

  calculate() {
    if (this.npvForm.valid) {
      this.calculationService.getCalculationResult(this.calculationModel).subscribe(response => {
        this.netPresentValue = response.NetPresentValue;
        this.presentValueOfCashFlows = response.PresentValueOfCashFlows;
      })
    }
  }

  saveCalculation() {
    if (this.npvForm.valid) { 
      this.previousResultsService.saveResults(this.calculationModel).subscribe(response => {
        if (response.Success) {
          this.resetFields();
        }
      });
    }
  }
  
  resetFields() {
    this.npvForm.resetForm();
    this.calculationModel = new CalculationModel();
    this.calculationModel.CashFlows = [];
    this.calculationModel.LifeOfProject = 10;
    this.netPresentValue = null;
    this.presentValueOfCashFlows = null;

    this.initializeCashFlow();
  }

  validateCashFlow(cashFlow) {
    return cashFlow.Value != null && cashFlow.Value > 0;
  }
 }
