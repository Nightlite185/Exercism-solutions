public struct CurrencyAmount(decimal amount, string currency)
{
    private decimal amount = amount;
    private string currency = currency;

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount == n2.amount
        : throw new ArgumentException("Cannot compare different currencies.");

    public static bool operator !=(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount != n2.amount
        : throw new ArgumentException("Cannot compare different currencies.");

    // TODO: implement comparison operators
    public static bool operator >(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount > n2.amount
        : throw new ArgumentException("Cannot compare different currencies.");

    public static bool operator <(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount < n2.amount
        : throw new ArgumentException("Cannot compare different currencies.");

    // TODO: implement arithmetic operators
    public static decimal operator +(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount + n2.amount
        : throw new ArgumentException("Cannot execute operations on different currencies.");

    public static decimal operator -(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount - n2.amount
        : throw new ArgumentException("Cannot execute operations on different currencies.");

    public static decimal operator /(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount / n2.amount
        : throw new ArgumentException("Cannot execute operations on different currencies.");

    public static decimal operator *(CurrencyAmount n1, CurrencyAmount n2)
        => n1.currency == n2.currency
        ? n1.amount * n2.amount
        : throw new ArgumentException("Cannot execute operations on different currencies.");

    // TODO: implement type conversion operators
    public static explicit operator double(CurrencyAmount amount)
        => (double)amount.amount;

    public static implicit operator decimal(CurrencyAmount amount)
        => (decimal)amount.amount;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not CurrencyAmount other || other.currency != this.currency)
            return false;

        return this.amount == other.amount;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.amount, this.currency);
    }
}