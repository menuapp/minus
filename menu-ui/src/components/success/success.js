import './success.css';

import React from "react";
import { Link } from 'react-router-dom';

export default class Success extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="success-page">
                <div style={{
                    textAlign: "center",
                    fontSize: "1.5rem"
                }}>
                    {this.props.location.state.message}
                </div>
                {/* <div style={{
                    textAlign: "center"
                }}><Link style={{
                    all: "unsets"
                }} to="/">Menu</Link></div> */}
            </div>
        );
    }
}