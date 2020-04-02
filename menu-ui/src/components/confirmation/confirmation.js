import './confirmation.css';

import React from 'react';
import { Link, Redirect } from 'react-router-dom';
import OrderService from '../../Service/orderService';
import AuthenticationService from '../../Service/authenticationService';

export default class Confirm extends React.Component {
  constructor(props) {
    super(props);

    this.confirm = this.confirm.bind(this);
    this.orderService = new OrderService();
    this.authenticationService = new AuthenticationService();
  }

  async confirm() {
    await this.orderService.confirmBasket(this.props.basket);
    this.props.preparingOrder();
  }

  render() {
    return this.authenticationService.isAuthenticated() ? (
      <div className="order-confirmation">
        <div>Do you confirm following order?</div>
        {
          <table className="order-list">
            <tbody>
              {this.props.basket
                ? this.props.basket.orderProducts.map(orderProduct => {
                  return (
                    <tr>
                      <td>{orderProduct.product.name}</td>
                      <td>{orderProduct.quantity}</td>
                      <td>
                        {orderProduct.quantity *
                          orderProduct.product.unitPrice +
                          ' TL'}
                      </td>
                    </tr>
                  );
                })
                : ''}
              <tr className="total-amount">
                <td>
                  <b>Total</b>
                </td>
                <td></td>
                <td>
                  <b>45 TL</b>
                </td>
              </tr>
            </tbody>
          </table>
        }
        <div className="confirm-buttons">
          <Link className="text-success" to="/" onClick={this.confirm}>
            Yes
          </Link>
          <Link className="text-danger" to="/basket">
            No
          </Link>
        </div>
      </div>
    ) : (<Redirect to="/" />);
  }
}
