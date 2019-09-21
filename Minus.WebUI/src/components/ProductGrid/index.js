import React from "react";
import PropTypes from "prop-types";
import styled from "styled-components";
import "./style.scss";
import sepetIcon from "../../images/sepete-ekle.png";
import ProductCount from './ProductCount';

const Wrapper = styled.div`
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
`;

const ProductWrapper = styled.div`
  flex-basis: 24%;
  margin-bottom: 20px;
`;

const ProductImage = styled.img`
  width: 100%;
`;

const ProductName = styled.div`
  margin: 10px 0;
`;
const ProductPrice = styled.div`
  margin: 10px 0;
`;

const ProductGrid = ({ products, addToCart }) => (
  <Wrapper>
    {products.map(product => (
      <div className="wrapper">
        <div className="container">
          <div className="bottom">
            <ProductWrapper key={product._id}>
              <ProductImage className="product-image" src={product.picture} />
              <ProductName className="product-name">{product.name}</ProductName>
              <ProductPrice className="price">{product.price} ₺</ProductPrice>
              <div>
                <button onClick={() => addToCart(product)}>
                  <img className="sepetIcon" src={sepetIcon} alt="sepet kısmı" />
                </button>
              </div>
              <ProductCount>{product.quantity} </ProductCount>
            </ProductWrapper>
          </div>
        </div>
        <div className="inside">
          <div className="icon">
            <i className="material-icons">Açıklama</i>
          </div>
          <div className="contents">
            <table>
              <tr>
                <th>İçindekiler:</th>
                <th>Height</th>
              </tr>
              <tr>
                <td>3000mm</td>
                <td>4000mm</td>
              </tr>
              <tr>
                <th>Something</th>
                <th>Something</th>
              </tr>
              <tr>
                <td>200mm</td>
                <td>200mm</td>
              </tr>
              <tr>
                <th>Something</th>
                <th>Something</th>
              </tr>
              <tr>
                <td>200mm</td>
                <td>200mm</td>
              </tr>
              <tr>
                <th>Something</th>
                <th>Something</th>
              </tr>
              <tr>
                <td>200mm</td>
                <td>200mm</td>
              </tr>
            </table>
          </div>
        </div>
      </div>
    ))}
  </Wrapper>
);

ProductGrid.propTypes = {
  products: PropTypes.arrayOf(
    PropTypes.shape({
      _id: PropTypes.string.isRequired,
      picture: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
      price: PropTypes.number.isRequired,
      quantity: PropTypes.number.isRequired
    })
  ).isRequired,
  addToCart: PropTypes.func.isRequired
};

export default ProductGrid;
