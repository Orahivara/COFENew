//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COFE.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompositionProduct
    {
        public int IDComposition { get; set; }
        public int IDProduct { get; set; }
    
        public virtual Composition Composition { get; set; }
    }
}