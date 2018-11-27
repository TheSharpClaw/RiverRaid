using RiverRaid.ObjectTypes;

namespace RiverRaid.Objects.Tiles
{
    interface ITile : IEntity
    {
        bool ToDestroy { get; }
    }
}