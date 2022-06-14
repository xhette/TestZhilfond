namespace TestZhilfond.Database.Extentions.Classes
{
    public enum DbResultCode
    {
        OK,
        Error
    }

    public class DbResult<T> where T : class
    {
        public DbResultCode ResultCode { get; set; }

        public T? Result { get; set; }

        public string ErrorMessage { get; set; }

    }
}
