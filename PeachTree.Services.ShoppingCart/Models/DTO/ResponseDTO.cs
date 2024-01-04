﻿namespace PeachTree.Services.ShoppingCart.Models.Dto
{
	public class ResponseDTO
	{
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}