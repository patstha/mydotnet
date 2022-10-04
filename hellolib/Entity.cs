namespace hellolib
{
    public abstract class Entity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; } = "System";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
