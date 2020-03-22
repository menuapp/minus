import ServiceBase from './serviceBase';
import ProductRepository from '../DAL/productRepository';
import AuthenticationRepository from '../DAL/authenticationRepository';
import OrderRepository from '../DAL/orderRepository';

export default class ProductService extends ServiceBase {
  constructor() {
    super();
    this.productRepository = new ProductRepository();
    this.authenticationRepository = new AuthenticationRepository();
    this.orderRepository = new OrderRepository();
  }

  async getAll(restaurantName) {
    if (!localStorage.getItem("token")) {
      await this.authenticationRepository.getToken();

      await this.orderRepository.createBasket();
    }

    return await this.productRepository.getAll(restaurantName);
  }
}