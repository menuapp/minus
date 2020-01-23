import React from 'react';

import './App.css';
import Carousel from './components/carousel/carousel';
import CarouselItem from './components/carouselItem/carouselItem';

function App() {
  return (
    <div className="App">
      <Carousel>
        <CarouselItem color="red" />
        <CarouselItem color="blue" />
      </Carousel>
    </div>
  );
}

export default App;
