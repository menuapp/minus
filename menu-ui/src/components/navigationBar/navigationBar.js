import './navigationBar.css';
import logo from '../../dish (1).svg';

import React from 'react';
import { Route, Switch, Link } from 'react-router-dom';
import SignIn from '../signIn/signIn';
import App from '../../App';
import OrderService from '../../Service/orderService';

export default class NavigationBar extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isExpand: false,
      transitionNone: false
    };

    this.updateNavigation = this.updateNavigation.bind(this);
    this.toggleMenu = this.toggleMenu.bind(this);
    this.stopPropagation = this.stopPropagation.bind(this);
  }

  stopPropagation(event, dimState) {
    this.props.dimBacklight(dimState);
    event.stopPropagation();
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.clickOutsideNavbar) {
      this.setState({ isExpand: false, transitionNone: false });
    }
  }

  updateNavigation() {
    this.setState({ isExpand: false, transitionNone: true }, () => this.props.dimBacklight(false));
  }

  toggleMenu() {
    this.setState({ isExpand: !this.state.isExpand, transitionNone: false }, () => {
      this.props.dimBacklight(this.state.isExpand);
    });
  }

  render() {
    return (
      <div>
        <nav role="navigation">
          <div id="menuToggle">
            <input
              className={(this.state.isExpand) ? "checked" : ""}
              type="checkbox"
              onClick={this.stopPropagation}
              onChange={this.toggleMenu}
            />
            <span className={this.state.transitionNone ? "transition-none" : ""}></span>
            <span className={this.state.transitionNone ? "transition-none" : ""}></span>
            <span className={this.state.transitionNone ? "transition-none" : ""}></span>
            <ul id="menu" className={this.state.transitionNone ? "transition-none" : ""} onClick={(e) => this.stopPropagation(e, true)}>
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
          <Link to="/basket">
            <div id="basket-link">
              <img src={logo} />
              {this.props.basketQuantity ? <span>{this.props.basketQuantity}</span> : ""}
            </div>
          </Link>
        </nav>
      </div>
    );
  }
}
