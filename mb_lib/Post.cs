// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace mb_lib
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public long PostId { get; set; }
        public long? PostOwnerId { get; set; }
        public string Post1 { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }

        public virtual Register PostOwner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}