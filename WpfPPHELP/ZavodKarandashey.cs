//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfPPHELP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZavodKarandashey
    {
        public int ID_SozdanogoKarandasha { get; set; }
        public int KarandashiType_ID { get; set; }
        public int Razmer_ID { get; set; }
        public int Chvet_ID { get; set; }
        public double Price { get; set; }
    
        public virtual Chvet Chvet { private get; set; }
        public virtual Karandashi Karandashi { private get; set; }
        public virtual Razmer Razmer { private get; set; }
    }
}
