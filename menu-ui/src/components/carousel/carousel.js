import React from "react";
import "./carousel.css";
import Draggable from "react-draggable";

export default class Carousel extends React.Component {
    constructor(props) {
        super(props);
        this.state = { pagePosition: 0, startPosition: null };
        this.onDragStart = this.onDragStart.bind(this);
        this.onDragEnd = this.onDragEnd.bind(this);
    }

    onDragStart() {
        window.a = this.props.children;
        console.log("dragStart");
        // this.setState(() => {
        //     return {
        //         startPosition: 
        //     }
        // });
    }

    onDragEnd(e) {
        window.b = e;
        this.setState(() => {
            return {
                pagePosition: -100
            }
        });
    }

    render() {
        return <Draggable axis="x" onStart={this.onDragStart} onStop={this.onDragEnd}><div id="carousel" style={{ backgroundColor: this.props.color, marginLeft: this.state.pagePosition + "%" }}>{this.props.children}</div>
        </Draggable>;
    }
}