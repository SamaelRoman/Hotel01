using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel01.DAL.Etities
{
    public class RoomImage
    {
        /// <summary>
        /// Уникальный идентификатор + имя файла.
        /// </summary>
        [Key]
        [Required]
        public Guid ID { get; set; }
        /// <summary>
        /// Расширение фотографии.
        /// </summary>
        [Required]
        public string Extension { get; set; }
        /// <summary>
        /// Имя Файла.
        /// </summary>
        [NotMapped]
        public string ImgName { get { return $"{ID}.{Extension}"; } }
        /// <summary>
        /// Сылка на номер, которому пренадлежит фотография.
        /// </summary>
        [Required]
        public Room Room{ get; set; }
        public int? RoomID { get; set; }

    }
}