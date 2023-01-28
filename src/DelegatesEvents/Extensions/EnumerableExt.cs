using System.Collections;

namespace DelegatesEvents.Extensions;

public static partial class EnumerableExt
{
    public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter)
        where T : class
    {
        if (e == null)
        {
            throw new Exception("No element");
        }

        if (getParameter == null)
        {
            throw new Exception("No function");
        }

        T value;

        var el = e.GetEnumerator();

        if (!el.MoveNext())
        {
            throw new Exception("No elements");
        }

        value = (T)el.Current;

        if (!el.MoveNext())
        {
            return value;
        }

        T x = (T)el.Current;

        if (getParameter(x) > getParameter(value))
        {
            value = x;
        }

        while (el.MoveNext())
        {
            x = (T)el.Current;

            if (getParameter(x) > getParameter(value))
            {
                value = x;
            }
        }

        return value;
    }
}
