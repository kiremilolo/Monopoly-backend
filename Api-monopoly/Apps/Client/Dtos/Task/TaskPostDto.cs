﻿namespace Api_monopoly.Apps.Client.Dtos.Task
{
    public class TaskPostDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Point { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
