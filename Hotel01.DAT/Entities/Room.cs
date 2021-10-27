using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;


namespace Hotel01.DAL.Etities
{
    /// <summary>
    /// Класс гостинечного номера.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Уникальный идентификатор, является номером комнаты.
        /// </summary>
        [Key]
        [Display(Name = "Номер комнаты")]
        [Required(ErrorMessage = "Поле \"номер комнаты\" обязательно к заполнению!")]
        public int ID { get; set; }            
        /// <summary>
        /// Фотографии номера
        /// </summary>
        [Display(Name = "Фотографии номера")]
        [InverseProperty("Room")]
        public virtual ICollection<RoomImage> RoomImages { get; set; }
        /// <summary>
        /// Путь к превью фотографии.Превью фото это случайная из его фотографий!.
        /// </summary>
        [NotMapped]
        [DataType(DataType.ImageUrl)]
        public string Preview { get {
                var rnd = new Random();
                var index = rnd.Next(RoomImages.Count-1);
                return $"{RoomImages.ElementAt(index).ImgName}"; } }
        /// <summary>
        /// Категория номера.
        /// </summary>
        [Display(Name = "Категория:")]
        public Category Category { get; set; }
        public Guid CategoryID { get; set; }
        /// <summary>
        /// Список объектов класса BookingIfo содержащих информацию о бронировании номера (Кем забронирован, на какую дату, и тд).
        /// </summary>
        public virtual ICollection<BookingInfo> BookingInfos { get; set; }
        /// <summary>
        /// Вычесляемое свойство. Возвращает ответ есть ли активные брони на данный номер.В случае наличия брони возвращает true!
        /// </summary>
        [NotMapped]
        public bool IsBooked { get { if (BookingInfos.Count > 0) { return true; } else { return false; };} }
        public Room()
        {
            RoomImages = new List<RoomImage>();
            BookingInfos = new List<BookingInfo>();
        }
    }
}