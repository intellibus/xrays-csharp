using System;

namespace XRays
{
    public struct XResult<T>
    {
        public readonly T Result;
        public readonly Exception Error;

        public bool HasError => Error != null;

        public XResult(T value)
        {
            Result = value;
            Error = null;
        }

        public XResult(Exception error)
        {
            Error = error;
            Result = default;
        }

        public void Deconstruct(out T result, out Exception error)
        {
            result = Result;
            error = Error;
        }
    }
}
