using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.UsuarioDao
{
    /// <summary>
    /// A Custom VO which keeps the results for a login action.
    /// </summary>
    [Serializable()]
    public class LoginResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResult"/> class.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="name">Users's first name.</param>
        /// <param name="encryptedPassword">The encrypted password.</param>
        /// <param name="idiom">The language.</param>
        /// <param name="country">The country.</param>
        public LoginResult(long userId, String name,
            String encryptedPassword, String idiom, String country)
        {
            this.UserId = userId;
            this.Name = name;
            this.EncryptedPassword = encryptedPassword;
            this.Idiom = idiom;
            this.Country = country;
        }

        #region Properties Region

        /// <summary>
        /// Gets the country code.
        /// </summary>
        /// <value>The country code.</value>
        public string Country { get; private set; }

        /// <summary>
        /// Gets the encrypted password.
        /// </summary>
        /// <value>The <c>encryptedPassword.</c></value>
        public string EncryptedPassword { get; private set; }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>The <c>firstName</c></value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the language code.
        /// </summary>
        /// <value>The language code.</value>
        public string Idiom { get; private set; }

        /// <summary>
        /// Gets the user profile id.
        /// </summary>
        /// <value>The user profile id.</value>
        public long UserId { get; private set; }

        #endregion Properties Region

        public override bool Equals(object obj)
        {
            LoginResult target = (LoginResult)obj;

            return (this.UserId == target.UserId)
                   && (this.Name == target.Name)
                   && (this.EncryptedPassword == target.EncryptedPassword)
                   && (this.Idiom == target.Idiom)
                   && (this.Country == target.Country);
        }

        // The GetHashCode method is used in hashing algorithms and data
        // structures such as a hash table. In order to ensure that it works
        // properly, it is based on a field that does not change.
        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
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
            String strLoginResult;

            strLoginResult =
                "[ userProfileId = " + UserId + " | " +
                "firstName = " + Name + " | " +
                "encryptedPassword = " + EncryptedPassword + " | " +
                "language = " + Idiom + " | " +
                "country = " + Country + " ]";

            return strLoginResult;
        }
    }
}
