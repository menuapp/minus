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
            <div className="container product-desc">
            You could spend 15 minutes preheating your oven and then another hour baking your potato, but why would you ever do that when you can microwave your potato in 7 minutes flat??

Pat it dry

You'll of course need to scrub and clean your potato first. Be sure to dry them extra well so they don't steam too much in the microwave. 

Poke the potato.  

Yes! Poking the potato helps steam escape and makes the potato softer. It's an important step so don't skip it! 

Go crazy with the toppings.

Just because you've made a meal in the microwave doesn't mean it can't be exciting. If you want to completely avoid the oven, stick with sauces or herbs that don't need to be heated again. Or add some cheese and bacon and pop it back in the microwave for a minute to melt. 

Of course, if you still want to bake your baked potato, we've got you covered there too. 

Made this? Let us know how it went in the comment section below!
            </div>
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
