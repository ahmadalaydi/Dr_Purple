﻿namespace Dr_Purple.Application.Utility.Results;
public class DataResult<T> : Result, IDataResult<T>
{
    public T Data { get; }
    public DataResult(T data, bool succsess, string message, string messageId)
        : base(succsess, message, messageId) => (Data) = (data);
    public DataResult(T data, bool succsess)
        : base(succsess) => (Data) = (data);
}