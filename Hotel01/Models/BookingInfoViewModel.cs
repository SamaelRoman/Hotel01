using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel01.Models
{
    public class BookingInfoViewModel
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key]
        [Required]
        public Guid ID { get; set; }
        /// <summary>
        /// Дата начала бронирования.
        /// </summary>
        [Display(Name = "Дата заселения!")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartBooking { get; set; }
        /// <summary>
        /// Дата окончания бронирвоания.
        /// </summary>
        [Display(Name = "Дата выселения!")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndBooking { get; set; }
        /// <summary>
        /// Номер для бронирования!
        /// </summary>
        [Required]
        public RoomViewModel Room { get; set; }
        public int? RoomID { get; set; }
        /// <summary>
        /// Постоялец забронировавший номер.
        /// </summary>
        [Required]
        public CustomerViewModel Customer { get; set; }
        public Guid CustomerID { get; set; }
        /// <summary>
        /// Количество дней бронирования.
        /// </summary>
        [NotMapped]
        public int NumberOfDays { get { return (EndBooking - StartBooking).Days; } }
        /// <summary>
        /// Итоговая цена.
        /// </summary>
        [DataType(DataType.Currency)]
        [NotMapped]
        public decimal TotalPrice { get {
                decimal result = 0;
                for (int i = 0; i <= NumberOfDays; i++)
                {
                    result += Room.Category.CategoryInfos.First(CI => CI.PriceAtTheMomentStart <= StartBooking.AddDays(i) && CI.PriceAtTheMomentEnd >= StartBooking.AddDays(i)).Price;
                }
                return result;
            } }
        public BookingInfoViewModel()
        {
            this.ID = Guid.NewGuid();
        }
    }
}