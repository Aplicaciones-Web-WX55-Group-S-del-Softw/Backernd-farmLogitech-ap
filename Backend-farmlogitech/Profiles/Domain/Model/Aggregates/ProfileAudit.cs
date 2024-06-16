using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Backend_farmlogitech.Profiles.Domain.Model.Aggregates
{
    public partial class Profile : IEntityWithCreatedUpdatedDate
    {
        [Column("created_at")] public DateTimeOffset? CreatedDate { get; set; }
        [Column("updated_at")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}