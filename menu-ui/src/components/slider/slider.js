import React from "react";
import ProductService from "../../Service/productService";

import "./slider.css";
import SliderItem from "../sliderItem/sliderItem";

export default class Slider extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="slider">
                <div className="slider-header">{this.props.sliderData.name}</div>
                <hr />
                <div className="slider-body">
                    {this.props.sliderData.products.map((item) => {
                        return <SliderItem item={item} />
                    })}
                </div>
            </div>
        );
    }
}