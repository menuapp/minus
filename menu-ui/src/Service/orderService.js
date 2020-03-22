import ServiceBase from "./serviceBase";
import OrderRepository from "../DAL/orderRepository";

export default class OrderService extends ServiceBase {
    constructor() {
        super();

        this.orderRepository = new OrderRepository();
    }

    async addToBasket(productId, quantity) {
        return await this.orderRepository.addToBasket(productId, quantity);
    }

    async getBasket() {
        return await this.orderRepository.getBasket();
    }
}