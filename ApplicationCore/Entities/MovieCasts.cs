﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCasts
    {
        [Required]
        public int CastId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(450)")]
        public string Character { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}
