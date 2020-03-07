import './bottomNavBar.css';

import React from 'react';

export default class BottomNavBar extends React.Component {
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
        <div className="bottom-nav" role="navigation">
          <div className="container h-100">
            <div className="row h-100 align-items-center">
              {this.props.children}
            </div>
          </div>
        </div>
      </div>
    );
  }
}
