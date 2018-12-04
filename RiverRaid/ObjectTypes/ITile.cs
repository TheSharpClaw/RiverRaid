namespace RiverRaid.ObjectTypes
{
    interface ITile : IEntity
    {
        bool ToDestroy { get; }
    }
}