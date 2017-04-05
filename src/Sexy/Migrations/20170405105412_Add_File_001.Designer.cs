using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Sexy.Data;
using Sexy.Models;

namespace Sexy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170405105412_Add_File_001")]
    partial class Add_File_001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sexy.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateUploaded");

                    b.Property<string>("Extension");

                    b.Property<string>("Name");

                    b.Property<string>("OriginalFilename");

                    b.Property<string>("Source");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });
        }
    }
}
