import './confirmation.css';

import React from 'react';
import { Link } from 'react-router-dom';

export default function Confirm(props) {
    return (
        <div className="order-confirmation">
            <div>Do you confirm following order?</div>
            {<table className="order-list">
                    <tbody>
                        {props.basket ? (props.basket.orderProducts.map(orderProduct => {
                            return (<tr>
                                <td>{orderProduct.product.name}</td>
                                <td>{orderProduct.quantity}</td>
                                <td>{(orderProduct.quantity * orderProduct.product.unitPrice) + " TL"}</td>
                            </tr>)
                        })) : ""}
                        <tr className="total-amount">
                           <td><b>Total</b></td>
                           <td></td>
                           <td><b>45 TL</b></td>
                        </tr>
                    </tbody>
                </table>}
            <div className="confirm-buttons">
                <Link className="text-success" to="/">Yes</Link>
                <Link className="text-danger" to="/basket">No</Link>
            </div>
        </div>
    );
}