﻿using System;

namespace Bll.Core.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }

        public ValidationException(string message) : base(message)
        {
        }
    }
}
