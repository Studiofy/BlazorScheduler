using System;

namespace BlazorScheduler.WASM.Demo.Models
{
    public class AppointmentDto
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; }
        public string? Class { get; set; }
    }
}
