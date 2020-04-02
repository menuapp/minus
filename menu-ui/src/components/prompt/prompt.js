import './prompt.css';

import React from "react";
import { Redirect } from 'react-router-dom';
import Success from '../success/success';

export default class Prompt extends React.Component {
    constructor(props) {
        super(props);

        this.hidePopup = this.hidePopup.bind(this);
        this.confirm = this.confirm.bind(this);
        this.onAnimationEnd = this.onAnimationEnd.bind(this);
        this.setToClose = this.setToClose.bind(this);
        this.setToConfirm = this.setToConfirm.bind(this);
        this.state = { close: false, confirm: false, animation: "slideDown" };
    }

    setToClose() {
        this.setState({
            close: true,
            animation: "slideUp"
        });
    }

    hidePopup() {
        this.props.hide();
    }

    confirm() {
        this.props.confirm();
    }

    setToConfirm() {
        this.setState({
            confirm: true,
            close: true,
            animation: "slideUp"
        })
    }

    onAnimationEnd() {
        if (this.state.confirm && this.state.close) {
            return this.confirm();
        } else if (this.state.close) {
            return this.hidePopup();
        }
    }

    render() {
        return (
            <div className="modal" id="exampleModal" >
                <div className="modal-dialog" role="document" style={{
                    animationName: this.state.animation
                }} onAnimationEnd={this.onAnimationEnd}>
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Payment Confirmation</h5>
                            <button type="button" onClick={this.setToClose} className="close">
                                <span>&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            Your cheque will be delivered to your table, do you want to confirm?
          </div>
                        <div className="modal-footer">
                            <button type="button" onClick={this.setToClose} className="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" onClick={this.confirm} className="btn btn-primary">Confirm</button>
                        </div>
                    </div>
                </div>
            </div >
        );
    }
};