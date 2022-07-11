﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackageDelivery.Persistence;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    [DbContext(typeof(PackageDeliveryDbContext))]
    [Migration("20220710233206_SeedEventTypes")]
    partial class SeedEventTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PackageDelivery.Domain.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeliveryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Amount");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("BarCode");

                    b.Property<string>("ClientReference")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ClientReference");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDateUtc");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeliveryDate");

                    b.Property<string>("Eta")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ETA");

                    b.Property<string>("Instructions")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Instructions");

                    b.Property<int>("NumberOfVolumes")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfVolumes");

                    b.Property<DateTime?>("PickingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("PickingDate");

                    b.Property<string>("PinNumber")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("PinNumber");

                    b.Property<string>("PreferentialPeriod")
                        .HasMaxLength(23)
                        .HasColumnType("nvarchar(23)")
                        .HasColumnName("PreferentialPeriod");

                    b.Property<string>("ReceiverAddress")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("ReceiverAddress");

                    b.Property<string>("ReceiverAddressCountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("ReceiverAddressCountryCode");

                    b.Property<string>("ReceiverAddressPlace")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReceiverAddressPlace");

                    b.Property<string>("ReceiverAddressZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("ReceiverAddressZipCode");

                    b.Property<string>("ReceiverAddressZipCodePlace")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReceiverAddressZipCodePlace");

                    b.Property<string>("ReceiverClientCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ReceiverClientCode");

                    b.Property<string>("ReceiverContactEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReceiverContactEmail");

                    b.Property<string>("ReceiverContactName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("ReceiverContactName");

                    b.Property<string>("ReceiverContactPhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReceiverContactPhoneNumber");

                    b.Property<string>("ReceiverFixedInstructions")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ReceiverFixedInstructions");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReceiverName");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("SenderAddress");

                    b.Property<string>("SenderAddressCountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("SenderAddressCountryCode");

                    b.Property<string>("SenderAddressPlace")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SenderAddressPlace");

                    b.Property<string>("SenderAddressZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("SenderAddressZipCode");

                    b.Property<string>("SenderAddressZipCodePlace")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SenderAddressZipCodePlace");

                    b.Property<string>("SenderClientCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("SenderClientCode");

                    b.Property<string>("SenderContactEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SenderContactEmail");

                    b.Property<string>("SenderContactName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SenderContactName");

                    b.Property<string>("SenderContactPhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SenderContactPhoneNumber");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SenderName");

                    b.Property<decimal>("TotalWeightOfVolumes")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("TotalWeightOfVolumes");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDateUtc");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverAddress");

                    b.HasIndex("ReceiverContactPhoneNumber");

                    b.HasIndex("SenderAddress");

                    b.HasIndex("SenderContactPhoneNumber");

                    b.ToTable("Deliveries", "dbo");
                });

            modelBuilder.Entity("PackageDelivery.Domain.DeliveryAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeliveryAttributeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDateUtc");

                    b.Property<string>("DeliveryAttributeENG")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DeliveryAttributeENG");

                    b.Property<string>("DeliveryAttributeES")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DeliveryAttributeES");

                    b.Property<string>("DeliveryAttributePT")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DeliveryAttributePT");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDateUtc");

                    b.HasKey("Id");

                    b.ToTable("DeliveryAttributes", "dbo");
                });

            modelBuilder.Entity("PackageDelivery.Domain.DeliveryDeliveryAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDateUtc");

                    b.Property<int>("DeliveryAttributeId")
                        .HasColumnType("int")
                        .HasColumnName("DeliveryAttributeId");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("DeliveryId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDateUtc");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAttributeId");

                    b.HasIndex("DeliveryId");

                    b.ToTable("Delivery_DeliveryAttributes", "dbo");
                });

            modelBuilder.Entity("PackageDelivery.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EventId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDateUtc");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("DeliveryId");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int")
                        .HasColumnName("EventTypeId");

                    b.Property<int?>("PackageId")
                        .HasColumnType("int")
                        .HasColumnName("VolumeId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDateUtc");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("PackageId");

                    b.ToTable("Events", "dbo");
                });

            modelBuilder.Entity("PackageDelivery.Domain.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EventTypeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDateUtc");

                    b.Property<string>("EventTypeENG")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EventTypeENG");

                    b.Property<string>("EventTypeES")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EventTypeES");

                    b.Property<string>("EventTypePT")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EventTypePT");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDateUtc");

                    b.HasKey("Id");

                    b.ToTable("EventTypes", "dbo");
                });

            modelBuilder.Entity("PackageDelivery.Domain.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PackageId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDateUtc");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("DeliveryId");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(10,3)")
                        .HasColumnName("Height");

                    b.Property<decimal?>("Length")
                        .HasColumnType("decimal(10,3)")
                        .HasColumnName("Length");

                    b.Property<string>("PackageBarCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PackageBarCode");

                    b.Property<int>("PackageNumber")
                        .HasColumnType("int")
                        .HasColumnName("PackageNumber");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDateUtc");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("Weight");

                    b.Property<decimal?>("Width")
                        .HasColumnType("decimal(10,3)")
                        .HasColumnName("Width");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("Packages", "dbo");
                });

            modelBuilder.Entity("PackageDelivery.Domain.DeliveryDeliveryAttribute", b =>
                {
                    b.HasOne("PackageDelivery.Domain.DeliveryAttribute", "DeliveryAttribute")
                        .WithMany("DeliveryDeliveryAttributes")
                        .HasForeignKey("DeliveryAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Deliveries_DeliveryAttributes_DeliveryAttributes_DeliveryAttributeId");

                    b.HasOne("PackageDelivery.Domain.Delivery", "Delivery")
                        .WithMany("DeliveryDeliveryAttributes")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Deliveries_DeliveryAttributes_Deliveries_DeliveryId");

                    b.Navigation("Delivery");

                    b.Navigation("DeliveryAttribute");
                });

            modelBuilder.Entity("PackageDelivery.Domain.Event", b =>
                {
                    b.HasOne("PackageDelivery.Domain.Delivery", "Delivery")
                        .WithMany("Events")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Events_Deliveries_DeliveryId");

                    b.HasOne("PackageDelivery.Domain.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Events_EventTypes_EventTypeId");

                    b.HasOne("PackageDelivery.Domain.Package", "Package")
                        .WithMany("Events")
                        .HasForeignKey("PackageId")
                        .HasConstraintName("FK_Events_Packages_PackageId");

                    b.Navigation("Delivery");

                    b.Navigation("EventType");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("PackageDelivery.Domain.Package", b =>
                {
                    b.HasOne("PackageDelivery.Domain.Delivery", "Delivery")
                        .WithMany("Packages")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Packages_Deliveries_DeliveryId");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("PackageDelivery.Domain.Delivery", b =>
                {
                    b.Navigation("DeliveryDeliveryAttributes");

                    b.Navigation("Events");

                    b.Navigation("Packages");
                });

            modelBuilder.Entity("PackageDelivery.Domain.DeliveryAttribute", b =>
                {
                    b.Navigation("DeliveryDeliveryAttributes");
                });

            modelBuilder.Entity("PackageDelivery.Domain.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("PackageDelivery.Domain.Package", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
