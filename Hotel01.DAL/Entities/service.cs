using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel01.DAL.Etities
{
    public class service
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key]
        [Required]
        public Guid ID { get; set; }
        /// <summary>
        /// Заголовок услуги.
        /// </summary>
        [Display(Name = "Название присутствующей услуги!")]
        [Required(ErrorMessage = "Поле \"Название присутствующей услуги\" должно быть заполненно!")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Поле \"Название присутствующей услуги\" Должно содержать от 1го до 25ти символов!")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        /// <summary>
        /// Путь к иконке услуги.
        /// </summary>
        [Required(ErrorMessage = "Выберите иконку для услуги!")]
        [DataType(DataType.ImageUrl)]
        public string IconUrl { get; set; }
        /// <summary>
        /// Список категорий пренадлежащих к услуге.
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }
        public service()
        {
            this.ID = Guid.NewGuid();
            Categories = new List<Category>();
        }
    }
}