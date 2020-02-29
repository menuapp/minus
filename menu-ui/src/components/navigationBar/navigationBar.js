import './navigationBar.css';
import logo from '../../food.svg';

import React from 'react';
import { Route, Switch, Link } from 'react-router-dom';
import SignIn from '../signIn/signIn';
import App from '../../App';


export default class NavigationBar extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <nav role="navigation">
                    <div id="menuToggle">
                        <input type="checkbox" />
                        <span></span>
                        <span></span>
                        <span></span>
                        <ul id="menu">
                            <li><Link to="/signin">Sign in</Link></li>
                            <li><Link to="/">Search</Link></li>
                            <li><Link to="/">Info</Link></li>
                            <li><Link to="/">Home</Link></li>
                        </ul>

                    </div>
                    <img src={logo} />
                </nav>
                
            </div>);
    }
}