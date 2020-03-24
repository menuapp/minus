import './basket.css';

import React from 'react';
import BottomNavBar from '../bottomNavBar/bottomNavBar';
import { Link } from 'react-router-dom';

export default class Basket extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.basket) {
            let prices = this.props.basket.orderProducts.map(orderProduct => orderProduct.product.unitPrice * orderProduct.quantity);
            let sum = prices.length > 0 && prices.reduce(((sum, price) => sum += price));
            var totalPrice = sum;
        }

        return (
            <div>
                <table className="order-list">
                    <tbody>
                        {this.props.basket ? (this.props.basket.orderProducts.map(orderProduct => {
                            return (<tr>
                                <td>{orderProduct.product.name}</td>
                                <td>{orderProduct.quantity}</td>
                                <td>{(orderProduct.quantity * orderProduct.product.unitPrice) + " TL"}</td>
                            </tr>)
                        })) : ""}
                    </tbody>
                </table>{
                    totalPrice > 0 ?
                        <BottomNavBar>
                            <div className="col-3">{totalPrice + " TL"}</div>
                            <Link to="/confirmation" className="pay-btn col-3 h-100 offset-6">
                                Confirm
                            </Link>
                        </BottomNavBar> : ""
                }
            </div>
        );
    }
}