using System;
using System.Threading.Tasks;

namespace XRays
{
    public static class XRays
    {
        public async static Task<XResult<TResult>> X<TResult>(this Task<TResult> throwable)
        {
            try
            {
                var result = await throwable;
                return new XResult<TResult>(result);
            }
            catch (Exception e)
            {
                return new XResult<TResult>(e);
            }
        }
    }
}
