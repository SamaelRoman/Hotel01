using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Hotel01.DAL.Etities
{
    public class Customer
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key]
        [Required]
        public Guid ID { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        [Display(Name = "Имя")]
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия.
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        /// <summary>
        /// Отчество.
        /// </summary>
        [Display(Name = "Отчество")]
        [Required]
        [DataType(DataType.Text)]
        public string Patronymic { get; set; }
        /// <summary>
        /// Вычисляемое свойство.ФИО клиента.
        /// </summary>
        [DataType(DataType.Text)]
        [NotMapped]
        public string FullName { get {return $"{LastName} {FirstName} {Patronymic}"; } }
        /// <summary>
        /// Номер телефона.
        /// </summary>
        [Display(Name = "Номер телефона")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }
        /// <summary>
        /// Номер паспорта.
        /// </summary>
        [Required]
        [Display(Name = "Номер паспорта")]
        [DataType(DataType.Text)]
        [RegularExpression(@"(?:^|\s)[А-Я]{2}([ ]?){1}\d{6}(?:$|\s|\,)",ErrorMessage = "Введите коректный номер паспорта! в формате \"ЕЕ000000\"")]
        public string PassportID { get; set; }
        /// <summary>
        /// Список объектов класса BookingIfo содержащих информацию о бронировании номера (Кем забронирован, на какую дату, и тд).
        /// </summary>
        public virtual ICollection<BookingInfo> BookingInfos { get; set; }

    }
}