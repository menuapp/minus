import React from 'react';
import Animal from './Animal';
import Food from './Food';
import AltyumLira from '../../images/altyum-lira.png';
import TipBox from '../../images/tip-box.png';

export default class BahsisKutusu extends React.Component {
  render() {

    // we will use this as a custom drag element
    const customElem = <button style={{marginTop:20, marginLeft:20}}>Altyum Parasi</button> 

    const scrollBoxStyle = {
      float:'left', width: 120, height: 200, marginTop: 40, border: '1px solid black',
    };

    return (
      <div className='drag_food_to_animals'>
        <div className="foods" style={scrollBoxStyle}>
          <Food targetKey="AltyumParasi" label="Teşekkürler" tastes="Lezzetli" image={AltyumLira}/>
          <Food targetKey="AltyumParasi" label="Teşekkürler" tastes="Garip tadı vardı" image={AltyumLira}/>
          <Food dragClone={true} dragElemOpacity={0.4} targetKey="AltyumParasi" label="Teşekkürler" tastes="Iyi çalışmalar!" image={AltyumLira}/>
          <Food customDragElement={customElem} targetKey="AltyumParasi" label="Teşekkürler" tastes="Güzeldi" image={AltyumLira}/>
        </div>
        <div className="animals">
            <Animal targetKey="AltyumParasi" name="Kong">
              <img src={TipBox} width="215" alt="hadi"/>
            </Animal>
        </div>
        <h3>Notlar:</h3>
        <ul>
          <li><strong>Altyum Parasi </strong> her biri 10 Lira'dir.</li>
          <li><strong>Dikkat!</strong> geri almak ve buna benzer her hangi bir tuş yoktur.</li>
          <li><strong>Nasıl Çalışır?</strong> <img src={AltyumLira} alt="Logo" /> aldıktan sonra sürekliyip <img src={TipBox} width="60px" alt="Logo" /> içine bırakın</li>
        </ul>
      </div>
    )
  }
}