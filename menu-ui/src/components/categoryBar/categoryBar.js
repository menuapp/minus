import './categoryBar.css';

import React from 'react';

export default class CategoryBar extends React.Component {
    constructor(props) {
        super(props);

        this.showCategoryItems = this.showCategoryItems.bind(this);
    }

    showCategoryItems(event) {
        let chosenCategoryIndex = Number(event.target.getAttribute("data-key"));
        this.props.updateCategoryItems(chosenCategoryIndex);
    }

    render() {
        return (
            <div id="category-bar">
                <div id="category-bar-wrapper">
                    <div className="scrollable">
                    {
                        this.props.categoryName.map((name, index) => {
                            return (<span key={index} data-key={index} onClick={this.showCategoryItems} className="name">
                                {name}
                            </span>
                            );
                        })
                    }
                    </div>
                </div>
            </div>
        );
    }
}