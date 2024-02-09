using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Keeper.Domen.Models;

    public abstract class BaseModel
    {
        public int Id {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
