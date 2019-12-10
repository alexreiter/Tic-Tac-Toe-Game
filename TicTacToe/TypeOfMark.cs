using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// the type of value a cell in the game is currently at
    /// </summary>
    enum TypeOfMark
    {
        /// <summary>
        /// the cell hasn't been clicked yet
        /// </summary>
        Free, 

        /// <summary>
        /// the cell is 0
        /// </summary>
        Nought, 

        /// <summary>
        /// the cell is an x
        /// </summary>
        Cross

    }
}
