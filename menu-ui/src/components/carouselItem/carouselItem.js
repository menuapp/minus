import React from "react";
import "./carouselItem.css";

export default class CarouselItem extends React.Component {
    constructor(props) {
        super(props);
        this.self = React.createRef();
    }

    render() {
        console.log(this.self)
        return <div id="carousel-item"  style={{ backgroundColor: this.props.color }}></div>;
    }
}