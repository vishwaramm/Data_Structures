import React, { Component } from 'react';

class UICard extends Component {

    render() {
        return (
            <div className="card">
                <div className="suit">{this.props.card.suit}</div>
                <div className="rank">{this.props.card.rank}</div>
            </div>
        );
    }
}

export default UICard;