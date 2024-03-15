using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<UserLike> Likes { get; set; }
    public DbSet<Message> Messages { get; set; }


    //Tables Relations
    protected override void OnModelCreating(ModelBuilder builder)
    {
       base.OnModelCreating(builder); 

       builder.Entity<UserLike>()
            .HasKey(k => new {k.SourceUserId, k.TargetUserId});
        

        //For SourceUser it likes many users and has key SourceUserId
       builder.Entity<UserLike>()
            .HasOne(s => s.SourceUser)
            .WithMany(l => l.LikedUsers)
            .HasForeignKey(s => s.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade); //For SQL Server Cascade Does Not Work , Only .NoAction Is Useful
          

        //For Target User Its liked by many Users and it has Key TargetUserID
       builder.Entity<UserLike>()
            .HasOne(s => s.TargetUser)
            .WithMany(l => l.LikedByUsers)
            .HasForeignKey(s => s.TargetUserId)
            .OnDelete(DeleteBehavior.Cascade); //For SQL Server Cascade Does Not Work , Only .NoAction Is Useful


        
        builder.Entity<Message>()
            .HasOne(u => u.Recipient)
            .WithMany(m => m.MessagesReceived)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<Message>()
            .HasOne(u => u.Sender)
            .WithMany(m => m.MessagesSent)
            .OnDelete(DeleteBehavior.Restrict);
            
    }

}
