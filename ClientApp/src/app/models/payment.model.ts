import { RechargeModel } from './recharge.model';

export class PaymentModel {
    PaymentModeId: string;
    Module: PaymentModule;
    Amount: string;
    MobileRecharge: RechargeModel;
    constructor() {
        this.MobileRecharge = new RechargeModel();
    }
}

export enum PaymentModule {
    Electricity = 1,
    MobileRecharge
}