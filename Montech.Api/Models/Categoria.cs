﻿using System.ComponentModel.DataAnnotations;

namespace Montech.Api.Models;

public class Categoria
{
    [Required(ErrorMessage = "O campo Id é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [MaxLength(25, ErrorMessage = "O tamanho do campo Nome não pode exceder 25 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo IsValid é obrigatório")]
    public bool IsValid { get; set; }
}
