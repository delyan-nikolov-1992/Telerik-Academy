namespace Poker
{
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face &&
                        hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var orderedByFaces = hand.Cards.OrderBy(x => x.Face).ToList();
            bool aceAsFirst = false;

            if (orderedByFaces[0].Face == CardFace.Two && orderedByFaces[4].Face == CardFace.Ace &&
                orderedByFaces[0].Suit == orderedByFaces[4].Suit)
            {
                aceAsFirst = true;
            }

            for (int i = 1; i < orderedByFaces.Count; i++)
            {
                if (i == 4 && aceAsFirst)
                {
                    return true;
                }

                if (orderedByFaces[0].Face + i != orderedByFaces[i].Face ||
                    orderedByFaces[0].Suit != orderedByFaces[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            for (int i = 0; i < 2; i++)
            {
                byte counter = 1;

                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        counter++;
                    }
                }

                if (counter == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            var orderedByFaces = hand.Cards.OrderBy(x => x.Face).ToList();

            if ((orderedByFaces[0].Face == orderedByFaces[1].Face &&
                orderedByFaces[1].Face == orderedByFaces[2].Face &&
                orderedByFaces[3].Face == orderedByFaces[4].Face) ||
                (orderedByFaces[0].Face == orderedByFaces[1].Face &&
                orderedByFaces[2].Face == orderedByFaces[3].Face &&
                orderedByFaces[3].Face == orderedByFaces[4].Face))
            {
                return true;
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            for (byte i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != hand.Cards[0].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            var orderedByFaces = hand.Cards.OrderBy(x => x.Face).ToList();
            bool aceAsFirst = false;

            if (orderedByFaces[0].Face == CardFace.Two && orderedByFaces[4].Face == CardFace.Ace)
            {
                aceAsFirst = true;
            }

            for (int i = 1; i < orderedByFaces.Count; i++)
            {
                if (i == 4 && aceAsFirst)
                {
                    return true;
                }

                if (orderedByFaces[0].Face + i != orderedByFaces[i].Face)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (this.IsFullHouse(hand) || this.IsFourOfAKind(hand))
            {
                return false;
            }

            var orderedByFaces = hand.Cards.OrderBy(x => x.Face).ToList();

            if ((orderedByFaces[0].Face == orderedByFaces[1].Face &&
                orderedByFaces[1].Face == orderedByFaces[2].Face) ||
                (orderedByFaces[2].Face == orderedByFaces[3].Face &&
                orderedByFaces[3].Face == orderedByFaces[4].Face))
            {
                return true;
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (this.IsFullHouse(hand) || this.IsFourOfAKind(hand))
            {
                return false;
            }

            var orderedByFaces = hand.Cards.OrderBy(x => x.Face).ToList();
            byte pairs = 0;

            for (int i = 0; i < orderedByFaces.Count - 1; i++)
            {
                if (orderedByFaces[i].Face == orderedByFaces[i + 1].Face)
                {
                    pairs++;
                    i++;
                }

                if (pairs == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (this.IsTwoPair(hand) || this.IsFullHouse(hand) || this.IsFourOfAKind(hand))
            {
                return false;
            }

            var orderedByFaces = hand.Cards.OrderBy(x => x.Face).ToList();

            for (int i = 0; i < orderedByFaces.Count - 1; i++)
            {
                if (orderedByFaces[i].Face == orderedByFaces[i + 1].Face)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsStraightFlush(hand) && !IsFourOfAKind(hand) && !IsFullHouse(hand) &&
                !IsFlush(hand) && !IsStraight(hand) && !IsThreeOfAKind(hand) &&
                !IsTwoPair(hand) && !IsOnePair(hand))
            {
                return true;
            }

            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsStraightFlush(firstHand) && this.IsStraightFlush(secondHand))
            {
                return -1;
            }
            else if (this.IsStraightFlush(firstHand) && !this.IsStraightFlush(secondHand))
            {
                return 1;
            }
            else if (!this.IsFourOfAKind(firstHand) && this.IsFourOfAKind(secondHand))
            {
                return -1;
            }
            else if (this.IsFourOfAKind(firstHand) && !this.IsFourOfAKind(secondHand))
            {
                return 1;
            }
            else if (!this.IsFullHouse(firstHand) && this.IsFullHouse(secondHand))
            {
                return -1;
            }
            else if (this.IsFullHouse(firstHand) && !this.IsFullHouse(secondHand))
            {
                return 1;
            }
            else if (!this.IsFlush(firstHand) && this.IsFlush(secondHand))
            {
                return -1;
            }
            else if (this.IsFlush(firstHand) && !this.IsFlush(secondHand))
            {
                return 1;
            }
            else if (!this.IsStraight(firstHand) && this.IsStraight(secondHand))
            {
                return -1;
            }
            else if (this.IsStraight(firstHand) && !this.IsStraight(secondHand))
            {
                return 1;
            }
            else if (!this.IsThreeOfAKind(firstHand) && this.IsThreeOfAKind(secondHand))
            {
                return -1;
            }
            else if (this.IsThreeOfAKind(firstHand) && !this.IsThreeOfAKind(secondHand))
            {
                return 1;
            }
            else if (!this.IsTwoPair(firstHand) && this.IsTwoPair(secondHand))
            {
                return -1;
            }
            else if (this.IsTwoPair(firstHand) && !this.IsTwoPair(secondHand))
            {
                return 1;
            }
            else if (!this.IsOnePair(firstHand) && this.IsOnePair(secondHand))
            {
                return -1;
            }
            else if (this.IsOnePair(firstHand) && !this.IsOnePair(secondHand))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}