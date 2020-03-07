import React from 'react';

import "./itemBox.css";
import { Link } from 'react-router-dom';

export default class ItemBox extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div className="itemBox mb-4"><Link to={'/itemDetails/' + this.props.card.id}>
                <img alt="" src={"http://" + this.props.card.contents[0].relativePath.replace("localhost", "192.168.1.174")} width="100%" height="55%" />
            </Link>
                <div className="container name">{this.props.card.name}</div>
                <div className="container details">
                    <div className="d-flex flex-row detailsWrapper align-items-center">
                        <div className="duration text-left">45 mins</div>
                        <div className="ingredients  text-left">4 ingredients</div>
                        <button className="button text-center ml-auto rounded-sm">+  Order</button>
                    </div>

                </div>
            </div>

        );
    }
}