using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Models;
using Statistic.Domain.Models.Enums;

namespace Statistic.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Окружающая среда" },
                new Category { Id = 2, Name = "Население и демографические процессы" },
                new Category { Id = 3, Name = "Социальная статистика" },
                new Category { Id = 4, Name = "Экономическая статистика" },
                new Category { Id = 5, Name = "Гендерная статистика" },
                new Category { Id = 6, Name = "Региональная статистика" },
                new Category { Id = 7, Name = "Метеорология", ParentCategoryId = 1 },
                new Category { Id = 8, Name = "Водопользование", ParentCategoryId = 1 },
                new Category { Id = 9, Name = "Охрана атмосферного воздуха", ParentCategoryId = 1 },
                new Category { Id = 10, Name = "Отходы", ParentCategoryId = 1 },
                new Category { Id = 11, Name = "Земельный и лесной фонд", ParentCategoryId = 1 },
                new Category { Id = 12, Name = "Городская инфраструктура", ParentCategoryId = 1 },
                new Category { Id = 13, Name = "Текущие расходы на охрану окружающей среды и экологические платежи", ParentCategoryId = 1 },
                new Category { Id = 14, Name = "Среднемесячная температура воздуха", ParentCategoryId = 7, Description = "air-temperature" },
                new Category { Id = 15, Name = "Месячное количество осадков", ParentCategoryId = 7 },
                new Category { Id = 16, Name = "Среднемесячная скорость ветра", ParentCategoryId = 7 }
            );

            modelBuilder.Entity<Contact>().HasData(
    new Contact
    {
        Id = 1,
        Name = "Источник 1",
        Address = "Описание источника 1",
        Phone = null,
        Email = "https://source1.com"
    },
    new Contact
    {
        Id = 2,
        Name = "Источник 2",
        Address = "Описание источника 2",
        Phone = null,
        Email = "https://source2.com"
    },
    new Contact
    {
        Id = 3,
        Name = "Источник 3",
        Address = "Описание источника 3",
        Phone = null,
        Email = "https://source3.com"
    },
    new Contact
    {
        Id = 4,
        Name = "Источник 4",
        Address = "Описание источника 4",
        Phone = null,
        Email = "https://source4.com"
    }
);

            modelBuilder.Entity<Meteorology>().HasData(
     new Meteorology
     {
         Id = 11,
         AirTemperature = "15°C",
         PrecipitationQuantity = "30mm",
         AverageMonthlyWindSpeed = "5 m/s",
         Month = "Январь",
         Year = 2023,
         ContactId = 1,
         Unit = MeasurementUnit.Celsius,
         SourceId = 1,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 12,
         AirTemperature = "10°C",
         PrecipitationQuantity = "50mm",
         AverageMonthlyWindSpeed = "7 m/s",
         Month = "Февраль",
         Year = 2023,
         ContactId = 2,
         Unit = MeasurementUnit.Celsius,
         SourceId = 1,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 13,
         AirTemperature = "20°C",
         PrecipitationQuantity = "20mm",
         AverageMonthlyWindSpeed = "4 m/s",
         Month = "Март",
         Year = 2023,
         ContactId = 3,
         Unit = MeasurementUnit.Celsius,
         SourceId = 1,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 14,
         AirTemperature = "18°C",
         PrecipitationQuantity = "35mm",
         AverageMonthlyWindSpeed = "6 m/s",
         Month = "Апрель",
         Year = 2023,
         ContactId = 4,
         Unit = MeasurementUnit.Celsius,
         SourceId = 2,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 15,
         AirTemperature = "22°C",
         PrecipitationQuantity = "40mm",
         AverageMonthlyWindSpeed = "3 m/s",
         Month = "Май",
         Year = 2023,
         ContactId = 5,
         Unit = MeasurementUnit.Celsius,
         SourceId = 2,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 16,
         AirTemperature = "25°C",
         PrecipitationQuantity = "25mm",
         AverageMonthlyWindSpeed = "8 m/s",
         Month = "Июнь",
         Year = 2023,
         ContactId = 2,
         Unit = MeasurementUnit.Celsius,
         SourceId = 3,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 17,
         AirTemperature = "30°C",
         PrecipitationQuantity = "15mm",
         AverageMonthlyWindSpeed = "2 m/s",
         Month = "Июль",
         Year = 2023,
         ContactId = 3,
         Unit = MeasurementUnit.Celsius,
         SourceId = 3,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 18,
         AirTemperature = "28°C",
         PrecipitationQuantity = "45mm",
         AverageMonthlyWindSpeed = "6 m/s",
         Month = "Август",
         Year = 2023,
         ContactId = 4,
         Unit = MeasurementUnit.Celsius,
         SourceId = 3,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 19,
         AirTemperature = "24°C",
         PrecipitationQuantity = "30mm",
         AverageMonthlyWindSpeed = "4 m/s",
         Month = "Сентябрь",
         Year = 2023,
         ContactId = 2,
         Unit = MeasurementUnit.Celsius,
         SourceId = 4,
         CategoryId = 7
     },
     new Meteorology
     {
         Id = 20,
         AirTemperature = "19°C",
         PrecipitationQuantity = "25mm",
         AverageMonthlyWindSpeed = "5 m/s",
         Month = "Октябрь",
         Year = 2023,
         ContactId = 3,
         Unit = MeasurementUnit.Celsius,
         SourceId = 4,
         CategoryId = 7
     }
 );

            modelBuilder.Entity<Source>().HasData(
    new Source
    {
        Id = 1,
        Name = "Источник 1",
        Description = "Описание источника 1",
        Link = "https://source1.com"
    },
    new Source
    {
        Id = 2,
        Name = "Источник 2",
        Description = "Описание источника 2",
        Link = "https://source2.com"
    },
    new Source
    {
        Id = 3,
        Name = "Источник 3",
        Description = "Описание источника 3",
        Link = "https://source3.com"
    },
    new Source
    {
        Id = 4,
        Name = "Источник 4",
        Description = "Описание источника 4",
        Link = "https://source4.com"
    }
    );

        }
    }

}