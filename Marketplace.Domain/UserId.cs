using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Domain
{
    public class UserId : Value<UserId>
    {
        private readonly Guid _value;
        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentException(nameof(value), "User id cannot be emtpy");
            _value = value;
        }
    }
}
