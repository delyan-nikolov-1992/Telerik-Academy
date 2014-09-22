﻿namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}