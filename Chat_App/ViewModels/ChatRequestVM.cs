namespace Chat_App.ViewModels
{
    public sealed record ChatRequestVM
    {
        public string Prompt { get; set; } = string.Empty;
        public string ConnectionId { get; set; } = string.Empty;
    }
}
