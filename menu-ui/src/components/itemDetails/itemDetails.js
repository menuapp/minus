import React from 'react';

import './itemDetails.css';
import { useParams } from 'react-router-dom';
import BottomNavBar from '../bottomNavBar/bottomNavBar';

export default function ItemDetails(props) {
  let { id } = new useParams();
  let product = {};

  props.products.some(item => {
    if (item.id == id) {
      product = item;
    }
  });

  return (
    <div>
      <div id="itemDetails">
        <div className="imagesContainer">
          {(product.contents || []).map((item, index) => {
            return (
              <div>
                <img src={'http://' + item.relativePath} width="100%" />
              </div>
            );
          })}
          <div className="product-details-container">
            <div className="container product-name">{product.name || ''}</div>
          </div>
        </div>
      </div>
      <BottomNavBar>
        <div className="col-3">{product.unitPrice + " TL"}</div>
        <button className="order-btn col-3 h-100 offset-6 ">Order</button>
      </BottomNavBar>
    </div>
  );
}
