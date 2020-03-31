import './payment.css';

import React from 'react';
import { Link } from 'react-router-dom';

export default class Payment extends React.Component {
    constructor(props) {
        super(props);

        this.expandCashOption = this.expandCashOption.bind(this);
        this.expandOnlineOption = this.expandOnlineOption.bind(this);
        this.state = {
            cashOptionExpand: false,
            onlineOptionExpand: false,
        };
    }

    expandCashOption() {
        console.log("asd");
        this.setState({
            cashOptionExpand: !this.state.cashOptionExpand
        });
    }

    expandOnlineOption() {
        console.log("asd");
        this.setState({
            onlineOptionExpand: !this.state.onlineOptionExpand
        });
    }

    render() {
        return (

            <div className="payment-options">
                <div className="payment-title">Choose Payment Method</div>
                <a className="payment-link" onClick={this.expandCashOption}>Cash</a>
                <div class="collapse" id="collapseExample" style={{ display: this.state.cashOptionExpand ? "block" : "none" }}>
                    <div class="card card-body">
                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid.
                        Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                        <div style={{ textAlign: "center" }}>
                            <Link to="success">Ask Cheque</Link>
                            <Link to="success">Pay at Desk</Link>
                        </div>
                    </div>
                </div>

                <a className="payment-link" onClick={this.expandOnlineOption}>Credit Card</a>
                <div class="collapse" id="collapseExample" style={{ display: this.state.onlineOptionExpand ? "block" : "none" }}>
                    <div class="card card-body">
                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid.
                        Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                    </div>
                </div>
            </div>
        );
    }
}