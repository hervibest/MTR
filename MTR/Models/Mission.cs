namespace MTR.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Simple task without deadline and optional priority.
    /// </summary>
    /// ///// <para>???Maybe it needs Recurrence???</para>
    public class Mission : BaseObjectModel, IComparable<Mission>
    {
        /// <summary>
        /// The priority for this task
        /// </summary>
        private Priority priority;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mission"/> class
        /// <para>A simple task without deadline and optional priority</para>
        /// </summary>
        public Mission()
        {
            this.Title = "New Task";
            this.Description = "Enter_description";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mission"/> class
        /// <para>A simple task without deadline and optional priority</para>
        /// </summary>
        /// <param name="title">The task's title</param>
        /// <param name="description">The task's description</param>
        /// <param name="priority">The task's priority</param>
        public Mission(string title, string description, Priority priority = Priority.None)
            : base(title, description)
        {
            this.Priority = priority;
        }

        /// <summary>
        /// Gets or sets the priority for this task
        /// </summary>
        public Priority Priority
        {
            get
            {
                return this.priority;
            }

            set
            {
                this.priority ^= value;
                /* If property changes notify who is interested */
                this.OnPropertyChanged("Priority");
            }
        }

        /// <summary>
        /// Compares this instance with a specific ToDoList.Models.Task and indicates whether this instance precedes, follows,
        /// or appears in the same position in the sort order as the specified ToDoList.Models.Task
        /// </summary>
        /// <param name="other">A ToDoList.Models.Task to compare this instance to</param>
        /// <returns>-1, 0, or 1 depending on the end dates of the goals that are compared</returns>
        public int CompareTo(Mission other)
        {
            return this.Priority.CompareTo(other.Priority) * (-1);
        }

        /// <summary>
        /// Returns all the information of this instance of <see cref="Mission"/> as a string
        /// </summary>
        /// <returns>A string representation of this object</returns>
        public override string ToString()
        {
            return string.Format(
                "{0}\n{1}",
                base.ToString(),
                this.Priority);
        }
    }
}
