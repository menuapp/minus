import './payment.css';

import React from 'react';

export default class Payment extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            
            <div className="payment-options">
                <div className="payment-title">Choose Payment Method</div>
                <a className="payment-link">Cash</a>
                <div class="collapse" id="collapseExample">
                    <div class="card card-body">
                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid.
                        Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                    </div>
                </div>

                <a className="payment-link">Credit Card</a>
                <div class="collapse" id="collapseExample">
                    <div class="card card-body">
                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid.
                        Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                    </div>
                </div>
            </div>
        );
    }
}