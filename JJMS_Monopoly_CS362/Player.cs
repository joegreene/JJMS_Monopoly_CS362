using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyProject
{
    class Player
    {
        private string playerName;          // Players name will default to Player 1,2,3,.... or, n amount of playhers
       
        // DO YOU WANT TO KEEP TRACK OF DEMONINATION OF BILLS I.E. $1, $5, $10, ...
        // if so...check out cashAmountTwo;
        private int cashAmount;             // Amount of money in the player's bank 
        private int[,] cashAmountTwo = new int [1, 7];
        
        private Token token;                // The token peice that the player has chosen to represent the player on the board
        private Property playerLocation;    // Property that the player is currently one

        /* Associative array where the first slot keeps track of the properties owned by the second attribute is associated
         * with the ammount houses and hotels the player has on that property. I used an associative array in that it is easier to keep
         * track of two items that are associated with one another but different data types. We can split the second attribute into a second
         * dictionary where the first property is number of houses and the second is the number of hotels. I wasnt to sure how houses and hotels
         * going to be implented in this game, as and object or an attribute to the location.
         */

        // This Dictionary implies that the second attribute is associated with the number of houses and hotels and one number. Where 0 is neither 
        // houses nor hotels are owned. 1, 2, and 3 represent the number of houses. 4 represents 1 hotel and 5 represents 2 hotels
        private IDictionary<Property, int>
            propertiesOwned = new Dictionary<Property, int>();

        // This Dictionary imples that the second attribute is associate witht the number of houses and hotels as two seperate entities in another
        // Dictionary. The first property represents the number of house, the second represents the number of hotels.
        private IDictionary<Property, IDictionary<int, int>>
            propertiesOwned2 = new Dictionary<Property, IDictionary<int, int>>();

        //Default Constructor
        public Player()
        {
            playerName = "Player 1";
            playerLocation = Start;
            cashAmount = 1500;

            for(int i = 0; i < 6; i++)
            {
                if (i < 3)
                {
                    cashAmountTwo[0, i] = 5;
                }
                else if(i < 4)
                {
                    cashAmountTwo[0, i] = 6;
                }
                else
                {
                    cashAmountTwo[0, i] = 2;
                }
            }
        }

        public Player(string playerName)
        {
            playerName = playerName;
            playerLocation = Start;
            cashAmount = 1500;

            for (int i = 0; i < 6; i++)
            {
                if (i < 3)
                {
                    cashAmountTwo[0, i] = 5;
                }
                else if (i < 4)
                {
                    cashAmountTwo[0, i] = 6;
                }
                else
                {
                    cashAmountTwo[0, i] = 2;
                }
            }
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public void SetPlayerName(string newPlayerName)
        {
            playerName = newPlayerName;
        }

        public int GetCashAmount()
        {
            return cashAmount;
        }

        public void SetCashAmount(int newCashAmount)
        {
            cashAmount = newCashAmount;
        }

        public void IncreaseCashAmount(int increaseCashByThisAmount)
        {
            cashAmount = cashAmount + increaseCashByThisAmount;
        }

        public void DecreaseCashAmount(int decreaseCashByThisAmount)
        {
            cashAmount = cashAmount - decreaseCashByThisAmount;
        }

        public int GetCashAmountTwo()
        {
            int total;

            total = cashAmountTwo[0, 0] + (cashAmountTwo[0, 1] * 5) + (cashAmountTwo[0, 2] * 10)
                + (cashAmountTwo[0, 3] * 20) + (cashAmountTwo[0, 4] * 100) + (cashAmountTwo[0, 6] * 500);

            return total;
        }

        public void SetCashAmountTwo(int demoninationToChange, int newAmount)
        {
            cashAmountTwo[0, demoninationToChange] = newAmount;
        }
        
        public void AddProperty(Property propertyToBeAdded)
        {
            propertiesOwned.Add(propertyToBeAdded, 0);
        }

        public void RemoveProperty(Property propertyToBeRemoved)
        {
            propertiesOwned.Remove(propertyToBeRemoved);
        }

        public Property GetPlayerLocation()
        {
            return playerLocation;
        }

        public void SetPlayerLocation(Property newPlayerLocation)
        {
            playerLocation = newPlayerLocation;
        }
    }
}
