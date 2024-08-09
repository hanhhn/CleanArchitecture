namespace Domain.Entities.PostAggregate
{
    public class Comment : BaseEntity<string>
    {
        public string Owner { get; set; }
        public string Message { get; set; }
        public string PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}

