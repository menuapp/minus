import React from 'react';

import './slidingPage.css';
import ItemBox from '../itemBox/itemBox';

export default class SlidingPage extends React.Component {
  constructor(props) {
    super(props);

    this.updateBasket = this.updateBasket.bind(this);
  }

  updateBasket() {
    this.props.updateBasket();
  }

  render() {
    return (
      <div className="page container-fluid">
        <div className="slidingPage row">
          {this.props.category.map((card, index) => {
            return (
              <div key={index} className="col-xs-12 col-md-4 col-xl-3">
                <ItemBox updateBasket={this.updateBasket} card={card} />
              </div>
            );
          })}
        </div>
      </div>
    );
  }
}
