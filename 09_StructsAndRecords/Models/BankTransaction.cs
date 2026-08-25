namespace CSharp.Mastery.StructsAndRecords.Models;

// Record class (reference type). Excellent for immutable data models (Domain Driven Design).
// Uses positional syntax.
public record BankTransaction(Guid TransactionId, decimal Amount, string Description, DateTime Date)
{
    // Records provide built-in value-based equality, ToString(), and Deconstruct out of the box.
}
