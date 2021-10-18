using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixTask4
{
    public class Fork
    {
        private readonly string ForkName;
        public Fork(int forkNum)
        {
            ForkName = $"fork number {forkNum}";
        }

        public string ForkAction()
        {
            return $"grabs a noodle with a {ForkName}";
        }
    }
}
