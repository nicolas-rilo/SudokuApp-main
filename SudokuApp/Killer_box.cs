//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Es.Udc.DotNet.SudokuApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Killer_box
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Killer_box()
        {
            this.Cell = new HashSet<Cell>();
        }
    
        public long killerId { get; set; }
        public long sudokuId { get; set; }
        public Nullable<int> killer_value { get; set; }
    
        public virtual Sudoku Sudoku { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cell> Cell { get; set; }
    }
}
