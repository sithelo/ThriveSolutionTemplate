namespace CardTransactionHostedService.Core.Entities;

public class TraderTransaction : BaseEntity {
    public string   ThriveId       { get; set; }
    public DateTime RequestDateUtc { get; } = DateTime.UtcNow;
    public float    Amount         { get; set; }
    public string   TransactionId  { get; set; }
    public string   Reason         { get; set; }
}