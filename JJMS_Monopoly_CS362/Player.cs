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
        private int cashAmount;             // Amount of money in the player's bank   
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
        private List<Property> propertiesOwned = new List<Property>();

        //Default Constructor
        public Player()
        {
            playerName = "Player 1";
            playerLocation = Start;
            cashAmount = 1500;
        }

        public Player(string playerName)
        {
            playerName = playerName;
            playerLocation = Start;
            cashAmount = 1500;
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
        
        public void AddProperty(Property propertyToBeAdded)
        {
            propertiesOwned.Add(propertyToBeAdded);
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
