namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public enum SettlementType
    {
        None = 0,
        Daily = 1,
        BeginningOfMonth = 2,
        EndOfMonth = 3,
        MidMonth = 4,
        OnDemand = 5,
        OnDemandWithCatch = 6,
        OncePerDay = 7,
        Ignore = 8,
    }
}