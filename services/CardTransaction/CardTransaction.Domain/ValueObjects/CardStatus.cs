namespace CardTransaction.Domain.ValueObjects;

public record CardStatus {
    
    public string CardReason { get; private set; }
    private static readonly string[] SupportedStatuses = { "Blocked", "UnBlocked", "Active", "RaiseDispute", "TopUp", "RequestStatement" };
    
    internal CardStatus() {
    }

    public CardStatus(string cardReason) {
        if (!SupportedStatuses.Contains(cardReason)) throw new ArgumentOutOfRangeException(nameof(cardReason),$"Unsupported reason: {cardReason}");

        CardReason = cardReason;
    }
}