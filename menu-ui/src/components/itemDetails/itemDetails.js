import React from 'react';

import './itemDetails.css';
import { useParams } from 'react-router-dom';

export default function ItemDetails(props) {
  let { id } = new useParams();


  return (
    <div id="itemDetails">
      <div className="imagesContainer">
        {id}
      </div>
      <div>Details</div>
    </div>
  );
}

// export default class ItemDetails extends React.Component {
//     constructor(props) {
//         super(props);
//     }

//     render() {

//     }
// }
