using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldDB.Entities
{
    [Keyless]
    public partial class HighEarningEmployee
    {
        public byte[]? Name { get; set; }
        public long? HouseNumber { get; set; }
        public string? ArtistCity { get; set; }
        public string? AlbumName { get; set; }
        public double? AlbumPrice { get; set; }
    }
}
