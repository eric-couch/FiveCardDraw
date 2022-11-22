using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample
{
    internal class Player
    {
        public string Name { get; set; } = String.Empty;
        public List<Card> Hand {  get; set; } = new List<Card>();

        public Player() { }
    }
}
