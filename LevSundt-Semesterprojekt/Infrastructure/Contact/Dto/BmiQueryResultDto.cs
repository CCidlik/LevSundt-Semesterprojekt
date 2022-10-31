﻿namespace LevSundt_Semesterprojekt.Infrastructure.Contact.Dto;

public class BmiQueryResultDto
{
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Bmi { get; set; }
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public byte[] RowVersion { get; set; }

    public string UserId { get; set; }
}