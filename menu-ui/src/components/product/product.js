import React from "react";

export default class Product extends React.Component {
    touchMove(){
        console.log("move it");
    }

    render() {
        return <h1 onTouchMove={this.touchMove}>Hello</h1>;
    }
}