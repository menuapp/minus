import './basket.css';

import React from 'react';
import BottomNavBar from '../bottomNavBar/bottomNavBar';
import { Link, Redirect } from 'react-router-dom';
import AuthenticationService from '../../Service/authenticationService';

export default class Basket extends React.Component {
    constructor(props) {
        super(props);

        this.authenticationService = new AuthenticationService();
    }

    render() {
        if (this.props.basket) {
            let prices = this.props.basket.orderProducts.map(orderProduct => orderProduct.product.unitPrice * orderProduct.quantity);
            let sum = prices.length > 0 && prices.reduce(((sum, price) => sum += price));
            var totalPrice = sum;
        }

        return this.authenticationService.isAuthenticated() ? (
            <div id="order-list-wrapper">
                <table className="order-list">
                    <tbody>
                        {this.props.basket ? (this.props.basket.orderProducts.map(orderProduct => {
                            return (<tr>
                                <td>{orderProduct.product.name}</td>
                                <div className="qContainer">
                                    <button href="#" className="qEksi"><span>-</span></button>
                                    {/* <td>{orderProduct.quantity}</td> */}
                                    <input type="text" className="qValue" value={orderProduct.quantity} />
                                    <button className="qArti"><span>+</span></button>
                                </div>
                                <td>{(orderProduct.quantity * orderProduct.product.unitPrice).toFixed(2) + " ₺"}</td>
                            </tr>)
                        })) : ""}
                        <tr className="total-amount">
                            <td>
                                <b>Previous</b>
                            </td>
                            <td></td>
                            <td>
                                <b>45 TL</b>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table className="order-list">
                    <tbody>
                        {this.props.basket ? (this.props.basket.orderProducts.map(orderProduct => {
                            return (<tr>
                                <td>{orderProduct.product.name}</td>
                                <div className="qContainer">
                                    <button href="#" className="qEksi"><span>-</span></button>
                                    {/* <td>{orderProduct.quantity}</td> */}
                                    <input type="text" className="qValue" value={orderProduct.quantity} />
                                    <button className="qArti"><span>+</span></button>
                                </div>
                                <td>{(orderProduct.quantity * orderProduct.product.unitPrice).toFixed(2) + " ₺"}</td>
                            </tr>)
                        })) : ""}
                        <tr className="total-amount">
                            <td>
                                <b>In Basket</b>
                            </td>
                            <td></td>
                            <td>
                                <b>45 TL</b>
                            </td>
                        </tr>
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
                </table>{
                    totalPrice > 0 ?
                        <BottomNavBar>
                            <div className="col-3">{totalPrice + " ₺"}</div>
                            <Link to="/confirmation" className="pay-btn col-3 h-100 offset-6">
                                Confirm
                            </Link>
                        </BottomNavBar> : ""
                }
            </div>
        ) : (<Redirect to="/" />);
    }
}