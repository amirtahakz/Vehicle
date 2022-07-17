﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Data.Entities
{
    public abstract class BaseEntity
    {
        #region Properties

        [Key]
        public Guid Id { get; protected set; }

        [Required(ErrorMessage = "{0} is required.")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [DefaultValue(false)]
        [Required(ErrorMessage = "{0} is required.")]
        public bool IsRemove { get; set; }

        #endregion
    }
}
