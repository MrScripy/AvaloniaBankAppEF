using System;

namespace AvaloniaBankAppEF.Args
{
    public class DialogResultEventArgs<TResult> : EventArgs
    {
        private readonly TResult _result;
        public TResult Result => _result;
        public DialogResultEventArgs(TResult result)
        {
            _result = result;
        }
    }
}
