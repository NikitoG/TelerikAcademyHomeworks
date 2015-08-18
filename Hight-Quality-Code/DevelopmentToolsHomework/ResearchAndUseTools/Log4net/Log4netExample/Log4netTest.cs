namespace Log4netExample
{
    using System;

    using log4net;
    using log4net.Config;

    class Log4netTest
    {
        private static readonly ILog Log =
          LogManager.GetLogger(typeof(Log4netTest));
        static void Main()
        {
            BasicConfigurator.Configure();
            Log.Debug("Debug msg");
            Log.Error("Error msg");
            Log.Fatal("Fatal msg");
            Log.Warn("Warn msg");
            Log.Info("Info msg");
        }

    }
}
