import './navigationBar.css';

declare var require: any

var React = require("react");
var ReactDOM = require("react-dom");

export class NavigationBar extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <nav>
                <li>Menus</li>
                <li>Restaurants</li>
                <li>Products</li>
                <li>Contact</li>
            </nav>
        );
    }
}   