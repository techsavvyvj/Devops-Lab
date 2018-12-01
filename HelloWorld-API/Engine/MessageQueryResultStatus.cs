namespace HelloWorld.API.Engine
{
    /// <summary>
    /// The different statuses a request for a Message may have.
    /// </summary>
    public enum MessageQueryResultStatus
    {
        Ok = 0,
        NoResults = 1,
        Error = -1
    }
}