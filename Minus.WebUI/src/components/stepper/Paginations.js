import React, { Component } from 'react';
import Yiyecek from '../../images/yiyecekler.png';
import Icecek from '../../images/icecekler.png';
import Tatli from '../../images/tatlilar.png';



export  class BasicExample extends Component {
  render() {
    return (
      <div>
        <a href='#yiyecekler'><img className="" src={Yiyecek} alt="yiyecek kısmı" /> </a>
        <a href='#icecekler'> <img className="" src={Icecek} alt="icecek kısmı" /></a>
        <a href='#tatlilar'> <img className="" src={Tatli} alt="tatli kısmı" /> </a>
      </div>
    )
  }
}

export default BasicExample;
