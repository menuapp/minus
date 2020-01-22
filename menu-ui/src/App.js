import React from 'react';
import logo from './logo.svg';
import './App.css';
import Product from './components/product/product';
import Carousel from './components/carousel/carousel';

function App() {
  return (
    <div className="App">
      <Carousel color={"red"} />
      <Carousel color={"blue"} />
      <Carousel color={"yellow"} />
    </div>
  );
}

export default App;
