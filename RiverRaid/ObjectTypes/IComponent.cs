using System.Collections.Generic;

namespace RiverRaid.ObjectTypes
{
    interface IComponent
    {
        List<IEntity> EntityList { get; set; }
        List<IEntity> UpdateList { get; set; }
    }
}