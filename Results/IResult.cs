namespace Results;

public interface IResult
{
    public bool Success { get; protected set; }
    public Exception? Exception { get; protected set; }
    public ICollection<string> ErrorMessages { get; protected set; }
    public bool HasErrors => ErrorMessages.Any();
}

public interface IResult<TData> : IResult where TData : class
{
    public TData? Data { get; protected set; }
    public bool HasData => Data is not null;
    public bool HasErrorMessages => ErrorMessages.Any();

}