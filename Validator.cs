using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    /// <summary>
    /// Contatins helper methods for common validation
    /// </summary>
    static class Validator
    {
        /// <summary>
        /// Checks if the textbox has any data
        /// Whitespace does not count
        /// </summary>
        /// <param name="box">The textbox to check</param>
        /// <returns>True if there is a value other 
        ///         than null or whitespace</returns>
        public static bool IsPresent(TextBox box)
        {
            if(string.IsNullOrWhiteSpace(box.Text))
            {
                return false;
            }
            return true;
        }
    }
}
