//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Individueel_Project_Sergio
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klant()
        {
            this.Bestellings = new HashSet<Bestelling>();
        }
    
        public int KlantID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnumme { get; set; }
        public int Bus { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Telefoonnummer { get; set; }
        public string Emailadres { get; set; }
        public System.DateTime AangemaaktOp { get; set; }
        public string Opmerking { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bestelling> Bestellings { get; set; }
    }
}
