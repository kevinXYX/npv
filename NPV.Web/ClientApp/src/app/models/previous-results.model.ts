import { CashFlowModel } from "./cashflow.model";

export class PreviousResultsModel {
    LifeOfProject: number;
    InitialCost: number;
    LowerBoundDiscountRate: number;
    UpperBoundDiscountRate: number;
    DiscountRateIncrement: number;
    CashFlows: Array<CashFlowModel>;  
    NetPresentValue: number;
    PresentValueOfCashFlows: number;
    CreatedDate: Date;
}