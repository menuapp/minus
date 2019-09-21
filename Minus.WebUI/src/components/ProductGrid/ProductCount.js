import React, { Component } from 'react';
import '../../App.css';

export class ProductCount extends Component {
  constructor(props) {
    super(props);
    this.state = {
      clicks: 0,
      show: true
    };
  }
  

  IncrementItem = () => {
    this.setState({ clicks: this.state.clicks + 1 });
  }
  DecreaseItem = () => {
    this.setState({ clicks: this.state.clicks - 1 && 0 });
  }

  render() {
    return (
      <div className="product-count">
        <button className="btn-inc" onClick={this.IncrementItem}>＋</button>
        { this.state.show ? <h2 className="count-rakam">{ this.state.clicks }</h2> : '' }
        <button className="btn-dec" onClick={this.DecreaseItem}>－</button>
      </div>
    );
  }
}

export default ProductCount;
