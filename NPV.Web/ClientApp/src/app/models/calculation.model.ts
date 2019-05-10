import { CashFlowModel } from "./cashflow.model";

export class CalculationModel {
    LifeOfProject: number;
    InitialCost: number;
    LowerBoundDiscountRate: number;
    UpperBoundDiscountRate: number;
    DiscountRateIncrement: number;
    CashFlows: Array<CashFlowModel>;  
}