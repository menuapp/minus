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
                        <div className="cash-side">
                            <button>
                                <Link to="success">Ask Cheque</Link>
                            </button>
                            <button>
                                <Link to="success">Pay at Desk</Link>
                            </button>
                        </div>
                    </div>
                </div>

                <a className="payment-link" onClick={this.expandOnlineOption}>Credit Card</a>
                <div class="collapse" id="collapseExample" style={{ display: this.state.onlineOptionExpand ? "block" : "none" }}>
                    <div class="card card-body">
                        <div class="info">
                            <h1>Pay by Card</h1>
                        </div>
                        <div class="form">
                            <div class="thumbnail"><img src="https://i.hizliresim.com/dhXrZ9.png" /></div>
                            <form class="login-form">
                                <input type="text" placeholder="Name on the Card" required />
                                <input type="number" maxlength="16" data-mask="0000 0000 0000 0000" placeholder="1234 1234 1234 1234" required />

                                <input type="date" placeholder="Expiration Date" required />
                                <input type="number" placeholder="CVC/CCV" required />
                                <button>Confirm and Pay</button>
                                <p class="message">Cash mi Ödemek istiyorsun?
                                <br />
                                    <a href="cashpay">Cash Öde</a></p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}