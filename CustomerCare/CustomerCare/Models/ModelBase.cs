using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCare.Models
{
    public abstract class ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public virtual int Id { get; set; }
    }
}
