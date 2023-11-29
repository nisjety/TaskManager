namespace TaskManager.models
{
    public class UTask
    {
        //  Unique identifier for the task, auto-generated by the database. The setter is private to prevent external modification.
        public int Id { get; private set; } 
        // Title of the task. It is a mandatory field and cannot be null or whitespace.
        public string Title { get; set; }
        // Optional descriptive note for the task. It can be null or empty, just wrote note because it is easier to write
        public string Note { get; set; }
        // Due date for the task completion. The task's due date must be set to a future date.
        public DateTime DueDate { get; set; }

        // Constructs to ensure valid initial values for Title and DueDate.
        public UTask(string title, string? note, DateTime dueDate)
        {
            Title = !string.IsNullOrWhiteSpace(title) ? title : throw new ArgumentException("Title cannot be empty");
            Note = note ?? string.Empty;
            DueDate = dueDate > DateTime.Now ? dueDate : throw new ArgumentException("Due date must be in the future");
        }

        // Methods to update task properties
        public void UpdateTitle(string newTitle)
        {//Updates the title of the task ensuring that the new title is not null or whitespace.
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Title cannot be empty");
            }

            Title = newTitle;
        }

        public void UpdateNote(string? newNote)
        {// Updates the note for the task. The note can be null or empty.
            Note = newNote ?? string.Empty;
        }

        public void UpdateDueDate(DateTime newDueDate)
        {// Updates the due date of the task ensuring the new date is in the future.
            if (newDueDate <= DateTime.Now)
            {
                throw new ArgumentException("Due date must be in the future");
            }

            DueDate = newDueDate;
        }
    }
}