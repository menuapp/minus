import './basket.css';

import React from 'react';
import BottomNavBar from '../bottomNavBar/bottomNavBar';

export default class Basket extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div>
                <BottomNavBar>
                    <div className="col-3">{100 + " TL"}</div>
                    <button className="pay-btn col-3 h-100">Confirm</button>
                </BottomNavBar>
            </div>
        );
    }
}