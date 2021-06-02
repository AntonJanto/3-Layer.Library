namespace NextIT.Assignment.Models.Requests
{
    public class PatchRequest<T>
    {
        public string Op { get; set; }
        public T Data { get; set; }
    }
}