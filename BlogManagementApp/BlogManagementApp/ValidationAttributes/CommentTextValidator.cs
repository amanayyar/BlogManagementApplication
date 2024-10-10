using System.ComponentModel.DataAnnotations;

namespace BlogManagementApp.ValidationAttributes
{
    public class CommentTextValidator : ValidationAttribute
    {
        private readonly HashSet<string> _blacklist;

        public CommentTextValidator()
        {
            // Initialize blacklist and whitelist
            // In a real application, consider loading these from a database or configuration
            _blacklist = new HashSet<string> { "badword1", "badword2", "badword3" };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var text = value as string;
            if (string.IsNullOrEmpty(text))
            {
                return ValidationResult.Success;
            }

            var words = text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (_blacklist.Contains(word))
                {
                    return new ValidationResult($"The comment contains a prohibited word: {word}");
                }
            }

            return ValidationResult.Success;
        }
    }
}