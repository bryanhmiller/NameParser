using System;
using System.Linq;

namespace NameParser.App
{
    public class Parser
    {
        public User ParseName(string name)
        {
            var user = new User();

            var namePieces = name.Split(' ');

            user.FirstName = namePieces[0];


            if (namePieces.Length > 1)
            {
                user.LastName = namePieces[1];

                if (namePieces[1].Contains('.')) 
                {
                    user.MiddleName = namePieces[1].First().ToString();
                    user.LastName = namePieces[2];
                }
            }

            if (namePieces.Length > 2 && namePieces[0].Contains('.'))
            {
                user.Honorific = namePieces[0];
                user.FirstName = namePieces[1];
                user.LastName = namePieces[2];
            }

            if (namePieces.Length > 2 && namePieces[2].Contains('.')) 
            {
                user.LastName = namePieces[1];
                user.Suffix = namePieces[2];
            }

            return user;
        }
    }
}