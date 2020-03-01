import React from 'react';

import './slidingPage.css';
import ItemBox from '../itemBox/itemBox';

export default class SlidingPage extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="page container-fluid">
        <div className="slidingPage row">
          {this.props.category.map((card, index) => {
            return (
              <div key={index} className="col-xs-12 col-md-4 col-xl-3">
                <ItemBox card={card} />
              </div>
            );
          })}
        </div>
      </div>
    );
  }
}
