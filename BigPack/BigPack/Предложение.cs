//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BigPack
{
    using System;
    using System.Collections.Generic;
    
    public partial class Предложение
    {
        public int ID { get; set; }
        public Nullable<int> ID_аналитика { get; set; }
        public Nullable<int> ID_менеджера { get; set; }
        public Nullable<int> ID_агента { get; set; }
        public string Наименование { get; set; }
        public string Описание { get; set; }
    
        public virtual Агент Агент { get; set; }
        public virtual Аналитик Аналитик { get; set; }
        public virtual Менеджер Менеджер { get; set; }
    }
}
