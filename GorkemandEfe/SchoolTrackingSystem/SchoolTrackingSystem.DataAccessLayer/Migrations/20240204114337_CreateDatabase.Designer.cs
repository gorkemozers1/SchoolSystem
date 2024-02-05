using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolTrackingSystem.DataAccessLayer.DataContext;

#nullable disable

namespace SchoolTrackingSystem.DataAccessLayer.Migrations
{
    [DbContext(typeof(SchoolTrackingDatabaseModelContext))]
    [Migration("20240204114337_CreateDatabase")]
    partial class CreateDatabase
    {
        
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolTrackingSystem.EntityLayer.Model.Students", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Classroom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FatherNumber")
                        .HasColumnType("decimal(20,0)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("MotherNumber")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PhoneNumber")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int>("SchoolNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Students", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
