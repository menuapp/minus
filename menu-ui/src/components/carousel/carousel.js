import React from "react";
import "./carousel.css";
export default class Carousel extends React.Component {
    constructor(props) {
        super(props);
    }

    touchMove() {
        console.log("a");
    }

    render() {
        return <div id="carousel" onTouchMove={this.touchMove} style={{ backgroundColor: this.props.color }}></div>;
    }
}