using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Api.Repository
{
    public static class Seeder
    {
        public static void CustomerSettingSeeder(this ModelBuilder builder)
        {
            builder.Entity<Setting>().HasData(
                new List<Setting>
                {
                new()
                {
                    AttributeId = "CUS01", AttributeName = "Channel", Description = "Kênh phân phối",
                    IsDistributorAttribute = true, IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS02", AttributeName = "Sub channel", Description = "Kênh phân phối con",
                    IsDistributorAttribute = true, IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS03", AttributeName = "Business Partner type",
                    Description = "Loại hình khách hàng", IsDistributorAttribute = false, IsCustomerAttribute = false,
                    Used = true
                },
                new()
                {
                    AttributeId = "CUS04", AttributeName = "Business model", Description = "Mô hình kinh tế",
                    IsDistributorAttribute = true, IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS05", AttributeName = "Type pf model", Description = "Loại hình kinh doanh",
                    IsDistributorAttribute = false, IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS06", AttributeName = "Location", Description = "Vị trí",
                    IsDistributorAttribute = false, IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS07", AttributeName = "Area", Description = "Khu vực",
                    IsDistributorAttribute = false, IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS08", AttributeName = "Average monthly revenue",
                    Description = "Doanh số bình quân tháng", IsDistributorAttribute = false,
                    IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS09", AttributeName = "Contributed", Description = "Doanh số đóng góp",
                    IsDistributorAttribute = false, IsCustomerAttribute = true, Used = true
                },
                new()
                {
                    AttributeId = "CUS10", AttributeName = "Acreage", Description = "Diện tích",
                    IsDistributorAttribute = false, IsCustomerAttribute = false, Used = false
                }
                }
            );
        }

        public static void CustomerAttributeSeeder(this ModelBuilder builder)
        {
            builder.Entity<Models.Attribute>().HasData(
                new List<Models.Attribute>
                {
                new Models.Attribute
                {
                    SettingId = "CUS01", Code = "zb", Description = "Kênh phân phối zed", ShortName = "zb",
                    Parent = null, EffectiveDate = DateTime.UtcNow, ValidUntil = null
                },
                new Models.Attribute
                {
                    SettingId = "CUS02", Code = "za", Description = "Kênh phân phối con zep", ShortName = "zb",
                    Parent = null, EffectiveDate = DateTime.UtcNow, ValidUntil = null
                },
                new Models.Attribute
                {
                    SettingId = "CUS01", Code = "zc", Description = "Kênh phân phối zec", ShortName = "zb",
                    Parent = null, EffectiveDate = DateTime.UtcNow, ValidUntil = null
                },
                new Models.Attribute
                {
                    SettingId = "CUS03", Code = "zy", Description = "Khách hàng zyk", ShortName = "zb", Parent = null,
                    EffectiveDate = DateTime.UtcNow, ValidUntil = null
                },
                new Models.Attribute
                {
                    SettingId = "CUS04", Code = "zq", Description = " Mô hình zaq", ShortName = "zb", Parent = null,
                    EffectiveDate = DateTime.UtcNow, ValidUntil = null
                },
                });
        }
    }
}
