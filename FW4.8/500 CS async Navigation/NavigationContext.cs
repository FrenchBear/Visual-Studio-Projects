using System.Threading.Tasks;
using System.Windows;

namespace CS500
{
    public interface INavigationContext<T, TResult> where T : UIElement
    {
        Task<TResult> WaitForContinuationTask();

        T UIelement { get; }

        void Continue(TResult returnValue);
    }

    // NavigationContext is implemented only one time, and a provider will give easy access
    // (similar to the relation between IEnumerator and IEnumerable)
    public class NavigationContext<T, TResult> : INavigationContext<T, TResult> where T : UIElement
    {
        public NavigationContext(T element)
        {
            this.element = element;
        }

        private readonly T element;

        // object behind "awaited tasks", maintains thread status for awaited tasks
        private TaskCompletionSource<TResult> cts;

        // Task<TResult> is awaitable
        public Task<TResult> WaitForContinuationTask()
        {
            cts = new TaskCompletionSource<TResult>();
            return cts.Task;
        }

        public T UIelement
        {
            get { return element; }
        }

        public void Continue(TResult returnValue)
        {
            // terminates the task and return a result, freeing waiting contexts
            cts.SetResult(returnValue);
        }
    }

    public interface INavigationContextProvider<T, TResult> where T : UIElement
    {
        INavigationContext<T, TResult> GetNavigationContext();
    }

    // Trick: simple class to enable type inferance by C# compiler on NavigationContext<T, TResult>
    public class NavigationContext<TResult>
    {
        // Since class is generic<TResult> and method is generic<T>, that means that actually
        // this method is generic <T, TResult>
        public static INavigationContext<T, TResult> Create<T>(T element) where T : UIElement
        {
            return new NavigationContext<T, TResult>(element);
        }
    }

    public enum NavigationResult
    {
        Home,
        GoBackward,
        GoForward
    }
}