using System.Collections.Generic;

namespace GitToolbox
{
    public class Arguments
    {
        private readonly Queue<string> _Arguments;

        public Arguments(string[] args)
        {
            _Arguments = new Queue<string>(args);
        }

        public string Next
        {
            get
            {
                if (_Arguments.Count == 0)
                    return string.Empty;

                return _Arguments.Peek();
            }
        }

        public void Shift()
        {
            if (_Arguments.Count > 0)
                _Arguments.Dequeue();
        }
    }
}