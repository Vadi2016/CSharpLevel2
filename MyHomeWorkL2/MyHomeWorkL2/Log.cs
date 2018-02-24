using System;
namespace MyHomeWorkL2
{
    public delegate void LogMessage(object o);


    class Log
    {
        LogMessage myDelegate;

        public void PrintMessage(LogMessage f)
        {
            myDelegate += f;
        }

        public void Start()
        {
            if (myDelegate != null) myDelegate(this);
        }
    }
}
