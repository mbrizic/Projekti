
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Sonar.Web.Model
{

using System;
    using System.Collections.Generic;
    
public partial class Event
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Event()
    {

        this.Comment = new HashSet<Comment>();

        this.EventPerson = new HashSet<EventPerson>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Nullable<System.DateTime> StartDate { get; set; }

    public Nullable<System.DateTime> EndDate { get; set; }

    public Nullable<float> Longitude { get; set; }

    public Nullable<float> Latitude { get; set; }

    public int AuthorID { get; set; }

    public int TownID { get; set; }

    public int StateID { get; set; }

    public string ImageUrl { get; set; }

    public string Contact { get; set; }

    public int EventTypeID { get; set; }

    public Nullable<int> Radius { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Comment> Comment { get; set; }

    public virtual Person Person { get; set; }

    public virtual EventType EventType { get; set; }

    public virtual EventState EventState { get; set; }

    public virtual Town Town { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<EventPerson> EventPerson { get; set; }

}

}
