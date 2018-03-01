﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Validations
{
    public interface IFriendValidation : IValidation<Friend>
    {
        void ValidateIfHasGameBorrowed();
    }
}
