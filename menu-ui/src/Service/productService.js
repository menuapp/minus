import ServiceBase from './serviceBase';
import ProductRepository from '../DAL/productRepository';

export default class ProductService extends ServiceBase {
  constructor() {
    super();
    this.productRepository = new ProductRepository();
  }

  async getAll(restaurantName) {
    return await this.productRepository.getAll(restaurantName);
  }
}
