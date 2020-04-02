import ServiceBase from "./serviceBase";
import PaymentRepository from "../DAL/paymentRepository";
import paymentTypes from "../Extensions/paymenTypes";
import orderStates from "../Extensions/orderStates";
import AuthenticationRepository from "../DAL/authenticationRepository";

export default class PaymentService extends ServiceBase {
    constructor() {
        super();

        this.paymentRepository = new PaymentRepository();
        this.authenticationRepository = new AuthenticationRepository();
    }

    async payCard(order) {
        order.paymentType = paymentTypes.CARD;
        order.orderStatus = orderStates.DELIVERED;
        await this.paymentRepository.choosePaymentMethod(order);
        await this.authenticationRepository.checkout();
    }

    async payOnline(order) {
        order.orderStatus = orderStates.DELIVERED;
        order.paymentType = paymentTypes.MOBILE;
        await this.paymentRepository.choosePaymentMethod(order);
        await this.paymentRepository.payOnline(order);
        await this.authenticationRepository.checkout();
    }

    async payCash(order) {
        order.orderStatus = orderStates.DELIVERED;
        order.paymentType = paymentTypes.CASH;
        await this.paymentRepository.choosePaymentMethod(order);
        await this.authenticationRepository.checkout();
    }
}