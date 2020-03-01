import './navigationBar.css';
import logo from '../../food.svg';

import React from 'react';
import { Route, Switch, Link } from 'react-router-dom';
import SignIn from '../signIn/signIn';
import App from '../../App';

export default class NavigationBar extends React.Component {
  constructor(props) {
    super(props);
    this.state = { isExpand: false };
    this.updateNavigation = this.updateNavigation.bind(this);
    this.toggleMenu = this.toggleMenu.bind(this);
  }

  updateNavigation() {
    this.setState({ isExpand: false });
  }

  toggleMenu() {
    this.setState({ isExpand: !this.state.isExpand });
  }

  render() {
    return (
      <div>
        <nav role="navigation">
          <div id="menuToggle">
            <input
              type="checkbox"
              checked={this.state.isExpand}
              onClick={this.toggleMenu}
            />
            <span></span>
            <span></span>
            <span></span>
            <ul id="menu">
              <li>
                <Link to="/signin" onClick={this.updateNavigation}>
                  Sign in
                </Link>
              </li>
              <li>
                <Link to="/" onClick={this.updateNavigation}>
                  Search
                </Link>
              </li>
              <li>
                <Link to="/" onClick={this.updateNavigation}>
                  Info
                </Link>
              </li>
              <li>
                <Link to="/" onClick={this.updateNavigation}>
                  Home
                </Link>
              </li>
            </ul>
          </div>
          <img src={logo} />
        </nav>
      </div>
    );
  }
}
