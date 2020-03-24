import React from "react";

import "./sliderItem.css";

export default class SliderItem extends React.Component {
    constructor(props) {
        super(props);
        this.showDetails = this.showDetails.bind(this);
    }

    showDetails(event) {
        console.log(event.target);
        // this.setState
    }

    render() {
        return (
            <div className="slider-item">
                <img className="body" onClick={this.showDetails} src={"http://" + this.props.item.contents[0].relativePath} width="100%" height="80%" />
                <div className="name">{this.props.item.name}</div>
                <div className="price">{this.props.item.unitPrice + " TL"}</div>
            </div>
        );
    }
}