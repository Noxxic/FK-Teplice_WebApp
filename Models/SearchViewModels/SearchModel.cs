using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using FKTeplice.Data;
using Microsoft.AspNetCore.Http;

namespace FKTeplice.Models.SearchViewModels
{
    public class SearchModel {
        public string Query { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}