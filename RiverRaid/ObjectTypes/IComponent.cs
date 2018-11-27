using System.Collections.Generic;

namespace RiverRaid.ObjectTypes
{
    interface IComponent
    {
        List<IEntity> DrawList { get; set; }
        List<IEntity> UpdateList { get; set; }
    }
}