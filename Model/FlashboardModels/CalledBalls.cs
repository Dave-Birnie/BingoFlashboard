using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashboard.Model
{

    // This class is used to store the state of the called balls for the flashboard
    public class CalledBalls
    {
        public string CalledBallState_ { get; set; } = "State";
        public int BallNum_ { get; set; } = 0;
    }
}
