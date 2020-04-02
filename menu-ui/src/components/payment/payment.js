import './payment.css';

import React from 'react';
import { Link, Redirect } from 'react-router-dom';
import Prompt from '../prompt/prompt';
import paymentTypes from '../../Extensions/paymenTypes';
import PaymentService from '../../Service/paymentService';
import orderStates from '../../Extensions/orderStates';

export default class Payment extends React.Component {
    constructor(props) {
        super(props);

        this.paymentService = new PaymentService();
        this.showPrompt = this.showPrompt.bind(this);
        this.confirmPayment = this.confirmPayment.bind(this);
        this.choseOnlinePayment = this.choseOnlinePayment.bind(this);
        this.expandOnlineOption = this.expandOnlineOption.bind(this);
        this.hidePopup = this.hidePopup.bind(this);
        this.state = {
            showPrompt: false,
            onlineOptionExpand: false,
            chosenPaymentType: null,
            redirect: false,
            message: ""
        };
    }

    hidePopup() {
        this.setState({
            showPrompt: false,
            onlineOptionExpand: false
        });
    }

    showPrompt(paymentType) {
        this.setState({
            showPrompt: true,
            onlineOptionExpand: false,
            chosenPaymentType: paymentType
        });
    }

    expandOnlineOption() {
        this.setState({
            onlineOptionExpand: !this.state.onlineOptionExpand
        });
    }

    choseOnlinePayment() {
        this.setState({
            chosenPaymentType: paymentTypes.MOBILE
        }, () => {
            this.confirmPayment();
        });
    }

    confirmPayment() {
        let text = "";
        switch (this.state.chosenPaymentType) {
            case paymentTypes.CARD:
                text = "You can make your payment at cash desk";
                this.paymentService.payCard(this.props.basket);
                break;
            case paymentTypes.MOBILE:
                text = "Your payment received, thank you for coming";
                this.paymentService.payOnline(this.props.basket);
                break;
            case paymentTypes.CASH:
                text = "You can make your payment at cash desk";
                this.paymentService.payCash(this.props.basket);
                break;
        }

        this.setState({
            message: text
        }, () => {
            this.setState({
                redirect: true
            });
        });
    }

    isOrderDelivered() {
        return (this.props.basket || {}).orderStatus == orderStates.DELIVERED;
    }

    render() {
        return true ? (
            <div className="payment-options">
                <div className="payment-title">Choose Payment Method</div>
                <a className="payment-link" onClick={() => this.showPrompt(paymentTypes.CASH)}>Cash</a>
                <a className="payment-link" onClick={() => this.showPrompt(paymentTypes.CARD)}>Credit Card</a>
                <a className="payment-link" href="#online-payment" onClick={this.expandOnlineOption}>Online</a>
                <div id="online-payment" className="collapse" style={{ display: this.state.onlineOptionExpand ? "block" : "none" }}>
                    <div className="card card-body">
                        <div className="info">
                            <h1>Pay Online</h1>
                        </div>
                        <div className="form">
                            <div className="thumbnail"><img src="https://i.hizliresim.com/dhXrZ9.png" /></div>
                            <form className="login-form contianer">
                                <input type="text" placeholder="Name on the Card" required />
                                <input type="number" maxLength="16" data-mask="0000 0000 0000 0000" placeholder="1234 1234 1234 1234" required />

                                <input type="date" placeholder="Expiration Date" required />
                                <input type="number" placeholder="CVC/CCV" required />
                                <button className="payment-btn" onClick={this.choseOnlinePayment}>Confirm and Pay</button>
                                <p className="message">Cash mi Ödemek istiyorsun?
                                <br />
                                    <a href="#" onClick={this.payWithCard}>Cash Öde</a></p>
                            </form>
                        </div>
                    </div>
                    {/* <article className="card">
                        <div className="card-body p-5">

                            <ul className="nav bg-light nav-pills rounded nav-fill mb-3" role="tablist">
                                <li className="nav-item">
                                    <a className="nav-link active show" href="#nav-tab-card">
                                        <i className="fa fa-credit-card"></i> Credit Card</a></li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#nav-tab-bank">
                                        <i className="fa fa-university"></i> Bank Transfer</a></li>
                            </ul>

                            <div className="tab-content">
                                <div className="tab-pane fade active show" id="nav-tab-card">
                                    <p className="alert alert-success">Some text success or error</p>
                                    <form role="form">
                                        <div className="form-group">
                                            <label for="username">Full name (on the card)</label>
                                            <input type="text" className="form-control" name="username" placeholder="" required="" />
                                        </div>

                                        <div className="form-group">
                                            <label for="cardNumber">Card number</label>
                                            <div className="input-group">
                                                <input type="text" className="form-control" name="cardNumber" placeholder="" />
                                                <div className="input-group-append">
                                                    <span className="input-group-text text-muted">
                                                        <i className="fab fa-cc-visa"></i> &nbsp; <i className="fab fa-cc-amex"></i> &nbsp;
                                    <i className="fab fa-cc-mastercard"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div className="row">
                                            <div className="col-sm-8">
                                                <div className="form-group">
                                                    <label><span className="hidden-xs">Expiration</span> </label>
                                                    <div className="input-group">
                                                        <input type="number" className="form-control" placeholder="MM" name="" />
                                                        <input type="number" className="form-control" placeholder="YY" name="" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div className="col-sm-4">
                                                <div className="form-group">
                                                    <label data-toggle="tooltip" title=""
                                                        data-original-title="3 digits code on back side of the card">CVV <i
                                                            className="fa fa-question-circle"></i></label>
                                                    <input type="number" className="form-control" required="" />
                                                </div>
                                            </div>
                                        </div>
                                        <button className="subscribe btn btn-primary btn-block" type="button"> Confirm </button>
                                    </form>
                                </div>
                                <div className="tab-pane fade" id="nav-tab-bank">
                                    <p>Bank accaunt details</p>
                                    <dl className="param">
                                        <dt>BANK: </dt>
                                        <dd> THE WORLD BANK</dd>
                                    </dl>
                                    <dl className="param">
                                        <dt>Accaunt number: </dt>
                                        <dd> 12345678912345</dd>
                                    </dl>
                                    <dl className="param">
                                        <dt>IBAN: </dt>
                                        <dd> 123456789</dd>
                                    </dl>
                                    <p><strong>Note:</strong> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                    tempor incididunt ut labore et dolore magna aliqua. </p>
                                </div>
                            </div>

                        </div>
                    </article> */}
                </div>
                {this.state.showPrompt ? <Prompt show={true} hide={this.hidePopup} confirm={this.confirmPayment} /> : ""}
                {this.state.redirect ? <Redirect to={{
                    pathname: "/success",
                    state: {
                        message: this.state.message
                    }
                }} /> : ""}
            </div>
        ) : (<Redirect to="/" />);
    }
}