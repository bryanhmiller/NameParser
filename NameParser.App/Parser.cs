using System;
using System.Collections.Generic;
using System.Linq;

namespace NameParser.App
{
    public class Parser
    {
        public User ParseName(string name)
        {
            var user = new User();
            var namePieces = name.Split(' ');

            if (namePieces.Length == 1)
            {
                user.FirstName = namePieces[0];
                return user;
            }

            SetHonorificAndFirstName(user, namePieces);
            SetSuffixAndLastName(user, namePieces);
            SetMiddleInitial(user, namePieces);
            return user;
        }

        static void SetMiddleInitial(User user, string[] namePieces)
        {
            var firstNamePosition = Array.IndexOf(namePieces, user.FirstName);
            var lastNamePosition = Array.IndexOf(namePieces, user.LastName);

            if (lastNamePosition - firstNamePosition == 2)
            {
                user.MiddleName = namePieces[lastNamePosition - 1].Trim('.');
            }
        }

        static void SetSuffixAndLastName(User user, string[] namePieces)
        {
            var acceptableSuffixes = new List<string> { "Jr.", "Sr.", "Jr", "Sr", "MD", "PHD", "II", "III", "Esq" };
            var lastPiecePosition = namePieces.Length - 1;
            var hasSuffix = acceptableSuffixes.Contains(namePieces[lastPiecePosition]);

            if (hasSuffix)
            {
                user.Suffix = namePieces[lastPiecePosition];
                user.LastName = namePieces[lastPiecePosition - 1];
            }
            else
            {
                user.LastName = namePieces[lastPiecePosition];
            }
        }

        static void SetHonorificAndFirstName(User user, string[] namePieces)
        {
            var acceptableHonorifics = new List<string> { "Mr.", "Mrs.", "Ms.", "Mr", "Mrs", "Ms", "Miss", "Dr.", "Dr" };

            if (acceptableHonorifics.Contains(namePieces[0]))
            {
                user.Honorific = namePieces[0];
                user.FirstName = namePieces[1];
            }
            else
            {
                user.FirstName = namePieces[0];
            }
        }
    }
}