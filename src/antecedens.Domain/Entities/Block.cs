using System;

namespace antecedens.Domain.Entities
{
    public class Block
    {
        public int Nonce { get; set; }

        public string TimeStamp { get; set; }

        public string Hash { get; set; }

        public string LastHash { get; set; }

        public int Difficulty { get; set; }

        public Chain AssociatedChain { get; set; }

    }
}
