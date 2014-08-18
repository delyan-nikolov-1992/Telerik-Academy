namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        // playing Texas Hold'em there are five cards in the hand of a player
        private const byte NumberOfCards = 5;

        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The cards in the hand should not be null!");
                }

                if (value.Count != NumberOfCards)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                        "The cards in the hand should be exactly ",
                        NumberOfCards));
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var currentCard in this.Cards)
            {
                result.AppendLine(currentCard.ToString());
            }

            return result.ToString();
        }
    }
}