using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awari.Model
{
    public class AwariEventArgs : EventArgs
    {
        private int _whoWon;

        public int WhoWon { get { return _whoWon; } }

        /// <param name="WhoWon">hú íz disz núb hú vin dö gém.</param>

        public AwariEventArgs(int WhoWon)
        {
            _whoWon = WhoWon;       
        }

    }
}
