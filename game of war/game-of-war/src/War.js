import React, { Component } from 'react';
import Deck from './classes/deck';
import UIDeck from './Deck';

class War extends Component {
    constructor(props) {
        super(props);

        this.state = {
            deck: new Deck(),
            players: [

            ],
            turns: 0,
            currentTurnPlayerIndex: 0
        };
    }

    deal() {
        let playerIndex = 0;
        this.state.deck.shuffle();

        while (this.state.deck.cards.length > 0) {
            if (playerIndex >= this.state.players.length) {
                playerIndex = 0;
            }

            let currentCard = this.state.deck.cards.pop();

            if (currentCard) {
                this.state.players[playerIndex].cards.push(currentCard);
                playerIndex++;
            }
        }
    }

    handlePlayerClick() {

    }
}

export default War;