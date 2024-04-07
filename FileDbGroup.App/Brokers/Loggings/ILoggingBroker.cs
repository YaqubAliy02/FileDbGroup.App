namespace FileDbGroup.App.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInforamation(string message);
        void LogError(string userMessage);
        void LogError(Exception exception);
    }
}
