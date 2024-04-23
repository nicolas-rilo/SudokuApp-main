using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.UsuarioService
{
    /// <summary>
    /// VO Class which contains the user details
    /// </summary>
    [Serializable()]
    public class UserDetails
    {

        public String firstName { get; private set; }

        public String lastName { get; private set; }

        public String Email { get; private set; }

        public String idiom { get; private set; }

        public String country { get; private set; }

        public bool admin { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioDetails"/>
        /// class.
        /// </summary>
        /// <param name="name">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="idiom">The language.</param>
        /// <param name="country">The country.</param>
        public UserDetails(String name, String lastName,
            String email, String idiom, String country)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.Email = email;
            this.idiom = idiom;
            this.country = country;
        }

        public override bool Equals(object obj)
        {

            UserDetails target = (UserDetails)obj;

            return (this.firstName == target.firstName)
                  && (this.lastName == target.lastName)
                  && (this.Email == target.Email)
                  && (this.idiom == target.idiom)
                  && (this.country == target.country);
        }

        // The GetHashCode method is used in hashing algorithms and data 
        // structures such as a hash table. In order to ensure that it works 
        // properly, we suppose that the FirstName does not change.        
        public override int GetHashCode()
        {
            return this.firstName.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the 
        /// current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current 
        /// <see cref="T:System.Object"></see>.
        /// </returns>
        public override String ToString()
        {
            String strUserProfileDetails;

            strUserProfileDetails =
                "[ firstName = " + firstName + " | " +
                "lastName = " + lastName + " | " +
                "email = " + Email + " | " +
                "language = " + idiom + " | " +
                "country = " + country + " ]";


            return strUserProfileDetails;
        }
    }
}
