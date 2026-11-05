namespace ZellaBeautyPos.Web.Services;

public record Toast(Guid Id, string Message, bool IsError);

public class ToastService
{
    public event Action? Changed;
    public List<Toast> Items { get; } = [];

    public void Success(string message) => Add(message, false);
    public void Error(string message) => Add(message, true);

    void Add(string message, bool isError)
    {
        var t = new Toast(Guid.NewGuid(), message, isError);
        lock (Items) Items.Add(t);
        Changed?.Invoke();
        _ = Task.Delay(3500).ContinueWith(_ => Dismiss(t.Id));
    }

    public void Dismiss(Guid id)
    {
        lock (Items) Items.RemoveAll(t => t.Id == id);
        Changed?.Invoke();
    }
}
