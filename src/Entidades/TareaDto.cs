﻿namespace Entidades;
public class TareaDto
{
    public int Id {get;set;}
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public bool Finalizada {get;set;}
    public DateTime FechaCreacion {get;set;}
    public DateTime FechaFinalizada {get;set;}
}