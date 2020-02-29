import React from 'react';

import "./itemDetails.css";
import { useParams } from 'react-router-dom';

export default function ItemDetails(props) {
    let { id } = new useParams();
    let selectedProduct;

    if (props && props.data) {
        props.data.forEach(product => {
            if (product.id == id) {
                selectedProduct = product;
            }
        });

        return (
            <div id="itemDetails">
                <div className="imagesContainer">
                    {selectedProduct.contents.map((content) => {
                        return <img src={content.relativePath} />
                    })}
                </div>
                <div>
                    Details
                </div>
            </div>
        );
    } else return '';
}

// export default class ItemDetails extends React.Component {
//     constructor(props) {
//         super(props);
//     }

//     render() {

//     }
// }