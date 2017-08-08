using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ProfileDetEntityConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProfileDet>
    {
        public ProfileDetEntityConfiguration()
        {
            //OnetoManyRelation - looks the case of profile creation with profile details distributed 
            this.HasKey(p => p.ProfileId);
            this.Property(p => p.ProfileId).HasColumnName("ProfileID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.ToTable("ProfileDet");
            
            //try with using System.Data.Entity.ModelConfiguration; for HasDatabaseGeneratedOption()

            //There can be OnetoZeroOrOne and ManytoMany relationships , that can be worked on with reference when there there is Good Business need.
            //OnetoMany is easily applicable on required needs for now
            //OnetoZeroOrOne relationship can be used for having unique related records in 2 tables
            }
    }
    public class GeneralTopicsEntityConfiguration :System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GeneralTopics>
    {
        public GeneralTopicsEntityConfiguration()
        {
            //OnetoManyRelation  - looks the case of profile creation with profile details distributed
            this.HasKey<int>(p => p.TopicId);
            this.Property(p => p.TopicId).HasColumnName("Id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            //NonNull foreign Key/Mandatory Intersested topics- practically not necessary
            //this.HasRequired<ProfileDet>(p=>p.ProfileDet).WithMany(c=>c.InterestedTopicChecks).Map(fk => fk.MapKey("ProfileID")).WillCascadeOnDelete();
            //Nullable foreign key - Not must to have interseted Topics
            this.HasOptional<ProfileDet>(p=>p.ProfileDet).WithMany(c=>c.InterestedTopicChecks).Map(fk => fk.MapKey("ProfileID")).WillCascadeOnDelete(true);

            //CascadeonDelete working as expected,Column with data removed without any exception
            //There can be OnetoZeroOrOne and ManytoMany relationships , that can be worked on with reference when there there is Good Business need
            //OnetoMany is easily applicable on required needs for now            
            //OnetoZeroOrOne relationship can be used for having unique related records in 2 tables
        }

        //for Bigint column
        //[Key, Required]
        //public virtual long EntityId { get; set; }
    }

}
