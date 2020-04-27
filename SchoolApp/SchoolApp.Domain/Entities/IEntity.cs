using System;

namespace SchoolApp.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}