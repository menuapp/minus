import RepositoryBase from './repositoryBase';
import paymentTypes from '../Extensions/paymenTypes';

export default class OrderRepository extends RepositoryBase {
  constructor() {
    super();

    this.endPoint += '/basket';
  }

  async createBasket() {
    let response = await fetch(this.endPoint + '/add', {
      method: 'POST',
      headers: new Headers({
        Accept: 'application/json',
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + localStorage.getItem('token')
      }),
      body: JSON.stringify({
        orderStatus: 1,
        orderType: 1,
        paymentType: 1
      })
    });

    if (response.status === 200) {
      return true;
    }

    return false;
  }

  async addToBasket(productId, quantity) {
    let response = await fetch(this.endPoint + '/addproduct', {
      method: 'POST',
      headers: new Headers({
        Accept: 'application/json',
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + localStorage.getItem('token')
      }),
      body: JSON.stringify({
        productId,
        quantity
      })
    });

    if (response.status === 200) {
      return true;
    }

    return false;
  }

  async getBasket() {
    let response = await fetch(this.endPoint + '/getbasket', {
      method: 'POST',
      headers: new Headers({
        Accept: 'application/json',
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    });
    let basket;

    if (response.status === 200) {
      basket = await response.json();

      return basket;
    }

    return null;
  }

  async confirmOrder(order) {
    let response = await fetch(this.endPoint + '/confirm', {
      method: 'POST',
      headers: new Headers({
        Accept: 'application/json',
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + localStorage.getItem('token')
      }),
      body: JSON.stringify(order)
    });

    if (response.status === 200) {
      return true;
    } else {
      return false;
    }
  }

  async updateProduct() {}

  async removeProduct() {}
}