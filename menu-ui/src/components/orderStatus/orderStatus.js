import './orderStatus.css';

import React from 'react';
import orderStates from '../../Extensions/orderStates';
import { Link } from 'react-router-dom';

export default function OrderStatus(props) {
    let states = orderStates;
    let element;

    switch (props.orderState) {
        case states.PREPARING:
            element = <div className="message bg-warning"><span>Preparing...</span></div>;
            break;
        case states.DELIVERED:
            element = <div className="message bg-success"><span>Delivered.</span><Link className="bg-warning" to="/payment">Payment</Link></div>;
            break;
    }

    return (
        <div className="order-state">
            {element}
        </div>
    );
}