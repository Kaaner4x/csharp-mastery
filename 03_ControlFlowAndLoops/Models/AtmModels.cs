namespace CSharp.Mastery.ControlFlowAndLoops.Models;

public enum AtmState
{
    Idle,
    CardInserted,
    PinEntered,
    TransactionMenu,
    Exiting
}

public class BankAccount
{
    public string CardNumber { get; set; } = "1234-5678";
    public string PinCode { get; set; } = "1234";
    public decimal Balance { get; set; } = 15000.00m;
}
