import React from 'react';

import "./itemBox.css";

export default class ItemBox extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div className="itemBox mb-4">
                <img src={"http://" + this.props.card.contents[0].relativePath.replace("localhost", "192.168.1.174")} width="100%" height="55%" />
                <div className="container name">{this.props.card.name}</div>
                <div className="details container">
                    <div className="row detailsWrapper align-items-center">
                        <div className="duration col-3 text-center">45 mins</div>
                        <div className="ingredients col-5 text-center">4 ingredients</div>
                        <button className="button col-3 text-center rounded-sm">+  Order</button>
                    </div>

                </div>
            </div>
        );
    }
}