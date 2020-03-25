import { RechargeModel } from './recharge.model';
import { ElectricityRechargeModel } from './electricity-recharge.model';

export class PaymentModel {
    PaymentModeId: string;
    Module: PaymentModule;
    Amount: string;
    MobileRecharge: RechargeModel;
    ElectricityRecharge: ElectricityRechargeModel;
}

export enum PaymentModule {
    Electricity = 1,
    MobileRecharge
}