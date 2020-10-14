using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home_work_c_generic
{
    class Player
    {
        public string Name { get; set; }

        public Queue<Card>  Cards = new Queue<Card>(18);

        public void  Show_cards()
        {
            foreach (var item in Cards)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }

    class Game
    {
        Deck_of_cards Cards = new Deck_of_cards();
        private Player player1 = new Player();
        private Player player2 = new Player();
      
        private  void Distribution(Player player)
        {
            for (int i = 0; i < 18; i++)
            {
                player.Cards.Enqueue(Cards.Get_card_from_deck());
            }
        }

        public void Game_()
        {      
            Cards.Shuffle_deck();
            Distribution(player2);
            Distribution(player1);

            Card cardp1 = new Card();
            Card cardp2 = new Card();

            int raund = 0;
            bool win = true;
            while (win)
            {
                cardp1 = player1.Cards.Peek();
                cardp2 = player2.Cards.Peek();
                raund++;
                if (cardp1.Name > cardp2.Name )
                {
                    Console.WriteLine($"raund: {raund})  card player1 :{cardp1.ToString()}  ->  card player2 : {cardp2.ToString()} ");
                    player1.Cards.Dequeue();
                    player1.Cards.Enqueue(cardp1);
                    player1.Cards.Enqueue(player2.Cards.Dequeue());
                }
                else if (cardp1.Name == cardp2.Name)
                {
                    Console.WriteLine($"raund: {raund}) card player1 :{cardp1.ToString()} == card player2 :{cardp2.ToString()} ");
                    player1.Cards.Dequeue();
                    player1.Cards.Enqueue(cardp1);
                    player1.Cards.Enqueue(player2.Cards.Dequeue());
                }
                else if (cardp1.Name < cardp2.Name )
                {
                    Console.WriteLine($"raund: {raund}) card player1 :{cardp1.ToString()}  <-  card player2 :{cardp2.ToString()} ");
                    player2.Cards.Dequeue();
                    player2.Cards.Enqueue(cardp2);
                    player2.Cards.Enqueue(player1.Cards.Dequeue());
                }

                if (player1.Cards.Count == 36)
                {
                    Console.WriteLine("\nPlayer 1 winer 36 cards");
                    win = false;
                }
                else if (player2.Cards.Count == 36)
                {
                    Console.WriteLine("\nPlayer 2 winer 36 cards");
                    win = false;
                }
            }


        }

    }

    public class Card : IComparable<Card>
    {
        public int Name { get; set; }
        public string Mast { get; set; }

        public int count_sort;

        public Card( ){ }
        public Card(int name, string mast)
        {
            Name = name;
            Mast = mast;
            count_sort = -1;
        }

        public int CompareTo(Card other)
        {
            return count_sort.CompareTo(other.count_sort);
        }
        public int Count_sort
        {
            get { return count_sort; }
            set { count_sort = value; }
        }
        public override string ToString()
        {
            return ($"{Mast}");
        }

    }

    public class Deck_of_cards
    {

        Queue<Card> deck_cards = new Queue<Card>(36);
        Card[] Cards = new Card[36];
        public Deck_of_cards()
        {
            deck_cards.Enqueue(new Card(6, "6-Hearts"));
            deck_cards.Enqueue(new Card(6, "6-Diamonds"));
            deck_cards.Enqueue(new Card(6, "6-Clubs"));
            deck_cards.Enqueue(new Card(6, "6-Spades "));
            deck_cards.Enqueue(new Card(7, "7-Hearts"));
            deck_cards.Enqueue(new Card(7, "7-Diamonds"));
            deck_cards.Enqueue(new Card(7, "7-Clubs"));
            deck_cards.Enqueue(new Card(7, "7-Spades "));
            deck_cards.Enqueue(new Card(8, "8-Hearts"));
            deck_cards.Enqueue(new Card(8, "8-Diamonds"));
            deck_cards.Enqueue(new Card(8, "8-Clubs"));
            deck_cards.Enqueue(new Card(8, "8-Spades "));
            deck_cards.Enqueue(new Card(9, "9-Hearts"));
            deck_cards.Enqueue(new Card(9, "9-Diamonds"));
            deck_cards.Enqueue(new Card(9, "9-Clubs"));
            deck_cards.Enqueue(new Card(9, "9-Spades "));
            deck_cards.Enqueue(new Card(10, "10-Hearts"));
            deck_cards.Enqueue(new Card(10, "10-Diamonds"));
            deck_cards.Enqueue(new Card(10, "10-Clubs"));
            deck_cards.Enqueue(new Card(10, "10-Spades "));
            deck_cards.Enqueue(new Card(11, "Jack-Hearts"));
            deck_cards.Enqueue(new Card(11, "Jack-Diamonds"));
            deck_cards.Enqueue(new Card(11, "Jack-Clubs"));
            deck_cards.Enqueue(new Card(11, "Jack-Spades "));
            deck_cards.Enqueue(new Card(12, "Queen -Hearts"));
            deck_cards.Enqueue(new Card(12, "Queen -Diamonds"));
            deck_cards.Enqueue(new Card(12, "Queen _Clubs"));
            deck_cards.Enqueue(new Card(12, "Queen -Spades "));
            deck_cards.Enqueue(new Card(13, "King-Hearts"));
            deck_cards.Enqueue(new Card(13, "King-Diamonds"));
            deck_cards.Enqueue(new Card(13, "King-Clubs"));
            deck_cards.Enqueue(new Card(13, "King-Spades "));
            deck_cards.Enqueue(new Card(14, "Ace -Hearts"));
            deck_cards.Enqueue(new Card(14, "Ace -Diamonds"));
            deck_cards.Enqueue(new Card(14, "Ace -Clubs"));
            deck_cards.Enqueue(new Card(14, "Ace -Spades "));

        }

        public void Sort(IComparer<Card> comparer)
        {
            Array.Sort(Cards, comparer);
        }

        public void Shuffle_deck()
        {
            Random rnd = new Random();
            int random;

            foreach (var item in deck_cards)
            {
                random = rnd.Next(0, 100);
                item.Count_sort = random;
            }

            int num = 0;
            foreach (var item in deck_cards)
            {
                Cards[num] = item;
                num++;
            }

            Sort(new CompareByCount_to_sort());

            Queue<Card> temp = new Queue<Card>(36);
            foreach (var item in Cards)
            {
                temp.Enqueue(item);
            }

            deck_cards = temp;
        }

        public Card Get_card_from_deck()
        {
            return deck_cards.Dequeue();
        }

       
        public void Show_deck_of_card()
        {
            foreach (var item in deck_cards)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class CompareByCount_to_sort : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return x.count_sort.CompareTo(y.count_sort);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Game_();
        }
    }
}
