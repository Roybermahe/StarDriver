        }
﻿namespace StarDriver.domain.core.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}